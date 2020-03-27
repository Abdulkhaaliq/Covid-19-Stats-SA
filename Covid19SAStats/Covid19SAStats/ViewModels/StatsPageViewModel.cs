using Covid19SAStats.Helper;
using Covid19SAStats.Models;
using Newtonsoft.Json;
using Prism.AppModel;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Covid19SAStats.ViewModels
{
    public class StatsPageViewModel : ViewModelBase  , IPageLifecycleAware
    {
        private readonly IPageDialogService _pageDialogService;

        public DateTime CurrentDate { get; }

        private InformationHere  _countrydata;
        public InformationHere Countrydata
        {
            get { return _countrydata; }
            set { SetProperty(ref _countrydata, value); }
        }

     
        public StatsPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService)
        {
            CurrentDate = DateTime.UtcNow;

            _pageDialogService = pageDialogService;
            Title = "Home";
          
        }

        public void OnDisappearing()
        {
            
        }

        public async void OnAppearing()
        {
            try 
            {     
                var current = Connectivity.NetworkAccess;

                if (current == NetworkAccess.Internet)
                {
                    // Connection to internet is available
                    var stats = await StatsGenerator.GetStatsAsync();
                    Countrydata = stats;
                    await _pageDialogService.DisplayAlertAsync("Welcome!", "Information on covid-19 in South Africa", "ok");
                }
            }
            catch(Exception ex)
            {
                var current = Connectivity.NetworkAccess;

                if (current != NetworkAccess.Internet)
                {
                    await _pageDialogService.DisplayAlertAsync("Unexpected Error", "No Interent access", "cancel", "ok");
                }
            }
        }
    }
}
