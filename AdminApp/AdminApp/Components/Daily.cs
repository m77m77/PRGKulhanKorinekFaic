using AdminApp.Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminApp.Components
{
    public class Daily
    {
        private List<DailyOneTime> times;
        private Button dailyAdd;
        public TabPage Parent { get; private set; }


        public event Action ListChanged;

        private int maxTimes = 12;

        public Daily(TabPage parent)
        {
            this.Parent = parent;
            this.times = new List<DailyOneTime>();
            this.dailyAdd = new Button();

            this.dailyAdd.Location = new System.Drawing.Point(6, 6);
            this.dailyAdd.Name = "dailyAdd";
            this.dailyAdd.Size = new System.Drawing.Size(117, 99);
            this.dailyAdd.TabIndex = 2;
            this.dailyAdd.Text = "+";
            this.dailyAdd.UseVisualStyleBackColor = true;
            this.dailyAdd.Click += DailyAdd_Click;

            parent.Controls.Add(this.dailyAdd);

            this.ListChanged += ValidateFirstDay;
        }

        private void DailyAdd_Click(object sender, EventArgs e)
        {
            this.AddTime();
        }

        private void ValuesChanged()
        {
            this.ListChanged?.Invoke();
        }

        public void LoadSettings(Settings settings)
        {
            foreach (BackupTime item in settings.BackupScheme.BackupTimes)
            {
                this.AddTime(item);
            }

            ValidateFirstDay();
        }

        public void SaveSettings(Settings settings)
        {
            List<BackupTime> bcTimes = new List<BackupTime>();
            foreach (DailyOneTime item in this.times)
            {
                BackupTime bcTime = new BackupTime();
                bcTime.DayNumber = 1;
                item.SaveSettings(bcTime);
                bcTimes.Add(bcTime);
            }

            settings.BackupScheme.BackupTimes = bcTimes;
        }

        public void AddTime(BackupTime bcTime = null)
        {
            DailyOneTime time = new DailyOneTime(this.times.Count, this.Parent, this);
            if(bcTime != null)
            {
                time.LoadSettings(bcTime);
            }

            time.ValueChanged += ValuesChanged;
            this.times.Add(time);
            this.ChangeAddButtonPosition();

            if(bcTime == null)
                this.ListChanged?.Invoke();
        }

        private void ChangeAddButtonPosition()
        {
            this.dailyAdd.Location = new System.Drawing.Point(6 + (this.times.Count % 4) * 120, 6 + (this.times.Count / 4) * 100);

            if (this.times.Count >= this.maxTimes)
            {
                this.dailyAdd.Visible = false;
            }
            else
            {
                this.dailyAdd.Visible = true;
            }
        }

        public void RemoveTime(int index)
        {
            for (int i = index + 1; i < this.times.Count; i++)
            {
                this.times[i].ChangeIndex(i - 1);
            }

            this.times.RemoveAt(index);
            this.ChangeAddButtonPosition();
            this.ListChanged?.Invoke();
        }

        public void ValidateFirstDay()
        {
            if (this.times.Count <= 0)
                return;

            DailyOneTime first = this.times[0];
            foreach (DailyOneTime item in this.times)
            {
                if (item.GetTime < first.GetTime)
                {
                    first = item;
                }
                item.Unlock();
            }

            first.LockAsFirstBackup();
        }
    }
}
