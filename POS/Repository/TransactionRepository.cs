using POS.Data;
using POS.Models;
using System.Data.SQLite;
using System.Transactions;

namespace POS.Repository
{
    public class TransactionRepository
    {
        public List<Transactions> GetAll()
        {
            var transactions = new List<Transactions>();

            using var conn = DatabaseManager.GetConnection();
            conn.Open();

            string query = @"
                SELECT 
                T.TransactionID,
                T.UserID,
                U.Name AS UserName,
                T.CustomerId,

                CASE 
                    WHEN T.CustomerId = 0 THEN 'Guest'
                    ELSE C.Name
                END AS CustomerName,

                T.TransactionNumber,
                T.TransactionDate,
                T.TotalAmount,
                T.PaymentType,
                IFNULL(SUM(OD.Quantity), 0) AS TotalItems

            FROM SalesTransactions T

            INNER JOIN Users U 
                ON U.UserId = T.UserID

            LEFT JOIN Customers C 
                ON C.CustomerId = T.CustomerId

            LEFT JOIN OrderDetails OD 
                ON OD.TransactionID = T.TransactionID

            GROUP BY T.TransactionID
            ORDER BY T.TransactionDate DESC;
            ";

            using var cmd = new SQLiteCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                transactions.Add(new Transactions
                {
                    TransactionID = reader.GetInt32(0),
                    UserID = reader.GetInt32(1),
                    UserName = reader.GetString(2),
                    CustomerId = reader.GetInt32(3),
                    CustomerName = reader.GetString(4),
                    TransactionNumber = reader.GetString(5),
                    TransactionDate = reader.GetDateTime(6),
                    TotalAmount = reader.GetDouble(7),
                    PaymentType = reader.GetString(8),
                    TotalItems = reader.GetInt32(9)
                });
            }

            return transactions;
        }

        public List<Transactions> GetFiltered(DateTime fromDate, DateTime toDate, string search)
        {
            var transactions = new List<Transactions>();

            using var conn = DatabaseManager.GetConnection();
            conn.Open();

            string query = @"
            SELECT 
                T.TransactionID,
                T.UserID,
                U.Name AS UserName,
                T.CustomerId,
                COALESCE(C.Name, 'Guest') AS CustomerName,
                T.TransactionNumber,
                T.TransactionDate,
                T.TotalAmount,
                T.PaymentType,
                IFNULL(SUM(OD.Quantity), 0) AS TotalItems
            FROM SalesTransactions T
            INNER JOIN Users U ON U.UserId = T.UserID
            LEFT JOIN Customers C ON C.CustomerId = T.CustomerId
            LEFT JOIN OrderDetails OD ON OD.TransactionID = T.TransactionID
            WHERE 
                DATE(T.TransactionDate) BETWEEN DATE(@FromDate) AND DATE(@ToDate)
                AND (@Search = '' OR T.TransactionNumber LIKE '%' || @Search || '%')
            GROUP BY T.TransactionID
            ORDER BY T.TransactionDate DESC
        ";

            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@FromDate", fromDate);
            cmd.Parameters.AddWithValue("@ToDate", toDate);
            cmd.Parameters.AddWithValue("@Search", search);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                transactions.Add(new Transactions
                {
                    TransactionID = reader.GetInt32(0),
                    UserID = reader.GetInt32(1),
                    UserName = reader.GetString(2),
                    CustomerId = reader.GetInt32(3),
                    CustomerName = reader.GetString(4),
                    TransactionNumber = reader.GetString(5),
                    TransactionDate = reader.GetDateTime(6),
                    TotalAmount = reader.GetDouble(7),
                    PaymentType = reader.GetString(8),
                    TotalItems = reader.GetInt32(9)
                });
            }

            return transactions;
        }
    }
}
