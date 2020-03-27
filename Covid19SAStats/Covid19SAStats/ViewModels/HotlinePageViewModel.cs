using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;

namespace Covid19SAStats.ViewModels
{
    public class HotlinePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
      


        public HotlinePageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService;
            Title = "Hotlines";
        }

        private DelegateCommand _ambulanceCommand;
        public DelegateCommand AmbulanceCommand =>
            _ambulanceCommand ?? (_ambulanceCommand = new DelegateCommand(ExecuteAmbulanceCommand));

        async void ExecuteAmbulanceCommand()
        {
            try
            {
                await Clipboard.SetTextAsync("10177");
            }
            catch (Exception)
            {
                return;
            }
        }

        private DelegateCommand _covidCommand;
        public DelegateCommand CovidCommand =>
            _covidCommand ?? (_covidCommand = new DelegateCommand(ExecuteCovidCommand));

       async void ExecuteCovidCommand()
        {
            try
            {
                await Clipboard.SetTextAsync("0800 029 999");

            }
            catch (Exception)
            {
                return;
            }
        }

        private DelegateCommand _emergencyCommand;
        public DelegateCommand EmergencyCommand =>
            _emergencyCommand ?? (_emergencyCommand = new DelegateCommand(ExecuteEmergencyCommand));

       async void ExecuteEmergencyCommand()
        {
            try
            {
                await Clipboard.SetTextAsync("10111");

            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
