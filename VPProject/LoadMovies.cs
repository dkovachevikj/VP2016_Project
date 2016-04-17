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

        static public async Task<List<CustomMovie>> TopRated(CancellationToken cancellationToken)
        {
            using (var client = new ServiceClient(Key))
            {
                var movies = await client.Movies.GetTopRatedAsync(null, 1, cancellationToken);
                List<CustomMovie> returnList = new List<CustomMovie>();
                foreach(Movie m in movies.Results)
                {
                    var movie = await client.Movies.GetAsync(m.Id, null, true, cancellationToken);
                    returnList.Add(new CustomMovie(movie));
                }
                return returnList;
            }
        }

        static public async Task<List<CustomMovie>> SearchMovies(string searchString, CancellationToken cancellationToken)
        {
            using (var client = new ServiceClient(Key))
            {
                var movies = await client.Movies.SearchAsync(searchString, null, false, 1, cancellationToken);
                List<CustomMovie> returnList = new List<CustomMovie>();
                foreach (Movie m in movies.Results)
                {
                    var movie = await client.Movies.GetAsync(m.Id, null, true, cancellationToken);
                    returnList.Add(new CustomMovie(movie));
                }
                return returnList;
            }
        }
    }
}
