using System.Collections.ObjectModel;

namespace Rental_House_System;

public partial class SearchResults : ContentPage
{
	public ObservableCollection<Listing> allListings = new ObservableCollection<Listing>();
    public SearchResults()
	{
		InitializeComponent();
        System.Diagnostics.Debug.WriteLine("sasas");
        string[] imgs = { "house_example.jpeg", "living_room.jpeg", "bathroom.jpeg" };

        Address a = new Address()
        {
            streetName = "Verney Park Campus, London Road",
            postcode = "MK18 1AD",
            city = "Buckignham"
        };
        Listing r = new Listing()
        {
            lId = 1,
            price = 1790,
            address = a,
            type = "Apartment",
            available = "12/2/2001",
            images = imgs,
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
        System.Diagnostics.Debug.WriteLine("sasas1");
        allListings.Add(r);
        allListings.Add(r);
        allListings.Add(r);
        allListings.Add(r);
        System.Diagnostics.Debug.WriteLine("sasas");
        results.ItemsSource = allListings;
        System.Diagnostics.Debug.WriteLine("sasas3");
    }
}
