namespace AdminApp
{
    partial class Form_Login
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button_Login = new System.Windows.Forms.Button();
            this.label_Username = new System.Windows.Forms.Label();
            this.label_Password = new System.Windows.Forms.Label();
            this.textBox_Username = new System.Windows.Forms.TextBox();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.textBox_serverAdress = new System.Windows.Forms.TextBox();
            this.label_server = new System.Windows.Forms.Label();
            this.label_error = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Login
            // 
            this.button_Login.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_Login.Location = new System.Drawing.Point(96, 208);
            this.button_Login.Name = "button_Login";
            this.button_Login.Size = new System.Drawing.Size(211, 41);
            this.button_Login.TabIndex = 0;
            this.button_Login.Text = "Log in";
            this.button_Login.UseVisualStyleBackColor = true;
            this.button_Login.Click += new System.EventHandler(this.button_Login_Click);
            // 
            // label_Username
            // 
            this.label_Username.AutoSize = true;
            this.label_Username.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_Username.Location = new System.Drawing.Point(91, 60);
            this.label_Username.Name = "label_Username";
            this.label_Username.Size = new System.Drawing.Size(97, 25);
            this.label_Username.TabIndex = 1;
            this.label_Username.Text = "Username";
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Password.Location = new System.Drawing.Point(91, 133);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(92, 25);
            this.label_Password.TabIndex = 2;
            this.label_Password.Text = "Password";
            // 
            // textBox_Username
            // 
            this.textBox_Username.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_Username.Location = new System.Drawing.Point(96, 88);
            this.textBox_Username.Multiline = true;
            this.textBox_Username.Name = "textBox_Username";
            this.textBox_Username.Size = new System.Drawing.Size(211, 42);
            this.textBox_Username.TabIndex = 3;
            // 
            // textBox_Password
            // 
            this.textBox_Password.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_Password.Location = new System.Drawing.Point(96, 161);
            this.textBox_Password.Multiline = true;
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.Size = new System.Drawing.Size(211, 41);
            this.textBox_Password.TabIndex = 4;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkRate = 100;
            this.errorProvider1.ContainerControl = this;
            // 
            // textBox_serverAdress
            // 
            this.textBox_serverAdress.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.textBox_serverAdress.Location = new System.Drawing.Point(96, 23);
            this.textBox_serverAdress.Name = "textBox_serverAdress";
            this.textBox_serverAdress.Size = new System.Drawing.Size(211, 33);
            this.textBox_serverAdress.TabIndex = 5;
            // 
            // label_server
            // 
            this.label_server.AutoSize = true;
            this.label_server.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.label_server.Location = new System.Drawing.Point(91, -5);
            this.label_server.Name = "label_server";
            this.label_server.Size = new System.Drawing.Size(65, 25);
            this.label_server.TabIndex = 6;
            this.label_server.Text = "Server";
            // 
            // label_error
            // 
            this.label_error.BackColor = System.Drawing.Color.Red;
            this.label_error.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.label_error.ForeColor = System.Drawing.Color.Black;
            this.label_error.Location = new System.Drawing.Point(12, 277);
            this.label_error.Name = "label_error";
            this.label_error.Size = new System.Drawing.Size(381, 29);
            this.label_error.TabIndex = 7;
            this.label_error.Text = "error";
            this.label_error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(405, 315);
            this.Controls.Add(this.label_error);
            this.Controls.Add(this.label_server);
            this.Controls.Add(this.textBox_serverAdress);
            this.Controls.Add(this.textBox_Password);
            this.Controls.Add(this.textBox_Username);
            this.Controls.Add(this.label_Password);
            this.Controls.Add(this.label_Username);
            this.Controls.Add(this.button_Login);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form_Login";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Login;
        private System.Windows.Forms.Label label_Username;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.TextBox textBox_Username;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox textBox_serverAdress;
        private System.Windows.Forms.Label label_server;
        private System.Windows.Forms.Label label_error;
    }
}

