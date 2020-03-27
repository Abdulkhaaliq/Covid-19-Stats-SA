using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19SAStats.Models
{
    public class TipModel
    {
        public int TipId { get; set; }
        public int TipOrder { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
    }
}
