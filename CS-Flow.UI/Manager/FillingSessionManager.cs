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
        public FillingSession getLoaded(int FpId, int fbId)
        {
            return _fillingSessionGateway.getByLoaded(FpId, fbId);
        }
        public FillingSession getLoaded(int fbId)
        {
            return _fillingSessionGateway.getByLoaded(fbId);
        }
        public bool StartLoaded(int StartTot, FillingPointDetail fpd, ChildDevice cd, FillingBatch Fb)
        {
            FillingSession fillingSession = new FillingSession();
            fillingSession.batch_id = Fb.id;
            fillingSession.filling_point_id = fpd.id;
            fillingSession.start_time = Convert.ToInt32(DateTimeOffset.Now.ToUnixTimeSeconds());
            fillingSession.start_totalizer = StartTot;
            fillingSession.preset = Fb.preset;
            fillingSession.tank_supply = "";
            return _fillingSessionGateway.Insert(fillingSession);
        }
        public bool Complete(FillingSession fs)
        {
            return _fillingSessionGateway.Update(fs);
        }
    }
}
