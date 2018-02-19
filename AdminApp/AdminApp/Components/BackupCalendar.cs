using AdminApp.Models.Settings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminApp.Components
{
    public class BackupCalendar
    {
        private List<OneDay> days;
        public event Action ValuesChanged;

        public BackupCalendar(TabControl control,TabPage page,Form_NewMenu menu,int count,params string[] names)
        {
            days = new List<OneDay>();

            for (int i = 0; i < count; i++)
            {
                string name = (i + 1) + "";
                if (names.Length > i)
                {
                    name = names[i];
                }
                OneDay day = new OneDay(this,new Point((i % 7) * 66, (i / 7) * 66), menu, name, page);
                day.ListChanged += DayListChanged;
                days.Add(day);
            }

            control.SelectedIndexChanged += BackupCalendar_TabControl_SelectedIndexChanged;
        }

        public void LoadSettings(Settings settings)
        {
            foreach (BackupTime item in settings.BackupScheme.BackupTimes)
            {
                this.days[item.DayNumber].LoadSettings(item);
            }
        }

        public void SaveSettings(Settings settings)
        {
            List<BackupTime> bcTimes = new List<BackupTime>();
            for (int i = 0; i < this.days.Count; i++)
            {
                this.days[i].SaveSettings(bcTimes, i);
            }

            settings.BackupScheme.BackupTimes = bcTimes;
        }   

        private void BackupCalendar_TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.HidePanels();
        }

        private void DayListChanged()
        {
            bool found = false;
            foreach (OneDay item in this.days)
            {
                if(!found)
                {
                    if(item.HasBackupTimes)
                    {
                        found = true;
                        item.ValidateFirstDay(true);
                    }
                }else
                {
                    item.ValidateFirstDay(false);
                }
            }

            ValuesChanged?.Invoke();
        }

        public void HidePanels()
        {
            foreach (OneDay item in this.days)
            {
                item.HidePanel();
            }
        }
    }
}
