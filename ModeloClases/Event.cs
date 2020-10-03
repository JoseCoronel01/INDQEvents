using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModeloClases
{
    public class Event
    {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string date { get; set; }
        public string image { get; set; }
        public long attendances { get; set; }
        public bool willYouAttend { get; set; }
        public  decimal[] location { get; set; }
    }
}