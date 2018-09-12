using BacASable.Models;
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
	public partial class SfImageEditorPage : ContentPage
	{
		public SfImageEditorPage ()
		{
			InitializeComponent ();
            imageeditor.SetToolbarItemVisibility("text,shape,path",false);
        }


    }
}