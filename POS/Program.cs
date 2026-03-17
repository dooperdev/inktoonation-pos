using POS.Forms.Auth;
using POS.Forms;
using POS.Forms.Users;
using POS.Data;
using POS.Forms.Products;
namespace POS
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            DatabaseManager.InitializeDatabase(); //Initializing Database
            ApplicationConfiguration.Initialize();
            Application.Run(new Login());
        }
    }
}