using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Flow.Models
{
    public class FillingPointDetail :FillingPoint
    {
        //private int id;
        //private string name;
        //private string fgroup;
        //private string product;
        private string status;
        private double flowrate =0;        
        private double liquidTemperature = 0;
        private double vaporTemperature = 0;
        private double liquidPressure = 0;
        private double vaporPressure = 0;
        private double liquidDensity = 0;
        private double vaporDensity = 0;
        private long liquidTotalizer = 0;
        private long vaporTotalizer = 0;
        private int batch = 0;
        private int preset = 0;
        private int today = 0;
        private int safetyCircuit1 = 0;
        private int safetyCircuit2 = 0;
        private int safetyCircuit3 = 0;
        private int safetyCircuit4 = 0;
        private int safetyCircuit5 = 0;
        private int safetyCircuit6 = 0;
        private int safetyCircuit7 = 0;
        private int safetyCircuit8 = 0;
        private int realtimeLoaded = 0;
        
        private List<ChildDevice> childDevices;
        private List<string> messages;

        public FillingPointDetail()
        {
            childDevices = new List<ChildDevice>();
            status = "Disconnected";
            messages = new List<string>();
        }
        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Group { get { return fgroup; } set { fgroup = value; } }
        public string Product { get { return product; } set { product = value; } }
        public string Status { get { return status; } set { status = value; } }
        public double Flowrate { get { return flowrate; } set { flowrate = value; } }
        public double LiquidTemperature { get { return liquidTemperature; } set { liquidTemperature = value; } }
        public double VaporTemperature { get { return vaporTemperature; } set { vaporTemperature = value; } }
        public double LiquidPressure { get { return liquidPressure; } set { liquidPressure = value; } }
        public double VaporPressure { get { return vaporPressure; } set { vaporPressure = value; } }
        public double LiquidDensity { get { return liquidDensity; } set { liquidDensity = value; } }
        public double VaporDensity { get { return vaporDensity; } set { vaporDensity = value; } }
        public long LiquidTotalizer { get { return liquidTotalizer; } set { liquidTotalizer = value; } }
        public long VaporTotalizer { get { return vaporTotalizer; } set { vaporTotalizer = value; } }
        public int Batch { get { return batch; } set { batch = value; } }
        public int Preset { get { return preset; } set { preset = value; } }
        public int Today { get { return today; } set { today = value; } }
        public int SafetyCircuit1 { get { return safetyCircuit1; } set { safetyCircuit1 = value; } }
        public int SafetyCircuit2 { get { return safetyCircuit2; } set { safetyCircuit2 = value; } }
        public int SafetyCircuit3 { get { return safetyCircuit3; } set { safetyCircuit3 = value; } }
        public int SafetyCircuit4 { get { return safetyCircuit4; } set { safetyCircuit4 = value; } }
        public int SafetyCircuit5 { get { return safetyCircuit5; } set { safetyCircuit5 = value; } }
        public int SafetyCircuit6 { get { return safetyCircuit6; } set { safetyCircuit6 = value; } }
        public int SafetyCircuit7 { get { return safetyCircuit7; } set { safetyCircuit7 = value; } }
        public int SafetyCircuit8 { get { return safetyCircuit8; } set { safetyCircuit8 = value; } }
        public int RealtimeLoaded { get { return realtimeLoaded; } set { realtimeLoaded = value; } }

        public void setChildDevice(ChildDevice cd) 
        {
            childDevices.Add(cd);
        }
        public List<ChildDevice> getChildDevice()
        {
            return childDevices;
        }
        

        public List<String> Message { get; set; }
    }
}
