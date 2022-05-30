using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_Flow.Data;
using CS_Flow.Models;

namespace CS_Flow.Gateway
{
    public class FillingPointGateway
    {
        DataContext _dataContext = new DataContext();

        public List<FillingPoint> getAll()
        {
            return _dataContext.tblFillingPoint.ToList();
        }
        
    }
}

