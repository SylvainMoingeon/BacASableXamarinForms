using BacASable.Models;
using BacASable.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace BacASable.ViewModels
{
    public class SfImageEditorViewModel : BaseViewModel
    {
        private ImageSource image;

        public ImageSource Image
        {
            get
            {
                return image;
            }

            set
            {
                SetProperty(ref image, value);
            }
        }

        public ICommand PickPhotoCommand { get; }

        readonly IPicturePickerService picturePickerService;

        public SfImageEditorViewModel()
        {
            picturePickerService = new PicturePickerService();


            PickPhotoCommand = new Command(
                execute: async () =>
                {
                    var image = await picturePickerService.PickPictureAsync().ConfigureAwait(false);
                    Image = image.Source;
                });
        }



        //Image = ImageSource.FromResource("BacASable.portrait.jpg");

    }

}
