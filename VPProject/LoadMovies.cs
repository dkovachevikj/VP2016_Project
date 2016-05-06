using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.TMDb;
using System.Threading;
using System.IO;

namespace VPProject
{
    public static class LoadMovies
    {
        /// <summary>
        /// API Key
        /// </summary>
        static private readonly string Key = "f2371afc8f5052f400222bb1834586f0";

        /// <summary>
        /// Keeps track of current genre status so that if it hasn't changed
        /// it doesn't make an API call for the same content
        /// </summary>
        static private string currGenreName = "";
        /// <summary>
        /// Keeps track of current search status so that if it hasn't changed
        /// it doesn't make an API call for the same content
        /// </summary>
        static private string currSearchTitle = "";

        /// <summary>
        /// Keeps track of current page of top rated movies
        /// </summary>
        static private int topRatedPage = 1;
        /// <summary>
        /// Keeps track of current page of movies of a particular genre
        /// </summary>
        static private int genrePage = 1;
        /// <summary>
        /// Keeps track of current page of movies whose title contains the given keywords
        /// </summary>
        static private int searchPage = 1;

        /// <summary>
        /// Keeps track of the number of loaded top rated movies
        /// </summary>
        static public int topRatedCount = 0;
        /// <summary>
        /// Keeps track of the total number of top rated movies
        /// </summary>
        static public int topRatedTotal = 0;

        /// <summary>
        /// Keeps track of the number of loaded movies from a particular genre
        /// </summary>
        static public int genreCount = 0;
        /// <summary>
        /// Keeps track of the total number of movies from a particular genre
        /// </summary>
        static public int genreTotal = 0;

        /// <summary>
        /// Keeps track of the number of loaded movies whose title contains the given keywords
        /// </summary>
        static public int searchTotal = 0;
        /// <summary>
        /// Keeps track of the total number of movies whose title contains the given keywords
        /// </summary>
        static public int searchCount = 0;

        static private CancellationToken token = new CancellationToken();

        /// <summary>
        /// Get the top rated movies
        /// </summary>
        /// <returns></returns>
        public static async Task<List<CustomMovie>> TopRated()
        {
            using (var client = new ServiceClient(Key))
            {
                try
                {
                    var movies = await client.Movies.GetTopRatedAsync(null, topRatedPage, token);
                    topRatedTotal = movies.TotalCount;
                    List<CustomMovie> returnList = new List<CustomMovie>();
                    foreach (Movie m in movies.Results)
                    {
                        returnList.Add(new CustomMovie(m));
                    }
                    topRatedPage++;
                    topRatedCount += returnList.Count;
                    return returnList;
                }
                catch (ServiceRequestException)
                {
                    MessageBox.Show("Too may requests, please wait for a few moments");
                    return null;
                }
            }
        }

        /// <summary>
        /// Get the movies that contain the given key words in their title
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public static async Task<List<CustomMovie>> SearchMovies(string searchString)
        {
            using (var client = new ServiceClient(Key))
            {
                try
                {
                    if (!searchString.Equals(currSearchTitle))
                    {
                        currSearchTitle = searchString;
                        searchPage = 1;
                        searchTotal = 0;
                        searchCount = 0;
                    }
                    var movies = await client.Movies.SearchAsync(searchString, null, false, searchPage, token);
                    if (searchTotal == 0)
                        searchTotal = movies.TotalCount;
                    List<CustomMovie> returnList = new List<CustomMovie>();
                    foreach (Movie m in movies.Results)
                    {
                        returnList.Add(new CustomMovie(m));
                    }
                    searchCount += returnList.Count;
                    searchPage++;
                    genrePage = 1;
                    currGenreName = "#fffff";
                    genreTotal = 0;
                    genreCount = 0;
                    return returnList;
                }
                catch(ServiceRequestException)
                {
                    MessageBox.Show("Too may requests, please wait for a few moments");
                    return null;
                }
            }
        }

