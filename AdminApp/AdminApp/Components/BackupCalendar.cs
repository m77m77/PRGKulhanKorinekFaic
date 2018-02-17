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

        public BackupCalendar(TabPage page,Form_NewMenu menu,int count,params string[] names)
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

            ((TabControl)page.Parent).SelectedIndexChanged += BackupCalendar_TabControl_SelectedIndexChanged;
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
