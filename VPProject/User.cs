using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPProject
{
    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Movie> RentedMovies { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
            RentedMovies = new List<Movie>();
        }

    }
}
