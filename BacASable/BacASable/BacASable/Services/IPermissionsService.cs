using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BacASable.Services
{
    public interface IPermissionsService
    {
        Task<PermissionStatus> AskPermissionAsync(Permission permission);
    }
}
