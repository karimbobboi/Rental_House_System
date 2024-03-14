namespace Rental_House_System;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("room", typeof(RentPage));
	}
}

