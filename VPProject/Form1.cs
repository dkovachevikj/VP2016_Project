using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.TMDb;

namespace VPProject
{
    public partial class Form1 : Form
    {
        private User LoggedUser { get; set; }
        private string TrailerPath { get; set; }
        private List<CustomMovie> beginMovies { get; set; }

        public Form1()
        {
            InitializeComponent();
            panelMovie.Hide();
            panelUser.Hide();
            loadMovies();
            TrailerPath = "";
            beginMovies = new List<CustomMovie>();
        }

        private async void loadMovies()
        {
            var movies = await LoadMovies.TopRated(new CancellationToken());
            foreach (CustomMovie cm in movies)
            {
                lbMovies.Items.Add(cm);
                beginMovies.Add(cm);
            }
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            SignIn signIn = new SignIn();
            if (signIn.ShowDialog() == DialogResult.OK)
            {
                LoggedUser = signIn.User;
                panelUser.Show();
                lblUsername.Text = LoggedUser.Username;
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            if (signUp.ShowDialog() == DialogResult.OK)
            {
                SqlConn.SignUp(signUp.User);
            }
        }

        private void lbMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbMovies.SelectedIndex != -1)
            {
                CustomMovie cm = lbMovies.SelectedItem as CustomMovie;
                lblMovieTitle.Text = string.Format("{0} ({1:0.00})", cm.Movie.Title, cm.Movie.VoteAverage);
                pbPoster.ImageLocation = "http://image.tmdb.org/t/p/w500" + cm.Movie.Poster;
                lblDescription.Text = cm.Movie.Overview;
                panelMovie.Show();
            }
            else
            {
                panelMovie.Hide();
            }
        }

        private void cbSort_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbSignOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Дали сте сигурни дека сакате да се одјавите?", "Одјави се", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoggedUser = null;
                panelUser.Hide();
            }
        }

        private void lblUsername_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Име: "+LoggedUser.Ime+"\n");
            sb.Append("Презиме: "+LoggedUser.Prezime+"\n");
            sb.Append("Е-маил: "+LoggedUser.Email+"\n");
            MessageBox.Show(sb.ToString());
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            lbMovies.Items.Clear();
            if(tbSearch.Text.Trim().Length == 0)
            {
                foreach(CustomMovie cm in beginMovies)
                {
                    lbMovies.Items.Add(cm);
                }
            }
            else
            {
                panelMovie.Hide();
                var movies = await LoadMovies.SearchMovies(tbSearch.Text, new CancellationToken());
                foreach(CustomMovie cm in movies)
                {
                    lbMovies.Items.Add(cm);
                }
            }
        }
    }
}
