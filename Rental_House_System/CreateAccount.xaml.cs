namespace Rental_House_System;

public partial class CreateAccount : ContentPage
{
	public CreateAccount()
	{
		InitializeComponent();
	}

    async void CreateBtn_Clicked(System.Object sender, System.EventArgs e)
    {
		App globalref = (App)Application.Current;
		if (!(firstName.Text == "" || lastName.Text == "" ||
            electronicMail.Text == "" || pass.Text == "")) {
			if (globalref.appDB.GetUserByEmail(electronicMail.Text) == null)
			{
				User u = new User();
				u.fname = firstName.Text;
				u.lname = lastName.Text;
				u.email = electronicMail.Text;
				u.password = pass.Text;

				globalref.appDB.AddUser(u);
                await DisplayAlert("Account successfully created",
                    $"Welcome {firstName.Text}", "Continue");
				await Navigation.PopAsync();
            }
			else {
                await DisplayAlert("User already exists",
					$"There is already an account with the email address '{electronicMail.Text}'",
					"OK");
            }
        }
		else
		{
			await DisplayAlert("Please fill all fields","","OK");
		}
    }
}
