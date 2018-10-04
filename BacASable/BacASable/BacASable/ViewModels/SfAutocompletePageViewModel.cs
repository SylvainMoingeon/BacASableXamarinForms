using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BacASable.ViewModels
{
    public class Country
    {

        public Country(string name)
        {
            Name = name;
        }
        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

    }

    public class SfAutocompletePageViewModel : BaseViewModel
    {
        private ObservableCollection<Country> _Countries;

        public ObservableCollection<Country> Countries
        {
            get { return _Countries; }
            set { SetProperty(ref _Countries, value); }
        }

        private string _Watermark;
        public string Watermark
        {
            get { return _Watermark; }
            set { SetProperty(ref _Watermark, value); }
        }

        private Country _SelectedCountry;
        public Country SelectedCountry
        {
            get { return _SelectedCountry; }
            set { SetProperty(ref _SelectedCountry, value); }
        }

        public SfAutocompletePageViewModel()
        {

            var countries = new ObservableCollection<Country>()
            {
               new Country( "France"),
               new Country(  "Suisse"),
               new Country(  "Allemagne"),
               new Country(  "Australie"),
               new Country(  "Autriche"),
                new Country("Groland")
            };

            Countries = new ObservableCollection<Country>(countries);

            Watermark = "Par là !";
            //SelectedCountry = "France";
        }
    }
}
