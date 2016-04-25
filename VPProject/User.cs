using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPProject
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Ime { set; get; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public HashSet<CustomMovie> Movies { get; set; }
        public HashSet<string> mID { get; set; }

        public User(string username, string password,string ime,string prezime,string email,string movies)
        {
            Username = username;
            Password = password;
            Ime = ime;
            Prezime = prezime;
            Email = email;
            mID = new HashSet<string>();
            Movies = new HashSet<CustomMovie>();
            if(movies.Length > 0)
            {
                char[] pattern = { '>' };
                string[] splitMovies = movies.Split(pattern);
                foreach (string s in splitMovies)
                    mID.Add(s);
            }
        }

    }
}
