namespace Rental_House_System;

public partial class App : Application
{
    public User activeUser;
    public AppDatabase appDB = new AppDatabase();
    public App()
	{
		InitializeComponent();
		activeUser = new User();
		MainPage = new LoginPage();
	}
}