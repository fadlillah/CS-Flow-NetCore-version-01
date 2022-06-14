using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_Flow.Models;

namespace CS_Flow.Gateway
{
    public class TransactionGateway
    {
        FillingBatchGateway _fbGateway = new FillingBatchGateway();
        FillingSessionGateway _fsGateway = new FillingSessionGateway();
        private List<Transaction> _transactions;
        public TransactionGateway()
        {
            _transactions = new List<Transaction>();
        }
        public List<Transaction> getOnload()
        {
            List<FillingBatch> fillingBatches = new List<FillingBatch>();
            List<Transaction> transactions = new List<Transaction>();
            fillingBatches = _fbGateway.getAll();
            if (fillingBatches != null)
            {
                foreach (var fb in fillingBatches)
                {
                    if (fb.status < 5)
                    {
                        Transaction ts = new Transaction();
                        ts.id = fb.id;
                        ts.order_id = fb.order_id;
                        ts.batch_id = fb.batch_id;
                        ts.preset = fb.preset;
                        ts.product = fb.product;
                        ts.filling_point = fb.filling_point;
                        ts.status = fb.status;
                        ts.pin = fb.pin;
                        ts.scancode = fb.scancode;
                        ts.truck = fb.truck;
                        ts.str_gatein_timestamp = fb.gatein_time == 0 ? "0" : UnixTimeStampToDateTime(fb.gatein_time).ToString("yyyy/MM/dd HH:MM:ss");
                        ts.str_gateout_timestamp = fb.gateout_time == 0?"0": UnixTimeStampToDateTime(fb.gateout_time).ToString("yyyy/MM/dd HH:MM:ss");
                        ts.fillingSession = _fsGateway.getByBatchId(fb.id);
                        transactions.Add(ts);
                    }                  
                
                }
            }
            return transactions;
            
        }
        public DateTime UnixTimeStampToDateTime(int unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
    }
}
