using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using FluentModbus;
using CS_Flow.Models;

namespace CS_Flow.Manager
{
    public class ModbusServerManager
    {
        public List<FillingPointDetail> _fillingPointDetails;
        private ModbusTcpServer tcpServer;
        

        private int startAddress;
        public ModbusServerManager()
        {
            this._fillingPointDetails = new List<FillingPointDetail>();
            tcpServer = new ModbusTcpServer();
            tcpServer.Start();
        }
        public void UpdateValue(List<FillingPointDetail> fpds)
        {
            startAddress = 0;
            int cnt = 0;
            Span<short> registers = tcpServer.GetHoldingRegisters();
            if (fpds != null)
            {
                lock (tcpServer.Lock)
                {
                    foreach (FillingPointDetail fpd in fpds)
                    {
                        if (fpd != null)
                        {
                            foreach (PropertyInfo item in fpd.GetType().GetProperties())
                            {
                                if (item.Name == "Flowrate")
                                {
                                    int result = 0;
                                    int data = Convert.ToInt32(fpd.RealtimeLoaded);
                                   // var data = Convert.ToInt32(fpd.GetType().GetProperty(item.Name).GetValue(fpd, null));
                                    if (data != 0)
                                    {
                                        result = setValue(data);
                                    }
                                    
                                    registers.SetLittleEndian<int>(address: startAddress, result);

                                }
                                else if (item.Name == "LiquidTemperature")
                                {
                                    double data = Convert.ToDouble(fpd.GetType().GetProperty(item.Name).GetValue(fpd, null));
                                    float result = setValue(data);
                                    registers.SetLittleEndian<float>(address: startAddress+2, result);
                                }
                                else if (item.Name == "Preset")
                                {
                                    var data = Convert.ToInt32(fpd.GetType().GetProperty(item.Name).GetValue(fpd, null));
                                    int result = setValue(data);
                                    registers.SetLittleEndian<int>(address: startAddress+4, result);
                                }
                                    //if (item.PropertyType == typeof(float) || item.PropertyType == typeof(double))
                                    //{
                                    //    double data = Convert.ToDouble(fpd.GetType().GetProperty(item.Name).GetValue(fpd, null));
                                    //    float result = setValue(data);
                                    //    registers.SetLittleEndian<float>(address: startAddress, result);
                                    //}
                                    //else if(item.PropertyType == typeof(int) || item.PropertyType == typeof(long))
                                    //{
                                    //    var data = Convert.ToInt32(fpd.GetType().GetProperty(item.Name).GetValue(fpd, null));
                                    //    int result = setValue(data);
                                    //    registers.SetLittleEndian<int>(address: startAddress, result);
                                    //}
                                   //
                            }
                            startAddress += 30;
                            cnt++;
                        }
                        
                    }
                }
            }
        }
        private float setValue(double data)
        {
            float value = (float)data;
            byte[] Arry = BitConverter.GetBytes(value);
            byte[] xArry = new byte[4];
            xArry[0] = Arry[1];
            xArry[1] = Arry[0];
            xArry[2] = Arry[3];
            xArry[3] = Arry[2];
            return BitConverter.ToSingle(xArry, 0);
        }
        private float setValue(float data)
        {
            float value = data;
            byte[] Arry = BitConverter.GetBytes(value);
            byte[] xArry = new byte[4];
            xArry[0] = Arry[1];
            xArry[1] = Arry[0];
            xArry[2] = Arry[3];
            xArry[3] = Arry[2];
            return BitConverter.ToSingle(xArry, 0);
        }
        private int setValue(int data)
        {
            int value = data;
            byte[] Arry = BitConverter.GetBytes(value);
            byte[] xArry = new byte[4];
            xArry[0] = Arry[1];
            xArry[1] = Arry[0];
            xArry[2] = Arry[3];
            xArry[3] = Arry[2];
            return BitConverter.ToInt32(xArry, 0);
        }
    }
}
