﻿namespace AdminApp
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
            this.comboBox_DailyMethod5 = new System.Windows.Forms.ComboBox();
            this.comboBox_DailyMethod4 = new System.Windows.Forms.ComboBox();
            this.comboBox_DailyMethod3 = new System.Windows.Forms.ComboBox();
            this.comboBox_DailyMethod2 = new System.Windows.Forms.ComboBox();
            this.comboBox_DailyMethod1 = new System.Windows.Forms.ComboBox();
            this.textBox_DailyKeepingBackups = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.button_DailyRemoveTime5 = new System.Windows.Forms.Button();
            this.button_DailyRemoveTime4 = new System.Windows.Forms.Button();
            this.button_DailyRemoveTime3 = new System.Windows.Forms.Button();
            this.button_DailyAddTime5 = new System.Windows.Forms.Button();
            this.button_DailyAddTime4 = new System.Windows.Forms.Button();
            this.button_DailyAddTime3 = new System.Windows.Forms.Button();
            this.dateTimePicker_DailyTime4 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_DailyTime3 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_DailyTime2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_DailyTime5 = new System.Windows.Forms.DateTimePicker();
            this.button_DailyRemoveTime2 = new System.Windows.Forms.Button();
            this.button_DailyAddTime2 = new System.Windows.Forms.Button();
            this.dateTimePicker_DailyTime1 = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.tabPage_Weekly = new System.Windows.Forms.TabPage();
            this.panel_WeeklyDay = new System.Windows.Forms.Panel();
            this.comboBox_WeeklyDay3 = new System.Windows.Forms.ComboBox();
            this.comboBox_WeeklyDay2 = new System.Windows.Forms.ComboBox();
            this.comboBox_WeeklyDay1 = new System.Windows.Forms.ComboBox();
            this.button_WeeklyRemoveTime = new System.Windows.Forms.Button();
            this.button_WeeklyAddTime = new System.Windows.Forms.Button();
            this.dateTimePicker_WeeklyTime2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_WeeklyTime1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_WeeklyTime3 = new System.Windows.Forms.DateTimePicker();
            this.textBox_WeeklyKeepingBackups = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.checkBox_Tue = new System.Windows.Forms.CheckBox();
            this.checkBox_Sun = new System.Windows.Forms.CheckBox();
            this.checkBox_Sat = new System.Windows.Forms.CheckBox();
            this.checkBox_Fri = new System.Windows.Forms.CheckBox();
            this.checkBox_Thu = new System.Windows.Forms.CheckBox();
            this.checkBox_Wed = new System.Windows.Forms.CheckBox();
            this.checkBox_Mon = new System.Windows.Forms.CheckBox();
            this.tabPage_Monthly = new System.Windows.Forms.TabPage();
            this.textBox_MonthlyKeepingBackups = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.checkBox_MonthlyDay14 = new System.Windows.Forms.CheckBox();
            this.checkBox_MonthlyDay13 = new System.Windows.Forms.CheckBox();
            this.checkBox_MonthlyDay11 = new System.Windows.Forms.CheckBox();
            this.checkBox_MonthlyDay4 = new System.Windows.Forms.CheckBox();
            this.checkBox_MonthlyDay3 = new System.Windows.Forms.CheckBox();
            this.checkBox_MonthlyDay27 = new System.Windows.Forms.CheckBox();
            this.checkBox_MonthlyDay26 = new System.Windows.Forms.CheckBox();
            this.checkBox_MonthlyDay21 = new System.Windows.Forms.CheckBox();
            this.checkBox_MonthlyDay7 = new System.Windows.Forms.CheckBox();
            this.checkBox_MonthlyDay6 = new System.Windows.Forms.CheckBox();
            this.checkBox_MonthlyDay9 = new System.Windows.Forms.CheckBox();
            this.checkBox_MonthlyDay20 = new System.Windows.Forms.CheckBox();
            this.checkBox_MonthlyDay19 = new System.Windows.Forms.CheckBox();
            this.checkBox_MonthlyDay18 = new System.Windows.Forms.CheckBox();
            this.checkBox_MonthlyDay24 = new System.Windows.Forms.CheckBox();
            this.checkBox_MonthlyDay17 = new System.Windows.Forms.CheckBox();
            this.checkBox_MonthlyDay12 = new System.Windows.Forms.CheckBox();
            this.checkBox_MonthlyDay10 = new System.Windows.Forms.CheckBox();
            this.checkBox_MonthlyDay22 = new System.Windows.Forms.CheckBox();
            this.checkBox_MonthlyDay15 = new System.Windows.Forms.CheckBox();
            this.checkBox_MonthlyDay8 = new System.Windows.Forms.CheckBox();
            this.checkBox_MonthlyDay5 = new System.Windows.Forms.CheckBox();
            this.checkBox_MonthlyDay25 = new System.Windows.Forms.CheckBox();
            this.checkBox_MonthlyDay23 = new System.Windows.Forms.CheckBox();
            this.checkBox_MonthlyDay28 = new System.Windows.Forms.CheckBox();
            this.checkBox_MonthlyDay29 = new System.Windows.Forms.CheckBox();
            this.checkBox_MonthlyDay30 = new System.Windows.Forms.CheckBox();
            this.checkBox_MonthlyDay31 = new System.Windows.Forms.CheckBox();
            this.checkBox_MonthlyDay16 = new System.Windows.Forms.CheckBox();
            this.checkBox_MonthlyDay2 = new System.Windows.Forms.CheckBox();
            this.checkBox_MonthlyDay1 = new System.Windows.Forms.CheckBox();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel_MonthlyDay = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
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
            this.tabPage_Weekly.SuspendLayout();
            this.panel_WeeklyDay.SuspendLayout();
            this.tabPage_Monthly.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel_MonthlyDay.SuspendLayout();
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
            // textBox_SFTPAdress
            // 
            this.textBox_SFTPAdress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_SFTPAdress.Location = new System.Drawing.Point(538, 159);
            this.textBox_SFTPAdress.Multiline = true;
            this.textBox_SFTPAdress.Name = "textBox_SFTPAdress";
            this.textBox_SFTPAdress.Size = new System.Drawing.Size(153, 20);
            this.textBox_SFTPAdress.TabIndex = 43;
            // 
            // textBox_SFTPPassword
            // 
            this.textBox_SFTPPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_SFTPPassword.Location = new System.Drawing.Point(538, 275);
            this.textBox_SFTPPassword.Multiline = true;
            this.textBox_SFTPPassword.Name = "textBox_SFTPPassword";
            this.textBox_SFTPPassword.Size = new System.Drawing.Size(153, 20);
            this.textBox_SFTPPassword.TabIndex = 42;
            // 
            // textBox_SFTPPort
            // 
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
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(464, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 15);
            this.label8.TabIndex = 36;
            this.label8.Text = "Adress";
            // 
            // textBox_SFTPUsername
            // 
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
            this.textBox_Path.Text = "Path";
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
            "Archive .zip",
            "Without comprimation"});
            this.comboBox_Savingformat.Location = new System.Drawing.Point(574, 64);
            this.comboBox_Savingformat.Name = "comboBox_Savingformat";
            this.comboBox_Savingformat.Size = new System.Drawing.Size(114, 25);
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
            this.textBox_FTPAdress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_FTPAdress.Location = new System.Drawing.Point(286, 157);
            this.textBox_FTPAdress.Multiline = true;
            this.textBox_FTPAdress.Name = "textBox_FTPAdress";
            this.textBox_FTPAdress.Size = new System.Drawing.Size(153, 20);
            this.textBox_FTPAdress.TabIndex = 30;
            // 
            // textBox_FTPPassword
            // 
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
            this.label_Savingformat.Location = new System.Drawing.Point(464, 67);
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
            this.label_Adress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_Adress.Location = new System.Drawing.Point(212, 160);
            this.label_Adress.Name = "label_Adress";
            this.label_Adress.Size = new System.Drawing.Size(42, 15);
            this.label_Adress.TabIndex = 19;
            this.label_Adress.Text = "Adress";
            // 
            // textBox_FTPUsername
            // 
            this.textBox_FTPUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_FTPUsername.Location = new System.Drawing.Point(286, 234);
            this.textBox_FTPUsername.Multiline = true;
            this.textBox_FTPUsername.Name = "textBox_FTPUsername";
            this.textBox_FTPUsername.Size = new System.Drawing.Size(153, 20);
            this.textBox_FTPUsername.TabIndex = 27;
            // 
            // textBox_Selectdestination
            // 
            this.textBox_Selectdestination.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_Selectdestination.Location = new System.Drawing.Point(18, 155);
            this.textBox_Selectdestination.Multiline = true;
            this.textBox_Selectdestination.Name = "textBox_Selectdestination";
            this.textBox_Selectdestination.Size = new System.Drawing.Size(150, 20);
            this.textBox_Selectdestination.TabIndex = 33;
            this.textBox_Selectdestination.Text = "Path";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
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
            "Restart",
            "Turn off",
            "Sleep mode"});
            this.comboBox_Afterbackup.Location = new System.Drawing.Point(574, 25);
            this.comboBox_Afterbackup.Name = "comboBox_Afterbackup";
            this.comboBox_Afterbackup.Size = new System.Drawing.Size(114, 25);
            this.comboBox_Afterbackup.TabIndex = 23;
            // 
            // label_FTPport
            // 
            this.label_FTPport.AutoSize = true;
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
            this.label_AfterBackup.Location = new System.Drawing.Point(464, 28);
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
            this.tabPage_Daily.Controls.Add(this.comboBox_DailyMethod5);
            this.tabPage_Daily.Controls.Add(this.comboBox_DailyMethod4);
            this.tabPage_Daily.Controls.Add(this.comboBox_DailyMethod3);
            this.tabPage_Daily.Controls.Add(this.comboBox_DailyMethod2);
            this.tabPage_Daily.Controls.Add(this.comboBox_DailyMethod1);
            this.tabPage_Daily.Controls.Add(this.textBox_DailyKeepingBackups);
            this.tabPage_Daily.Controls.Add(this.label18);
            this.tabPage_Daily.Controls.Add(this.button_DailyRemoveTime5);
            this.tabPage_Daily.Controls.Add(this.button_DailyRemoveTime4);
            this.tabPage_Daily.Controls.Add(this.button_DailyRemoveTime3);
            this.tabPage_Daily.Controls.Add(this.button_DailyAddTime5);
            this.tabPage_Daily.Controls.Add(this.button_DailyAddTime4);
            this.tabPage_Daily.Controls.Add(this.button_DailyAddTime3);
            this.tabPage_Daily.Controls.Add(this.dateTimePicker_DailyTime4);
            this.tabPage_Daily.Controls.Add(this.dateTimePicker_DailyTime3);
            this.tabPage_Daily.Controls.Add(this.dateTimePicker_DailyTime2);
            this.tabPage_Daily.Controls.Add(this.dateTimePicker_DailyTime5);
            this.tabPage_Daily.Controls.Add(this.button_DailyRemoveTime2);
            this.tabPage_Daily.Controls.Add(this.button_DailyAddTime2);
            this.tabPage_Daily.Controls.Add(this.dateTimePicker_DailyTime1);
            this.tabPage_Daily.Controls.Add(this.label17);
            this.tabPage_Daily.Location = new System.Drawing.Point(4, 30);
            this.tabPage_Daily.Name = "tabPage_Daily";
            this.tabPage_Daily.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Daily.Size = new System.Drawing.Size(688, 336);
            this.tabPage_Daily.TabIndex = 1;
            this.tabPage_Daily.Text = "Daily";
            this.tabPage_Daily.UseVisualStyleBackColor = true;
            // 
            // comboBox_DailyMethod5
            // 
            this.comboBox_DailyMethod5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DailyMethod5.FormattingEnabled = true;
            this.comboBox_DailyMethod5.Items.AddRange(new object[] {
            "Full backup",
            "Incremental backup",
            "Differential backup"});
            this.comboBox_DailyMethod5.Location = new System.Drawing.Point(371, 98);
            this.comboBox_DailyMethod5.Name = "comboBox_DailyMethod5";
            this.comboBox_DailyMethod5.Size = new System.Drawing.Size(85, 29);
            this.comboBox_DailyMethod5.TabIndex = 21;
            // 
            // comboBox_DailyMethod4
            // 
            this.comboBox_DailyMethod4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DailyMethod4.FormattingEnabled = true;
            this.comboBox_DailyMethod4.Items.AddRange(new object[] {
            "Full backup",
            "Incremental backup",
            "Differential backup"});
            this.comboBox_DailyMethod4.Location = new System.Drawing.Point(280, 98);
            this.comboBox_DailyMethod4.Name = "comboBox_DailyMethod4";
            this.comboBox_DailyMethod4.Size = new System.Drawing.Size(85, 29);
            this.comboBox_DailyMethod4.TabIndex = 20;
            // 
            // comboBox_DailyMethod3
            // 
            this.comboBox_DailyMethod3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DailyMethod3.FormattingEnabled = true;
            this.comboBox_DailyMethod3.Items.AddRange(new object[] {
            "Full backup",
            "Incremental backup",
            "Differential backup"});
            this.comboBox_DailyMethod3.Location = new System.Drawing.Point(189, 98);
            this.comboBox_DailyMethod3.Name = "comboBox_DailyMethod3";
            this.comboBox_DailyMethod3.Size = new System.Drawing.Size(85, 29);
            this.comboBox_DailyMethod3.TabIndex = 19;
            // 
            // comboBox_DailyMethod2
            // 
            this.comboBox_DailyMethod2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DailyMethod2.FormattingEnabled = true;
            this.comboBox_DailyMethod2.Items.AddRange(new object[] {
            "Full backup",
            "Incremental backup",
            "Differential backup"});
            this.comboBox_DailyMethod2.Location = new System.Drawing.Point(98, 98);
            this.comboBox_DailyMethod2.Name = "comboBox_DailyMethod2";
            this.comboBox_DailyMethod2.Size = new System.Drawing.Size(85, 29);
            this.comboBox_DailyMethod2.TabIndex = 18;
            // 
            // comboBox_DailyMethod1
            // 
            this.comboBox_DailyMethod1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DailyMethod1.FormattingEnabled = true;
            this.comboBox_DailyMethod1.Items.AddRange(new object[] {
            "Full backup"});
            this.comboBox_DailyMethod1.Location = new System.Drawing.Point(7, 98);
            this.comboBox_DailyMethod1.Name = "comboBox_DailyMethod1";
            this.comboBox_DailyMethod1.Size = new System.Drawing.Size(85, 29);
            this.comboBox_DailyMethod1.TabIndex = 17;
            // 
            // textBox_DailyKeepingBackups
            // 
            this.textBox_DailyKeepingBackups.Location = new System.Drawing.Point(312, 271);
            this.textBox_DailyKeepingBackups.Name = "textBox_DailyKeepingBackups";
            this.textBox_DailyKeepingBackups.Size = new System.Drawing.Size(100, 29);
            this.textBox_DailyKeepingBackups.TabIndex = 16;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 274);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(298, 21);
            this.label18.TabIndex = 15;
            this.label18.Text = "How many backups do you want to keep?";
            // 
            // button_DailyRemoveTime5
            // 
            this.button_DailyRemoveTime5.Location = new System.Drawing.Point(418, 176);
            this.button_DailyRemoveTime5.Name = "button_DailyRemoveTime5";
            this.button_DailyRemoveTime5.Size = new System.Drawing.Size(39, 30);
            this.button_DailyRemoveTime5.TabIndex = 14;
            this.button_DailyRemoveTime5.Text = "-";
            this.button_DailyRemoveTime5.UseVisualStyleBackColor = true;
            this.button_DailyRemoveTime5.Click += new System.EventHandler(this.button_DailyRemoveTime5_Click);
            // 
            // button_DailyRemoveTime4
            // 
            this.button_DailyRemoveTime4.Location = new System.Drawing.Point(327, 176);
            this.button_DailyRemoveTime4.Name = "button_DailyRemoveTime4";
            this.button_DailyRemoveTime4.Size = new System.Drawing.Size(39, 30);
            this.button_DailyRemoveTime4.TabIndex = 13;
            this.button_DailyRemoveTime4.Text = "-";
            this.button_DailyRemoveTime4.UseVisualStyleBackColor = true;
            this.button_DailyRemoveTime4.Click += new System.EventHandler(this.button_DailyRemoveTime4_Click);
            // 
            // button_DailyRemoveTime3
            // 
            this.button_DailyRemoveTime3.Location = new System.Drawing.Point(236, 176);
            this.button_DailyRemoveTime3.Name = "button_DailyRemoveTime3";
            this.button_DailyRemoveTime3.Size = new System.Drawing.Size(39, 30);
            this.button_DailyRemoveTime3.TabIndex = 12;
            this.button_DailyRemoveTime3.Text = "-";
            this.button_DailyRemoveTime3.UseVisualStyleBackColor = true;
            this.button_DailyRemoveTime3.Click += new System.EventHandler(this.button_DailyRemoveTime3_Click);
            // 
            // button_DailyAddTime5
            // 
            this.button_DailyAddTime5.Location = new System.Drawing.Point(372, 176);
            this.button_DailyAddTime5.Name = "button_DailyAddTime5";
            this.button_DailyAddTime5.Size = new System.Drawing.Size(40, 30);
            this.button_DailyAddTime5.TabIndex = 10;
            this.button_DailyAddTime5.Text = "+";
            this.button_DailyAddTime5.UseVisualStyleBackColor = true;
            this.button_DailyAddTime5.Click += new System.EventHandler(this.button_DailyAddTime5_Click);
            // 
            // button_DailyAddTime4
            // 
            this.button_DailyAddTime4.Location = new System.Drawing.Point(281, 176);
            this.button_DailyAddTime4.Name = "button_DailyAddTime4";
            this.button_DailyAddTime4.Size = new System.Drawing.Size(40, 30);
            this.button_DailyAddTime4.TabIndex = 9;
            this.button_DailyAddTime4.Text = "+";
            this.button_DailyAddTime4.UseVisualStyleBackColor = true;
            this.button_DailyAddTime4.Click += new System.EventHandler(this.button_DailyAddTime4_Click);
            // 
            // button_DailyAddTime3
            // 
            this.button_DailyAddTime3.Location = new System.Drawing.Point(190, 176);
            this.button_DailyAddTime3.Name = "button_DailyAddTime3";
            this.button_DailyAddTime3.Size = new System.Drawing.Size(40, 30);
            this.button_DailyAddTime3.TabIndex = 8;
            this.button_DailyAddTime3.Text = "+";
            this.button_DailyAddTime3.UseVisualStyleBackColor = true;
            this.button_DailyAddTime3.Click += new System.EventHandler(this.button_DailyAddTime3_Click);
            // 
            // dateTimePicker_DailyTime4
            // 
            this.dateTimePicker_DailyTime4.Location = new System.Drawing.Point(280, 63);
            this.dateTimePicker_DailyTime4.Name = "dateTimePicker_DailyTime4";
            this.dateTimePicker_DailyTime4.Size = new System.Drawing.Size(85, 29);
            this.dateTimePicker_DailyTime4.TabIndex = 7;
            // 
            // dateTimePicker_DailyTime3
            // 
            this.dateTimePicker_DailyTime3.Location = new System.Drawing.Point(189, 63);
            this.dateTimePicker_DailyTime3.Name = "dateTimePicker_DailyTime3";
            this.dateTimePicker_DailyTime3.Size = new System.Drawing.Size(85, 29);
            this.dateTimePicker_DailyTime3.TabIndex = 6;
            // 
            // dateTimePicker_DailyTime2
            // 
            this.dateTimePicker_DailyTime2.Location = new System.Drawing.Point(98, 63);
            this.dateTimePicker_DailyTime2.Name = "dateTimePicker_DailyTime2";
            this.dateTimePicker_DailyTime2.Size = new System.Drawing.Size(85, 29);
            this.dateTimePicker_DailyTime2.TabIndex = 5;
            // 
            // dateTimePicker_DailyTime5
            // 
            this.dateTimePicker_DailyTime5.Location = new System.Drawing.Point(371, 63);
            this.dateTimePicker_DailyTime5.Name = "dateTimePicker_DailyTime5";
            this.dateTimePicker_DailyTime5.Size = new System.Drawing.Size(85, 29);
            this.dateTimePicker_DailyTime5.TabIndex = 4;
            // 
            // button_DailyRemoveTime2
            // 
            this.button_DailyRemoveTime2.Location = new System.Drawing.Point(145, 176);
            this.button_DailyRemoveTime2.Name = "button_DailyRemoveTime2";
            this.button_DailyRemoveTime2.Size = new System.Drawing.Size(39, 30);
            this.button_DailyRemoveTime2.TabIndex = 3;
            this.button_DailyRemoveTime2.Text = "-";
            this.button_DailyRemoveTime2.UseVisualStyleBackColor = true;
            this.button_DailyRemoveTime2.Click += new System.EventHandler(this.button_DailyRemoveTime2_Click);
            // 
            // button_DailyAddTime2
            // 
            this.button_DailyAddTime2.Location = new System.Drawing.Point(98, 176);
            this.button_DailyAddTime2.Name = "button_DailyAddTime2";
            this.button_DailyAddTime2.Size = new System.Drawing.Size(40, 30);
            this.button_DailyAddTime2.TabIndex = 2;
            this.button_DailyAddTime2.Text = "+";
            this.button_DailyAddTime2.UseVisualStyleBackColor = true;
            this.button_DailyAddTime2.Click += new System.EventHandler(this.button_DailyAddTime2_Click);
            // 
            // dateTimePicker_DailyTime1
            // 
            this.dateTimePicker_DailyTime1.Location = new System.Drawing.Point(7, 63);
            this.dateTimePicker_DailyTime1.Name = "dateTimePicker_DailyTime1";
            this.dateTimePicker_DailyTime1.Size = new System.Drawing.Size(85, 29);
            this.dateTimePicker_DailyTime1.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label17.Location = new System.Drawing.Point(3, 26);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 21);
            this.label17.TabIndex = 0;
            this.label17.Text = "Time";
            // 
            // tabPage_Weekly
            // 
            this.tabPage_Weekly.Controls.Add(this.panel_WeeklyDay);
            this.tabPage_Weekly.Controls.Add(this.textBox_WeeklyKeepingBackups);
            this.tabPage_Weekly.Controls.Add(this.label19);
            this.tabPage_Weekly.Controls.Add(this.checkBox_Tue);
            this.tabPage_Weekly.Controls.Add(this.checkBox_Sun);
            this.tabPage_Weekly.Controls.Add(this.checkBox_Sat);
            this.tabPage_Weekly.Controls.Add(this.checkBox_Fri);
            this.tabPage_Weekly.Controls.Add(this.checkBox_Thu);
            this.tabPage_Weekly.Controls.Add(this.checkBox_Wed);
            this.tabPage_Weekly.Controls.Add(this.checkBox_Mon);
            this.tabPage_Weekly.Location = new System.Drawing.Point(4, 30);
            this.tabPage_Weekly.Name = "tabPage_Weekly";
            this.tabPage_Weekly.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Weekly.Size = new System.Drawing.Size(688, 336);
            this.tabPage_Weekly.TabIndex = 2;
            this.tabPage_Weekly.Text = "Weekly";
            this.tabPage_Weekly.UseVisualStyleBackColor = true;
            // 
            // panel_WeeklyDay
            // 
            this.panel_WeeklyDay.Controls.Add(this.comboBox_WeeklyDay3);
            this.panel_WeeklyDay.Controls.Add(this.comboBox_WeeklyDay2);
            this.panel_WeeklyDay.Controls.Add(this.comboBox_WeeklyDay1);
            this.panel_WeeklyDay.Controls.Add(this.button_WeeklyRemoveTime);
            this.panel_WeeklyDay.Controls.Add(this.button_WeeklyAddTime);
            this.panel_WeeklyDay.Controls.Add(this.dateTimePicker_WeeklyTime2);
            this.panel_WeeklyDay.Controls.Add(this.dateTimePicker_WeeklyTime1);
            this.panel_WeeklyDay.Controls.Add(this.dateTimePicker_WeeklyTime3);
            this.panel_WeeklyDay.Location = new System.Drawing.Point(13, 65);
            this.panel_WeeklyDay.Name = "panel_WeeklyDay";
            this.panel_WeeklyDay.Size = new System.Drawing.Size(160, 224);
            this.panel_WeeklyDay.TabIndex = 30;
            // 
            // comboBox_WeeklyDay3
            // 
            this.comboBox_WeeklyDay3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_WeeklyDay3.FormattingEnabled = true;
            this.comboBox_WeeklyDay3.Items.AddRange(new object[] {
            "Full backup",
            "Incremental backup ",
            "Differential backup"});
            this.comboBox_WeeklyDay3.Location = new System.Drawing.Point(29, 187);
            this.comboBox_WeeklyDay3.Name = "comboBox_WeeklyDay3";
            this.comboBox_WeeklyDay3.Size = new System.Drawing.Size(85, 29);
            this.comboBox_WeeklyDay3.TabIndex = 32;
            // 
            // comboBox_WeeklyDay2
            // 
            this.comboBox_WeeklyDay2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_WeeklyDay2.FormattingEnabled = true;
            this.comboBox_WeeklyDay2.Items.AddRange(new object[] {
            "Full backup",
            "Incremental backup ",
            "Differential backup"});
            this.comboBox_WeeklyDay2.Location = new System.Drawing.Point(29, 116);
            this.comboBox_WeeklyDay2.Name = "comboBox_WeeklyDay2";
            this.comboBox_WeeklyDay2.Size = new System.Drawing.Size(85, 29);
            this.comboBox_WeeklyDay2.TabIndex = 31;
            // 
            // comboBox_WeeklyDay1
            // 
            this.comboBox_WeeklyDay1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_WeeklyDay1.FormattingEnabled = true;
            this.comboBox_WeeklyDay1.Items.AddRange(new object[] {
            "Full backup",
            "Incremental backup ",
            "Differential backup"});
            this.comboBox_WeeklyDay1.Location = new System.Drawing.Point(29, 43);
            this.comboBox_WeeklyDay1.Name = "comboBox_WeeklyDay1";
            this.comboBox_WeeklyDay1.Size = new System.Drawing.Size(85, 29);
            this.comboBox_WeeklyDay1.TabIndex = 30;
            // 
            // button_WeeklyRemoveTime
            // 
            this.button_WeeklyRemoveTime.Location = new System.Drawing.Point(120, 52);
            this.button_WeeklyRemoveTime.Name = "button_WeeklyRemoveTime";
            this.button_WeeklyRemoveTime.Size = new System.Drawing.Size(25, 29);
            this.button_WeeklyRemoveTime.TabIndex = 29;
            this.button_WeeklyRemoveTime.Text = "-";
            this.button_WeeklyRemoveTime.UseVisualStyleBackColor = true;
            this.button_WeeklyRemoveTime.Click += new System.EventHandler(this.button_WeeklyRemoveTime_Click);
            // 
            // button_WeeklyAddTime
            // 
            this.button_WeeklyAddTime.Location = new System.Drawing.Point(120, 17);
            this.button_WeeklyAddTime.Name = "button_WeeklyAddTime";
            this.button_WeeklyAddTime.Size = new System.Drawing.Size(25, 29);
            this.button_WeeklyAddTime.TabIndex = 28;
            this.button_WeeklyAddTime.Text = "+";
            this.button_WeeklyAddTime.UseVisualStyleBackColor = true;
            this.button_WeeklyAddTime.Click += new System.EventHandler(this.button_WeeklyAddTime_Click);
            // 
            // dateTimePicker_WeeklyTime2
            // 
            this.dateTimePicker_WeeklyTime2.Enabled = false;
            this.dateTimePicker_WeeklyTime2.Location = new System.Drawing.Point(29, 90);
            this.dateTimePicker_WeeklyTime2.Name = "dateTimePicker_WeeklyTime2";
            this.dateTimePicker_WeeklyTime2.Size = new System.Drawing.Size(85, 29);
            this.dateTimePicker_WeeklyTime2.TabIndex = 27;
            // 
            // dateTimePicker_WeeklyTime1
            // 
            this.dateTimePicker_WeeklyTime1.Enabled = false;
            this.dateTimePicker_WeeklyTime1.Location = new System.Drawing.Point(29, 17);
            this.dateTimePicker_WeeklyTime1.Name = "dateTimePicker_WeeklyTime1";
            this.dateTimePicker_WeeklyTime1.Size = new System.Drawing.Size(85, 29);
            this.dateTimePicker_WeeklyTime1.TabIndex = 21;
            // 
            // dateTimePicker_WeeklyTime3
            // 
            this.dateTimePicker_WeeklyTime3.Enabled = false;
            this.dateTimePicker_WeeklyTime3.Location = new System.Drawing.Point(29, 160);
            this.dateTimePicker_WeeklyTime3.Name = "dateTimePicker_WeeklyTime3";
            this.dateTimePicker_WeeklyTime3.Size = new System.Drawing.Size(85, 29);
            this.dateTimePicker_WeeklyTime3.TabIndex = 26;
            // 
            // textBox_WeeklyKeepingBackups
            // 
            this.textBox_WeeklyKeepingBackups.Location = new System.Drawing.Point(318, 289);
            this.textBox_WeeklyKeepingBackups.Name = "textBox_WeeklyKeepingBackups";
            this.textBox_WeeklyKeepingBackups.Size = new System.Drawing.Size(100, 29);
            this.textBox_WeeklyKeepingBackups.TabIndex = 29;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(9, 292);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(298, 21);
            this.label19.TabIndex = 28;
            this.label19.Text = "How many backups do you want to keep?";
            // 
            // checkBox_Tue
            // 
            this.checkBox_Tue.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_Tue.AutoSize = true;
            this.checkBox_Tue.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_Tue.Location = new System.Drawing.Point(154, 28);
            this.checkBox_Tue.Name = "checkBox_Tue";
            this.checkBox_Tue.Size = new System.Drawing.Size(45, 31);
            this.checkBox_Tue.TabIndex = 15;
            this.checkBox_Tue.Text = "Tue";
            this.checkBox_Tue.UseVisualStyleBackColor = false;
            // 
            // checkBox_Sun
            // 
            this.checkBox_Sun.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_Sun.AutoSize = true;
            this.checkBox_Sun.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_Sun.Location = new System.Drawing.Point(408, 28);
            this.checkBox_Sun.Name = "checkBox_Sun";
            this.checkBox_Sun.Size = new System.Drawing.Size(47, 31);
            this.checkBox_Sun.TabIndex = 20;
            this.checkBox_Sun.Text = "Sun";
            this.checkBox_Sun.UseVisualStyleBackColor = false;
            // 
            // checkBox_Sat
            // 
            this.checkBox_Sat.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_Sat.AutoSize = true;
            this.checkBox_Sat.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_Sat.Location = new System.Drawing.Point(360, 28);
            this.checkBox_Sat.Name = "checkBox_Sat";
            this.checkBox_Sat.Size = new System.Drawing.Size(42, 31);
            this.checkBox_Sat.TabIndex = 19;
            this.checkBox_Sat.Text = "Sat";
            this.checkBox_Sat.UseVisualStyleBackColor = false;
            // 
            // checkBox_Fri
            // 
            this.checkBox_Fri.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_Fri.AutoSize = true;
            this.checkBox_Fri.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_Fri.Location = new System.Drawing.Point(316, 28);
            this.checkBox_Fri.Name = "checkBox_Fri";
            this.checkBox_Fri.Size = new System.Drawing.Size(38, 31);
            this.checkBox_Fri.TabIndex = 18;
            this.checkBox_Fri.Text = "Fri";
            this.checkBox_Fri.UseVisualStyleBackColor = false;
            // 
            // checkBox_Thu
            // 
            this.checkBox_Thu.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_Thu.AutoSize = true;
            this.checkBox_Thu.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_Thu.Location = new System.Drawing.Point(264, 28);
            this.checkBox_Thu.Name = "checkBox_Thu";
            this.checkBox_Thu.Size = new System.Drawing.Size(46, 31);
            this.checkBox_Thu.TabIndex = 17;
            this.checkBox_Thu.Text = "Thu";
            this.checkBox_Thu.UseVisualStyleBackColor = false;
            // 
            // checkBox_Wed
            // 
            this.checkBox_Wed.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_Wed.AutoSize = true;
            this.checkBox_Wed.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_Wed.Location = new System.Drawing.Point(205, 28);
            this.checkBox_Wed.Name = "checkBox_Wed";
            this.checkBox_Wed.Size = new System.Drawing.Size(51, 31);
            this.checkBox_Wed.TabIndex = 16;
            this.checkBox_Wed.Text = "Wed";
            this.checkBox_Wed.UseVisualStyleBackColor = false;
            // 
            // checkBox_Mon
            // 
            this.checkBox_Mon.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_Mon.AutoSize = true;
            this.checkBox_Mon.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_Mon.Location = new System.Drawing.Point(96, 28);
            this.checkBox_Mon.Name = "checkBox_Mon";
            this.checkBox_Mon.Size = new System.Drawing.Size(52, 31);
            this.checkBox_Mon.TabIndex = 14;
            this.checkBox_Mon.Text = "Mon";
            this.checkBox_Mon.UseVisualStyleBackColor = false;
            this.checkBox_Mon.CheckedChanged += new System.EventHandler(this.checkBox_Mon_CheckedChanged);
            // 
            // tabPage_Monthly
            // 
            this.tabPage_Monthly.Controls.Add(this.panel_MonthlyDay);
            this.tabPage_Monthly.Controls.Add(this.textBox_MonthlyKeepingBackups);
            this.tabPage_Monthly.Controls.Add(this.label20);
            this.tabPage_Monthly.Controls.Add(this.checkBox_MonthlyDay14);
            this.tabPage_Monthly.Controls.Add(this.checkBox_MonthlyDay13);
            this.tabPage_Monthly.Controls.Add(this.checkBox_MonthlyDay11);
            this.tabPage_Monthly.Controls.Add(this.checkBox_MonthlyDay4);
            this.tabPage_Monthly.Controls.Add(this.checkBox_MonthlyDay3);
            this.tabPage_Monthly.Controls.Add(this.checkBox_MonthlyDay27);
            this.tabPage_Monthly.Controls.Add(this.checkBox_MonthlyDay26);
            this.tabPage_Monthly.Controls.Add(this.checkBox_MonthlyDay21);
            this.tabPage_Monthly.Controls.Add(this.checkBox_MonthlyDay7);
            this.tabPage_Monthly.Controls.Add(this.checkBox_MonthlyDay6);
            this.tabPage_Monthly.Controls.Add(this.checkBox_MonthlyDay9);
            this.tabPage_Monthly.Controls.Add(this.checkBox_MonthlyDay20);
            this.tabPage_Monthly.Controls.Add(this.checkBox_MonthlyDay19);
            this.tabPage_Monthly.Controls.Add(this.checkBox_MonthlyDay18);
            this.tabPage_Monthly.Controls.Add(this.checkBox_MonthlyDay24);
            this.tabPage_Monthly.Controls.Add(this.checkBox_MonthlyDay17);
            this.tabPage_Monthly.Controls.Add(this.checkBox_MonthlyDay12);
            this.tabPage_Monthly.Controls.Add(this.checkBox_MonthlyDay10);
            this.tabPage_Monthly.Controls.Add(this.checkBox_MonthlyDay22);
            this.tabPage_Monthly.Controls.Add(this.checkBox_MonthlyDay15);
            this.tabPage_Monthly.Controls.Add(this.checkBox_MonthlyDay8);
            this.tabPage_Monthly.Controls.Add(this.checkBox_MonthlyDay5);
            this.tabPage_Monthly.Controls.Add(this.checkBox_MonthlyDay25);
            this.tabPage_Monthly.Controls.Add(this.checkBox_MonthlyDay23);
            this.tabPage_Monthly.Controls.Add(this.checkBox_MonthlyDay28);
            this.tabPage_Monthly.Controls.Add(this.checkBox_MonthlyDay29);
            this.tabPage_Monthly.Controls.Add(this.checkBox_MonthlyDay30);
            this.tabPage_Monthly.Controls.Add(this.checkBox_MonthlyDay31);
            this.tabPage_Monthly.Controls.Add(this.checkBox_MonthlyDay16);
            this.tabPage_Monthly.Controls.Add(this.checkBox_MonthlyDay2);
            this.tabPage_Monthly.Controls.Add(this.checkBox_MonthlyDay1);
            this.tabPage_Monthly.Location = new System.Drawing.Point(4, 30);
            this.tabPage_Monthly.Name = "tabPage_Monthly";
            this.tabPage_Monthly.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Monthly.Size = new System.Drawing.Size(688, 336);
            this.tabPage_Monthly.TabIndex = 3;
            this.tabPage_Monthly.Text = "Monthly";
            this.tabPage_Monthly.UseVisualStyleBackColor = true;
            // 
            // textBox_MonthlyKeepingBackups
            // 
            this.textBox_MonthlyKeepingBackups.Location = new System.Drawing.Point(317, 292);
            this.textBox_MonthlyKeepingBackups.Name = "textBox_MonthlyKeepingBackups";
            this.textBox_MonthlyKeepingBackups.Size = new System.Drawing.Size(100, 29);
            this.textBox_MonthlyKeepingBackups.TabIndex = 62;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(8, 295);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(298, 21);
            this.label20.TabIndex = 61;
            this.label20.Text = "How many backups do you want to keep?";
            // 
            // checkBox_MonthlyDay14
            // 
            this.checkBox_MonthlyDay14.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_MonthlyDay14.AutoSize = true;
            this.checkBox_MonthlyDay14.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_MonthlyDay14.Location = new System.Drawing.Point(344, 84);
            this.checkBox_MonthlyDay14.Name = "checkBox_MonthlyDay14";
            this.checkBox_MonthlyDay14.Size = new System.Drawing.Size(38, 31);
            this.checkBox_MonthlyDay14.TabIndex = 60;
            this.checkBox_MonthlyDay14.Text = "14";
            this.checkBox_MonthlyDay14.UseVisualStyleBackColor = false;
            // 
            // checkBox_MonthlyDay13
            // 
            this.checkBox_MonthlyDay13.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_MonthlyDay13.AutoSize = true;
            this.checkBox_MonthlyDay13.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_MonthlyDay13.Location = new System.Drawing.Point(304, 84);
            this.checkBox_MonthlyDay13.Name = "checkBox_MonthlyDay13";
            this.checkBox_MonthlyDay13.Size = new System.Drawing.Size(38, 31);
            this.checkBox_MonthlyDay13.TabIndex = 59;
            this.checkBox_MonthlyDay13.Text = "13";
            this.checkBox_MonthlyDay13.UseVisualStyleBackColor = false;
            // 
            // checkBox_MonthlyDay11
            // 
            this.checkBox_MonthlyDay11.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_MonthlyDay11.AutoSize = true;
            this.checkBox_MonthlyDay11.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_MonthlyDay11.Location = new System.Drawing.Point(224, 81);
            this.checkBox_MonthlyDay11.Name = "checkBox_MonthlyDay11";
            this.checkBox_MonthlyDay11.Size = new System.Drawing.Size(38, 31);
            this.checkBox_MonthlyDay11.TabIndex = 58;
            this.checkBox_MonthlyDay11.Text = "11";
            this.checkBox_MonthlyDay11.UseVisualStyleBackColor = false;
            // 
            // checkBox_MonthlyDay4
            // 
            this.checkBox_MonthlyDay4.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_MonthlyDay4.AutoSize = true;
            this.checkBox_MonthlyDay4.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_MonthlyDay4.Location = new System.Drawing.Point(224, 46);
            this.checkBox_MonthlyDay4.Name = "checkBox_MonthlyDay4";
            this.checkBox_MonthlyDay4.Size = new System.Drawing.Size(29, 31);
            this.checkBox_MonthlyDay4.TabIndex = 57;
            this.checkBox_MonthlyDay4.Text = "4";
            this.checkBox_MonthlyDay4.UseVisualStyleBackColor = false;
            // 
            // checkBox_MonthlyDay3
            // 
            this.checkBox_MonthlyDay3.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_MonthlyDay3.AutoSize = true;
            this.checkBox_MonthlyDay3.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_MonthlyDay3.Location = new System.Drawing.Point(186, 46);
            this.checkBox_MonthlyDay3.Name = "checkBox_MonthlyDay3";
            this.checkBox_MonthlyDay3.Size = new System.Drawing.Size(29, 31);
            this.checkBox_MonthlyDay3.TabIndex = 56;
            this.checkBox_MonthlyDay3.Text = "3";
            this.checkBox_MonthlyDay3.UseVisualStyleBackColor = false;
            // 
            // checkBox_MonthlyDay27
            // 
            this.checkBox_MonthlyDay27.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_MonthlyDay27.AutoSize = true;
            this.checkBox_MonthlyDay27.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_MonthlyDay27.Location = new System.Drawing.Point(306, 150);
            this.checkBox_MonthlyDay27.Name = "checkBox_MonthlyDay27";
            this.checkBox_MonthlyDay27.Size = new System.Drawing.Size(38, 31);
            this.checkBox_MonthlyDay27.TabIndex = 55;
            this.checkBox_MonthlyDay27.Text = "27";
            this.checkBox_MonthlyDay27.UseVisualStyleBackColor = false;
            // 
            // checkBox_MonthlyDay26
            // 
            this.checkBox_MonthlyDay26.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_MonthlyDay26.AutoSize = true;
            this.checkBox_MonthlyDay26.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_MonthlyDay26.Location = new System.Drawing.Point(268, 150);
            this.checkBox_MonthlyDay26.Name = "checkBox_MonthlyDay26";
            this.checkBox_MonthlyDay26.Size = new System.Drawing.Size(38, 31);
            this.checkBox_MonthlyDay26.TabIndex = 54;
            this.checkBox_MonthlyDay26.Text = "26";
            this.checkBox_MonthlyDay26.UseVisualStyleBackColor = false;
            // 
            // checkBox_MonthlyDay21
            // 
            this.checkBox_MonthlyDay21.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_MonthlyDay21.AutoSize = true;
            this.checkBox_MonthlyDay21.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_MonthlyDay21.Location = new System.Drawing.Point(344, 117);
            this.checkBox_MonthlyDay21.Name = "checkBox_MonthlyDay21";
            this.checkBox_MonthlyDay21.Size = new System.Drawing.Size(38, 31);
            this.checkBox_MonthlyDay21.TabIndex = 53;
            this.checkBox_MonthlyDay21.Text = "21";
            this.checkBox_MonthlyDay21.UseVisualStyleBackColor = false;
            // 
            // checkBox_MonthlyDay7
            // 
            this.checkBox_MonthlyDay7.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_MonthlyDay7.AutoSize = true;
            this.checkBox_MonthlyDay7.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_MonthlyDay7.Location = new System.Drawing.Point(343, 47);
            this.checkBox_MonthlyDay7.Name = "checkBox_MonthlyDay7";
            this.checkBox_MonthlyDay7.Size = new System.Drawing.Size(29, 31);
            this.checkBox_MonthlyDay7.TabIndex = 52;
            this.checkBox_MonthlyDay7.Text = "7";
            this.checkBox_MonthlyDay7.UseVisualStyleBackColor = false;
            // 
            // checkBox_MonthlyDay6
            // 
            this.checkBox_MonthlyDay6.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_MonthlyDay6.AutoSize = true;
            this.checkBox_MonthlyDay6.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_MonthlyDay6.Location = new System.Drawing.Point(303, 47);
            this.checkBox_MonthlyDay6.Name = "checkBox_MonthlyDay6";
            this.checkBox_MonthlyDay6.Size = new System.Drawing.Size(29, 31);
            this.checkBox_MonthlyDay6.TabIndex = 51;
            this.checkBox_MonthlyDay6.Text = "6";
            this.checkBox_MonthlyDay6.UseVisualStyleBackColor = false;
            // 
            // checkBox_MonthlyDay9
            // 
            this.checkBox_MonthlyDay9.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_MonthlyDay9.AutoSize = true;
            this.checkBox_MonthlyDay9.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_MonthlyDay9.Location = new System.Drawing.Point(148, 81);
            this.checkBox_MonthlyDay9.Name = "checkBox_MonthlyDay9";
            this.checkBox_MonthlyDay9.Size = new System.Drawing.Size(29, 31);
            this.checkBox_MonthlyDay9.TabIndex = 50;
            this.checkBox_MonthlyDay9.Text = "9";
            this.checkBox_MonthlyDay9.UseVisualStyleBackColor = false;
            // 
            // checkBox_MonthlyDay20
            // 
            this.checkBox_MonthlyDay20.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_MonthlyDay20.AutoSize = true;
            this.checkBox_MonthlyDay20.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_MonthlyDay20.Location = new System.Drawing.Point(304, 117);
            this.checkBox_MonthlyDay20.Name = "checkBox_MonthlyDay20";
            this.checkBox_MonthlyDay20.Size = new System.Drawing.Size(38, 31);
            this.checkBox_MonthlyDay20.TabIndex = 49;
            this.checkBox_MonthlyDay20.Text = "20";
            this.checkBox_MonthlyDay20.UseVisualStyleBackColor = false;
            // 
            // checkBox_MonthlyDay19
            // 
            this.checkBox_MonthlyDay19.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_MonthlyDay19.AutoSize = true;
            this.checkBox_MonthlyDay19.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_MonthlyDay19.Location = new System.Drawing.Point(268, 117);
            this.checkBox_MonthlyDay19.Name = "checkBox_MonthlyDay19";
            this.checkBox_MonthlyDay19.Size = new System.Drawing.Size(38, 31);
            this.checkBox_MonthlyDay19.TabIndex = 48;
            this.checkBox_MonthlyDay19.Text = "19";
            this.checkBox_MonthlyDay19.UseVisualStyleBackColor = false;
            // 
            // checkBox_MonthlyDay18
            // 
            this.checkBox_MonthlyDay18.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_MonthlyDay18.AutoSize = true;
            this.checkBox_MonthlyDay18.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_MonthlyDay18.Location = new System.Drawing.Point(224, 114);
            this.checkBox_MonthlyDay18.Name = "checkBox_MonthlyDay18";
            this.checkBox_MonthlyDay18.Size = new System.Drawing.Size(38, 31);
            this.checkBox_MonthlyDay18.TabIndex = 47;
            this.checkBox_MonthlyDay18.Text = "18";
            this.checkBox_MonthlyDay18.UseVisualStyleBackColor = false;
            // 
            // checkBox_MonthlyDay24
            // 
            this.checkBox_MonthlyDay24.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_MonthlyDay24.AutoSize = true;
            this.checkBox_MonthlyDay24.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_MonthlyDay24.Location = new System.Drawing.Point(186, 147);
            this.checkBox_MonthlyDay24.Name = "checkBox_MonthlyDay24";
            this.checkBox_MonthlyDay24.Size = new System.Drawing.Size(38, 31);
            this.checkBox_MonthlyDay24.TabIndex = 46;
            this.checkBox_MonthlyDay24.Text = "24";
            this.checkBox_MonthlyDay24.UseVisualStyleBackColor = false;
            // 
            // checkBox_MonthlyDay17
            // 
            this.checkBox_MonthlyDay17.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_MonthlyDay17.AutoSize = true;
            this.checkBox_MonthlyDay17.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_MonthlyDay17.Location = new System.Drawing.Point(186, 114);
            this.checkBox_MonthlyDay17.Name = "checkBox_MonthlyDay17";
            this.checkBox_MonthlyDay17.Size = new System.Drawing.Size(38, 31);
            this.checkBox_MonthlyDay17.TabIndex = 45;
            this.checkBox_MonthlyDay17.Text = "17";
            this.checkBox_MonthlyDay17.UseVisualStyleBackColor = false;
            // 
            // checkBox_MonthlyDay12
            // 
            this.checkBox_MonthlyDay12.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_MonthlyDay12.AutoSize = true;
            this.checkBox_MonthlyDay12.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_MonthlyDay12.Location = new System.Drawing.Point(268, 84);
            this.checkBox_MonthlyDay12.Name = "checkBox_MonthlyDay12";
            this.checkBox_MonthlyDay12.Size = new System.Drawing.Size(38, 31);
            this.checkBox_MonthlyDay12.TabIndex = 44;
            this.checkBox_MonthlyDay12.Text = "12";
            this.checkBox_MonthlyDay12.UseVisualStyleBackColor = false;
            // 
            // checkBox_MonthlyDay10
            // 
            this.checkBox_MonthlyDay10.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_MonthlyDay10.AutoSize = true;
            this.checkBox_MonthlyDay10.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_MonthlyDay10.Location = new System.Drawing.Point(186, 81);
            this.checkBox_MonthlyDay10.Name = "checkBox_MonthlyDay10";
            this.checkBox_MonthlyDay10.Size = new System.Drawing.Size(38, 31);
            this.checkBox_MonthlyDay10.TabIndex = 43;
            this.checkBox_MonthlyDay10.Text = "10";
            this.checkBox_MonthlyDay10.UseVisualStyleBackColor = false;
            // 
            // checkBox_MonthlyDay22
            // 
            this.checkBox_MonthlyDay22.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_MonthlyDay22.AutoSize = true;
            this.checkBox_MonthlyDay22.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_MonthlyDay22.Location = new System.Drawing.Point(110, 147);
            this.checkBox_MonthlyDay22.Name = "checkBox_MonthlyDay22";
            this.checkBox_MonthlyDay22.Size = new System.Drawing.Size(38, 31);
            this.checkBox_MonthlyDay22.TabIndex = 42;
            this.checkBox_MonthlyDay22.Text = "22";
            this.checkBox_MonthlyDay22.UseVisualStyleBackColor = false;
            // 
            // checkBox_MonthlyDay15
            // 
            this.checkBox_MonthlyDay15.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_MonthlyDay15.AutoSize = true;
            this.checkBox_MonthlyDay15.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_MonthlyDay15.Location = new System.Drawing.Point(110, 114);
            this.checkBox_MonthlyDay15.Name = "checkBox_MonthlyDay15";
            this.checkBox_MonthlyDay15.Size = new System.Drawing.Size(38, 31);
            this.checkBox_MonthlyDay15.TabIndex = 41;
            this.checkBox_MonthlyDay15.Text = "15";
            this.checkBox_MonthlyDay15.UseVisualStyleBackColor = false;
            // 
            // checkBox_MonthlyDay8
            // 
            this.checkBox_MonthlyDay8.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_MonthlyDay8.AutoSize = true;
            this.checkBox_MonthlyDay8.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_MonthlyDay8.Location = new System.Drawing.Point(110, 81);
            this.checkBox_MonthlyDay8.Name = "checkBox_MonthlyDay8";
            this.checkBox_MonthlyDay8.Size = new System.Drawing.Size(29, 31);
            this.checkBox_MonthlyDay8.TabIndex = 40;
            this.checkBox_MonthlyDay8.Text = "8";
            this.checkBox_MonthlyDay8.UseVisualStyleBackColor = false;
            // 
            // checkBox_MonthlyDay5
            // 
            this.checkBox_MonthlyDay5.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_MonthlyDay5.AutoSize = true;
            this.checkBox_MonthlyDay5.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_MonthlyDay5.Location = new System.Drawing.Point(267, 47);
            this.checkBox_MonthlyDay5.Name = "checkBox_MonthlyDay5";
            this.checkBox_MonthlyDay5.Size = new System.Drawing.Size(29, 31);
            this.checkBox_MonthlyDay5.TabIndex = 39;
            this.checkBox_MonthlyDay5.Text = "5";
            this.checkBox_MonthlyDay5.UseVisualStyleBackColor = false;
            // 
            // checkBox_MonthlyDay25
            // 
            this.checkBox_MonthlyDay25.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_MonthlyDay25.AutoSize = true;
            this.checkBox_MonthlyDay25.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_MonthlyDay25.Location = new System.Drawing.Point(224, 147);
            this.checkBox_MonthlyDay25.Name = "checkBox_MonthlyDay25";
            this.checkBox_MonthlyDay25.Size = new System.Drawing.Size(38, 31);
            this.checkBox_MonthlyDay25.TabIndex = 38;
            this.checkBox_MonthlyDay25.Text = "25";
            this.checkBox_MonthlyDay25.UseVisualStyleBackColor = false;
            // 
            // checkBox_MonthlyDay23
            // 
            this.checkBox_MonthlyDay23.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_MonthlyDay23.AutoSize = true;
            this.checkBox_MonthlyDay23.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_MonthlyDay23.Location = new System.Drawing.Point(148, 147);
            this.checkBox_MonthlyDay23.Name = "checkBox_MonthlyDay23";
            this.checkBox_MonthlyDay23.Size = new System.Drawing.Size(38, 31);
            this.checkBox_MonthlyDay23.TabIndex = 37;
            this.checkBox_MonthlyDay23.Text = "23";
            this.checkBox_MonthlyDay23.UseVisualStyleBackColor = false;
            // 
            // checkBox_MonthlyDay28
            // 
            this.checkBox_MonthlyDay28.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_MonthlyDay28.AutoSize = true;
            this.checkBox_MonthlyDay28.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_MonthlyDay28.Location = new System.Drawing.Point(344, 150);
            this.checkBox_MonthlyDay28.Name = "checkBox_MonthlyDay28";
            this.checkBox_MonthlyDay28.Size = new System.Drawing.Size(38, 31);
            this.checkBox_MonthlyDay28.TabIndex = 36;
            this.checkBox_MonthlyDay28.Text = "28";
            this.checkBox_MonthlyDay28.UseVisualStyleBackColor = false;
            // 
            // checkBox_MonthlyDay29
            // 
            this.checkBox_MonthlyDay29.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_MonthlyDay29.AutoSize = true;
            this.checkBox_MonthlyDay29.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_MonthlyDay29.Location = new System.Drawing.Point(110, 179);
            this.checkBox_MonthlyDay29.Name = "checkBox_MonthlyDay29";
            this.checkBox_MonthlyDay29.Size = new System.Drawing.Size(38, 31);
            this.checkBox_MonthlyDay29.TabIndex = 35;
            this.checkBox_MonthlyDay29.Text = "29";
            this.checkBox_MonthlyDay29.UseVisualStyleBackColor = false;
            // 
            // checkBox_MonthlyDay30
            // 
            this.checkBox_MonthlyDay30.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_MonthlyDay30.AutoSize = true;
            this.checkBox_MonthlyDay30.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_MonthlyDay30.Location = new System.Drawing.Point(148, 179);
            this.checkBox_MonthlyDay30.Name = "checkBox_MonthlyDay30";
            this.checkBox_MonthlyDay30.Size = new System.Drawing.Size(38, 31);
            this.checkBox_MonthlyDay30.TabIndex = 34;
            this.checkBox_MonthlyDay30.Text = "30";
            this.checkBox_MonthlyDay30.UseVisualStyleBackColor = false;
            // 
            // checkBox_MonthlyDay31
            // 
            this.checkBox_MonthlyDay31.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_MonthlyDay31.AutoSize = true;
            this.checkBox_MonthlyDay31.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_MonthlyDay31.Location = new System.Drawing.Point(186, 179);
            this.checkBox_MonthlyDay31.Name = "checkBox_MonthlyDay31";
            this.checkBox_MonthlyDay31.Size = new System.Drawing.Size(38, 31);
            this.checkBox_MonthlyDay31.TabIndex = 33;
            this.checkBox_MonthlyDay31.Text = "31";
            this.checkBox_MonthlyDay31.UseVisualStyleBackColor = false;
            // 
            // checkBox_MonthlyDay16
            // 
            this.checkBox_MonthlyDay16.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_MonthlyDay16.AutoSize = true;
            this.checkBox_MonthlyDay16.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_MonthlyDay16.Location = new System.Drawing.Point(148, 114);
            this.checkBox_MonthlyDay16.Name = "checkBox_MonthlyDay16";
            this.checkBox_MonthlyDay16.Size = new System.Drawing.Size(38, 31);
            this.checkBox_MonthlyDay16.TabIndex = 32;
            this.checkBox_MonthlyDay16.Text = "16";
            this.checkBox_MonthlyDay16.UseVisualStyleBackColor = false;
            // 
            // checkBox_MonthlyDay2
            // 
            this.checkBox_MonthlyDay2.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_MonthlyDay2.AutoSize = true;
            this.checkBox_MonthlyDay2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_MonthlyDay2.Location = new System.Drawing.Point(148, 46);
            this.checkBox_MonthlyDay2.Name = "checkBox_MonthlyDay2";
            this.checkBox_MonthlyDay2.Size = new System.Drawing.Size(29, 31);
            this.checkBox_MonthlyDay2.TabIndex = 31;
            this.checkBox_MonthlyDay2.Text = "2";
            this.checkBox_MonthlyDay2.UseVisualStyleBackColor = false;
            // 
            // checkBox_MonthlyDay1
            // 
            this.checkBox_MonthlyDay1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_MonthlyDay1.AutoSize = true;
            this.checkBox_MonthlyDay1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.checkBox_MonthlyDay1.Location = new System.Drawing.Point(110, 46);
            this.checkBox_MonthlyDay1.Name = "checkBox_MonthlyDay1";
            this.checkBox_MonthlyDay1.Size = new System.Drawing.Size(29, 31);
            this.checkBox_MonthlyDay1.TabIndex = 30;
            this.checkBox_MonthlyDay1.Text = "1";
            this.checkBox_MonthlyDay1.UseVisualStyleBackColor = false;
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
            // panel_MonthlyDay
            // 
            this.panel_MonthlyDay.Controls.Add(this.comboBox1);
            this.panel_MonthlyDay.Controls.Add(this.comboBox2);
            this.panel_MonthlyDay.Controls.Add(this.comboBox3);
            this.panel_MonthlyDay.Controls.Add(this.button1);
            this.panel_MonthlyDay.Controls.Add(this.button2);
            this.panel_MonthlyDay.Controls.Add(this.dateTimePicker1);
            this.panel_MonthlyDay.Controls.Add(this.dateTimePicker2);
            this.panel_MonthlyDay.Controls.Add(this.dateTimePicker3);
            this.panel_MonthlyDay.Location = new System.Drawing.Point(0, 92);
            this.panel_MonthlyDay.Name = "panel_MonthlyDay";
            this.panel_MonthlyDay.Size = new System.Drawing.Size(160, 224);
            this.panel_MonthlyDay.TabIndex = 63;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Full backup",
            "Incremental backup ",
            "Differential backup"});
            this.comboBox1.Location = new System.Drawing.Point(29, 187);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(85, 29);
            this.comboBox1.TabIndex = 32;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Full backup",
            "Incremental backup ",
            "Differential backup"});
            this.comboBox2.Location = new System.Drawing.Point(29, 116);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(85, 29);
            this.comboBox2.TabIndex = 31;
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Full backup",
            "Incremental backup ",
            "Differential backup"});
            this.comboBox3.Location = new System.Drawing.Point(29, 43);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(85, 29);
            this.comboBox3.TabIndex = 30;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(120, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 29);
            this.button1.TabIndex = 29;
            this.button1.Text = "-";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(120, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 29);
            this.button2.TabIndex = 28;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(29, 90);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(85, 29);
            this.dateTimePicker1.TabIndex = 27;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Enabled = false;
            this.dateTimePicker2.Location = new System.Drawing.Point(29, 17);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(85, 29);
            this.dateTimePicker2.TabIndex = 21;
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Enabled = false;
            this.dateTimePicker3.Location = new System.Drawing.Point(29, 160);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(85, 29);
            this.dateTimePicker3.TabIndex = 26;
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
            this.tabPage_Weekly.ResumeLayout(false);
            this.tabPage_Weekly.PerformLayout();
            this.panel_WeeklyDay.ResumeLayout(false);
            this.tabPage_Monthly.ResumeLayout(false);
            this.tabPage_Monthly.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel_MonthlyDay.ResumeLayout(false);
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
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dateTimePicker_DailyTime1;
        private System.Windows.Forms.Button button_DailyAddTime2;
        private System.Windows.Forms.Button button_DailyRemoveTime2;
        private System.Windows.Forms.DateTimePicker dateTimePicker_DailyTime4;
        private System.Windows.Forms.DateTimePicker dateTimePicker_DailyTime3;
        private System.Windows.Forms.DateTimePicker dateTimePicker_DailyTime2;
        private System.Windows.Forms.DateTimePicker dateTimePicker_DailyTime5;
        private System.Windows.Forms.Button button_DailyRemoveTime5;
        private System.Windows.Forms.Button button_DailyRemoveTime4;
        private System.Windows.Forms.Button button_DailyRemoveTime3;
        private System.Windows.Forms.Button button_DailyAddTime5;
        private System.Windows.Forms.Button button_DailyAddTime4;
        private System.Windows.Forms.Button button_DailyAddTime3;
        private System.Windows.Forms.TextBox textBox_DailyKeepingBackups;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox comboBox_DailyMethod1;
        private System.Windows.Forms.ComboBox comboBox_DailyMethod5;
        private System.Windows.Forms.ComboBox comboBox_DailyMethod4;
        private System.Windows.Forms.ComboBox comboBox_DailyMethod3;
        private System.Windows.Forms.ComboBox comboBox_DailyMethod2;
        private System.Windows.Forms.CheckBox checkBox_Tue;
        private System.Windows.Forms.DateTimePicker dateTimePicker_WeeklyTime3;
        private System.Windows.Forms.CheckBox checkBox_Sun;
        private System.Windows.Forms.CheckBox checkBox_Sat;
        private System.Windows.Forms.CheckBox checkBox_Fri;
        private System.Windows.Forms.CheckBox checkBox_Thu;
        private System.Windows.Forms.CheckBox checkBox_Wed;
        private System.Windows.Forms.CheckBox checkBox_Mon;
        private System.Windows.Forms.CheckBox checkBox_MonthlyDay14;
        private System.Windows.Forms.CheckBox checkBox_MonthlyDay13;
        private System.Windows.Forms.CheckBox checkBox_MonthlyDay11;
        private System.Windows.Forms.CheckBox checkBox_MonthlyDay4;
        private System.Windows.Forms.CheckBox checkBox_MonthlyDay3;
        private System.Windows.Forms.CheckBox checkBox_MonthlyDay27;
        private System.Windows.Forms.CheckBox checkBox_MonthlyDay26;
        private System.Windows.Forms.CheckBox checkBox_MonthlyDay21;
        private System.Windows.Forms.CheckBox checkBox_MonthlyDay7;
        private System.Windows.Forms.CheckBox checkBox_MonthlyDay6;
        private System.Windows.Forms.CheckBox checkBox_MonthlyDay9;
        private System.Windows.Forms.CheckBox checkBox_MonthlyDay20;
        private System.Windows.Forms.CheckBox checkBox_MonthlyDay19;
        private System.Windows.Forms.CheckBox checkBox_MonthlyDay18;
        private System.Windows.Forms.CheckBox checkBox_MonthlyDay24;
        private System.Windows.Forms.CheckBox checkBox_MonthlyDay17;
        private System.Windows.Forms.CheckBox checkBox_MonthlyDay12;
        private System.Windows.Forms.CheckBox checkBox_MonthlyDay10;
        private System.Windows.Forms.CheckBox checkBox_MonthlyDay22;
        private System.Windows.Forms.CheckBox checkBox_MonthlyDay15;
        private System.Windows.Forms.CheckBox checkBox_MonthlyDay8;
        private System.Windows.Forms.CheckBox checkBox_MonthlyDay5;
        private System.Windows.Forms.CheckBox checkBox_MonthlyDay25;
        private System.Windows.Forms.CheckBox checkBox_MonthlyDay23;
        private System.Windows.Forms.CheckBox checkBox_MonthlyDay28;
        private System.Windows.Forms.CheckBox checkBox_MonthlyDay29;
        private System.Windows.Forms.CheckBox checkBox_MonthlyDay30;
        private System.Windows.Forms.CheckBox checkBox_MonthlyDay31;
        private System.Windows.Forms.CheckBox checkBox_MonthlyDay16;
        private System.Windows.Forms.CheckBox checkBox_MonthlyDay2;
        private System.Windows.Forms.CheckBox checkBox_MonthlyDay1;
        private System.Windows.Forms.TextBox textBox_WeeklyKeepingBackups;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBox_MonthlyKeepingBackups;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Panel panel_WeeklyDay;
        private System.Windows.Forms.Button button_WeeklyAddTime;
        private System.Windows.Forms.DateTimePicker dateTimePicker_WeeklyTime2;
        private System.Windows.Forms.DateTimePicker dateTimePicker_WeeklyTime1;
        private System.Windows.Forms.Button button_WeeklyRemoveTime;
        private System.Windows.Forms.ComboBox comboBox_WeeklyDay3;
        private System.Windows.Forms.ComboBox comboBox_WeeklyDay2;
        private System.Windows.Forms.ComboBox comboBox_WeeklyDay1;
        private System.Windows.Forms.Panel panel_MonthlyDay;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
    }
}