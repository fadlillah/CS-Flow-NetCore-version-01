using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_Flow.Gateway;
using CS_Flow.Models;

namespace CS_Flow.Manager
{
    public class FillingPointManager
    {
        public FillingPointGateway _fillingPointGateway = new FillingPointGateway();
        public List<FillingPoint> getAll()
        {
            return _fillingPointGateway.getAll();
        }
        
    }
}
