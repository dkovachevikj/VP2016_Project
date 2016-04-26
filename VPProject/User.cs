using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.TMDb;
using System.Threading;
using System.Windows.Forms;

namespace VPProject
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Ime { set; get; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public Dictionary<string, string> Movies { get; set; }

        public User(string username, string password,string ime,string prezime,string email,string movies)
        {
            Username = username;
            Password = password;
            Ime = ime;
            Prezime = prezime;
            Email = email;
            Movies = new Dictionary<string, string>();
            if(movies.Length > 0)
            {
                loadRentedMovies(movies);
            }
        }

        public void loadRentedMovies(string fromDB)
        {
            char[] primarySeparator = { '>' };
            char[] secondarySeparator = { ';' };
            string[] primaryParts = fromDB.Split(primarySeparator);
            string[] secondaryParts = null;
            DateTime currentDate = DateTime.Now;
            DateTime tempDate = DateTime.MaxValue;
            StringBuilder sbExpired = new StringBuilder();
            foreach(string s in primaryParts)
            {
                secondaryParts = s.Split(secondarySeparator);
                tempDate = DateTime.ParseExact(secondaryParts[1], "dd/MM/yyyy HH:mm:ss", null);
                if(tempDate.CompareTo(currentDate) > 0)
                {
                    Movies.Add(secondaryParts[0], secondaryParts[1]);
                }
                else
                {
                    sbExpired.Append(secondaryParts[0] + ", ");
                }
            }
            if(!(sbExpired.Length == 0))
            {
                NotifyIcon icon = new NotifyIcon();
                icon.Visible = true;
                icon.Icon = System.Drawing.SystemIcons.Information;
                icon.ShowBalloonTip(3000, "Cinematiqe", string.Format("Your rental for {0} has expired", sbExpired.ToString().Substring(0, sbExpired.ToString().Length - 2)), ToolTipIcon.Info);
            }
        }

    }
}
