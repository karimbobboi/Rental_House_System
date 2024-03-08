namespace Rental_House_System;

public partial class MainPage : ContentPage
{
	App globalref = (App)Application.Current;

	public MainPage()
	{
		InitializeComponent();
	}

	async private void OnCounterClicked(object sender, EventArgs e)
	{
        Listing r = new Listing()
        {
            lId = 1,
            price = "1,790",
            address = "Verney Park Campus, London Road, Buckingham, MK18 1AD",
            type = "Apartment",
            available = "12/2/2001",
            numRooms = 2,
            numToilets = 1,
            bills = true,
            internet = true,
            furnished = true,
            tv = true,
            gym = true,
            lterm = true,
            kitchen = true,
            dishwasher = true,
            wmachine = true,
            park = true
        };
        await Navigation.PushAsync(new RentPage(r));
        //await Shell.Current.GoToAsync("room");
    }
}


