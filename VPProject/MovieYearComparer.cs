using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPProject
{
    class MovieYearComparer : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            if(x.Year > y.Year)
            {
                return 1;
            }
            else if(x.Year < y.Year)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
