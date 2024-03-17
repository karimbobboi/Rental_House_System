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
        
    }

    void btnContinue_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushAsync(new SearchPage());
    }
}


