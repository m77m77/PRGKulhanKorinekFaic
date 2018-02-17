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

namespace AdminApp
{
    public partial class Form_NewMenu : Form
    {
 

        public Form_NewMenu(ServerAccess gettoken)
        {
            InitializeComponent();
            //DayTimesPanel p = new DayTimesPanel(this);
            //p.AddTime();
            //p.AddTime();
            //p.AddTime();
            BackupCalendar weekly = new BackupCalendar(this.tabPage_Weekly, this, 7, "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun");
            BackupCalendar monthly = new BackupCalendar(this.tabPage_Monthly, this, 31);

            Daily daily = new Daily(this.tabPage_Daily);
            daily.AddTime();

            this.CharPassword();
            this.TimeSettings();
            this.DefaultBools();
        }

        private void CharPassword()
        {
            textBox_SMTPPassword.PasswordChar = '•';
            textBox_FTPPassword.PasswordChar = '•';
            textBox_SFTPPassword.PasswordChar = '•';
        }


        private void DefaultBools()
        {
         

        }
        private  void TimeSettings()
        {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = culture;

            dateTimePicker_OneTimeYMD.Format = DateTimePickerFormat.Custom;
            dateTimePicker_OneTimeYMD.CustomFormat = "yyyy-MM-dd"; // or the format you prefer

            this.dateTimePicker_OneTimeTime.CustomFormat = "hh:mm:ss";
            this.dateTimePicker_OneTimeTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_OneTimeTime.ShowUpDown = true;

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
            else if (!this.IsNumber(this.textBox_FTPPort.Text))
            {
                this.errorProvider1.SetError(this.textBox_FTPPort, "This is not number");
                valid = false;
            }
            else if (!this.IsNumber(this.textBox_SFTPPort.Text))
            {
                this.errorProvider1.SetError(this.textBox_SFTPPort, "This is not number");
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

        private void button_Save_Click(object sender, EventArgs e)
        {

        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            if (this.IsValid())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }


        private void radioButton_Localnetwork_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton_Localnetwork.Checked)
                return;

            this.textBox_FTPPassword.Enabled = false;
            this.textBox_FTPUsername.Enabled = false;
            this.textBox_FTPPort.Enabled = false;
            this.textBox_FTPAdress.Enabled = false;
            this.textBox_FTPPath.Enabled = false;

            this.textBox_SFTPPassword.Enabled = false;
            this.textBox_SFTPUsername.Enabled = false;
            this.textBox_SFTPPort.Enabled = false;
            this.textBox_SFTPAdress.Enabled = false;
            this.textBox_SFTPPath.Enabled = false;


            this.textBox_Selectdestination.Enabled = true;
        }

        private void radioButton_SFTP_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton_SFTP.Checked)
                return;

            this.textBox_FTPPassword.Enabled = false;
            this.textBox_FTPUsername.Enabled = false;
            this.textBox_FTPPort.Enabled = false;
            this.textBox_FTPAdress.Enabled = false;
            this.textBox_FTPPath.Enabled = false;

            this.textBox_SFTPPassword.Enabled = true;
            this.textBox_SFTPUsername.Enabled = true;
            this.textBox_SFTPPort.Enabled = true;
            this.textBox_SFTPAdress.Enabled = true;
            this.textBox_SFTPPath.Enabled = true;


            this.textBox_Selectdestination.Enabled = false;
        }

        private void radioButton_FTP_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton_FTP.Checked)
                return;

            this.textBox_FTPPassword.Enabled = true;
            this.textBox_FTPUsername.Enabled = true;
            this.textBox_FTPPort.Enabled = true;
            this.textBox_FTPAdress.Enabled = true;
            this.textBox_FTPPath.Enabled = true;

            this.textBox_SFTPPassword.Enabled = false;
            this.textBox_SFTPUsername.Enabled = false;
            this.textBox_SFTPPort.Enabled = false;
            this.textBox_SFTPAdress.Enabled = false;
            this.textBox_SFTPPath.Enabled = false;


            this.textBox_Selectdestination.Enabled = false;
        }
    }
}
