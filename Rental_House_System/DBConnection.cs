using System;
namespace Rental_House_System
{
	public static class DBConnection
	{
        // Declare the Database Name
        public const string DatabaseFilename = "AppDatabase.db3";
        // Set The DB Initialisation Flags i.e. what can be done with the database
        public const SQLite.SQLiteOpenFlags Flags =
        // Open the DB;
        SQLite.SQLiteOpenFlags.ReadWrite |
        // Automatically Create the DB if it does not exist
        SQLite.SQLiteOpenFlags.Create;
        // Determine the DB File Path
        public static string DatabasePath
        {
            get
            {
                // Get the Base Path i.e. the folder to store the database file
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                // combine the base path with the database filename
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}

