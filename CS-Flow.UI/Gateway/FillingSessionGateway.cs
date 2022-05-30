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
        public bool Insert(FillingSession fillingSession)
        {
            var data = _dataContext.tblFillingSession.FirstOrDefault(u => u.id == fillingSession.id);
            if (data == null)
            {
                return false;
            }
            _dataContext.tblFillingSession.Add(fillingSession);
            return _dataContext.SaveChanges() > 0;
        }
    }
}
