namespace AdminApp
{
    partial class Form_NewMenu
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
            this.components = new System.ComponentModel.Container();
            this.tabControl_DefaultMenu = new System.Windows.Forms.TabControl();
            this.tabPage_EmailNotification = new System.Windows.Forms.TabPage();
            this.textBox_SMTPServerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_To = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_SMTPUsername = new System.Windows.Forms.TextBox();
            this.textBox_SMTPPort = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_SMTPPassword = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tabPage_Administration = new System.Windows.Forms.TabPage();
            this.tabControl_Daemon = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl_Backup = new System.Windows.Forms.TabControl();
            this.tabPage_BackupSettings = new System.Windows.Forms.TabPage();
            this.textBox_SFTPPath = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox_FTPPath = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox_SFTPAdress = new System.Windows.Forms.TextBox();
            this.textBox_SFTPPassword = new System.Windows.Forms.TextBox();
            this.textBox_SFTPPort = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_SFTPUsername = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.radioButton_SFTP = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_Path = new System.Windows.Forms.TextBox();
            this.comboBox_Savingformat = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_FTPAdress = new System.Windows.Forms.TextBox();
            this.textBox_FTPPassword = new System.Windows.Forms.TextBox();
            this.radioButton_Localnetwork = new System.Windows.Forms.RadioButton();
            this.textBox_FTPPort = new System.Windows.Forms.TextBox();
            this.label_Savingformat = new System.Windows.Forms.Label();
            this.radioButton_FTP = new System.Windows.Forms.RadioButton();
            this.label_Adress = new System.Windows.Forms.Label();
            this.textBox_FTPUsername = new System.Windows.Forms.TextBox();
            this.textBox_Selectdestination = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox_Afterbackup = new System.Windows.Forms.ComboBox();
            this.label_FTPport = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label_AfterBackup = new System.Windows.Forms.Label();
            this.tabPage_BackupScheme = new System.Windows.Forms.TabPage();
            this.tabControl_Scheme = new System.Windows.Forms.TabControl();
            this.tabPage_OneTime = new System.Windows.Forms.TabPage();
            this.label16 = new System.Windows.Forms.Label();
            this.dateTimePicker_OneTimeYMD = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_OneTimeTime = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.tabPage_Daily = new System.Windows.Forms.TabPage();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.tabPage_Weekly = new System.Windows.Forms.TabPage();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.tabPage_Monthly = new System.Windows.Forms.TabPage();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl_DefaultMenu.SuspendLayout();
            this.tabPage_EmailNotification.SuspendLayout();
            this.tabPage_Administration.SuspendLayout();
            this.tabControl_Daemon.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl_Backup.SuspendLayout();
            this.tabPage_BackupSettings.SuspendLayout();
            this.tabPage_BackupScheme.SuspendLayout();
            this.tabControl_Scheme.SuspendLayout();
            this.tabPage_OneTime.SuspendLayout();
            this.tabPage_Daily.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tabPage_Weekly.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.tabPage_Monthly.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl_DefaultMenu
            // 
            this.tabControl_DefaultMenu.Controls.Add(this.tabPage_EmailNotification);
            this.tabControl_DefaultMenu.Controls.Add(this.tabPage_Administration);
            this.tabControl_DefaultMenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tabControl_DefaultMenu.Location = new System.Drawing.Point(1, 0);
            this.tabControl_DefaultMenu.Multiline = true;
            this.tabControl_DefaultMenu.Name = "tabControl_DefaultMenu";
            this.tabControl_DefaultMenu.SelectedIndex = 0;
            this.tabControl_DefaultMenu.Size = new System.Drawing.Size(767, 441);
            this.tabControl_DefaultMenu.TabIndex = 0;
            // 
            // tabPage_EmailNotification
            // 
            this.tabPage_EmailNotification.BackColor = System.Drawing.Color.Transparent;
            this.tabPage_EmailNotification.Controls.Add(this.textBox_SMTPServerName);
            this.tabPage_EmailNotification.Controls.Add(this.label1);
            this.tabPage_EmailNotification.Controls.Add(this.label2);
            this.tabPage_EmailNotification.Controls.Add(this.label3);
            this.tabPage_EmailNotification.Controls.Add(this.label4);
            this.tabPage_EmailNotification.Controls.Add(this.textBox_To);
            this.tabPage_EmailNotification.Controls.Add(this.label5);
            this.tabPage_EmailNotification.Controls.Add(this.textBox_SMTPUsername);
            this.tabPage_EmailNotification.Controls.Add(this.textBox_SMTPPort);
            this.tabPage_EmailNotification.Controls.Add(this.label6);
            this.tabPage_EmailNotification.Controls.Add(this.textBox_SMTPPassword);
            this.tabPage_EmailNotification.Controls.Add(this.checkBox1);
            this.tabPage_EmailNotification.Location = new System.Drawing.Point(4, 30);
            this.tabPage_EmailNotification.Name = "tabPage_EmailNotification";
            this.tabPage_EmailNotification.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_EmailNotification.Size = new System.Drawing.Size(759, 407);
            this.tabPage_EmailNotification.TabIndex = 0;
            this.tabPage_EmailNotification.Text = "Email notification";
            // 
            // textBox_SMTPServerName
            // 
            this.textBox_SMTPServerName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_SMTPServerName.Location = new System.Drawing.Point(195, 156);
            this.textBox_SMTPServerName.Multiline = true;
            this.textBox_SMTPServerName.Name = "textBox_SMTPServerName";
            this.textBox_SMTPServerName.Size = new System.Drawing.Size(146, 25);
            this.textBox_SMTPServerName.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(72, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 21);
            this.label1.TabIndex = 27;
            this.label1.Text = "Server name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(72, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 21);
            this.label2.TabIndex = 28;
            this.label2.Text = "Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(72, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 21);
            this.label3.TabIndex = 25;
            this.label3.Text = "To";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(387, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 21);
            this.label4.TabIndex = 29;
            this.label4.Text = "Username";
            // 
            // textBox_To
            // 
            this.textBox_To.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_To.Location = new System.Drawing.Point(131, 71);
            this.textBox_To.Multiline = true;
            this.textBox_To.Name = "textBox_To";
            this.textBox_To.Size = new System.Drawing.Size(519, 25);
            this.textBox_To.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(387, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 21);
            this.label5.TabIndex = 30;
            this.label5.Text = "Password";
            // 
            // textBox_SMTPUsername
            // 
            this.textBox_SMTPUsername.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_SMTPUsername.Location = new System.Drawing.Point(504, 156);
            this.textBox_SMTPUsername.Multiline = true;
            this.textBox_SMTPUsername.Name = "textBox_SMTPUsername";
            this.textBox_SMTPUsername.Size = new System.Drawing.Size(147, 25);
            this.textBox_SMTPUsername.TabIndex = 31;
            // 
            // textBox_SMTPPort
            // 
            this.textBox_SMTPPort.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_SMTPPort.Location = new System.Drawing.Point(195, 197);
            this.textBox_SMTPPort.Multiline = true;
            this.textBox_SMTPPort.Name = "textBox_SMTPPort";
            this.textBox_SMTPPort.Size = new System.Drawing.Size(146, 25);
            this.textBox_SMTPPort.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(72, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 21);
            this.label6.TabIndex = 36;
            this.label6.Text = "SMTP settings";
            // 
            // textBox_SMTPPassword
            // 
            this.textBox_SMTPPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_SMTPPassword.Location = new System.Drawing.Point(504, 197);
            this.textBox_SMTPPassword.Multiline = true;
            this.textBox_SMTPPassword.Name = "textBox_SMTPPassword";
            this.textBox_SMTPPassword.Size = new System.Drawing.Size(147, 25);
            this.textBox_SMTPPassword.TabIndex = 34;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBox1.Location = new System.Drawing.Point(391, 245);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(86, 25);
            this.checkBox1.TabIndex = 35;
            this.checkBox1.Text = "SSL/TLS";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // tabPage_Administration
            // 
            this.tabPage_Administration.Controls.Add(this.tabControl_Daemon);
            this.tabPage_Administration.Location = new System.Drawing.Point(4, 30);
            this.tabPage_Administration.Name = "tabPage_Administration";
            this.tabPage_Administration.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Administration.Size = new System.Drawing.Size(759, 407);
            this.tabPage_Administration.TabIndex = 1;
            this.tabPage_Administration.Text = "Administration";
            this.tabPage_Administration.UseVisualStyleBackColor = true;
            // 
            // tabControl_Daemon
            // 
            this.tabControl_Daemon.Controls.Add(this.tabPage2);
            this.tabControl_Daemon.Location = new System.Drawing.Point(7, 0);
            this.tabControl_Daemon.Name = "tabControl_Daemon";
            this.tabControl_Daemon.SelectedIndex = 0;
            this.tabControl_Daemon.Size = new System.Drawing.Size(741, 411);
            this.tabControl_Daemon.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tabControl_Backup);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(733, 377);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Daemon";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl_Backup
            // 
            this.tabControl_Backup.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl_Backup.Controls.Add(this.tabPage_BackupSettings);
            this.tabControl_Backup.Controls.Add(this.tabPage_BackupScheme);
            this.tabControl_Backup.Location = new System.Drawing.Point(0, 0);
            this.tabControl_Backup.Multiline = true;
            this.tabControl_Backup.Name = "tabControl_Backup";
            this.tabControl_Backup.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl_Backup.SelectedIndex = 0;
            this.tabControl_Backup.ShowToolTips = true;
            this.tabControl_Backup.Size = new System.Drawing.Size(748, 377);
            this.tabControl_Backup.TabIndex = 0;
            // 
            // tabPage_BackupSettings
            // 
            this.tabPage_BackupSettings.Controls.Add(this.textBox_SFTPPath);
            this.tabPage_BackupSettings.Controls.Add(this.label18);
            this.tabPage_BackupSettings.Controls.Add(this.textBox_FTPPath);
            this.tabPage_BackupSettings.Controls.Add(this.label22);
            this.tabPage_BackupSettings.Controls.Add(this.textBox_SFTPAdress);
            this.tabPage_BackupSettings.Controls.Add(this.textBox_SFTPPassword);
            this.tabPage_BackupSettings.Controls.Add(this.textBox_SFTPPort);
            this.tabPage_BackupSettings.Controls.Add(this.label8);
            this.tabPage_BackupSettings.Controls.Add(this.textBox_SFTPUsername);
            this.tabPage_BackupSettings.Controls.Add(this.label12);
            this.tabPage_BackupSettings.Controls.Add(this.label13);
            this.tabPage_BackupSettings.Controls.Add(this.label14);
            this.tabPage_BackupSettings.Controls.Add(this.radioButton_SFTP);
            this.tabPage_BackupSettings.Controls.Add(this.label7);
            this.tabPage_BackupSettings.Controls.Add(this.textBox_Path);
            this.tabPage_BackupSettings.Controls.Add(this.comboBox_Savingformat);
            this.tabPage_BackupSettings.Controls.Add(this.label9);
            this.tabPage_BackupSettings.Controls.Add(this.textBox_FTPAdress);
            this.tabPage_BackupSettings.Controls.Add(this.textBox_FTPPassword);
            this.tabPage_BackupSettings.Controls.Add(this.radioButton_Localnetwork);
            this.tabPage_BackupSettings.Controls.Add(this.textBox_FTPPort);
            this.tabPage_BackupSettings.Controls.Add(this.label_Savingformat);
            this.tabPage_BackupSettings.Controls.Add(this.radioButton_FTP);
            this.tabPage_BackupSettings.Controls.Add(this.label_Adress);
            this.tabPage_BackupSettings.Controls.Add(this.textBox_FTPUsername);
            this.tabPage_BackupSettings.Controls.Add(this.textBox_Selectdestination);
            this.tabPage_BackupSettings.Controls.Add(this.label10);
            this.tabPage_BackupSettings.Controls.Add(this.comboBox_Afterbackup);
            this.tabPage_BackupSettings.Controls.Add(this.label_FTPport);
            this.tabPage_BackupSettings.Controls.Add(this.label11);
            this.tabPage_BackupSettings.Controls.Add(this.label_AfterBackup);
            this.tabPage_BackupSettings.Location = new System.Drawing.Point(32, 4);
            this.tabPage_BackupSettings.Name = "tabPage_BackupSettings";
            this.tabPage_BackupSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_BackupSettings.Size = new System.Drawing.Size(712, 369);
            this.tabPage_BackupSettings.TabIndex = 0;
            this.tabPage_BackupSettings.Text = "Backup settings";
            this.tabPage_BackupSettings.UseVisualStyleBackColor = true;
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
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Enabled = false;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label18.Location = new System.Drawing.Point(464, 315);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(31, 15);
            this.label18.TabIndex = 48;
            this.label18.Text = "Path";
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
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Enabled = false;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label22.Location = new System.Drawing.Point(212, 315);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(31, 15);
            this.label22.TabIndex = 44;
            this.label22.Text = "Path";
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
            // 
            // textBox_SFTPPassword
            // 
            this.textBox_SFTPPassword.Enabled = false;
            this.textBox_SFTPPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_SFTPPassword.Location = new System.Drawing.Point(538, 275);
            this.textBox_SFTPPassword.Multiline = true;
            this.textBox_SFTPPassword.Name = "textBox_SFTPPassword";
            this.textBox_SFTPPassword.Size = new System.Drawing.Size(153, 20);
            this.textBox_SFTPPassword.TabIndex = 42;
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
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Enabled = false;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(464, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 15);
            this.label8.TabIndex = 36;
            this.label8.Text = "Adress";
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
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Enabled = false;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(464, 239);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 15);
            this.label12.TabIndex = 39;
            this.label12.Text = "Username";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Enabled = false;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label13.Location = new System.Drawing.Point(464, 199);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 15);
            this.label13.TabIndex = 37;
            this.label13.Text = "Port";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Enabled = false;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label14.Location = new System.Drawing.Point(464, 278);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 15);
            this.label14.TabIndex = 38;
            this.label14.Text = "Password";
            // 
            // radioButton_SFTP
            // 
            this.radioButton_SFTP.AutoSize = true;
            this.radioButton_SFTP.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButton_SFTP.Location = new System.Drawing.Point(467, 121);
            this.radioButton_SFTP.Name = "radioButton_SFTP";
            this.radioButton_SFTP.Size = new System.Drawing.Size(62, 25);
            this.radioButton_SFTP.TabIndex = 35;
            this.radioButton_SFTP.TabStop = true;
            this.radioButton_SFTP.Text = "SFTP";
            this.radioButton_SFTP.UseVisualStyleBackColor = true;
            this.radioButton_SFTP.CheckedChanged += new System.EventHandler(this.radioButton_SFTP_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(15, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(223, 21);
            this.label7.TabIndex = 15;
            this.label7.Text = "Select what will you backup";
            // 
            // textBox_Path
            // 
            this.textBox_Path.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_Path.Location = new System.Drawing.Point(18, 58);
            this.textBox_Path.Multiline = true;
            this.textBox_Path.Name = "textBox_Path";
            this.textBox_Path.Size = new System.Drawing.Size(200, 20);
            this.textBox_Path.TabIndex = 17;
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
            this.comboBox_Savingformat.Location = new System.Drawing.Point(512, 64);
            this.comboBox_Savingformat.Name = "comboBox_Savingformat";
            this.comboBox_Savingformat.Size = new System.Drawing.Size(176, 25);
            this.comboBox_Savingformat.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(15, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 21);
            this.label9.TabIndex = 34;
            this.label9.Text = "Destination";
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
            // 
            // textBox_FTPPassword
            // 
            this.textBox_FTPPassword.Enabled = false;
            this.textBox_FTPPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_FTPPassword.Location = new System.Drawing.Point(286, 273);
            this.textBox_FTPPassword.Multiline = true;
            this.textBox_FTPPassword.Name = "textBox_FTPPassword";
            this.textBox_FTPPassword.Size = new System.Drawing.Size(153, 20);
            this.textBox_FTPPassword.TabIndex = 29;
            // 
            // radioButton_Localnetwork
            // 
            this.radioButton_Localnetwork.AutoSize = true;
            this.radioButton_Localnetwork.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButton_Localnetwork.Location = new System.Drawing.Point(18, 121);
            this.radioButton_Localnetwork.Name = "radioButton_Localnetwork";
            this.radioButton_Localnetwork.Size = new System.Drawing.Size(173, 25);
            this.radioButton_Localnetwork.TabIndex = 16;
            this.radioButton_Localnetwork.TabStop = true;
            this.radioButton_Localnetwork.Text = "Local/network drives";
            this.radioButton_Localnetwork.UseVisualStyleBackColor = true;
            this.radioButton_Localnetwork.CheckedChanged += new System.EventHandler(this.radioButton_Localnetwork_CheckedChanged);
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
            this.radioButton_FTP.TabStop = true;
            this.radioButton_FTP.Text = "FTP";
            this.radioButton_FTP.UseVisualStyleBackColor = true;
            this.radioButton_FTP.CheckedChanged += new System.EventHandler(this.radioButton_FTP_CheckedChanged);
            // 
            // label_Adress
            // 
            this.label_Adress.AutoSize = true;
            this.label_Adress.Enabled = false;
            this.label_Adress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_Adress.Location = new System.Drawing.Point(212, 160);
            this.label_Adress.Name = "label_Adress";
            this.label_Adress.Size = new System.Drawing.Size(42, 15);
            this.label_Adress.TabIndex = 19;
            this.label_Adress.Text = "Adress";
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
            // 
            // textBox_Selectdestination
            // 
            this.textBox_Selectdestination.Enabled = false;
            this.textBox_Selectdestination.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_Selectdestination.Location = new System.Drawing.Point(18, 155);
            this.textBox_Selectdestination.Multiline = true;
            this.textBox_Selectdestination.Name = "textBox_Selectdestination";
            this.textBox_Selectdestination.Size = new System.Drawing.Size(150, 20);
            this.textBox_Selectdestination.TabIndex = 33;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Enabled = false;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(212, 237);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 15);
            this.label10.TabIndex = 24;
            this.label10.Text = "Username";
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
            this.comboBox_Afterbackup.Location = new System.Drawing.Point(512, 25);
            this.comboBox_Afterbackup.Name = "comboBox_Afterbackup";
            this.comboBox_Afterbackup.Size = new System.Drawing.Size(176, 25);
            this.comboBox_Afterbackup.TabIndex = 23;
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
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Enabled = false;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.Location = new System.Drawing.Point(212, 276);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 15);
            this.label11.TabIndex = 22;
            this.label11.Text = "Password";
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
            // 
            // tabPage_BackupScheme
            // 
            this.tabPage_BackupScheme.Controls.Add(this.tabControl_Scheme);
            this.tabPage_BackupScheme.Location = new System.Drawing.Point(32, 4);
            this.tabPage_BackupScheme.Name = "tabPage_BackupScheme";
            this.tabPage_BackupScheme.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_BackupScheme.Size = new System.Drawing.Size(712, 369);
            this.tabPage_BackupScheme.TabIndex = 1;
            this.tabPage_BackupScheme.Text = "Backup scheme";
            this.tabPage_BackupScheme.UseVisualStyleBackColor = true;
            // 
            // tabControl_Scheme
            // 
            this.tabControl_Scheme.Controls.Add(this.tabPage_OneTime);
            this.tabControl_Scheme.Controls.Add(this.tabPage_Daily);
            this.tabControl_Scheme.Controls.Add(this.tabPage_Weekly);
            this.tabControl_Scheme.Controls.Add(this.tabPage_Monthly);
            this.tabControl_Scheme.Location = new System.Drawing.Point(2, 0);
            this.tabControl_Scheme.Name = "tabControl_Scheme";
            this.tabControl_Scheme.SelectedIndex = 0;
            this.tabControl_Scheme.Size = new System.Drawing.Size(696, 370);
            this.tabControl_Scheme.TabIndex = 0;
            // 
            // tabPage_OneTime
            // 
            this.tabPage_OneTime.Controls.Add(this.label16);
            this.tabPage_OneTime.Controls.Add(this.dateTimePicker_OneTimeYMD);
            this.tabPage_OneTime.Controls.Add(this.dateTimePicker_OneTimeTime);
            this.tabPage_OneTime.Controls.Add(this.label15);
            this.tabPage_OneTime.Location = new System.Drawing.Point(4, 30);
            this.tabPage_OneTime.Name = "tabPage_OneTime";
            this.tabPage_OneTime.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_OneTime.Size = new System.Drawing.Size(688, 336);
            this.tabPage_OneTime.TabIndex = 0;
            this.tabPage_OneTime.Text = "One-Time";
            this.tabPage_OneTime.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(245, 27);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(28, 21);
            this.label16.TabIndex = 3;
            this.label16.Text = "on";
            // 
            // dateTimePicker_OneTimeYMD
            // 
            this.dateTimePicker_OneTimeYMD.Location = new System.Drawing.Point(279, 21);
            this.dateTimePicker_OneTimeYMD.Name = "dateTimePicker_OneTimeYMD";
            this.dateTimePicker_OneTimeYMD.Size = new System.Drawing.Size(113, 29);
            this.dateTimePicker_OneTimeYMD.TabIndex = 2;
            // 
            // dateTimePicker_OneTimeTime
            // 
            this.dateTimePicker_OneTimeTime.Location = new System.Drawing.Point(154, 21);
            this.dateTimePicker_OneTimeTime.Name = "dateTimePicker_OneTimeTime";
            this.dateTimePicker_OneTimeTime.Size = new System.Drawing.Size(85, 29);
            this.dateTimePicker_OneTimeTime.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 27);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(133, 21);
            this.label15.TabIndex = 0;
            this.label15.Text = "Execute backup at";
            // 
            // tabPage_Daily
            // 
            this.tabPage_Daily.Controls.Add(this.numericUpDown1);
            this.tabPage_Daily.Controls.Add(this.label19);
            this.tabPage_Daily.Location = new System.Drawing.Point(4, 30);
            this.tabPage_Daily.Name = "tabPage_Daily";
            this.tabPage_Daily.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Daily.Size = new System.Drawing.Size(688, 336);
            this.tabPage_Daily.TabIndex = 1;
            this.tabPage_Daily.Text = "Daily";
            this.tabPage_Daily.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(552, 41);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(49, 29);
            this.numericUpDown1.TabIndex = 67;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label19.Location = new System.Drawing.Point(499, 40);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(183, 25);
            this.label19.TabIndex = 66;
            this.label19.Text = "Keep            backups";
            // 
            // tabPage_Weekly
            // 
            this.tabPage_Weekly.Controls.Add(this.numericUpDown3);
            this.tabPage_Weekly.Controls.Add(this.label20);
            this.tabPage_Weekly.Location = new System.Drawing.Point(4, 30);
            this.tabPage_Weekly.Name = "tabPage_Weekly";
            this.tabPage_Weekly.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Weekly.Size = new System.Drawing.Size(688, 336);
            this.tabPage_Weekly.TabIndex = 2;
            this.tabPage_Weekly.Text = "Weekly";
            this.tabPage_Weekly.UseVisualStyleBackColor = true;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(552, 41);
            this.numericUpDown3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(49, 29);
            this.numericUpDown3.TabIndex = 65;
            this.numericUpDown3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label20.Location = new System.Drawing.Point(499, 40);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(183, 25);
            this.label20.TabIndex = 64;
            this.label20.Text = "Keep            backups";
            // 
            // tabPage_Monthly
            // 
            this.tabPage_Monthly.Controls.Add(this.numericUpDown2);
            this.tabPage_Monthly.Controls.Add(this.label21);
            this.tabPage_Monthly.Location = new System.Drawing.Point(4, 30);
            this.tabPage_Monthly.Name = "tabPage_Monthly";
            this.tabPage_Monthly.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Monthly.Size = new System.Drawing.Size(688, 336);
            this.tabPage_Monthly.TabIndex = 3;
            this.tabPage_Monthly.Text = "Monthly";
            this.tabPage_Monthly.UseVisualStyleBackColor = true;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(552, 41);
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(49, 29);
            this.numericUpDown2.TabIndex = 63;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label21.Location = new System.Drawing.Point(499, 40);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(183, 25);
            this.label21.TabIndex = 62;
            this.label21.Text = "Keep            backups";
            // 
            // button_Cancel
            // 
            this.button_Cancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_Cancel.Location = new System.Drawing.Point(628, 448);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(111, 45);
            this.button_Cancel.TabIndex = 1;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_Save
            // 
            this.button_Save.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_Save.Location = new System.Drawing.Point(511, 448);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(111, 45);
            this.button_Save.TabIndex = 2;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Form_NewMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 505);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.tabControl_DefaultMenu);
            this.Name = "Form_NewMenu";
            this.Text = "Form_NewMenu";
            this.tabControl_DefaultMenu.ResumeLayout(false);
            this.tabPage_EmailNotification.ResumeLayout(false);
            this.tabPage_EmailNotification.PerformLayout();
            this.tabPage_Administration.ResumeLayout(false);
            this.tabControl_Daemon.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabControl_Backup.ResumeLayout(false);
            this.tabPage_BackupSettings.ResumeLayout(false);
            this.tabPage_BackupSettings.PerformLayout();
            this.tabPage_BackupScheme.ResumeLayout(false);
            this.tabControl_Scheme.ResumeLayout(false);
            this.tabPage_OneTime.ResumeLayout(false);
            this.tabPage_OneTime.PerformLayout();
            this.tabPage_Daily.ResumeLayout(false);
            this.tabPage_Daily.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tabPage_Weekly.ResumeLayout(false);
            this.tabPage_Weekly.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.tabPage_Monthly.ResumeLayout(false);
            this.tabPage_Monthly.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_DefaultMenu;
        private System.Windows.Forms.TabPage tabPage_EmailNotification;
        private System.Windows.Forms.TabPage tabPage_Administration;
        private System.Windows.Forms.TextBox textBox_SMTPServerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_To;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_SMTPUsername;
        private System.Windows.Forms.TextBox textBox_SMTPPort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_SMTPPassword;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.TabControl tabControl_Daemon;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControl_Backup;
        private System.Windows.Forms.TabPage tabPage_BackupSettings;
        private System.Windows.Forms.TabPage tabPage_BackupScheme;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_Path;
        private System.Windows.Forms.ComboBox comboBox_Savingformat;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_FTPAdress;
        private System.Windows.Forms.TextBox textBox_FTPPassword;
        private System.Windows.Forms.RadioButton radioButton_Localnetwork;
        private System.Windows.Forms.TextBox textBox_FTPPort;
        private System.Windows.Forms.Label label_Savingformat;
        private System.Windows.Forms.RadioButton radioButton_FTP;
        private System.Windows.Forms.Label label_Adress;
        private System.Windows.Forms.TextBox textBox_FTPUsername;
        private System.Windows.Forms.TextBox textBox_Selectdestination;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox_Afterbackup;
        private System.Windows.Forms.Label label_FTPport;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label_AfterBackup;
        private System.Windows.Forms.TextBox textBox_SFTPAdress;
        private System.Windows.Forms.TextBox textBox_SFTPPassword;
        private System.Windows.Forms.TextBox textBox_SFTPPort;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_SFTPUsername;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RadioButton radioButton_SFTP;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TabControl tabControl_Scheme;
        private System.Windows.Forms.TabPage tabPage_OneTime;
        private System.Windows.Forms.TabPage tabPage_Daily;
        private System.Windows.Forms.TabPage tabPage_Weekly;
        private System.Windows.Forms.TabPage tabPage_Monthly;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dateTimePicker_OneTimeYMD;
        private System.Windows.Forms.DateTimePicker dateTimePicker_OneTimeTime;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBox_SFTPPath;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBox_FTPPath;
        private System.Windows.Forms.Label label22;
    }
}