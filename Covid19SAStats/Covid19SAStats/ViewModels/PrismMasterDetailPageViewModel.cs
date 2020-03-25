using Covid19SAStats.Messages;
using Covid19SAStats.Models;
using Covid19SAStats.Services.Interfaces;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Covid19SAStats.ViewModels
{
    public class PrismMasterDetailPageViewModel : ViewModelBase
    {
        private ISecurityService _securityService;
        private IEventAggregator _eventAggregator;
        private DelegateCommand<MenuItem> _navigateCommand;
        private ObservableCollection<MenuItem> _menuItems;
        public ObservableCollection<MenuItem> MenuItems
        {
            get { return _menuItems; }
            set { SetProperty(ref _menuItems, value); }
        }
        public DelegateCommand<MenuItem> NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand<MenuItem>(ExecuteNavigateCommand));
        public async void ExecuteNavigateCommand(MenuItem menu)
        {
            if (menu.MenuType == Enums.MenuTypeEnum.LogOut)
                _securityService.LogOut();
            else
                await NavigationService.NavigateAsync(menu.NavigationPath);
        }
        public PrismMasterDetailPageViewModel(INavigationService navigationService, ISecurityService securityService, IEventAggregator eventAggregator)
            : base(navigationService)
        {
            Title = "Main Page";
            _securityService = securityService;
            _eventAggregator = eventAggregator;
            MenuItems = new ObservableCollection<MenuItem>(_securityService.GetAllowedAccessItems());

            _eventAggregator.GetEvent<LoginMessage>().Subscribe(LoginEvent);

            _eventAggregator.GetEvent<LogOut>().Subscribe(LogOutEvent);
        }
        public void LoginEvent()
        {
            MenuItems = new ObservableCollection<MenuItem>(_securityService.GetAllowedAccessItems());
            NavigationService.NavigateAsync("NavigationPage/StatsPage");
        }
        public void LogOutEvent()
        {
            MenuItems = new ObservableCollection<MenuItem>(_securityService.GetAllowedAccessItems());
            NavigationService.NavigateAsync("NavigationPage/LoginPage");
        }
    }
}
