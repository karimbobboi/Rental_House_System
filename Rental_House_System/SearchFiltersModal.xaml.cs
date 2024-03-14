using System.ComponentModel;

namespace Rental_House_System;

public class SearchFiltersModalVM : INotifyPropertyChanged
{
    App globalref = (App)Application.Current;
    AppDatabase AppDB = new AppDatabase();
    public SearchFiltersModalVM(bool Parking)
    {
        parking = Parking;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    private bool _parking = true;
    public bool parking
    {
        get { return _parking; }
        set
        {
            if (value != null)
            {
                _parking = value;
                OnPropertyChanged("parking");
            }
        }
    }
}

public partial class SearchFiltersModal : ContentPage
{
    //SearchFiltersModalVM searchFiltersVM;
    SearchVM searchViewModel;
    public SearchFiltersModal(SearchVM searchVM)
	{
        InitializeComponent();
        //searchFiltersVM = new SearchFiltersModalVM(Parking);
        searchViewModel = searchVM;
        //BindingContext = searchFiltersVM;
        BindingContext = searchViewModel;
    }

    async void ClickedButton_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}
