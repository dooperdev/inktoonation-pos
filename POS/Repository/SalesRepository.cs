using POS.Data;
using POS.Models;
using System.Data.SQLite;

namespace POS.Repository
{
    public class SalesRepository
    {
        // Return the saved transaction info
        public TransactionResult SaveTransaction(int userId, int customerId, List<CartItem> cart, string paymentType)
        {
            using var conn = DatabaseManager.GetConnection();
            conn.Open();

            using var transaction = conn.BeginTransaction();

            try
            {
                // 1️⃣ Generate Transaction Number
                string transactionNumber = GenerateTransactionNumber(conn, transaction);

                // 2️⃣ Compute Total
                double totalAmount = cart.Sum(x => x.Price * x.Quantity);

                // 3️⃣ Insert into SalesTransactions
                string insertTransaction = @"
                    INSERT INTO SalesTransactions 
                    (UserID, CustomerId, TransactionNumber, TotalAmount, PaymentType)
                    VALUES (@UserID, @CustomerId, @TransactionNumber, @TotalAmount, @PaymentType);
                    SELECT last_insert_rowid();";

                using var cmdTrans = new SQLiteCommand(insertTransaction, conn, transaction);
                cmdTrans.Parameters.AddWithValue("@UserID", userId);
                cmdTrans.Parameters.AddWithValue("@CustomerId", customerId);
                cmdTrans.Parameters.AddWithValue("@TransactionNumber", transactionNumber);
                cmdTrans.Parameters.AddWithValue("@TotalAmount", totalAmount);
                cmdTrans.Parameters.AddWithValue("@PaymentType", paymentType);

                long transactionId = (long)cmdTrans.ExecuteScalar();

                // 4️⃣ Insert OrderDetails + Deduct Inventory
                foreach (var item in cart)
                {
                    int productId = GetProductIdByName(conn, transaction, item.Name);

                    // Insert OrderDetails
                    string insertDetails = @"
                        INSERT INTO OrderDetails
                        (TransactionID, ProductID, Quantity, UnitPrice)
                        VALUES (@TransactionID, @ProductID, @Quantity, @UnitPrice)";

                    using var cmdDetails = new SQLiteCommand(insertDetails, conn, transaction);
                    cmdDetails.Parameters.AddWithValue("@TransactionID", transactionId);
                    cmdDetails.Parameters.AddWithValue("@ProductID", productId);
                    cmdDetails.Parameters.AddWithValue("@Quantity", item.Quantity);
                    cmdDetails.Parameters.AddWithValue("@UnitPrice", item.Price);
                    cmdDetails.ExecuteNonQuery();

                    // Deduct Inventory
                    string updateStock = @"
                        UPDATE Inventory
                        SET QuantityInStock = QuantityInStock - @Quantity
                        WHERE ProductID = @ProductID";

                    using var cmdStock = new SQLiteCommand(updateStock, conn, transaction);
                    cmdStock.Parameters.AddWithValue("@Quantity", item.Quantity);
                    cmdStock.Parameters.AddWithValue("@ProductID", productId);
                    cmdStock.ExecuteNonQuery();
                }

                transaction.Commit();

                // Return transaction info
                return new TransactionResult
                {
                    TransactionID = (int)transactionId,
                    TransactionNumber = transactionNumber,
                    TotalAmount = totalAmount
                };
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        // 🔥 Generate Transaction Number
        private string GenerateTransactionNumber(SQLiteConnection conn, SQLiteTransaction transaction)
        {
            string today = DateTime.Now.ToString("ddMMyyyy");

            string query = @"
               SELECT COUNT(*)
                FROM SalesTransactions
                WHERE date(TransactionDate, '+8 hours') = date('now', '+8 hours');";

            using var cmd = new SQLiteCommand(query, conn, transaction);
            long countToday = (long)cmd.ExecuteScalar();

            int nextNumber = (int)countToday + 1;

            return $"{today}-{nextNumber:000}";
        }

        private int GetProductIdByName(SQLiteConnection conn, SQLiteTransaction transaction, string name)
        {
            string query = "SELECT ProductID FROM Products WHERE Name = @Name";

            using var cmd = new SQLiteCommand(query, conn, transaction);
            cmd.Parameters.AddWithValue("@Name", name);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }

    // DTO class to return transaction info
    public class TransactionResult
    {
        public int TransactionID { get; set; }
        public string TransactionNumber { get; set; }
        public double TotalAmount { get; set; }
    }
}