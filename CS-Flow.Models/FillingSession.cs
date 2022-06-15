using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Flow.Models
{
    public class FillingSession
    {
        public int id { get; set; }
        public int batch_id  { get; set; }
        public int filling_point_id { get; set; }
        public int start_time { get; set; }
        public int stop_time { get; set; }
        public int start_totalizer { get; set; }
        public int stop_totalizer { get; set; }
        public int preset { get; set; }
        public bool interrupted { get; set; }
        public decimal temperature { get; set; }
        public decimal density { get; set; }
        public string tank_supply { get; set; }
        public int loaded { get; set; }
        public int start_totalizer_2 { get; set; }
        public int stop_totalizer_2 { get; set; }
        public decimal measured_temperature_1 { get; set; }
        public decimal measured_temperature_2 { get; set; }
        public decimal measured_density { get; set; }
        public int loaded_coriolis { get; set; }
    }
}
