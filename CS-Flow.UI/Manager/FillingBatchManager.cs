using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_Flow.Models;
using CS_Flow.Gateway;

namespace CS_Flow.Manager
{
    public class FillingBatchManager
    {
        FillingBatchGateway _fillingBatchGateway = new FillingBatchGateway();
        public List<FillingBatch> getAll()
        {
            return _fillingBatchGateway.getAll();
        }
        public List<FillingBatch> getStandBy()
        {
            return _fillingBatchGateway.getStanby();
        }
        public FillingBatch getByTransporterId(string transporterId)
        {
            return _fillingBatchGateway.getByTransporterId(transporterId);
        }
        public FillingBatch getByOrderId(string orderId)
        {
            return _fillingBatchGateway.getByOrderId(orderId);
        }
        public List<FillingBatch> getStandbyByFpPin(string Fp, int Pin )
        {
            return _fillingBatchGateway.getStandbyByFpPin(Fp, Pin);
        }
        public List<FillingBatch> getInProgress()
        {
            return _fillingBatchGateway.getInProgress();
        }
        public FillingBatch getProgressByFp(string fpName)
        {
            return _fillingBatchGateway.getProgressOnFp(fpName);
        }
        public List<FillingBatch> getInterupted()
        {
            return _fillingBatchGateway.getInterupted();
        }
        public List<FillingBatch> getCompleted()
        {
            return _fillingBatchGateway.getCompleted();
        }
        public bool Add(FillingBatch fillingBatch)
        {
            return _fillingBatchGateway.Add(fillingBatch);
        }
        public bool UpdateStatus(string OrderId, int Status)
        {
            return _fillingBatchGateway.UpdateStatus(OrderId, Status);
        }
        public bool UpdateGateOut(string OrderId)
        {
            return _fillingBatchGateway.UpdateGateOut(OrderId);
        }
    }
}
