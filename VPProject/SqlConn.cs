using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace VPProject
{
    static class SqlConn
    {
        static public MySqlConnection connection = new MySqlConnection("SERVER=db4free.net;PORT=3306;DATABASE=testsqlserver;UID=master702;PWD=bestPumpkins&&&;");

        static public void SignUp(User user)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                MySqlCommand commandInsert = new MySqlCommand("INSERT INTO Users(Username,Password,Ime,Prezime,Email,Movies) VALUES(@username,@password,@ime,@prezime,@email,@movies)", connection);
                commandInsert.Parameters.AddWithValue("@username", user.Username);
                commandInsert.Parameters.AddWithValue("@password", user.Password);
                commandInsert.Parameters.AddWithValue("@ime", user.Ime);
                commandInsert.Parameters.AddWithValue("@prezime", user.Prezime);
                commandInsert.Parameters.AddWithValue("@email", user.Email);
                commandInsert.Parameters.AddWithValue("@movies", "");
                commandInsert.ExecuteNonQuery();
                commandInsert.Parameters.Clear();
                MessageBox.Show("Успешно се регистриравте!");

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        static public User SignIn(string username)
        {
            User user = null;
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    try
                    {
                        connection.Open();
                    }
                    catch (TimeoutException ex)
                    {
                        MessageBox.Show(ex.Message, "Database timeout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                MySqlCommand command = new MySqlCommand("SELECT * FROM Users WHERE Username='" + username + "'", connection);
                MySqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read() == false) user = null;
                else
                {
                    user = new User(dataReader[1].ToString(), dataReader[2].ToString(), dataReader[3].ToString(), dataReader[4].ToString(), dataReader[5].ToString(), dataReader[6].ToString());
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
            return user;
        }

        static public void UpdateCart(User user,CustomMovie movie)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                MySqlCommand command = null;
                if(user.Movies.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (KeyValuePair<string, string> kvp in user.Movies.AsEnumerable())
                    {
                        sb.Append(string.Format("{0};{1}>", kvp.Key, kvp.Value));
                    }
                    command = new MySqlCommand("UPDATE Users SET Movies='" + sb.ToString().Substring(0, sb.ToString().Length - 1) + "' WHERE Username='" + user.Username + "'", connection);
                }
                else
                {
                    command = new MySqlCommand("UPDATE Users SET Movies='" + "" + "' WHERE Username='" + user.Username + "'", connection);
                }
                    command.ExecuteNonQuery();
                if(movie != null)
                    MessageBox.Show(string.Format("{0} was successfully rented", movie.Movie.Title));
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private static string CONCAT(object movies, string v)
        {
            throw new NotImplementedException();
        }
    }
}
