using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Flow.Models
{
    public class EventLog
    {
        public int id { get; set; }
        public int timestamp { get; set; }
        public string message { get; set; }
        public int filling_point_id { get; set; }
        public int batch_id { get; set; }
        public string truck { get; set; }
        public int severity { get; set; }
    }
}
