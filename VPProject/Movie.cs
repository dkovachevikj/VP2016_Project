using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPProject
{
    class Movie : IComparable<Movie>
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }

        public Movie(string title, string description, int year)
        {
            Title = title;
            Description = description;
            Year = year;
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Title, Year);
        }

        public int CompareTo(Movie other)
        {
            if(Title.CompareTo(other.Title) > 0)
            {
                return -1;
            }
            else if(Title.CompareTo(other.Title) < 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
