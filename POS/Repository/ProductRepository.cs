using Microsoft.VisualBasic.ApplicationServices;
using POS.Data;
using POS.Models;
using System.Data.SQLite;

namespace POS.Repository
{
    public class ProductRepository
    {
        public void Create(Products products)
        {
            using var conn = DatabaseManager.GetConnection();
            conn.Open();

            // Start a transaction to ensure both inserts succeed or fail together
            using var transaction = conn.BeginTransaction();

            try
            {
                // Insert product into Products table
                string queryProduct = @"INSERT INTO Products (Name, Barcode, Description, Price, ImagePath) 
                                        VALUES (@Name, @Barcode, @Description, @Price, @ImagePath);
                                        SELECT last_insert_rowid();"; // Get last inserted ProductID

                using var cmdProduct = new SQLiteCommand(queryProduct, conn, transaction);
                cmdProduct.Parameters.AddWithValue("@Name", products.Name);
                cmdProduct.Parameters.AddWithValue("@Barcode", products.Barcode);
                cmdProduct.Parameters.AddWithValue("@Description", products.Description);
                cmdProduct.Parameters.AddWithValue("@Price", products.Price);
                cmdProduct.Parameters.AddWithValue("@ImagePath", products.ImagePath);

                // Execute and get the newly inserted ProductID
                long productId = (long)cmdProduct.ExecuteScalar();

                // Insert into Inventory table with default QuantityInStock = 0
                string queryInventory = @"INSERT INTO Inventory (ProductID, QuantityInStock) 
                                          VALUES (@ProductID, @QuantityInStock)";
                using var cmdInventory = new SQLiteCommand(queryInventory, conn, transaction);
                cmdInventory.Parameters.AddWithValue("@ProductID", productId);
                cmdInventory.Parameters.AddWithValue("@QuantityInStock", 0);
                cmdInventory.ExecuteNonQuery();

                // Commit transaction
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Edit(int productId, Products products)
        {
            using var conn = DatabaseManager.GetConnection();
            conn.Open();

            var cmd = new SQLiteCommand(
                "UPDATE Products SET Name=@Name, Barcode=@Barcode, Description=@Description, Price=@Price, ImagePath=@ImagePath WHERE ProductId = @ProductId", conn);
            cmd.Parameters.AddWithValue("@ProductId", productId);
            cmd.Parameters.AddWithValue("@Name", products.Name);
            cmd.Parameters.AddWithValue("@Barcode", products.Barcode);
            cmd.Parameters.AddWithValue("@Description", products.Description);
            cmd.Parameters.AddWithValue("@Price", products.Price);
            cmd.Parameters.AddWithValue("@ImagePath", products.ImagePath);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int productId)
        {
            using var conn = DatabaseManager.GetConnection();
            conn.Open();

            // Optional: Delete inventory first to avoid FK constraint issues
            using var cmdInventory = new SQLiteCommand(
                "DELETE FROM Inventory WHERE ProductID = @ProductID", conn);
            cmdInventory.Parameters.AddWithValue("@ProductID", productId);
            cmdInventory.ExecuteNonQuery();

            var cmd = new SQLiteCommand(
                "DELETE FROM Products WHERE ProductId = @ProductId", conn);
            cmd.Parameters.AddWithValue("@ProductId", productId);
            cmd.ExecuteNonQuery();
        }

        public List<Products> GetAll()
        {
            var products = new List<Products>();

            using var conn = DatabaseManager.GetConnection();
            conn.Open();

            string query = "SELECT * FROM Products";

            using var cmd = new SQLiteCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                products.Add(new Products
                {
                    ProductId = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Barcode = reader.GetString(2),
                    Description = reader.GetString(3),
                    Price = reader.GetDecimal(4),
                    ImagePath = reader.GetString(5)
                });
            }

            return products;
        }

        public int GetStock(int productId)
        {
            using var conn = DatabaseManager.GetConnection();
            conn.Open();

            string query = "SELECT QuantityInStock FROM Inventory WHERE ProductID = @ProductID";
            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@ProductID", productId);

            var result = cmd.ExecuteScalar();
            return result != null ? Convert.ToInt32(result) : 0;
        }
    }
}