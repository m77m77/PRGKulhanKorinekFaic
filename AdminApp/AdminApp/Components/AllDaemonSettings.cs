using AdminApp.CommunicationClasses;
using AdminApp.LoginNewToken;
using AdminApp.Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminApp.Components
{
    public class AllDaemonSettings
    {
        private List<OneDaemonSettings> daemonSettings;
        public Dictionary<string, int> NameToIdDaemons = new Dictionary<string, int>();

        public AllDaemonSettings()
        {
            daemonSettings = new List<OneDaemonSettings>();
        }

        public void CreateDaemons(ListSettingsData data,TabControl tabControl,Form_NewMenu form)
        {
            Settings defaultSettings = data.DefaultSettings;
            this.daemonSettings.Add(new OneDaemonSettings(tabControl, form, true, defaultSettings,null));


            foreach (Daemon item in data.ListDaemons)
            {
                this.daemonSettings.Add(new OneDaemonSettings(tabControl, form, false,null, item));
                this.GetEmailFromDaemons(form.GetEmailDaemonsListBoxDaily(),form.GetEmailDaemonsListBoxWeekly(),form.GetEmailDaemonsListBoxMonthly(), item);
            }
        }
        public void GetEmailFromDaemons(CheckedListBox checkedlistboxdaily,CheckedListBox checkedlistboxmonthly,CheckedListBox checkedlistboxweekly, Daemon daemon )
        {
            this.NameToIdDaemons.Add(daemon.DaemonName, daemon.DaemonID);
            checkedlistboxdaily.Items.Add(daemon.DaemonName);
            checkedlistboxweekly.Items.Add(daemon.DaemonName);
            checkedlistboxmonthly.Items.Add(daemon.DaemonName);
        }

        public async void SaveSettings(ServerAccess serverAccess,Label label,ErrorProvider provider)
        {
            provider.Clear();
            foreach (OneDaemonSettings item in this.daemonSettings)
            {
                if(item.HasBeenChanged)
                {
                    if (!item.IsValid(provider)) continue;

                    if(!item.IsDefault)
                    {
                        Response res = await serverAccess.PostSettings(item.SaveSettings(),label);
                        if(res.Status == "OK")
                        {
                            item.Saved();
                        }
                    }else
                    {
                        Response res = await serverAccess.PostDefaultSettings(item.SaveSettings().Settings[0], label);
                        if (res.Status == "OK")
                        {
                            item.Saved();
                        }
                    }
                }
            }
        }
    }
}
