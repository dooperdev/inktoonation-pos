using Microsoft.VisualBasic.ApplicationServices;
using POS.Data;
using POS.Models;
using System.Data.SQLite;

namespace POS.Repository
{
    public class UserRepository
    {
        public void Create(Users user)
        {
            using var conn = DatabaseManager.GetConnection();
            conn.Open();

            string query = @"INSERT INTO Users (Name, Username, Password, Role, Pin)
                     VALUES (@Name, @Username, @Password, @Role, @Pin)";

            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@Username", user.Username);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@Role", user.Role);
            cmd.Parameters.AddWithValue("@Pin", user.Pin);
            cmd.ExecuteNonQuery();
        }

        public void Edit(int userId, Users user)
        {
            using var conn = DatabaseManager.GetConnection();
            conn.Open();

            var cmd = new SQLiteCommand(
                "UPDATE Users SET Name=@Name, Username=@Username, Password=@Password, Role=@Role, Pin=@Pin WHERE UserId = @UserId", conn);
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@Username", user.Username);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@Role", user.Role);
            cmd.Parameters.AddWithValue("@Pin", user.Pin);
            cmd.ExecuteNonQuery();
        }

        public void DeleteRole(int userId)
        {
            using var conn = DatabaseManager.GetConnection();
            conn.Open();

            var cmd = new SQLiteCommand(
                "DELETE FROM Users WHERE UserId = @UserId", conn);
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.ExecuteNonQuery();
        }

        public List<Users> GetAll()
        {
            var users = new List<Users>();

            using var conn = DatabaseManager.GetConnection();
            conn.Open();

            string query = "SELECT * FROM Users";

            using var cmd = new SQLiteCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                users.Add(new Users
                {
                    UserId = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Username = reader.GetString(2),
                    Password = reader.GetString(3),
                    Role = reader.GetString(4),
                    Pin = reader.GetString(5)
                });
            }

            return users;
        }

        public Users GetUserById(int userId)
        {
            using var conn = DatabaseManager.GetConnection();
            conn.Open();

            string query = "SELECT UserId, Name, Username, Role, Pin FROM Users WHERE UserId = @UserId";

            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@UserId", userId);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Users
                {
                    UserId = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Username = reader.GetString(2),
                    Role = reader.GetString(3),
                    Pin = reader.GetString(4)
                };
            }
            return null; // not found
        }
    }
}
