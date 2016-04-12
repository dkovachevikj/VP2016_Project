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
    partial class SignIn : Form
    {
        public User User { get; set; }
        public Dictionary<string, User> Users { get; set; }

        public SignIn(Dictionary<string, User> users)
        {
            Users = users;
            InitializeComponent();
        }

        private void tbName_Validating(object sender, CancelEventArgs e)
        {
            if(tbName.Text.Trim().Length == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbName, "Полињата се задолжителни");
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
                errorProvider1.SetError(tbPassword, "Полињата се задолжителни");
            }
            else
            {
                errorProvider1.SetError(tbPassword, null);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(!Users.ContainsKey(tbName.Text))
            {
                MessageBox.Show("Не постои корисник со даденото име!");
                tbName.ResetText();
                tbPassword.ResetText();
            }
            else
            {
                User user = null;
                Users.TryGetValue(tbName.Text, out user);
                if(!tbPassword.Text.Equals(user.Password))
                {
                    MessageBox.Show("Погрешна лозинка!");
                    tbPassword.ResetText();
                }
                else
                {
                    User = user;
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
