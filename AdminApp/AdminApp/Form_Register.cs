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
        private ServerAccess sa;
        public Form_Register(ServerAccess serverAccess)
        {
            InitializeComponent();
            sa = serverAccess;
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
            if (this.IsValid())
            {
                try
                {
                AdminPost ap = new AdminPost();
                ap.Name = textBox_username.Text;
                ap.Password = textBox_password.Text;

                Response r = new Response();
                r = await sa.GetAllAdmins(this.label_registererror);

                ListAdminData l = new ListAdminData();
                l = (ListAdminData)r.Data;

                Response rType = new Response();
                rType = await sa.GetAdminType(this.label_registererror);

                bool valid = true;
                for (int i = 0; i < l.ListAdmin.Count; i++)
                {
                    if (l.ListAdmin[i].Name == ap.Name)
                        valid = false;
                }
                if (valid == true && ((AdminPost)rType.Data).Type == "master")
                {
                    await sa.PostNewAdmin(ap, this.label_registererror);
                    this.Close();
                }
                else
                {
                    this.label_registererror.Visible = true;
                    this.label_registererror.Text = "Choose a different name";
                }
                }
                catch(Exception ex)
                {

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

        private void button_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
