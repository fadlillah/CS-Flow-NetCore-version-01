using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_Flow.Data;
using CS_Flow.Models;

namespace CS_Flow.Gateway
{
    internal class ChildDeviceGateway
    {
        DataContext _dataContext = new DataContext();
        public List<ChildDevice> getAll()
        {
            return _dataContext.tblChildDevice.ToList();
        }
        public List<ChildDevice> getByFp(int fpId)
        {
            return _dataContext.tblChildDevice.Where(x => x.id == fpId).ToList();
        }
    }
}
