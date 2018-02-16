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
using AdminApp.LoginNewToken;


namespace AdminApp
{
    public partial class Form_Menu : Form
    {
        public Form_Menu(ServerAccess gettoken)
        {
            InitializeComponent();

            textBox_MailPassword.PasswordChar = '*';
            textBox_FTPPassword.PasswordChar = '*';

            this.TimeSettings();

            this.DefaultBool();
            

        }

        private void DefaultBool()
        {
            this.panel_Mail.Visible = true;
            this.panel_Administrace.Visible = false;
            this.panel_BackupschemeDefault.Visible = false;
            this.panel_Daily.Visible = false;
            this.panel_Bakupsettings.Visible = false;
            this.panel_Weekly.Visible = false;
            this.panel_Monthly.Visible = false;
            this.panel_Weekly.Enabled = true;
            this.panel_Monthly.Enabled = true;
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
          
            this.textBox_Selectdestination.ReadOnly = false;

        }

        private void radioButton_FTP_CheckedChanged(object sender, EventArgs e)
        {
            this.textBox_FTPPassword.ReadOnly = false;
            this.textBox_FTPUsername.ReadOnly = false;
            this.textBox_FTPPort.ReadOnly = false;
            this.textBox_FTPAdress.ReadOnly = false;
         
            this.textBox_Selectdestination.ReadOnly = true;
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
            this.dateTimePicker_OneTimeTime.CustomFormat = "hh:mm:ss";
            this.dateTimePicker_OneTimeTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_OneTimeTime.ShowUpDown = true;

            this.dateTimePicker_DailyTime.CustomFormat = "hh:mm:ss";
            this.dateTimePicker_DailyTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_DailyTime.ShowUpDown = true;

            //this.dateTimePicker_WeeklyTime.CustomFormat = "hh:mm:ss";
            //this.dateTimePicker_WeeklyTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            //this.dateTimePicker_WeeklyTime.ShowUpDown = true;

            this.dateTimePicker_WeeklyMon.CustomFormat = "hh:mm:ss";
            this.dateTimePicker_WeeklyMon.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_WeeklyMon.ShowUpDown = true;

            this.dateTimePicker_WeeklyTue.CustomFormat = "hh:mm:ss";
            this.dateTimePicker_WeeklyTue.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_WeeklyTue.ShowUpDown = true;

            this.dateTimePicker_WeeklyWed.CustomFormat = "hh:mm:ss";
            this.dateTimePicker_WeeklyWed.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_WeeklyWed.ShowUpDown = true;

            this.dateTimePicker_WeeklyThur.CustomFormat = "hh:mm:ss";
            this.dateTimePicker_WeeklyThur.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_WeeklyThur.ShowUpDown = true;

            this.dateTimePicker_WeeklyFri.CustomFormat = "hh:mm:ss";
            this.dateTimePicker_WeeklyFri.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_WeeklyFri.ShowUpDown = true;

            this.dateTimePicker_WeeklySat.CustomFormat = "hh:mm:ss";
            this.dateTimePicker_WeeklySat.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_WeeklySat.ShowUpDown = true;

            this.dateTimePicker_WeeklySun.CustomFormat = "hh:mm:ss";
            this.dateTimePicker_WeeklySun.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_WeeklySun.ShowUpDown = true;






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
            //MessageBox.Show("Do you really want to exit?");
            Application.Exit();
        }

        private void emailNotifikaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel_Mail.Visible = true;
            this.panel_Administrace.Visible = false;
        }

        private void administraceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel_Administrace.Visible = true;
            this.panel_Mail.Visible = true;
        }

        private void button_AddDaemon_Click(object sender, EventArgs e)
        {

            TabPage newPage = new TabPage();

            foreach (Control control in tabControl1.TabPages[0].Controls)
            {
                newPage.Controls.Add(control);
            }

            tabControl1.TabPages.Add(newPage);

         

        }

        private void backupSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel_Bakupsettings.Visible = true;
            this.panel_BackupschemeDefault.Visible = false;
            this.panel_Daily.Visible = false;
            this.panel_Weekly.Visible = false;
            this.panel_Monthly.Visible = false;
        }

        private void backupSchemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            this.panel_BackupschemeDefault.Visible = true;
            // this.panel_Daily.Visible = false;
            //this.panel_Bakupsettings.Visible = false;
         //   this.panel_Daily.Visible = false;
           // this.panel_Weekly.Visible = false;
           // this.panel_Monthly.Visible = false;




        }

        private void OneTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.panel_BackupschemeDefault.Visible = true;
            this.panel_Daily.Visible = false;
            //this.panel_Bakupsettings.Visible = false;
            this.panel_Monthly.Visible = false;
            this.panel_Daily.Visible = false;
        }

        private void DailyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
         
            this.panel_BackupschemeDefault.Visible = true;
            this.panel_Daily.Visible = true;
            // this.panel_Bakupsettings.Visible = false;
            this.panel_Monthly.Visible = false;
            this.panel_Weekly.Visible = false;

        }

        private void WeeklyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel_BackupschemeDefault.Visible = true;
            this.panel_Weekly.Visible = true;
            this.panel_Monthly.Visible = false;
            this.panel_Daily.Visible = false;
        }

        private void MonthlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            this.panel_BackupschemeDefault.Visible = true;
            this.panel_Monthly.Visible = true;
            this.panel_Weekly.Visible = false;
            this.panel_Daily.Visible = false;
        }

        private void comboBox_Afterbackup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Path_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_Savingformat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox_FTPAdress_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_FTPPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_FTPPort_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_Savingformat_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_Adress_Click(object sender, EventArgs e)
        {

        }

        private void textBox_FTPUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Selectdestination_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label_FTPport_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label_AfterBackup_Click(object sender, EventArgs e)
        {

        }
    }
}
