﻿using System;
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
            setUI();
        }

        private void setUI()
        {
            btnOK.FlatAppearance.MouseOverBackColor = Color.FromArgb(235, 235, 224);
            btnCancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(235, 235, 224);
            btnOK.FlatAppearance.MouseDownBackColor = Color.FromArgb(214, 214, 194);
            btnCancel.FlatAppearance.MouseDownBackColor = Color.FromArgb(214, 214, 194);
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
            bwSignUp.RunWorkerAsync();
            btnOK.Enabled = false;
            btnCancel.Enabled = false;
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
                errorProvider1.SetError(tbName, "Name is required");
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
                errorProvider1.SetError(tbSurname, "Surname is required");
            }
            else
            {
                errorProvider1.SetError(tbSurname, null);
            }
        }

        private async void tbUsername_Validating(object sender, CancelEventArgs e)
        {
            if(tbUsername.Text.Trim().Length == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbUsername, "Username is required");
            }
            else
            {
                bool userExists = await SqlConn.userExists(tbUsername.Text);
                if(userExists)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(tbUsername, "Username already exists, please try again");
                }
                else
                {
                    errorProvider1.SetError(tbUsername, null);
                }
            }
        }

        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {
            if(!IsValidEmail(tbEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbEmail, "Invalid e-mail (it should look like user@example.com)");
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
                errorProvider1.SetError(tbPassword, "Password is required! (duh)");
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
                errorProvider1.SetError(tbRepeatPassword, "Passwords don't match");
            }
            else
            {
                errorProvider1.SetError(tbRepeatPassword, null);
            }
        }

        private void bwSignUp_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = SqlConn.SignUp(new User(tbUsername.Text, tbPassword.Text, tbName.Text, tbSurname.Text, tbEmail.Text, ""));
        }

        private void bwSignUp_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Sign up error: " + e.Error.ToString());
            }
            else
            {
                bool result = (bool)e.Result;
                if(result)
                {
                    MessageBox.Show("You have successfully registered!");
                    Close();
                }
                else
                {
                    MessageBox.Show("Registration failed");
                    btnCancel.Enabled = true;
                    btnOK.Enabled = true;
                }
            }
        }

        private void bwUserExists_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void bwUserExists_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}
