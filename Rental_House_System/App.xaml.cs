using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Rental_House_System;

public partial class App : Application
{
    public User activeUser;
    public AppDatabase appDB = new AppDatabase();
    public App()
	{
		InitializeComponent();
		activeUser = new User();
        MainPage = new LoginPage();
        RecentListingsCollection = new ObservableCollection<Listing>();
        //MainPage = new SearchPage();
    }

    public void LogOut()
    {
        MainPage = new LoginPage();
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    private ObservableCollection<Listing> recentListingsCollection;
    public ObservableCollection<Listing> RecentListingsCollection
    {
        get { return recentListingsCollection; }
        set
        {
            if (value != null)
            {
                recentListingsCollection = value;
                OnPropertyChanged("RecentListingsCollection");
            }
        }
    }
}