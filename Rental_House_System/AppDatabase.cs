using System;
using Android.Database.Sqlite;
using System.Data.Common;
using SQLite;
using System.Collections.ObjectModel;
using System.Reflection;

namespace Rental_House_System
{
	public class AppDatabase
	{
        public string CurrentState; // to hold the current db state
        static SQLiteConnection DatabaseConnection; // to hold and establish the connection

        public AppDatabase()
		{
            try
            {
                // Make the connection
                DatabaseConnection = new SQLiteConnection(DBConnection.DatabasePath, DBConnection.Flags);
                // Create a Table
                DatabaseConnection.CreateTable<User>();
                // set the status of the DB
                CurrentState = "Database and Table Created";
            }
            catch (SQLite.SQLiteException excep)
            {
                CurrentState = excep.Message;
            }
        }

        // DB Utility Functions

        //User functions
        // Insert a new user
        public int AddUser(User user)
        {
            // Insert into the table and return the status of the inset
            var insertstatus = DatabaseConnection.Insert(user);
            System.Diagnostics.Debug.WriteLine(insertstatus);
            return insertstatus;
        }
        // Delete a user
        public int DeleteUser(User user)
        {
            // Query to return all users in the DB
            var deletestatus = DatabaseConnection.Delete(user);
            return deletestatus;
        }
        // Update a user
        public int UpdateUser(User user)
        {
            // Query to return all users in the DB
            var updatestatus = DatabaseConnection.Update(user);
            return updatestatus;
        }

        // Return ALL users
        public ObservableCollection<User> GetAllUsers()
        {
            ObservableCollection<User> users;
            // Query to return all users in the DB
            var allUsers = DatabaseConnection.Table<User>();
            users = new ObservableCollection<User>(allUsers.ToList());
            return users;
        }
        // Return a user based on email
        public User GetUserByEmail(string email)
        {
            
            // Query to return all users in the DB
            var user = (from u in DatabaseConnection.Table<User>()
                           where u.email == email
                        select u).FirstOrDefault();
            return user;
        }

        // Listings functions
        public int AddListing(Listing listing)
        {
            // Insert into the table and return the status of the inset
            var insertstatus = DatabaseConnection.Insert(listing);
            return insertstatus;
        }
        // Delete a user
        public int DeleteListing(Listing listing)
        {
            // Query to return all users in the DB
            var deletestatus = DatabaseConnection.Delete(listing);
            return deletestatus;
        }
        // Update a user
        public int UpdateListing(Listing listing)
        {
            // Query to return all users in the DB
            var updatestatus = DatabaseConnection.Update(listing);
            return updatestatus;
        }

        // Return ALL users
        public ObservableCollection<User> GetAllListings()
        {
            ObservableCollection<User> users;
            // Query to return all users in the DB
            var allUsers = DatabaseConnection.Table<User>();
            users = new ObservableCollection<User>(allUsers.ToList());
            return users;
        }
        // Return a user based on email
        public Listing SearchListings(Listing listing)
        {

            // Query to return all users in the DB
            //var user = (from u in DatabaseConnection.Table<User>()
            //            where u.email == email
            //            select u).FirstOrDefault();
            return null;
        }
    }
}

