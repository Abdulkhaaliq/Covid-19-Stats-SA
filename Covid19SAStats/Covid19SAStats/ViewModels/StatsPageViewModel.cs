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

namespace Covid19SAStats.ViewModels
{
    public class StatsPageViewModel : ViewModelBase  , IPageLifecycleAware
    {
        private readonly INavigationService _navigationService;
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
            _navigationService = navigationService;
            Title = "Home";
          
        }

        public void OnDisappearing()
        {
            
        }

        public async void OnAppearing()
        {
            try 
            { 
             var stats = await StatsGenerator.GetStatsAsync();
              Countrydata = stats;
            }
            catch(Exception ex)
            {
                await _pageDialogService.DisplayAlertAsync("Unexpected Error", ex.ToString() ,"ok");
            }
        }
    }
}
