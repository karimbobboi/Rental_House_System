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
        string[] imgs = { "house2.jpeg", "house2_bed.jpeg", "house2_out.jpeg", "house2_toilet.jpeg" };

        Agent ag = new Agent()
        {
            name = "Buckingham Property Management",
            phone = "MK18 1AD",
            email = "Buckignham"
        };
        globalref.appDB.AddAgent(ag);
        Agent tempAgent = globalref.appDB.GetAgentByEmail(ag.email);
        string imgsString = globalref.appDB.ArrayToImageString(imgs);

        Listing r = new Listing()
        {
            lId = 1,
            price = 1790,
            agentEmail = tempAgent.email,
            images = imgsString,
            streetName = "Verney Park Campus, London Road",
            postcode = "MK18 1AD",
            city = "Buckignham",
            type = "Apartment",
            available = "12/2/2001",
            numRooms = 2,
            numToilets = 1,
            bills = true,
            internet = true,
            tv = true,
            gym = true,
            lterm = true,
            kitchen = true,
            dishwasher = true,
            wmachine = true,
            park = true
        };

        string[] imgs2 = { "living_room.jpeg", "house_example.jpeg", "bathroom.jpeg" };

        imgsString = globalref.appDB.ArrayToImageString(imgs2);

        Listing r2 = new Listing()
        {
            lId = 1,
            price = 1790,
            agentEmail = tempAgent.email,
            images = imgsString,
            streetName = "London Road",
            postcode = "PK18 1AG",
            city = "Leeds",
            type = "Apartment",
            available = "12/2/2001",
            numRooms = 2,
            numToilets = 1,
            dishwasher = true,
            wmachine = true
        };

        globalref.appDB.AddListing(r);
        globalref.appDB.AddListing(r2);
        //await Navigation.PushAsync(new RentPage(r));
        //await Navigation.PushAsync(new EmailAgent(r));

        //await Shell.Current.GoToAsync("room");
    }

    void btnContinue_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushAsync(new SearchPage());
    }
}


