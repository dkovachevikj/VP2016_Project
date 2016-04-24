using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPProject
{
    public partial class UserDetail : Form
    {
        public User user { get; set; }
        public UserDetail(User user)
        {
            InitializeComponent();
            this.user = user;
            lblIme.Text += " " + user.Ime;
            lblPrezime.Text += " " + user.Prezime;
            lblEmail.Text += " " + user.Email;
            lbKosnicka.Items.Clear();
            char[] separatingChars = { '>' };
            string [] parts=user.Movies.Split(separatingChars);
            for(int i=1;i<parts.Length;i++)
            {
                lbKosnicka.Items.Add(parts[i]);
            }
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
    }
}
