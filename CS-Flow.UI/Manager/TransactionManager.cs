using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_Flow.Danload;
using CS_Flow.Models;
using CS_Flow.Gateway;

namespace CS_Flow.Manager
{
    public class TransactionManager
    {
        TransactionGateway _transactionGateway = new TransactionGateway(); 
        public List<Transaction> getOnLoaded()
        {
            return _transactionGateway.getOnload();

        }
    }
}
