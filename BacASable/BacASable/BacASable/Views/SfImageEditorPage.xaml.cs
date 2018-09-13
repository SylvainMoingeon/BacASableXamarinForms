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
        public SfImageEditorPage()
        {
            InitializeComponent();

            imageeditor.SetToolbarItemVisibility("text,shape,path,free,original,3:1,3:2,4:3,5:4,16:9", false);
        }
    }
}