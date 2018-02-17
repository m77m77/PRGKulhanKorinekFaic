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
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl_Daemon = new System.Windows.Forms.TabControl();
            this.tabControl_DefaultMenu.SuspendLayout();
            this.tabPage_EmailNotification.SuspendLayout();
            this.tabPage_Administration.SuspendLayout();
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
            this.tabControl_DefaultMenu.Size = new System.Drawing.Size(767, 483);
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
            this.tabPage_EmailNotification.Size = new System.Drawing.Size(759, 449);
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
            this.textBox_SMTPPassword.PasswordChar = '•';
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
            this.tabPage_Administration.Size = new System.Drawing.Size(759, 449);
            this.tabPage_Administration.TabIndex = 1;
            this.tabPage_Administration.Text = "Administration";
            this.tabPage_Administration.UseVisualStyleBackColor = true;
            // 
            // button_Cancel
            // 
            this.button_Cancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_Cancel.Location = new System.Drawing.Point(628, 489);
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
            this.button_Save.Location = new System.Drawing.Point(511, 489);
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
            // tabControl_Daemon
            // 
            this.tabControl_Daemon.Location = new System.Drawing.Point(0, 0);
            this.tabControl_Daemon.Name = "tabControl_Daemon";
            this.tabControl_Daemon.SelectedIndex = 0;
            this.tabControl_Daemon.Size = new System.Drawing.Size(759, 449);
            this.tabControl_Daemon.TabIndex = 0;
            // 
            // Form_NewMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 546);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.tabControl_DefaultMenu);
            this.Name = "Form_NewMenu";
            this.Text = "Form_NewMenu";
            this.tabControl_DefaultMenu.ResumeLayout(false);
            this.tabPage_EmailNotification.ResumeLayout(false);
            this.tabPage_EmailNotification.PerformLayout();
            this.tabPage_Administration.ResumeLayout(false);
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
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TabControl tabControl_Daemon;
    }
}