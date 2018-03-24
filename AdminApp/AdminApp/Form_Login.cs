﻿using System;
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
using AdminApp.LoginNewToken;

namespace AdminApp
{
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
            label_error.Visible = false;
            textBox_Password.PasswordChar = '•';

        }

        private async void button_Login_Click(object sender, EventArgs e)
        {
            ServerAccess gt = new ServerAccess();

            if (this.IsValid())
            {
                bool res;
                AdminPost ap = new AdminPost();
                ap.Name = textBox_Username.Text;
                ap.Password = textBox_Password.Text;

                //DEBUG
                res = await gt.GetTokenMethod(ap,label_error,textBox_serverAdress);
                //res = true;

                if(res == true)
                {
                    
                    Form_NewMenu frm = new Form_NewMenu(gt);
                    bool dRes = await frm.GetAllSettings(label_error);

                    if (dRes)
                    {
                        this.Hide();
                        if (frm.ShowDialog() == DialogResult.OK) { }
                        this.Close();
                    }
                }
                
            }
          
        }

        private bool IsValid()
        {
            bool valid  = true;
            this.errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(this.textBox_serverAdress.Text))
            {
                this.errorProvider1.SetError(this.textBox_serverAdress, "Cannot be empty");
                valid = false;
            }
            else if (string.IsNullOrWhiteSpace(this.textBox_Username.Text))
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
