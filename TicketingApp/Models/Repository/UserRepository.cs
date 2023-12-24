using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingApp.Models.Context;
using TicketingApp.Models.Entity;
using MySqlConnector;


namespace TicketingApp.Models.Repository
{
    public class UserRepository
    {
        private MySqlConnection _conn;
        public UserRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public bool GetUserToLogin(string email, string password)
        {
            bool result = false;

            string sql = @"select count(*) as row_count
                           from users
                           where email = @email and password = @password";

            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);

                using (MySqlDataReader dtr = cmd.ExecuteReader())
                {
                    if (dtr.Read())
                    {
                        result = Convert.ToInt32(dtr["row_count"]) > 0;
                    }
                }
            }

            return result;
        }


        public int RegisterNewUser(User newUser, string id)
        {
            int result = 0;
            string query = @"INSERT INTO users (id, nama, password, email, no_tlp) VALUES (@id, @nama, @password, @email, @noTlp)";

            using (MySqlCommand cmd = new MySqlCommand(query, _conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nama", newUser.Nama);
                cmd.Parameters.AddWithValue("@password", newUser.Password);
                cmd.Parameters.AddWithValue("@email", newUser.Email);
                cmd.Parameters.AddWithValue("@noTlp", newUser.NoTlp);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                }
            }
            return result;
        }

        public int PushToken(string email, int token)
        {
            int result = 0;
            string query = @"UPDATE users SET Token = @token WHERE email=@email";

            using (MySqlCommand cmd = new MySqlCommand(query, _conn))
            {;
                cmd.Parameters.AddWithValue("@token", token);
                cmd.Parameters.AddWithValue("@email", email);
                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                }
            }
            return result;
        }

        public int GetToken(string email, int token)
        {
            int result = 0;
            string query = @"SELECT token FROM users WHERE email=@email";

            using (MySqlCommand cmd = new MySqlCommand(query, _conn))
            {
                cmd.Parameters.AddWithValue("@email", email);
                using (MySqlDataReader dtr = cmd.ExecuteReader())
                {
                    if (dtr.Read())
                    {
                        result = dtr.GetInt32(0);
                    }
                }
            }
            return result;
        }

        public int UpdatePassword(string email, string password)
        {
            int result = 0;
            string query = @"UPDATE users SET password = @password WHERE email=@email";

            using (MySqlCommand cmd = new MySqlCommand(query, _conn))
            {
                ;
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@email", email);
                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                }
            }
            return result;
        }




    }
}
