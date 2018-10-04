using System;
using System.Collections.Generic;
using System.Text;

namespace BacASable.Models
{
    public enum MenuItemType
    {
        SfAutocomplete,
        SfImageEditor,
        Browse,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
