using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminApp.CommunicationClasses;

namespace AdminApp
{
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
            textBox_Password.PasswordChar = '•';
        }

        private Response button_Login_Click(object sender, EventArgs e)
        {
            Response r = new Response();

            if (this.IsValid())
            {
                
                HttpClient http = new HttpClient();
                http.PostAsync("api/newtoken/admin", r.NewToken());
                this.Hide();
                Form_Menu frm = new Form_Menu();
                if (frm.ShowDialog() == DialogResult.OK) { }
                return r;
            }
            return r;
          


        }

        private bool IsValid()
        {
            bool valid  = true;
            this.errorProvider1.Clear();


            if(string.IsNullOrWhiteSpace(this.textBox_Username.Text))
            {
                this.errorProvider1.SetError(this.textBox_Username, "Cannot be empty");
                valid = false;
            }
            else if (string.IsNullOrWhiteSpace(this.textBox_Password.Text))
            {
                this.errorProvider1.SetError(this.textBox_Password, "Cannot be empty");
                valid = false;
            }
            return valid;

        }
    }
}
