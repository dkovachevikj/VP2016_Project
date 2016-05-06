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
    public partial class Main : Form
    {
        /// <summary>
        /// The user that is currently logged in (null if there is none)
        /// </summary>
        private User LoggedUser;

        /// <summary>
        /// Keeps the URL of the trailer for the currently selected movie
        /// </summary>
        private string TrailerPath;

        /// <summary>
        /// List that contains the top rated movies loaded when the app starts
        /// </summary>
        private List<CustomMovie> beginMovies;

        /// <summary>
        /// Collection that contains the genres
        /// </summary>
        private Dictionary<int, Genre> Genres;

        //Fields needed for the browsing logic
        private string currentSearchText;
        private bool searchChanged;
        private string currentGenre;
        private bool genreChanged;

        //Fields needed for operations with the rented movies
        private DateTime tempDate;
        private string trashMovie;

        //Fields used for managing the upcoming movies and their representation
        private List<Movie> upcoming;
        private List<int> upcomingRGB;
        private bool upcomingInc;
        private Movie upcomingMovie;
        private int upcomingMovieIndex;

        public Main()
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
            timerSafeUpcoming.Enabled = true;
        }

        #region Movie browsing code

        /// <summary>
        /// Load genres
        /// </summary>
        private async void setGenres()
        {
            List<CustomGenre> genres = await LoadMovies.GetGenres();
            foreach (CustomGenre cg in genres)
            {
                cbGenre.Items.Add(cg);
                Genres.Add(cg.Genre.Id, cg.Genre);
            }
            cbGenre.SelectedIndex = 0;
            currentGenre = "All";
            genreChanged = false;
        }

        /// <summary>
        /// Load top rated movies from the first page in the API results
        /// </summary>

        private async void loadMovies()
        {
            var movies = await LoadMovies.TopRated();
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

        /// <summary>
        /// Load one page of upcoming movies
        /// </summary>
        private async void setUpcoming()
        {
            upcoming = new List<Movie>();
            var movies = await LoadMovies.getUpcoming();
            foreach (Movie m in movies)
            {
                upcoming.Add(m);
            }
            Random tempRandom = new Random();
            upcomingMovieIndex = tempRandom.Next(0, upcoming.Count() - 1);
            upcomingRGB = new List<int>() { 255, 255, 255 };
            upcomingInc = false;
            upcomingMovie = null;
            timerFade.Enabled = true;
            timerUpcoming.Enabled = true;
        }

        /// <summary>
        /// Set genreal info for the selected movie and call methods to load additional info
        /// </summary>
        private async void setMovieInfo()
        {
            pbPoster.SizeMode = PictureBoxSizeMode.CenterImage;
            pbPoster.Image = Properties.Resources.loading;
            CustomMovie cm = lbMovies.SelectedItem as CustomMovie;
            Movie movie = await LoadMovies.GetMovie(cm);
            if (movie.ReleaseDate.HasValue)
                lblMovieTitle.Text = string.Format("{0} ({1})", movie.Title, movie.ReleaseDate.Value.Year.ToString());
            else
                lblMovieTitle.Text = movie.Title;
            lblRating.Text = movie.VoteAverage.ToString("0.00");
            lblVotes.Text = movie.VoteCount.ToString();
            pbPoster.SizeMode = PictureBoxSizeMode.Zoom;
            pbPoster.ImageLocation = "http://image.tmdb.org/t/p/w500" + movie.Poster;
            lblDescription.Text = movie.Overview;
            setCast(movie.Credits.Cast);
            setInfo(movie);
            setTrailer(movie.Videos.Results);
        }

        /// <summary>
        /// Load the cast of the selected movie
        /// </summary>
        /// <param name="cast"></param>
        private void setCast(IEnumerable<MediaCast> cast)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Cast:  ");
            if (cast.Count() == 0)
            {
                sb.Append("Not available");
                lblCast.Text = sb.ToString();
            }
            else
            {
                int maxCast = 0;
                foreach (MediaCast mc in cast)
                {
                    if (maxCast > 10)
                        break;
                    sb.Append(mc.Name + ", ");
                    maxCast++;
                }
                lblCast.Text = sb.ToString().Substring(0, sb.ToString().Length - 2);
            }
        }

        /// <summary>
        /// Load the run time, release date and genres of the selected movie
        /// </summary>
        /// <param name="movie"></param>
        private void setInfo(Movie movie)
        {
            lblInfo.Text = "Not available";
            if (movie.ReleaseDate.HasValue)
            {
                lblInfo.Text = movie.ReleaseDate.Value.ToString("dd MMMM yyyy");
                if (LoggedUser != null)
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
            if (movie.Genres.Count() > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("  |  ");
                int count = 0;
                Genre tempGenre = null;
                foreach (Genre g in movie.Genres)
                {
                    if (count >= 3)
                        break;
                    if (Genres.ContainsKey(g.Id))
                    {
                        Genres.TryGetValue(g.Id, out tempGenre);
                        sb.Append(tempGenre.Name + ", ");
                        count++;
                    }
                }
                lblInfo.Text += sb.ToString().Substring(0, sb.ToString().Length - 2);
            }
        }

        /// <summary>
        /// Set the URL of the trailer for the selected movie
        /// </summary>
        /// <param name="trailers"></param>
        private void setTrailer(IEnumerable<Video> trailers)
        {
            if (trailers.Count() > 0)
            {
                foreach (Video v in trailers)
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
        }

        /// <summary>
        /// Searches for movies by the provided keywords or by the selected genre
        /// </summary>
        private void search()
        {
            if (!cbGenre.SelectedItem.ToString().Equals("All"))
            {
                if (cbGenre.SelectedItem.ToString().Equals(currentGenre))
                {
                    if (searchChanged)
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
                if (tbSearch.Text.Trim().Equals(currentSearchText))
                {
                    if (genreChanged)
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

        /// <summary>
        /// Load movies from the selected genre
        /// </summary>
        private async void loadGenre()
        {
            tbSearch.ResetText();
            lbMovies.Items.Clear();
            List<CustomMovie> movies = await LoadMovies.GetByGenre(cbGenre.SelectedItem.ToString());
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

        /// <summary>
        /// Load movies whose titles contain the given keywords
        /// </summary>
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
                var movies = await LoadMovies.SearchMovies(tbSearch.Text.Trim());
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

        /// <summary>
        /// Called when the user presses the "Load more" button, it checks whether it should load more top rated movies,
        /// <para>movies from search results or movies from the selected genre</para>
        /// </summary>
        private async void loadMore()
        {
            bool topRated = false;
            bool search = false;
            bool genre = false;
            List<CustomMovie> movies = null;
            if (cbGenre.SelectedItem.ToString().Equals("All") && tbSearch.Text.Trim().Length == 0)
            {
                movies = await LoadMovies.TopRated();
                topRated = true;
            }
            else if (!cbGenre.SelectedItem.ToString().Equals("All") && tbSearch.Text.Trim().Length == 0)
            {
                movies = await LoadMovies.GetByGenre(cbGenre.SelectedItem.ToString());
                genre = true;
            }
            else if (cbGenre.SelectedItem.ToString().Equals("All") && tbSearch.Text.Trim().Length > 0)
            {
                movies = await LoadMovies.SearchMovies(tbSearch.Text.Trim());
                search = true;
            }
            else
            {
                return;
            }
            if (movies != null)
            {
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
        }

        /// <summary>
        /// Called when the user presses the "Rent movie" button, it first checks whether it's possible to rent a movie,
        /// <para>and if it is, proceeds to update the list of rented movies of the logged user</para>
        /// </summary>
        private void rentMovie()
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
                    RentTime rentTime = new RentTime();
                    if (rentTime.ShowDialog() == DialogResult.OK)
                    {
                        LoggedUser.Movies.Add(selectedMovie.Movie.Title, DateTime.Now.AddDays(+rentTime.Days).ToString("dd/MM/yyyy HH:mm:ss"));
                        MessageBox.Show(string.Format("{0} was successfully rented", selectedMovie.Movie.Title));
                    }
                }
            }
        }

        /// <summary>
        /// Takes care of updating the label that shows the title of an upcoming movie, including the fade in/fade out effects
        /// </summary>
        private async void upcomingMoviesUpdate()
        {
            if (lblUpcoming.ForeColor == Color.FromArgb(242, 242, 242))
            {
                lblUpcoming.Text = upcoming[upcomingMovieIndex].Title;
                upcomingMovie = await LoadMovies.GetMovie(upcoming[upcomingMovieIndex].Id);
                if (upcomingMovie == null)
                {
                    lblUpcoming.Enabled = false;
                }
                else
                {
                    lblUpcoming.Enabled = true;
                }
                if (++upcomingMovieIndex >= upcoming.Count())
                {
                    upcomingMovieIndex = 0;
                }
                upcomingInc = false;
                changeUpcomingRGB("decrement");

            }
            else if (lblUpcoming.ForeColor == Color.FromArgb(92, 92, 61))
            {
                if (upcomingInc)
                {
                    changeUpcomingRGB("increment");
                }
                else
                {
                    upcomingInc = true;
                    timerFade.Enabled = false;
                }
            }
            else
            {
                if (!upcomingInc)
                {
                    changeUpcomingRGB("decrement");
                }
                else
                {
                    changeUpcomingRGB("increment");
                }
            }
            lblUpcoming.ForeColor = Color.FromArgb(upcomingRGB[0], upcomingRGB[1], upcomingRGB[2]);
        }

        private void changeUpcomingRGB(string cmd)
        {
            if (cmd.Equals("increment"))
            {
                upcomingRGB[0] += 13;
                upcomingRGB[1] += 13;
                upcomingRGB[2] += 13;
                if (upcomingRGB[0] > 242)
                {
                    upcomingRGB[0] = 242;
                    upcomingRGB[1] = 242;
                    upcomingRGB[2] = 242;
                }
            }
            else
            {
                upcomingRGB[0] -= 13;
                upcomingRGB[1] -= 13;
                upcomingRGB[2] -= 13;
                if (upcomingRGB[0] < 92)
                {
                    upcomingRGB[0] = 92;
                    upcomingRGB[1] = 92;
                    upcomingRGB[2] = 61;
                }
            }
        }

        /// <summary>
        /// When the user clicks on the label that shows the title of an upcoming movie, it takes them to the trailer for that movie
        /// </summary>
        private void upcomingTrailer()
        {
            if (upcomingMovie.Videos.Results.Count() > 0)
            {
                string path = "";
                foreach (Video v in upcomingMovie.Videos.Results)
                {
                    path = v.Key;
                    break;
                }
                System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=" + path);
            }
            else
            {
                MessageBox.Show("Trailer not available");
            }
        }

        #endregion

        /// <summary>
        /// Set button design
        /// </summary>
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
            lblUpcoming.ForeColor = Color.FromArgb(242, 242, 242);
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
            signUp.ShowDialog();
        }

        private void lbMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbMovies.SelectedIndex != -1)
            {
                setMovieInfo();
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
                bwUpdateDB.RunWorkerAsync();
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
            search();
        }

        private void btnLoadMore_Click(object sender, EventArgs e)
        {
            loadMore();
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

        private void btnRent_Click(object sender, EventArgs e)
        {
            rentMovie();
        }

        private void cbGenre_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
            {
                return;
            }
            ComboBox combo = sender as ComboBox;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(214, 214, 194)), e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(combo.BackColor), e.Bounds);
            }
            e.Graphics.DrawString(combo.Items[e.Index].ToString(), e.Font, new SolidBrush(combo.ForeColor), new Point(e.Bounds.X, e.Bounds.Y));
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
            if (toolCheckStatusBar.Checked)
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
            if (toolBtnRent.Enabled)
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

        /// <summary>
        /// Checks if a movie rental has expired
        /// </summary>
        private void rentalCheck()
        {
            if (LoggedUser.Movies.Count > 0)
            {
                trashMovie = "";
                foreach (KeyValuePair<string, string> kvp in LoggedUser.Movies)
                {
                    tempDate = DateTime.ParseExact(kvp.Value, "dd/MM/yyyy HH:mm:ss", null);
                    if (tempDate.CompareTo(DateTime.Now) < 0)
                    {
                        trashMovie = kvp.Key;
                        break;
                    }
                }
                if (!trashMovie.Equals(""))
                {
                    LoggedUser.Movies.Remove(trashMovie);
                    NotifyIcon icon = new NotifyIcon();
                    icon.Visible = true;
                    icon.Icon = SystemIcons.Information;
                    icon.ShowBalloonTip(3000, "Cinematique", string.Format("Your rental for {0} has expired", trashMovie), ToolTipIcon.Info);
                }
            }
        }

        private void movieCheckTimer_Tick(object sender, EventArgs e)
        {
            rentalCheck();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (LoggedUser != null)
            {
                SqlConn.UpdateCart(LoggedUser);
            }
        }

        private void timerUpcoming_Tick(object sender, EventArgs e)
        {
            if (!timerFade.Enabled)
                timerFade.Enabled = true;
        }

        private void timerFade_Tick(object sender, EventArgs e)
        {
            upcomingMoviesUpdate();
        }

        private void lblUpcoming_Click(object sender, EventArgs e)
        {
            upcomingTrailer();
        }

        private void lblUpcoming_MouseEnter(object sender, EventArgs e)
        {
            lblUpcoming.Cursor = Cursors.Hand;
        }

        private void lblUpcoming_MouseLeave(object sender, EventArgs e)
        {
            lblUpcoming.Cursor = Cursors.Default;
        }

        private void showNewestMoviesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showNewestMoviesToolStripMenuItem.Checked = !showNewestMoviesToolStripMenuItem.Checked;
            if (!showNewestMoviesToolStripMenuItem.Checked)
            {
                lblUpcoming.Hide();
                timerUpcoming.Enabled = false;
            }
            else
            {
                if (!timerUpcoming.Enabled)
                {
                    timerUpcoming.Enabled = true;
                    lblUpcoming.Show();
                }
            }
        }

        private void bwUpdateDB_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = SqlConn.UpdateCart(LoggedUser);
        }

        private void bwUpdateDB_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Database update error: " + e.Error.ToString());
            }
            else
            {
                bool result = (bool)e.Result;
                if (!result)
                {
                    MessageBox.Show("Database update failed");
                }
                else
                {
                    LoggedUser = null;
                }
            }
        }

        /// <summary>
        /// Delays the loading of upcoming movies because only a limited number of requests can be send at a given time
        /// <para>After 3 seconds have passed, upcoming movies are loaded and the timer is permanently disabled</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerSafeUpcoming_Tick(object sender, EventArgs e)
        {
            setUpcoming();
            timerSafeUpcoming.Enabled = false;
        }

    }
}
