using System.Data.SQLite;
using System.IO;

namespace POS.Data
{
    public static class DatabaseManager
    {
        private static string dbFolder =
           Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database");

        private static string dbPath =
            Path.Combine(dbFolder, "pos.db");

        private static string connectionString =
            $"Data Source={dbPath};Version=3;";

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }
        public static void InitializeDatabase()
        {

            // ✅ Ensure folder exists
            if (!Directory.Exists(dbFolder))
                Directory.CreateDirectory(dbFolder);

            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);

                using var conn = GetConnection();
                conn.Open();

                string createTables = @"
                CREATE TABLE IF NOT EXISTS Users (
                    UserId INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Username TEXT UNIQUE NOT NULL,
                    Password TEXT NOT NULL,
                    Role TEXT NOT NULL CHECK (Role IN ('Admin','Cashier')),
                    Pin TEXT UNIQUE NOT NULL
                );

                CREATE TABLE IF NOT EXISTS Products (
                    ProductId INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Barcode TEXT UNIQUE NOT NULL,
                    Description TEXT,
                    Price REAL NOT NULL,
                    ImagePath TEXT
                );

                CREATE TABLE IF NOT EXISTS Customers (
                    CustomerId INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Email TEXT UNIQUE,
                    Phone TEXT,
                    Address TEXT,
                    CreatedAt DATETIME DEFAULT (DATETIME('now', '+8 hours'))
                );

                CREATE TABLE IF NOT EXISTS Inventory (
                        InventoryID INTEGER PRIMARY KEY AUTOINCREMENT,
                        ProductID INTEGER NOT NULL,
                        QuantityInStock INTEGER DEFAULT 0,
                        FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
                    );

                CREATE TABLE IF NOT EXISTS SalesTransactions (
                            TransactionID INTEGER PRIMARY KEY AUTOINCREMENT,
                            UserID INTEGER NOT NULL,
                            CustomerId INTEGER NOT NULL,
                            TransactionNumber NOT NULL,
                            TransactionDate DATETIME DEFAULT (DATETIME('now', '+8 hours')),
                            TotalAmount REAL NOT NULL,
                            PaymentType TEXT NOT NULL CHECK(PaymentType IN ('Cash','GCash','Split')),
                            FOREIGN KEY (UserID) REFERENCES Users(UserID)
                        );

                CREATE TABLE IF NOT EXISTS OrderDetails (
                            OrderDetailID INTEGER PRIMARY KEY AUTOINCREMENT,
                            TransactionID INTEGER NOT NULL,
                            ProductID INTEGER NOT NULL,
                            Quantity INTEGER NOT NULL,
                            UnitPrice REAL NOT NULL,
                            FOREIGN KEY (TransactionID) REFERENCES SalesTransactions(TransactionID),
                            FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
                        );                     
                ";

                using var cmd = new SQLiteCommand(createTables, conn);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
