using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPProject
{
    public partial class RentTime : Form
    {
        public int Days { get; set; }

        public RentTime()
        {
            InitializeComponent();
            cbDays.SelectedIndex = 0;
            setColors();
        }

        private void setColors()
        {
            btnOK.FlatAppearance.MouseOverBackColor = Color.FromArgb(235, 235, 224);
            btnCancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(235, 235, 224);
            btnOK.FlatAppearance.MouseDownBackColor = Color.FromArgb(214, 214, 194);
            btnCancel.FlatAppearance.MouseDownBackColor = Color.FromArgb(214, 214, 194);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Days = int.Parse(cbDays.SelectedItem.ToString());
            DialogResult = DialogResult.OK;
        }

        private void RentTime_Load(object sender, EventArgs e)
        {
            cbDays.DrawMode = DrawMode.OwnerDrawFixed;
        }

        private void cbDays_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            ComboBox combo = sender as ComboBox;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(214, 214, 194)),
                                         e.Bounds);
            else
                e.Graphics.FillRectangle(new SolidBrush(combo.BackColor),
                                         e.Bounds);

            e.Graphics.DrawString(combo.Items[e.Index].ToString(), e.Font,
                                  new SolidBrush(combo.ForeColor),
                                  new Point(e.Bounds.X, e.Bounds.Y));

            e.DrawFocusRectangle();
        }
    }
}
