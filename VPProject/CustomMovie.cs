﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.TMDb;
using System.Windows.Forms;

namespace VPProject
{
    //Class made to give custom representation ("Title (Year)") of the movies in the list box containing them, through the overriden toString() method
    public class CustomMovie
    {
        public Movie Movie { get; set; }

        public CustomMovie(Movie movie)
        {
            Movie = movie;
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Movie.Title, (Movie.ReleaseDate.HasValue ? Movie.ReleaseDate.Value.Year.ToString() : "unknown"));
        }
    }
}
