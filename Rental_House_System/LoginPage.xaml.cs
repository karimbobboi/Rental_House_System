namespace Rental_House_System;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    async void SignInBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        App globalref = (App)Application.Current;
        if (!(electronicMail.Text == "" || pass.Text == "")) {
            User u = globalref.appDB.GetUserByEmail(electronicMail.Text);
            if (u != null) {
                if (u.password == pass.Text) {
                    globalref.activeUser = u;
                    await DisplayAlert("Login successful", $"Welcome back, {u.fname}", "Continue");
                    globalref.MainPage = new AppShell();
                }
                else
                {
                    await DisplayAlert("Login unsuccessful", "Wrong password", "OK");
                }
            }
            else {
                await DisplayAlert("An error occurred", "Please retry", "OK");
            }
        }
        else
        {
            await DisplayAlert("Please fill all fields", "", "OK");
        }
    }

    async void SignUpBtn_Clicked(System.Object sender, System.EventArgs e)
    {
		await Navigation.PushAsync(new CreateAccount());
    }
}
