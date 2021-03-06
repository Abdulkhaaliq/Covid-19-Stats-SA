﻿using Prism;
using Prism.Ioc;
using Covid19SAStats.ViewModels;
using Covid19SAStats.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Covid19SAStats
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("PrismMasterDetailPage/NavigationPage/StatsPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<PrismMasterDetailPage, PrismMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<StatsPage, StatsPageViewModel>();
            containerRegistry.RegisterForNavigation<AboutUs, AboutUsViewModel>();
            containerRegistry.RegisterForNavigation<TipsPage, TipsPageViewModel>();
            containerRegistry.RegisterForNavigation<HotlinePage, HotlinePageViewModel>();
        }
    }
}
