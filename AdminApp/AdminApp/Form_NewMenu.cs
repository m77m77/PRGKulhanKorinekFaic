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

namespace AdminApp
{
    public partial class Form_NewMenu : Form
    {
 

        public Form_NewMenu(ServerAccess gettoken)
        {
            InitializeComponent();
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
          
            this.dateTimePicker_DailyTime2.Visible = false;
            this.dateTimePicker_DailyTime3.Visible = false;
            this.dateTimePicker_DailyTime4.Visible = false;
            this.dateTimePicker_DailyTime5.Visible = false;
            this.button_DailyRemoveTime2.Visible = false;
            this.button_DailyAddTime3.Visible = false;
            this.button_DailyAddTime4.Visible = false;
            this.button_DailyAddTime5.Visible = false;
            this.button_DailyRemoveTime3.Visible = false;
            this.button_DailyRemoveTime4.Visible = false;
            this.button_DailyRemoveTime5.Visible = false;
            this.comboBox_DailyMethod1.Visible = true;
            this.comboBox_DailyMethod2.Visible = false;
            this.comboBox_DailyMethod3.Visible = false;
            this.comboBox_DailyMethod4.Visible = false;
            this.comboBox_DailyMethod5.Visible = false;
            this.panel_WeeklyDay.Visible = false;
            this.dateTimePicker_WeeklyTime1.Visible = true;
            this.dateTimePicker_WeeklyTime2.Visible = false;
            this.dateTimePicker_WeeklyTime3.Visible = false;
            this.button_WeeklyAddTime.Visible = true;
            this.button_WeeklyRemoveTime.Visible = false;
            this.comboBox_WeeklyDay1.Visible = true;
            this.comboBox_WeeklyDay2.Visible = false;
            this.comboBox_WeeklyDay3.Visible = false;

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

            this.dateTimePicker_DailyTime1.CustomFormat = "hh:mm:ss";
            this.dateTimePicker_DailyTime1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_DailyTime1.ShowUpDown = true;

            this.dateTimePicker_DailyTime2.CustomFormat = "hh:mm:ss";
            this.dateTimePicker_DailyTime2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_DailyTime2.ShowUpDown = true;

            this.dateTimePicker_DailyTime3.CustomFormat = "hh:mm:ss";
            this.dateTimePicker_DailyTime3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_DailyTime3.ShowUpDown = true;

            this.dateTimePicker_DailyTime4.CustomFormat = "hh:mm:ss";
            this.dateTimePicker_DailyTime4.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_DailyTime4.ShowUpDown = true;

            this.dateTimePicker_DailyTime5.CustomFormat = "hh:mm:ss";
            this.dateTimePicker_DailyTime5.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_DailyTime5.ShowUpDown = true;

         
            this.dateTimePicker_WeeklyTime1.CustomFormat = "hh:mm:ss";
            this.dateTimePicker_WeeklyTime1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_WeeklyTime1.ShowUpDown = true;

            this.dateTimePicker_WeeklyTime2.CustomFormat = "hh:mm:ss";
            this.dateTimePicker_WeeklyTime2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_WeeklyTime2.ShowUpDown = true;

            this.dateTimePicker_WeeklyTime3.CustomFormat = "hh:mm:ss";
            this.dateTimePicker_WeeklyTime3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_WeeklyTime3.ShowUpDown = true;

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
            else if (!this.IsNumber(this.textBox_DailyKeepingBackups.Text))
            {
                this.errorProvider1.SetError(this.textBox_DailyKeepingBackups, "This is not number");
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
            else if((this.comboBox_DailyMethod2.Visible == true && this.comboBox_DailyMethod3.Visible == true && this.comboBox_DailyMethod4.Visible == true && this.comboBox_DailyMethod5.Visible == true) && (!(this.dateTimePicker_DailyTime1.Value < this.dateTimePicker_DailyTime2.Value)|| !(this.dateTimePicker_DailyTime1.Value < this.dateTimePicker_DailyTime3.Value) || !(this.dateTimePicker_DailyTime1.Value < this.dateTimePicker_DailyTime4.Value) || !(this.dateTimePicker_DailyTime1.Value < this.dateTimePicker_DailyTime5.Value)))
            {
                this.errorProvider1.SetError(this.dateTimePicker_DailyTime1, "This value must be smaller than the other value ");
                valid = false;
            }
            else if((this.comboBox_DailyMethod2.Visible == true && this.comboBox_DailyMethod3.Visible == true && this.comboBox_DailyMethod4.Visible == true) && (!(this.dateTimePicker_DailyTime1.Value < this.dateTimePicker_DailyTime2.Value) || !(this.dateTimePicker_DailyTime1.Value < this.dateTimePicker_DailyTime3.Value) || !(this.dateTimePicker_DailyTime1.Value < this.dateTimePicker_DailyTime4.Value)))
            {
                this.errorProvider1.SetError(this.dateTimePicker_DailyTime1, "This value must be smaller than the other values ");
                valid = false;
            }
            else if ((this.comboBox_DailyMethod2.Visible == true && this.comboBox_DailyMethod3.Visible == true) && (!(this.dateTimePicker_DailyTime1.Value < this.dateTimePicker_DailyTime2.Value) || !(this.dateTimePicker_DailyTime1.Value < this.dateTimePicker_DailyTime3.Value)))
            {
                this.errorProvider1.SetError(this.dateTimePicker_DailyTime1, "This value must be smaller than the other values ");
                valid = false;
            }
            else if ((this.comboBox_DailyMethod2.Visible == true) && (!(this.dateTimePicker_DailyTime1.Value < this.dateTimePicker_DailyTime2.Value)))
            {
                this.errorProvider1.SetError(this.dateTimePicker_DailyTime1, "This value must be smaller than the other values ");
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
            this.textBox_FTPPassword.ReadOnly = true;
            this.textBox_FTPUsername.ReadOnly = true;
            this.textBox_FTPPort.ReadOnly = true;
            this.textBox_FTPAdress.ReadOnly = true;

            this.textBox_SFTPPassword.ReadOnly = true;
            this.textBox_SFTPUsername.ReadOnly = true;
            this.textBox_SFTPPort.ReadOnly = true;
            this.textBox_SFTPAdress.ReadOnly = true;


            this.textBox_Selectdestination.ReadOnly = false;
        }

        private void radioButton_SFTP_CheckedChanged(object sender, EventArgs e)
        {
            this.textBox_FTPPassword.ReadOnly = true;
            this.textBox_FTPUsername.ReadOnly = true;
            this.textBox_FTPPort.ReadOnly = true;
            this.textBox_FTPAdress.ReadOnly = true;

            this.textBox_SFTPPassword.ReadOnly = false;
            this.textBox_SFTPUsername.ReadOnly = false;
            this.textBox_SFTPPort.ReadOnly = false;
            this.textBox_SFTPAdress.ReadOnly = false;


            this.textBox_Selectdestination.ReadOnly = true;
        }

        private void radioButton_FTP_CheckedChanged(object sender, EventArgs e)
        {
            this.textBox_FTPPassword.ReadOnly = false;
            this.textBox_FTPUsername.ReadOnly = false;
            this.textBox_FTPPort.ReadOnly = false;
            this.textBox_FTPAdress.ReadOnly = false;

            this.textBox_SFTPPassword.ReadOnly = true;
            this.textBox_SFTPUsername.ReadOnly = true;
            this.textBox_SFTPPort.ReadOnly = true;
            this.textBox_SFTPAdress.ReadOnly = true;


            this.textBox_Selectdestination.ReadOnly = true;
        }

        private void button_DailyAddTime2_Click(object sender, EventArgs e)
        {
            this.dateTimePicker_DailyTime2.Visible = true;
            this.button_DailyRemoveTime2.Visible = true;
            this.button_DailyAddTime3.Visible = true;
            this.comboBox_DailyMethod2.Visible = true;
        }

        private void button_DailyRemoveTime2_Click(object sender, EventArgs e)
        {
            if (this.dateTimePicker_DailyTime3.Visible == false && this.dateTimePicker_DailyTime4.Visible == false && this.dateTimePicker_DailyTime5.Visible == false)
            {
                this.dateTimePicker_DailyTime2.Visible = false;
                this.button_DailyRemoveTime2.Visible = false;
                this.button_DailyAddTime3.Visible = false;
                this.comboBox_DailyMethod2.Visible = false;
            }
        }

        private void button_DailyAddTime3_Click(object sender, EventArgs e)
        {
            
            this.dateTimePicker_DailyTime3.Visible = true;
            this.button_DailyRemoveTime3.Visible = true;
            this.button_DailyAddTime4.Visible = true;
            this.comboBox_DailyMethod3.Visible = true;
        }

        private void button_DailyRemoveTime3_Click(object sender, EventArgs e)
        {
            if (this.dateTimePicker_DailyTime4.Visible == false && this.dateTimePicker_DailyTime5.Visible == false)
            {
                this.dateTimePicker_DailyTime3.Visible = false;
                this.button_DailyRemoveTime3.Visible = false;
                this.button_DailyAddTime4.Visible = false;
                this.comboBox_DailyMethod3.Visible = false;
            }
           
        }

        private void button_DailyAddTime4_Click(object sender, EventArgs e)
        {
            
            
                this.dateTimePicker_DailyTime4.Visible = true;
                this.button_DailyRemoveTime4.Visible = true;
                this.button_DailyAddTime5.Visible = true;
                this.comboBox_DailyMethod4.Visible = true;

        }

        private void button_DailyRemoveTime4_Click(object sender, EventArgs e)
        {
            if (this.dateTimePicker_DailyTime5.Visible == false)
            {
                this.dateTimePicker_DailyTime4.Visible = false;
                this.button_DailyRemoveTime4.Visible = false;
                this.button_DailyAddTime5.Visible = false;
                this.comboBox_DailyMethod4.Visible = false;
            }
        }

        private void button_DailyAddTime5_Click(object sender, EventArgs e)
        {
            this.dateTimePicker_DailyTime5.Visible = true;
            this.button_DailyRemoveTime5.Visible = true;
            this.comboBox_DailyMethod5.Visible = true;

        }

        private void button_DailyRemoveTime5_Click(object sender, EventArgs e)
        {
            this.dateTimePicker_DailyTime5.Visible = false;
            this.button_DailyRemoveTime5.Visible = false;
            this.comboBox_DailyMethod5.Visible = false;
        }

        private void button_WeeklyAddTime_Click(object sender, EventArgs e)
        {
            this.button_WeeklyRemoveTime.Visible = true;
            this.dateTimePicker_WeeklyTime2.Visible = true;
            this.dateTimePicker_WeeklyTime3.Visible = true;
            this.comboBox_WeeklyDay2.Visible = true;
            this.comboBox_WeeklyDay3.Visible = true;
        }

        private void checkBox_Mon_CheckedChanged(object sender, EventArgs e)
        {
            this.panel_WeeklyDay.Visible = true;
        }

        private void button_WeeklyRemoveTime_Click(object sender, EventArgs e)
        {
            this.comboBox_WeeklyDay2.Visible = false;
            this.comboBox_WeeklyDay3.Visible = false;
        }

        private void tabPage_Weekly_Click(object sender, EventArgs e)
        {
            this.panel_WeeklyDay.Visible = false;
        }
    }
}
