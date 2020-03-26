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
            var result = await _pageDialogService.DisplayAlertAsync("Alert", "Send us a email with your thoughts!", "cancel", "ok");
            if(result == true)
            {
                return;
            }
            else
            {
                List<string> toAddress = new List<string>();
                toAddress.Add("Abdulkhaaliqdollie@gmail.com");
                await SendEmail(toAddress);

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
            catch (FeatureNotSupportedException fbsEx)
            {
                // Email is not supported on this device  
            }
            catch (Exception ex)
            {
                // Some other exception occurred  
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
