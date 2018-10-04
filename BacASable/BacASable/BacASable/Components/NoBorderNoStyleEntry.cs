using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BacASable.Components
{
    public class NoBorderNoStyleEntry : Entry
    {
        public static readonly BindableProperty PlaceHolderFontFamilyProperty =
            BindableProperty.Create(nameof(PlaceHolderFontFamily), typeof(string), typeof(NoBorderNoStyleEntry), string.Empty);

        public string PlaceHolderFontFamily
        {
            get => (string)GetValue(PlaceHolderFontFamilyProperty);
            set => SetValue(PlaceHolderFontFamilyProperty, value);
        }

        public static readonly BindableProperty IsReadonlyProperty =
           BindableProperty.Create(nameof(IsReadonly), typeof(bool), typeof(NoBorderNoStyleEntry), false);

        public bool IsReadonly
        {
            get => (bool)GetValue(IsReadonlyProperty);
            set => SetValue(IsReadonlyProperty, value);
        }

        public NoBorderNoStyleEntry()
        {
            
        }
    }
}
