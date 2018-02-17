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
            //BackupCalendar weekly = new BackupCalendar(this.tabPage_Weekly, this, 7, "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun");
            //BackupCalendar monthly = new BackupCalendar(this.tabPage_Monthly, this, 31);

            //Daily daily = new Daily(this.tabPage_Daily);
            //daily.AddTime();

            //BackupSchemeTab tab = new BackupSchemeTab(this.tabPage_BackupScheme, this);
            //BackupSettingsTab settingsTab = new BackupSettingsTab(this.tabPage_BackupSettings);
            Settings settings = new Settings();
            settings.DaemonID = 1;
            settings.DaemonName = "Main";
            settings.BackupSourcePath = @"C\DATA";
            settings.ActionAfterBackup = "RESTART";
            settings.SaveFormat = "ZIP";

            //LocalNetworkDestination dest = new LocalNetworkDestination();
            FTPDestination dest = new FTPDestination();
            dest.Path = @"\BACKUP\ABCD";
            dest.Adress = "localhost";
            dest.Port = "5430";
            dest.Username = "admin";
            dest.Password = "password";
            settings.Destination = dest;

            BackupScheme scheme = new BackupScheme();
            scheme.Type = "WEEKLY";
            scheme.MaxBackups = 5;
            scheme.BackupTimes = new List<BackupTime>();
            scheme.BackupTimes.Add(new BackupTime() { Type = "FULL", Time = new TimeSpan(4, 0, 0), DayNumber = 0 });
            scheme.BackupTimes.Add(new BackupTime() { Type = "DIFF", Time = new TimeSpan(5, 0, 0), DayNumber = 4 });
            scheme.BackupTimes.Add(new BackupTime() { Type = "INC", Time = new TimeSpan(6, 0, 0), DayNumber = 6 });
            settings.BackupScheme = scheme;

            OneDaemonSettings daemonSet = new OneDaemonSettings(this.tabControl_Daemon, this,false,settings);
            OneDaemonSettings defaultSet = new OneDaemonSettings(this.tabControl_Daemon, this,true,settings);

            MessageBox.Show(JsonConvert.SerializeObject(daemonSet.SaveSettings(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() }));
            //this.CharPassword();
            //this.TimeSettings();
            //this.DefaultBools();
        }


        private void DefaultBools()
        {
         

        }
        private  void TimeSettings()
        {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = culture;

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
    }
}
