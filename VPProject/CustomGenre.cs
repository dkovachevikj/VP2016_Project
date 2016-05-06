using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.TMDb;

namespace VPProject
{
    //Class made to give proper representation of the genres in the combo box though the overriden toString() method
    public class CustomGenre
    {
        public Genre Genre { get; set; }

        public CustomGenre(Genre genre)
        {
            Genre = genre;
        }

        public override string ToString()
        {
            return Genre.Name;
        }
    }
}
