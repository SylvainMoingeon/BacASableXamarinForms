using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BacASable.Services
{
    public interface IPicturePickerService
    {
        Task<Image> PickPictureAsync();
    }
}
