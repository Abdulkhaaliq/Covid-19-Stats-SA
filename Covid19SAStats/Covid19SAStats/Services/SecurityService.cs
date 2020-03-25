using Covid19SAStats.Enums;
using Covid19SAStats.Messages;
using Covid19SAStats.Models;
using Covid19SAStats.Services.Interfaces;
using Prism.Events;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19SAStats.Services
{
    public class SecurityService : ISecurityService
    {
        private IEventAggregator _eventAggregator;
        public IList<MenuItem> _allMenuItems;
        private IPageDialogService _pageDialogService;

        private IDatabase _database;

        public bool LoggedIn { get; set; }

        public SecurityService(IEventAggregator eventAggregator, IDatabase database)
        {
            CreateMenuItems();

            _eventAggregator = eventAggregator;
            _database = database;
        }

        public IList<MenuItem> GetAllowedAccessItems()
        {
            if (LoggedIn)
            {
                var accessItems = new List<MenuItem>();

                foreach (var item in _allMenuItems)
                {
                    if (item.MenuType == MenuTypeEnum.Secured || item.MenuType == MenuTypeEnum.UnSecured || item.MenuType == MenuTypeEnum.LogOut)
                    {
                        accessItems.Add(item);
                    }
                }

                return accessItems.OrderBy(x => x.MenuOrder).ToList();
            }
            else
            {
                var accessItems = new List<MenuItem>();

                foreach (var item in _allMenuItems)
                {
                    if (item.MenuType == MenuTypeEnum.UnSecured || item.MenuType == MenuTypeEnum.Login)
                    {
                        accessItems.Add(item);
                    }
                }

                return accessItems.OrderBy(x => x.MenuOrder).ToList();
            }
        }

        public async Task<bool> Login()
        { 
            LoggedIn = true;
            _eventAggregator.GetEvent<LoginMessage>().Publish();

            if (LoggedIn)
            {
                return true;
            }
            return false;
        }

        public void LogOut()
        {
            LoggedIn = false;

            _eventAggregator.GetEvent<LogOut>().Publish();
        }



        private void CreateMenuItems()
        {
            _allMenuItems = new List<MenuItem>();

            var menuItem = new MenuItem();
            menuItem.MenuItemId = 1;
            menuItem.MenuItemName = "Logout";
            menuItem.NavigationPath = "NavigationPage/MainPage";
            menuItem.MenuType = MenuTypeEnum.LogOut;
            menuItem.MenuOrder = 99;

            _allMenuItems.Add(menuItem);

            menuItem = new MenuItem();
            menuItem.MenuItemId = 2;
            menuItem.MenuItemName = "About Us";
            menuItem.NavigationPath = "NavigationPage/AboutUs";
            menuItem.MenuOrder = 1;
            menuItem.MenuType = MenuTypeEnum.Login;

        }
    }
}
