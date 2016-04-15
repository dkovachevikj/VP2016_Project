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
            btnOK.FlatAppearance.MouseOverBackColor = Color.FromArgb(241, 230, 218);
            btnCancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(241, 230, 218);
            lblEmail.Parent = pictureBox1;
            lblMandatory.Parent = pictureBox1;
            lblName.Parent = pictureBox1;
            lblPassword.Parent = pictureBox1;
            lblRegister.Parent = pictureBox1;
            lblRepeatPassword.Parent = pictureBox1;
            lblSurname.Parent = pictureBox1;
            lblUsername.Parent = pictureBox1;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            User = new User(tbUsername.Text, tbPassword.Text, tbName.Text, tbSurname.Text, tbEmail.Text, "");
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbName_Enter(object sender, EventArgs e)
        {
            tbName.BackColor = Color.FromArgb(255, 255, 230);
        }

        private void tbName_Leave(object sender, EventArgs e)
        {
            tbName.BackColor = Color.White;
        }

        private void tbSurname_Enter(object sender, EventArgs e)
        {
            tbSurname.BackColor = Color.FromArgb(255, 255, 230);
        }

        private void tbSurname_Leave(object sender, EventArgs e)
        {
            tbSurname.BackColor = Color.White;
        }

        private void tbUsername_Enter(object sender, EventArgs e)
        {
            tbUsername.BackColor = Color.FromArgb(255, 255, 230);
        }

        private void tbUsername_Leave(object sender, EventArgs e)
        {
            tbUsername.BackColor = Color.White;
        }

        private void tbEmail_Enter(object sender, EventArgs e)
        {
            tbEmail.BackColor = Color.FromArgb(255, 255, 230);
            if(tbEmail.Text.Trim().Length == 0 || tbEmail.Text.Equals("user@example.com"))
            {
                tbEmail.Text = "";
                tbEmail.ForeColor = Color.Black;
            }
        }

        private void tbEmail_Leave(object sender, EventArgs e)
        {
            tbEmail.BackColor = Color.White;
        }

        private void tbPassword_Enter(object sender, EventArgs e)
        {
            tbPassword.BackColor = Color.FromArgb(255, 255, 230);
        }

        private void tbPassword_Leave(object sender, EventArgs e)
        {
            tbPassword.BackColor = Color.White;
        }

        private void tbRepeatPassword_Enter(object sender, EventArgs e)
        {
            tbRepeatPassword.BackColor = Color.FromArgb(255, 255, 230);
        }

        private void tbRepeatPassword_Leave(object sender, EventArgs e)
        {
            tbRepeatPassword.BackColor = Color.White;
        }

        private void tbName_Validating(object sender, CancelEventArgs e)
        {
            if(tbName.Text.Trim().Length == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbName, "Името е задолжително");
            }
            else
            {
                errorProvider1.SetError(tbName, null);
            }
        }

        private void tbSurname_Validating(object sender, CancelEventArgs e)
        {
            if(tbSurname.Text.Trim().Length == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbSurname, "Презимето е задолжително");
            }
            else
            {
                errorProvider1.SetError(tbSurname, null);
            }
        }

        private void tbUsername_Validating(object sender, CancelEventArgs e)
        {
            if(tbUsername.Text.Trim().Length == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbUsername, "Корисничкото име е задолжително");
            }
            else
            {
                errorProvider1.SetError(tbUsername, null);
            }
        }

        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {
            if(!IsValidEmail(tbEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbEmail, "Невалидна е-пошта (треба да биде во облик user@example.com)");
            }
            else
            {
                errorProvider1.SetError(tbEmail, null);
            }
        }

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            if(tbPassword.Text.Trim().Length == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbPassword, "Лозинката е задолжителна! (duh)");
            }
            else
            {
                errorProvider1.SetError(tbPassword, null);
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void tbRepeatPassword_Validating(object sender, CancelEventArgs e)
        {
            if(!tbRepeatPassword.Text.Equals(tbPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbRepeatPassword, "Не се совпаѓа со внесената лозинка");
            }
            else
            {
                errorProvider1.SetError(tbRepeatPassword, null);
            }
        }
    }
}
