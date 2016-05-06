using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.TMDb;
using System.Threading;

namespace VPProject
{
    public partial class UserDetail : Form
    {
        public User user { get; set; }
        private DateTime tempDate;
        private Label tempLabel;
        private int day;
        private int hr;
        private int min;
        private int second;
        private string[] timeParts;
        private char[] separator;
        private TimeSpan span;

        public UserDetail(User user)
        {
            InitializeComponent();
            this.user = user;
            lblIme.Text += " " + user.Name;
            lblPrezime.Text += " " + user.Surname;
            lblEmail.Text += " " + user.Email;
            day = 9;
            fillTable();
            tempDate = DateTime.Now;
            tempLabel = null;
            span = TimeSpan.Zero;
            timer1.Enabled = true;
            setBtns();
            panelMovies.Hide();
            separator = new char[] { ':' };
        }

        /// <summary>
        /// Set button design
        /// </summary>
        private void setBtns()
        {
            btnReturnMovies.FlatAppearance.MouseOverBackColor = Color.FromArgb(235, 235, 224);
            btnReturnMovies.FlatAppearance.MouseDownBackColor = Color.FromArgb(214, 214, 194);
            btnReturn.FlatAppearance.MouseOverBackColor = Color.FromArgb(235, 235, 224);
            btnReturn.FlatAppearance.MouseDownBackColor = Color.FromArgb(214, 214, 194);
            btnCancelReturn.FlatAppearance.MouseOverBackColor = Color.FromArgb(235, 235, 224);
            btnCancelReturn.FlatAppearance.MouseDownBackColor = Color.FromArgb(214, 214, 194);
        }

