using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.TMDb;
using System.Threading;

namespace VPProject
{
    public partial class UserDetail : Form
    {
        public User user { get; set; }
        public UserDetail(User user)
        {
            InitializeComponent();
            this.user = user;
            fillControls();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void fillControls()
        {
            lblIme.Text += " " + user.Ime;
            lblPrezime.Text += " " + user.Prezime;
            lblEmail.Text += " " + user.Email;
            lbKosnicka.Items.Clear();
            if(user.Movies.Count > 0)
                foreach(CustomMovie cm in user.Movies)
                {
                    lbKosnicka.Items.Add(cm);
                }
        }
    }
}
