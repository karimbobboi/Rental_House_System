using System.ComponentModel;

namespace Rental_House_System;

public partial class SearchFiltersModal : ContentPage
{
    SearchVM searchViewModel;
    public SearchFiltersModal(SearchVM searchVM)
	{
        InitializeComponent();
        searchViewModel = searchVM;
        BindingContext = searchViewModel;
    }

    async void DoneButton_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}