        /// <summary>
        /// Since there's no cancel button on the form, this method is used to check whether the user pushed the Esc key to close the form
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Close();
                DialogResult = DialogResult.Cancel;
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Fills the table with rented movies and the time remaining for each movie
        /// </summary>
        private void fillTable()
        {
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel1.Controls.Clear();
            while(tableLayoutPanel1.RowCount > 2)
            {
                int row = tableLayoutPanel1.RowCount - 1;
                tableLayoutPanel1.RowStyles.RemoveAt(row);
                tableLayoutPanel1.RowCount--;
            }
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Movie", Font = new Font(Font, FontStyle.Bold), Anchor = AnchorStyles.Left}, 0, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Remaining time", Font = new Font(Font, FontStyle.Bold), Anchor = AnchorStyles.Right }, 1, 0);
            lbRentedMovies.Items.Clear();
            if(user.Movies.Count > 0)
            {
                int row = 1;
                foreach (KeyValuePair<string, string> kvp in user.Movies)
                {
                    tableLayoutPanel1.RowCount += 1;
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25));
                    tempDate = DateTime.ParseExact(kvp.Value, "dd/MM/yyyy HH:mm:ss", null);
                    TimeSpan ts = tempDate.Subtract(DateTime.Now);
                    int seconds = ts.Seconds;
                    tableLayoutPanel1.Controls.Add(new Label() { Text = kvp.Key, Anchor = AnchorStyles.Left, AutoSize = true}, 0, row);
                    tableLayoutPanel1.Controls.Add(new Label() { Text = TimeSpan.FromSeconds(ts.TotalSeconds).ToString(@"dd\:hh\:mm\:ss"),  Anchor = AnchorStyles.Right}, 1, row);
                    row++;
                    lbRentedMovies.Items.Add(kvp.Key);
                }
                btnReturnMovies.Enabled = true;
                btnReturn.Enabled = false;
            }
            else
            {
                btnReturnMovies.Enabled = false;
            }
            tableLayoutPanel1.ResumeLayout();
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            checkTime();
        }

        /// <summary>
        /// Checks the rental for all movies, and informs the user if a rental expired (also removes it from the collection of rented movies)
        /// </summary>
        private void checkTime()
        {
            if (user.Movies.Count > 0)
            {
                tableLayoutPanel1.SuspendLayout();

                for (int i = 1; i < tableLayoutPanel1.RowCount - 1; i++)
                {
                    tempLabel = tableLayoutPanel1.GetControlFromPosition(1, i) as Label;
                    if (!tempLabel.ForeColor.Equals(Color.Orange))
                    {
                        if (tempLabel.Text.Equals("00:00:00:00"))
                        {
                            timer1.Enabled = false;
                            Label title = tableLayoutPanel1.GetControlFromPosition(0, i) as Label;
                            user.Movies.Remove(title.Text);
                            NotifyIcon icon = new NotifyIcon();
                            icon.Visible = true;
                            icon.Icon = SystemIcons.Information;
                            icon.ShowBalloonTip(3000, "Cinematique", string.Format("Your rental for {0} has expired", title.Text), ToolTipIcon.Info);
                            tempLabel.ForeColor = Color.Orange;
                            Label titleLabel = tableLayoutPanel1.GetControlFromPosition(0, i) as Label;
                            user.Movies.Remove(titleLabel.Text);
                            lbRentedMovies.Items.Remove(titleLabel.Text);
                            titleLabel.ForeColor = Color.Orange;
                            tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(0, i));
                            tableLayoutPanel1.Controls.Add(titleLabel, 0, i);
                            timer1.Enabled = true;
                            return;
                        }
                        else
                        {
                            timeParts = tempLabel.Text.Split(separator);
                            day = int.Parse(timeParts[0]);
                            hr = int.Parse(timeParts[1]);
                            min = int.Parse(timeParts[2]);
                            second = int.Parse(timeParts[3]);
                            setFields();
                        }

                        tempLabel.Text = string.Format("{0}:{1}:{2}:{3}", day.ToString("D2"), hr.ToString("D2"), min.ToString("D2"), second.ToString("D2"));
                    }

                    tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(1, i));

                    tableLayoutPanel1.Controls.Add(tempLabel, 1, i);
                }

                tableLayoutPanel1.ResumeLayout();
            }
        }

        private void UserDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
        }

        private void UserDetail_Load(object sender, EventArgs e)
        {
            this.tableLayoutPanel1.CellPaint += new TableLayoutCellPaintEventHandler(tableLayoutPanel1_CellPaint);
        }

        void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
                Graphics g = e.Graphics;
                Rectangle r = e.CellBounds;
                g.FillRectangle(new SolidBrush(Color.Blue), r);
        }

        private void btnReturnMovies_Click(object sender, EventArgs e)
        {
            panelMovies.Show();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if(lbRentedMovies.SelectedItems.Count > 0)
            {  
                foreach (object o in lbRentedMovies.SelectedItems)
                {
                    user.Movies.Remove(o.ToString());
                }
                fillTable();
            }
            panelMovies.Hide();
        }

        private void btnCancelReturn_Click(object sender, EventArgs e)
        {
            panelMovies.Hide();
        }

        private void lbRentedMovies_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            bool isItemSelected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);
            int itemIndex = e.Index;
            if (itemIndex >= 0 && itemIndex < lbRentedMovies.Items.Count)
            {
                Graphics g = e.Graphics;

                SolidBrush backgroundColorBrush = new SolidBrush((isItemSelected) ? Color.FromArgb(194, 194, 163) : SystemColors.WindowFrame);
                g.FillRectangle(backgroundColorBrush, e.Bounds);

                string itemText = lbRentedMovies.Items[itemIndex].ToString();

                SolidBrush itemTextColorBrush = (isItemSelected) ? new SolidBrush(Color.Black) : new SolidBrush(Color.White);
                g.DrawString(itemText, e.Font, itemTextColorBrush, lbRentedMovies.GetItemRectangle(itemIndex).Location);

                backgroundColorBrush.Dispose();
                itemTextColorBrush.Dispose();
            }

            e.DrawFocusRectangle();
        }

        private void UserDetail_Load_1(object sender, EventArgs e)
        {
            lbRentedMovies.DrawMode = DrawMode.OwnerDrawFixed;
        }

        private void lbRentedMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lbRentedMovies.SelectedItems.Count > 0)
            {
                btnReturn.Enabled = true;
            }
            else
            {
                btnReturn.Enabled = false;
            }
        }

        /// <summary>
        /// Update rent times
        /// </summary>
        private void setFields()
        {
            if (day == 0)
            {
                if (hr == 0)
                {
                    if (min == 0)
                    {
                        second--;
                    }
                    else
                    {
                        if (second == 0)
                        {
                            min--;
                            second = 59;
                            return;
                        }
                        else
                        {
                            second--;
                        }
                    }
                }
                else
                {
                    if (min == 0)
                    {
                        if (second == 0)
                        {
                            hr--;
                            min = 59;
                            second = 59;
                            return;
                        }
                        else
                        {
                            second--;
                        }
                    }
                    else
                    {
                        if (second == 0)
                        {
                            min--;
                            second = 59;
                        }
                        else
                        {
                            second--;
                        }
                    }
                }
            }
            else
            {
                if (hr == 0)
                {
                    if (min == 0)
                    {
                        if (second == 0)
                        {
                            day--;
                            hr = 23;
                            min = 59;
                            second = 59;
                            return;
                        }
                        else
                        {
                            second--;
                        }
                    }
                    else
                    {
                        if (second == 0)
                        {
                            min--;
                            second = 59;
                            return;
                        }
                        else
                        {
                            second--;
                        }
                    }
                }
                else
                {
                    if (min == 0)
                    {
                        if (second == 0)
                        {
                            hr--;
                            min = 59;
                            second = 59;
                            return;
                        }
                        else
                        {
                            second--;
                        }
                    }
                    else
                    {
                        if (second == 0)
                        {
                            min--;
                            second = 59;
                            return;
                        }
                        else
                        {
                            second--;
                        }
                    }
                }
            }
        }
    }
}
