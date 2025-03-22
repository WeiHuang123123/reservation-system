using System;
using MySql.Data.MySqlClient;

namespace ReservationSystem
{
    public class ReservationManager
    {
        private MySqlConnection _connection;

        public ReservationManager(string connectionString)
        {
            _connection = new MySqlConnection(connectionString);
        }

        public void AddReservation(string username, DateTime reservationTime)
        {
            try
            {
                string query = "INSERT INTO Reservations (Username, ReservationTime, Status) VALUES (@Username, @ReservationTime, 'Pending')";
                MySqlCommand cmd = new MySqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@ReservationTime", reservationTime);

                _connection.Open();
                cmd.ExecuteNonQuery();
                _connection.Close();

                Console.WriteLine("預約已新增！");
            }
            catch (Exception ex)
            {
                Console.WriteLine("新增預約時出錯：" + ex.Message);
            }
        }

        public void UpdateReservationStatus(int reservationId, string newStatus)
        {
            try
            {
                string query = "UPDATE Reservations SET Status = @NewStatus WHERE ReservationId = @ReservationId";
                MySqlCommand cmd = new MySqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@NewStatus", newStatus);
                cmd.Parameters.AddWithValue("@ReservationId", reservationId);

                _connection.Open();
                cmd.ExecuteNonQuery();
                _connection.Close();

                Console.WriteLine("預約狀態已更新！");
            }
            catch (Exception ex)
            {
                Console.WriteLine("更新預約狀態時出錯：" + ex.Message);
            }
        }

        public void DisplayReservations()
        {
            try
            {
                string query = "SELECT * FROM Reservations";
                MySqlCommand cmd = new MySqlCommand(query, _connection);

                _connection.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"預約ID: {reader["ReservationId"]}, 使用者: {reader["Username"]}, 時間: {reader["ReservationTime"]}, 狀態: {reader["Status"]}");
                }

                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("顯示預約時出錯：" + ex.Message);
            }
        }
    }
}
