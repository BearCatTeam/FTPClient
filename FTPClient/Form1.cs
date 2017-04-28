using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace FTPClient
{
    public partial class FTPApplication : Form
    {
        public NetworkStream nStream;
        public StreamReader rStream, commandStream; 
        TcpClient FTPSocket;
        NetworkStream pasvStrm = null;
        NetworkStream passiveConnection;
        private string current_dir = "";
        private string ServerIP = "";
        private string current_folder = "";

        public FTPApplication()
        {
            InitializeComponent();
            this.progressBar2.Maximum = 100;
            this.progressBar2.Minimum = 0;
        }

        public string sendFTPcmd(string cmd)
        {
            byte[] Messages;
            rStream = new StreamReader(nStream);
            Messages = Encoding.ASCII.GetBytes(cmd.ToCharArray());
            nStream.Write(Messages,0,Messages.Length);
            string response = "";
            string startStr = "";
            bool startMultiLine = false;
            try
            {
                while (true)
                {
                    response = rStream.ReadLine();
                    this.StatusBox.Items.Add(response);
                    this.StatusBox.Refresh();
                    if (response.Length < 4) continue; 
                    if (response.Substring(0,4).ElementAt(3)=='-' && startMultiLine==false)
                    {
                        startStr = response.Substring(0,3);
                        startMultiLine = true;
                    }
                    if (response.Substring(0,4).ElementAt(3)==' ')
                    {
                        if (startMultiLine == false)
                        {
                            break;
                        } else if (response.Substring(0,3)==startStr)
                        {
                            break;
                        }
                    }
                }
            } catch (Exception e)
            {
                MessageBox.Show("Server is not responding");
            }
            return response;
        }

        private void fillField()
        {
            if (this.userName.Text == "")
            {
                this.userName.Text = "anonymous";
            }
            if (this.userPass.Text == "")
            {
                this.userPass.Text = "user@user";
            }
            if (this.portNum.Text == "")
            {
                this.portNum.Text = "21";
            }
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            this.closeSock();
            //Binding FTP Server
            if (serverAddr.Text == "")
            {
                MessageBox.Show("Enter the server address");
                return;
            }
            this.fillField();
            serverAddr.Text = serverAddr.Text.Replace("ftp://", "").Replace(" ", "");
            if (serverAddr.Text.IndexOf("/") < 0)
            {
                serverAddr.Text += "/";
            }
            current_folder = serverAddr.Text.Substring(serverAddr.Text.IndexOf('/'));
            ServerIP = serverAddr.Text.Substring(0, serverAddr.Text.IndexOf('/'));
            FTPSocket = new TcpClient(ServerIP, int.Parse(portNum.Text));
            nStream = FTPSocket.GetStream();
            nStream.ReadTimeout = 10000;
            rStream = new StreamReader(nStream);
            StatusBox.Items.Add(rStream.ReadLine());
            //Authenticate
            StatusBox.Items.Add("USER " + userName.Text);
            sendFTPcmd("USER " + userName.Text + "\r\n");
            StatusBox.Items.Add("PASS " + userPass.Text);
            sendFTPcmd("PASS " + userPass.Text + "\r\n");

            //Call Show Folders and Files function after complete bind connection
            if (StatusBox.Items[4].ToString().Substring(0, 3) != "230") // Server returns 230
            {
                MessageBox.Show("Sorry, you are lost the connection. Please try again!");
            }
            else
            {
                MessageBox.Show("Successful connection. Welcome to our application!");
                sendFTPcmd("MODE S\r\n");
                sendFTPcmd("STRU F\r\n");
                sendFTPcmd("CWD " + current_folder + "\r\n");
                ShowFolder("NLST");
            }
            
        }

        public void ShowFolder(string cmd)
        {
            string[] FilesAndFolders;
            string FilesOrFolders;
            string folderList = "";
            FoldersBox.Items.Clear();
            string current_directory = this.sendFTPcmd("PWD\r\n");
            this.fileAddr.Text = current_directory.Substring(5).Substring(0, current_directory.Substring(5).IndexOf('"'));
            folderList = sendPassiveFTPcmd(cmd + "\r\n");
            FilesAndFolders = folderList.Split("\n".ToCharArray());
            bool isBinary = false;
            for (int i = 0; i < FilesAndFolders.GetUpperBound(0); i++)
            {
                FilesOrFolders = FilesAndFolders[i];
                string fileSize = "";     
                bool is213 = false;
                while (!is213)
                {
                    fileSize = sendFTPcmd("SIZE " + FilesOrFolders.Replace("\r", "").Replace("\n", "") + "\r\n");
                    if (fileSize.Substring(0, 3) == "213")
                    {
                        is213 = true;
                    } else if (fileSize.Substring(0, 3) == "550" )
                    {
                        if (fileSize.ToUpper().Contains("ASCII"))
                        {
                            sendFTPcmd("TYPE I\r\n");
                            isBinary = true;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                if (fileSize.Substring(0, 3) == "213")
                {
                    if (fileSize.Length > 4) fileSize = fileSize.Substring(4);
                    Int64 fileSize_int = 0;
                    Int64.TryParse(fileSize, out fileSize_int);
                    this.FoldersBox.Items.Add("FILE      | "+string.Format("SIZE = {0,10:N0} KB|", fileSize_int / 1024)+FilesOrFolders);

                } else
                {
                    this.FoldersBox.Items.Add("DIRECTORY | "+string.Format("SIZE = {0,10:N0} KB|", 0)+FilesOrFolders);
                }
                this.FoldersBox.Refresh();
            }
            if (isBinary == true) sendFTPcmd("TYPE A\r\n");
        }

        public string sendPassiveFTPcmd(string cmd)
        {
            byte[] Messages;
            System.Collections.ArrayList al = new ArrayList();
            byte[] RecvBytes = new byte[2048];
            Messages = Encoding.ASCII.GetBytes(cmd.ToCharArray());
            passiveConnection = createdPassiveConnection();
            commandStream = new StreamReader(nStream);
            string return_mess = "";
            using (StreamReader passiveReader = new StreamReader(passiveConnection))
            {
                nStream.Write(Messages, 0, Messages.Length);
                while (true)
                {
                    string res = commandStream.ReadLine();
                    if (res.Contains("150"))
                    {
                        this.StatusBox.Items.Add(res);
                        break;
                    }
                }
                if (passiveReader.Peek() > 0)
                {
                    return_mess += passiveReader.ReadToEnd();
                }
            }
            passiveConnection.Close();
            StatusBox.Refresh();
            while (true)
            {
                string res = commandStream.ReadLine();
                if (res.Contains("226"))
                {
                    this.StatusBox.Items.Add(res);
                    break;
                }
            }
            StatusBox.Refresh();
            return return_mess;
        }

        private NetworkStream createdPassiveConnection()
        {
            string[] commaSeperatedValues;
            int highByte = 0;
            int lowByte = 0;
            int passivePort = 0;
            string response = "";
            StatusBox.Items.Add("PASV");
            response = sendFTPcmd("PASV\r\n");
            if (response.ToString().Substring(0, 3) == "227")
            {
                commaSeperatedValues = response.Split(",".ToCharArray());
                highByte = Convert.ToInt16(commaSeperatedValues[4]) * 256;
                commaSeperatedValues[5] = commaSeperatedValues[5].Substring(0, commaSeperatedValues[5].IndexOf(")"));
                lowByte = Convert.ToInt16(commaSeperatedValues[5]);
                passivePort = highByte + lowByte;
                FTPSocket = new TcpClient(ServerIP, passivePort);
                pasvStrm = FTPSocket.GetStream();
            }
            return pasvStrm;
        }
       
        private void closeSock()
        {
            try
            {
                rStream.Close();
                commandStream.Close();
                pasvStrm.Close();
                FTPSocket.Close();
            }
            catch (Exception ex)
            {

            }
        }

        //button2 = close
        private void button2_Click(object sender, EventArgs e)
        {
            this.closeSock();
            serverAddr.Clear();
            userName.Clear();
            userPass.Clear();
            portNum.Clear();
            StatusBox.Items.Clear();
            FoldersBox.Items.Clear();
            fileAddr.Text = "";
            MessageBox.Show("Thank you!");
        }

        private void Download_Click(object sender, EventArgs e)
        {
            if (this.FoldersBox.SelectedItem == null) return;
            string selectItem = this.FoldersBox.SelectedItem.ToString();
            if (selectItem.Contains("FILE"))
            {
                string localDir = Microsoft.VisualBasic.Interaction.InputBox("Where to put downloaded file ?", "Download File", @"C:", 0, 0);
                string file_name = selectItem.Substring(33).Replace("\r", "").Replace("\n", "");
                string fileSize = sendFTPcmd("SIZE " + file_name + "\r\n");
                if (fileSize.Contains("ASCII"))
                {
                    sendFTPcmd("TYPE I\r\n");
                    fileSize = sendFTPcmd("SIZE " + file_name + "\r\n");
                }
                int fileSize_int = 0;
                if (fileSize[0] == '2')
                {
                    if (fileSize.Length > 4) fileSize = fileSize.Substring(4);
                    int.TryParse(fileSize, out fileSize_int);
                }
                StatusBox.Items.Add("Download " + file_name); StatusBox.Refresh();
                string current_directory = this.sendFTPcmd("PWD\r\n");
                current_directory = current_directory.Substring(5).Substring(0, current_directory.Substring(5).IndexOf('"'));
                try
                {
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + ServerIP + current_directory + "/" + file_name);
                    request.Credentials = new NetworkCredential(this.userName.Text, this.userPass.Text);
                    request.UseBinary = true; 
                    request.Method = WebRequestMethods.Ftp.DownloadFile;

                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    Stream responseStream = response.GetResponseStream();
                    FileStream writer = new FileStream(localDir + @"\" + file_name, FileMode.Create);
                    long length = response.ContentLength;
                    int bufferSize = 2048;
                    int readCount;
                    int readed = 0;
                    byte[] buffer = new byte[bufferSize];
                    readCount = responseStream.Read(buffer, 0, bufferSize);
                    readed += readCount;
                    this.progressBar2.Value = (readed * 100) / fileSize_int;
                    while (readCount > 0)
                    {
                        writer.Write(buffer, 0, readCount);
                        readCount = responseStream.Read(buffer, 0, bufferSize);
                        readed += readCount;
                        this.progressBar2.Value = (readed * 100) / fileSize_int;
                    }

                    responseStream.Close();
                    response.Close();
                    writer.Close();
                    MessageBox.Show("Download Has Completed");
                } catch (WebException except)
                {
                    MessageBox.Show(((FtpWebResponse)except.Response).StatusDescription);
                }
                this.progressBar2.Value = 0;
            } else
            {
                MessageBox.Show("Please select a file to download!");
            }
        }

        private void userName_Leave(object sender, EventArgs e)
        {
            if (this.userName.Text == "")
            {
                this.userName.Text = "anonymous";
            }
        }

        private void portNum_Leave(object sender, EventArgs e)
        {
            if (this.portNum.Text == "")
            {
                this.portNum.Text = "21";
            }
        }

        private void FoldersBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string selectItem = this.FoldersBox.SelectedItem.ToString();
            if (selectItem.Contains("DIRECTORY"))
            {
                string directory_name = selectItem.Substring(33);
                StatusBox.Items.Add("Link to " + directory_name);
                sendFTPcmd("CWD " + directory_name.Replace("\n","").Replace(" ","").Replace("\r","") + "\r\n");
                ShowFolder("NLST");
            }
        }

        private void Backward_Click(object sender, EventArgs e)
        {
            sendFTPcmd("CDUP" + "\r\n");
            ShowFolder("NLST");
        }

        private void Forward_Click(object sender, EventArgs e)
        {
            string selectItem = "";
            if (this.FoldersBox.SelectedItem != null)
            {
                selectItem = this.FoldersBox.SelectedItem.ToString();
            }
            if (selectItem.Contains("DIRECTORY"))
            {
                string directory_name = selectItem.Substring(33);
                StatusBox.Items.Add("Link to " + directory_name);
                sendFTPcmd("CWD " + directory_name.Replace("\n", "").Replace(" ", "").Replace("\r", "") + "\r\n");
                ShowFolder("NLST");
            }
        }

        private void userPass_Leave(object sender, EventArgs e)
        {
            if (this.userPass.Text == "")
            {
                this.userPass.Text = @"user@user";
            }
        }

        private void FTPApplication_FormClosing(object sender, FormClosingEventArgs e)
        {
            closeSock();
        }
    }
}
