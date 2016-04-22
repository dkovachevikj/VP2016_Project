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
        private string currentSearchText { get; set; }
        private bool searchChanged { get; set; }
        private string currentGenre { get; set; }
        private bool genreChanged { get; set; }

        public Form1()
        {
            InitializeComponent();
            panelMovie.Hide();
            panelUser.Hide();
            loadMovies();
            TrailerPath = "";
            beginMovies = new List<CustomMovie>();
            setGenres();
        }

        private async void setGenres()
        {
            List<CustomGenre> genres = await LoadMovies.GetGenres(new CancellationToken());
            foreach(CustomGenre cg in genres)
            {
                cbGenre.Items.Add(cg);
            }
            cbGenre.SelectedIndex = 0;
            currentGenre = "All";
            genreChanged = false;
        }
        private async void loadMovies()
        {
            var movies = await LoadMovies.TopRated(new CancellationToken());
            foreach (CustomMovie cm in movies)
            {
                lbMovies.Items.Add(cm);
                beginMovies.Add(cm);
            }
            currentSearchText = "";
            searchChanged = false;
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            SignIn signIn = new SignIn();
            if (signIn.ShowDialog() == DialogResult.OK)
            {
                LoggedUser = signIn.User;
                panelUser.Show();
                btnSignIn.Visible = false;
                btnSignUp.Visible = false;
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

        private async void lbMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbMovies.SelectedIndex != -1)
            {
                CustomMovie cm = lbMovies.SelectedItem as CustomMovie;
                Movie movie = await LoadMovies.GetMovie(cm, new CancellationToken());
                lblMovieTitle.Text = string.Format("{0} ({1:0.00})", movie.Title, movie.VoteAverage);
                pbPoster.ImageLocation = "http://image.tmdb.org/t/p/w500" + movie.Poster;
                lblDescription.Text = movie.Overview;
                if(movie.Videos.Results.Count() > 0)
                {
                    foreach (Video v in movie.Videos.Results)
                    {
                        TrailerPath = "https://www.youtube.com/watch?v=" + v.Key;
                        break;
                    }
                    btnWatchTrailer.Enabled = true;
                }
                else
                {
                    btnWatchTrailer.Enabled = false;
                }
                panelMovie.Show();
            }
            else
            {
                panelMovie.Hide();
            }
        }

        private void lbSignOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Дали сте сигурни дека сакате да се одјавите?", "Одјави се", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoggedUser = null;
                btnSignIn.Visible = true;
                btnSignUp.Visible = true;
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

        private void btnWatchTrailer_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(TrailerPath);
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if(!cbGenre.SelectedItem.ToString().Equals("All"))
            {
                if(cbGenre.SelectedItem.ToString().Equals(currentGenre))
                {
                    if(searchChanged)
                    {
                        tbSearch.ResetText();
                        lbMovies.Items.Clear();
                        List<CustomMovie> movies = await LoadMovies.GetByGenre(cbGenre.SelectedItem.ToString(), new CancellationToken());
                        foreach (CustomMovie cm in movies)
                        {
                            lbMovies.Items.Add(cm);
                        }
                        currentGenre = cbGenre.SelectedItem.ToString();
                        genreChanged = true;
                        searchChanged = false;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    tbSearch.ResetText();
                    lbMovies.Items.Clear();
                    List<CustomMovie> movies = await LoadMovies.GetByGenre(cbGenre.SelectedItem.ToString(), new CancellationToken());
                    foreach (CustomMovie cm in movies)
                    {
                        lbMovies.Items.Add(cm);
                    }
                    currentGenre = cbGenre.SelectedItem.ToString();
                    genreChanged = true;
                    searchChanged = false;
                }
            }
            else
            {
                if(tbSearch.Text.Trim().Equals(currentSearchText))
                {
                    if(genreChanged)
                    {
                        lbMovies.Items.Clear();
                        if (tbSearch.Text.Trim() == "")
                        {
                            foreach (CustomMovie cm in beginMovies)
                            {
                                lbMovies.Items.Add(cm);
                            }
                        }
                        else
                        {
                            var movies = await LoadMovies.SearchMovies(tbSearch.Text.Trim(), new CancellationToken());
                            foreach (CustomMovie cm in movies)
                            {
                                lbMovies.Items.Add(cm);
                            }
                        }
                        currentSearchText = tbSearch.Text.Trim();
                        searchChanged = true;
                        genreChanged = false;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    lbMovies.Items.Clear();
                    if (tbSearch.Text.Trim() == "")
                    {
                        foreach (CustomMovie cm in beginMovies)
                        {
                            lbMovies.Items.Add(cm);
                        }
                    }
                    else
                    {
                        var movies = await LoadMovies.SearchMovies(tbSearch.Text.Trim(), new CancellationToken());
                        foreach (CustomMovie cm in movies)
                        {
                            lbMovies.Items.Add(cm);
                        }
                    }
                    currentSearchText = tbSearch.Text.Trim();
                    searchChanged = true;
                    genreChanged = false;
                }
            }
        }

        private async void btnLoadMore_Click(object sender, EventArgs e)
        {
            bool topRated = false;
            List<CustomMovie> movies = null;
            if (cbGenre.SelectedItem.ToString().Equals("All") && tbSearch.Text.Trim().Length == 0)
            {
                movies = await LoadMovies.TopRated(new CancellationToken());
                topRated = true;
            }
            else if (!cbGenre.SelectedItem.ToString().Equals("All") && tbSearch.Text.Trim().Length == 0)
            {
                movies = await LoadMovies.GetByGenre(cbGenre.SelectedItem.ToString(), new CancellationToken());
            }
            else if (cbGenre.SelectedItem.ToString().Equals("All") && tbSearch.Text.Trim().Length > 0)
            {
                movies = await LoadMovies.SearchMovies(tbSearch.Text.Trim(), new CancellationToken());
            }
            else
            {
                return;
            }
            foreach(CustomMovie cm in movies)
            {
                if(topRated)
                {
                    beginMovies.Add(cm);
                }
                lbMovies.Items.Add(cm);
            }
        }

        private void tbSearch_Enter(object sender, EventArgs e)
        {
            tbSearch.BackColor = Color.FromArgb(255, 255, 230);
            cbGenre.SelectedIndex = 0;
        }

        private void tbSearch_Leave(object sender, EventArgs e)
        {
            tbSearch.BackColor = Color.White;
        }

        private void cbGenre_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnDodadiKosnicka_Click(object sender, EventArgs e)
        {
            if (lbMovies.SelectedItem != null&&LoggedUser!=null)
            {
                CustomMovie selectedMovie = lbMovies.SelectedItem as CustomMovie;
                SqlConn.AddShoppingCart(LoggedUser, selectedMovie);
            }
        }
    }
}
