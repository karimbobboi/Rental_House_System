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

    public void LoadSavedListingsCollection() {
        ObservableCollection<Listing> AllListings = appDB.GetAllListings();
        ObservableCollection<Saved> savedListings = appDB.GetAllSavedByUserID(activeUser.uid);
        
        var idsToFilter = savedListings.Select(saved => saved.listingId).ToArray();
        var listingsWithMatchingIds = AllListings.Where(listing => idsToFilter.Contains(listing.lId)).ToList();

        SavedListingsCollection = new ObservableCollection<Listing>(listingsWithMatchingIds);
        System.Diagnostics.Debug.WriteLine("qwertyu " + SavedListingsCollection.Count);
    }
}