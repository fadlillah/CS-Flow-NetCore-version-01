using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_Flow.Models;
using CS_Flow.Danload;
using CS_Flow.Gateway;

namespace CS_Flow.Manager
{ 
    public class FillingPointDetailManager
    {
        private List<DanloadNetLib> _danloadLibs;
        private List<FillingPointDetail> _fillingPointDetails;
        private FillingBatchManager _FillingBatchManager;
        private FillingSessionManager _fillingSessionManager;
        public FillingPointDetailManager()
        {
            _danloadLibs = new List<DanloadNetLib>();
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

                        }
                        Random rn = new Random();
                        int temp = rn.Next(0, 100);
                        _fillingPointDetails[inc].tank_temperature = temp;
                    }
                }
                System.Threading.Thread.Sleep(100);
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
                                            List<FillingBatch> fillingBatchs = new List<FillingBatch>();
                                            fillingBatchs = _FillingBatchManager.getStandbyByFpPin(fpd.name, _danloadLibs[inc].KeyEnter);
                                            if (fillingBatchs.Count == 1)
                                            {
                                                _danloadLibs[inc].batch_request = fillingBatchs[0].preset;
                                                _danloadLibs[inc].pinKey = Convert.ToInt32(fillingBatchs[0].pin);
                                                _FillingBatchManager.UpdateStatus(fillingBatchs[0].order_id, 2);
                                                //Gate In Filling Session
                                                //FillingSession fs = new FillingSession();
                                                //fs.batch_id = cd.id;
                                                //fs.filling_point_id = fpd.id;
                                                //fs.start_time =Convert.ToInt32(DateTimeOffset.Now.ToUnixTimeSeconds());
                                                //fs.start_totalizer = _danloadLibs[inc].GrossTotal;
                                                //fs.preset = fillingBatchs[0].preset;
                                                //fs.temperature = fpd.tank_temperature;
                                                //fs.density = fpd.tank_density;
                                                //_fillingSessionManager.Add(fs);
                                                _fillingSessionManager.StartLoaded(_danloadLibs[0].GrossTotal, fpd, cd, fillingBatchs[0]);
                                            }                                            
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
                                                _fillingSessionManager.Complete(fs);

                                            }

                                        }
                                    }                                    
                                }
                            }
                        }                        
                    }
                }
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
    class SerialConnection
    {
        public string Com { get; set; }
        public int Port { get; set; }
    }

}
