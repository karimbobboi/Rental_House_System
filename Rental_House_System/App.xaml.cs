namespace Rental_House_System;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}

public class Room
{
    public string price { get; set; }
    public string address { get; set; }
    public string  type { get; set; }
    public string available { get; set; }

    public int numRooms { get; set; }
    public int numToilets { get; set; }

    public bool bills { get; set; }
    public bool internet { get; set; }
    public bool furnished { get; set; }
    public bool tv { get; set; }
    public bool gym { get; set; }
    public bool lterm { get; set; }
    public bool kitchen { get; set; }
    public bool dishwasher { get; set; }
    public bool wmachine { get; set; }
    public bool park { get; set; }
}
