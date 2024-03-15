using System.Collections.ObjectModel;

namespace Rental_House_System;

public partial class AccountPage : ContentPage
{
    App globalref = (App)Application.Current;
    EditUserVM editUserVM;
    public AccountPage()
	{
		InitializeComponent();
        //profile.BindingContext = globalref.activeUser;
        editUserVM = new EditUserVM();
        BindingContext = editUserVM;
        savedListings.ItemsSource = editUserVM.allListings;
        recentListings.ItemsSource = editUserVM.allListings;
    }

    async void OnGridTapped(object sender, EventArgs args)
    {
        await Navigation.PushAsync(new EditUser(editUserVM));
    }

    async void LogOutBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        bool answer = await DisplayAlert("Are you sure you want to log out?",
            "Please tap yes if you want to sign out of this account.","Yes", "No");
        if(answer)
            globalref.LogOut();
    }

    async void OnSavedGridTapped(System.Object sender, System.EventArgs e)
    {
        Grid grid = sender as Grid;
        Listing listing = grid.BindingContext as Listing;
        await Navigation.PushAsync(new RentPage(listing));
    }
}
