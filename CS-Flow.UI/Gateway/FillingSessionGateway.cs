using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_Flow.Data;
using CS_Flow.Models;

namespace CS_Flow.Gateway
{
    public class FillingSessionGateway
    {
        DataContext _dataContext = new DataContext();
        public List<FillingSession> getAll()
        {
            return _dataContext.tblFillingSession.ToList();
        }
        public FillingSession getByBatchId(int fbId)
        {
            return _dataContext.tblFillingSession.FirstOrDefault(u => u.batch_id == fbId);
        }
        public FillingSession getByLoaded(int fpId, int fbId)
        {
            return _dataContext.tblFillingSession.FirstOrDefault(u => u.filling_point_id == fpId && u.batch_id == fbId);
        }
        public FillingSession getByLoaded(int fbId)
        {
            return _dataContext.tblFillingSession.FirstOrDefault(u=> u.batch_id == fbId);
        }
        public bool Insert(FillingSession fillingSession)
        {
            var data = _dataContext.tblFillingSession.FirstOrDefault(u => u.id == fillingSession.id);
            if (data != null)
            {
                return false;
            }
            _dataContext.tblFillingSession.Add(fillingSession);
            return _dataContext.SaveChanges() > 0;
        }
        public bool Update(FillingSession fillingSession)
        {
            var data = _dataContext.tblFillingSession.FirstOrDefault(u => u.id == fillingSession.id);
            if (data == null) 
            {
                return false;
            }
            _dataContext.Update(data);
            return _dataContext.SaveChanges() > 0;
        }
    }
}
