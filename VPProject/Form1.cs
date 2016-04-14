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
    public partial class Form1 : Form
    {
        private List<Movie> Movies { get; }
        private User LoggedUser { get; set; }

        public Form1()
        {
            InitializeComponent();
            panelMovie.Hide();
            btnDeleteMovie.Enabled = false;
            Movies = new List<Movie>();
            panelUser.Hide();
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

        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            AddMovie newMovie = new AddMovie();
            if (newMovie.ShowDialog() == DialogResult.OK)
            {
                Movies.Add(newMovie.Movie);
                lbMovies.Items.Add(newMovie.Movie);
            }
        }

        private void lbMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbMovies.SelectedIndex != -1)
            {
                btnDeleteMovie.Enabled = true;
                Movie movie = lbMovies.SelectedItem as Movie;
                lblMovieTitle.Text = movie.Title;
                lblMovieYear.Text = movie.Year.ToString();
                lblMovieDesc.Text = movie.Description;
                panelMovie.Show();
            }
            else
            {
                btnDeleteMovie.Enabled = false;
                panelMovie.Hide();
            }
        }

        private void btnDeleteMovie_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Дали сте сигурни дека сакате да го избришете филмот?", "Избриши филм", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Movies.Remove(lbMovies.SelectedItem as Movie);
                lbMovies.Items.Remove(lbMovies.SelectedItem);

            }
        }

        private void cbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbMovies.Items.Clear();
            if (cbSort.SelectedIndex == 0)
            {
                Movies.Sort();
                foreach (Movie m in Movies)
                {
                    lbMovies.Items.Add(m);
                }
            }
            if (cbSort.SelectedIndex == 1)
            {
                Movies.Sort(new MovieYearComparer());
                foreach (Movie m in Movies)
                {
                    lbMovies.Items.Add(m);
                }
            }
        }

        private void lbSignOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Дали сте сигурни дека сакате да се одјавите?", "Одјави се", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoggedUser = null;
                panelUser.Hide();
            }
        }
    }
}
