using System;
using System.Text;
using System.IO.Ports;
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;
using CommonClassLibs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
//using System.Windows.Forms;
using TCPClient;
using TCPIPClient;
using System.Timers;
using System.ComponentModel;
using System.IO.Ports;

namespace CS_Flow.Lib
{
    public class AcculoadLib
    {
        private enum _MACHINE_STATE : byte
        {
            DISCONNECTED,
            EQ, // ENQUIRY STAT, Enquire
            DA, // RELEASE KEYPAD, Release Keypad and Display
            WP, // WRITE DELAY PROMPT, Write Delayed Prompt with Echo
            VT, // Request Meter Totalizer
            RQ, // Request Current Flow Rate
            RD_T, // Request Current Transducer or Probe Value (T, P, D)
            RD_P,
            RD_D,
            RT, // Request Transaction
            SB, // Set Batch
            RK, // Read Keypad
            RE_BD, // Reset Status
            RE_TD, // Reset Status
            RE_PF, // Reset Status
            EA,
            AR,
            ET,   //End Transaction
            CT,   //CLEAR TRANSACTIONS
            RP,   // Request Present
            AR_ACK,
            MP,
            TA,
        }

        #region Command and and Constant Definitions
        private enum _CMD_TYPE
        {
            EQ, // ENQUIRY STAT, Enquire
            DA, // RELEASE KEYPAD, Release Keypad and Display
            WP, // WRITE DELAY PROMPT, Write Delayed Prompt with Echo
            VT, // Request Meter Totalizer
            RQ, // Request Current Flow Rate
            RD, // Request Current Transducer or Probe Value (T, P, D)
            RT, // Request Transaction
            SB, // Set Batch
            RK, // Read Keypad
            RE, // Reset Status
            EA,
            AR,
        }
        #endregion

        #region ALARM State
        [Flags]
        private enum _ALARM_FLAG : ulong
        {
            None = 0,
            // A1
            ROM_BAD_DA = 0x1000000000000000,
            RAM_BAD_DA = 0x2000000000000000,
            FLASH_ERROR = 0x4000000000000000,
            RAM_CORRUPT = 0x8000000000000000,
            // A2
            FLASH_BACKUP_BAD_DA = 0x100000000000000,
            WATCHDOG = 0x200000000000000,
            SYS_PROG = 0x400000000000000,
            EAAI = 0x800000000000000,
            // A3
            BSE_FAILURE = 0x10000000000000,
            PASSCODE_RESET_DA = 0x20000000000000,
            POWER_FAIL = 0x40000000000000,
            COMMUNICATION = 0x80000000000000,
            // A4
            CIVACON_COMM_FAILURE_CV = 0x1000000000000,
            SHARED_PRINTER = 0x2000000000000,
            PTB_PRINTER = 0x4000000000000,
            USER_ALARM_1 = 0x8000000000000,
            // A5
            USER_ALARM_2 = 0x100000000000,
            USER_ALARM_3 = 0x200000000000,
            USER_ALARM_4 = 0x400000000000,
            USER_ALARM_5 = 0x800000000000,
            // A6
            USER_ALARM_6 = 0x10000000000,
            USER_ALARM_7 = 0x20000000000,
            USER_ALARM_8 = 0x40000000000,
            USER_ALARM_9 = 0x80000000000,
            // A7
            USER_ALARM_10 = 0x1000000000,
            ADD_PAK_1_POWER_FAIL_A1 = 0x2000000000,
            ADD_PAK_2_POWER_FAIL_A2 = 0x4000000000,
            ADD_PAK_1_DIAGNOSTIC_D1 = 0x8000000000,
            // A8
            ADD_PAK_2_DIAGNOSTIC_D2 = 0x100000000,
            ADD_PAK_1_AUTO_DETECT_FAILED_P1 = 0x200000000,
            ADD_PAK_2_AUTO_DETECT_FAILED_P2 = 0x400000000,
            ADD_PAK_1_COMM_FAILED_C1 = 0x800000000,
            // A9
            ADD_PAK_2_COMM_FAILED_C2 = 0x10000000,
            DISPLAY_FAILURE_DA = 0x20000000,
            MMI_COMM_FAIL_MC = 0x40000000,
            MMI_EXCESS_ARMS_ACTIVE_ME = 0x80000000,
            // A10
            DTA_RETENTION_DA = 0x1000000,
            COMFLASH_CF = 0x2000000,
            NETWORK_PRINTER = 0x4000000,
            SENING_COMM = 0x8000000,
            // A11
            FACTORY_RESERVED = 0x100000,
            RESERVED = 0x200000,
            RESERVED_1 = 0x400000,
            RESERVED_2 = 0x800000,
        }
        #endregion

        #region Response Start Communication 
        private class RspStartCommunication
        {
            byte[] raw;
            private RspStartCommunication(byte[] response)
            {
                raw = new byte[response.Length];
                Array.Copy(response, raw, response.Length);
            }
            private int NumberOfMeters { get { return BitConverter.ToInt16(raw, 2 + 2); } }
            private int NumberOfComponents { get { return BitConverter.ToInt16(raw, 2 + 4); } }
            private int NumberOfValves { get { return BitConverter.ToInt16(raw, 2 + 6); } }
            private int NumberOfFactors { get { return BitConverter.ToInt16(raw, 2 + 8); } }
            private int NumberOfRecipes { get { return BitConverter.ToInt16(raw, 2 + 10); } }
            private int NumberOfAdditives { get { return BitConverter.ToInt16(raw, 2 + 12); } }
            private String TemperatureUnits
            {
                get
                {
                    switch (raw[14])
                    {
                        case 0: return "Celcius";
                        case 1: return "Fahrenheit";
                        default: return "NULL";
                    }
                }
            }
        }
        #endregion

        #region Response Meter Value
        public class RspMeterValueGross   //VT
        {
            String GrossString;
            public RspMeterValueGross(byte[] response)
            {
                SetGrossTotal(response);
            }

            public string SetGrossTotal(byte[] response)
            {
                GrossString = new string(Encoding.ASCII.GetString(response).ToCharArray());
                GrossString = GrossString.Substring(11, 10);
                return GrossString;
            }

            public string TotalString { get { return GrossString; } }
            private int Total
            {
                get
                {
                    int grossTotal = 0;
                    Int32.TryParse(GrossString, out grossTotal);
                    return grossTotal;
                }
            }
        }

        public class RspMeterValueFlowRate   //RQ Flow Rate
        {
            String flowRate;
            public RspMeterValueFlowRate(byte[] response)
            {
                SetRQ(response);
            }

            public string SetRQ(byte[] response)
            {
                flowRate = new string(Encoding.ASCII.GetString(response).ToCharArray());
                flowRate = flowRate.Substring(6, 6);
                return flowRate;
            }

            public string FlowRateString { get { return flowRate; } }
            public int FlowRate
            {
                get
                {
                    int grossTotal = 0;
                    Int32.TryParse(flowRate, out grossTotal);
                    return grossTotal;
                }
            }
        }

        public class RspMeterValueTemperature   //RD_T Temperature
        {
            String Temp;
            public RspMeterValueTemperature(byte[] response)
            {
                SetTemp(response);
            }

            public string SetTemp(byte[] response)
            {
                Temp = new string(Encoding.ASCII.GetString(response).ToCharArray());
                Temp = Temp.Substring(11, 5);
                return Temp;
            }

            public string TemperatureString { get { return Temp; } }
            public int Temperature
            {
                get
                {
                    int TempInt = 0;
                    Int32.TryParse(Temp, out TempInt);
                    return TempInt;
                }
            }
        }

        public class RspMeterValuePressure   //RD_P Pressure
        {
            String Press;
            public RspMeterValuePressure(byte[] response)
            {
                SetPress(response);
            }

            public string SetPress(byte[] response)
            {
                Press = new string(Encoding.ASCII.GetString(response).ToCharArray());
                Press = Press.Substring(11, 4);
                return Press;
            }

            public string PressString { get { return Press; } }
            public int Pressure
            {
                get
                {
                    int PressInt = 0;
                    Int32.TryParse(Press, out PressInt);
                    return PressInt;
                }
            }
        }

        public class RspMeterValueDensity   //RD_D Density
        {
            String Dens;
            public RspMeterValueDensity(byte[] response)
            {
                SetDens(response);
            }

            public string SetDens(byte[] response)
            {
                Dens = new string(Encoding.ASCII.GetString(response).ToCharArray());
                Dens = Dens.Substring(11, 4);
                return Dens;
            }

            public string DensString { get { return Dens; } }

            public int Density
            {
                get
                {
                    int DensInt = 0;
                    Int32.TryParse(Dens, out DensInt);
                    return DensInt;
                }
            }
        }

        #endregion

