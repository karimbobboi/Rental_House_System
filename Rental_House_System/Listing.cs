using System;
using SQLite;

namespace Rental_House_System
{
    [Table("Listing")]
    public class Listing
    {
        [PrimaryKey, AutoIncrement]
        public int lId { get; set; }
        //public Agent agent { get; set; }
        public int price { get; set; }
        public Address address { get; set; }
        public string type { get; set; }
        public string available { get; set; }
        public string[] images { get; set; }

        public int numRooms { get; set; }
        public int numToilets { get; set; }

        public bool bills { get; set; } = false;
        public bool internet { get; set; } = false;
        public bool furnished { get; set; } = false;
        public bool tv { get; set; } = false;
        public bool gym { get; set; } = false;
        public bool lterm { get; set; } = false;
        public bool kitchen { get; set; } = false;
        public bool dishwasher { get; set; } = false;
        public bool wmachine { get; set; } = false;
        public bool park { get; set; } = false;

        public string PriceToString()
        {
            return price.ToString("N0");
;
        }
    }

    [Table("Address")]
    public class Address
    {
        [PrimaryKey, AutoIncrement]
        public string postcode { get; set; }
        public string city { get; set; }
        public string streetName { get; set; }

        public override string ToString()
        {
            return $"{streetName}, {city}, {postcode}";
        }
    }

    //[Table("Agent")]
    //public class Agent
    //{
    //    [PrimaryKey, AutoIncrement]
    //    public int agentId { get; set; }
    //    public string name { get; set; }
    //    public string email { get; set; }
    //    public string phone { get; set; }
    //}
}

