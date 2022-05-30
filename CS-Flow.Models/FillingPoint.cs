using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Flow.Models
{
    public class FillingPoint
    {
        public int id { get; set; }
        public string name { get; set; }
        public string fgroup { get; set; }
        public string product { get; set; }
        public int enabled { get; set; }
        public string tank { get; set; }
        public decimal tank_temperature { get; set; }
        public decimal tank_density { get; set; }
        public int fdm_id { get; set; }
    }
}
