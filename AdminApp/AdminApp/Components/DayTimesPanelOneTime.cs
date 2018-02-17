using AdminApp.Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminApp.Components
{
    public class DayTimesPanelOneTime
    {
        private DateTimePicker timePicker;
        public TimeSpan GetTime
        {
            get { return timePicker.Value.TimeOfDay; }
        }

        public event Action TimeChanged;

        private ComboBox selectType;
        private Button remove;

        private DayTimesPanel parent;
        private int currentIndex;

        public DayTimesPanelOneTime(DayTimesPanel parent,int index)
        {
            this.currentIndex = index;
            this.parent = parent;
            this.timePicker = new DateTimePicker();
            this.selectType = new ComboBox();
            this.remove = new Button();

            // 
            // timePicker
            // 
            this.timePicker.CustomFormat = "HH:mm";
            this.timePicker.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timePicker.Location = new System.Drawing.Point(3, 3 + (index * 30));
            this.timePicker.Name = "timePicker";
            this.timePicker.ShowUpDown = true;
            this.timePicker.Size = new System.Drawing.Size(57, 25);
            this.timePicker.TabIndex = 33;
            this.timePicker.ValueChanged += TimePicker_ValueChanged;
            // 
            // selectType
            // 
            this.selectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.selectType.FormattingEnabled = true;
            this.selectType.Items.AddRange(new object[] {
            "Full",
            "Incremental",
            "Differential"});
            this.selectType.SelectedIndex = 0;
            this.selectType.Location = new System.Drawing.Point(66, 3 + (index * 30));
            this.selectType.Name = "selectType";
            this.selectType.Size = new System.Drawing.Size(85, 25);
            this.selectType.TabIndex = 33;
            this.selectType.SelectedValueChanged += TimePicker_ValueChanged;
            // 
            // remove
            // 
            this.remove.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.remove.Location = new System.Drawing.Point(157, 3 + (index * 30));
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(25, 25);
            this.remove.TabIndex = 34;
            this.remove.Text = "-";
            this.remove.Click += Remove_Click;
            this.remove.UseVisualStyleBackColor = true;


            //ADD TO PANEL
            parent.Panel.Controls.Add(this.timePicker);
            parent.Panel.Controls.Add(this.selectType);
            parent.Panel.Controls.Add(this.remove);
        }

        public void LoadSettings(BackupTime bcTime)
        {
            this.timePicker.Value = new DateTime(2000, 1, 1,bcTime.Time.Hours, bcTime.Time.Minutes, bcTime.Time.Seconds);

            if (bcTime.Type == "FULL")
            {
                this.selectType.SelectedIndex = 0;
            }
            else if (bcTime.Type == "INC")
            {
                this.selectType.SelectedIndex = 1;
            }
            else if (bcTime.Type == "DIFF")
            {
                this.selectType.SelectedIndex = 2;
            }
        }

        public void SaveSettings(BackupTime bcTime)
        {
            bcTime.Time = this.GetTime;
            if (this.selectType.SelectedIndex == 0)
            {
                bcTime.Type = "FULL";
            }
            else if (this.selectType.SelectedIndex == 1)
            {
                bcTime.Type = "INC";
            }
            else if (this.selectType.SelectedIndex == 2)
            {
                bcTime.Type = "DIFF";
            }
        }

        private void TimePicker_ValueChanged(object sender, EventArgs e)
        {
            this.TimeChanged?.Invoke();
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            this.parent.Panel.Controls.Remove(this.selectType);
            this.parent.Panel.Controls.Remove(this.timePicker);
            this.parent.Panel.Controls.Remove(this.remove);
            this.parent.RemoveTime(this.currentIndex);
        }

        public void ChangeIndex(int index)
        {
            this.currentIndex = index;
            this.timePicker.Location = new System.Drawing.Point(3, 3 + (index * 30));
            this.selectType.Location = new System.Drawing.Point(66, 3 + (index * 30));
            this.remove.Location = new System.Drawing.Point(157, 3 + (index * 30));
        }

        public void LockAsFirstBackup()
        {
            this.selectType.SelectedIndex = 0;
            this.selectType.Enabled = false;
        }

        public void Unlock()
        {
            this.selectType.Enabled = true;
        }
    }
}
