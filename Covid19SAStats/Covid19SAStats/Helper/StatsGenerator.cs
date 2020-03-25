using Covid19SAStats.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Covid19SAStats.Helper
{
    public class StatsGenerator
    {
        public async Task<Countrydata> GetStat()
        {

            HttpClient httpClient = new HttpClient();
            string LatestStatString = await httpClient.GetStringAsync("https://thevirustracker.com/free-api?countryTotal=ZA");
            Countrydata getter = JsonConvert.DeserializeObject<Countrydata>(LatestStatString);
            var countryData = new Countrydata();

            
            countryData.total_cases = getter.total_cases;
            countryData.total_active_cases = getter.total_active_cases;
            countryData.total_new_cases_today = getter.total_new_cases_today;
            countryData.total_deaths = getter.total_deaths;
            countryData.total_recovered = getter.total_recovered;


            return countryData;
        }
    }
}
