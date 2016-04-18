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

        static public async Task<List<CustomMovie>> TopRated(CancellationToken cancellationToken)
        {
            using (var client = new ServiceClient(Key))
            {
                var movies = await client.Movies.GetTopRatedAsync(null, topRatedPage, cancellationToken);
                List<CustomMovie> returnList = new List<CustomMovie>();
                foreach (Movie m in movies.Results)
                {
                    returnList.Add(new CustomMovie(m));
                }
                topRatedPage++;
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
                }
                var movies = await client.Movies.SearchAsync(currSearchTitle, null, false, searchPage, cancellationToken);
                List<CustomMovie> returnList = new List<CustomMovie>();
                foreach (Movie m in movies.Results)
                {
                    returnList.Add(new CustomMovie(m));
                }
                searchPage++;
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
                }
                var genres = await client.Genres.GetAsync(DataInfoType.Movie, new CancellationToken());
                var selectedGenre = genres.Where(g => g.Name.Contains(genreName)).FirstOrDefault();
                var detailedMovies = await client.Movies.DiscoverAsync(null, false, null, null, null, null, null, selectedGenre.Id.ToString(), "", genrePage, cancellationToken);
                foreach(Movie m in detailedMovies.Results)
                {
                    returnList.Add(new CustomMovie(m));
                }
                genrePage++;
                return returnList;
            }
        }
    }
}
