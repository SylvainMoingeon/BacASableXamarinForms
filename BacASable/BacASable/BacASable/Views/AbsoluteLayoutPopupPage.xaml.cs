using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BacASable.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AbsoluteLayoutPopupPage : ContentPage
	{
		public AbsoluteLayoutPopupPage ()
		{
			InitializeComponent ();
            List<string> items = new List<string> { "Xamarin.Forms", "Xamarin.iOS", "Xamarin.Android", "Xamarin Monkeys" };
            imgMonkey.Source = ImageSource.FromResource("XamarinCustomPopup.images.monkey-MVP.png");
            imgPopup.Source = ImageSource.FromResource("XamarinCustomPopup.images.xammonkey.png");
            sampleList.ItemsSource = items;
        }


        private void btnPopupButton_Clicked(object sender, EventArgs e)
        {
            popupLoginView.IsVisible = true;
            activityIndicator.IsRunning = true;
        }

    }
}