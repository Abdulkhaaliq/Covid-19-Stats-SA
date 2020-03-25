using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19SAStats.Models
{
    public class Info
    {
        public int ourid { get; set; }
        public string title { get; set; }
        public string code { get; set; }
        public string source { get; set; }
    }

    public class Countrydata
    {
        public Info info { get; set; }
        public int total_cases { get; set; }
        public int total_recovered { get; set; }
        public int total_unresolved { get; set; }
        public int total_deaths { get; set; }
        public int total_new_cases_today { get; set; }
        public int total_new_deaths_today { get; set; }
        public int total_active_cases { get; set; }
        public int total_serious_cases { get; set; }
    }
}