        #region Response EQ (Enquire Status)
        /// <summary>
        /// Responses: ’C1C2C3C4C5C6’ Good Response: Six characters C1 C2 C3 C4 C5 C6
        /// </summary>
        [Flags]
        public enum _STATUS_FLAG : ulong
        {
            None = 0,
            // A1
            AUTHORIZED = 0x1000000000000000,
            FLOWING = 0x2000000000000000,
            RELEASED = 0x4000000000000000,
            PROG_MODE = 0x8000000000000000,
            // A2
            KEYPAD_DATA_PENDING = 0x100000000000000,
            BATCH_DONE = 0x200000000000000,
            TRANSACTION_DONE = 0x400000000000000,
            TRANSACTION_PROGRESS = 0x800000000000000,
            // A3
            STANDBY = 0x10000000000000,
            STORAGE_FULL = 0x20000000000000,
            STB_TRANS_EXIST = 0x40000000000000,
            ALARM_ON = 0x80000000000000,
            // A4
            POWER_FAIL = 0x1000000000000,
            MSG_TIME_OUT = 0x2000000000000,
            DELAYED_PROMPT_EFFECT = 0x4000000000000,
            PROG_VAL_CHANGE = 0x8000000000000,
            // A5
            INPUT_3 = 0x100000000000,
            INPUT_2 = 0x200000000000,
            INPUT_1 = 0x400000000000,
            CHECK_ENTRIES = 0x800000000000,
            // A6
            INPUT_7 = 0x10000000000,
            INPUT_6 = 0x20000000000,
            INPUT_5 = 0x40000000000,
            INPUT_4 = 0x80000000000,
            // A7
            INPUT_11 = 0x1000000000,
            INPUT_10 = 0x2000000000,
            INPUT_9 = 0x4000000000,
            INPUT_8 = 0x8000000000,
            // A8
            INPUT_15 = 0x100000000,
            INPUT_14 = 0x200000000,
            INPUT_13 = 0x400000000,
            INPUT_12 = 0x800000000,
            // A9
            INPUT_19 = 0x10000000,
            INPUT_18 = 0x20000000,
            INPUT_17 = 0x40000000,
            INPUT_16 = 0x80000000,
            // A10
            INPUT_23 = 0x1000000,
            INPUT_22 = 0x2000000,
            INPUT_21 = 0x4000000,
            INPUT_20 = 0x8000000,
            // A11
            INPUT_27 = 0x100000,
            INPUT_26 = 0x200000,
            INPUT_25 = 0x400000,
            INPUT_24 = 0x800000,
            // A12
            INPUT_31 = 0x10000,
            INPUT_30 = 0x20000,
            INPUT_29 = 0x40000,
            INPUT_28 = 0x80000,
            // A13
            INPUT_35 = 0x1000,
            INPUT_34 = 0x2000,
            INPUT_33 = 0x4000,
            INPUT_32 = 0x8000,
            // A14
            INPUT_39 = 0x100,
            INPUT_38 = 0x200,
            INPUT_37 = 0x400,
            INPUT_36 = 0x800,
            // 15
            INPUT_43 = 0x10,
            INPUT_42 = 0x20,
            INPUT_41 = 0x40,
            INPUT_40 = 0x80,
            // A16
            PRINTING = 0x1,
            PERMISSIVE_DELAY = 0x2,
            CARD_DATA_PRESENT = 0x4,
            PRESET_IN_PROGRESS = 0x8
        }

        public class RspEQ
        {
            ulong rawStatus;
            //public RspEQ() { }
            public bool boolSimulator = false;
            public RspEQ(byte[] response)
            {
                if (response[0] == 0x00)
                {
                    boolSimulator = false;
                    SetStatus(response);
                }
                else
                {
                    boolSimulator = true;
                    byte[] newResponse = new byte[response.Length + 1];
                    response.CopyTo(newResponse, 1);
                    newResponse[0] = 0x00;
                    SetStatus(newResponse);
                }
            }
            public void SetStatus(byte[] response)
            {
                ulong[] rawUlong = new ulong[16];
                for (int i = 0; i < 16; i++)
                {
                    rawUlong[i] = (ulong)response[i + 4] - '0';
                }

                rawStatus = rawUlong[15] | (rawUlong[14] << 4) |
                    (rawUlong[13] << 8) | (rawUlong[12] << 12) |
                    (rawUlong[11] << 16) | (rawUlong[10] << 20) |
                    (rawUlong[9] << 24) | (rawUlong[8] << 28) |
                    (rawUlong[7] << 32) | (rawUlong[6] << 36) |
                    (rawUlong[5] << 40) | (rawUlong[4] << 44) |
                    (rawUlong[3] << 48) | (rawUlong[2] << 52) |
                    (rawUlong[1] << 56) | (rawUlong[0] << 60);
            }
            public _STATUS_FLAG Status { get { return (_STATUS_FLAG)rawStatus; } }

