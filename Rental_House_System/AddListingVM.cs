using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Rental_House_System
{
    public class AddListingVM : INotifyPropertyChanged
    {
        private Color _stackColor;

        public Color StackColor
        {
            get { return _stackColor; }
            set
            {
                _stackColor = value;
                OnPropertyChanged(nameof(StackColor));
            }
        }

        public ICommand ChangeColorCommand { get; set; }

        public AddListingVM()
        {
            StackColor = Color.FromHex("#C8C8C8"); // Initial color
            ChangeColorCommand = new Command<object>(ChangeColor);

            AddedImages = new ObservableCollection<string>();
            FeaturesDictionary = new Dictionary<string, bool>();

            FeaturesDictionary["Bills included"] = false;
            FeaturesDictionary["Internet included"] = false;
            FeaturesDictionary["TV"] = false;
            FeaturesDictionary["Gym membership"] = false;
            FeaturesDictionary["Kitchen"] = false;
            FeaturesDictionary["Fridge"] = false;
            FeaturesDictionary["Dish washer"] = false;
            FeaturesDictionary["Washing machine"] = false;
            FeaturesDictionary["Long term"] = false;
            FeaturesDictionary["Parking"] = false;

            date = DateTime.Today;
        }

        private void ChangeColor(object sender)
        {
            //StackColor = StackColor == Colors.Black ? Color.FromHex("#C8C8C8") : Colors.Black; // Change color after tap
            var label = sender as Label;
            if (label != null)
            {
                label.FontAttributes = label.FontAttributes == FontAttributes.Bold ? FontAttributes.None : FontAttributes.Bold;
                Frame frame = (Frame)label.Parent;
                frame.HasShadow = !(frame.HasShadow);
                frame.BorderColor = frame.BorderColor == Colors.Black ? Color.FromHex("#C8C8C8") : Colors.Black;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _type = "";
        public string type
        {
            get { return _type; }
            set
            {
                if (value != null)
                {
                    _type = value;
                    OnPropertyChanged("type");
                }
            }
        }

        private string _furnishing = "Furnished";
        public string furnishing
        {
            get { return _furnishing; }
            set
            {
                if (value != null)
                {
                    _furnishing = value;
                    OnPropertyChanged("furnishing");
                }
            }
        }

        private int _rooms = 1;
        public int rooms
        {
            get { return _rooms; }
            set
            {
                if (value != null)
                {
                    _rooms = value;
                    OnPropertyChanged("rooms");
                }
            }
        }

        private int _bath = 1;
        public int bath
        {
            get { return _bath; }
            set
            {
                if (value != null)
                {
                    _bath = value;
                    OnPropertyChanged("bath");
                }
            }
        }

        private float _price = 1;
        public float price
        {
            get { return _price; }
            set
            {
                if (value != null)
                {
                    _price = value > 0 ? value : 1;
                    OnPropertyChanged("price");
                }
            }
        }

        private DateTime _date;
        public DateTime date
        {
            get { return _date; }
            set
            {
                if (value != null)
                {
                    _date = value;
                    OnPropertyChanged("date");
                }
            }
        }

        private string _streetName = "";
        public string streetName
        {
            get { return _streetName; }
            set
            {
                if (value != null)
                {
                    _streetName = value;
                    OnPropertyChanged("streetName");
                }
            }
        }

        private string _city = "";
        public string city
        {
            get { return _city; }
            set
            {
                if (value != null)
                {
                    _city = value;
                    OnPropertyChanged("city");
                }
            }
        }

        private string _postcode = "";
        public string postcode
        {
            get { return _postcode; }
            set
            {
                if (value != null)
                {
                    _postcode = value;
                    OnPropertyChanged("postcode");
                }
            }
        }

        private string _agentName = "";
        public string agentName
        {
            get { return _agentName; }
            set
            {
                if (value != null)
                {
                    _agentName = value;
                    OnPropertyChanged("agentName");
                }
            }
        }

        private string _agentEmail = "";
        public string agentEmail
        {
            get { return _agentEmail; }
            set
            {
                if (value != null)
                {
                    _agentEmail = value;
                    OnPropertyChanged("agentEmail");
                }
            }
        }

        private string _agentPhone = "";
        public string agentPhone
        {
            get { return _agentPhone; }
            set
            {
                if (value != null)
                {
                    _agentPhone = value;
                    OnPropertyChanged("agentPhone");
                }
            }
        }

        private Dictionary<string, bool> featuresDictionary;
        public Dictionary<string, bool> FeaturesDictionary
        {
            get { return featuresDictionary; }
            set
            {
                if (value != null)
                {
                    featuresDictionary = value;
                    OnPropertyChanged("FeaturesDictionary");
                }
            }
        }

        private ObservableCollection<string> addedImages;
        public ObservableCollection<string> AddedImages
        {
            get { return addedImages; }
            set
            {
                if (value != null)
                {
                    addedImages = value;
                    OnPropertyChanged("AddedImages");
                }
            }
        }

        public void ResetVM()
        {
            AddedImages = new ObservableCollection<string>();
            FeaturesDictionary = new Dictionary<string, bool>();

            FeaturesDictionary["Bills included"] = false;
            FeaturesDictionary["Internet included"] = false;
            FeaturesDictionary["TV"] = false;
            FeaturesDictionary["Gym membership"] = false;
            FeaturesDictionary["Kitchen"] = false;
            FeaturesDictionary["Fridge"] = false;
            FeaturesDictionary["Dish washer"] = false;
            FeaturesDictionary["Washing machine"] = false;
            FeaturesDictionary["Long term"] = false;
            FeaturesDictionary["Parking"] = false;

            date = DateTime.Today;
            agentEmail = ""; agentName = "";
            agentPhone = ""; type = "";
            furnishing = "Furnished"; bath = 1;
            rooms = 1; price = 1;
            streetName = ""; city = "";
            postcode = "";
        }
    }
}

