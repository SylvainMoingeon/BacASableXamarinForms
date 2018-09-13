using BacASable.DependencyInterfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BacASable.Services
{
    public class PicturePickerService : IPicturePickerService
    {
       public async Task<Image> PickPictureAsync()
        {
            Stream stream = await DependencyService.Get<IPicturePicker>().GetImageStreamAsync().ConfigureAwait(false);

            if (stream != null)
            {
                Image image = new Image
                {
                    Source = ImageSource.FromStream(() => stream),
                    BackgroundColor = Color.Gray
                };

                return image;
            }

            return null;
        }
    }
}
