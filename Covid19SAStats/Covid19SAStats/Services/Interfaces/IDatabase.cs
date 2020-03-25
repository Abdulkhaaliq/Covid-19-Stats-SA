using Covid19SAStats.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Covid19SAStats.Services.Interfaces
{
    public interface IDatabase
    {
        Task<int> SaveItemAsync(User user);
        Task<List<User>> GetAllInformationData();
        Task<User> GetPeopleByEmail(string Email);

    }
}
