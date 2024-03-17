using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection.PortableExecutable;
using Microsoft.Maui.Controls.Compatibility;
using static Android.Service.Notification.NotificationListenerService;

namespace Rental_House_System;

public partial class EditUser : ContentPage
{
    App globalref = (App)Application.Current;
    EditUserVM editUserVM;
    public EditUser(EditUserVM temp)
	{
		InitializeComponent();
        editUserVM = temp; 
        BindingContext = editUserVM;
    }

    async void CancelBtn_Clicked(System.Object sender, System.EventArgs e)
    {
		await Navigation.PopAsync();
    }

    async void SaveBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        
        if (!(firstName.Text == "" || lastName.Text == "" ||
            electronicMail.Text == "" || pass.Text == ""))
        {
            if(firstName.Text == globalref.activeUser.fname &&
            lastName.Text == globalref.activeUser.lname &&
            electronicMail.Text == globalref.activeUser.email &&
            pass.Text == globalref.activeUser.password) { // check if any change made
                await DisplayAlert("No change made",
                    $"{firstName.Text} , {globalref.activeUser.fname}", "Continue");
                return;
            }

            var res = globalref.appDB.GetUserByEmail(electronicMail.Text);
            if (res == null || res.email == globalref.activeUser.email)
            {
                User u = new User();
                u.fname = firstName.Text;
                u.lname = lastName.Text;
                u.email = electronicMail.Text;
                u.password = pass.Text;

                //globalref.appDB.UpdateUser(u);
                editUserVM.UpdateUser();
                await DisplayAlert("Changes to profile completed",
                    "", "Continue");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("User already exists",
                    $"There is already an account with the email address '{electronicMail.Text}'",
                    "OK");
            }
        }
        else
        {
            await DisplayAlert("Please fill all fields", "", "OK");
        }
    }

    void EditBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        var editButton = (Button)sender;
        var parentGrid = editButton.Parent as Microsoft.Maui.Controls.Grid;
        var fieldEntry = (Entry)parentGrid.Children[1];

        fieldEntry.BackgroundColor = Colors.LightGray;
        fieldEntry.IsEnabled = true;
    }

    async void DeleteBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        bool answer = await DisplayAlert("Are you sure you want to delete this account?",
            "Please tap yes if you want to permanently delete this account.", "Yes", "No");
        if (answer) {
            editUserVM.DeleteUser();
            await DisplayAlert("Account deleted", "Sorry to see you go!", "Continue");
            globalref.LogOut();
        }

    }
}
