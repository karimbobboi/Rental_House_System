namespace Rental_House_System;

public partial class SearchFiltersModal : ContentPage
{
	public SearchFiltersModal()
	{
		InitializeComponent();
	}

    async void ClickedButton_Clicked(System.Object sender, System.EventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("qwertyuiuytfdtyui");
        await Navigation.PopModalAsync();
        
    }
}
