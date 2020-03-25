using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19SAStats.Models
{
    public class InformationHere
    {
        public int total_cases { get; set; }
        public int total_recovered { get; set; }
        public int total_new_cases_today { get; set; }
        public int total_deaths { get; set; }
        public int total_active_cases { get; set; }

    }
}
