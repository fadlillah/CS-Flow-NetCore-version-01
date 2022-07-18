using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_Flow.Models;
using CS_Flow.Lib;

using CS_Flow.Gateway;

namespace CS_Flow.Manager
{ 
    public class FillingPointDetailManager
    {
        private List<DanloadNetLib> _danloadLibs;
        private List<AcculoadLib> _acculoadLibs;
        private List<FillingPointDetail> _fillingPointDetails;
        private FillingBatchManager _FillingBatchManager;
        private FillingSessionManager _fillingSessionManager;
        public bool EventFillingPoint = false;
        public FillingPointDetailManager()
        {
            _danloadLibs = new List<DanloadNetLib>();
            _acculoadLibs = new List<AcculoadLib>();
            _fillingPointDetails = new List<FillingPointDetail>();
            _FillingBatchManager = new FillingBatchManager();
            _fillingSessionManager = new FillingSessionManager();
        }
        public void Init()
        {
            FillingPointDetailGateway fpDetailGateway = new FillingPointDetailGateway();
            foreach (FillingPointDetail fpDetail in fpDetailGateway.getAll())
            {
                List<ChildDevice> childDevices = fpDetail.getChildDevice();
                if (childDevices != null)
                {
                    foreach (var device in childDevices)
                    {
                        if (device.protocol == "Danload")
                        {
                            string[] connection = device.conn_str.Split(';');

                            if (connection[0] == "TCP")
                            {
                                DanloadTCPConnection danloadTCP = new DanloadTCPConnection();
                                danloadTCP.fp_Id = fpDetail.Id;
                                danloadTCP.IpAddress = connection[1];
                                danloadTCP.Port = connection[2];
                                _danloadLibs.Add(danloadTCP);
                                AcculoadTCPConnection acculoadTCP = new AcculoadTCPConnection();
                                acculoadTCP.fp_Id = 0;
                                acculoadTCP.IpAddress = "";
                                acculoadTCP.Port = "";
                                _acculoadLibs.Add(acculoadTCP);
                            }
                        }
                        else if (device.protocol == "Accuload III")
                        {
                            string[] connection = device.conn_str.Split(';');
                            if (connection[0] == "TCP")
                            {
                                AcculoadTCPConnection acculoadTCP = new AcculoadTCPConnection();
                                acculoadTCP.fp_Id = fpDetail.id;
                                acculoadTCP.IpAddress = connection[1];
                                acculoadTCP.Port = connection[2];
                                _acculoadLibs.Add(acculoadTCP);
                                DanloadTCPConnection danloadTCP = new DanloadTCPConnection();
                                danloadTCP.fp_Id = 0;
                                danloadTCP.IpAddress = "";
                                danloadTCP.Port = "";
                                _danloadLibs.Add(danloadTCP);
                            }                            
                        }

                    }
                }
                _fillingPointDetails.Add(fpDetail);
            }
        }
        public List<DanloadNetLib> GetDanloadTCPConnection()
        {
            return _danloadLibs;
        }
        public List<FillingPointDetail> GetFillingPointDetails()
        {
            return _fillingPointDetails;
        }
        public void updateConnection()
        {
            while (true)
            {
                if (_fillingPointDetails != null)
                {
                    for (int inc = 0; inc < _fillingPointDetails.Count; inc++)
                    {
                        FillingPointDetail fpd = new FillingPointDetail();
                        fpd = _fillingPointDetails[inc];
                        List<ChildDevice> childDevices = fpd.getChildDevice();
                        ChildDevice cd = childDevices.First(x => x.fp_id == fpd.id);
                        string[] connection = cd.conn_str.Split(";");
                        if (connection[0] == "TCP")
                        {
                            if (cd.protocol == "Danload")
                            {
                                try
                                {
                                    if (!_danloadLibs[inc].ServerConnected)
                                    {
                                        _danloadLibs[inc].Connect(connection[2], connection[1]);
                                        if (_danloadLibs[inc].ServerConnected)
                                        {
                                            _fillingPointDetails[inc].Status = "Connected";
                                            _danloadLibs[inc].startDanload();

                                        }
                                        else
                                        {
                                            _fillingPointDetails[inc].Status = "Disconnected";

                                        }
                                    }
                                    else
                                    {
                                        _fillingPointDetails[inc].Status = "Connected";
                                    }
                                   
                                }
                                catch
                                {
                                    _fillingPointDetails[inc].Status = "Disconnected";
                                }
                                

                            }
                            else if (cd.protocol == "Accuload III")
                            {
                                try
                                {
                                    if (!_acculoadLibs[inc].ServerConnected)
                                    {
                                        _acculoadLibs[inc].Connect(connection[2], connection[1]);
                                        if (_acculoadLibs[inc].ServerConnected)
                                        {
                                            _fillingPointDetails[inc].Status = "Connected";
                                            _acculoadLibs[inc].startAccuload();
                                        }
                                        else
                                        {
                                            _fillingPointDetails[inc].Status = "Disconnected";

                                        }
                                    }
                                    else
                                    {
                                        _fillingPointDetails[inc].Status = "Connected";
                                    }

                                }
                                catch
                                {
                                    _fillingPointDetails[inc].Status = "Disconnected";
                                }
                            }
                        }
                       
                      //  _fillingPointDetails[inc].RealtimeLoaded = temp;
                    }
                }
                System.Threading.Thread.Sleep(100);
            }
        }
        private int getRealtimeLoaded(int cnt, FillingPointDetail fpd)
        {
            int result = 0;
            List<FillingBatch> fillingBatches = new List<FillingBatch>();
            FillingBatchManager fillingBatchManager = new FillingBatchManager();
            fillingBatches = fillingBatchManager.getInProgress();
            if (fillingBatches != null)
            {
                FillingBatch _fpb = fillingBatches.Where(x => x.filling_point == fpd.name).FirstOrDefault();
                if (_fpb != null)
                {
                    FillingSession fillingSession = new FillingSession();
                    FillingSessionManager fillingSessionManager = new FillingSessionManager();
                    fillingSession = fillingSessionManager.getByBatchId(_fpb.id);
                    if (fillingSession != null)
                    {
                        result = _danloadLibs[cnt].GrossTotal - fillingSession.start_totalizer;
                    }
                }
            }
           
            return result;
        }
        public void realTimeLoaded()
        {
            while (true)
            {
                if (_fillingPointDetails != null)
                {
                    for (int inc=0; inc< _fillingPointDetails.Count; inc++)
                    {
                        FillingPointDetail fpd = new FillingPointDetail();
                        fpd = _fillingPointDetails[inc];
                        _fillingPointDetails[inc].RealtimeLoaded = getRealtimeLoaded(inc, fpd);
                    //    Random rn = new Random();
                    //    int temp = rn.Next(0, 100);
                    //    _fillingPointDetails[inc].RealtimeLoaded = temp;
                    }
                }
                Thread.Sleep(100);
            }

        }
        public void updateDataBC()
        {
            while (true)
            {
                if (_fillingPointDetails != null)
                {
                    for (int inc = 0; inc < _fillingPointDetails.Count; inc++)
                    {
                        FillingPointDetail fpd = new FillingPointDetail();
                        fpd = _fillingPointDetails[inc];
                        if (fpd.Status == "Connected")
                        {
                            List<ChildDevice> childDevices = fpd.getChildDevice();
                            ChildDevice cd = childDevices.First(x => x.fp_id == fpd.id);
                            string[] connection = cd.conn_str.Split(";");
                            if (connection[0] == "TCP")
                            {
                                if (cd.protocol == "Danload")
                                {
                                    if (_danloadLibs[inc].ServerConnected)
                                    {
                                        if (_danloadLibs[inc].KeyEnter != 0)
                                        {
                                            _danloadLibs[inc].PinKeyAccept = true;
                                            List<FillingBatch> fillingBatchs = new List<FillingBatch>();
                                            fillingBatchs = _FillingBatchManager.getStandbyByFpPin(fpd.name, _danloadLibs[inc].KeyEnter);
                                            
                                            if (fillingBatchs.Count == 1)
                                            {                                                
                                                _danloadLibs[inc].batch_request = fillingBatchs[0].preset;
                                                _danloadLibs[inc].pinKey = Convert.ToInt32(fillingBatchs[0].pin);
                                                _FillingBatchManager.UpdateStatus(fillingBatchs[0].order_id, 2);
                                                _danloadLibs[inc].KeyEnter = 0;
                                                _fillingSessionManager.StartLoaded(_danloadLibs[0].GrossTotal, fpd, cd, fillingBatchs[0]);                                                
                                            }
                                            else
                                            {
                                                _danloadLibs[inc].PinKeyAccept = false;

                                            }
                                        }
                                        if (_danloadLibs[inc].StartFlow == true)
                                        {
                                            _danloadLibs[inc].StartFlow = false;
                                        }
                                        if (_danloadLibs[inc].DanloadStatus == "END_TRANSACTION_STATE")
                                        {
                                            //update filling batch to complete
                                            FillingBatch fillingBatch = new FillingBatch();
                                            fillingBatch = _FillingBatchManager.getProgressByFp(fpd.name);
                                            if(fillingBatch != null)
                                            {
                                                _FillingBatchManager.UpdateStatus(fillingBatch.order_id, 4);
                                                
                                                //update session to complete 
                                                FillingSession fs = new FillingSession();
                                                fs = _fillingSessionManager.getLoaded(fpd.id, fillingBatch.id);
                                                fs.stop_time = Convert.ToInt32(DateTimeOffset.Now.ToUnixTimeSeconds());
                                                fs.stop_totalizer = _danloadLibs[inc].GrossTotal;
                                                fs.loaded = fs.stop_totalizer - fs.start_totalizer;
                                                fs.temperature = _danloadLibs[inc].temp10;
                                                fs.density = _danloadLibs[inc].dens;
                                                fs.tank_supply = "";
                                                fs.temperature = _danloadLibs[inc].temp10;                                                
                                                _fillingSessionManager.Complete(fs);

                                            }

                                        }
                                    }                                    
                                }
                                if (cd.protocol == "Accuload III")
                                {
                                    if (_acculoadLibs[inc].ServerConnected)
                                    {
                                        if (_acculoadLibs[inc].keyEnter != 0)
                                        {
                                            _acculoadLibs[inc].PinKeyAccept = true;
                                            List<FillingBatch> fillingBatchs = new List<FillingBatch>();
                                            fillingBatchs = _FillingBatchManager.getStandbyByFpPin(fpd.name, _acculoadLibs[inc].keyEnter);

                                            if (fillingBatchs.Count == 1)
                                            {
                                                _acculoadLibs[inc].batch_request = fillingBatchs[0].preset;
                                                _acculoadLibs[inc].pinKey = Convert.ToInt32(fillingBatchs[0].pin);
                                                _FillingBatchManager.UpdateStatus(fillingBatchs[0].order_id, 2);
                                                _acculoadLibs[inc].keyEnter = 0;
                                                _fillingSessionManager.StartLoaded(Convert.ToInt32(_danloadLibs[inc].GrossTotal), fpd, cd, fillingBatchs[0]);
                                            }
                                            else
                                            {
                                                _acculoadLibs[inc].PinKeyAccept = false;

                                            }
                                        }
                                        //if (_acculoadLibs[inc] == true)
                                        //{
                                        //    _acculoadLibs[inc].StartFlow = false;
                                        //}
                                        if (_acculoadLibs[inc].responseAccuload == "BATCH_DONE, TRANSACTION_DONE")
                                        {
                                            //update filling batch to complete
                                            FillingBatch fillingBatch = new FillingBatch();
                                            fillingBatch = _FillingBatchManager.getProgressByFp(fpd.name);
                                            if (fillingBatch != null)
                                            {
                                                _FillingBatchManager.UpdateStatus(fillingBatch.order_id, 4);

                                                //update session to complete 
                                                FillingSession fs = new FillingSession();
                                                fs = _fillingSessionManager.getLoaded(fpd.id, fillingBatch.id);
                                                fs.stop_time = Convert.ToInt32(DateTimeOffset.Now.ToUnixTimeSeconds());
                                                fs.stop_totalizer = Convert.ToInt32(_danloadLibs[inc].GrossTotal);
                                                fs.loaded = fs.stop_totalizer - fs.start_totalizer;
                                                fs.temperature =Convert.ToInt32(_danloadLibs[inc].temp10);
                                                fs.density =Convert.ToInt32(_danloadLibs[inc].dens);
                                                fs.tank_supply = "";
                                                fs.temperature =Convert.ToInt32(_danloadLibs[inc].temp10);
                                                _fillingSessionManager.Complete(fs);

                                            }

                                        }
                                    }
                                }
                            }
                        }                        
                    }
                }
                Thread.Sleep(100);
            }
        } 
        public void stopBC()
        {
            if (_fillingPointDetails != null)
            {
                for (int inc = 0; inc < _fillingPointDetails.Count; inc++)
                {
                    FillingPointDetail fpd = new FillingPointDetail();
                    fpd = _fillingPointDetails[inc];
                    List<ChildDevice> childDevices = fpd.getChildDevice();
                    ChildDevice cd = childDevices.First(x => x.fp_id == fpd.id);
                    string[] connection = cd.conn_str.Split(";");
                    if (connection[0] == "TCP")
                    {
                        if (cd.protocol == "Danload")
                        {
                            if (_danloadLibs[inc].ServerConnected)
                            {
                                _danloadLibs[inc].Disconnected();
                            }
                        }
                    }
                }
            }
        }

    }  
    public class DanloadTCPConnection : DanloadNetLib
    {
        public int fp_Id { get; set; }
        public string IpAddress { get; set; }
        public string Port { get; set; }
    }
    public class AcculoadTCPConnection : AcculoadLib
    {
        public int fp_Id { get; set; }
        public string IpAddress { get; set; }
        public string Port { get; set; }
    }
    class SerialConnection
    {
        public string Com { get; set; }
        public int Port { get; set; }
    }

}
