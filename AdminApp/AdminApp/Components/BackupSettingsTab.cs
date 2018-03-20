using AdminApp.Models.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminApp.Components
{
    public class BackupSettingsTab
    {
        private System.Windows.Forms.Label labelSelectSource;
        private System.Windows.Forms.TextBox textBox_Path;
        private System.Windows.Forms.ComboBox comboBox_Savingformat;
        private System.Windows.Forms.Label label_Destination;
        private System.Windows.Forms.TextBox textBox_FTPAdress;
        private System.Windows.Forms.TextBox textBox_FTPPassword;
        private System.Windows.Forms.RadioButton radioButton_Localnetwork;
        private System.Windows.Forms.TextBox textBox_FTPPort;
        private System.Windows.Forms.Label label_Savingformat;
        private System.Windows.Forms.RadioButton radioButton_FTP;
        private System.Windows.Forms.Label label_FTPServer;
        private System.Windows.Forms.TextBox textBox_FTPUsername;
        private System.Windows.Forms.TextBox textBox_Selectdestination;
        private System.Windows.Forms.Label label_FTPUserName;
        private System.Windows.Forms.ComboBox comboBox_Afterbackup;
        private System.Windows.Forms.Label label_FTPport;
        private System.Windows.Forms.Label label_FTPPassword;
        private System.Windows.Forms.Label label_AfterBackup;
        private System.Windows.Forms.TextBox textBox_SFTPAdress;
        private System.Windows.Forms.TextBox textBox_SFTPPassword;
        private System.Windows.Forms.TextBox textBox_SFTPPort;
        private System.Windows.Forms.Label label_SFTPServer;
        private System.Windows.Forms.TextBox textBox_SFTPUsername;
        private System.Windows.Forms.Label label_SFTPUsername;
        private System.Windows.Forms.Label label_SFTPPort;
        private System.Windows.Forms.Label label_SFTPPassword;
        private System.Windows.Forms.RadioButton radioButton_SFTP;
        private System.Windows.Forms.TextBox textBox_SFTPPath;
        private System.Windows.Forms.Label label_SFTPPath;
        private System.Windows.Forms.TextBox textBox_FTPPath;
        private System.Windows.Forms.Label label_FTPPath;

        public event Action ValuesChanged;

        public BackupSettingsTab(TabPage page)
        {
            this.textBox_SFTPPath = new System.Windows.Forms.TextBox();
            this.label_SFTPPath = new System.Windows.Forms.Label();
            this.textBox_FTPPath = new System.Windows.Forms.TextBox();
            this.label_FTPPath = new System.Windows.Forms.Label();
            this.textBox_SFTPAdress = new System.Windows.Forms.TextBox();
            this.textBox_SFTPPassword = new System.Windows.Forms.TextBox();
            this.textBox_SFTPPort = new System.Windows.Forms.TextBox();
            this.label_SFTPServer = new System.Windows.Forms.Label();
            this.textBox_SFTPUsername = new System.Windows.Forms.TextBox();
            this.label_SFTPUsername = new System.Windows.Forms.Label();
            this.label_SFTPPort = new System.Windows.Forms.Label();
            this.label_SFTPPassword = new System.Windows.Forms.Label();
            this.radioButton_SFTP = new System.Windows.Forms.RadioButton();
            this.labelSelectSource = new System.Windows.Forms.Label();
            this.textBox_Path = new System.Windows.Forms.TextBox();
            this.comboBox_Savingformat = new System.Windows.Forms.ComboBox();
            this.label_Destination = new System.Windows.Forms.Label();
            this.textBox_FTPAdress = new System.Windows.Forms.TextBox();
            this.textBox_FTPPassword = new System.Windows.Forms.TextBox();
            this.radioButton_Localnetwork = new System.Windows.Forms.RadioButton();
            this.textBox_FTPPort = new System.Windows.Forms.TextBox();
            this.label_Savingformat = new System.Windows.Forms.Label();
            this.radioButton_FTP = new System.Windows.Forms.RadioButton();
            this.label_FTPServer = new System.Windows.Forms.Label();
            this.textBox_FTPUsername = new System.Windows.Forms.TextBox();
            this.textBox_Selectdestination = new System.Windows.Forms.TextBox();
            this.label_FTPUserName = new System.Windows.Forms.Label();
            this.comboBox_Afterbackup = new System.Windows.Forms.ComboBox();
            this.label_FTPport = new System.Windows.Forms.Label();
            this.label_FTPPassword = new System.Windows.Forms.Label();
            this.label_AfterBackup = new System.Windows.Forms.Label();

            // 
            // textBox_SFTPPath
            // 
            this.textBox_SFTPPath.Enabled = false;
            this.textBox_SFTPPath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_SFTPPath.Location = new System.Drawing.Point(538, 312);
            this.textBox_SFTPPath.Multiline = true;
            this.textBox_SFTPPath.Name = "textBox_SFTPPath";
            this.textBox_SFTPPath.Size = new System.Drawing.Size(153, 20);
            this.textBox_SFTPPath.TabIndex = 49;
            this.textBox_SFTPPath.TextChanged += this.ValsChanged;
            // 
            // label_SFTPPath
            // 
            this.label_SFTPPath.AutoSize = true;
            this.label_SFTPPath.Enabled = false;
            this.label_SFTPPath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_SFTPPath.Location = new System.Drawing.Point(464, 315);
            this.label_SFTPPath.Name = "label_SFTPPath";
            this.label_SFTPPath.Size = new System.Drawing.Size(31, 15);
            this.label_SFTPPath.TabIndex = 48;
            this.label_SFTPPath.Text = "Path";
            // 
            // textBox_FTPPath
            // 
            this.textBox_FTPPath.Enabled = false;
            this.textBox_FTPPath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_FTPPath.Location = new System.Drawing.Point(286, 312);
            this.textBox_FTPPath.Multiline = true;
            this.textBox_FTPPath.Name = "textBox_FTPPath";
            this.textBox_FTPPath.Size = new System.Drawing.Size(153, 20);
            this.textBox_FTPPath.TabIndex = 47;
            this.textBox_FTPPath.TextChanged += this.ValsChanged;
            // 
            // label_FTPPath
            // 
            this.label_FTPPath.AutoSize = true;
            this.label_FTPPath.Enabled = false;
            this.label_FTPPath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_FTPPath.Location = new System.Drawing.Point(212, 315);
            this.label_FTPPath.Name = "label_FTPPath";
            this.label_FTPPath.Size = new System.Drawing.Size(31, 15);
            this.label_FTPPath.TabIndex = 44;
            this.label_FTPPath.Text = "Path";
            // 
            // textBox_SFTPAdress
            // 
            this.textBox_SFTPAdress.Enabled = false;
            this.textBox_SFTPAdress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_SFTPAdress.Location = new System.Drawing.Point(538, 159);
            this.textBox_SFTPAdress.Multiline = true;
            this.textBox_SFTPAdress.Name = "textBox_SFTPAdress";
            this.textBox_SFTPAdress.Size = new System.Drawing.Size(153, 20);
            this.textBox_SFTPAdress.TabIndex = 43;
            this.textBox_SFTPAdress.TextChanged += this.ValsChanged;
            // 
            // textBox_SFTPPassword
            // 
            this.textBox_SFTPPassword.Enabled = false;
            this.textBox_SFTPPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_SFTPPassword.Location = new System.Drawing.Point(538, 275);
            this.textBox_SFTPPassword.Multiline = true;
            this.textBox_SFTPPassword.Name = "textBox_SFTPPassword";
            this.textBox_SFTPPassword.PasswordChar = '•';
            this.textBox_SFTPPassword.Size = new System.Drawing.Size(153, 20);
            this.textBox_SFTPPassword.TabIndex = 42;
            this.textBox_SFTPPassword.TextChanged += this.ValsChanged;
            // 
            // textBox_SFTPPort
            // 
            this.textBox_SFTPPort.Enabled = false;
            this.textBox_SFTPPort.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_SFTPPort.Location = new System.Drawing.Point(538, 198);
            this.textBox_SFTPPort.Multiline = true;
            this.textBox_SFTPPort.Name = "textBox_SFTPPort";
            this.textBox_SFTPPort.Size = new System.Drawing.Size(153, 20);
            this.textBox_SFTPPort.TabIndex = 41;
            this.textBox_SFTPPort.TextChanged += this.ValsChanged;
            // 
            // label_SFTPServer
            // 
            this.label_SFTPServer.AutoSize = true;
            this.label_SFTPServer.Enabled = false;
            this.label_SFTPServer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_SFTPServer.Location = new System.Drawing.Point(464, 162);
            this.label_SFTPServer.Name = "label_SFTPServer";
            this.label_SFTPServer.Size = new System.Drawing.Size(39, 15);
            this.label_SFTPServer.TabIndex = 36;
            this.label_SFTPServer.Text = "Server";
            // 
            // textBox_SFTPUsername
            // 
            this.textBox_SFTPUsername.Enabled = false;
            this.textBox_SFTPUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_SFTPUsername.Location = new System.Drawing.Point(538, 236);
            this.textBox_SFTPUsername.Multiline = true;
            this.textBox_SFTPUsername.Name = "textBox_SFTPUsername";
            this.textBox_SFTPUsername.Size = new System.Drawing.Size(153, 20);
            this.textBox_SFTPUsername.TabIndex = 40;
            this.textBox_SFTPUsername.TextChanged += this.ValsChanged;
            // 
            // label_SFTPUsername
            // 
            this.label_SFTPUsername.AutoSize = true;
            this.label_SFTPUsername.Enabled = false;
            this.label_SFTPUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_SFTPUsername.Location = new System.Drawing.Point(464, 239);
            this.label_SFTPUsername.Name = "label_SFTPUsername";
            this.label_SFTPUsername.Size = new System.Drawing.Size(60, 15);
            this.label_SFTPUsername.TabIndex = 39;
            this.label_SFTPUsername.Text = "Username";
            // 
            // label_SFTPPort
            // 
            this.label_SFTPPort.AutoSize = true;
            this.label_SFTPPort.Enabled = false;
            this.label_SFTPPort.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_SFTPPort.Location = new System.Drawing.Point(464, 199);
            this.label_SFTPPort.Name = "label_SFTPPort";
            this.label_SFTPPort.Size = new System.Drawing.Size(29, 15);
            this.label_SFTPPort.TabIndex = 37;
            this.label_SFTPPort.Text = "Port";
            // 
            // label_SFTPPassword
            // 
            this.label_SFTPPassword.AutoSize = true;
            this.label_SFTPPassword.Enabled = false;
            this.label_SFTPPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_SFTPPassword.Location = new System.Drawing.Point(464, 278);
            this.label_SFTPPassword.Name = "label_SFTPPassword";
            this.label_SFTPPassword.Size = new System.Drawing.Size(57, 15);
            this.label_SFTPPassword.TabIndex = 38;
            this.label_SFTPPassword.Text = "Password";
            // 
            // radioButton_SFTP
            // 
            this.radioButton_SFTP.AutoSize = true;
            this.radioButton_SFTP.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButton_SFTP.Location = new System.Drawing.Point(467, 121);
            this.radioButton_SFTP.Name = "radioButton_SFTP";
            this.radioButton_SFTP.Size = new System.Drawing.Size(62, 25);
            this.radioButton_SFTP.TabIndex = 35;
            this.radioButton_SFTP.Text = "SFTP";
            this.radioButton_SFTP.UseVisualStyleBackColor = true;
            this.radioButton_SFTP.CheckedChanged += new System.EventHandler(this.radioButton_SFTP_CheckedChanged);
            this.radioButton_SFTP.CheckedChanged += this.ValsChanged;
            // 
            // labelSelectSource
            // 
            this.labelSelectSource.AutoSize = true;
            this.labelSelectSource.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSelectSource.Location = new System.Drawing.Point(15, 25);
            this.labelSelectSource.Name = "labelSelectSource";
            this.labelSelectSource.Size = new System.Drawing.Size(223, 21);
            this.labelSelectSource.TabIndex = 15;
            this.labelSelectSource.Text = "Select what will you backup";
            // 
            // textBox_Path
            // 
            this.textBox_Path.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_Path.Location = new System.Drawing.Point(18, 58);
            this.textBox_Path.Multiline = true;
            this.textBox_Path.Name = "textBox_Path";
            this.textBox_Path.Size = new System.Drawing.Size(200, 20);
            this.textBox_Path.TabIndex = 17;
            this.textBox_Path.TextChanged += this.ValsChanged;
            // 
            // comboBox_Savingformat
            // 
            this.comboBox_Savingformat.AutoCompleteCustomSource.AddRange(new string[] {
            "Archive .zip",
            "Without comprimation"});
            this.comboBox_Savingformat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Savingformat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBox_Savingformat.FormattingEnabled = true;
            this.comboBox_Savingformat.Items.AddRange(new object[] {
            "Without comprimation",
            "Archive .zip"});
            this.comboBox_Savingformat.SelectedIndex = 0;
            this.comboBox_Savingformat.Location = new System.Drawing.Point(512, 64);
            this.comboBox_Savingformat.Name = "comboBox_Savingformat";
            this.comboBox_Savingformat.Size = new System.Drawing.Size(176, 25);
            this.comboBox_Savingformat.TabIndex = 26;
            this.comboBox_Savingformat.SelectedValueChanged += this.ValsChanged;
            // 
            // label_Destination
            // 
            this.label_Destination.AutoSize = true;
            this.label_Destination.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_Destination.Location = new System.Drawing.Point(15, 101);
            this.label_Destination.Name = "label_Destination";
            this.label_Destination.Size = new System.Drawing.Size(99, 21);
            this.label_Destination.TabIndex = 34;
            this.label_Destination.Text = "Destination";
            // 
            // textBox_FTPAdress
            // 
            this.textBox_FTPAdress.Enabled = false;
            this.textBox_FTPAdress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_FTPAdress.Location = new System.Drawing.Point(286, 157);
            this.textBox_FTPAdress.Multiline = true;
            this.textBox_FTPAdress.Name = "textBox_FTPAdress";
            this.textBox_FTPAdress.Size = new System.Drawing.Size(153, 20);
            this.textBox_FTPAdress.TabIndex = 30;
            this.textBox_FTPAdress.TextChanged += this.ValsChanged;
            // 
            // textBox_FTPPassword
            // 
            this.textBox_FTPPassword.Enabled = false;
            this.textBox_FTPPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_FTPPassword.Location = new System.Drawing.Point(286, 273);
            this.textBox_FTPPassword.Multiline = true;
            this.textBox_FTPPassword.Name = "textBox_FTPPassword";
            this.textBox_FTPPassword.PasswordChar = '•';
            this.textBox_FTPPassword.Size = new System.Drawing.Size(153, 20);
            this.textBox_FTPPassword.TabIndex = 29;
            this.textBox_FTPPassword.TextChanged += this.ValsChanged;
            // 
            // radioButton_Localnetwork
            // 
            this.radioButton_Localnetwork.AutoSize = true;
            this.radioButton_Localnetwork.Checked = true;
            this.radioButton_Localnetwork.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButton_Localnetwork.Location = new System.Drawing.Point(18, 121);
            this.radioButton_Localnetwork.Name = "radioButton_Localnetwork";
            this.radioButton_Localnetwork.Size = new System.Drawing.Size(173, 25);
            this.radioButton_Localnetwork.TabIndex = 16;
            this.radioButton_Localnetwork.TabStop = true;
            this.radioButton_Localnetwork.Text = "Local/network drives";
            this.radioButton_Localnetwork.UseVisualStyleBackColor = true;
            this.radioButton_Localnetwork.CheckedChanged += new System.EventHandler(this.radioButton_Localnetwork_CheckedChanged);
            this.radioButton_Localnetwork.CheckedChanged += this.ValsChanged;
            // 
            // textBox_FTPPort
            // 
            this.textBox_FTPPort.Enabled = false;
            this.textBox_FTPPort.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_FTPPort.Location = new System.Drawing.Point(286, 196);
            this.textBox_FTPPort.Multiline = true;
            this.textBox_FTPPort.Name = "textBox_FTPPort";
            this.textBox_FTPPort.Size = new System.Drawing.Size(153, 20);
            this.textBox_FTPPort.TabIndex = 28;
            this.textBox_FTPPort.TextChanged += this.ValsChanged;
            // 
            // label_Savingformat
            // 
            this.label_Savingformat.AutoSize = true;
            this.label_Savingformat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_Savingformat.Location = new System.Drawing.Point(424, 67);
            this.label_Savingformat.Name = "label_Savingformat";
            this.label_Savingformat.Size = new System.Drawing.Size(49, 17);
            this.label_Savingformat.TabIndex = 25;
            this.label_Savingformat.Text = "Format";
            // 
            // radioButton_FTP
            // 
            this.radioButton_FTP.AutoSize = true;
            this.radioButton_FTP.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButton_FTP.Location = new System.Drawing.Point(215, 121);
            this.radioButton_FTP.Name = "radioButton_FTP";
            this.radioButton_FTP.Size = new System.Drawing.Size(53, 25);
            this.radioButton_FTP.TabIndex = 18;
            this.radioButton_FTP.Text = "FTP";
            this.radioButton_FTP.UseVisualStyleBackColor = true;
            this.radioButton_FTP.CheckedChanged += new System.EventHandler(this.radioButton_FTP_CheckedChanged);
            this.radioButton_FTP.CheckedChanged += this.ValsChanged;
            // 
            // label_FTPServer
            // 
            this.label_FTPServer.AutoSize = true;
            this.label_FTPServer.Enabled = false;
            this.label_FTPServer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_FTPServer.Location = new System.Drawing.Point(212, 160);
            this.label_FTPServer.Name = "label_FTPServer";
            this.label_FTPServer.Size = new System.Drawing.Size(39, 15);
            this.label_FTPServer.TabIndex = 19;
            this.label_FTPServer.Text = "Server";
            // 
            // textBox_FTPUsername
            // 
            this.textBox_FTPUsername.Enabled = false;
            this.textBox_FTPUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_FTPUsername.Location = new System.Drawing.Point(286, 234);
            this.textBox_FTPUsername.Multiline = true;
            this.textBox_FTPUsername.Name = "textBox_FTPUsername";
            this.textBox_FTPUsername.Size = new System.Drawing.Size(153, 20);
            this.textBox_FTPUsername.TabIndex = 27;
            this.textBox_FTPUsername.TextChanged += this.ValsChanged;
            // 
            // textBox_Selectdestination
            // 
            this.textBox_Selectdestination.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_Selectdestination.Location = new System.Drawing.Point(18, 155);
            this.textBox_Selectdestination.Multiline = true;
            this.textBox_Selectdestination.Name = "textBox_Selectdestination";
            this.textBox_Selectdestination.Size = new System.Drawing.Size(150, 20);
            this.textBox_Selectdestination.TabIndex = 33;
            this.textBox_Selectdestination.TextChanged += this.ValsChanged;
            // 
            // label_FTPUserName
            // 
            this.label_FTPUserName.AutoSize = true;
            this.label_FTPUserName.Enabled = false;
            this.label_FTPUserName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_FTPUserName.Location = new System.Drawing.Point(212, 237);
            this.label_FTPUserName.Name = "label_FTPUserName";
            this.label_FTPUserName.Size = new System.Drawing.Size(60, 15);
            this.label_FTPUserName.TabIndex = 24;
            this.label_FTPUserName.Text = "Username";
            // 
            // comboBox_Afterbackup
            // 
            this.comboBox_Afterbackup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Afterbackup.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBox_Afterbackup.FormattingEnabled = true;
            this.comboBox_Afterbackup.Items.AddRange(new object[] {
            "Nothing",
            "Restart",
            "Turn off",
            "Sleep mode"});
            this.comboBox_Afterbackup.SelectedIndex = 0;
            this.comboBox_Afterbackup.Location = new System.Drawing.Point(512, 25);
            this.comboBox_Afterbackup.Name = "comboBox_Afterbackup";
            this.comboBox_Afterbackup.Size = new System.Drawing.Size(176, 25);
            this.comboBox_Afterbackup.TabIndex = 23;
            this.comboBox_Afterbackup.SelectedValueChanged += this.ValsChanged;
            // 
            // label_FTPport
            // 
            this.label_FTPport.AutoSize = true;
            this.label_FTPport.Enabled = false;
            this.label_FTPport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_FTPport.Location = new System.Drawing.Point(212, 197);
            this.label_FTPport.Name = "label_FTPport";
            this.label_FTPport.Size = new System.Drawing.Size(29, 15);
            this.label_FTPport.TabIndex = 20;
            this.label_FTPport.Text = "Port";
            // 
            // label_FTPPassword
            // 
            this.label_FTPPassword.AutoSize = true;
            this.label_FTPPassword.Enabled = false;
            this.label_FTPPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_FTPPassword.Location = new System.Drawing.Point(212, 276);
            this.label_FTPPassword.Name = "label_FTPPassword";
            this.label_FTPPassword.Size = new System.Drawing.Size(57, 15);
            this.label_FTPPassword.TabIndex = 22;
            this.label_FTPPassword.Text = "Password";
            // 
            // label_AfterBackup
            // 
            this.label_AfterBackup.AutoSize = true;
            this.label_AfterBackup.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_AfterBackup.Location = new System.Drawing.Point(424, 29);
            this.label_AfterBackup.Name = "label_AfterBackup";
            this.label_AfterBackup.Size = new System.Drawing.Size(82, 17);
            this.label_AfterBackup.TabIndex = 21;
            this.label_AfterBackup.Text = "After backup";


            //ADD TO TAB PAGE
            page.Controls.Add(this.textBox_SFTPPath);
            page.Controls.Add(this.label_SFTPPath);
            page.Controls.Add(this.textBox_FTPPath);
            page.Controls.Add(this.label_FTPPath);
            page.Controls.Add(this.textBox_SFTPAdress);
            page.Controls.Add(this.textBox_SFTPPassword);
            page.Controls.Add(this.textBox_SFTPPort);
            page.Controls.Add(this.label_SFTPServer);
            page.Controls.Add(this.textBox_SFTPUsername);
            page.Controls.Add(this.label_SFTPUsername);
            page.Controls.Add(this.label_SFTPPort);
            page.Controls.Add(this.label_SFTPPassword);
            page.Controls.Add(this.radioButton_SFTP);
            page.Controls.Add(this.labelSelectSource);
            page.Controls.Add(this.textBox_Path);
            page.Controls.Add(this.comboBox_Savingformat);
            page.Controls.Add(this.label_Destination);
            page.Controls.Add(this.textBox_FTPAdress);
            page.Controls.Add(this.textBox_FTPPassword);
            page.Controls.Add(this.radioButton_Localnetwork);
            page.Controls.Add(this.textBox_FTPPort);
            page.Controls.Add(this.label_Savingformat);
            page.Controls.Add(this.radioButton_FTP);
            page.Controls.Add(this.label_FTPServer);
            page.Controls.Add(this.textBox_FTPUsername);
            page.Controls.Add(this.textBox_Selectdestination);
            page.Controls.Add(this.label_FTPUserName);
            page.Controls.Add(this.comboBox_Afterbackup);
            page.Controls.Add(this.label_FTPport);
            page.Controls.Add(this.label_FTPPassword);
            page.Controls.Add(this.label_AfterBackup);
        }

        public bool IsValid(ErrorProvider errProvider)
        {
            bool result = true;

            if(String.IsNullOrWhiteSpace(this.textBox_Path.Text) || !Path.IsPathRooted(this.textBox_Path.Text))
            {
                result = false;
                errProvider.SetError(this.textBox_Path, "Not a valid path");
            }

            if(this.radioButton_Localnetwork.Checked)
            {
                if(String.IsNullOrWhiteSpace(this.textBox_Selectdestination.Text) || !Path.IsPathRooted(this.textBox_Selectdestination.Text))
                {
                    result = false;
                    errProvider.SetError(this.textBox_Selectdestination, "Not a valid path");
                }
            }

            if (this.radioButton_FTP.Checked)
            {
                if (String.IsNullOrWhiteSpace(this.textBox_FTPAdress.Text))
                {
                    result = false;
                    errProvider.SetError(this.textBox_FTPAdress, "Cannot be empty");
                }

                if (String.IsNullOrWhiteSpace(this.textBox_FTPPort.Text))
                {
                    result = false;
                    errProvider.SetError(this.textBox_FTPPort, "Cannot be empty");
                }

                try
                {
                    Convert.ToInt32(this.textBox_FTPPort.Text);
                }
                catch (Exception)
                {
                    result = false;
                    errProvider.SetError(this.textBox_FTPPort, "Port must be a number");
                }

                if (String.IsNullOrWhiteSpace(this.textBox_FTPUsername.Text))
                {
                    result = false;
                    errProvider.SetError(this.textBox_FTPUsername, "Cannot be empty");
                }

                if (String.IsNullOrWhiteSpace(this.textBox_FTPPassword.Text))
                {
                    result = false;
                    errProvider.SetError(this.textBox_FTPPassword, "Cannot be empty");
                }

                if (String.IsNullOrWhiteSpace(this.textBox_FTPPath.Text))
                {
                    result = false;
                    errProvider.SetError(this.textBox_FTPPath, "Not a valid path");
                }
            }

            if (this.radioButton_SFTP.Checked)
            {
                if (String.IsNullOrWhiteSpace(this.textBox_SFTPAdress.Text))
                {
                    result = false;
                    errProvider.SetError(this.textBox_SFTPAdress, "Cannot be empty");
                }

                if (String.IsNullOrWhiteSpace(this.textBox_SFTPPort.Text))
                {
                    result = false;
                    errProvider.SetError(this.textBox_SFTPPort, "Cannot be empty");
                }

                try
                {
                    Convert.ToInt32(this.textBox_SFTPPort.Text);
                }
                catch (Exception)
                {
                    result = false;
                    errProvider.SetError(this.textBox_SFTPPort, "Port must be a number");
                }

                if (String.IsNullOrWhiteSpace(this.textBox_SFTPUsername.Text))
                {
                    result = false;
                    errProvider.SetError(this.textBox_SFTPUsername, "Cannot be empty");
                }

                if (String.IsNullOrWhiteSpace(this.textBox_SFTPPassword.Text))
                {
                    result = false;
                    errProvider.SetError(this.textBox_SFTPPassword, "Cannot be empty");
                }

                if (String.IsNullOrWhiteSpace(this.textBox_SFTPPath.Text))
                {
                    result = false;
                    errProvider.SetError(this.textBox_SFTPPath, "Not a valid path");
                }
            }

            return result;
        }

        private void ValsChanged(object sender,EventArgs args)
        {
            this.ValuesChanged?.Invoke();
        }

        private void radioButton_Localnetwork_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton_Localnetwork.Checked)
                return;

            this.textBox_FTPPassword.Enabled = false;
            this.textBox_FTPUsername.Enabled = false;
            this.textBox_FTPPort.Enabled = false;
            this.textBox_FTPAdress.Enabled = false;
            this.textBox_FTPPath.Enabled = false;

            this.textBox_SFTPPassword.Enabled = false;
            this.textBox_SFTPUsername.Enabled = false;
            this.textBox_SFTPPort.Enabled = false;
            this.textBox_SFTPAdress.Enabled = false;
            this.textBox_SFTPPath.Enabled = false;


            this.textBox_Selectdestination.Enabled = true;
        }

        private void radioButton_SFTP_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton_SFTP.Checked)
                return;

            this.textBox_FTPPassword.Enabled = false;
            this.textBox_FTPUsername.Enabled = false;
            this.textBox_FTPPort.Enabled = false;
            this.textBox_FTPAdress.Enabled = false;
            this.textBox_FTPPath.Enabled = false;

            this.textBox_SFTPPassword.Enabled = true;
            this.textBox_SFTPUsername.Enabled = true;
            this.textBox_SFTPPort.Enabled = true;
            this.textBox_SFTPAdress.Enabled = true;
            this.textBox_SFTPPath.Enabled = true;


            this.textBox_Selectdestination.Enabled = false;
        }

        private void radioButton_FTP_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton_FTP.Checked)
                return;

            this.textBox_FTPPassword.Enabled = true;
            this.textBox_FTPUsername.Enabled = true;
            this.textBox_FTPPort.Enabled = true;
            this.textBox_FTPAdress.Enabled = true;
            this.textBox_FTPPath.Enabled = true;

            this.textBox_SFTPPassword.Enabled = false;
            this.textBox_SFTPUsername.Enabled = false;
            this.textBox_SFTPPort.Enabled = false;
            this.textBox_SFTPAdress.Enabled = false;
            this.textBox_SFTPPath.Enabled = false;


            this.textBox_Selectdestination.Enabled = false;
        }

        public void LoadSettings(Daemon daemon)
        {
            //SOURCE PATH
            this.textBox_Path.Text = daemon.Settings[0].BackupSourcePath;

            //SAVE FORMAT
            if (daemon.Settings[0].SaveFormat == "PLAIN")
            {
                this.comboBox_Savingformat.SelectedIndex = 0;
            }else if(daemon.Settings[0].SaveFormat == "ZIP")
            {
                this.comboBox_Savingformat.SelectedIndex = 1;
            }

            //ACTION AFTER BACKUP
            if(daemon.Settings[0].ActionAfterBackup == "NOTHING")
            {
                this.comboBox_Afterbackup.SelectedIndex = 0;
            }
            else if(daemon.Settings[0].ActionAfterBackup == "RESTART")
            {
                this.comboBox_Afterbackup.SelectedIndex = 1;
            }
            else if (daemon.Settings[0].ActionAfterBackup == "TURN OFF")
            {
                this.comboBox_Afterbackup.SelectedIndex = 2;
            }
            else if (daemon.Settings[0].ActionAfterBackup == "SLEEP")
            {
                this.comboBox_Afterbackup.SelectedIndex = 3;
            }

            //DESTINATION
            if(daemon.Settings[0].Destination.Type == "LOCAL_NETWORK")
            {
                this.radioButton_Localnetwork.Checked = true;
                this.radioButton_FTP.Checked = false;
                this.radioButton_SFTP.Checked = false;

                this.textBox_Selectdestination.Text = daemon.Settings[0].Destination.Path;
            }
            else if (daemon.Settings[0].Destination.Type == "FTP")
            {
                this.radioButton_Localnetwork.Checked = false;
                this.radioButton_FTP.Checked = true;
                this.radioButton_SFTP.Checked = false;

                FTPDestination dest = (FTPDestination)daemon.Settings[0].Destination;
                this.textBox_FTPAdress.Text = dest.Adress;
                this.textBox_FTPPort.Text = dest.Port;
                this.textBox_FTPUsername.Text = dest.Username;
                this.textBox_FTPPassword.Text = dest.Password;
                this.textBox_FTPPath.Text = dest.Path;
            }
            else if (daemon.Settings[0].Destination.Type == "SFTP")
            {
                this.radioButton_Localnetwork.Checked = false;
                this.radioButton_FTP.Checked = false;
                this.radioButton_SFTP.Checked = true;

                SFTPDestination dest = (SFTPDestination)daemon.Settings[0].Destination;
                this.textBox_SFTPAdress.Text = dest.Adress;
                this.textBox_SFTPPort.Text = dest.Port;
                this.textBox_SFTPUsername.Text = dest.Username;
                this.textBox_SFTPPassword.Text = dest.Password;
                this.textBox_SFTPPath.Text = dest.Path;
            }

        }

        public void SaveSettings(Daemon daemon)
        {
            //SOURCE PATH
            daemon.Settings[0].BackupSourcePath = this.textBox_Path.Text;

            //SAVE FORMAT
            if (this.comboBox_Savingformat.SelectedIndex == 0)
            {

                daemon.Settings[0].SaveFormat = "PLAIN";
            }
            else if (this.comboBox_Savingformat.SelectedIndex == 1)
            {
                daemon.Settings[0].SaveFormat = "ZIP";
            }

            //ACTION AFTER BACKUP
            if (this.comboBox_Afterbackup.SelectedIndex == 0)
            {
                daemon.Settings[0].ActionAfterBackup = "NOTHING";
            }
            else if (this.comboBox_Afterbackup.SelectedIndex == 1)
            {
                daemon.Settings[0].ActionAfterBackup = "RESTART";
            }
            else if (this.comboBox_Afterbackup.SelectedIndex == 2)
            {
                daemon.Settings[0].ActionAfterBackup = "TURN OFF";
            }
            else if (this.comboBox_Afterbackup.SelectedIndex == 3)
            {
                daemon.Settings[0].ActionAfterBackup = "SLEEP";
            }

            //DESTINATION
            if (this.radioButton_Localnetwork.Checked)
            {
                daemon.Settings[0].Destination = new LocalNetworkDestination();
                daemon.Settings[0].Destination.Path = this.textBox_Selectdestination.Text;
            }
            else if (this.radioButton_FTP.Checked)
            {

                FTPDestination dest = new FTPDestination();
                dest.Adress = this.textBox_FTPAdress.Text;
                dest.Port = this.textBox_FTPPort.Text;
                dest.Username = this.textBox_FTPUsername.Text;
                dest.Password = this.textBox_FTPPassword.Text;
                dest.Path = this.textBox_FTPPath.Text;

                daemon.Settings[0].Destination = dest;
            }
            else if (this.radioButton_SFTP.Checked)
            {
                SFTPDestination dest = new SFTPDestination();
                dest.Adress = this.textBox_SFTPAdress.Text;
                dest.Port = this.textBox_SFTPPort.Text;
                dest.Username = this.textBox_SFTPUsername.Text;
                dest.Password = this.textBox_SFTPPassword.Text;
                dest.Path = this.textBox_SFTPPath.Text;

                daemon.Settings[0].Destination = dest;
            }
        }
    }
}
