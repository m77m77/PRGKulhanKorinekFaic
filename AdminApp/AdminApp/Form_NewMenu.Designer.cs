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
            this.label8 = new System.Windows.Forms.Label();
            this.checkedListBox_fromdaemonsmonthly = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.checkedListBox_fromdaemonsweekly = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox_template = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkedListBox_fromdaemonsdaily = new System.Windows.Forms.CheckedListBox();
            this.checkBox_sendemails = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_To = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage_Administration = new System.Windows.Forms.TabPage();
            this.tabControl_Daemon = new System.Windows.Forms.TabControl();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label_error = new System.Windows.Forms.Label();
            this.button_register = new System.Windows.Forms.Button();
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
            this.tabPage_EmailNotification.Controls.Add(this.label8);
            this.tabPage_EmailNotification.Controls.Add(this.checkedListBox_fromdaemonsmonthly);
            this.tabPage_EmailNotification.Controls.Add(this.label7);
            this.tabPage_EmailNotification.Controls.Add(this.checkedListBox_fromdaemonsweekly);
            this.tabPage_EmailNotification.Controls.Add(this.label5);
            this.tabPage_EmailNotification.Controls.Add(this.listBox_template);
            this.tabPage_EmailNotification.Controls.Add(this.label4);
            this.tabPage_EmailNotification.Controls.Add(this.label2);
            this.tabPage_EmailNotification.Controls.Add(this.checkedListBox_fromdaemonsdaily);
            this.tabPage_EmailNotification.Controls.Add(this.checkBox_sendemails);
            this.tabPage_EmailNotification.Controls.Add(this.label3);
            this.tabPage_EmailNotification.Controls.Add(this.textBox_To);
            this.tabPage_EmailNotification.Controls.Add(this.label6);
            this.tabPage_EmailNotification.Location = new System.Drawing.Point(4, 30);
            this.tabPage_EmailNotification.Name = "tabPage_EmailNotification";
            this.tabPage_EmailNotification.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_EmailNotification.Size = new System.Drawing.Size(759, 449);
            this.tabPage_EmailNotification.TabIndex = 0;
            this.tabPage_EmailNotification.Text = "Email notification settings";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 364);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 21);
            this.label8.TabIndex = 50;
            this.label8.Text = "Monthly";
            // 
            // checkedListBox_fromdaemonsmonthly
            // 
            this.checkedListBox_fromdaemonsmonthly.FormattingEnabled = true;
            this.checkedListBox_fromdaemonsmonthly.Location = new System.Drawing.Point(149, 364);
            this.checkedListBox_fromdaemonsmonthly.Name = "checkedListBox_fromdaemonsmonthly";
            this.checkedListBox_fromdaemonsmonthly.Size = new System.Drawing.Size(120, 76);
            this.checkedListBox_fromdaemonsmonthly.TabIndex = 49;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 282);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 21);
            this.label7.TabIndex = 48;
            this.label7.Text = "Weekly";
            // 
            // checkedListBox_fromdaemonsweekly
            // 
            this.checkedListBox_fromdaemonsweekly.FormattingEnabled = true;
            this.checkedListBox_fromdaemonsweekly.Location = new System.Drawing.Point(150, 282);
            this.checkedListBox_fromdaemonsweekly.Name = "checkedListBox_fromdaemonsweekly";
            this.checkedListBox_fromdaemonsweekly.Size = new System.Drawing.Size(120, 76);
            this.checkedListBox_fromdaemonsweekly.TabIndex = 47;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(436, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 21);
            this.label5.TabIndex = 46;
            this.label5.Text = "Template";
            // 
            // listBox_template
            // 
            this.listBox_template.FormattingEnabled = true;
            this.listBox_template.ItemHeight = 21;
            this.listBox_template.Items.AddRange(new object[] {
            "1",
            "2"});
            this.listBox_template.Location = new System.Drawing.Point(541, 256);
            this.listBox_template.Name = "listBox_template";
            this.listBox_template.Size = new System.Drawing.Size(120, 88);
            this.listBox_template.TabIndex = 45;
            this.listBox_template.SelectedIndexChanged += new System.EventHandler(this.listBox_template_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 21);
            this.label4.TabIndex = 43;
            this.label4.Text = "Send emails";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 21);
            this.label2.TabIndex = 42;
            this.label2.Text = "Daily";
            // 
            // checkedListBox_fromdaemonsdaily
            // 
            this.checkedListBox_fromdaemonsdaily.FormattingEnabled = true;
            this.checkedListBox_fromdaemonsdaily.Location = new System.Drawing.Point(149, 200);
            this.checkedListBox_fromdaemonsdaily.Name = "checkedListBox_fromdaemonsdaily";
            this.checkedListBox_fromdaemonsdaily.Size = new System.Drawing.Size(120, 76);
            this.checkedListBox_fromdaemonsdaily.TabIndex = 41;
            // 
            // checkBox_sendemails
            // 
            this.checkBox_sendemails.AutoSize = true;
            this.checkBox_sendemails.Location = new System.Drawing.Point(137, 48);
            this.checkBox_sendemails.Name = "checkBox_sendemails";
            this.checkBox_sendemails.Size = new System.Drawing.Size(15, 14);
            this.checkBox_sendemails.TabIndex = 38;
            this.checkBox_sendemails.UseVisualStyleBackColor = true;
            this.checkBox_sendemails.CheckedChanged += new System.EventHandler(this.checkBox_sendemails_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(27, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 21);
            this.label3.TabIndex = 25;
            this.label3.Text = "To";
            // 
            // textBox_To
            // 
            this.textBox_To.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_To.Location = new System.Drawing.Point(104, 134);
            this.textBox_To.Multiline = true;
            this.textBox_To.Name = "textBox_To";
            this.textBox_To.Size = new System.Drawing.Size(519, 25);
            this.textBox_To.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(27, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 21);
            this.label6.TabIndex = 36;
            this.label6.Text = "SMTP settings";
            // 
            // tabPage_Administration
            // 
            this.tabPage_Administration.Controls.Add(this.tabControl_Daemon);
            this.tabPage_Administration.Location = new System.Drawing.Point(4, 30);
            this.tabPage_Administration.Name = "tabPage_Administration";
            this.tabPage_Administration.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Administration.Size = new System.Drawing.Size(759, 449);
            this.tabPage_Administration.TabIndex = 1;
            this.tabPage_Administration.Text = "Daemons settings";
            this.tabPage_Administration.UseVisualStyleBackColor = true;
            // 
            // tabControl_Daemon
            // 
            this.tabControl_Daemon.Location = new System.Drawing.Point(0, 0);
            this.tabControl_Daemon.Name = "tabControl_Daemon";
            this.tabControl_Daemon.SelectedIndex = 0;
            this.tabControl_Daemon.Size = new System.Drawing.Size(759, 449);
            this.tabControl_Daemon.TabIndex = 0;
            // 
            // button_Cancel
            // 
            this.button_Cancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_Cancel.Location = new System.Drawing.Point(642, 489);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(111, 45);
            this.button_Cancel.TabIndex = 1;
            this.button_Cancel.Text = "Exit";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_Save
            // 
            this.button_Save.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_Save.Location = new System.Drawing.Point(525, 489);
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
            // label_error
            // 
            this.label_error.BackColor = System.Drawing.Color.Red;
            this.label_error.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.label_error.ForeColor = System.Drawing.Color.Black;
            this.label_error.Location = new System.Drawing.Point(12, 496);
            this.label_error.Name = "label_error";
            this.label_error.Size = new System.Drawing.Size(493, 29);
            this.label_error.TabIndex = 8;
            this.label_error.Text = "error";
            this.label_error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_error.Visible = false;
            // 
            // button_register
            // 
            this.button_register.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.button_register.Location = new System.Drawing.Point(440, 489);
            this.button_register.Name = "button_register";
            this.button_register.Size = new System.Drawing.Size(79, 45);
            this.button_register.TabIndex = 1;
            this.button_register.Text = "Register";
            this.button_register.UseVisualStyleBackColor = true;
            this.button_register.Click += new System.EventHandler(this.button_register_Click);
            // 
            // Form_NewMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 546);
            this.Controls.Add(this.button_register);
            this.Controls.Add(this.label_error);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_To;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TabControl tabControl_Daemon;
        private System.Windows.Forms.Label label_error;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox checkedListBox_fromdaemonsdaily;
        private System.Windows.Forms.CheckBox checkBox_sendemails;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox_template;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckedListBox checkedListBox_fromdaemonsmonthly;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckedListBox checkedListBox_fromdaemonsweekly;
        private System.Windows.Forms.Button button_register;
    }
}