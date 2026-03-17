using POS.Data;
using POS.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    public class AuthRepository
    {

        public int? Login(string username, string password)
        {
            using var conn = DatabaseManager.GetConnection();
            conn.Open();

            string query = "SELECT UserId FROM Users WHERE Username = @Username AND Password = @Password";

            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);

            var result = cmd.ExecuteScalar();

            if (result != null)
                return Convert.ToInt32(result);

            return null; // login failed
        }
    }
}
