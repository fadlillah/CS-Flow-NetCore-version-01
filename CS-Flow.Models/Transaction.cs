using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Flow.Models
{
    public class Transaction : FillingBatch
    {
        public string str_gatein_timestamp { get; set; }
        public string str_gateout_timestamp { get; set; }
        public FillingSession? fillingSession { get; set; }
    }
}
