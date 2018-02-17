using AdminApp.Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminApp.Components
{
    public class BackupSchemeTab
    {
        private TabControl tabControl_Scheme;

        private TabPage tabPage_OneTime;
        private DateTimePicker oneTimeWhen;
        private Label label15;

        private NumericUpDown dailyKeepBackups;
        private Label label19;
        private TabPage tabPage_Daily;
        private Daily daily;

        private TabPage tabPage_Weekly;
        private NumericUpDown weeklyKeepBackups;
        private Label label20;
        private BackupCalendar weekly;

        private TabPage tabPage_Monthly;
        private NumericUpDown monthlyKeepBackups;
        private Label label21;
        private BackupCalendar monthly;

        public event Action ValuesChanged;

        public BackupSchemeTab(TabPage schemePage,Form_NewMenu form)
        {
            this.tabControl_Scheme = new TabControl();

            //this.tabControl_Scheme.Controls.Add(this.tabPage_OneTime);
            //this.tabControl_Scheme.Controls.Add(this.tabPage_Daily);
            //this.tabControl_Scheme.Controls.Add(this.tabPage_Weekly);
            //this.tabControl_Scheme.Controls.Add(this.tabPage_Monthly);

            this.tabControl_Scheme.Location = new System.Drawing.Point(0, 0);
            this.tabControl_Scheme.Name = "tabControl_Scheme";
            this.tabControl_Scheme.SelectedIndex = 0;
            this.tabControl_Scheme.Size = new System.Drawing.Size(719, 369);
            this.tabControl_Scheme.TabIndex = 0;
            this.tabControl_Scheme.SelectedIndexChanged += this.EventValChanged;

            this.IniOneTimeTabPage();
            this.IniDailyTabPage();
            this.IniWeeklyTabPage(form);
            this.IniMonthlyTabPage(form);

            this.tabControl_Scheme.Controls.Add(this.tabPage_OneTime);
            this.tabControl_Scheme.Controls.Add(this.tabPage_Daily);
            this.tabControl_Scheme.Controls.Add(this.tabPage_Weekly);
            this.tabControl_Scheme.Controls.Add(this.tabPage_Monthly);

            schemePage.Controls.Add(this.tabControl_Scheme);

        }

        public void LoadSettings(Settings settings)
        {
            //BACKUP SCHEME
            this.tabControl_Scheme.SelectedIndexChanged -= this.EventValChanged;
            if(settings.BackupScheme.Type == "ONE_TIME")
            {
                this.tabControl_Scheme.SelectedIndex = 0;
                this.oneTimeWhen.ValueChanged -= this.EventValChanged;
                this.oneTimeWhen.Value = settings.BackupScheme.OneTimeBackup.When;
                this.oneTimeWhen.ValueChanged += this.EventValChanged;
            }
            else if (settings.BackupScheme.Type == "DAILY")
            {
                this.tabControl_Scheme.SelectedIndex = 1;
                this.daily.LoadSettings(settings);
                this.dailyKeepBackups.ValueChanged -= this.EventValChanged;
                this.dailyKeepBackups.Value = settings.BackupScheme.MaxBackups;
                this.dailyKeepBackups.ValueChanged += this.EventValChanged;
            }
            else if (settings.BackupScheme.Type == "WEEKLY")
            {
                this.tabControl_Scheme.SelectedIndex = 2;
                this.weekly.LoadSettings(settings);
                this.weeklyKeepBackups.ValueChanged -= this.EventValChanged;
                this.weeklyKeepBackups.Value = settings.BackupScheme.MaxBackups;
                this.weeklyKeepBackups.ValueChanged += this.EventValChanged;
            }
            else if (settings.BackupScheme.Type == "MONTHLY")
            {
                this.tabControl_Scheme.SelectedIndex = 3;
                this.monthly.LoadSettings(settings);
                this.monthlyKeepBackups.ValueChanged -= this.EventValChanged;
                this.monthlyKeepBackups.Value = settings.BackupScheme.MaxBackups;
                this.monthlyKeepBackups.ValueChanged += this.EventValChanged;
            }
            this.tabControl_Scheme.SelectedIndexChanged += this.EventValChanged;
        }

        public void SaveSettings(Settings settings)
        {
            if (this.tabControl_Scheme.SelectedIndex == 0)
            {
                settings.BackupScheme = new BackupScheme();
                settings.BackupScheme.Type = "ONE_TIME";
                settings.BackupScheme.OneTimeBackup = new OneTimeBackup();
                settings.BackupScheme.OneTimeBackup.When = this.oneTimeWhen.Value;
            }
            else if (this.tabControl_Scheme.SelectedIndex == 1)
            {
                settings.BackupScheme = new BackupScheme();
                settings.BackupScheme.Type = "DAILY";
                this.daily.SaveSettings(settings);
                settings.BackupScheme.MaxBackups = (int) this.dailyKeepBackups.Value;
            }
            else if (this.tabControl_Scheme.SelectedIndex == 2)
            {
                settings.BackupScheme = new BackupScheme();
                settings.BackupScheme.Type = "WEEKLY";
                this.weekly.SaveSettings(settings);
                settings.BackupScheme.MaxBackups = (int) this.weeklyKeepBackups.Value;
            }
            else if (this.tabControl_Scheme.SelectedIndex == 3)
            {
                settings.BackupScheme = new BackupScheme();
                settings.BackupScheme.Type = "MONTHLY";
                this.monthly.SaveSettings(settings);
                settings.BackupScheme.MaxBackups = (int) this.monthlyKeepBackups.Value;
            }
        }

        private void ValsChanged()
        {
            this.ValuesChanged?.Invoke();
        }

        private void EventValChanged(object sender,EventArgs args)
        {
            this.ValuesChanged?.Invoke();
        }

        private void IniMonthlyTabPage(Form_NewMenu form)
        {
            this.monthlyKeepBackups = new NumericUpDown();
            this.label21 = new Label();
            this.tabPage_Monthly = new TabPage();

            // 
            // monthlyKeepBackups
            // 
            this.monthlyKeepBackups.Location = new System.Drawing.Point(552, 41);
            this.monthlyKeepBackups.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.monthlyKeepBackups.Name = "monthlyKeepBackups";
            this.monthlyKeepBackups.Size = new System.Drawing.Size(49, 29);
            this.monthlyKeepBackups.TabIndex = 63;
            this.monthlyKeepBackups.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label21.Location = new System.Drawing.Point(499, 40);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(183, 25);
            this.label21.TabIndex = 62;
            this.label21.Text = "Keep            backups";

            this.tabPage_Monthly.Controls.Add(this.monthlyKeepBackups);
            this.tabPage_Monthly.Controls.Add(this.label21);
            this.tabPage_Monthly.Location = new System.Drawing.Point(4, 30);
            this.tabPage_Monthly.Name = "tabPage_Monthly";
            this.tabPage_Monthly.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Monthly.Size = new System.Drawing.Size(688, 336);
            this.tabPage_Monthly.TabIndex = 3;
            this.tabPage_Monthly.Text = "Monthly";
            this.tabPage_Monthly.UseVisualStyleBackColor = true;

            //MONTHLY
            this.monthly = new BackupCalendar(this.tabControl_Scheme,this.tabPage_Monthly, form, 31);
            this.monthly.ValuesChanged += this.ValsChanged;
        }

        private void IniWeeklyTabPage(Form_NewMenu form)
        {
            this.weeklyKeepBackups = new NumericUpDown();
            this.label20 = new Label();
            this.tabPage_Weekly = new TabPage();

            // 
            // weeklyKeepBackups
            // 
            this.weeklyKeepBackups.Location = new System.Drawing.Point(552, 41);
            this.weeklyKeepBackups.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.weeklyKeepBackups.Name = "weeklyKeepBackups";
            this.weeklyKeepBackups.Size = new System.Drawing.Size(49, 29);
            this.weeklyKeepBackups.TabIndex = 65;
            this.weeklyKeepBackups.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label20.Location = new System.Drawing.Point(499, 40);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(183, 25);
            this.label20.TabIndex = 64;
            this.label20.Text = "Keep            backups";


            this.tabPage_Weekly.Controls.Add(this.weeklyKeepBackups);
            this.tabPage_Weekly.Controls.Add(this.label20);
            this.tabPage_Weekly.Location = new System.Drawing.Point(4, 30);
            this.tabPage_Weekly.Name = "tabPage_Weekly";
            this.tabPage_Weekly.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Weekly.Size = new System.Drawing.Size(688, 336);
            this.tabPage_Weekly.TabIndex = 2;
            this.tabPage_Weekly.Text = "Weekly";
            this.tabPage_Weekly.UseVisualStyleBackColor = true;

            //WEEKLY
            this.weekly = new BackupCalendar(this.tabControl_Scheme,this.tabPage_Weekly, form, 7, "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun");
            this.weekly.ValuesChanged += this.ValsChanged;
        }

        private void IniDailyTabPage()
        {
            this.dailyKeepBackups = new NumericUpDown();
            this.label19 = new Label();
            this.tabPage_Daily = new TabPage();

            // 
            // dailyKeepBackups
            // 
            this.dailyKeepBackups.Location = new System.Drawing.Point(552, 41);
            this.dailyKeepBackups.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dailyKeepBackups.Name = "dailyKeepBackups";
            this.dailyKeepBackups.Size = new System.Drawing.Size(49, 29);
            this.dailyKeepBackups.TabIndex = 67;
            this.dailyKeepBackups.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dailyKeepBackups.ValueChanged += this.EventValChanged;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label19.Location = new System.Drawing.Point(499, 40);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(183, 25);
            this.label19.TabIndex = 66;
            this.label19.Text = "Keep            backups";


            this.tabPage_Daily.Controls.Add(this.dailyKeepBackups);
            this.tabPage_Daily.Controls.Add(this.label19);
            this.tabPage_Daily.Location = new System.Drawing.Point(4, 30);
            this.tabPage_Daily.Name = "tabPage_Daily";
            this.tabPage_Daily.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Daily.Size = new System.Drawing.Size(693, 336);
            this.tabPage_Daily.TabIndex = 1;
            this.tabPage_Daily.Text = "Daily";
            this.tabPage_Daily.UseVisualStyleBackColor = true;

            //DAILY
            this.daily = new Daily(this.tabPage_Daily);
            this.daily.ListChanged += this.ValsChanged;

        }

        private void IniOneTimeTabPage()
        {
            this.tabPage_OneTime = new TabPage();
            this.oneTimeWhen = new DateTimePicker();
            this.label15 = new Label();

            // 
            // oneTimeWhen
            // 
            this.oneTimeWhen.CustomFormat = "HH:mm dd.MM.yyyy";
            this.oneTimeWhen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.oneTimeWhen.Location = new System.Drawing.Point(142, 21);
            this.oneTimeWhen.Name = "oneTimeWhen";
            this.oneTimeWhen.Size = new System.Drawing.Size(170, 29);
            this.oneTimeWhen.TabIndex = 2;
            this.oneTimeWhen.ValueChanged += this.EventValChanged;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 27);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(133, 21);
            this.label15.TabIndex = 0;
            this.label15.Text = "Execute backup at";

            this.tabPage_OneTime.Controls.Add(this.oneTimeWhen);
            this.tabPage_OneTime.Controls.Add(this.label15);
            this.tabPage_OneTime.Location = new System.Drawing.Point(4, 30);
            this.tabPage_OneTime.Name = "tabPage_OneTime";
            this.tabPage_OneTime.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_OneTime.Size = new System.Drawing.Size(693, 336);
            this.tabPage_OneTime.TabIndex = 0;
            this.tabPage_OneTime.Text = "One-Time";
            this.tabPage_OneTime.UseVisualStyleBackColor = true;
        }
    }
}
