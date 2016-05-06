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
    /// <summary>
    /// Static class for manipulation with Users stored in our DataBase 
    /// </summary>
    static class SqlConn
    {
        /// <summary>
        /// connectionString saved in App.config, which is used for establishing a connection with Database
        /// </summary>
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;


        /// <summary>
        /// SignUp method inserts a new record for each registered user in table Users
        /// </summary>
        static public bool SignUp(User user)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    /// <summary>
                    /// SqlCommand object contains SqlConnection object and queryString (INSERT command with parameters) 
                    /// </summary>
                    MySqlCommand commandInsert = new MySqlCommand("INSERT INTO Users(Username,Password,Ime,Prezime,Email,Movies) VALUES(@username,@password,@ime,@prezime,@email,@movies)", connection);
                    commandInsert.Parameters.AddWithValue("@username", user.Username);
                    commandInsert.Parameters.AddWithValue("@password", user.Password);
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

        /// <summary>
        /// SignIn method returns the user which is LoggedIn (Description)
        /// </summary>
        static public User SignIn(string username)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    User user = null;
                    /// <summary>
                    /// queryString = Search in table Users for all records whose username is equal with the username given as a parameter
                    /// </summary>
                    MySqlCommand command = new MySqlCommand("SELECT * FROM Users WHERE Username='" + username + "'", connection);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read() == false) user = null;
                    else
                    {
                        user = new User(dataReader[1].ToString(), dataReader[2].ToString(), dataReader[3].ToString(), dataReader[4].ToString(), dataReader[5].ToString(), dataReader[6].ToString());
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

        /// <summary>
        /// UpdateCard method updates Movies field for the User given as a parameter
        /// This method is used for Renting a Movie 
        /// </summary>
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

        /// <summary>
        /// This method is used for UsernameValidation (Checks for existing User with same Username) in SignIn Form
        /// </summary>
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
