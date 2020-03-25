using Covid19SAStats.Messages;
using Covid19SAStats.Models;
using Covid19SAStats.Services.Interfaces;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Covid19SAStats.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private IEventAggregator _eventAggregator;

        private ISecurityService _securityService;

        private IPageDialogService _pageDialogService;

        private bool LoggedIn = false;
        private User _person;
        public User Person
        {
            get { return _person; }
            set { SetProperty(ref _person, value); }
        }

        private DelegateCommand _enteredCommand;
        public DelegateCommand EnteredCommand =>
            _enteredCommand ?? (_enteredCommand = new DelegateCommand(ExecuteEnteredCommand));

        async void ExecuteEnteredCommand()
        {
            LoggedIn = true;
                if (LoggedIn)
                {
                    _eventAggregator.GetEvent<LoginMessage>().Publish();
                    await  NavigationService.NavigateAsync("NavigationPage/StatsPage");
                    await _pageDialogService.DisplayAlertAsync("Welcome", "Nice to see you!!!", "Ok");
                }
        }


        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IEventAggregator eventAggregator, ISecurityService securityService)
            : base(navigationService)
        {
            _pageDialogService = pageDialogService;
            _securityService = securityService;
            _eventAggregator = eventAggregator;
            _navigationService = navigationService;
            Title = "Menu";
        }
    }
}
