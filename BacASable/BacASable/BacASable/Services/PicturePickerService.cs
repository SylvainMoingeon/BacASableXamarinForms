using BacASable.DependencyInterfaces;
using Plugin.Permissions;
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

        IPermissionsService permissionsService;

        public async Task<Image> PickPictureAsync()
        {

            permissionsService = new PermissionsService();

            var status = await permissionsService.AskPermissionAsync(Plugin.Permissions.Abstractions.Permission.Storage);

            if (status == Plugin.Permissions.Abstractions.PermissionStatus.Granted)
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
            }

            return null;
        }
    }
}
