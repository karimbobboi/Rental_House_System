namespace Rental_House_System;

public partial class SearchPage : ContentPage
{
	public SearchPage()
	{
		InitializeComponent();
	}

    async void SearchButton_Clicked(System.Object sender, System.EventArgs e)
    {
		await Navigation.PushAsync(new SearchResults());
    }
}
