using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Flow.Models
{
    public class ChildDevice
    {
        public int id { get; set; }
        public int fp_id { get; set; }
        public string name { get; set; }
        public string conn_str { get; set; }
        public string protocol { get; set; }
        public string address { get; set; }
    }
}