        /// <summary>
        /// Get a Movie object that contains more info about the requested movie through a CustomMovie object
        /// </summary>
        /// <param name="cm"></param>
        /// <returns></returns>
        public static async Task<Movie> GetMovie(CustomMovie cm)
        {
            using (var client = new ServiceClient(Key))
            {
                try
                {
                    Movie movie = await client.Movies.GetAsync(cm.Movie.Id, null, true, token);
                    return movie;
                }
                catch(ServiceRequestException)
                {
                    MessageBox.Show("Too many requests, please wait for a few moments");
                    return null;
                }
            }
        }

        /// <summary>
        /// Get a Movie object that contains more info about the movie directly by the movie ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<Movie> GetMovie(int id)
        {
            using (var client = new ServiceClient(Key))
            {
                try
                {
                    Movie movie = await client.Movies.GetAsync(id, null, true, token);
                    return movie;
                }
                catch(ServiceRequestException)
                {
                    MessageBox.Show("Too many requests, please wait for a few moments");
                    return null;
                }
            }
        }
        
        /// <summary>
        /// Get all movie genres
        /// </summary>
        /// <returns></returns>
        public static async Task<List<CustomGenre>> GetGenres()
        {
            using (var client = new ServiceClient(Key))
            {
                List<CustomGenre> returnGenres = new List<CustomGenre>();
                var genres = await client.Genres.GetAsync(DataInfoType.Movie, token);
                foreach(Genre g in genres)
                {
                    returnGenres.Add(new CustomGenre(g));
                }
                return returnGenres;
            }
        }

        /// <summary>
        /// Get movies from the specified genre
        /// </summary>
        /// <param name="genreName"></param>
        /// <returns></returns>
        public static async Task<List<CustomMovie>> GetByGenre(string genreName)
        {
            using (var client = new ServiceClient(Key))
            {
                try
                {
                    List<CustomMovie> returnList = new List<CustomMovie>();
                    if (!genreName.Equals(currGenreName))
                    {
                        genrePage = 1;
                        currGenreName = genreName;
                        genreTotal = 0;
                        genreCount = 0;
                    }
                    var genres = await client.Genres.GetAsync(DataInfoType.Movie, token);
                    var selectedGenre = genres.Where(g => g.Name.Contains(genreName)).FirstOrDefault();
                    var detailedMovies = await client.Movies.DiscoverAsync(null, false, null, null, null, null, null, selectedGenre.Id.ToString(), "", genrePage, token);
                    if (genreTotal == 0)
                        genreTotal = detailedMovies.TotalCount;
                    foreach (Movie m in detailedMovies.Results)
                    {
                        returnList.Add(new CustomMovie(m));
                    }
                    genreCount += returnList.Count;
                    genrePage++;
                    currSearchTitle = "#ffffff";
                    searchPage = 1;
                    searchTotal = 0;
                    searchCount = 0;
                    return returnList;
                }
                catch(ServiceRequestException)
                {
                    MessageBox.Show("Too many requests, please wait for a few moments");
                    return null;
                }
            }
        }

        /// <summary>
        /// Reset all parameters used for keeping track of current browsing status
        /// </summary>
        public static void resetParams()
        {
            genrePage = 1;
            currGenreName = "#fffffff";
            genreTotal = 0;
            genreCount = 0;
            currSearchTitle = "#ffffffff";
            searchPage = 1;
            searchTotal = 0;
            searchCount = 0;
        }

        /// <summary>
        /// Get upcoming (newest) movies
        /// </summary>
        /// <returns></returns>
        public static async Task<IEnumerable<Movie>> getUpcoming()
        {
            using (var client = new ServiceClient(Key))
            {
                try
                {
                    var movies = await client.Movies.GetUpcomingAsync(null, 1, token);
                    return movies.Results;
                }
                catch(ServiceRequestException)
                {
                    MessageBox.Show("Too many requests, please wait for a few moments");
                    return null;
                }
            }
        }
    }
}
