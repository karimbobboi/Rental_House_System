using System.Globalization;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Graphics.Text;
using static Java.Util.Jar.Attributes;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;
using System.ComponentModel;

namespace Rental_House_System;

public class MainViewModel : BindableObject
{
    App globalref = (App)Microsoft.Maui.Controls.Application.Current;
    public string[] ImageList { get; set; }
    public Listing toRent;

    public MainViewModel(Listing temp)
    {
        //ImageList = new List<string>
        //    {
        //        "house_example.jpeg",
        //        "bathroom.jpeg",
        //        "living_room.jpeg"
        //    };
        toRent = temp;
        ImageList = globalref.appDB.ImageStringToArray(toRent);

        if (globalref.appDB.GetSavedByIds(globalref.activeUser.uid, toRent.lId) == null)
        {
            System.Diagnostics.Debug.WriteLine("wertyui");
            saved = false;
        }
        else
        {
            System.Diagnostics.Debug.WriteLine("wertyu12212122i");
            saved = true;
        }

    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    private bool _saved = false;
    public bool saved { get {
            return _saved;
        }
        set
        {
            if (value != null)
            {
                _saved = value;
                OnPropertyChanged("saved");
            }
        }
    }

    public int AddSaved()
    {
        Saved s = new Saved();
        s.userId = globalref.activeUser.uid;
        s.listingId = toRent.lId;
        int res;
        if (globalref.appDB.GetSavedByIds(globalref.activeUser.uid, toRent.lId) == null) {
            res = globalref.appDB.AddSaved(s);
        } else
        {
            res = globalref.appDB.UpdateSaved(s);
            
        }
        globalref.LoadSavedListingsCollection();
        MessagingCenter.Send<MainViewModel, string>(this, "CollectionChanged", "CollectionUpdated");
        return res;

        // Call the uodate function in Model
    }

    public int RemoveSaved()
    {
        Saved s = globalref.appDB.GetSavedByIds(globalref.activeUser.uid, toRent.lId);
        int res = -1;
        if (s != null)
        {
            res = globalref.appDB.DeleteSaved(s);
        }
        MessagingCenter.Send<MainViewModel, string>(this, "CollectionChanged", "CollectionUpdated");
        return res;

        // Call the uodate function in Model
    }
}

public class IntToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value.ToString();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return null;
    }
}

public partial class RentPage : ContentPage
{
    public string currentImg;
    public string totalImgs;
    public string fullText;
    public Listing toRent;

    public readonly string blankSaved = "\u2661";
    public readonly string fullSaved = "\u2665";

    App globalref = (App)Microsoft.Maui.Controls.Application.Current;
    private MainViewModel images;

    public RentPage(Listing temp)
	{
        InitializeComponent();
        toRent = temp;
        //ImageList = globalref.appDB.ImageStringToArray(toRent);
        
        images = new MainViewModel(temp);
        BindingContext = images;
        rrr.BindingContext = toRent;

        currentImg = "1";
        totalImgs = images.ImageList.Length.ToString();
        fullText = currentImg + "/" + totalImgs;

        initLabels();

        if(images.saved)
        {
            savedBtn.Text = fullSaved;
            savedBtn.FontSize = 18;
        } else {
            savedBtn.Text = blankSaved;
            savedBtn.FontSize = 25;
        }
    }

    void ShowBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        for (int i = 6; i < props.Count; i++) {
            var child = props.Children[i];

            if (child is Label label)
            {
                label.IsVisible = true;
            } else if (child is Microsoft.Maui.Controls.Button bt)
            {
                bt.IsVisible = true;
            }
        }
        showBtn.IsVisible = false;
    }

    void HideBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        for (int i = 6; i < props.Count; i++)
        {
            var child = props.Children[i];

            if (child is Label label)
            {
                label.IsVisible = false;
            }
            else if (child is Microsoft.Maui.Controls.Button bt)
            {
                bt.IsVisible = false;
            }
        }
        showBtn.IsVisible = true;
    }

    private bool initLabels()
    {

        List<string> features = new List<string>();
        if (toRent.bills)
            features.Add("Bills included");
        if (toRent.internet)
            features.Add("Internet included");
        if (toRent.kitchen)
            features.Add("Kitchen");

        if (toRent.tv)
            features.Add("TV");
        if (toRent.gym)
            features.Add("Gym");
        if (toRent.lterm)
            features.Add("Long term");
        else if (!toRent.lterm)
            features.Add("Short term");

        if (toRent.park)
            features.Add("Parking");
        if (toRent.wmachine)
            features.Add("Washing machine");
        if (toRent.dishwasher)
            features.Add("Dish washer");

        int index = 0; bool vis = true;
        
        for (int i = 0; i < features.Count; i++) {
            for (int j = 0; j < 3; j++) {
                try
                {
                    if (features.Count > 6 && (i == 1 && j == 2))
                    {
                        vis = false;
                    }
                    Label label1 = new Label();
                    label1.Text = features[index];
                    label1.FontSize = 13;
                    label1.IsVisible = vis;
                    props.Add(label1, j, i);
                    index++;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Trace.Write("Something went wrong.");
                    break;
                }
            }
        }

        if (features.Count > 6)
        {

            Microsoft.Maui.Controls.Button hdBtn = new Microsoft.Maui.Controls.Button
            {
                BackgroundColor = Colors.Transparent,
                FontAttributes = FontAttributes.Bold,
                Padding = new Thickness(0),
                HorizontalOptions = LayoutOptions.Start,
                Text = "Hide >",
                TextColor = Colors.Black,
                FontSize = 13,
                IsVisible = false
            };
            hdBtn.Clicked += HideBtn_Clicked;
            int mod = features.Count % 3;
            props.Add(hdBtn, mod, (features.Count / 3));
        } else
        {
            showBtn.IsVisible = false;
        }

        return true;
    }

    public async void EmailBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new EmailAgent(toRent));
    }

    public async void CallBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        bool answer = await DisplayAlert($"Call +{44123456789}", "Do you want to call the agent?", "Call", "Cancel");

        if (answer)
        {
            
        }
    }

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        Button button = sender as Button;
        if (button.Text == "\u2661") {
            button.Text = "\u2665";
            button.FontSize = 18;
            images.AddSaved();
        } else if (button.Text == "\u2665")
        {
            button.Text = "\u2661";
            button.FontSize = 25;
            images.RemoveSaved();
        }
    }
}
