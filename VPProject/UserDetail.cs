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
    public partial class UserDetail : Form
    {
        public User user { get; set; }
        public UserDetail(User user)
        {
            InitializeComponent();
            this.user = user;
            lblIme.Text += " " + user.Ime;
            lblPrezime.Text += " " + user.Prezime;
            lblEmail.Text += " " + user.Email;
            lbKosnicka.Items.Clear();
            if (user.Movies.Count > 0)
                loadRentedMovies();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private async void loadRentedMovies()
        {
            Movie movie = null;
            foreach (string s in user.Movies)
            {
                movie = await LoadMovies.GetMovie(int.Parse(s), new CancellationToken());
                lbKosnicka.Items.Add(new CustomMovie(movie));
            }
        }
    }
}
