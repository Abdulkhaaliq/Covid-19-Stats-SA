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

            TipItems = new ObservableCollection<TipModel>();

            TipItems.Add(new TipModel()
            {
                Title = "What to look out for",
                ImageUrl = "how.jpeg"
            });

            TipItems.Add(new TipModel()
            {
                Title = "How virus is spread 1",
                ImageUrl = "means.jpeg"
            });

            TipItems.Add(new TipModel()
            {
                Title = "How virus is spread 2",
                ImageUrl = "means2.jpeg"
            });

            TipItems.Add(new TipModel()
            {
                Title = "How virus is spread 3",
                ImageUrl = "means3.jpeg"
            });

            TipItems.Add(new TipModel()
            {
                Title = "How virus is spread 4",
                ImageUrl = "means4.jpeg"
            });

            TipItems.Add(new TipModel()
            { 
                Title = "Tip 1",
               ImageUrl = "one.jpeg"
            });

            TipItems.Add(new TipModel()
            {
                Title = "Tip 2",
                ImageUrl = "two.jpeg"
            });

            TipItems.Add(new TipModel()
            {
                Title = "Tip 3 and 4",
                ImageUrl = "three.jpeg"
            });

            TipItems.Add(new TipModel()
            {
                Title = "Precautions 1",
                ImageUrl = "measure1.jpeg"
            });

            TipItems.Add(new TipModel()
            {
                Title = "Precautions 2",
                ImageUrl = "measure2.jpeg"
            });

            TipItems.Add(new TipModel()
            {
                Title = "Precaution 3",
                ImageUrl = "measure3.jpeg"
            });
        }
    }
}
