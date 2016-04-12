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
        public Dictionary<string, User> Users { get; set; }

        public SignUp(Dictionary<string, User> users)
        {
            InitializeComponent();
            Users = users;
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

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            if(tbPassword.Text.Trim().Length == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbPassword, "Лозинката е задолжителна");
            }
            else if(tbPassword.Text.Trim().Length > 10)
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
            if(Users.ContainsKey(tbName.Text))
            {
                MessageBox.Show("Корисничкото име веќе постои!");
                tbName.ResetText();
                tbPassword.ResetText();
            }
            else
            {
                User = new User(tbName.Text, tbPassword.Text);
                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
