using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPProject
{
    class YearMovieComparer : IComparer<CustomMovie>
    {
        public int Compare(CustomMovie x, CustomMovie y)
        {
            if(x.Movie.ReleaseDate.HasValue && y.Movie.ReleaseDate.HasValue)
            {
                if (x.Movie.ReleaseDate.Value.Year > y.Movie.ReleaseDate.Value.Year)
                {
                    return -1;
                }
                else if (x.Movie.ReleaseDate.Value.Year < y.Movie.ReleaseDate.Value.Year)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}
