﻿using BacASable.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BacASable.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem{Id=MenuItemType.AbsoluteLayoutPopup, Title="AbsoluteLayoutPopup"},
                new HomeMenuItem {Id = MenuItemType.SfAutocomplete, Title="SfAutocomplete" },
                new HomeMenuItem {Id = MenuItemType.SfImageEditor, Title="SfImageEditor" },
                new HomeMenuItem {Id = MenuItemType.Browse, Title="Browse"},
                new HomeMenuItem {Id = MenuItemType.About, Title="About" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}