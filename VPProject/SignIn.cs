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
    partial class SignIn : Form
    {
        public User User { get; set; }

        public SignIn()
        {
            InitializeComponent();
            lblNajava.Parent = pictureBox1;
            lblPassword.Parent = pictureBox1;
            lblUsername.Parent = pictureBox1;
            setColors();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bwSignIn.RunWorkerAsync();
            btnOK.Enabled = false;
            btnCancel.Enabled = false;
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

        private void tbName_Enter(object sender, EventArgs e)
        {
            tbName.BackColor = Color.FromArgb(255, 255, 230);
        }

        private void tbName_Leave(object sender, EventArgs e)
        {
            tbName.BackColor = Color.White;
        }

        private void tbPassword_Enter(object sender, EventArgs e)
        {
            tbPassword.BackColor = Color.FromArgb(255, 255, 230);
        }

        private void tbPassword_Leave(object sender, EventArgs e)
        {
            tbPassword.BackColor = Color.White;
        }

        private void bwSignIn_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = SqlConn.SignIn(tbName.Text);
        }

        private void bwSignIn_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnOK.Enabled = true;
            btnCancel.Enabled = true;
            if(e.Error != null)
            {
                MessageBox.Show("Sign in error: " + e.Error.ToString());
            }
            else
            {
                User tempUser = e.Result as User;
                if (tempUser == null)
                {
                    MessageBox.Show("Username doesn't exist", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (tempUser.Password.Equals(tbPassword.Text))
                    {
                        User = tempUser;
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Invalid password!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
    }
}
