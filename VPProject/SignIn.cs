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
    partial class SignIn : Form
    {
        public User User { get; set; }
        public Dictionary<string, User> Users { get; set; }

        public SignIn(Dictionary<string, User> users)
        {
            Users = users;
            InitializeComponent();
            lblNajava.Parent = pictureBox1;
            lblPassword.Parent = pictureBox1;
            lblUsername.Parent = pictureBox1;
            btnOK.FlatAppearance.MouseOverBackColor = Color.FromArgb(241, 230, 218);
            btnCancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(241, 230, 218);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!Users.ContainsKey(tbName.Text))
            {
                MessageBox.Show("Не постои корисник со даденото име!");
                tbName.ResetText();
                tbPassword.ResetText();
            }
            else
            {
                User user = null;
                Users.TryGetValue(tbName.Text, out user);
                if (!tbPassword.Text.Equals(user.Password))
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
    }
}
