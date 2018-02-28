using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AdminApp.LoginNewToken;
using AdminApp.Components;
using AdminApp.Models.Settings;
using Newtonsoft.Json;
using AdminApp.CommunicationClasses;
using AdminApp.Models.EmailSettings;

namespace AdminApp
{
    public partial class Form_NewMenu : Form
    {
        private ServerAccess serverAccess;
        private AllDaemonSettings allDaemonSettings;

        public Form_NewMenu(ServerAccess gettoken)
        {
            InitializeComponent();
            this.serverAccess = gettoken;
            this.allDaemonSettings = new AllDaemonSettings();
            GetEmailSettings();

        }

        public CheckedListBox GetEmailDaemonsListBox()
        {
            return this.checkedListBox_fromdaemons;
        }
        public async Task<bool> GetAllSettings(Label label)
        {
            Response response = await this.serverAccess.GetAllSettings(label);
            

            if (response.Status == "OK")
            {
                allDaemonSettings.CreateDaemons((ListSettingsData)response.Data, this.tabControl_Daemon, this);
                return true;
            }

            return false;
        }

        public async void GetEmailSettings()
        {

            Response response = await serverAccess.OneGetEmailSettings(label1);

            if (response.Status == "OK")
            {
                addParams((EmailSettings)response.Data);
            }

        }
        public void addParams(EmailSettings data)
        {
            this.textBox_To.Text = data.EmailAddress; //dodělat
            this.checkBox_sendemails.Checked = data.SendEmails;
            //this.checkedListBox_fromdaemons.Text = data.FromDaemons;
            this.comboBox_howoften.SelectedItem = data.HowOften;
        }

        private bool IsValid()
        {
            bool valid = true;
            this.errorProvider1.Clear();


            if (Regex.IsMatch(this.textBox_To.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                this.errorProvider1.SetError(this.textBox_To, "Type in correct email - xxx@xxx.xx");
                valid = false;
            }

            return valid;

        }

        private bool IsNumber(string str)
        {
            try
            {
                Convert.ToInt32(str);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private async void button_Save_Click(object sender, EventArgs e)
        {
            this.label_error.Visible = false;
            this.allDaemonSettings.SaveSettings(this.serverAccess,this.label_error,this.errorProvider1);

            ListEmailSettingsData lesd = new ListEmailSettingsData();
            lesd.ListEmailSettings = new List<EmailSettings>();
            
            try
            {
                lesd.ListEmailSettings.Add(new EmailSettings());
                lesd.ListEmailSettings[0].FromDaemons = new List<int>();
                lesd.ListEmailSettings[0].EmailAddress = this.textBox_To.Text;
                lesd.ListEmailSettings[0].SendEmails = this.checkBox_sendemails.Checked;
                lesd.ListEmailSettings[0].Template = "ahooooj";
                foreach(string item in checkedListBox_fromdaemons.CheckedItems)
                {
                    lesd.ListEmailSettings[0].FromDaemons.Add(allDaemonSettings.NameToIdDaemons[item]);
                }
                lesd.ListEmailSettings[0].HowOften = this.comboBox_howoften.Text;
                //if (listBox_template.Text == "1")
                //    lesd.ListEmailSettings[0].Template = "ahoj";
                await this.serverAccess.PostEmailSettings(lesd.ListEmailSettings[0], this.label_error);
            }
            catch (Exception ex)
            {

            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void checkBox_sendemails_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox_sendemails.Checked == false)
            {
                this.checkedListBox_fromdaemons.Enabled = false;
                this.comboBox_howoften.Enabled = false;
                this.textBox_To.Enabled = false;
            }
            else
            {
                this.checkedListBox_fromdaemons.Enabled = true;
                this.comboBox_howoften.Enabled = true;
                this.textBox_To.Enabled = true;
            }
        }

        private void listBox_template_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
