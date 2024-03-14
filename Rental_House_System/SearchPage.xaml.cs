using System.ComponentModel;

namespace Rental_House_System;

public class SearchVM : INotifyPropertyChanged
{
    App globalref = (App)Application.Current;
    AppDatabase AppDB = new AppDatabase();

    //public int lId { get; set; }
    //public Agent agent { get; set; }
    //public int price { get; set; }
    //public Address address { get; set; }
    //public string type { get; set; }
    //public string available { get; set; }
    //public string[] images { get; set; }
    //public string furnished { get; set; } = "Unfurnished";

    //public int numRooms { get; set; }
    //public int numToilets { get; set; }

    //public bool bills { get; set; } = false;
    //public bool internet { get; set; } = false;
    //public bool tv { get; set; } = false;
    //public bool gym { get; set; } = false;
    //public bool lterm { get; set; } = false;
    //public bool kitchen { get; set; } = false;
    //public bool dishwasher { get; set; } = false;
    //public bool wmachine { get; set; } = false;
    //public bool park { get; set; } = false;
    //public bool fridge { get; set; } = false;


    public SearchVM()
    {
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    //private Listing activeUser;
    //public User ActiveUser
    //{
    //    get
    //    {
    //        return activeUser;
    //    }
    //    set
    //    {
    //        if (activeUser != value)
    //        {
    //            activeUser = value;
    //            fname = activeUser.fname;
    //            lname = activeUser.lname;
    //            email = activeUser.email;
    //            password = activeUser.password;
    //        }
    //    }
    //}

    private bool _kitchen;
    public bool kitchen
    {
        get { return _kitchen; }
        set
        {
            if (value != null)
            {
                _kitchen = value;
                OnPropertyChanged("kitchen");
            }
        }
    }

    private bool _wMachine;
    public bool wMachine
    {
        get { return _wMachine; }
        set
        {
            if (value != null)
            {
                _wMachine = value;
                OnPropertyChanged("wMachine");
            }
        }
    }

    private bool _dishwasher;
    public bool dishwasher
    {
        get { return _dishwasher; }
        set
        {
            if (value != null)
            {
                _dishwasher = value;
                OnPropertyChanged("dishwasher");
            }
        }
    }

    private bool _fridge;
    public bool fridge
    {
        get { return _fridge; }
        set
        {
            if (value != null)
            {
                _fridge = value;
                OnPropertyChanged("fridge");
            }
        }
    }

    private bool _parking;
    public bool parking
    {
        get { return _parking; }
        set
        {
            if (value != null)
            {
                _parking = value;
                OnPropertyChanged("parking");
            }
        }
    }

    private bool _tv;
    public bool tv
    {
        get { return _tv; }
        set
        {
            if (value != null)
            {
                _tv = value;
                OnPropertyChanged("tv");
            }
        }
    }

    private bool _gym;
    public bool gym
    {
        get { return _gym; }
        set
        {
            if (value != null)
            {
                _gym = value;
                OnPropertyChanged("gym");
            }
        }
    }

    private bool _bills;
    public bool bills
    {
        get { return _bills; }
        set
        {
            if (value != null)
            {
                _bills = value;
                OnPropertyChanged("bills");
            }
        }
    }

    private bool _shortTerm;
    public bool shortTerm
    {
        get { return _shortTerm; }
        set
        {
            if (value != null)
            {
                _shortTerm = value;
                OnPropertyChanged("shortTerm");
            }
        }
    }

    private bool _internet;
    public bool internet
    {
        get { return _internet; }
        set
        {
            if (value != null)
            {
                _internet = value;
                OnPropertyChanged("internet");
            }
        }
    }

    //private string _lname;
    //public string lname
    //{
    //    get { return _lname; }
    //    set
    //    {
    //        if (value != null)
    //        {
    //            _lname = value;
    //            OnPropertyChanged("lname");
    //        }
    //    }
    //}

    //private string _email;
    //public string email
    //{
    //    get { return _email; }
    //    set
    //    {
    //        if (value != null)
    //        {
    //            _email = value;
    //            OnPropertyChanged("email");
    //        }
    //    }
    //}

    //private string _password;
    //public string password
    //{
    //    get { return _password; }
    //    set
    //    {
    //        if (value != null)
    //        {
    //            _password = value;
    //            OnPropertyChanged("password");
    //        }
    //    }
    //}

    //public void UpdateUser()
    //{
    //    User u = new User();
    //    u.uid = globalref.activeUser.uid;
    //    u.fname = fname;
    //    u.lname = lname;
    //    u.email = email;
    //    u.password = password;ssss

    //    // Call the uodate function in Model
    //    globalref.appDB.UpdateUser(u);
    //}

    //public void OnSearch()
    //{
    //    globalref.appDB.DeleteUser(globalref.activeUser);
    //}
}


public partial class SearchPage : ContentPage
{
    SearchVM searchVM;
    public SearchPage()
	{
		InitializeComponent();
        searchVM = new SearchVM();
        BindingContext = searchVM;
        furnishing.SelectedIndex = 0;
        radiusPicker.SelectedIndex = 0;
        propertyPicker.SelectedIndex = 0;
    }

    async void SearchButton_Clicked(System.Object sender, System.EventArgs e)
    {
        App globalref = (App)Application.Current;
        if (searchBar.Text != "")
		    await Navigation.PushAsync(new SearchResults(globalref.appDB.GetAllListings()));
    }

    async void FiltersButton_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushModalAsync(new SearchFiltersModal(searchVM));
    }

    void ClearButton_Clicked(System.Object sender, System.EventArgs e) { }
}
