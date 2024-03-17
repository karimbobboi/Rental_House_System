using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Rental_House_System
{
    public class EditUserVM : INotifyPropertyChanged
    {
        User UserInstance;
        App globalref = (App)Application.Current;
        public ObservableCollection<Saved> savedListings = new ObservableCollection<Saved>();

        AppDatabase AppDB = new AppDatabase();
        public EditUserVM()
        {
            UserInstance = new User();
            ActiveUser = globalref.activeUser;
            AllListings = globalref.appDB.GetAllListings();
            SavedListingsCollection = GetSavedListingsCollection();

            MessagingCenter.Subscribe<MainViewModel, string>(this, "CollectionChanged", (sender, arg) =>
            {
                SavedListingsCollection = GetSavedListingsCollection();
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
}
