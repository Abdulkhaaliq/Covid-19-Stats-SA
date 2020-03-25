using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Covid19SAStats.ViewModels
{
    public class AboutUsViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public AboutUsViewModel(INavigationService navigationService)
            : base(navigationService)
        {
         
            _navigationService = navigationService;
            Title = "About Us";
        }
    }
}
