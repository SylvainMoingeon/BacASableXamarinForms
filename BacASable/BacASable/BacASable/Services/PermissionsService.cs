using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BacASable.Services
{
    public class PermissionsService : IPermissionsService
    {

        public async Task<PermissionStatus> AskPermissionAsync(Permission permission)
        {
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(permission);

            if (status == PermissionStatus.Granted) return PermissionStatus.Granted;


            if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(permission))
            {
                // await DisplayAlert("Need location", "Gunna need that location", "OK");
                System.Diagnostics.Debug.Assert(false, "Display rationale ?");
            }

            var results = await CrossPermissions.Current.RequestPermissionsAsync(permission);
            if (results.ContainsKey(permission)) return results[permission];


            return PermissionStatus.Unknown;
        }

    }
}