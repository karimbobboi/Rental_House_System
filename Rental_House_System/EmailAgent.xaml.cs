namespace Rental_House_System;

public partial class EmailAgent : ContentPage
{
	Listing property = new Listing();
    public EmailAgent(Listing l)
	{
		InitializeComponent();
		property = l;

		propertyViewer.BindingContext = property;

    }
}
