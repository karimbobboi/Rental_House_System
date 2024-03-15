using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection.PortableExecutable;
using Microsoft.Maui.Controls.Compatibility;
using static Android.Service.Notification.NotificationListenerService;

namespace Rental_House_System;

public class EditUserVM : INotifyPropertyChanged
{
    User UserInstance;
    App globalref = (App)Application.Current;
    public ObservableCollection<Saved> savedListings = new ObservableCollection<Saved>();

    AppDatabase AppDB = new AppDatabase();
    public EditUserVM()
    {
        //AllStudents = student.LoadAllStudents();
        UserInstance = new User();
        ActiveUser = globalref.activeUser;
        AllListings = globalref.appDB.GetAllListings();
        SavedListingsCollection = GetSavedListingsCollection();

        MessagingCenter.Subscribe<MainViewModel, string>(this, "CollectionChanged", (sender, arg) =>
        {
            SavedListingsCollection = GetSavedListingsCollection();
            System.Diagnostics.Debug.WriteLine("rdectfvgybhuij " + SavedListingsCollection.Count);
        });
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    private ObservableCollection<Listing> allListings;
    public ObservableCollection<Listing> AllListings
    {
        get { return allListings; }
        set
        {
            if (value != null)
            {
                allListings = value;
                OnPropertyChanged("AllListings");
            }
        }
    }

    private ObservableCollection<Listing> savedListingsCollection;
    public ObservableCollection<Listing> SavedListingsCollection
    {
        get { return savedListingsCollection; }
        set
        {
            if (value != null)
            {
                savedListingsCollection = value;
                OnPropertyChanged("SavedListingsCollection");
            }
        }
    }

    private User activeUser;
    public User ActiveUser
    {
        get
        {
            return activeUser;
        }
        set
        {
            if (activeUser != value)
            {
                activeUser = value; 
                fname = activeUser.fname; 
                lname = activeUser.lname; 
                email = activeUser.email; 
                password = activeUser.password; 
            }
        }
    }

    private string _fname;
    public string fname
    {
        get { return _fname; }
        set
        {
            if (value != null)
            {
                _fname = value;
                OnPropertyChanged("fname");
            }
        }
    }

    private string _lname;
    public string lname
    {
        get { return _lname; }
        set
        {
            if (value != null)
            {
                _lname = value;
                OnPropertyChanged("lname");
            }
        }
    }

    private string _email;
    public string email
    {
        get { return _email; }
        set
        {
            if (value != null)
            {
                _email = value;
                OnPropertyChanged("email");
            }
        }
    }

    private string _password;
    public string password
    {
        get { return _password; }
        set
        {
            if (value != null)
            {
                _password = value;
                OnPropertyChanged("password");
            }
        }
    }

    public void UpdateUser()
    {
        User u = new User();
        u.uid = globalref.activeUser.uid;
        u.fname = fname;
        u.lname = lname;
        u.email = email;
        u.password = password;

        // Call the uodate function in Model
        globalref.appDB.UpdateUser(u);
    }

    public void DeleteUser()
    {
        globalref.appDB.DeleteUser(globalref.activeUser);
    }

    public ObservableCollection<Listing> GetSavedListingsCollection()
    {
        ObservableCollection<Listing> AllListings = globalref.appDB.GetAllListings();
        ObservableCollection<Saved> savedListings = globalref.appDB.GetAllSavedByUserID(activeUser.uid);

        var idsToFilter = savedListings.Select(saved => saved.listingId).ToArray();
        var listingsWithMatchingIds = AllListings.Where(listing => idsToFilter.Contains(listing.lId)).ToList();

        ObservableCollection<Listing> saved = new ObservableCollection<Listing>(listingsWithMatchingIds);
        return saved;
    }
}

public partial class EditUser : ContentPage
{
    App globalref = (App)Application.Current;
    EditUserVM editUserVM;
    public EditUser(EditUserVM temp)
	{
		InitializeComponent();
        //firstNameGrid.BindingContext = globalref.activeUser;

        //editUserVM = new EditUserVM();
        editUserVM = temp; 
        BindingContext = editUserVM;
        //fields.BindingContext = globalref.activeUser;

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
