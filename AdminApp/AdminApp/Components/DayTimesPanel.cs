using AdminApp.Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminApp.Components
{
    public class DayTimesPanel
    {
        public event Action ListChanged;
        public Panel Panel { get; private set; }
        private Button add;
        private List<DayTimesPanelOneTime> times;

        public int ItemCount
        {
            get { return times.Count; }
        }


        private int maxTimes = 8;

        public DayTimesPanel(Form_NewMenu form)
        {
            this.times = new List<DayTimesPanelOneTime>();
            this.Panel = new Panel();
            this.add = new Button();

            this.Panel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Panel.Location = new System.Drawing.Point(0, 0);
            this.Panel.Name = "dayBackupTimesSelectPanel";
            this.Panel.Size = new System.Drawing.Size(185, 240);
            this.Panel.TabIndex = 32;

            this.add.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.add.Location = new System.Drawing.Point(3, 3);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(179, 25);
            this.add.TabIndex = 33;
            this.add.Text = "+";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += Add_Click; 
            this.Panel.Controls.Add(this.add);

            form.Controls.Add(this.Panel);
            this.Panel.BringToFront();
        }

        public void SaveSettings(List<BackupTime> bcTimes, int dayNum)
        {
            foreach (DayTimesPanelOneTime item in this.times)
            {
                BackupTime bcTime = new BackupTime();
                bcTime.DayNumber = dayNum;

                item.SaveSettings(bcTime);

                bcTimes.Add(bcTime);
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            this.AddTime();
        }

        private void TimeChanged()
        {
            this.ListChanged?.Invoke();
        }

        public void AddTime(BackupTime bcTime = null)
        {
            DayTimesPanelOneTime time = new DayTimesPanelOneTime(this, this.times.Count);
            if(bcTime != null)
            {
                time.LoadSettings(bcTime);
            }
            time.TimeChanged += TimeChanged;
            this.times.Add(time);
            this.ChangeAddButtonPosition();

            if (bcTime == null)
                this.ListChanged?.Invoke();
        }

        private void ChangeAddButtonPosition()
        {
            this.add.Location = new System.Drawing.Point(3, 3 + (this.times.Count * 30));
            if (this.times.Count >= this.maxTimes)
            {
                this.add.Visible = false;
            }else
            {
                this.add.Visible = true;
            }
        }

        public void RemoveTime(int index)
        {
            for (int i = index+1; i < this.times.Count; i++)
            {
                this.times[i].ChangeIndex(i - 1);
            }

            this.times.RemoveAt(index);
            this.ChangeAddButtonPosition();
            this.ListChanged?.Invoke();
        }

        public void ValidateFirstDay(bool isFirstDay)
        {
            if (this.ItemCount <= 0)
                return;

            DayTimesPanelOneTime first = this.times[0];
            foreach (DayTimesPanelOneTime item in this.times)
            {
                if(item.GetTime < first.GetTime)
                {
                    first = item;
                }
                item.Unlock();
            }

            if (isFirstDay)
                first.LockAsFirstBackup();
        }
    }
}
