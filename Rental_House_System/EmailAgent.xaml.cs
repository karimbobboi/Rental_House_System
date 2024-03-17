namespace Rental_House_System;

public partial class EmailAgent : ContentPage
{
	Listing property = new Listing();
	string[] allImages;
	App globalref = (App)Application.Current;
    Agent agent;
    public EmailAgent(Listing l)
	{
		InitializeComponent();
		property = l;
        allImages = globalref.appDB.ImageStringToArray(l);
		propertyViewer.BindingContext = property;
        propertyViewerImage.Source = allImages[0];

        agent = globalref.appDB.GetAgentByEmail(property.agentEmail);
        agentDetails.BindingContext = agent;
    }

    async void SendButton_Clicked(System.Object sender, System.EventArgs e)
    {
        await DisplayAlert("Message sent!","","Continue");
        await Navigation.PopAsync();
    }
}
