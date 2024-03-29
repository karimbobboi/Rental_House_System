﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Rental_House_System
{
    public class SearchVM : INotifyPropertyChanged
    {
        App globalref = (App)Application.Current;
        AppDatabase AppDB = new AppDatabase();

        public SearchVM()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private int _propType = 0;
        public int propType
        {
            get
            {
                return _propType;
            }
            set
            {
                if (value != null)
                {
                    _propType = value;
                    OnPropertyChanged("propType");
                }
            }
        }

        private int _furnishing = 0;
        public int furnishing
        {
            get
            {
                return _furnishing;
            }
            set
            {
                if (value != null)
                {
                    _furnishing = value;
                    OnPropertyChanged("furnishing");
                }
            }
        }

        private bool _kitchen;
        public bool kitchen
        {
            get { return _kitchen; }
            set
            {
                if (value != null)
                {
                    _kitchen = value;
                    OnPropertyChanged("kitchen");
                }
            }
        }

        private bool _wMachine;
        public bool wMachine
        {
            get { return _wMachine; }
            set
            {
                if (value != null)
                {
                    _wMachine = value;
                    OnPropertyChanged("wMachine");
                }
            }
        }

        private bool _dishwasher;
        public bool dishwasher
        {
            get { return _dishwasher; }
            set
            {
                if (value != null)
                {
                    _dishwasher = value;
                    OnPropertyChanged("dishwasher");
                }
            }
        }

        private bool _fridge;
        public bool fridge
        {
            get { return _fridge; }
            set
            {
                if (value != null)
                {
                    _fridge = value;
                    OnPropertyChanged("fridge");
                }
            }
        }

        private bool _parking;
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

        private bool _tv;
        public bool tv
        {
            get { return _tv; }
            set
            {
                if (value != null)
                {
                    _tv = value;
                    OnPropertyChanged("tv");
                }
            }
        }

        private bool _gym;
        public bool gym
        {
            get { return _gym; }
            set
            {
                if (value != null)
                {
                    _gym = value;
                    OnPropertyChanged("gym");
                }
            }
        }

        private bool _bills;
        public bool bills
        {
            get { return _bills; }
            set
            {
                if (value != null)
                {
                    _bills = value;
                    OnPropertyChanged("bills");
                }
            }
        }

        private bool _shortTerm;
        public bool shortTerm
        {
            get { return _shortTerm; }
            set
            {
                if (value != null)
                {
                    _shortTerm = value;
                    OnPropertyChanged("shortTerm");
                }
            }
        }

        private bool _internet;
        public bool internet
        {
            get { return _internet; }
            set
            {
                if (value != null)
                {
                    _internet = value;
                    OnPropertyChanged("internet");
                }
            }
        }

        private string _searchTerm = "";
        public string searchTerm
        {
            get
            {
                return _searchTerm;
            }
            set
            {
                if (value != null)
                {
                    _searchTerm = value;
                    OnPropertyChanged("searchTerm");
                }
            }
        }


        private int _maxPrice = 1000000;
        public int maxPrice
        {
            get
            {
                return _maxPrice;
            }
            set
            {
                if (value != null)
                {
                    _maxPrice = value;
                    OnPropertyChanged("maxPrice");
                }
            }
        }

        private int _minPrice = 0;
        public int minPrice
        {
            get
            {
                return _minPrice;
            }
            set
            {
                if (value != null)
                {
                    _minPrice = value;
                    OnPropertyChanged("minPrice");
                    if (_minPrice > maxPrice)
                        maxPrice = _minPrice + 5;
                }
            }
        }

        private int _minBed = 0;
        public int minBed
        {
            get
            {
                return _minBed;
            }
            set
            {
                if (value != null)
                {
                    if (value < 0)
                        _minBed = 0;
                    else
                        _minBed = value;
                    OnPropertyChanged("minBed");
                    if (_minBed > maxBed)
                        maxBed = _minBed + 1;
                }
            }
        }


        private int _maxBed = 10;
        public int maxBed
        {
            get
            {
                return _maxBed;
            }
            set
            {
                if (value != null)
                {
                    if (value < 1)
                        _maxBed = 1;
                    else
                        _maxBed = value;
                    OnPropertyChanged("maxBed");
                }
            }
        }

        private int _minBath = 0;
        public int minBath
        {
            get
            {
                return _minBath;
            }
            set
            {
                if (value != null)
                {
                    if (value < 0)
                        _minBath = 0;
                    else
                        _minBath = value;
                    OnPropertyChanged("minBath");
                    if (_minBath > maxBath)
                        maxBath = _minBath + 1;
                }
            }
        }


        private int _maxBath = 10;
        public int maxBath
        {
            get
            {
                return _maxBath;
            }
            set
            {
                if (value != null)
                {
                    _maxBath = value;
                    if (value < 1)
                        _maxBath = 1;
                    else
                        _maxBath = value;
                    OnPropertyChanged("maxBath");
                }
            }
        }

        public ObservableCollection<Listing> SearchListings()
        {
            ObservableCollection<Listing> allListings = globalref.appDB.GetAllListings();
            string[] propTypes = { "Apartment", "Detached", "Semi-Detached", "Terraced", "Flat", "Bungalow" };
            string[] furnishings = { "Furnished", "Part furnished", "Unfurnished" };

            // Perform search based on keyword
            var results = new ObservableCollection<Listing>(
                allListings.Where(listing =>
                    listing.AddressToString().ToLower().Contains(searchTerm.ToLower()) &&
                    (listing.price >= minPrice && listing.price <= maxPrice) &&
                    (listing.numToilets >= minBath && listing.numToilets <= maxBath) &&
                    (listing.numRooms >= minBed && listing.numRooms <= maxBed) &&
                    (propType == 0 || (listing.type == propTypes[propType - 1])) &&
                    (furnishing == 0 || (listing.type == furnishings[furnishing - 1])) &&
                    (!wMachine || (wMachine && listing.wmachine)) && (!kitchen || (kitchen && listing.kitchen))
                    && (!dishwasher || (dishwasher && listing.dishwasher)) && (!fridge || (fridge && listing.fridge))
                    && (!gym || (gym && listing.gym)) && (!internet || (internet && listing.internet))
                    && (!parking || (parking && listing.park)) && (!bills || (bills && listing.bills))
                    && (!shortTerm || (shortTerm && !(listing.lterm))) && (!tv || (tv && listing.tv))
                ));

            return results;
        }

        // clears entire vm
        public void ResetVM()
        {
            searchTerm = "";
            propType = 0;
            furnishing = 0;
            minPrice = 0; maxPrice = 10000;
            minBath = 0; maxBath = 10;
            minBed = 0; maxBed = 10;

            kitchen = false; wMachine = false;
            gym = false; parking = false;
            shortTerm = false; bills = false;
            fridge = false; internet = false;
            tv = false; dishwasher = false;
        }
    }
}

