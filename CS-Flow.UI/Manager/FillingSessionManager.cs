using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_Flow.Gateway;
using CS_Flow.Models;

namespace CS_Flow.Manager
{
    internal class FillingSessionManager
    {
        FillingSessionGateway _fillingSessionGateway = new FillingSessionGateway();
        public List<FillingSession> getAll()
        {
            return _fillingSessionGateway.getAll();
        }
        public bool Add(FillingSession fs)
        {
            return _fillingSessionGateway.Insert(fs);
        }
    }
}
