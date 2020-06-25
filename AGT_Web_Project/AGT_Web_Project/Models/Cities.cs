using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGT_Web_Project.Models
{
    public class Cities
    {
        public string City { get; set; }
        public string State { get; set; }
        public int MaxTemperature { get; set; }
        public int MinTemperature { get; set; }
    }
}