using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VPProject
{
    class TitleMovieComparer : IComparer<CustomMovie>
    {
        public int Compare(CustomMovie x, CustomMovie y)
        {
            string xLower = x.Movie.Title.Trim().ToLower();
            string yLower = y.Movie.Title.Trim().ToLower();
            Regex.Replace(xLower, @"\s+", "");
            Regex.Replace(yLower, @"\s+", "");
            return xLower.CompareTo(yLower);
        }
    }
}
