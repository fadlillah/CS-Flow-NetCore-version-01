using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_Flow.Gateway;
using CS_Flow.Models;

namespace CS_Flow.Manager
{
    public class ChildDeviceManager
    {
        ChildDeviceGateway _childDeviceGateway = new ChildDeviceGateway();
        public List<ChildDevice> getAll()
        {
            return _childDeviceGateway.getAll();
        }

        public List<ChildDevice> getByFp (int id)
        {
            return _childDeviceGateway.getByFp(id);
        }

    }
}
