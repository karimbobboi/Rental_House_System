using System.Globalization;
using Android.Widget;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Graphics.Text;
using static Java.Util.Jar.Attributes;
using static System.Net.Mime.MediaTypeNames;

namespace Rental_House_System;

public class MainViewModel : BindableObject
{
    public IList<string> ImageList { get; set; }

    public MainViewModel()
    {
        ImageList = new List<string>
            {
                "house_example.jpeg",
                "bathroom.jpeg",
                "living_room.jpeg"
            };
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
    public Room toRent;
    private MainViewModel images;

    public RentPage(Room temp)
	{
		InitializeComponent();
        toRent = temp;
        images = new MainViewModel();
        imgSlider.BindingContext = images;
        rrr.BindingContext = toRent;

        currentImg = "1";
        totalImgs = images.ImageList.Count.ToString();
        fullText = currentImg + "/" + totalImgs;

        initLabels();
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
        if (toRent.furnished)
            features.Add("Furnished");
        else if (!toRent.furnished)
            features.Add("Unfurnished");

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
}
