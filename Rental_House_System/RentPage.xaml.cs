using System.Globalization;
using Android.Widget;
using Microsoft.Maui.Controls;

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
    private MainViewModel images;

    public RentPage(Room temp)
	{
		InitializeComponent();
        images = new MainViewModel();
        imgSlider.BindingContext = images;
        rrr.BindingContext = temp;

        currentImg = "1";
        totalImgs = images.ImageList.Count.ToString();
        fullText = currentImg + "/" + totalImgs;
    }

    void ShowBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        Label label1 = new Label();
        label1.Text = "Placeholder";
        label1.FontSize = 13;
        props.Add(label1, 2, 2);
    }
}
