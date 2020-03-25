using Covid19SAStats.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Covid19SAStats.Services.Interfaces
{
    public interface ISecurityService
    {
        IList<MenuItem> GetAllowedAccessItems();
        Task<bool> Login(string Email, string Password);
        void LogOut();
    }
}
