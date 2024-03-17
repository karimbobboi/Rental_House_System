using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Rental_House_System;

//public class AddListingVM : INotifyPropertyChanged
//{
//    App globalref = (App)Application.Current;
//    AppDatabase AppDB = new AppDatabase();
//    public AddListingVM()
//    {
//    }

//    public event PropertyChangedEventHandler PropertyChanged;
//    private void OnPropertyChanged(string propertyName)
//    {
//        if (PropertyChanged != null)
//        {
//            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
//        }
//    }
//}

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

    public void ResetVM() {
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

public partial class AddListing : ContentPage
{
    AddListingVM addListingVM;
    App globalref = (App)Application.Current;
    public AddListing()
	{
		InitializeComponent();
        addListingVM = new AddListingVM();
        BindingContext = addListingVM;
        SizeChanged += OnPageSizeChanged;

        secondPage.IsVisible = false;
        thirdPage.IsVisible = false;
        fourthPage.IsVisible = false;
        datePicker.MinimumDate = DateTime.Today;
        furnishing.SelectedIndex = 0;
    }

    private void OnPageSizeChanged(object sender, EventArgs e)
    {
        // Retrieve device height
        double deviceHeight = Application.Current.MainPage.Height;
        main.HeightRequest = deviceHeight;
    }

    async void FirstToSecond(System.Object sender, System.EventArgs e)
    {
        if (addListingVM.type == "")
        {
            await DisplayAlert("Please select a type", "", "OK");
            return;
        }
        firstPage.IsVisible = false;
        secondPage.IsVisible = true;
        double deviceHeight = Application.Current.MainPage.Height;
        secondPage.HeightRequest = deviceHeight;
    }

    void SecondToFirst(System.Object sender, System.EventArgs e)
    {
        secondPage.IsVisible = false;
        firstPage.IsVisible = true;
        double deviceHeight = Application.Current.MainPage.Height;
        firstPage.HeightRequest = deviceHeight;

        System.Diagnostics.Debug.WriteLine($"{ addListingVM.date}");
    }

    async void SecondToThird(System.Object sender, System.EventArgs e)
    {
        if (addListingVM.price < 1) {
            await DisplayAlert("Please provide a price", "", "OK");
            return;
        }
        secondPage.IsVisible = false;
        thirdPage.IsVisible = true;
        double deviceHeight = Application.Current.MainPage.Height;
        thirdPage.HeightRequest = deviceHeight;
    }

    void ThirdToSecond(System.Object sender, System.EventArgs e)
    {
        thirdPage.IsVisible = false;
        secondPage.IsVisible = true;
        double deviceHeight = Application.Current.MainPage.Height;
        secondPage.HeightRequest = deviceHeight;
    }

    async void ThirdToFourth(System.Object sender, System.EventArgs e)
    {
        if (Street.Text == "" || City.Text == "" ||
            Postcode.Text == "" || AgentName.Text == "" ||
            AgentEmail.Text == "" || AgentPhone.Text == "")
        {
            if (AgentPhone.Text.Length < 14) {
                await DisplayAlert("Please fill phone number field completely", "", "OK");
                return;
            }
            await DisplayAlert("Please fill all fields", "", "OK");
            return;
        }

        thirdPage.IsVisible = false;
        fourthPage.IsVisible = true;
        double deviceHeight = Application.Current.MainPage.Height;
        fourthPage.HeightRequest = deviceHeight;
    }

    void FourthToThird(System.Object sender, System.EventArgs e)
    {
        fourthPage.IsVisible = false;
        thirdPage.IsVisible = true;
        double deviceHeight = Application.Current.MainPage.Height;
        fourthPage.HeightRequest = deviceHeight;
    }

    void PropertySelect_Clicked(System.Object sender, System.EventArgs e)
    {
        var button = sender as Button;
        if (button != null)
        {
            foreach (var fr in props.Children.OfType<Frame>())
            {
                fr.HasShadow = false;
                fr.BorderColor = Color.FromHex("#C8C8C8");
                var frameButton = fr.Content as Button;
                if (frameButton != null)
                {
                    frameButton.FontAttributes = FontAttributes.None;
                }
            }

            button.FontAttributes = button.FontAttributes == FontAttributes.Bold ? FontAttributes.None : FontAttributes.Bold;
            Frame frame = (Frame)button.Parent;
            frame.HasShadow = !(frame.HasShadow);
            frame.BorderColor = frame.BorderColor == Colors.Black ? Color.FromHex("#C8C8C8") : Colors.Black;
            addListingVM.type = button.Text;
        }
    }

    void FeatureSelect_Clicked(System.Object sender, System.EventArgs e)
    {
        var button = sender as Button;
        if (button != null)
        { 
            button.FontAttributes = button.FontAttributes == FontAttributes.Bold ? FontAttributes.None : FontAttributes.Bold;
            Frame frame = (Frame)button.Parent;
            frame.HasShadow = !(frame.HasShadow);
            frame.BorderColor = frame.BorderColor == Colors.Black ? Color.FromHex("#C8C8C8") : Colors.Black;

            string key = button.Text;
            if (addListingVM.FeaturesDictionary.ContainsKey(key))
            {
                addListingVM.FeaturesDictionary[key] = !(addListingVM.FeaturesDictionary[key]);
            }
        }
    }

    async void AddImageClicked(System.Object sender, System.EventArgs e) {
        try
        {
            var photo = await MediaPicker.PickPhotoAsync();
            if (photo != null)
            {
                var PhotoPath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                using (var stream = await photo.OpenReadAsync())
                using (var newStream = File.OpenWrite(PhotoPath))
                {
                    await stream.CopyToAsync(newStream);
                }
                addListingVM.AddedImages.Add(PhotoPath);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }

    void LabelTapped(System.Object sender, System.EventArgs e)
    {
        Label label = (Label)sender;
        Grid grid = (Grid)label.Parent;
        Image image = (Image)grid.Children[0];
        addListingVM.AddedImages.Remove(image.Source.ToString().Substring(6));
    }

    void BedButton_Clicked(System.Object sender, System.EventArgs e)
    {
        Button button = (Button)sender;
        if(addListingVM.rooms > 1 && addListingVM.rooms < 18)
            addListingVM.rooms = button.Text == "+" ? addListingVM.rooms + 1 : addListingVM.rooms - 1;
        else if (addListingVM.rooms == 1)
            addListingVM.rooms = button.Text == "+" ? addListingVM.rooms + 1 : addListingVM.rooms;
        else if (addListingVM.rooms == 18)
            addListingVM.rooms = button.Text == "+" ? addListingVM.rooms : addListingVM.rooms - 1;
    }

    void BathButton_Clicked(System.Object sender, System.EventArgs e)
    {
        Button button = (Button)sender;
        if (addListingVM.bath > 1 && addListingVM.bath < 18)
            addListingVM.bath = button.Text == "+" ? addListingVM.bath + 1 : addListingVM.bath - 1;
        else if (addListingVM.bath == 1)
            addListingVM.bath = button.Text == "+" ? addListingVM.bath + 1 : addListingVM.bath;
        else if (addListingVM.bath == 18)
            addListingVM.bath = button.Text == "+" ? addListingVM.bath : addListingVM.bath - 1;
    }

    void BackToLogin(System.Object sender, System.EventArgs e)
    {
        globalref.MainPage = new LoginPage();
    }

   async void PublishListingBtn(System.Object sender, System.EventArgs e)
    {
        if(addListingVM.AddedImages.Count == 0) {
            await DisplayAlert("Please add at least 1 image", "", "OK");
            return;
        }

        Agent ag = globalref.appDB.GetAgentByEmail(addListingVM.agentEmail);
        if (ag == null)
        {
            ag = new Agent();
            ag.name = addListingVM.agentName;
            ag.email = addListingVM.agentEmail;
            ag.phone = addListingVM.agentPhone;

            globalref.appDB.AddAgent(ag);
        }

        string imgsString = globalref.appDB.ArrayToImageString(addListingVM.AddedImages.ToArray());

        Listing newListing = new Listing()
        {
            price = (int)addListingVM.price,
            agentEmail = ag.email,
            images = imgsString,
            streetName = addListingVM.streetName,
            postcode = addListingVM.postcode,
            city = addListingVM.city,
            type = addListingVM.type,
            available = addListingVM.date.ToString("dd/MM/yyyy"),
            numRooms = addListingVM.rooms,
            numToilets = addListingVM.bath,
            bills = addListingVM.FeaturesDictionary["Bills included"],
            internet = addListingVM.FeaturesDictionary["Internet included"],
            tv = addListingVM.FeaturesDictionary["TV"],
            gym = addListingVM.FeaturesDictionary["Gym membership"],
            lterm = addListingVM.FeaturesDictionary["Long term"],
            kitchen = addListingVM.FeaturesDictionary["Kitchen"],
            dishwasher = addListingVM.FeaturesDictionary["Dish washer"],
            wmachine = addListingVM.FeaturesDictionary["Washing machine"],
            park = addListingVM.FeaturesDictionary["Parking"],
            fridge = addListingVM.FeaturesDictionary["Fridge"]
        };
        System.Diagnostics.Debug.WriteLine("qw7");
        globalref.appDB.AddListing(newListing);
        System.Diagnostics.Debug.WriteLine("qw8");
        bool answer = await DisplayAlert("Listing published successfully!!", "Do you want to publish another one?", "Yes", "No");
        if (answer)
        {
         // Reset entire page   
            secondPage.IsVisible = false;
            thirdPage.IsVisible = false;
            fourthPage.IsVisible = false;
            firstPage.IsVisible = true;
            furnishing.SelectedIndex = 0;
            addListingVM.ResetVM();
            double deviceHeight = Application.Current.MainPage.Height;
            firstPage.HeightRequest = deviceHeight;

            // reset the features and property details buttons
            foreach (var fr in props.Children.OfType<Frame>())
            {
                fr.HasShadow = false;
                fr.BorderColor = Color.FromHex("#C8C8C8");
                var frameButton = fr.Content as Button;
                if (frameButton != null)
                {
                    frameButton.FontAttributes = FontAttributes.None;
                }
            }

            foreach (var fr in features.Children.OfType<Frame>())
            {
                fr.HasShadow = false;
                fr.BorderColor = Color.FromHex("#C8C8C8");
                var frameButton = fr.Content as Button;
                if (frameButton != null)
                {
                    frameButton.FontAttributes = FontAttributes.None;
                }
            }
        } else
        {
            globalref.MainPage = new LoginPage();
        }

    }
}
