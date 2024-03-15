namespace Rental_House_System;

public partial class EmailAgent : ContentPage
{
	Listing property = new Listing();
	string[] allImages;
	App globalref = (App)Application.Current;
    public EmailAgent(Listing l)
	{
		InitializeComponent();
		property = l;
        allImages = globalref.appDB.ImageStringToArray(l);
		propertyViewer.BindingContext = property;
        propertyViewerImage.Source = allImages[0];
    }

    async void SendButton_Clicked(System.Object sender, System.EventArgs e)
    {
        await DisplayAlert("Message sent!","","Continue");
        await Navigation.PopAsync();
    }
}
