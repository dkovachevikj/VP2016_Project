﻿using System;
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
        private Dictionary<int, Genre> Genres;
        private string currentSearchText { get; set; }
        private bool searchChanged { get; set; }
        private string currentGenre { get; set; }
        private bool genreChanged { get; set; }
        private DateTime tempDate;
        private string trashMovie;

        public Form1()
        {
            InitializeComponent();
            panelMovie.Hide();
            panelUser.Hide();
            loadMovies();
            TrailerPath = "";
            beginMovies = new List<CustomMovie>();
            Genres = new Dictionary<int, Genre>();
            setGenres();
            toolBtnRent.Enabled = false;
            setColors();
        }

        private void setColors()
        {
            btnLoadMore.FlatAppearance.MouseOverBackColor = Color.FromArgb(235, 235, 224);
            btnLoadMore.FlatAppearance.MouseDownBackColor = Color.FromArgb(214, 214, 194);
            btnSearch.FlatAppearance.MouseOverBackColor = Color.FromArgb(235, 235, 224);
            btnSearch.FlatAppearance.MouseDownBackColor = Color.FromArgb(214, 214, 194);
            btnWatchTrailer.FlatAppearance.MouseOverBackColor = Color.FromArgb(235, 235, 224);
            btnWatchTrailer.FlatAppearance.MouseDownBackColor = Color.FromArgb(214, 214, 194);
            btnRent.FlatAppearance.MouseOverBackColor = Color.FromArgb(235, 235, 224);
            btnRent.FlatAppearance.MouseDownBackColor = Color.FromArgb(214, 214, 194);
            btnSignUp.FlatAppearance.MouseOverBackColor = Color.FromArgb(235, 235, 224);
            btnSignUp.FlatAppearance.MouseDownBackColor = Color.FromArgb(214, 214, 194);
            btnSignIn.FlatAppearance.MouseOverBackColor = Color.FromArgb(235, 235, 224);
            btnSignIn.FlatAppearance.MouseDownBackColor = Color.FromArgb(214, 214, 194);
        }

        private async void setGenres()
        {
            List<CustomGenre> genres = await LoadMovies.GetGenres(new CancellationToken());
            foreach(CustomGenre cg in genres)
            {
                cbGenre.Items.Add(cg);
                Genres.Add(cg.Genre.Id, cg.Genre);
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
            lbMovies.SelectedIndex = 0;
            toopStripLblSearchResults.Text = string.Format("Showing {0} of {1} results", LoadMovies.topRatedCount, LoadMovies.topRatedTotal);
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
                toolBtnRent.Enabled = true;
                movieCheckTimer.Enabled = true;
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
                if (movie.ReleaseDate.HasValue)
                    lblMovieTitle.Text = string.Format("{0} ({1})", movie.Title, movie.ReleaseDate.Value.Year.ToString());
                else
                    lblMovieTitle.Text = movie.Title;
                lblRating.Text = movie.VoteAverage.ToString("0.00");
                lblVotes.Text = movie.VoteCount.ToString();
                pbPoster.ImageLocation = "http://image.tmdb.org/t/p/w500" + movie.Poster;
                lblDescription.Text = movie.Overview;
                StringBuilder sb = new StringBuilder();
                sb.Append("Cast:  ");
                if (movie.Credits.Cast.Count<MediaCast>() == 0)
                {
                    sb.Append("Not available");
                    lblCast.Text = sb.ToString();
                }
                else
                {
                    int maxCast = 0;
                    foreach (MediaCast mc in movie.Credits.Cast)
                    {
                        if (maxCast > 10)
                            break;
                        sb.Append(mc.Name + ", ");
                        maxCast++;
                    }
                    lblCast.Text = sb.ToString().Substring(0, sb.ToString().Length - 2);
                }
                lblInfo.Text = "Not available";
                if (movie.ReleaseDate.HasValue)
                {
                    lblInfo.Text = movie.ReleaseDate.Value.ToString("dd MMMM yyyy");
                    if(LoggedUser != null)
                    {
                        if (movie.ReleaseDate.Value.CompareTo(DateTime.Now) > 0)
                            toolBtnRent.Enabled = false;
                        else
                            toolBtnRent.Enabled = true;
                    }
                }
                if (movie.Runtime > 60)
                {
                    int hr = (int)movie.Runtime / 60;
                    int min = (int)movie.Runtime % 60;
                    if (min > 0)
                        lblInfo.Text += string.Format("  |  {0} h {1} min", hr, min);
                    else
                        lblInfo.Text += string.Format("  |  {0} h", hr);
                }
                else if (movie.Runtime > 0)
                {
                    lblInfo.Text += "  |  " + movie.Runtime.ToString() + " min";
                }
                else
                {
                    lblInfo.Text += " ";
                }
                if(movie.Genres.Count<Genre>() > 0)
                {
                    sb.Clear();
                    sb.Append("  |  ");
                    int count = 0;
                    Genre tempGenre = null;
                    foreach(Genre g in movie.Genres)
                    {
                        if (count >= 3)
                            break;
                        if(Genres.ContainsKey(g.Id))
                        {
                            Genres.TryGetValue(g.Id, out tempGenre);
                            sb.Append(tempGenre.Name + ", ");
                            count++;
                        }
                    }
                    lblInfo.Text += sb.ToString().Substring(0, sb.ToString().Length - 2);
                }
                if (movie.Videos.Results.Count() > 0)
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
                SqlConn.UpdateCart(LoggedUser, null);
                LoggedUser = null;
                btnSignIn.Visible = true;
                btnSignUp.Visible = true;
                panelUser.Hide();
                toolBtnRent.Enabled = false;
                movieCheckTimer.Enabled = false;
            }
        }

        private void lblUsername_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UserDetail forma = new UserDetail(LoggedUser);
            forma.Text = lblUsername.Text;
            movieCheckTimer.Enabled = false;
            if (forma.ShowDialog() == DialogResult.Cancel)
            {
                LoggedUser = forma.user;
                movieCheckTimer.Enabled = true;
            }
        }

        private void btnWatchTrailer_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(TrailerPath);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(!cbGenre.SelectedItem.ToString().Equals("All"))
            {
                if(cbGenre.SelectedItem.ToString().Equals(currentGenre))
                {
                    if(searchChanged)
                    {
                        loadGenre();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    loadGenre();
                }
            }
            else
            {
                if(tbSearch.Text.Trim().Equals(currentSearchText))
                {
                    if(genreChanged)
                    {
                        loadSearch();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    loadSearch();
                }
            }
        }

        private async void btnLoadMore_Click(object sender, EventArgs e)
        {
            bool topRated = false;
            bool search = false;
            bool genre = false;
            List<CustomMovie> movies = null;
            if (cbGenre.SelectedItem.ToString().Equals("All") && tbSearch.Text.Trim().Length == 0)
            {
                movies = await LoadMovies.TopRated(new CancellationToken());
                topRated = true;
            }
            else if (!cbGenre.SelectedItem.ToString().Equals("All") && tbSearch.Text.Trim().Length == 0)
            {
                movies = await LoadMovies.GetByGenre(cbGenre.SelectedItem.ToString(), new CancellationToken());
                genre = true;
            }
            else if (cbGenre.SelectedItem.ToString().Equals("All") && tbSearch.Text.Trim().Length > 0)
            {
                movies = await LoadMovies.SearchMovies(tbSearch.Text.Trim(), new CancellationToken());
                search = true;
            }
            else
            {
                return;
            }
            foreach (CustomMovie cm in movies)
            {
                if (topRated)
                {
                    beginMovies.Add(cm);
                }
                lbMovies.Items.Add(cm);
            }
            if (topRated)
                toopStripLblSearchResults.Text = string.Format("Showing {0} of {1} results", LoadMovies.topRatedCount, LoadMovies.topRatedTotal);
            else if (search)
                toopStripLblSearchResults.Text = string.Format("Showing {0} of {1} results", LoadMovies.searchCount, LoadMovies.searchTotal);
            else if (genre)
                toopStripLblSearchResults.Text = string.Format("Showing {0} of {1} results", LoadMovies.genreCount, LoadMovies.genreTotal);
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

        private async void loadGenre()
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
            if (lbMovies.Items.Count > 0)
            {
                lbMovies.SelectedIndex = 0;
            }
            toopStripLblSearchResults.Text = string.Format("Showing {0} of {1} results", LoadMovies.genreCount, LoadMovies.genreTotal);
        }

        private async void loadSearch()
        {
            lbMovies.Items.Clear();
            if (tbSearch.Text.Trim() == "")
            {
                foreach (CustomMovie cm in beginMovies)
                {
                    lbMovies.Items.Add(cm);
                }
                toopStripLblSearchResults.Text = string.Format("Showing {0} of {1} results", LoadMovies.topRatedCount, LoadMovies.topRatedTotal);
                LoadMovies.resetParams();
            }
            else
            {
                var movies = await LoadMovies.SearchMovies(tbSearch.Text.Trim(), new CancellationToken());
                foreach (CustomMovie cm in movies)
                {
                    lbMovies.Items.Add(cm);
                }
                toopStripLblSearchResults.Text = string.Format("Showing {0} of {1} results", LoadMovies.searchCount, LoadMovies.searchTotal);
            }
            currentSearchText = tbSearch.Text.Trim();
            searchChanged = true;
            genreChanged = false;
            if (lbMovies.Items.Count > 0)
            {
                lbMovies.SelectedIndex = 0;
            }
        }

        private void btnRent_Click(object sender, EventArgs e)
        {
            if (lbMovies.SelectedItem != null && LoggedUser != null)
            {
                CustomMovie selectedMovie = lbMovies.SelectedItem as CustomMovie;
                if (LoggedUser.Movies.ContainsKey(selectedMovie.Movie.Title))
                {
                    MessageBox.Show(string.Format("{0} is already rented!", selectedMovie.Movie.Title), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (LoggedUser.Movies.Count() >= 5)
                {
                    MessageBox.Show("Maximum number of rented movies (5) reached!\nReturn a rented movie or wait for a rental to expire", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    LoggedUser.Movies.Add(selectedMovie.Movie.Title, DateTime.Now.AddMinutes(+2).ToString("dd/MM/yyyy HH:mm:ss"));
                    MessageBox.Show(string.Format("{0} was successfully rented", selectedMovie.Movie.Title));
                }
            }
        }

        private void cbGenre_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            ComboBox combo = sender as ComboBox;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(214, 214, 194)),
                                         e.Bounds);
            else
                e.Graphics.FillRectangle(new SolidBrush(combo.BackColor),
                                         e.Bounds);

            e.Graphics.DrawString(combo.Items[e.Index].ToString(), e.Font,
                                  new SolidBrush(combo.ForeColor),
                                  new Point(e.Bounds.X, e.Bounds.Y));

            e.DrawFocusRectangle();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbGenre.DrawMode = DrawMode.OwnerDrawFixed;
            lbMovies.DrawMode = DrawMode.OwnerDrawFixed;
        }

        private void lbMovies_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            bool isItemSelected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);
            int itemIndex = e.Index;
            if (itemIndex >= 0 && itemIndex < lbMovies.Items.Count)
            {
                Graphics g = e.Graphics;

                SolidBrush backgroundColorBrush = new SolidBrush((isItemSelected) ? Color.FromArgb(194, 194, 163) : SystemColors.WindowFrame);
                g.FillRectangle(backgroundColorBrush, e.Bounds);

                string itemText = lbMovies.Items[itemIndex].ToString();

                SolidBrush itemTextColorBrush = (isItemSelected) ? new SolidBrush(Color.Black) : new SolidBrush(Color.White);
                g.DrawString(itemText, e.Font, itemTextColorBrush, lbMovies.GetItemRectangle(itemIndex).Location);

                backgroundColorBrush.Dispose();
                itemTextColorBrush.Dispose();
            }

            e.DrawFocusRectangle();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.ShowDialog();
        }

        private void toolCheckStatusBar_Click(object sender, EventArgs e)
        {
            toolCheckStatusBar.Checked = !toolCheckStatusBar.Checked;
            if(toolCheckStatusBar.Checked)
            {
                statusStrip1.Show();
            }
            else
            {
                statusStrip1.Hide();
            }
        }

        private void toolBtnRent_EnabledChanged(object sender, EventArgs e)
        {
            if(toolBtnRent.Enabled)
            {
                btnRent.Enabled = true;
            }
            else
            {
                btnRent.Enabled = false;
            }
        }

        private void toolBtnRent_Click(object sender, EventArgs e)
        {
            btnRent_Click(this, new EventArgs());
        }

        private void searchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            btnSearch_Click(this, new EventArgs());
        }

        private void loadMoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnLoadMore_Click(this, new EventArgs());
        }

        private void signInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSignIn_Click(this, new EventArgs());
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSignUp_Click(this, new EventArgs());
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void movieCheckTimer_Tick(object sender, EventArgs e)
        {
            if(LoggedUser.Movies.Count > 0)
            {
                trashMovie = "";
                foreach(KeyValuePair<string, string> kvp in LoggedUser.Movies)
                {
                    tempDate = DateTime.ParseExact(kvp.Value, "dd/MM/yyyy HH:mm:ss", null);
                    if(tempDate.CompareTo(DateTime.Now) < 0)
                    {
                        trashMovie = kvp.Key;
                        break;
                    }
                }
                if(!trashMovie.Equals(""))
                {
                    LoggedUser.Movies.Remove(trashMovie);
                    NotifyIcon icon = new NotifyIcon();
                    icon.Visible = true;
                    icon.Icon = SystemIcons.Information;
                    icon.ShowBalloonTip(3000, "Cinematique", string.Format("Your rental for {0} has expired", trashMovie), ToolTipIcon.Info);
                }
                
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(LoggedUser != null)
            {
                SqlConn.UpdateCart(LoggedUser, null);
            }
        }

        private void cbGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!cbGenre.SelectedItem.ToString().Equals("All"))
                btnSearch_Click(this, new EventArgs());
        }
    }
}
