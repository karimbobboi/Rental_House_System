﻿using System.Globalization;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics.Text;
using static Java.Util.Jar.Attributes;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;
using System.ComponentModel;
using System;

namespace Rental_House_System;

public class MainViewModel : BindableObject
{
    App globalref = (App)Microsoft.Maui.Controls.Application.Current;
    public string[] ImageList { get; set; }
    public Listing toRent;

    public MainViewModel(Listing temp)
    {
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
        listDetails.BindingContext = toRent;

        currentImg = "1";
        totalImgs = images.ImageList.Length.ToString();
        fullText = currentImg + "/" + totalImgs;

        initLabels();
        bool isInRecent = globalref.RecentListingsCollection.Any(item => item.Equals(toRent));

        if (isInRecent)
        {
            globalref.RecentListingsCollection.Remove(toRent);
            globalref.RecentListingsCollection.Add(toRent);
        }
        else
        {
            if (globalref.RecentListingsCollection.Count > 5) {
                globalref.RecentListingsCollection.RemoveAt(0);
            }
            globalref.RecentListingsCollection.Add(toRent);
        }

        if (images.saved)
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
        
        if (sender is Button button && props.Children.Contains(button))
        {
            props.Children.Remove(button);

            // Check if the button is currently in the first position
            if (Grid.GetRow(button) == 1)
            {
                for (int i = 0; i < props.Count; i++)
                {
                    var child = props.Children[i];
                    try
                    {
                        if (child is Label label)
                        {
                            label.IsVisible = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Trace.Write($"Something went wrong at {i}.");
                        break;
                    }
                }

                button.Text = "Hide >";
                Grid.SetRow(button, props.RowDefinitions.Count - 1);
                Grid.SetColumn(button, props.RowDefinitions.Count % 3);
            }
            else
            {
                for (int i = 0; i < props.Count; i++)
                {
                    var child = props.Children[i];
                    try
                    {
                        if (child is Label label)
                        {
                            if (Grid.GetRow(label) == 1 && Grid.GetColumn(label) == 2) {
                                label.IsVisible = false;
                            }
                            else if (Grid.GetRow(label) < 2) { continue; }
                            label.IsVisible = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Trace.Write($"Something went wrong at {i}.");
                        break;
                    }
                }

                button.Text = "Show more >";
                Grid.SetRow(button, 1);
                Grid.SetColumn(button, 2);
            }

            // Add the button back to the grid at its new position
            props.Children.Add(button);
        }
    }

    private bool initLabels()
    {
        // store all property details into a list
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
        //if (toRent.fridge)
            features.Add("Fridge");

        int index = 0; bool vis = true;
        int maxLoop = features.Count == 10 ? 4 : 3 % features.Count;

        // loop through features list and add all details to the Grid
        // three per row

        for (int i = 0; i < maxLoop; i++) {
            for (int j = 0; j < 3; j++) {
                try
                {
                    if (i == 3 && j > 0) { break; }
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
                    System.Diagnostics.Trace.Write($"Something went wrong at {i}, {j}.");
                    break;
                }
            }
        }

        // if features too many add show and hide functionality
        if (features.Count <= 6)
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
