using AdminApp.CommunicationClasses;
using AdminApp.LoginNewToken;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminApp
{
    public partial class Form_Register : Form
    {
        public Form_Register()
        {
            InitializeComponent();
            label_registererror.Visible = false;
            textBox_password.PasswordChar = '•';
            textBox_confirmpassword.PasswordChar = '•';
        }

        private bool IsValid()
        {
            bool valid = true;
            this.errorProvider_register.Clear();

            if (string.IsNullOrWhiteSpace(this.textBox_username.Text))
            {
                this.errorProvider_register.SetError(this.textBox_username, "Cannot be empty");
                valid = false;
            }
            else if (string.IsNullOrWhiteSpace(this.textBox_password.Text))
            {
                this.errorProvider_register.SetError(this.textBox_password, "Cannot be empty");
                valid = false;
            }
            else if (string.IsNullOrWhiteSpace(this.textBox_confirmpassword.Text))
            {
                this.errorProvider_register.SetError(this.textBox_confirmpassword, "Cannot be empty");
                valid = false;
            }
            else if (this.textBox_password.Text != this.textBox_confirmpassword.Text)
            {
                this.errorProvider_register.SetError(this.textBox_confirmpassword, "Password does not match the confirm password.");
                valid = false;
            }
            
            return valid;

        }

        private async void button_register_Click(object sender, EventArgs e)
        {
            ServerAccess na = new ServerAccess();

            if (this.IsValid())
            {
                AdminPost ap = new AdminPost();
                ap.Name = textBox_username.Text;
                ap.Password = textBox_password.Text;

                ListAdminData list = new ListAdminData();
                list.ListAdmin = new List<AdminPost>();
                Response r = new Response();
                //r = await na.GetAllAdmins(this.label_registererror);
                //list.ListAdmin.Add((AdminPost)r.Data);
                //list.Add((AdminPost)r.Data);
                
                //if(list.ListAdmin[0].Name != ap.Name)
                await na.PostNewAdmin(ap, this.label_registererror);

                if(this.label_registererror.Text == "")
                {
                    this.Close();
                }
            }
        }

        private void checkBox_show_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_show.Checked == true)
            {
                textBox_password.PasswordChar = '\0';
                textBox_confirmpassword.PasswordChar = '\0';
            }
            else
            {
                textBox_password.PasswordChar = '•';
                textBox_confirmpassword.PasswordChar = '•';
            }
            
        }
    }
}
