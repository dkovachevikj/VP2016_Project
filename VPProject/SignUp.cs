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
    partial class SignUp : Form
    {
        public User User { get; set; }

        public SignUp()
        {
            InitializeComponent();
        }

        private void tbName_Validating(object sender, CancelEventArgs e)
        {
            if (tbName.Text.Trim().Length == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbName, "Името е задолжително!");
            }
            else
            {
                errorProvider1.SetError(tbName, null);
            }
        }

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            if (tbPassword.Text.Trim().Length == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbPassword, "Лозинката е задолжителна!");
            }
            else if (tbPassword.Text.Trim().Length > 10)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbPassword, "Лозиката може да содржи најмногу 10 карактери");
            }
            else
            {
                errorProvider1.SetError(tbPassword, null);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            User = new User(tbUsername.Text,tbPassword.Text,tbName.Text,tbPrezime.Text,tbEmail.Text,"");
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbPrezime_Validating(object sender, CancelEventArgs e)
        {
            if (tbPrezime.Text.Trim().Length == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbPrezime, "Презимето е задолжително!");
            }
            else
            {
                errorProvider1.SetError(tbPrezime, null);
            }
        }
    }
}
