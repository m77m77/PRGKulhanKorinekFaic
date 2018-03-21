using AdminApp.Models.Settings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminApp.Components
{
    public class OneDaemonSettings
    {
        private TextBox textBox_daemonName;
        private Label label_daemonName;

        private TabControl tabControl_Backup;
        private TabPage tabPage_BackupSettings;
        private TabPage tabPage_BackupScheme;

        private TabPage tabPage_daemon;

        private BackupSettingsTab settingsTab;
        private BackupSchemeTab schemeTab;

        public bool HasBeenChanged { get; private set; }
        public event Action OneValueChanged;

        public bool IsDefault { get; private set; }
        public int DaemonID { get; private set; }

        public OneDaemonSettings(TabControl tabControl, Form_NewMenu form,bool isDefault,Settings settings,Daemon daemon)
        {
            this.IsDefault = isDefault;
            this.DaemonID = daemon.DaemonID;
            string name = isDefault ? "Default" : (String.IsNullOrWhiteSpace(daemon.DaemonName) ? "Daemon " + daemon.DaemonID : daemon.DaemonName);
            if (!IsDefault)
            {
                this.textBox_daemonName = new TextBox();
                this.label_daemonName = new Label();
            }
            this.tabControl_Backup = new TabControl();
            this.tabPage_BackupScheme = new TabPage();
            this.tabPage_BackupSettings = new TabPage();
            this.tabPage_daemon = new TabPage();

            if (!IsDefault)
            {
                // 
                // textBox_daemonName
                // 
                this.textBox_daemonName.Location = new System.Drawing.Point(67, 7);
                this.textBox_daemonName.Name = "textBox_daemonName";
                this.textBox_daemonName.Size = new System.Drawing.Size(677, 29);
                this.textBox_daemonName.TabIndex = 1;
                this.textBox_daemonName.Text = name;
                this.textBox_daemonName.TextChanged += TextBox_daemonName_TextChanged;
                // 
                // label_daemonName
                // 
                this.label_daemonName.AutoSize = true;
                this.label_daemonName.Location = new System.Drawing.Point(6, 10);
                this.label_daemonName.Name = "label_daemonName";
                this.label_daemonName.Size = new System.Drawing.Size(55, 21);
                this.label_daemonName.TabIndex = 2;
                this.label_daemonName.Text = "Name:";
            }
            // 
            // tabPage_BackupSettings
            // 
            this.tabPage_BackupSettings.Location = new System.Drawing.Point(32, 4);
            this.tabPage_BackupSettings.Name = "tabPage_BackupSettings";
            this.tabPage_BackupSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_BackupSettings.Size = new System.Drawing.Size(712, 369);
            this.tabPage_BackupSettings.TabIndex = 0;
            this.tabPage_BackupSettings.Text = "Backup settings";
            this.tabPage_BackupSettings.UseVisualStyleBackColor = true;
            // 
            // tabPage_BackupScheme
            // 
            this.tabPage_BackupScheme.Location = new System.Drawing.Point(32, 4);
            this.tabPage_BackupScheme.Name = "tabPage_BackupScheme";
            this.tabPage_BackupScheme.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_BackupScheme.Size = new System.Drawing.Size(719, 366);
            this.tabPage_BackupScheme.TabIndex = 1;
            this.tabPage_BackupScheme.Text = "Backup scheme";
            this.tabPage_BackupScheme.UseVisualStyleBackColor = true;


            this.tabControl_Backup.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl_Backup.Controls.Add(this.tabPage_BackupSettings);
            this.tabControl_Backup.Controls.Add(this.tabPage_BackupScheme);
            this.tabControl_Backup.Location = new System.Drawing.Point(1, 42);
            this.tabControl_Backup.Multiline = true;
            this.tabControl_Backup.Name = "tabControl_Backup";
            this.tabControl_Backup.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl_Backup.SelectedIndex = 0;
            this.tabControl_Backup.ShowToolTips = true;
            this.tabControl_Backup.Size = new System.Drawing.Size(748, 377);
            this.tabControl_Backup.TabIndex = 0;



            // 
            // tabPage_daemon
            // 
            this.tabPage_daemon.Controls.Add(this.label_daemonName);
            this.tabPage_daemon.Controls.Add(this.tabControl_Backup);
            this.tabPage_daemon.Controls.Add(this.textBox_daemonName);
            this.tabPage_daemon.Location = new System.Drawing.Point(4, 30);
            this.tabPage_daemon.Name = "tabPage_daemon";
            this.tabPage_daemon.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_daemon.Size = new System.Drawing.Size(751, 415);
            this.tabPage_daemon.TabIndex = 1;
            this.tabPage_daemon.Text = name;
            this.tabPage_daemon.UseVisualStyleBackColor = true;

            //TABS
            this.settingsTab = new BackupSettingsTab(this.tabPage_BackupSettings);
            this.settingsTab.LoadSettings(daemon);
            this.settingsTab.ValuesChanged += this.ValuesChanged;

            this.schemeTab = new BackupSchemeTab(this.tabPage_BackupScheme, form);
            this.schemeTab.LoadSettings(daemon);
            this.schemeTab.ValuesChanged += this.ValuesChanged;


            //ADD TAB PAGE
            tabControl.Controls.Add(this.tabPage_daemon);
        }

        public bool IsValid(ErrorProvider errProvider)
        {
            bool result = true;

            if(!this.IsDefault)
            {
                if(String.IsNullOrWhiteSpace(this.textBox_daemonName.Text))
                {
                    errProvider.SetError(this.textBox_daemonName, "Cannot be empty");
                    result = false;
                }
            }

            if(!this.settingsTab.IsValid(errProvider))
            {
                result = false;
            }

            return result;
        }

        public Daemon SaveSettings()
        {
            Daemon daemon = new Daemon();
            daemon.DaemonName = this.IsDefault? null : this.textBox_daemonName.Text;
            daemon.DaemonID = this.DaemonID;
            this.settingsTab.SaveSettings(daemon);
            this.schemeTab.SaveSettings(daemon);

            return daemon;
        }

        private void TextBox_daemonName_TextChanged(object sender, EventArgs e)
        {
            this.ValuesChanged();
        }

        private void ValuesChanged()
        {
            if(!this.HasBeenChanged)
            {
                this.HasBeenChanged = true;
            }

            this.ChangeName();
            this.OneValueChanged?.Invoke();
        }

        private void ChangeName()
        {
            if(this.HasBeenChanged)
            {
                this.tabPage_daemon.Text = this.IsDefault ? "Default *" : this.textBox_daemonName.Text + " *";
            }
            else
            {
                this.tabPage_daemon.Text = this.IsDefault ? "Default" : this.textBox_daemonName.Text;
            }
        }

        public void Saved()
        {
            this.HasBeenChanged = false;
            this.ChangeName();
        }
    }
}
