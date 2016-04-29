using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace VPProject
{
    static class SqlConn
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

        static public bool SignUp(User user)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    MySqlCommand commandInsert = new MySqlCommand("INSERT INTO Users(Username,Password,Ime,Prezime,Email,Movies) VALUES(@username,@password,@ime,@prezime,@email,@movies)", connection);
                    commandInsert.Parameters.AddWithValue("@username", user.Username);
                    commandInsert.Parameters.AddWithValue("@password", StringCipher.Encrypt(user.Password, user.Username));
                    commandInsert.Parameters.AddWithValue("@ime", user.Name);
                    commandInsert.Parameters.AddWithValue("@prezime", user.Surname);
                    commandInsert.Parameters.AddWithValue("@email", user.Email);
                    commandInsert.Parameters.AddWithValue("@movies", "");
                    commandInsert.ExecuteNonQuery();
                    commandInsert.Parameters.Clear();
                    return true;
                }
                catch(SystemException ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        static public User SignIn(string username)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    User user = null;
                    MySqlCommand command = new MySqlCommand("SELECT * FROM Users WHERE Username='" + username + "'", connection);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read() == false) user = null;
                    else
                    {
                        user = new User(dataReader[1].ToString(), StringCipher.Decrypt(dataReader[2].ToString(), dataReader[1].ToString()), dataReader[3].ToString(), dataReader[4].ToString(), dataReader[5].ToString(), dataReader[6].ToString());
                    }
                    return user;

                }
                catch (SystemException ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        static public bool UpdateCart(User user)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = null;
                    if (user.Movies.Count > 0)
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
                    return true;
                }
                catch(SystemException ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        public async static Task<bool> userExists(string username)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM Users WHERE Username='" + username + "'", connection);
                    System.Data.Common.DbDataReader dataReader = await command.ExecuteReaderAsync();
                    return dataReader.Read();
                }
                catch(MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }            
        }
    }
}
