using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_Flow.Manager;
using CS_Flow.Models;

namespace CS_Flow.Gateway
{
    public class FillingPointDetailGateway
    {
        public List<FillingPointDetail> getAll()
        {
            List<FillingPointDetail> fpDetails = new List<FillingPointDetail>();
            List<FillingPoint> fillingPoints = new List<FillingPoint>();
            FillingPointManager fpManager = new FillingPointManager();
            fillingPoints = fpManager.getAll();

            foreach (FillingPoint fp in fillingPoints)
            {
                FillingPointDetail fpDetail = new FillingPointDetail();
                fpDetail.Id = fp.id;
                fpDetail.Name = fp.name;
                fpDetail.Group = fp.fgroup;
                fpDetail.Product = fp.product;
                fpDetail.enabled = fp.enabled;
                fpDetail.tank = fp.tank;
                fpDetail.tank_temperature = fp.tank_temperature;
                fpDetail.tank_density = fp.tank_density;
                fpDetail.fdm_id = fp.fdm_id;

                #region Get Device Batch Controller
                ChildDeviceManager childDeviceManager = new ChildDeviceManager();
                try
                {
                    List<ChildDevice> result = childDeviceManager.getByFp(fp.id);
                    if (result != null)
                    {
                        foreach (var cd in result)
                        {
                            fpDetail.setChildDevice(cd);
                        }
                    }

                }
                catch (Exception e)
                {
                    fpDetail.Message.Add(e.ToString());
                }
                fpDetails.Add(fpDetail);
                #endregion 
            }
            return fpDetails;
        }
    }
}
