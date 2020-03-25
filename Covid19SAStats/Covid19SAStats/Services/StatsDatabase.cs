using Covid19SAStats.Models;
using Covid19SAStats.Services.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Covid19SAStats.Services
{
    public class StatsDatabase : IDatabase
    {
        public User Person;

        private SQLiteAsyncConnection userDatabase;


        public StatsDatabase()
        {
            var dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "Information.db3");

            userDatabase = new SQLiteAsyncConnection(dbPath);
            userDatabase.CreateTableAsync<User>().Wait();
        }

        public Task<List<User>> GetAllInformationData()
        {
            return userDatabase.Table<User>().ToListAsync();

        }

        public Task<User> GetPeopleByEmail(string Email)
        {
            return userDatabase.Table<User>().Where(x => x.Email == Email).FirstOrDefaultAsync();
        }

        public Task<int> DeleteAllInformation()
        {
            return userDatabase.DeleteAllAsync<User>();
        }

        public Task<int> SaveItemAsync(User info)
        {
            return userDatabase.InsertAsync(info);
        }

        public void Access()
        {
            Person = new User();

            var userprofile = new User();
            userprofile.Email = "Admin@gmail.com";
            userprofile.Password = "Admin";
       
        }

    }
}