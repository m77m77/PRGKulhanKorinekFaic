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
            this.daemonSettings.Add(new OneDaemonSettings(tabControl, form, true, defaultSettings));


            foreach (Settings item in data.ListSettings)
            {
                this.daemonSettings.Add(new OneDaemonSettings(tabControl, form, false, item));
                this.GetEmailFromDaemons(form.GetEmailDaemonsListBox(), item);
            }
        }
        public void GetEmailFromDaemons(CheckedListBox checkedlistbox,Settings settings )
        {
            this.NameToIdDaemons.Add(settings.DaemonName, settings.DaemonID);
            checkedlistbox.Items.Add(settings.DaemonName);
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
                        Response res = await serverAccess.PostDefaultSettings(item.SaveSettings(), label);
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
