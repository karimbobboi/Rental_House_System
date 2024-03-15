﻿namespace Rental_House_System;

public partial class CreateAccount : ContentPage
{
    bool email_valid = false, password_valid = false;
    public CreateAccount()
	{
		InitializeComponent();
	}

    async void CreateBtn_Clicked(System.Object sender, System.EventArgs e)
    {
		App globalref = (App)Application.Current;
		if (!(firstName.Text == "" || lastName.Text == "" ||
            electronicMail.Text == "" || pass.Text == "")) {

            validate_email(electronicMail.Text);
            validate_password(pass.Text);
            if (!email_valid || !password_valid) { return; }
            else if (globalref.appDB.GetUserByEmail(electronicMail.Text) == null)
			{
				User u = new User();
				u.fname = firstName.Text;
				u.lname = lastName.Text;
				u.email = electronicMail.Text;
				u.password = pass.Text;

				globalref.appDB.AddUser(u);
                await DisplayAlert("Account successfully created",
                    $"Welcome {firstName.Text}", "Continue");
                globalref.MainPage = new LoginPage();
                ///await Navigation.PopAsync();
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

    async void validate_email(string eml)
    {
        if (Char.IsLetterOrDigit(eml[0]) && eml.Contains('@') && (eml.Contains(".com") || eml.Contains(".co.uk")))
        {
            email_valid = true;
        }
        else
        {
            email_valid = false;
            await DisplayAlert("Input invalid", "Please input a valid email address", "OK");
        }
    }

    async void validate_password(string prd)
    {
        bool upper = false, lower = false, digit = false, sym = false;
        for (int i = 0; i < prd.Length; i++)
        {
            if (Char.IsUpper(prd[i]))
            {
                upper = true;
                continue;
            }
            if (Char.IsLower(prd[i]))
            {
                lower = true;
                continue;
            }
            if (Char.IsDigit(prd[i]))
            {
                digit = true;
                continue;
            }
            if (Char.IsSymbol(prd[i]) || prd[i] == '@')
            {
                sym = true;
                continue;
            }
        }
        if (upper && lower && digit && sym)
        {
            password_valid = true;
        }
        else
        {
            System.Diagnostics.Debug.WriteLine("fail " + prd);
            password_valid = false;
            await DisplayAlert("Input invalid",
                "Password must include atleast 1 uppercase, atleast 1 lowercase, atleast 1 number and atleast 1 symbol",
                "OK");
        }
    }
}
