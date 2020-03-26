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
        public static async Task<InformationHere> GetWeatherAsync()
        {

          
                HttpClient httpClient = new HttpClient();
                string news = await httpClient.GetStringAsync("https://coronavirus-19-api.herokuapp.com/countries/South%20Africa");
                Stats getter = JsonConvert.DeserializeObject<Stats>(news);
           

                var statInfo = new InformationHere
                {
                    active = getter.active,



                };
            
            return statInfo;
            
           
        }
    }
}
