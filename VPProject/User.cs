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
        public string Movies { get; set; }

        public User(string username, string password,string ime,string prezime,string email,string movies)
        {
            Username = username;
            Password = password;
            Ime = ime;
            Prezime = prezime;
            Email = email;
            Movies = movies;
        }

    }
}
