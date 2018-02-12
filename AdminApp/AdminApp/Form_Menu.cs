using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AdminApp
{
    public partial class Form_Menu : Form
    {
        public Form_Menu()
        {
            InitializeComponent();

            textBox_MailPassword.PasswordChar = '*';
            textBox_FTPPassword.PasswordChar = '*';

            this.TimeSettings();
        

        }

        private void button_Select_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                this.textBox_Path.Text = fbd.SelectedPath;
               
            }
        }

        private void radioButton_Localnetwork_CheckedChanged(object sender, EventArgs e)
        {
            this.textBox_FTPPassword.ReadOnly = true;
            this.textBox_FTPUsername.ReadOnly = true;
            this.textBox_FTPPort.ReadOnly = true;
            this.textBox_FTPAdress.ReadOnly = true;
            this.button_Selectdestinaton.Enabled = true;
            this.textBox_Selectdestination.ReadOnly = false;

        }

        private void radioButton_FTP_CheckedChanged(object sender, EventArgs e)
        {
            this.textBox_FTPPassword.ReadOnly = false;
            this.textBox_FTPUsername.ReadOnly = false;
            this.textBox_FTPPort.ReadOnly = false;
            this.textBox_FTPAdress.ReadOnly = false;
            this.button_Selectdestinaton.Enabled = false;
            this.textBox_Selectdestination.ReadOnly = true;
        }

        private void button_Selectdestinaton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                this.textBox_Selectdestination.Text = fbd.SelectedPath;

            }

        }

        private bool IsValid()
        {
            bool valid = true;
            this.errorProvider1.Clear();


            if (Regex.IsMatch(this.textBox_To.Text,@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                this.errorProvider1.SetError(this.textBox_To, "Type in correct email - xxx@xxx.xx");
                valid = false;
            }
           
            return valid;

        }


        public void TimeSettings()
        {
            this.dateTimePicker_OnetimeTime.CustomFormat = "hh:mm:ss";
            this.dateTimePicker_OnetimeTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_OnetimeTime.ShowUpDown = true;

            this.dateTimePicker_DailyTime.CustomFormat = "hh:mm:ss";
            this.dateTimePicker_DailyTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_DailyTime.ShowUpDown = true;

            this.dateTimePicker_WeeklyTime.CustomFormat = "hh:mm:ss";
            this.dateTimePicker_WeeklyTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_WeeklyTime.ShowUpDown = true;

            this.dateTimePicker_MonthlyTime.CustomFormat = "hh:mm:ss";
            this.dateTimePicker_MonthlyTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_MonthlyTime.ShowUpDown = true;



        }

        private void ToolStripMenuItem_Onetime_Click(object sender, EventArgs e)
        {
            this.panel_Onetime.Visible = true;
            this.panel_Daily.Visible = false;
            this.panel_Weekly.Visible = false;
            this.panel_Monthly.Visible = false;
        }
        private void ToolStripMenuItem_Daily_Click(object sender, EventArgs e)
        {
            this.panel_Daily.Visible = true;
            this.panel_Onetime.Visible = false;
            this.panel_Weekly.Visible = false;
            this.panel_Monthly.Visible = false;
        }

       

        private void ToolStripMenuItem_Weekly_Click(object sender, EventArgs e)
        {
            this.panel_Weekly.Visible = true;
            this.panel_Daily.Visible = false;
            this.panel_Onetime.Visible = false;
            this.panel_Monthly.Visible = false;

        }

        private void ToolStripMenuItem_Monthly_Click(object sender, EventArgs e)
        {
            this.panel_Monthly.Visible = true;
            this.panel_Weekly.Visible = false;
            this.panel_Daily.Visible = false;
            this.panel_Onetime.Visible = false;

        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (this.IsValid())
            {
                
                Application.Exit();
              
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Do you really want to exit?");
            Application.Exit();
        }

       
    }
}
