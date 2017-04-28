namespace FTPClient
{
    partial class FTPApplication
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTPApplication));
            this.Server = new System.Windows.Forms.Label();
            this.serverAddr = new System.Windows.Forms.TextBox();
            this.User = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.Label();
            this.Port = new System.Windows.Forms.Label();
            this.userPass = new System.Windows.Forms.TextBox();
            this.portNum = new System.Windows.Forms.TextBox();
            this.Connect = new System.Windows.Forms.Button();
            this.DisConnect = new System.Windows.Forms.Button();
            this.Backward = new System.Windows.Forms.Button();
            this.Forward = new System.Windows.Forms.Button();
            this.fileAddr = new System.Windows.Forms.ComboBox();
            this.Download = new System.Windows.Forms.Button();
            this.StatusBox = new System.Windows.Forms.ListBox();
            this.FoldersBox = new System.Windows.Forms.ListBox();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // Server
            // 
            this.Server.AutoSize = true;
            this.Server.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Server.Location = new System.Drawing.Point(16, 18);
            this.Server.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Server.Name = "Server";
            this.Server.Size = new System.Drawing.Size(50, 17);
            this.Server.TabIndex = 0;
            this.Server.Text = "Server";
            // 
            // serverAddr
            // 
            this.serverAddr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serverAddr.Location = new System.Drawing.Point(72, 15);
            this.serverAddr.Margin = new System.Windows.Forms.Padding(4);
            this.serverAddr.Name = "serverAddr";
            this.serverAddr.Size = new System.Drawing.Size(132, 22);
            this.serverAddr.TabIndex = 1;
            // 
            // User
            // 
            this.User.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.User.AutoSize = true;
            this.User.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.User.Location = new System.Drawing.Point(221, 18);
            this.User.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.User.Name = "User";
            this.User.Size = new System.Drawing.Size(38, 17);
            this.User.TabIndex = 2;
            this.User.Text = "User";
            // 
            // userName
            // 
            this.userName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userName.Location = new System.Drawing.Point(279, 15);
            this.userName.Margin = new System.Windows.Forms.Padding(4);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(132, 22);
            this.userName.TabIndex = 3;
            this.userName.Leave += new System.EventHandler(this.userName_Leave);
            // 
            // Password
            // 
            this.Password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Password.AutoSize = true;
            this.Password.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Password.Location = new System.Drawing.Point(425, 18);
            this.Password.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(69, 17);
            this.Password.TabIndex = 4;
            this.Password.Text = "Password";
            // 
            // Port
            // 
            this.Port.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Port.AutoSize = true;
            this.Port.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Port.Location = new System.Drawing.Point(657, 18);
            this.Port.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(34, 17);
            this.Port.TabIndex = 5;
            this.Port.Text = "Port";
            // 
            // userPass
            // 
            this.userPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userPass.Location = new System.Drawing.Point(511, 15);
            this.userPass.Margin = new System.Windows.Forms.Padding(4);
            this.userPass.Name = "userPass";
            this.userPass.Size = new System.Drawing.Size(132, 22);
            this.userPass.TabIndex = 6;
            this.userPass.Leave += new System.EventHandler(this.userPass_Leave);
            // 
            // portNum
            // 
            this.portNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.portNum.Location = new System.Drawing.Point(705, 15);
            this.portNum.Margin = new System.Windows.Forms.Padding(4);
            this.portNum.Name = "portNum";
            this.portNum.Size = new System.Drawing.Size(52, 22);
            this.portNum.TabIndex = 7;
            this.portNum.Leave += new System.EventHandler(this.portNum_Leave);
            // 
            // Connect
            // 
            this.Connect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Connect.BackColor = System.Drawing.Color.Black;
            this.Connect.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Connect.BackgroundImage")));
            this.Connect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Connect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Connect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Connect.Location = new System.Drawing.Point(776, 7);
            this.Connect.Margin = new System.Windows.Forms.Padding(4);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(41, 37);
            this.Connect.TabIndex = 8;
            this.Connect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Connect.UseVisualStyleBackColor = false;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // DisConnect
            // 
            this.DisConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DisConnect.BackColor = System.Drawing.Color.Black;
            this.DisConnect.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DisConnect.BackgroundImage")));
            this.DisConnect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DisConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DisConnect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DisConnect.Location = new System.Drawing.Point(825, 7);
            this.DisConnect.Margin = new System.Windows.Forms.Padding(4);
            this.DisConnect.Name = "DisConnect";
            this.DisConnect.Size = new System.Drawing.Size(41, 38);
            this.DisConnect.TabIndex = 9;
            this.DisConnect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.DisConnect.UseVisualStyleBackColor = false;
            this.DisConnect.Click += new System.EventHandler(this.button2_Click);
            // 
            // Backward
            // 
            this.Backward.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Backward.BackgroundImage")));
            this.Backward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Backward.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Backward.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Backward.Location = new System.Drawing.Point(20, 66);
            this.Backward.Margin = new System.Windows.Forms.Padding(4);
            this.Backward.Name = "Backward";
            this.Backward.Size = new System.Drawing.Size(44, 39);
            this.Backward.TabIndex = 12;
            this.Backward.UseVisualStyleBackColor = false;
            this.Backward.Click += new System.EventHandler(this.Backward_Click);
            // 
            // Forward
            // 
            this.Forward.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Forward.BackgroundImage")));
            this.Forward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Forward.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Forward.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Forward.Location = new System.Drawing.Point(76, 66);
            this.Forward.Margin = new System.Windows.Forms.Padding(4);
            this.Forward.Name = "Forward";
            this.Forward.Size = new System.Drawing.Size(49, 39);
            this.Forward.TabIndex = 13;
            this.Forward.UseVisualStyleBackColor = false;
            this.Forward.Click += new System.EventHandler(this.Forward_Click);
            // 
            // fileAddr
            // 
            this.fileAddr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileAddr.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fileAddr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileAddr.FormattingEnabled = true;
            this.fileAddr.Location = new System.Drawing.Point(133, 75);
            this.fileAddr.Margin = new System.Windows.Forms.Padding(4);
            this.fileAddr.Name = "fileAddr";
            this.fileAddr.Size = new System.Drawing.Size(675, 28);
            this.fileAddr.TabIndex = 14;
            // 
            // Download
            // 
            this.Download.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Download.BackColor = System.Drawing.Color.Black;
            this.Download.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Download.BackgroundImage")));
            this.Download.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Download.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Download.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Download.Location = new System.Drawing.Point(825, 66);
            this.Download.Margin = new System.Windows.Forms.Padding(4);
            this.Download.Name = "Download";
            this.Download.Size = new System.Drawing.Size(41, 39);
            this.Download.TabIndex = 15;
            this.Download.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Download.UseVisualStyleBackColor = false;
            this.Download.Click += new System.EventHandler(this.Download_Click);
            // 
            // StatusBox
            // 
            this.StatusBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusBox.FormattingEnabled = true;
            this.StatusBox.ItemHeight = 16;
            this.StatusBox.Location = new System.Drawing.Point(16, 124);
            this.StatusBox.Margin = new System.Windows.Forms.Padding(4);
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.Size = new System.Drawing.Size(857, 180);
            this.StatusBox.TabIndex = 16;
            // 
            // FoldersBox
            // 
            this.FoldersBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FoldersBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FoldersBox.FormattingEnabled = true;
            this.FoldersBox.ItemHeight = 17;
            this.FoldersBox.Location = new System.Drawing.Point(16, 312);
            this.FoldersBox.Margin = new System.Windows.Forms.Padding(4);
            this.FoldersBox.Name = "FoldersBox";
            this.FoldersBox.Size = new System.Drawing.Size(858, 412);
            this.FoldersBox.TabIndex = 18;
            this.FoldersBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FoldersBox_MouseDoubleClick);
            // 
            // progressBar2
            // 
            this.progressBar2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar2.Location = new System.Drawing.Point(16, 730);
            this.progressBar2.MarqueeAnimationSpeed = 0;
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(857, 23);
            this.progressBar2.TabIndex = 20;
            // 
            // FTPApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(891, 766);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.FoldersBox);
            this.Controls.Add(this.StatusBox);
            this.Controls.Add(this.Download);
            this.Controls.Add(this.fileAddr);
            this.Controls.Add(this.Forward);
            this.Controls.Add(this.Backward);
            this.Controls.Add(this.DisConnect);
            this.Controls.Add(this.Connect);
            this.Controls.Add(this.portNum);
            this.Controls.Add(this.userPass);
            this.Controls.Add(this.Port);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.User);
            this.Controls.Add(this.serverAddr);
            this.Controls.Add(this.Server);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FTPApplication";
            this.Text = "Snail FTP Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FTPApplication_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Server;
        private System.Windows.Forms.TextBox serverAddr;
        private System.Windows.Forms.Label User;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.Label Port;
        private System.Windows.Forms.TextBox userPass;
        private System.Windows.Forms.TextBox portNum;
        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.Button DisConnect;
        private System.Windows.Forms.Button Backward;
        private System.Windows.Forms.Button Forward;
        private System.Windows.Forms.ComboBox fileAddr;
        private System.Windows.Forms.Button Download;
        private System.Windows.Forms.ListBox StatusBox;
        private System.Windows.Forms.ListBox FoldersBox;
        private System.Windows.Forms.ProgressBar progressBar2;
    }
}

