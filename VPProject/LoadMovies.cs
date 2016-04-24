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
    class LoadMovies
    {
        static private readonly string Key = "f2371afc8f5052f400222bb1834586f0";
        static private int topRatedPage = 1;
        static private string currGenreName = "";
        static private int genrePage = 1;
        static private string currSearchTitle = "";
        static private int searchPage = 1;
        static public int topRatedCount = 0;
        static public int genreCount = 0;
        static public int topRatedTotal = 0;
        static public int genreTotal = 0;
        static public int searchTotal = 0;
        static public int searchCount = 0;

        static public async Task<List<CustomMovie>> TopRated(CancellationToken cancellationToken)
        {
            using (var client = new ServiceClient(Key))
            {
                var movies = await client.Movies.GetTopRatedAsync(null, topRatedPage, cancellationToken);
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
        }

        static public async Task<List<CustomMovie>> SearchMovies(string searchString, CancellationToken cancellationToken)
        {
            using (var client = new ServiceClient(Key))
            {
                if(!searchString.Equals(currSearchTitle))
                {
                    currSearchTitle = searchString;
                    searchPage = 1;
                    searchTotal = 0;
                    searchCount = 0;
                }
                var movies = await client.Movies.SearchAsync(currSearchTitle, null, false, searchPage, cancellationToken);
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
        }

        static public async Task<Movie> GetMovie(CustomMovie cm, CancellationToken cancellationToken)
        {
            using (var client = new ServiceClient(Key))
            {
                Movie movie = await client.Movies.GetAsync(cm.Movie.Id, null, true, cancellationToken);
                return movie;
            }
        }

        static public async Task<List<CustomGenre>> GetGenres(CancellationToken cancellationToken)
        {
            using (var client = new ServiceClient(Key))
            {
                List<CustomGenre> returnGenres = new List<CustomGenre>();
                var genres = await client.Genres.GetAsync(DataInfoType.Movie, cancellationToken);
                foreach(Genre g in genres)
                {
                    returnGenres.Add(new CustomGenre(g));
                }
                return returnGenres;
            }
        }

        static public async Task<List<CustomMovie>> GetByGenre(string genreName, CancellationToken cancellationToken)
        {
            using (var client = new ServiceClient(Key))
            {
                List<CustomMovie> returnList = new List<CustomMovie>();
                if (!genreName.Equals(currGenreName))
                {
                    genrePage = 1;
                    currGenreName = genreName;
                    genreTotal = 0;
                    genreCount = 0;
                }
                var genres = await client.Genres.GetAsync(DataInfoType.Movie, new CancellationToken());
                var selectedGenre = genres.Where(g => g.Name.Contains(genreName)).FirstOrDefault();
                var detailedMovies = await client.Movies.DiscoverAsync(null, false, null, null, null, null, null, selectedGenre.Id.ToString(), "", genrePage, cancellationToken);
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
        }
    }
}
