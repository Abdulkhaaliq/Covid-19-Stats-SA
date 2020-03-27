using Covid19SAStats.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Covid19SAStats.ViewModels
{
    public class TipsPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public ObservableCollection<TipModel> TipItems { get; set; }

        private TipModel _tipItem;
        public TipModel SelectedMenuItem
        {
            get => _tipItem;
            set => SetProperty(ref _tipItem, value);
        }

        public TipsPageViewModel(INavigationService navigationService)
             : base(navigationService)
        {
            Title = "Tips";
            _navigationService = navigationService;
        }
    }
}
