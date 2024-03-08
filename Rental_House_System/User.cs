using System;
using SQLite;

namespace Rental_House_System
{
    [Table("User")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int uid { get; set; }
        public string fname { get; set; } = "";
        public string lname { get; set; } = "";
        public string email { get; set; } = "";
        public string password { get; set; } = "";
    }
}

