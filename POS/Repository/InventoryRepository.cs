using POS.Data;
using POS.Models;
using System.Data.SQLite;

namespace POS.Repository
{
    public class InventoryRepository
    {
        public void UpdateStock(Inventory inventory)
        {
            using var conn = DatabaseManager.GetConnection();
            conn.Open();

            string query = @"UPDATE Inventory SET QuantityInStock=@QuantityInStock WHERE ProductId=@ProductId";

            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@ProductId", inventory.ProductId);
            cmd.Parameters.AddWithValue("@QuantityInStock", inventory.QuantityInStock);
            cmd.ExecuteNonQuery();
        }

        public List<Inventory> GetAll()
        {
            var inventories = new List<Inventory>();

            using var conn = DatabaseManager.GetConnection();
            conn.Open();

            string query = "SELECT I.ProductId, P.Name, I.QuantityInStock FROM Inventory I INNER JOIN Products P ON P.ProductId = I.ProductId";

            using var cmd = new SQLiteCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                inventories.Add(new Inventory
                {
                    ProductId= reader.GetInt32(0),
                    ProductName = reader.GetString(1),
                    QuantityInStock = reader.GetInt32(2),
                });
            }

            return inventories;
        }
    }
}
