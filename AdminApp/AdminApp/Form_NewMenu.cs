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

            ListEmailSettingsData lesd = new ListEmailSettingsData();   // testovací
            lesd.ListEmailSettings = new List<EmailSettings>();

            lesd.ListEmailSettings.Add(new EmailSettings());
            lesd.ListEmailSettings[0].AdminId = 1;
            lesd.ListEmailSettings[0].EmailAddress = this.textBox_To.Text;
            lesd.ListEmailSettings[0].SslTls = this.checkBox1.Checked;
            lesd.ListEmailSettings[0].Port = Convert.ToInt32(this.textBox_SMTPPort.Text);
            await this.serverAccess.PostEmailSettings(lesd.ListEmailSettings[0], this.label_error);
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
