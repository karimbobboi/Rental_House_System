namespace Rental_House_System;

public partial class App : Application
{
    public User activeUser;
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}

public class Listing
{
    public int lId { get; set; }
    public string price { get; set; }
    public string address { get; set; }
    public string type { get; set; }
    public string available { get; set; }

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
}

public class User
{
    public int uid { get; private set; } = -1;
    public string fname { get; set; } = "";
    public string lname { get; set; } = "";
    public string email { get; set; } = "";
    public string password { get; set; } = "";
}
