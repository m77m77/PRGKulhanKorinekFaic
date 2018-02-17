using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminApp.Components
{
    public class DailyOneTime
    {
        private DateTimePicker dailyTime;
        private Button dailyRemove;
        private ComboBox dailySelectType;

        public TimeSpan GetTime
        {
            get { return this.dailyTime.Value.TimeOfDay; }
        }

        public event Action ValueChanged;
        private Daily parent;
        private int currentIndex;

        public DailyOneTime(int index,TabPage page,Daily daily)
        {
            this.parent = daily;
            this.currentIndex = index;
            this.dailyTime = new DateTimePicker();
            this.dailyRemove = new Button();
            this.dailySelectType = new ComboBox();

            this.dailyTime.CustomFormat = "HH:mm";
            this.dailyTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dailyTime.Location = new System.Drawing.Point(6 + (index % 4) * 120, 6 + (index / 4) * 100);
            this.dailyTime.Name = "dailyTime";
            this.dailyTime.ShowUpDown = true;
            this.dailyTime.Size = new System.Drawing.Size(117, 29);
            this.dailyTime.TabIndex = 1;
            this.dailyTime.ValueChanged += TimeOrComboBoxChanged;

            this.dailyRemove.Location = new System.Drawing.Point(6 + (index % 4) * 120, 76 + (index / 4) * 100);
            this.dailyRemove.Name = "dailyRemove";
            this.dailyRemove.Size = new System.Drawing.Size(117, 29);
            this.dailyRemove.TabIndex = 68;
            this.dailyRemove.Text = "-";
            this.dailyRemove.UseVisualStyleBackColor = true;
            this.dailyRemove.Click += DailyRemove_Click;

            this.dailySelectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dailySelectType.FormattingEnabled = true;
            this.dailySelectType.Items.AddRange(new object[] {
            "Full",
            "Incremental",
            "Differential"});
            this.dailySelectType.SelectedIndex = 0;
            this.dailySelectType.Location = new System.Drawing.Point(6 + (index % 4) * 120, 41 + (index / 4) * 100);
            this.dailySelectType.Name = "dailySelectType";
            this.dailySelectType.Size = new System.Drawing.Size(117, 29);
            this.dailySelectType.TabIndex = 17;
            this.dailySelectType.SelectedIndexChanged += TimeOrComboBoxChanged;

            page.Controls.Add(this.dailyTime);
            page.Controls.Add(this.dailySelectType);
            page.Controls.Add(this.dailyRemove);
        }

        private void DailyRemove_Click(object sender, EventArgs e)
        {
            parent.Parent.Controls.Remove(this.dailyTime);
            parent.Parent.Controls.Remove(this.dailySelectType);
            parent.Parent.Controls.Remove(this.dailyRemove);
            parent.RemoveTime(currentIndex);
        }

        private void TimeOrComboBoxChanged(object sender, EventArgs e)
        {
            this.ValueChanged?.Invoke();
        }

        public void ChangeIndex(int index)
        {
            this.currentIndex = index;
            this.dailySelectType.Location = new System.Drawing.Point(6 + (index % 4) * 120, 41 + (index / 4) * 100);
            this.dailyRemove.Location = new System.Drawing.Point(6 + (index % 4) * 120, 76 + (index / 4) * 100);
            this.dailyTime.Location = new System.Drawing.Point(6 + (index % 4) * 120, 6 + (index / 4) * 100);
        }

        public void LockAsFirstBackup()
        {
            this.dailySelectType.SelectedIndex = 0;
            this.dailySelectType.Enabled = false;
        }

        public void Unlock()
        {
            this.dailySelectType.Enabled = true;
        }
    }
}
