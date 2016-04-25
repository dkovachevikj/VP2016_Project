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
            btnOK.FlatAppearance.MouseOverBackColor = Color.FromArgb(235, 235, 224);
            btnCancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(235, 235, 224);
            btnOK.FlatAppearance.MouseDownBackColor = Color.FromArgb(214, 214, 194);
            btnCancel.FlatAppearance.MouseDownBackColor = Color.FromArgb(214, 214, 194);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            User = SqlConn.SignIn(tbName.Text);
            if (User == null)
            {
                MessageBox.Show("Ne postoi takov username!");
            }
            else
            {
                if (User.Password == tbPassword.Text)
                {
                    loadRentedMovies();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Pogresena lozinka!");
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

        private async void loadRentedMovies()
        {
            Movie movie = null;
            foreach (string s in User.mID)
            {
                movie = await LoadMovies.GetMovie(int.Parse(s), new CancellationToken());
                User.Movies.Add(new CustomMovie(movie));
            }
        }
    }
}
