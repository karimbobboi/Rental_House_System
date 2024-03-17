using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Rental_House_System;

public partial class SearchPage : ContentPage
{
    SearchVM searchVM;
    public SearchPage()
	{
		InitializeComponent();
        searchVM = new SearchVM();
        searchVM.maxPrice = 10000; // set the initial value for max price
        BindingContext = searchVM;
        furnishing.SelectedIndex = 0;
        radiusPicker.SelectedIndex = 0;
    }

    async void SearchButton_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new SearchResults(searchVM.SearchListings()));
    }

    async void FiltersButton_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushModalAsync(new SearchFiltersModal(searchVM));
    }

    void ClearButton_Clicked(System.Object sender, System.EventArgs e) {
        searchVM.ResetVM();
        radiusPicker.SelectedIndex = 0;
    }

    // to make sure max price is always greater than min price
    void MaxEntry_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        string valueString = maxPriceEntry.Text.Replace("£", "");
        int.TryParse(valueString, out int newValue);
        searchVM.maxPrice = newValue;

        if (searchVM.maxPrice < 5)
            searchVM.minPrice = 0;
        else if (searchVM.minPrice > searchVM.maxPrice)
            searchVM.minPrice = searchVM.maxPrice - 5;
    }

    void MinEntry_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        string valueString = minPriceEntry.Text.Replace("£", "");
        int.TryParse(valueString, out int newValue);
        searchVM.minPrice = newValue;
    }

    // to make sure max bed is always greater than min bed
    void MaxBed_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        if (searchVM.maxBed <= 0)
            searchVM.minBed = 0;
        else if (searchVM.minBed > searchVM.maxBed)
            searchVM.minBed = searchVM.maxBed - 1;
    }

    // to make sure max bathrooms is always greater than min bathrooms
    void MaxBath_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        if (searchVM.maxBath <= 0)
            searchVM.minBath = 0;
        else if (searchVM.minBath > searchVM.maxBath)
            searchVM.minBath = searchVM.maxBath - 1;
    }
}
