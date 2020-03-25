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

        private Countrydata _countrydata;
        public Countrydata Countrydata
        {
            get { return _countrydata; }
            set { SetProperty(ref _countrydata, value); }
        }

        public void MyStatsModel()
        {
            _countrydata.total_cases.ToString();


        }


        public StatsPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {


            _navigationService = navigationService;
            Title = "Home";
            Countrydata = new Countrydata();
        }
    }
}
