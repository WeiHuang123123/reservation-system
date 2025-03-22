using System;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;

namespace ReservationSystem
{
    public class UserManager
    {
        private MySqlConnection _connection;

        public UserManager(string connectionString)
        {
            _connection = new MySqlConnection(connectionString);
        }

        public bool RegisterUser(string username, string password)
        {
            try
            {
                string passwordHash = HashPassword(password);

                string query = "INSERT INTO Users (Username, PasswordHash) VALUES (@Username, @PasswordHash)";
                MySqlCommand cmd = new MySqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);

                _connection.Open();
                int result = cmd.ExecuteNonQuery();
                _connection.Close();

                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("註冊時出錯：" + ex.Message);
                return false;
            }
        }

        public bool ValidateUser(string username, string password)
        {
            try
            {
                string query = "SELECT PasswordHash FROM Users WHERE Username = @Username";
                MySqlCommand cmd = new MySqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@Username", username);

                _connection.Open();
                object result = cmd.ExecuteScalar();
                _connection.Close();

                if (result != null)
                {
                    string storedHash = result.ToString();
                    return VerifyPassword(password, storedHash);
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("登入時出錯：" + ex.Message);
                return false;
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            string passwordHash = HashPassword(password);
            return passwordHash == storedHash;
        }
    }
}
