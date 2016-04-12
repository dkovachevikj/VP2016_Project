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
    partial class AddMovie : Form
    {
        public Movie Movie { get; set; }

        public AddMovie()
        {
            InitializeComponent();
        }

        private void tbTitle_Validating(object sender, CancelEventArgs e)
        {
            if(tbTitle.Text.Trim().Length == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbTitle, "Сите полиња се задолжителни");
            }
            else
            {
                errorProvider1.SetError(tbTitle, null);
            }
        }

        private void tbYear_Validating(object sender, CancelEventArgs e)
        {
            if(tbYear.Text.Trim().Length == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbYear, "Сите полиња се задолжителни");
            }
            else
            {
                int year;
                if(int.TryParse(tbYear.Text, out year))
                {
                    errorProvider1.SetError(tbYear, null);
                }
                else
                {
                    e.Cancel = true;
                    errorProvider1.SetError(tbYear, "Годината мора да се состои од бројки! (duh)");
                }
            }
        }

        private void tbDescription_Validating(object sender, CancelEventArgs e)
        {
            if(tbDescription.Text.Trim().Length == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbDescription, "Сите полиња се задолжителни");
            }
            else
            {
                errorProvider1.SetError(tbDescription, null);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Movie = new Movie(tbTitle.Text, tbDescription.Text, int.Parse(tbYear.Text));
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