            public bool isSimulator()
            {
                if (boolSimulator)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public String PrintStatus
            {
                get
                {
                    var status = (_STATUS_FLAG)rawStatus;
                    return String.Format("ACL STAT: {0:G}", status);
                }
            }

            public String PrintStatusEQ()
            {
                _STATUS_FLAG statusEQ = (_STATUS_FLAG)rawStatus;
                return statusEQ.ToString();
            }

            public bool AUTHORIZED()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)rawStatus;
                if (stat.HasFlag(_STATUS_FLAG.AUTHORIZED))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool FLOWING()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)rawStatus;
                if (stat.HasFlag(_STATUS_FLAG.FLOWING))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool RELEASED()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)rawStatus;
                if (stat.HasFlag(_STATUS_FLAG.RELEASED))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            private bool PROG_MODE()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)rawStatus;
                if (stat.HasFlag(_STATUS_FLAG.PROG_MODE))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool KEYPAD_DATA_PENDING()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)rawStatus;
                if (stat.HasFlag(_STATUS_FLAG.KEYPAD_DATA_PENDING))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool BATCH_DONE()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)rawStatus;
                if (stat.HasFlag(_STATUS_FLAG.BATCH_DONE))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool TRANSACTION_DONE()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)rawStatus;
                if (stat.HasFlag(_STATUS_FLAG.TRANSACTION_DONE))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool TRANSACTION_PROGRESS()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)rawStatus;
                if (stat.HasFlag(_STATUS_FLAG.TRANSACTION_PROGRESS))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            private bool STANDBY()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)rawStatus;
                if (stat.HasFlag(_STATUS_FLAG.STANDBY))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            private bool STORAGE_FULL()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)rawStatus;
                if (stat.HasFlag(_STATUS_FLAG.STORAGE_FULL))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            private bool STB_TRANS_EXIST()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)rawStatus;
                if (stat.HasFlag(_STATUS_FLAG.STB_TRANS_EXIST))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool ALARM_ON()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)rawStatus;
                if (stat.HasFlag(_STATUS_FLAG.ALARM_ON))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool POWER_FAIL()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)rawStatus;
                if (stat.HasFlag(_STATUS_FLAG.POWER_FAIL))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            private bool MSG_TIME_OUT()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)rawStatus;
                if (stat.HasFlag(_STATUS_FLAG.MSG_TIME_OUT))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool DELAYED_PROMPT_EFFECT()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)rawStatus;
                if (stat.HasFlag(_STATUS_FLAG.DELAYED_PROMPT_EFFECT))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool PROG_VAL_CHANGE()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)rawStatus;
                if (stat.HasFlag(_STATUS_FLAG.PROG_VAL_CHANGE))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool CHECK_ENTRIES()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)rawStatus;
                if (stat.HasFlag(_STATUS_FLAG.CHECK_ENTRIES))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool PRINTING()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)rawStatus;
                if (stat.HasFlag(_STATUS_FLAG.PRINTING))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool PERMISSIVE_DELAY()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)rawStatus;
                if (stat.HasFlag(_STATUS_FLAG.PERMISSIVE_DELAY))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool CARD_DATA_PRESENT()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)rawStatus;
                if (stat.HasFlag(_STATUS_FLAG.CARD_DATA_PRESENT))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            //PRESET_IN_PROGRESS
            public bool PRESET_IN_PROGRESS()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)rawStatus;
                if (stat.HasFlag(_STATUS_FLAG.PRESET_IN_PROGRESS))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


        }
        #endregion

        #region Response EA (Enquire Alarms)
        [Flags]
        public enum _ALARM_FLAG_PRODUCT
        {
            //A1
            None = 0,
            PRODUCT_PROG_ERROR_DA = 0x1000,
            BACK_PRESSURE = 0x2000,
            HIGH_DENSITY = 0x4000,
            HIGH_FLOW = 0x8000,

            //A2
            HIGH_PRESSURE = 0x100,
            HIGH_TEMP_ALARM = 0x200,
            LOW_DENSITY = 0x400,
            LOW_FLOW = 0x800,

            //A3
            LOW_PRESSURE = 0x10,
            LOW_TEMPERATURE = 0x20,
            ZERO_FLOW = 0x40,
            OVERRUN = 0x80,

            //A4
            BLOCK_VALVE = 0x1,
            BLEND_HIGH = 0x2,
            BLEND_LOW = 0x4,
            PRODUCT_STOP = 0x8,

        }
        public class RspAlarm
        {
            ulong rawAlarm;
            //public RspEQ() { }
            public RspAlarm(byte[] response)
            {
                if (response[0] == 0x00)
                {
                    SetAlarm(response);
                }
                else
                {
                    byte[] newResponse = new byte[response.Length + 1];
                    response.CopyTo(newResponse, 1);
                    newResponse[0] = 0x00;
                    SetAlarm(newResponse);
                }
            }
            public void SetAlarm(byte[] response)
            {
                ulong[] rawUlong = new ulong[4];
                for (int i = 0; i < 4; i++)
                {
                    rawUlong[i] = (ulong)response[i + 4] - '0';
                }

                rawAlarm = rawUlong[3] | (rawUlong[2] << 4) |
                    (rawUlong[1] << 8) | (rawUlong[0] << 12);
            }
            public _ALARM_FLAG_PRODUCT Alarms { get { return (_ALARM_FLAG_PRODUCT)rawAlarm; } }
            public String PrintAlarm
            {
                get
                {
                    var alarms = (_ALARM_FLAG_PRODUCT)rawAlarm;
                    return alarms.ToString();
                }
            }
        }
        #endregion

        #region Response RK (Read Key)
        public class RspRK
        {
            string key_read;
            //public RspRK() { }
            public RspRK(byte[] response)
            {
                if (response[0] == 0x00)
                {
                    SetPasskey(response);
                }
                else
                {
                    byte[] newResponse = new byte[response.Length + 1];
                    response.CopyTo(newResponse, 1);
                    newResponse[0] = 0x00;
                    SetPasskey(newResponse);
                }
            }
            public string SetPasskey(byte[] response)
            {
                key_read = new string(Encoding.ASCII.GetString(response).ToCharArray());
                key_read = key_read.Substring(7, 6);
                return key_read;
            }
            public string ReadPasskey { get { return key_read; } }

            public int KeypadInput
            {
                get
                {
                    int pin = 0;
                    Int32.TryParse(key_read, out pin);
                    return pin;
                }
            }
        }
        #endregion

        #region RT (Request Transaction)
        public class RspPreset   //RD_D Density
        {
            String preset;
            public RspPreset(byte[] response)
            {
                if (response[0] == 0x00)
                {
                    SetPreset(response);
                }
                else
                {
                    byte[] newResponse = new byte[response.Length + 1];
                    response.CopyTo(newResponse, 1);
                    newResponse[0] = 0x00;
                    SetPreset(newResponse);
                }
            }

            public string SetPreset(byte[] response)
            {
                preset = new string(Encoding.ASCII.GetString(response).ToCharArray());
                preset = preset.Substring(14, 9);
                return preset;
            }

            public string PresetString { get { return preset; } }

            public int Density
            {
                get
                {
                    int PresetInt = 0;
                    Int32.TryParse(preset, out PresetInt);
                    return PresetInt;
                }
            }
        }
        #endregion

        #region RspOK
        public class RspOK   //OKE
        {
            String OK_Response;
            public RspOK(byte[] response)
            {
                if (response[0] == 0x00)
                {
                    SetOK(response);
                }
                else
                {
                    byte[] newResponse = new byte[response.Length + 1];
                    response.CopyTo(newResponse, 1);
                    newResponse[0] = 0x00;
                    SetOK(newResponse);
                }
            }

            public string SetOK(byte[] response)
            {
                OK_Response = new string(Encoding.ASCII.GetString(response).ToCharArray());
                OK_Response = OK_Response.Substring(4, 2);
                return OK_Response;
            }

            public string OKString { get { return OK_Response; } }
        }
        #endregion



        //BATAS ATAS
        public bool AppIsExiting = false;
        public bool ServerConnected = false;
        private int MyHostServerID = 0;
        private long ServerTime = DateTime.Now.Ticks;

        private static AutoResetEvent autoEventHostServer = null;//mutex
        private static AutoResetEvent autoEvent2;//mutex

        //System.Windows.Forms.Timer GeneralTimer = null;

        private Thread FullPacketDataProcessThread = null;
        private Queue<TCPIPClient.FullPacket> FullHostServerPacketList = null;
        //public bool IsDisposed { get; }
        private Client client = null; //Client Socket class

        public Dictionary<int, UserClients> dUserClientsList = null;
        private Dictionary<int, StringBuilder> textInformation = new Dictionary<int, StringBuilder>();
        //public Dictionary<int, FileBody> dFileBodyList = null;

       // private Control invoker = null;

        public byte State = (byte)_MACHINE_STATE.DISCONNECTED;

        //System.Timers.Timer timer_rto = new System.Timers.Timer();
        System.Timers.Timer aTimer = new System.Timers.Timer();

        //private SerialPort sp = new SerialPort();
        public string AcculoadStatus;
        public byte fntype = 0x42;


        /// <summary>
        /// BATAS BAWAH
        /// </summary>
        const byte _STX = 0x02;
        const byte _ETX = 0x03;

        byte[] byteDeviceAddress = new byte[2];
        string strDeviceAddress = null;

        public byte MachineState = (byte)_MACHINE_STATE.DISCONNECTED;

        System.Timers.Timer timer_rto = new System.Timers.Timer();

        private SerialPort sp = new SerialPort();
        public string LibStatusString;
        public byte[] CommandDataframe = null;
        public byte[] ResponseDataframe = null;
        //public RspEQ EQStatus = new RspEQ();
        //public RspRK Passkey = new RspRK();

        #region Constructor / Deconstructor
        public AcculoadLib()
        {

        }
        public AcculoadLib(string strDevAddress)
        {

        }
        ~AcculoadLib()
        {
        }
        #endregion

        public string DeviceAddress
        {
            get { return strDeviceAddress; }
            set { strDeviceAddress = value; byteDeviceAddress = Encoding.ASCII.GetBytes(strDeviceAddress); }
        }
        public byte[] DeviceAddressBytes { get { return byteDeviceAddress; } }

        private _CMD_TYPE GetAcculoadCmdType
        {
            get
            {
                string str_cmd_type = Char.ToString((char)CommandDataframe[3]) +
                        Char.ToString((char)CommandDataframe[4]);
                return (_CMD_TYPE)Enum.Parse(typeof(_CMD_TYPE), str_cmd_type);
            }
        }

        #region Open / Close Procedures
        public bool Open(string portName, int baudRate, int databits, Parity parity, StopBits stopBits)
        {
            //Ensure port isn't already opened:
            if (!sp.IsOpen)
            {
                //Assign desired settings to the serial port:
                sp.PortName = portName;
                sp.BaudRate = baudRate;
                sp.DataBits = databits;
                sp.Parity = parity;
                sp.StopBits = stopBits;
                //These timeouts are default and cannot be editted through the class at this point:
                sp.ReadTimeout = 1000;
                sp.WriteTimeout = 1000;

                try
                {
                    sp.Open();
                }
                catch (Exception err)
                {
                    LibStatusString = "Error opening " + portName + ": " + err.Message;
                    return false;
                }
                LibStatusString = portName + " opened successfully";
                return true;
            }
            else
            {
                LibStatusString = portName + " already opened";
                return false;
            }
        }
        public bool Close()
        {
            //Ensure port is opened before attempting to close:
            if (sp.IsOpen)
            {
                try
                {
                    sp.Close();
                }
                catch (Exception err)
                {
                    LibStatusString = "Error closing " + sp.PortName + ": " + err.Message;
                    return false;
                }
                LibStatusString = sp.PortName + " closed successfully";
                return true;
            }
            else
            {
                LibStatusString = sp.PortName + " is not open";
                return false;
            }
        }
        #endregion

        #region Connect / DIsconnect Procedures

        public void CheckOnApplicationDirectory()
        {
            try
            {
                string AppPath = GeneralFunction.GetAppPath;

                if (!Directory.Exists(AppPath))
                {
                    Directory.CreateDirectory(AppPath);
                }
            }
            catch
            {
                Console.WriteLine("ISSUE CREATING A DIRECTORY");
            }
        }

        public void Connect(string portDanload, string ipDanload)
        {
            ServerConnected = true;
            InitializeServerConnection();
            if (ConnectToHostServer(portDanload, ipDanload))
            {
                ServerConnected = true;
                //btn_Connect.Enabled = false;
                //btn_Disconnect.Enabled = true;
                //btn_Send.Enabled = true;
                //btn_autoStart.Enabled = true;
                //panel1.AllowDrop = true;
                //buttonSendToClients.Enabled = true;
                //labelStatusInfo.Text = "Connected!!";
                AcculoadStatus = "Connected!!";
                //labelStatusInfo.ForeColor = System.Drawing.Color.Green;
                BeginGeneralTimer();
            }
            else
            {
                ServerConnected = false;
                AcculoadStatus = "Can't connect";
                //labelStatusInfo.Text = "Can't connect";
                //labelStatusInfo.ForeColor = System.Drawing.Color.Red;
                //pictureBox1.Image = imageListStatusLights.Images["RED"];
            }
        }

        public void Disconnected()
        {
            aTimer.Enabled = false;
            count_press_start = 0;
            TellServerImDisconnecting();
            DoServerDisconnect();
            //cmd_tick.Enabled = false;
            //btn_Disconnect.Enabled = false;
            //btn_Send.Enabled = false;
            //btn_autoStart.Enabled = false;
            //panel1.AllowDrop = false;
            //buttonSendToClients.Enabled = false;
            ServerConnected = false;
            //labelStatusInfo.Text = "Disconnected";
            //labelStatusInfo.ForeColor = System.Drawing.Color.Red;
            //pictureBox1.Image = imageListStatusLights.Images["RED"];
            //btn_Connect.Enabled = true;
            //SetSomeLabelInfoFromThread("...");

        }

        private void resetAllState()
        {
            keydata_keep = false;
            batchData_ready = false;
            ACK_Task = false;
            //StartCom_State = false;
            StartCom_fromStatus = false;
            batchEnded = false;
            transEnded = false;
        }

        public int count_press_start = 0;
        public void startAccuload()
        {
            if (ServerConnected)
            {
                AcculoadStatus = "ServerConnected";
                Reset_Condition();
                if (count_press_start == 0)
                {
                    DeviceAddress = "01";
                    count_press_start++;
                    StartCom_State = true;
                    StartCom_fromStatus = false;
                    State = (byte)_MACHINE_STATE.EQ;
                    //aTimer.Enabled = false;
                    aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                    aTimer.Interval = 500;
                    aTimer.Enabled = true;
                    AcculoadStatus = "START";
                }
                else
                {
                    StartCom_fromStatus = true;
                    keydata_keep = false;
                    AcculoadStatus = "Continue";
                    aTimer.Enabled = true;
                    State = (byte)_MACHINE_STATE.EQ;
                }
            }
            else
            {
                AcculoadStatus = "Server NOT Connected";
            }
        }

        private void Reset_Condition()
        {
            startStatusBool = true;
            countEQ = 0;
            flowingStateRT = true;
        }

        // Specify what you want to happen when the Elapsed event is raised.
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            //Console.WriteLine("Hello World!");
            Skema_Satu();
        }

        private byte[] cmd_msg;
        public int batch_request;

        private void Skema_Satu()
        {
            if (ServerConnected)
            {
                switch (State)
                {
                    case (byte)_MACHINE_STATE.DISCONNECTED:

                        break;

                    case (byte)_MACHINE_STATE.EQ:
                        cmd_msg = Encoding.ASCII.GetBytes(_CMD_TYPE.EQ.ToString());
                        WriteCmdMessage(DeviceAddressBytes, cmd_msg);
                        AcculoadStatus = "EQ";
                        break;

                    case (byte)_MACHINE_STATE.DA:
                        cmd_msg = Encoding.ASCII.GetBytes(_CMD_TYPE.DA.ToString());
                        WriteCmdMessage(DeviceAddressBytes, cmd_msg);
                        AcculoadStatus = "DA";
                        break;

                    case (byte)_MACHINE_STATE.WP:
                        byte[] cmd_msg_wp = new byte[23];
                        Array.Copy(Encoding.ASCII.GetBytes("WP 020 Masukkan PIN:&06"), cmd_msg_wp, 23);
                        WriteCmdMessage(DeviceAddressBytes, cmd_msg_wp);
                        AcculoadStatus = "WP";
                        break;

                    case (byte)_MACHINE_STATE.VT:
                        byte[] cmd_msg_vt = new byte[7];
                        //01VT R P13
                        Array.Copy(Encoding.ASCII.GetBytes("VT R P1"), cmd_msg_vt, 7);
                        //cmd_msg = Encoding.ASCII.GetBytes(_CMD_TYPE.VT.ToString());
                        WriteCmdMessage(DeviceAddressBytes, cmd_msg_vt);
                        AcculoadStatus = "VT";
                        break;

                    case (byte)_MACHINE_STATE.RQ:
                        cmd_msg = Encoding.ASCII.GetBytes(_CMD_TYPE.RQ.ToString());
                        WriteCmdMessage(DeviceAddressBytes, cmd_msg);
                        AcculoadStatus = "RQ";
                        break;

                    case (byte)_MACHINE_STATE.RD_T:
                        byte[] cmd_msg_rdt = new byte[4];
                        //01VT R P13
                        Array.Copy(Encoding.ASCII.GetBytes("RD T"), cmd_msg_rdt, 4);
                        //cmd_msg = Encoding.ASCII.GetBytes(_CMD_TYPE.RD.ToString());
                        WriteCmdMessage(DeviceAddressBytes, cmd_msg_rdt);
                        AcculoadStatus = "RD_T";
                        break;


                    case (byte)_MACHINE_STATE.RD_P:
                        byte[] cmd_msg_rdP = new byte[4];
                        //RD P
                        Array.Copy(Encoding.ASCII.GetBytes("RD P"), cmd_msg_rdP, 4);
                        WriteCmdMessage(DeviceAddressBytes, cmd_msg_rdP);
                        AcculoadStatus = "RD_P";
                        break;


                    case (byte)_MACHINE_STATE.RD_D:
                        byte[] cmd_msg_rdD = new byte[4];
                        //RD D
                        Array.Copy(Encoding.ASCII.GetBytes("RD D"), cmd_msg_rdD, 4);
                        WriteCmdMessage(DeviceAddressBytes, cmd_msg_rdD);
                        AcculoadStatus = "RD_D";
                        break;

                    case (byte)_MACHINE_STATE.RT:
                        byte[] cmd_msg_RT = new byte[4];
                        Array.Copy(Encoding.ASCII.GetBytes("RT R"), cmd_msg_RT, 4);
                        WriteCmdMessage(DeviceAddressBytes, cmd_msg_RT);
                        AcculoadStatus = "RT R";
                        break;

                    case (byte)_MACHINE_STATE.SB:
                        //if (batch_request > 0)
                        //{
                        string batchValue = "SB " + batch_request.ToString("000000");
                        byte[] cmd_msg_SB = new byte[batchValue.Length];
                        //Array.Copy(Encoding.ASCII.GetBytes(batchValue), cmd_msg_SB, batchValue.Length);
                        Array.Copy(Encoding.ASCII.GetBytes(batchValue), cmd_msg_SB, batchValue.Length);
                        //Buffer.BlockCopy(Encoding.ASCII.GetBytes(batch_request.ToString()), 0, cmd_msg_SB, 3, sizeof(Int32));

                        //byte[] cmd_msg_SB = new byte[9];
                        //Array.Copy(Encoding.ASCII.GetBytes("SB 005000"), cmd_msg_SB, 9);
                        //byte[] cmd_msg_SB = new byte[15];
                        //Array.Copy(Encoding.ASCII.GetBytes("SB 0-1251"), cmd_msg_SB, 15);
                        WriteCmdMessage(DeviceAddressBytes, cmd_msg_SB);
                        AcculoadStatus = "SB";
                        //}
                        //else
                        //{
                        //    AcculoadStatus = "PRESET 0";
                        //}

                        break;

                    case (byte)_MACHINE_STATE.RK:
                        byte[] cmd_msg_RK = new byte[2];
                        Array.Copy(Encoding.ASCII.GetBytes("RK"), cmd_msg_RK, 2);
                        WriteCmdMessage(DeviceAddressBytes, cmd_msg_RK);
                        AcculoadStatus = "RK";
                        break;

                    case (byte)_MACHINE_STATE.RE_BD:
                        byte[] cmd_msg_REBD = new byte[5];
                        Array.Copy(Encoding.ASCII.GetBytes("RE BD"), cmd_msg_REBD, 5);
                        WriteCmdMessage(DeviceAddressBytes, cmd_msg_REBD);
                        AcculoadStatus = "RE BD";
                        break;

                    case (byte)_MACHINE_STATE.RE_TD:
                        byte[] cmd_msg_RETD = new byte[5];
                        Array.Copy(Encoding.ASCII.GetBytes("RE TD"), cmd_msg_RETD, 5);
                        WriteCmdMessage(DeviceAddressBytes, cmd_msg_RETD);
                        AcculoadStatus = "RE TD";
                        break;

                    case (byte)_MACHINE_STATE.RE_PF:
                        byte[] cmd_msg_REPF = new byte[5];
                        Array.Copy(Encoding.ASCII.GetBytes("RE PF"), cmd_msg_REPF, 5);
                        WriteCmdMessage(DeviceAddressBytes, cmd_msg_REPF);
                        AcculoadStatus = "RE PF";
                        break;

                    case (byte)_MACHINE_STATE.EA:
                        byte[] cmd_msg_EA = new byte[5];
                        Array.Copy(Encoding.ASCII.GetBytes("EA P1"), cmd_msg_EA, 5);
                        WriteCmdMessage(DeviceAddressBytes, cmd_msg_EA);
                        AcculoadStatus = "EA";
                        break;

                    case (byte)_MACHINE_STATE.AR:
                        byte[] cmd_msg_AR = new byte[2];
                        Array.Copy(Encoding.ASCII.GetBytes("AR"), cmd_msg_AR, 2);
                        WriteCmdMessage(DeviceAddressBytes, cmd_msg_AR);
                        AcculoadStatus = "AR";
                        break;

                    case (byte)_MACHINE_STATE.AR_ACK:
                        byte[] cmd_msg_ARACK = new byte[2];
                        Array.Copy(Encoding.ASCII.GetBytes("AR"), cmd_msg_ARACK, 2);
                        WriteCmdMessage(DeviceAddressBytes, cmd_msg_ARACK);
                        AcculoadStatus = "AR";
                        break;

                    case (byte)_MACHINE_STATE.CT:
                        byte[] cmd_msg_CT = new byte[2];
                        Array.Copy(Encoding.ASCII.GetBytes("CT"), cmd_msg_CT, 2);
                        WriteCmdMessage(DeviceAddressBytes, cmd_msg_CT);
                        AcculoadStatus = "CT";
                        break;

                    case (byte)_MACHINE_STATE.ET:
                        byte[] cmd_msg_ET = new byte[2];
                        Array.Copy(Encoding.ASCII.GetBytes("ET"), cmd_msg_ET, 2);
                        WriteCmdMessage(DeviceAddressBytes, cmd_msg_ET);
                        AcculoadStatus = "ET";
                        break;

                    case (byte)_MACHINE_STATE.MP:

                        byte[] cmd_msg_MP = new byte[5];
                        Array.Copy(Encoding.ASCII.GetBytes("MP 01"), cmd_msg_MP, 5);
                        WriteCmdMessage(DeviceAddressBytes, cmd_msg_MP);
                        AcculoadStatus = "MP 01";
                        break;

                    case (byte)_MACHINE_STATE.TA:
                        //if (batch_request > 0)
                        //{
                        string batchValueTA = "TA " + batch_request.ToString("000000");
                        byte[] cmd_msg_TA = new byte[batchValueTA.Length];
                        Array.Copy(Encoding.ASCII.GetBytes(batchValueTA), cmd_msg_TA, batchValueTA.Length);
                        WriteCmdMessage(DeviceAddressBytes, cmd_msg_TA);
                        AcculoadStatus = "TA";
                        //}
                        //else
                        //{
                        //    AcculoadStatus = "PRESET 0";
                        //}
                        break;

                }
            }
            else
            {
                AcculoadStatus = "Server Not Connected";
            }
        }

        public string commandComputer;
        private void WriteCmdMessage(byte[] devAddress, byte[] datafields)
        {
            // Empetied response buffer
            ResponseDataframe = null;

            //Build outgoing danload message:
            BuildMessage(devAddress, datafields);

            SendMessageToServer(CommandDataframe);
            string str_command = BitConverter.ToString(CommandDataframe).Replace("-", " ");
            commandComputer = "CMD: " + str_command;
            //string str_command = ascii.GetString(aclnet.CommandDataframe, 0, aclnet.CommandDataframe.Length);
            //SetMessageToTextBox_FromThread("CMD: " + str_command);
        }

        private void BeginGeneralTimer()
        {
            //create the general timer but skip over it if its already running
            //if (GeneralTimer == null)
            //{
            //    GeneralTimer = new System.Windows.Forms.Timer();
            //    GeneralTimer.Tick += new EventHandler(GeneralTimer_Tick);
            //    GeneralTimer.Interval = 5000;
            //    GeneralTimer.Enabled = true;
            //}
        }
        private void GeneralTimer_Tick(object sender, EventArgs e)
        {
            if (client != null)
            {
                TimeSpan ts = DateTime.Now - client.LastDataFromServer;

                //If we dont hear from the server for more than 5 minutes then there is a problem so disconnect
                if (ts.TotalMinutes > 5)
                {
                    DestroyGeneralTimer();
                    HostCommunicationsHasQuit(false);
                }
            }

            // Add 5 seconds worth of Ticks to the server time
            ServerTime += (TimeSpan.TicksPerSecond * 5);
            //Console.WriteLine("SERVER TIME: " + (new DateTime(GeneralFunction.ServerTime)).ToLocalTime().TimeOfDay.ToString());
        }
        private bool ConnectToHostServer(string portDanload, string ipAddress)
        {
            try
            {
                //pictureBox1.Image = imageListStatusLights.Images["PURPLE"];
                if (client == null)
                {
                    client = new Client();
                    client.OnDisconnected += OnDisconnect;
                    client.OnReceiveData += OnDataReceive;
                }
                else
                {
                    //if we get here then we already have a client object so see if we are already connected
                    if (client.Connected)
                        return true;
                }

                string szIPstr = GetServerAddress(ipAddress);
                if (szIPstr.Length == 0)
                {
                    //pictureBox1.Image = imageListStatusLights.Images["RED"];
                    return false;
                }

                int port = 0;
                if (!Int32.TryParse(portDanload, out port))
                    port = 9999;

                IPAddress ipAdd = IPAddress.Parse(szIPstr);
                client.Connect(ipAdd, port);//(int)GeneralSettings.HostPort);

                if (client.Connected)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                var exceptionMessage = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
                Console.WriteLine($"EXCEPTION IN: ConnectToHostServer - {exceptionMessage}");
            }
            return false;
        }
        private string GetServerAddress(string ipAddress)//translates the server's named IP to an address
        {
            string SHubServer = ipAddress; //GeneralSettings.HostIP.Trim();

            if (SHubServer.Length < 1)
                return string.Empty;

            try
            {
                string[] qaudNums = SHubServer.Split('.');

                // See if its not a straightup IP address.. 
                //if not then we have to resolve the computer name
                if (qaudNums.Length != 4)
                {
                    //Must be a name so see if we can resolve it
                    IPHostEntry hostEntry = Dns.GetHostEntry(SHubServer);

                    foreach (IPAddress a in hostEntry.AddressList)
                    {
                        if (a.AddressFamily == AddressFamily.InterNetwork)//use IP 4 for now
                        {
                            SHubServer = a.ToString();
                            break;
                        }
                    }
                    //SHubServer = hostEntry.AddressList[0].ToString();
                }
            }
            catch (SocketException se)
            {
                Console.WriteLine($"Exception: {se.Message}");
                //statusStrip1.Items[1].Text = se.Message + " for " + Properties.Settings.Default.HostIP;
                SHubServer = string.Empty;
            }

            return SHubServer;
        }

        public string responseAccuload;
        private bool keydata_keep = false;
        public int pinKey;
        public int keyEnter = 0;
        public bool batchData_ready = false;
        public bool ACK_Task = false;
        public bool Auth_Clear = false;
        private bool StartCom_State = false;
        private bool StartCom_fromStatus = false;
        public bool batchEnded = false;
        public bool transEnded = false;
        public bool PinKeyAccept = false;
        ASCIIEncoding ascii = new ASCIIEncoding();
        private int countEQ = 0;
        private bool flowingStateRT = true;
        private bool startStatusBool = false;
        //private setBatchReady = false;
        private void OnDataReceive(byte[] message, int messageSize)
        {
            if (AppIsExiting)
                return;

            if (messageSize > 0)
            {
                //Console.WriteLine($"Raw Data From: Host Server, Size of Packet: {messageSize}");

                //HostServerRawPackets.AddToList(message, messageSize);
                ResponseDataframe = new byte[messageSize];
                Array.Copy(message, ResponseDataframe, messageSize);
                string str_response = BitConverter.ToString(ResponseDataframe).Replace("-", " ");
                //string str_response = ascii.GetString(ResponseDataframe, 0, ResponseDataframe.Length);
                //SetMessageToTextBox_FromThread("RSP: " + str_response);
                if (ResponseDataframe[0] == 0x00)
                {
                    responseAccuload = "RSP:" + str_response;
                }
                else
                {
                    responseAccuload = "RSP:" + str_response;
                }


                //string str_response = ascii.GetString(aclnet.ResponseDataframe, 0, aclnet.ResponseDataframe.Length);
                //SetMessageToTextBox_FromThread("RSP: " + str_response);


                if (autoEventHostServer != null)
                {
                    autoEventHostServer.Set();//Fire in the hole
                }

                if (ServerConnected)
                {
                    if (ResponseDataframe.Length > 2)
                    {

                        //if (CheckResponse(ResponseDataframe))
                        //{
                        //AcculoadStatus = "I am Here";
                        //AcculoadStatus = State.ToString();
                        //ProcessResponse();
                        switch (State)
                        {
                            case (byte)_MACHINE_STATE.DISCONNECTED:

                                break;

                            case (byte)_MACHINE_STATE.EQ:
                                RspEQ RspEQ = new RspEQ(ResponseDataframe);
                                responseAccuload = RspEQ.PrintStatusEQ();

                                if (countEQ == 0)
                                {
                                    State = (byte)_MACHINE_STATE.DA;
                                    countEQ++;
                                }
                                else if (countEQ == 1)
                                {
                                    //State = (byte)_MACHINE_STATE.DA;
                                    State = (byte)_MACHINE_STATE.WP;
                                    countEQ++;
                                }
                                else if (countEQ == 2)
                                {
                                    State = (byte)_MACHINE_STATE.RQ;
                                    countEQ++;
                                }
                                else if (countEQ == 3)
                                {
                                    State = (byte)_MACHINE_STATE.VT;
                                    countEQ++;
                                }
                                else if (countEQ == 4)
                                {
                                    State = (byte)_MACHINE_STATE.RD_T;
                                    countEQ++;
                                }
                                else if (countEQ == 5)
                                {
                                    State = (byte)_MACHINE_STATE.RD_P;
                                    countEQ++;
                                }
                                else if (countEQ == 6)
                                {
                                    State = (byte)_MACHINE_STATE.RD_D;
                                    countEQ = 2;
                                }



                                if (startStatusBool)
                                {
                                    startStatusBool = false;
                                    countEQ = 0;
                                    if (RspEQ.BATCH_DONE())
                                    {
                                        State = (byte)_MACHINE_STATE.RE_BD;
                                    }

                                    if (RspEQ.TRANSACTION_DONE())
                                    {
                                        State = (byte)_MACHINE_STATE.RE_TD;
                                    }

                                    if (RspEQ.TRANSACTION_PROGRESS())
                                    {
                                        State = (byte)_MACHINE_STATE.ET;
                                    }
                                }
                                else
                                {
                                    if (RspEQ.BATCH_DONE())
                                    {
                                        State = (byte)_MACHINE_STATE.ET;
                                    }

                                    if (RspEQ.BATCH_DONE() && RspEQ.TRANSACTION_DONE())
                                    {
                                        //startStatusBool = true;
                                        //State = (byte)_MACHINE_STATE.CT; Edit (20220713)
                                        State = (Byte)_MACHINE_STATE.EQ;
                                    }

                                }


                                //if (RspEQ.AUTHORIZED())
                                //{
                                //    State = (byte)_MACHINE_STATE.SB;
                                //}

                                if (RspEQ.KEYPAD_DATA_PENDING())
                                {
                                    State = (byte)_MACHINE_STATE.RK;
                                    if (batchData_ready)
                                    {
                                        if (RspEQ.isSimulator())
                                        {
                                            State = (byte)_MACHINE_STATE.SB;
                                        }
                                        else
                                        {
                                            State = (byte)_MACHINE_STATE.TA;
                                        }
                                    }
                                }

                                if (RspEQ.FLOWING())
                                {
                                    if (flowingStateRT)
                                    {
                                        State = (byte)_MACHINE_STATE.RT;
                                        flowingStateRT = false;
                                    }
                                    else
                                    {
                                        State = (byte)_MACHINE_STATE.RQ;
                                        flowingStateRT = true;
                                    }
                                }

                                if (RspEQ.FLOWING() && RspEQ.RELEASED() && RspEQ.AUTHORIZED() && RspEQ.TRANSACTION_PROGRESS())
                                {

                                }

                                if (RspEQ.POWER_FAIL())
                                {
                                    State = (byte)_MACHINE_STATE.RE_PF;
                                }

                                if (RspEQ.ALARM_ON())
                                {
                                    State = (byte)_MACHINE_STATE.AR;
                                }

                                if (ACK_Task)
                                {
                                    ACK_Task = false;
                                    //State = (byte)_MACHINE_STATE.AR_ACK;
                                    State = (byte)_MACHINE_STATE.AR;
                                }

                                if (Auth_Clear)
                                {
                                    Auth_Clear = false;
                                    State = (byte)_MACHINE_STATE.ET;
                                }
                                break;

                            case (byte)_MACHINE_STATE.DA:
                                RspOK RspOKE_DA = new RspOK(ResponseDataframe);
                                if (RspOKE_DA.OKString == "OK")
                                {
                                    State = (byte)_MACHINE_STATE.EQ;
                                }
                                else
                                {
                                    State = (byte)_MACHINE_STATE.DA;
                                }
                                break;

                            case (byte)_MACHINE_STATE.WP:
                                RspOK RspOKE_WP = new RspOK(ResponseDataframe);
                                if (RspOKE_WP.OKString == "OK")
                                {
                                    State = (byte)_MACHINE_STATE.EQ;
                                }
                                else
                                {
                                    State = (byte)_MACHINE_STATE.DA;
                                }
                                break;

                            case (byte)_MACHINE_STATE.VT:                    //Request Meter Totalizer
                                RspMeterValueGross RspTotal = new RspMeterValueGross(ResponseDataframe);
                                GrossTotal = RspTotal.TotalString;

                                State = (byte)_MACHINE_STATE.EQ;
                                break;

                            case (byte)_MACHINE_STATE.RQ:                    //Request Flowrate
                                RspMeterValueFlowRate RspRQ = new RspMeterValueFlowRate(ResponseDataframe);
                                Rate3 = RspRQ.FlowRateString;
                                State = (byte)_MACHINE_STATE.EQ;
                                break;

                            case (byte)_MACHINE_STATE.RD_T:                  //Request Temperature
                                RspMeterValueTemperature RspTemp = new RspMeterValueTemperature(ResponseDataframe);
                                temp10 = RspTemp.TemperatureString;
                                State = (byte)_MACHINE_STATE.EQ;
                                break;

                            case (byte)_MACHINE_STATE.RD_P:                 //Request Pressure
                                RspMeterValuePressure RspPress = new RspMeterValuePressure(ResponseDataframe);
                                pres = RspPress.PressString;
                                State = (byte)_MACHINE_STATE.EQ;
                                break;

                            case (byte)_MACHINE_STATE.RD_D:                 //Request Density
                                RspMeterValueDensity RspDens = new RspMeterValueDensity(ResponseDataframe);
                                dens = RspDens.DensString;
                                State = (byte)_MACHINE_STATE.EQ;
                                break;

                            case (byte)_MACHINE_STATE.RT:                    //Request Transaction
                                RspPreset RspPreset = new RspPreset(ResponseDataframe);
                                netvol = RspPreset.PresetString;
                                State = (byte)_MACHINE_STATE.EQ;
                                break;

                            case (byte)_MACHINE_STATE.SB:                    //Set Batch
                                RspOK RspOKE_SB = new RspOK(ResponseDataframe);
                                if (RspOKE_SB.OKString == "OK")
                                {
                                    State = (byte)_MACHINE_STATE.EQ;
                                }
                                else
                                {
                                    State = (byte)_MACHINE_STATE.SB;
                                }
                                break;

                            case (byte)_MACHINE_STATE.RK:                    // Request Key
                                RspRK RspPad = new RspRK(ResponseDataframe);
                                keyEnter = RspPad.KeypadInput;
                                if (PinKeyAccept)
                                {
                                    PinKeyAccept = false;
                                    //SetMessageToTextBox_FromThread("AUTH READY");
                                    batchData_ready = true;
                                    responseAccuload = "PIN:" + RspPad.KeypadInput;
                                }
                                else
                                {
                                    //State = (byte)_MACHINE_STATE.EQ;
                                }
                                State = (byte)_MACHINE_STATE.EQ;
                                break;

                            case (byte)_MACHINE_STATE.RE_BD:

                                State = (byte)_MACHINE_STATE.EQ;
                                break;

                            case (byte)_MACHINE_STATE.RE_TD:

                                State = (byte)_MACHINE_STATE.EQ;
                                break;

                            case (byte)_MACHINE_STATE.RE_PF:
                                State = (byte)_MACHINE_STATE.EQ;
                                break;

                            case (byte)_MACHINE_STATE.EA:
                                RspAlarm RspAlarms_ = new RspAlarm(ResponseDataframe);
                                PrintAlarm0 = RspAlarms_.PrintAlarm;
                                State = (byte)_MACHINE_STATE.EQ;
                                break;


                            case (byte)_MACHINE_STATE.AR:
                                State = (byte)_MACHINE_STATE.EQ;
                                break;

                            case (byte)_MACHINE_STATE.CT:
                                RspOK RspOKE_CT = new RspOK(ResponseDataframe);
                                if (RspOKE_CT.OKString == "OK")
                                {
                                    State = (byte)_MACHINE_STATE.DA;
                                    countEQ = 1;
                                }
                                else
                                {
                                    State = (byte)_MACHINE_STATE.CT;
                                }
                                break;

                            case (byte)_MACHINE_STATE.ET:
                                RspOK RspOKE_ET = new RspOK(ResponseDataframe);
                                if (RspOKE_ET.OKString == "OK")
                                {
                                    State = (byte)_MACHINE_STATE.EQ;
                                }
                                else
                                {
                                    State = (byte)_MACHINE_STATE.ET;
                                }
                                break;

                            case (byte)_MACHINE_STATE.AR_ACK:
                                State = (byte)_MACHINE_STATE.EQ;
                                break;

                            case (byte)_MACHINE_STATE.MP:
                                State = (byte)_MACHINE_STATE.EQ;
                                break;

                            case (byte)_MACHINE_STATE.TA:
                                RspOK RspOKE_TA = new RspOK(ResponseDataframe);
                                if (RspOKE_TA.OKString == "OK")
                                {
                                    State = (byte)_MACHINE_STATE.SB;
                                }
                                else
                                {
                                    State = (byte)_MACHINE_STATE.TA;
                                }
                                //State = (byte)_MACHINE_STATE.EQ;
                                break;

                        }
                        //}
                    }
                }
            }
        }

        //Respon Status
        private int grsvol;
        public string netvol;
        private string status;
        public string PrintAlarm0;
        public string PrintAlarm1;
        public string PrintAlarm2;
        private string PrintAlarm3;
        private string PrintAlarm4;
        private string PrintAlarm5;
        private string PrintAlarm6;
        private string PrintAlarm7;
        private string PrintAlarm8;
        private string PrintAlarm9;
        //end Respon Status

        //Respon Meter 
        private int rawLength;
        private int MeterNumber;
        public string GrossTotal;
        private int NetTotal;
        private int Grs;
        private int Net;
        public string Rate3;
        private int Rate5;
        private int Rate4;
        private long Mtrfac;
        private int Plscnt;
        private long Numfacts;
        private long pls2;
        private long ufg10;
        private long ufn10;
        public string temp10;
        public string dens;
        public string pres;

        //end Respon Meter

        private void OnDisconnect()
        {
            //Debug.WriteLine("Something Disconnected!! - OnDisconnect()");
            DoServerDisconnect();
        }

        private bool ImDisconnecting = false;
        public void DoServerDisconnect()
        {
            int Line = 0;
            if (ImDisconnecting)
                return;

            ImDisconnecting = true;

            Console.WriteLine("\nIN DoServerDisconnect\n");
            try
            {
                //if (invoker.InvokeRequired)
                //{
                //    invoker.Invoke(new MethodInvoker(DoServerDisconnect));
                //    return;
                //}

                //pictureBox1.Image = imageListStatusLights.Images["PURPLE"];

                int i = 0;
                Line = 1;


                if (client != null)
                {
                    TellServerImDisconnecting();
                    Thread.Sleep(75);// this is needed!
                }

                Line = 4;

                ServerConnected = false;

                DestroyGeneralTimer();

                Line = 5;


                /***************************************************/
                try
                {
                    //bust out of the data loops
                    if (autoEventHostServer != null)
                    {
                        autoEventHostServer.Set();

                        i = 0;
                        //while (DataProcessHostServerThread.IsAlive)
                        //{
                        //    Thread.Sleep(1);
                        //    if (i++ > 200)
                        //    {
                        //        DataProcessHostServerThread.Abort();
                        //        //Debug.WriteLine("\nHAD TO ABORT PACKET THREAD\n");
                        //        break;
                        //    }
                        //}

                        autoEventHostServer.Close();
                        autoEventHostServer.Dispose();
                        autoEventHostServer = null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"DoServerDisconnectA: {ex.Message}");
                }

                Line = 8;
                if (autoEvent2 != null)
                {
                    autoEvent2.Set();

                    autoEvent2.Close();
                    autoEvent2.Dispose();
                    autoEvent2 = null;
                }
                /***************************************************/

                Line = 9;
                //Debug.WriteLine("AppIsExiting = " + AppIsExiting.ToString());
                if (client != null)
                {
                    if (client.OnReceiveData != null)
                        client.OnReceiveData -= OnDataReceive;
                    if (client.OnDisconnected != null)
                        client.OnDisconnected -= OnDisconnect;

                    client.Disconnect();
                    client = null;
                }

                Line = 10;

                try
                {
                    Line = 13;
                    //buttonConnect.Text = "Connect";
                    //labelStatusInfo.Text = "NOT Connected";
                    AcculoadStatus = "NOT Connected";
                    Line = 14;
                    //labelStatusInfo.ForeColor = System.Drawing.Color.Red;
                }
                catch { }
                Line = 15;

                //btn_Connect.Enabled = true;
                //pictureBox1.Image = imageListStatusLights.Images["RED"];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DoServerDisconnectB: {ex.Message}");
            }
            finally
            {
                ImDisconnecting = false;
            }

            return;
        }
        private void DestroyGeneralTimer()
        {
            //if (GeneralTimer != null)
            //{
            //    if (GeneralTimer.Enabled == true)
            //        GeneralTimer.Enabled = false;

            //    try
            //    {
            //        GeneralTimer.Tick -= GeneralTimer_Tick;
            //    }
            //    catch (Exception)
            //    {
            //        //just incase there was no event to remove
            //    }
            //    GeneralTimer.Dispose();
            //    GeneralTimer = null;
            //}
        }
        private void TellServerImDisconnecting()
        {
            try
            {
                PACKET_DATA xdata = new PACKET_DATA();

                xdata.Packet_Type = (UInt16)PACKETTYPES.TYPE_Close;
                xdata.Data_Type = 0;
                xdata.Packet_Size = 16;
                xdata.maskTo = 0;
                xdata.idTo = 0;
                xdata.idFrom = 0;

                byte[] byData = PACKET_FUNCTIONS.StructureToByteArray(xdata);

                SendMessageToServer(byData);
            }
            catch (Exception ex)
            {
                string exceptionMessage = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
                Console.WriteLine($"EXCEPTION IN: TellServerImDisconnecting - {exceptionMessage}");
            }
        }
        private void InitializeServerConnection()
        {
            try
            {
                /**** Packet processor mutex, loop and other support variables *************************/
                autoEventHostServer = new AutoResetEvent(false);//the data mutex
                autoEvent2 = new AutoResetEvent(false);//the FullPacket data mutex
                FullPacketDataProcessThread = new Thread(new ThreadStart(ProcessRecievedServerData));
                //DataProcessHostServerThread = new Thread(new ThreadStart(ProcessServerRawPackets));


            }
            catch (Exception ex)
            {
                string exceptionMessage = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
                Console.WriteLine($"EXCEPTION IN: InitializeServerConnection - {exceptionMessage}");
            }
        }
        public void ProcessRecievedServerData()
        {
            try
            {
                Console.WriteLine($"ProcessRecievedHostServerData ThreadID = {Thread.CurrentThread.ManagedThreadId}");
                while (ServerConnected)
                {
                    //ods.DebugOut("Before AutoEvent2");
                    autoEvent2.WaitOne(10000);//wait at mutex until signal
                    //autoEvent2.WaitOne();
                    //ods.DebugOut("After AutoEvent2");
                    if (AppIsExiting || !ServerConnected)
                        break;

                    while (FullHostServerPacketList.Count > 0)
                    {
                        try
                        {
                            TCPIPClient.FullPacket fp;
                            lock (FullHostServerPacketList)
                                fp = FullHostServerPacketList.Dequeue();

                            UInt16 type = (ushort)(fp.ThePacket[1] << 8 | fp.ThePacket[0]);
                            //Debug.WriteLine("Got Server data... Packet type: " + ((PACKETTYPES)type).ToString());
                            switch (type)//Interrogate the first 2 Bytes to see what the packet TYPE is
                            {
                                case (UInt16)PACKETTYPES.TYPE_RequestCredentials:
                                    {
                                        ReplyToHostCredentialRequest(fp.ThePacket);
                                        //(new Thread(() => ReplyToHostCredentialRequest(fp.ThePacket))).Start();//
                                    }
                                    break;
                                case (UInt16)PACKETTYPES.TYPE_Ping:
                                    {
                                        ReplyToHostPing(fp.ThePacket);
                                        Console.WriteLine($"Received Ping: {GeneralFunction.GetDateTimeFormatted}");
                                    }
                                    break;
                                case (UInt16)PACKETTYPES.TYPE_HostExiting:
                                    HostCommunicationsHasQuit(true);
                                    break;
                                case (UInt16)PACKETTYPES.TYPE_Registered:
                                    {
                                        SetConnectionsStatus();
                                    }
                                    break;
                                case (UInt16)PACKETTYPES.TYPE_MessageReceived:
                                    //pictureBox1.Image = imageListStatusLights.Images["GREEN"];
                                    break;
                                case (UInt16)PACKETTYPES.TYPE_ClientData:
                                    AddTheClientToMyList(fp.ThePacket);
                                    break;

                                case (UInt16)PACKETTYPES.TYPE_Message:
                                    {
                                        AssembleMessage(fp.ThePacket);
                                    }
                                    break;
                                case (UInt16)PACKETTYPES.TYPE_ClientDisconnecting:
                                    RemoveClientFromList(fp.ThePacket);
                                    break;
                            }

                            if (client != null)
                                client.LastDataFromServer = DateTime.Now;
                        }
                        catch (Exception ex)
                        {
                            string exceptionMessage = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
                            Console.WriteLine($"EXCEPTION IN: ProcessRecievedServerData A - {exceptionMessage}");
                        }
                    }//end while
                }//end while serverconnected

                //ods.DebugOut("Exiting the ProcessRecievedHostServerData() thread");
            }
            catch (Exception ex)
            {
                string exceptionMessage = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
                Console.WriteLine($"EXCEPTION IN: ProcessRecievedServerData B - {exceptionMessage}");
            }
        }
        public void ReplyToHostCredentialRequest(byte[] message)
        {
            if (client == null)
                return;

            Console.WriteLine($"ReplyToHostCredentialRequest ThreadID = {Thread.CurrentThread.ManagedThreadId}");
            Int32 Loc = 0;
            try
            {
                //We will assume to tell the host this is just an update of the
                //credentials we first sent during the application start. This
                //will be true if the 'message' argument is null, otherwise we
                //will change the packet type below to the 'TYPE_MyCredentials'.
                UInt16 PaketType = (UInt16)PACKETTYPES.TYPE_CredentialsUpdate;

                if (message != null)
                {
                    int myOldServerID = 0;
                    //The host server has past my ID.
                    PACKET_DATA IncomingData = new PACKET_DATA();
                    IncomingData = (PACKET_DATA)PACKET_FUNCTIONS.ByteArrayToStructure(message, typeof(PACKET_DATA));
                    Loc = 10;
                    if (MyHostServerID > 0)
                        myOldServerID = MyHostServerID;
                    Loc = 20;
                    MyHostServerID = (int)IncomingData.idTo;//Hang onto this value
                    Loc = 25;

                    Console.WriteLine($"My Host Server ID is {MyHostServerID}");

                    string MyAddressAsSeenByTheHost = new string(IncomingData.szStringDataA).TrimEnd('\0');//My computer address
                    //SetSomeLabelInfoFromThread($"My Address As Seen By The Server: {MyAddressAsSeenByTheHost}, and my ID given by the server is: {MyHostServerID}");

                    ServerTime = IncomingData.DataLong1;

                    PaketType = (UInt16)PACKETTYPES.TYPE_MyCredentials;
                }

                //ods.DebugOut("Send Host Server some info about myself");
                PACKET_DATA xdata = new PACKET_DATA();

                xdata.Packet_Type = PaketType;
                xdata.Data_Type = 0;
                xdata.Packet_Size = (UInt16)Marshal.SizeOf(typeof(PACKET_DATA));
                xdata.maskTo = 0;
                xdata.idTo = 0;
                xdata.idFrom = 0;

                //Station Name
                string p = System.Environment.MachineName;
                if (p.Length > (xdata.szStringDataA.Length - 1))
                    p.CopyTo(0, xdata.szStringDataA, 0, (xdata.szStringDataA.Length - 1));
                else
                    p.CopyTo(0, xdata.szStringDataA, 0, p.Length);
                xdata.szStringDataA[(xdata.szStringDataA.Length - 1)] = '\0';//cap it off just incase

                //App and DLL Version
                string VersionNumber = string.Empty;

                VersionNumber = Assembly.GetEntryAssembly().GetName().Version.Major.ToString() + "." +
                                    Assembly.GetEntryAssembly().GetName().Version.Minor.ToString() + "." +
                                    Assembly.GetEntryAssembly().GetName().Version.Build.ToString();

                Loc = 30;

                VersionNumber.CopyTo(0, xdata.szStringDataB, 0, VersionNumber.Length);
                Loc = 40;
                //Station Name
                //string L = txtBox_DeviceID.Text;
                //if (L.Length > (xdata.szStringData150.Length - 1))
                //    L.CopyTo(0, xdata.szStringData150, 0, (xdata.szStringData150.Length - 1));
                //else
                //    L.CopyTo(0, xdata.szStringData150, 0, L.Length);
                xdata.szStringData150[(xdata.szStringData150.Length - 1)] = '\0';//cap it off just incase

                Loc = 50;

                //Application type
                xdata.nAppLevel = (UInt16)APPLEVEL.None;


                byte[] byData = PACKET_FUNCTIONS.StructureToByteArray(xdata);
                Loc = 60;
                SendMessageToServer(byData);
                Loc = 70;
            }
            catch (Exception ex)
            {
                string exceptionMessage = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
                Console.WriteLine($"EXCEPTION at location {Loc}, IN: ReplyToHostCredentialRequest - {exceptionMessage}");
            }
        }
        private void SendMessageToServer(byte[] byData)
        {
            //TimeSpan ts = client.LastDataFromServer

            if (client.Connected)
                client.SendMessage(byData);
        }
        private void ReplyToHostPing(byte[] message)
        {
            try
            {
                PACKET_DATA IncomingData = new PACKET_DATA();
                IncomingData = (PACKET_DATA)PACKET_FUNCTIONS.ByteArrayToStructure(message, typeof(PACKET_DATA));

                /****************************************************************************************/
                //calculate how long that ping took to get here
                TimeSpan ts = (new DateTime(IncomingData.DataLong1)) - (new DateTime(ServerTime));
                Console.WriteLine($"{GeneralFunction.GetDateTimeFormatted}: {string.Format("Ping From Server to client: {0:0.##}ms", ts.TotalMilliseconds)}");
                /****************************************************************************************/

                ServerTime = IncomingData.DataLong1;// Server computer's current time!

                PACKET_DATA xdata = new PACKET_DATA();

                xdata.Packet_Type = (UInt16)PACKETTYPES.TYPE_PingResponse;
                xdata.Data_Type = 0;
                xdata.Packet_Size = 16;
                xdata.maskTo = 0;
                xdata.idTo = 0;
                xdata.idFrom = 0;

                xdata.DataLong1 = IncomingData.DataLong1;

                byte[] byData = PACKET_FUNCTIONS.StructureToByteArray(xdata);

                SendMessageToServer(byData);

                CheckThisComputersTimeAgainstServerTime();
            }
            catch (Exception ex)
            {
                string exceptionMessage = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
                Console.WriteLine($"EXCEPTION IN: ReplyToHostPing - {exceptionMessage}");
            }
        }
        private void CheckThisComputersTimeAgainstServerTime()
        {
            Int64 timeDiff = DateTime.UtcNow.Ticks - ServerTime;
            TimeSpan ts = TimeSpan.FromTicks(Math.Abs(timeDiff));
            Console.WriteLine($"Server diff in secs: {ts.TotalSeconds}");

            if (ts.TotalMinutes > 15)
            {
                string msg = string.Format("Computer Time Discrepancy!! " +
                    "The time on this computer differs greatly " +
                    "compared to the time on the Realtrac Server " +
                    "computer. Check this PC's time.");

                Console.WriteLine(msg);
            }
        }
        private void SetConnectionsStatus()
        {
            Int32 loc = 1;
            try
            {
                //if (invoker.InvokeRequired)
                //{
                //    loc = 5;
                //    invoker.Invoke(new MethodInvoker(SetConnectionsStatus));
                //    return;
                //}
                loc = 10;
                //pictureBox1.Image = imageListStatusLights.Images["GREEN"];
            }
            catch (Exception ex)
            {
                string exceptionMessage = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
                Console.WriteLine($"EXCEPTION IN: SetConnectionsStatus - {exceptionMessage}");
            }
        }
        private void AddTheClientToMyList(byte[] message)//or update a clients data
        {
            try
            {
                PACKET_CLIENTDATA IncomingData = new PACKET_CLIENTDATA();
                IncomingData = (PACKET_CLIENTDATA)PACKET_FUNCTIONS.ByteArrayToStructure(message, typeof(PACKET_CLIENTDATA));

                bool AddNewClient = true;

                //figure out if we are updating data from a client or are we adding a new client
                if (dUserClientsList.ContainsKey(IncomingData.iClientID))
                {
                    //Update client Info
                    dUserClientsList[IncomingData.iClientID].szUserName = new string(IncomingData.szUserName).TrimEnd('\0');

                    dUserClientsList[IncomingData.iClientID].szAltIp = new string(IncomingData.szUsersAlternateAddress).TrimEnd('\0');

                    dUserClientsList[IncomingData.iClientID].szStationName = new string(IncomingData.szStationName).TrimEnd('\0');

                    AddNewClient = false;
                }


                if (AddNewClient)
                {
                    string ipaddr = new string(IncomingData.szUsersAddress).TrimEnd('\0');

                    //Console.WriteLine($"{GetFormattedTime}: Adding: {ipaddr}");

                    string name = new string(IncomingData.szUserName).TrimEnd('\0');
                    //Add New Client

                    if (string.IsNullOrEmpty(name))
                    {
                        dUserClientsList.Remove((int)IncomingData.iClientID);
                        return;
                    }

                    UserClients newClient = new UserClients(ipaddr, IncomingData.ListeningPort, name,
                                                            IncomingData.iClientID,
                                                            new string(IncomingData.szUsersAlternateAddress).TrimEnd('\0'), new string(IncomingData.szStationName).TrimEnd('\0'));

                    //ods.DebugOut("HERE 1");
                    AddUserClientToListbox_FromThread(newClient);//button must be created on the interface's thread
                                                                 //ods.DebugOut("HERE 2");
                    lock (dUserClientsList)
                        dUserClientsList.Add(IncomingData.iClientID, newClient);
                    //ods.DebugOut("HERE 3");
                    Console.WriteLine($"{GetFormattedTime}: Adding {name}, ID: {IncomingData.iClientID} and ip: {ipaddr}");

                    //LoadAsyncSound(SOUNDACTION.ClientConnect);
                }

                //WriteToMessagebar_FromThread("Client List Count: " + dUserClientsList.Count, Color.FromName("Control"), 1);
            }
            catch (Exception ex)
            {
                string exceptionMessage = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
                Console.WriteLine($"EXCEPTION IN: AddTheClientToMyList - {exceptionMessage}");
            }
        }
        private void AssembleMessage(byte[] message)
        {
            try
            {
                PACKET_DATA IncomingData = new PACKET_DATA();
                IncomingData = (PACKET_DATA)PACKET_FUNCTIONS.ByteArrayToStructure(message, typeof(PACKET_DATA));

                switch (IncomingData.Data_Type)
                {
                    case (UInt16)PACKETTYPES_SUBMESSAGE.SUBMSG_MessageStart:
                        {
                            if (dUserClientsList.ContainsKey((int)IncomingData.idFrom))
                            {
                                if (textInformation.ContainsKey((int)IncomingData.idFrom))
                                    textInformation[(int)IncomingData.idFrom].Clear();
                                else
                                    textInformation.Add((int)IncomingData.idFrom, new StringBuilder());

                                textInformation[(int)IncomingData.idFrom].Append(new string(IncomingData.szStringDataA).TrimEnd('\0'));
                            }
                        }
                        break;
                    case (UInt16)PACKETTYPES_SUBMESSAGE.SUBMSG_MessageGuts:
                        {
                            textInformation[(int)IncomingData.idFrom].Append(new string(IncomingData.szStringDataA).TrimEnd('\0'));
                        }
                        break;
                    case (UInt16)PACKETTYPES_SUBMESSAGE.SUBMSG_MessageEnd:
                        {
                            SetMessageFromClient_FromThread(textInformation[(int)IncomingData.idFrom].ToString(), (int)IncomingData.idFrom);

                            textInformation[(int)IncomingData.idFrom].Clear();

                            textInformation.Remove((int)IncomingData.idFrom);

                            /****************************************************************/
                            //Now tell the client the message was received!
                            PACKET_DATA xdata = new PACKET_DATA();

                            xdata.Packet_Type = (UInt16)PACKETTYPES.TYPE_MessageReceived;

                            xdata.idTo = xdata.idFrom;
                            xdata.idFrom = (uint)MyHostServerID;

                            byte[] byData = PACKET_FUNCTIONS.StructureToByteArray(xdata);

                            client.SendMessage(byData);
                        }
                        break;
                }
            }
            catch
            {
                Console.WriteLine("ERROR Assembling message");
            }
        }

        private delegate void RemoveClientFromList_Method(byte[] message);
        private void RemoveClientFromList(byte[] message)
        {
            if (AppIsExiting)
                return;

            //if (invoker.InvokeRequired)// because we are affecting the interface from a thread we need to land back on the interface's thread
            //{
            //    invoker.Invoke(new RemoveClientFromList_Method(RemoveClientFromList), new object[] { message });
            //    return;
            //}

            try
            {
                PACKET_CLIENTDATA IncomingData = new PACKET_CLIENTDATA();
                IncomingData = (PACKET_CLIENTDATA)PACKET_FUNCTIONS.ByteArrayToStructure(message, typeof(PACKET_CLIENTDATA));

                UserClients ClientToBeRemoved = null;

                /************************************************************/
                lock (dUserClientsList)
                {
                    if (dUserClientsList.ContainsKey((int)IncomingData.idFrom))
                    {
                        ClientToBeRemoved = dUserClientsList[(int)IncomingData.idFrom];
                        dUserClientsList.Remove((int)IncomingData.idFrom);
                    }
                }
                /************************************************************/

                /************************************************************/
                if (ClientToBeRemoved != null)
                    //listBox1.Items.Remove(ClientToBeRemoved);
                    /************************************************************/

                    /************************************************************/
                    if (textInformation.ContainsKey((int)IncomingData.idFrom))
                    {
                        textInformation[(int)IncomingData.idFrom].Clear();
                        textInformation.Remove((int)IncomingData.idFrom);
                    }
                /************************************************************/

                //lock (dFileBodyList)
                //{
                //    if (dFileBodyList.ContainsKey((int)IncomingData.idFrom))
                //        dFileBodyList.Remove((int)IncomingData.idFrom);
                //}
            }
            catch (Exception ex)
            {
                string exceptionMessage = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
                Console.WriteLine($"EXCEPTION IN: RemoveClientFromList - {exceptionMessage}");
            }
        }

        private delegate void AddUserClientToListbox_Method(UserClients uc);
        private void AddUserClientToListbox_FromThread(UserClients uc)
        {
            if (AppIsExiting)
                return;

            //if (invoker.InvokeRequired)
            //{
            //    //ods.DebugOut("HERE 1a");
            //    invoker.Invoke(new AddUserClientToListbox_Method(AddUserClientToListbox_FromThread), new object[] { uc });
            //    return;
            //}

            //listBox1.Items.Add(uc);

        }
        private string GetFormattedTime
        {
            get
            {
                return $"{DateTime.Now.ToShortDateString()} - {DateTime.Now.ToShortTimeString()}";
            }
        }

        private delegate void SetMessageFromClient_Method(string messageToPost, int messageFromClientID);
        private void SetMessageFromClient_FromThread(string messageToPost, int messageFromClientID)
        {
            if (AppIsExiting)
                return;

            //if (invoker.InvokeRequired)
            //{
            //    invoker.Invoke(new SetMessageFromClient_Method(SetMessageFromClient_FromThread), new object[] { messageToPost, messageFromClientID });
            //    return;
            //}

            if (dUserClientsList.ContainsKey(messageFromClientID))
            {
                //if (txtBox_Rcv.TextLength > 0)
                //    txtBox_Rcv.AppendText(Environment.NewLine);

                //txtBox_Rcv.AppendText($"{dUserClientsList[messageFromClientID].szUserName} at {GetFormattedTime} SAYS:");
                //txtBox_Rcv.AppendText(Environment.NewLine);
                //txtBox_Rcv.AppendText(messageToPost);
                //txtBox_Rcv.AppendText(Environment.NewLine);
            }
        }

        private delegate void HostCommunicationsHasQuitDelegate(bool FromHost);
        private void HostCommunicationsHasQuit(bool FromHost)
        {
            //if (invoker.InvokeRequired)
            //{
            //    invoker.Invoke(new HostCommunicationsHasQuitDelegate(HostCommunicationsHasQuit), new object[] { FromHost });
            //    return;
            //}

            if (client != null)
            {
                int c = 100;
                do
                {
                    c--;
                    //Application.DoEvents();
                    Thread.Sleep(10);
                }
                while (c > 0);

                //DoServerDisconnect();

                //if (FromHost)
                //{
                //labelStatusInfo.Text = "The Server has exited";
                //}
                //else
                //{
                //labelStatusInfo.Text = "App has lost communication with the server (network issue).";
                //}


                //btn_Disconnect.Enabled = false;
                //btn_Send.Enabled = false;
                //buttonSendToClients.Enabled = false;
                //panel1.AllowDrop = false;

                //btn_Send.Enabled = true;
                //SetSomeLabelInfoFromThread("...");

                //listBox1.Items.Clear();
            }
        }

        #endregion

        #region LRC Computation
        /// <summary>
        /// The LRC (longitudinal redundancy check) is a 7 bit ASCII character computed as the
        /// Exclusive OR(XOR) (BCC) sum of all characters following
        /// the STX and including the ETX transmission control characters.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="LRC"></param>
        private void GetLRC(byte[] message, ref byte LRC)
        {
            //Return the LRC values:

            LRC = 0x00;

            for (int i = 1; i < message.Length - 1; i++)    //for (int i = 1; i < message.Length-1; i++)
            {
                LRC = (byte)(LRC ^ message[i]);
            }
            //LRC = (byte)(LRC & 0x7F);
        }
        #endregion

        #region Build Message
        public void BuildMessage(byte[] address, byte[] datafields)
        {
            /// CMD DATAFRAME = STX, ADDRESS (2 - ASCII), DATA FIELD (ASCII), ETX, LRC
            CommandDataframe = new byte[1 + 2 + datafields.Length + 1 + 1];

            // Byte to receive LRC
            byte LRC = 0;

            CommandDataframe[0] = _STX;
            CommandDataframe[1] = address[0];
            CommandDataframe[2] = address[1];

            for (int i = 0; i < datafields.Length; i++)
            {
                CommandDataframe[i + 3] = datafields[i];
            }

            CommandDataframe[CommandDataframe.Length - 2] = _ETX;
            GetLRC(CommandDataframe, ref LRC);
            CommandDataframe[CommandDataframe.Length - 1] = LRC;
        }
        #endregion

        #region Check Response
        public bool CheckResponse(byte[] response)
        {
            //Perform a basic CRC check:
            byte LRC = 0;
            GetLRC(response, ref LRC);
            if (LRC == response[response.Length - 1])      // if (LRC == response[response.Length - 1])
                return true;
            else
                return false;
        }

        #endregion

        #region Get Response
        public void GetResponse(byte[] message, int messageSize)
        {
            ResponseDataframe = new byte[messageSize];
            Array.Copy(message, ResponseDataframe, messageSize);
        }
        #endregion



        private bool ProcessResponse()
        {
            //if (CheckResponse(ResponseDataframe))
            //{
            switch (GetAcculoadCmdType)
            {
                case _CMD_TYPE.EQ:
                    //EQStatus.SetStatus(ResponseDataframe);
                    break;

                case _CMD_TYPE.RK:
                    //Passkey.SetPasskey(ResponseDataframe);
                    break;

            }
            //LibStatusString = "Read successful";
            return true;
            //}
            //else
            //{
            //    LibStatusString = "CRC error";
            //    return false;
            //}
        }

        #region Function Build Commanf Message
        private void BuildCmdMsg(_CMD_TYPE cmd_type, byte[] data = null)
        {
            //Build outgoing accuload message
            int datafields_size = 2;
            if (data != null) datafields_size += data.Length;
            byte[] datafields = new byte[datafields_size];
            byte[] cmd_type_str = Encoding.ASCII.GetBytes(cmd_type.ToString());
            datafields[0] = cmd_type_str[0];
            datafields[1] = cmd_type_str[1];

            Array.Copy(data, 0, datafields, 2, data.Length);
            BuildMessage(byteDeviceAddress, datafields);
        }
        #endregion

    }
}
