using BacASable.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BacASable.ViewModels
{
    public class SfImageEditorViewModel : BaseViewModel
    {
        public ImageSource Image { get; set; }

        public SfImageEditorViewModel()
        {
            Image = ImageSource.FromResource("BacASable.portrait.jpg");
        }
    }

}
