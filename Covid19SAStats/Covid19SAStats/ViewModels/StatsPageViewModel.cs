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

namespace Covid19SAStats.ViewModels
{
    public class StatsPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public DateTime CurrentDate { get; }

        private InformationHere  _countrydata;
        public InformationHere Countrydata
        {
            get { return _countrydata; }
            set { SetProperty(ref _countrydata, value); }
        }

 


        public StatsPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            CurrentDate = DateTime.UtcNow;

            _navigationService = navigationService;
            Title = "Home";
            Countrydata = new InformationHere();
        }
    }
}
