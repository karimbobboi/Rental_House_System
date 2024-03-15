using System.Collections.ObjectModel;

namespace Rental_House_System;

public partial class LoginPage : ContentPage
{
    App globalref = (App)Application.Current;
    public LoginPage()
	{
		InitializeComponent();
	}

    async void SignInBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        
        if (!(electronicMail.Text == "" || pass.Text == "")) {
            User u = globalref.appDB.GetUserByEmail(electronicMail.Text);
            if (u != null) {
                if (u.password == pass.Text) {
                    globalref.activeUser = u;
                    await DisplayAlert("Login successful", $"Welcome back, {u.fname}", "Continue");
                    globalref.RecentListingsCollection = new ObservableCollection<Listing>();
                    globalref.MainPage = new AppShell();
                }
                else
                {
                    await DisplayAlert("Login unsuccessful", "Wrong password", "OK");
                }
            }
            else {
                await DisplayAlert("Email address not registered", "Please sign up", "OK");
            }
        }
        else
        {
            await DisplayAlert("Please fill all fields", "", "OK");
        }
    }

    async void SignUpBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        //await Navigation.PushAsync(new CreateAccount());
        globalref.MainPage = new CreateAccount();
    }
}
