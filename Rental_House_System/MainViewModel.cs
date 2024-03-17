using System;
using System.ComponentModel;

namespace Rental_House_System
{
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
                saved = false;
            }
            else
            {
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
        public bool saved
        {
            get
            {
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
            if (globalref.appDB.GetSavedByIds(globalref.activeUser.uid, toRent.lId) == null)
            {
                res = globalref.appDB.AddSaved(s);
            }
            else
            {
                res = globalref.appDB.UpdateSaved(s);

            }
            MessagingCenter.Send<MainViewModel, string>(this, "CollectionChanged", "CollectionUpdated");
            return res;
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
        }
    }
}

