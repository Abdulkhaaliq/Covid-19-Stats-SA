using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19SAStats.Models
{
    public class InformationHere
    {
        public int cases { get; set; }
        public int deaths { get; set; }
        public int todayDeaths { get; set; }
        public int recovered { get; set; }
        public int active { get; set; }

    }
}
