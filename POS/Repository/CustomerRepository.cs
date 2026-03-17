using Microsoft.VisualBasic.ApplicationServices;
using POS.Data;
using POS.Models;
using System.Data.SQLite;

namespace POS.Repository
{
    public class CustomerRepository
    {
        public void Create(Customers customer)
        {
            using var conn = DatabaseManager.GetConnection();
            conn.Open();

            string query = @"INSERT INTO Customers (Name, Email, Phone, Address) 
                VALUES (@Name, @Email, @Phone, @Address)";

            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", customer.Name);
            cmd.Parameters.AddWithValue("@Email", customer.Email);
            cmd.Parameters.AddWithValue("@Phone", customer.Phone);
            cmd.Parameters.AddWithValue("@Address", customer.Address);
            cmd.ExecuteNonQuery();
        }

        public void Edit(int customerId, Customers customer)
        {
            using var conn = DatabaseManager.GetConnection();
            conn.Open();

            var cmd = new SQLiteCommand(
                "UPDATE Customers SET Name=@Name, Email=@Email, Phone=@Phone, Address=@Address WHERE CustomerId = @CustomerId", conn);
            cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
            cmd.Parameters.AddWithValue("@Name", customer.Name);
            cmd.Parameters.AddWithValue("@Email", customer.Email);
            cmd.Parameters.AddWithValue("@Phone", customer.Phone);
            cmd.Parameters.AddWithValue("@Address", customer.Address);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int customerId)
        {
            using var conn = DatabaseManager.GetConnection();
            conn.Open();

            var cmd = new SQLiteCommand(
                "DELETE FROM Customers WHERE CustomerId = @CustomerId", conn);
            cmd.Parameters.AddWithValue("@CustomerId", customerId);
            cmd.ExecuteNonQuery();
        }

        public List<Customers> GetAll()
        {
            var customers = new List<Customers>();

            using var conn = DatabaseManager.GetConnection();
            conn.Open();

            string query = "SELECT * FROM Customers";

            using var cmd = new SQLiteCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                customers.Add(new Customers
                {
                    CustomerId = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Email = reader.GetString(2),
                    Phone = reader.GetString(3),
                    Address = reader.GetString(4)
                });
            }

            return customers;
        }

        public Customers GetById(int customerId)
        {
            using var conn = DatabaseManager.GetConnection();
            conn.Open();

            string query = "SELECT CustomerId, Name, Email, Phone, Address, CreatedAt FROM Customers WHERE CustomerId = @CustomerId";

            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@CustomerId", customerId);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Customers
                {
                    CustomerId = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Email = reader.IsDBNull(2) ? null : reader.GetString(2),
                    Phone = reader.IsDBNull(3) ? null : reader.GetString(3),
                    Address = reader.IsDBNull(4) ? null : reader.GetString(4)
                };
            }
            return null; // not found
        }
    }
}
