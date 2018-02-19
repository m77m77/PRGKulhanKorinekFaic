using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using AdminApp.Models.Settings;

namespace AdminApp.Components
{
    public class OneDay
    {
        public event Action ListChanged;
        private Button dayButton;
        private DayTimesPanel panel;

        private TabPage tab;
        private BackupCalendar parent;

        public bool HasBackupTimes
        {
            get { return panel.ItemCount > 0; }
        }


        public OneDay(BackupCalendar parent,Point pos,Form_NewMenu form,string text,TabPage page)
        {
            this.tab = page;
            this.parent = parent;
            this.dayButton = new Button();


            this.dayButton.BackColor = System.Drawing.Color.White;
            this.dayButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.dayButton.FlatAppearance.BorderSize = 2;
            this.dayButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.dayButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.dayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dayButton.Location = pos;
            this.dayButton.Name = "dayButton";
            this.dayButton.Size = new System.Drawing.Size(60, 60);
            this.dayButton.TabIndex = 31;
            this.dayButton.Text = text;
            this.dayButton.UseVisualStyleBackColor = false;
            this.dayButton.Click += DayButton_Click;

            page.Controls.Add(this.dayButton);

            panel = new DayTimesPanel(form);
            panel.Panel.Visible = false;
            panel.ListChanged += this.PanelChanged;
        }

        public void LoadSettings(BackupTime bcTime)
        {
            this.panel.AddTime(bcTime);
            this.PanelChanged();
        }

        public void SaveSettings(List<BackupTime> bcTimes,int dayNum)
        {
            this.panel.SaveSettings(bcTimes, dayNum);
        }

        private void PanelChanged()
        {
            this.PanelChanged(false);
        }

        private void PanelChanged(bool isLoading)
        {
            if (panel.ItemCount > 0)
            {
                this.dayButton.BackColor = Color.DeepSkyBlue;
                this.dayButton.FlatAppearance.MouseOverBackColor = Color.DeepSkyBlue;
            }
            else
            {
                this.dayButton.BackColor = Color.White;
                this.dayButton.FlatAppearance.MouseOverBackColor = Color.White;
            }

            if(!isLoading)
                this.ListChanged?.Invoke();
        }

        private void DayButton_Click(object sender, EventArgs e)
        {
            if(panel.Panel.Visible)
            {
                HidePanel();
            }
            else
            {
                Point cursorLoc = panel.Panel.FindForm().PointToClient(Cursor.Position);
                panel.Panel.Location = cursorLoc.Y > 250 ? new Point(cursorLoc.X, cursorLoc.Y - 240) : cursorLoc;
                ShowPanel();
            }
        }

        public void HidePanel()
        {
            panel.Panel.Visible = false;
        }

        public void ShowPanel()
        {
            this.parent.HidePanels();
            panel.Panel.Visible = true;
        }

        public void ValidateFirstDay(bool isFirstDay)
        {
            this.panel.ValidateFirstDay(isFirstDay);
        }
        }
}
