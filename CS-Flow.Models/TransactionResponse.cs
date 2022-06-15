using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Flow.Models
{
    public class TransactionResponse
    {
        public TransactionResponse()
        {
            transactionResponseDetails = new List<TransactionResponseDetail>();
        }
        
        public int actualloaded { get; set; }
        public int batchcnt { get; set; }
        public int batchnumber { get; set; }
        public bool completed { get; set; }
        public double dens { get; set; }
        public int? destinationID { get; set; }
        public int? destinationcompany { get; set; }
        public int? endtotal { get; set; }
        public string fpname { get; set; }
        public int gatelogid { get; set; }
        public string id { get; set; }
        public decimal measured_dens { get; set; }
        public decimal measured_temp1 { get; set; }
        public decimal measured_temp2 { get; set; }
        public bool multibatch { get; set; }
        public string pin { get; set; }
        public int preset { get; set; }
        public string product { get; set; }
        public double starttime { get; set; }
        public int starttotal { get; set; }
        public long stoptime { get; set; }
        public string? tank { get; set; }
        public double temp { get; set; }
        public string? transporter { get; set; }
        public string transporterID { get; set; }
        public string? transportertype { get; set; }
        public List<TransactionResponseDetail>? transactionResponseDetails { get; set; }
    }
    public class TransactionResponseDetail
    {
        public string fpname { get; set; }
        public double starttime { get; set; }
        public double stoptime { get; set; }
        public int preset { get; set; }
        public int loaded { get; set; }
        public int starttotal { get; set; }
        public int endtotal { get; set; }
        public int starttotal2 { get; set; }
        public int endtotal2 { get; set; }
        public bool interrupted { get; set; }
    }
}
