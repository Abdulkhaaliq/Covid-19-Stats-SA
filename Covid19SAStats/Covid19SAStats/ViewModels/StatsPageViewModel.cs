using Covid19SAStats.Services.Interfaces;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Covid19SAStats.ViewModels
{
    public class StatsPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private IEventAggregator _eventAggregator;

        private ISecurityService _securityService;



        private IPageDialogService _pageDialogService;


        public StatsPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IEventAggregator eventAggregator, ISecurityService securityService)
            : base(navigationService)
        {
            _pageDialogService = pageDialogService;
            _securityService = securityService;
            _eventAggregator = eventAggregator;
            _navigationService = navigationService;
            Title = "Home";
        }
    }
}
