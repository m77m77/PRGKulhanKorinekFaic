namespace AdminApp
{
    partial class Form_Register
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.textBox_confirmpassword = new System.Windows.Forms.TextBox();
            this.errorProvider_register = new System.Windows.Forms.ErrorProvider(this.components);
            this.button_register = new System.Windows.Forms.Button();
            this.label_registererror = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_register)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.label2.Location = new System.Drawing.Point(185, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 25);
            this.label2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.label3.Location = new System.Drawing.Point(12, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Confirm password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.label4.Location = new System.Drawing.Point(12, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Password:";
            // 
            // textBox_username
            // 
            this.textBox_username.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.textBox_username.Location = new System.Drawing.Point(190, 42);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(150, 33);
            this.textBox_username.TabIndex = 4;
            // 
            // textBox_password
            // 
            this.textBox_password.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.textBox_password.Location = new System.Drawing.Point(190, 120);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(150, 33);
            this.textBox_password.TabIndex = 5;
            // 
            // textBox_confirmpassword
            // 
            this.textBox_confirmpassword.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.textBox_confirmpassword.Location = new System.Drawing.Point(190, 176);
            this.textBox_confirmpassword.Name = "textBox_confirmpassword";
            this.textBox_confirmpassword.Size = new System.Drawing.Size(150, 33);
            this.textBox_confirmpassword.TabIndex = 6;
            // 
            // errorProvider_register
            // 
            this.errorProvider_register.ContainerControl = this;
            // 
            // button_register
            // 
            this.button_register.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.button_register.Location = new System.Drawing.Point(96, 255);
            this.button_register.Name = "button_register";
            this.button_register.Size = new System.Drawing.Size(207, 48);
            this.button_register.TabIndex = 7;
            this.button_register.Text = "Register";
            this.button_register.UseVisualStyleBackColor = true;
            this.button_register.Click += new System.EventHandler(this.button_register_Click);
            // 
            // label_registererror
            // 
            this.label_registererror.AutoSize = true;
            this.label_registererror.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.label_registererror.Location = new System.Drawing.Point(174, 340);
            this.label_registererror.Name = "label_registererror";
            this.label_registererror.Size = new System.Drawing.Size(0, 25);
            this.label_registererror.TabIndex = 8;
            // 
            // Form_Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 374);
            this.Controls.Add(this.label_registererror);
            this.Controls.Add(this.button_register);
            this.Controls.Add(this.textBox_confirmpassword);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.textBox_username);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form_Register";
            this.Text = "Form_Register";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_register)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.TextBox textBox_confirmpassword;
        private System.Windows.Forms.ErrorProvider errorProvider_register;
        private System.Windows.Forms.Button button_register;
        private System.Windows.Forms.Label label_registererror;
    }
}