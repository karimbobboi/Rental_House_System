using System.Collections.ObjectModel;

namespace Rental_House_System;

public partial class SearchResults : ContentPage
{
	public ObservableCollection<Listing> allListings = new ObservableCollection<Listing>();
    App globalref = (App)Application.Current;
    public SearchResults(ObservableCollection<Listing> temp)
	{
		InitializeComponent();
        //allListings = globalref.appDB.GetAllListings();
        allListings = temp;
        results.ItemsSource = allListings;
        if(allListings.Count > 0)
        {
            noResult.IsVisible = false;
        }
    }

    async void OnInnerStackTapped(System.Object sender, System.EventArgs e)
    {
        StackLayout stackLayout = (StackLayout)sender;
        CarouselView carousel = (CarouselView)stackLayout.Parent;

        // Get the corresponding item of the CarouselView
        Listing item = (Listing)carousel.BindingContext;

        // Get the index of the item in the ItemsSource collection
        int index = allListings.IndexOf(item);
        Listing listing = allListings[index];
        await Navigation.PushAsync(new RentPage(listing));
    }

    async void OnStackTapped(System.Object sender, System.EventArgs e)
    {
        StackLayout stackLayout = (StackLayout)sender;

        // Get the corresponding item of the ListView
        Listing item = (Listing)stackLayout.BindingContext;

        // Get the index of the item in the ItemsSource collection
        int index = allListings.IndexOf(item);
        Listing listing = allListings[index];
        await Navigation.PushAsync(new RentPage(listing));
    }
}
