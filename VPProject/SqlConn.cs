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
                MySqlCommand commandInsert = new MySqlCommand("INSERT INTO Users(Username,Password,Movie1,Movie2,Movie3) VALUES(@username,@password,@movie1,@movie2,@movie3)", connection);
                commandInsert.Parameters.AddWithValue("@username", user.Username);
                commandInsert.Parameters.AddWithValue("@password", user.Password);
                commandInsert.Parameters.AddWithValue("@movie1", "");
                commandInsert.Parameters.AddWithValue("@movie2", "");
                commandInsert.Parameters.AddWithValue("@movie3", "");
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
                    connection.Open();
                }
                MySqlCommand command = new MySqlCommand("SELECT * FROM Users WHERE Username='" + username + "'", connection);
                MySqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read() == false) user = null;
                else
                {
                    user = new User(dataReader[1].ToString(), dataReader[2].ToString());
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

    }
}
