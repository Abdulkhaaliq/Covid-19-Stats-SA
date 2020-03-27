using Covid19SAStats.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace Covid19SAStats.ViewModels
{
    public class PrismMasterDetailPageViewModel : BindableBase
    {
        private INavigationService _navigationService;

        public ObservableCollection<Items> MenuItems { get; set; }

        private Items selectedMenuItem;
        public Items SelectedMenuItem
        {
            get => selectedMenuItem;
            set => SetProperty(ref selectedMenuItem, value);
        }

        public DelegateCommand NavigateCommand { get; private set; }

        public PrismMasterDetailPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            MenuItems = new ObservableCollection<Items>();

            MenuItems.Add(new Items()
            {
                MenuItemId = 1,
                MenuItemName = "South Africa Covid-19 Statistics",        
                MenuOrder = 1,
                NavigationPath = "StatsPage"
            });

            MenuItems.Add(new Items()
            {
                MenuItemId = 2,
                MenuItemName = "Tips hub",
                MenuOrder = 2,
                NavigationPath = "TipsPage"
            });

            MenuItems.Add(new Items()
            {
                MenuItemId = 3,
                MenuItemName = "Emergency Contacts Here",
                MenuOrder = 3,
                NavigationPath = "HotlinePage"
            });

            MenuItems.Add(new Items()
            {
                MenuItemId = 4,
                MenuItemName = "About Us",
                Color = "Black",
                MenuOrder = 4,
                NavigationPath = "AboutUs"
            }); ;

            NavigateCommand = new DelegateCommand(Navigate);
        }

        async void Navigate()
        {
            await _navigationService.NavigateAsync(nameof(NavigationPage) + "/" + SelectedMenuItem.NavigationPath);
        }
    }
}
