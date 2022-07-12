using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_Flow.Data;
using CS_Flow.Models;

namespace CS_Flow.Gateway
{
    internal class FillingBatchGateway
    {
        DataContext _dataContext = new DataContext();
        public List<FillingBatch> getAll()
        {
            return _dataContext.tblFillingBatch.Where(x=>x.status <5).ToList();
        }
        public List<FillingBatch> getStanby()
        {
            return _dataContext.tblFillingBatch.Where(x => x.status == 0).ToList();
        }
        public FillingBatch getByTransporterId(string transporterId)
        {
            return _dataContext.tblFillingBatch.FirstOrDefault(x => x.truck == transporterId && x.status <5);
        }
        public FillingBatch getByOrderId(string orderId)
        {
            return _dataContext.tblFillingBatch.FirstOrDefault(x => x.order_id == orderId && x.status == 4);
        }
        public List<FillingBatch> getStandbyByFpPin(string Fp, int Pin)
        {
            return _dataContext.tblFillingBatch.Where(x => x.status == 0 && x.filling_point == Fp && x.pin == Pin.ToString()).ToList();
        }
        public List<FillingBatch> getInProgress()
        {
            return _dataContext.tblFillingBatch.Where(x => x.status == 1 || x.status==2).ToList();
        }
        public FillingBatch getProgressOnFp (string FpName)
        {
            return _dataContext.tblFillingBatch.FirstOrDefault(x => x.filling_point == FpName && x.status == 2);
        }
        public List<FillingBatch> getInterupted()
        {
            return _dataContext.tblFillingBatch.Where(x => x.status == 3).ToList();
        }
        public List<FillingBatch> getCompleted()
        {
            return _dataContext.tblFillingBatch.Where(x => x.status == 4).ToList();
        }
        public List<FillingBatch> getFinish()
        {
            return _dataContext.tblFillingBatch.Where(x => x.status == 5).ToList();
        }
        public bool Add(FillingBatch fillingBatch)
        {
            var data = _dataContext.tblFillingBatch.FirstOrDefault(x => x.truck == fillingBatch.truck && x.status==0 & fillingBatch.order_id == x.order_id);
            if (data != null)
            {
                return false;
            }
            _dataContext.Add(fillingBatch);
            return _dataContext.SaveChanges() > 0;
        }
        public bool Update(FillingBatch fillingBatch)
        {
            var data = _dataContext.tblFillingBatch.FirstOrDefault(u => u.id == fillingBatch.id);
            if (data == null)
            {
                return false;
            }
            data.order_id = fillingBatch.order_id;
            data.batch_id = fillingBatch.batch_id;
            data.preset = fillingBatch.preset;
            data.product = fillingBatch.product;
            data.filling_point = fillingBatch.filling_point;
            data.status = fillingBatch.status;
            data.pin = fillingBatch.pin;
            data.scancode = fillingBatch.scancode;
            data.truck = fillingBatch.truck;
            data.gatein_time = fillingBatch.gatein_time;
            data.gateout_time = fillingBatch.gateout_time;
            return _dataContext.SaveChanges() > 0;
        }
        public bool UpdateByFillingPoint(string OrderId, string FpName)
        {
            var data = _dataContext.tblFillingBatch.FirstOrDefault(u => u.order_id == OrderId);
            if (data == null)
            {
                return false;
            }
            data.filling_point = FpName;
            return _dataContext.SaveChanges() > 0;
        }
        public bool UpdateStatus(string orderId, int Status)
        {
            var data = _dataContext.tblFillingBatch.FirstOrDefault(u => u.order_id == orderId);
            if (data == null)
            {
                return false;
            }
            data.status = Status;
            //_dataContext.tblFillingBatch.Update(data);
            return _dataContext.SaveChanges() > 0;
        }
        public bool UpdateGateOut(string orderId)
        {
            var data = _dataContext.tblFillingBatch.FirstOrDefault(u => u.order_id == orderId && u.status == 4);
            if (data == null)
            {
                return false;
            }
            data.gateout_time =Convert.ToInt32(DateTimeOffset.Now.ToUnixTimeSeconds());
            data.status = 5;
            _dataContext.tblFillingBatch.Update(data);
            return _dataContext.SaveChanges() > 0;
        }

    }
}
