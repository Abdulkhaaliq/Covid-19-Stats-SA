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
        public static async Task<InformationHere> GetStatsAsync()
        {

            
                HttpClient httpClient = new HttpClient();
                string news = await httpClient.GetStringAsync("https://coronavirus-19-api.herokuapp.com/countries/South%20Africa");

    

                Stats getter = JsonConvert.DeserializeObject<Stats>(news);


            InformationHere statInfo = new InformationHere()
            {
                cases = getter.cases,
                active = getter.active,
                recovered = getter.recovered,
                deaths = getter.deaths,
                todayCases = getter.todayCases,

            };
            
            return statInfo;
            
        }
    }
}
