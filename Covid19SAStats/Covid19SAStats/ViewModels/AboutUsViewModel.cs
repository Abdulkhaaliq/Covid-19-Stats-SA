using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Covid19SAStats.ViewModels
{
    public class AboutUsViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;

        private DelegateCommand _emailCommand;
        public DelegateCommand EmailCommand =>
            _emailCommand ?? (_emailCommand = new DelegateCommand(ExecuteEmailCommand));

        async void ExecuteEmailCommand()
        {
            var result = await _pageDialogService.DisplayAlertAsync("Alert", "Send us a email with your thoughts!", "Ok", "Cancel");
            if(result == true)
            {
                List<string> toAddress = new List<string>();
                toAddress.Add("Abdulkhaaliqdollie@gmail.com");
                await SendEmail(toAddress);

            }
            else
            {
                return;

            }
        }

        public async Task SendEmail(List<string> recipients)
        {
            try
            {
                var message = new EmailMessage
                {
                   
                    To = recipients,
                    
                };
                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException ex)
            {
                // Email is not supported on this device  
                await _pageDialogService.DisplayAlertAsync("Alert", "No access to email service", "ok");
                return;
            }
            catch (Exception ex)
            {
                // Some other exception occurred  
                return;
            }
            
        }

        private DelegateCommand _donateCommand;
        public DelegateCommand DonateCommand =>
            _donateCommand ?? (_donateCommand = new DelegateCommand(ExecuteDonateCommand));

        async void ExecuteDonateCommand()
        {
            var result = await _pageDialogService.DisplayAlertAsync("Notice", "Donate what you feel is right", "Ok", "Cancel");
            if (result == true)
            {
               await Browser.OpenAsync("https://www.paypal.com/paypalme2/Abdulkhaaliqdolllie/20", BrowserLaunchMode.SystemPreferred);
            }
            else
            {
                return;
            }
        }
        public AboutUsViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService)
        {
            _pageDialogService = pageDialogService;
               _navigationService = navigationService;
            Title = "About Us";
        }
    }
}
