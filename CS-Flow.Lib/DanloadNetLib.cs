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


namespace CS_Flow.Lib
{
    public class DanloadNetLib
    {
        public enum _MACHINE_STATE : byte
        {
            DISCONNECTED,
            PROMPT_RECIPE_STATE,
            REQUEST_SELECTED_RECIPE_STATE,
            PROMPT_ADDITIVES_STATE,
            REQUEST_SELECTED_ADDITIVES_STATE,
            TIMEOUT_OP_STATE,
            AUTH_TRANSACTION_STATE,
            END_TRANSACTION_STATE,
            PROMPT_PRESET_VALUE_STATE,
            REQUEST_PRESET_VALUE_STATE,
            AUTH_BATCH_STATE,
            SET_DENSITIES_STATE,
            SET_TEMPERATURES_STATE,
            END_BATCH_STATE,
            START_BATCH_STATE,
            STOP_BATCH_STATE,
            BATCH_DATA_BY_COMPONENT_STATE,
            ADDITIVE_TOTALIZER_STATE,
            REQ_STAT_STATE,
            CLEAR_STATUS_STATE,
            CLEAR_STATUS_STATE_ACK,
            RST_PRM_ALARMS_STATE,
            METER_TOTALIZER_STATE,
            COMPONENT_TOTALIZER_STATE,
            UNAUTHORIZED_FLOW_STATE,
            DATA_CODE_VALUE_STATE,
            REQ_MTR_VAL_STATE,
            REQ_COMPONENT_VALUE_STATE,
            REQ_POWER_FAIL_DATE_N_TIME_STATE,
            DISPLAY_MSG_STATE,
            REQUEST_KEYPAD_DATA_STATE,
            REQUEST_TRANSACTION_STORAGE_STATUS_STATE,
            TRANSACTION_DATA_BY_COMPONENT_STATE,
            INITIALIZE_TRANSACTION_STORAGE_STATE,
            START_COMM_STATE,
            REQUEST_PROGRAM_CODE_VALUES_N_ATTR_STATE,
            SET_PROGRAM_CODE_VALUE_STATE,
            MODIFY_PROGRAM_CODE_ATTR_STATE,
            REQUEST_VALUE_CHANGED_ATTR_STATE,
            CLEAR_VALUE_CHANGED_ATTR_STATE,
            CONFIGURE_RECIPE_STATE,
            GET_DATE_N_TIME_STATE,
            SET_DATE_N_TIME_STATE,
            REQUEST_FIRMWARE_VERSIONS_STATE,
            READ_INPUT_STATE,
            WRITE_OUTPUT_STATE,
            DUART_DIAGNOSTIC_STATE,
            ARCNET_DIAGNOSTIC_STATE,
            REQUEST_CRASH_DATA_STATE,
            RST_UNIT_STATE,
            LAST_KEY_PRESSED_STATE,
            RAM_TESTS_STATE,
            SWING_ARM_SIDE_STATE,
            INSTALLED_BOARDS_STATE,
            CONFIGURE_STATE,
            WEIGHTS_N_MEASURES_SWITCH_STATE,
            CHG_OP_MODE_STATE,
            CLR_DISPLAY_STATE,
            REQUEST_STORED_TRANSACTION_STATE,
            REQUEST_STORED_BATCH_STATE,
            ENCHANCED_START_STARTCOMM_STATE,
            ENCHANCED_REQUEST_STATUS_STATE,
            REPORT_ALARM_STATE,
            RST_PRM_ALARMS_STATE_ACK,
        }
        private enum _CMD_TYPE : byte
        {
            PROMPT_RECIPE = 0x01,
            REQUEST_SELECTED_RECIPE = 0x02,
            PROMPT_ADDITIVES = 0x03,
            REQUEST_SELECTED_ADDITIVES = 0x04,
            TIMEOUT_OP = 0x05,
            AUTH_TRANSACTION = 0x06,
            END_TRANSACTION = 0x07,
            PROMPT_PRESET_VALUE = 0x08,
            REQUEST_PRESET_VALUE = 0x09,
            AUTH_BATCH = 0x0A,
            SET_DENSITIES = 0x0B,
            SET_TEMPERATURES = 0x0C,
            END_BATCH = 0x0D,
            START_BATCH = 0x0E,
            STOP_BATCH = 0x0F,
            BATCH_DATA_BY_COMPONENT = 0x10,
            ADDITIVE_TOTALIZER = 0x11,
            REQ_STAT = 0x12,
            CLEAR_STATUS = 0x13,
            RST_PRM_ALARMS = 0x14,
            METER_TOTALIZER = 0x15,
            COMPONENT_TOTALIZER = 0x16,
            UNAUTHORIZED_FLOW = 0x17,
            DATA_CODE_VALUE = 0x18,
            REQ_MTR_VAL = 0x19,
            REQ_COMPONENT_VALUE = 0x1A,
            REQ_POWER_FAIL_DATE_N_TIME = 0x1B,
            DISPLAY_MSG = 0x1C,
            REQUEST_KEYPAD_DATA = 0x1D,
            REQUEST_TRANSACTION_STORAGE_STATUS = 0x1E,
            TRANSACTION_DATA_BY_COMPONENT = 0x1F,
            INITIALIZE_TRANSACTION_STORAGE = 0x20,
            START_COMM = 0x21,
            REQUEST_PROGRAM_CODE_VALUES_N_ATTR = 0x22,
            SET_PROGRAM_CODE_VALUE = 0x23,
            MODIFY_PROGRAM_CODE_ATTR = 0x24,
            REQUEST_VALUE_CHANGED_ATTR = 0x25,
            CLEAR_VALUE_CHANGED_ATTR = 0x26,
            CONFIGURE_RECIPE = 0x27,
            GET_DATE_N_TIME = 0x28,
            SET_DATE_N_TIME = 0x29,
            REQUEST_FIRMWARE_VERSIONS = 0x2A,
            READ_INPUT = 0x2B,
            WRITE_OUTPUT = 0x2C,
            DUART_DIAGNOSTIC = 0x2D,
            ARCNET_DIAGNOSTIC = 0x2E,
            REQUEST_CRASH_DATA = 0x2F,
            RST_UNIT = 0x30,
            LAST_KEY_PRESSED = 0x31,
            RAM_TESTS = 0x32,
            SWING_ARM_SIDE = 0x33,
            INSTALLED_BOARDS = 0x34,
            CONFIGURE = 0x35,
            WEIGHTS_N_MEASURES_SWITCH = 0x36,
            CHG_OP_MODE = 0x37,
            CLR_DISPLAY = 0x38,
            REQUEST_STORED_TRANSACTION = 0x39,
            REQUEST_STORED_BATCH = 0x3A,
            ENCHANCED_START_STARTCOMM = 0x3B,
            ENCHANCED_REQUEST_STATUS = 0x3C,
            REPORT_ALARM = 0x3D,
        }

        #region Command and Response START_COMMUNICATION
        struct cmd_start_comm
        {
            public byte dfl; /* Data field length. */
            public byte cmdcode;
        }

        public class RspStartCommunication
        {
            byte[] raw;
            public RspStartCommunication(byte[] response)
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

        #region Command and Response CHANGE_OP_MODE
        private struct cmd_chg_op_mode
        {
            private byte dfl; /* Data field length. */
            private byte cmdcode;
            private byte opmode; /* Operating mode. 0=Auto, 1=Manual. */

            private cmd_chg_op_mode(byte dfl, byte cmdcode, byte opmode)
            {
                this.dfl = dfl;
                this.cmdcode = cmdcode;
                this.opmode = opmode;
            }
        }
        private struct rsp_chg_op_mode
        {
            public byte dfl; /* Data field length. */
            public byte cmdcode;
        }
        private enum _CMD_CHG_OP_MODE : byte
        {
            AUTO = 0x00,
            MANUAL = 0x01,
        }

        #endregion

        #region Command and Response Variable RST_PRM_ALARMS
        struct cmd_rst_prm_alarms
        {
            public byte dfl; /* Data field length. */
            public byte cmdcode;
            public byte alarm_byte_9; /* Alarm bits 79 thru 72. */
            public byte alarm_byte_8; /* Alarm bits 71 thru 64. */
            public byte alarm_byte_7; /* Alarm bits 63 thru 56. */
            public byte alarm_byte_6; /* Alarm bits 55 thru 48. */
            public byte alarm_byte_5; /* Alarm bits 47 thru 40. */
            public byte alarm_byte_4; /* Alarm bits 39 thru 32. */
            public byte alarm_byte_3; /* Alarm bits 31 thru 24. */
            public byte alarm_byte_2; /* Alarm bits 23 thru 16. */
            public byte alarm_byte_1; /* Alarm bits 15 thru 8. */
            public byte alarm_byte_0; /* Alarm bits 7 thru 0. */
        }
        [Flags]
        public enum ALARM_BYTE_0 : byte                         /* Alarm bits 7 thru 0. */
        {
            PRIMARY_DISPLAY_FAILURE = 0x00,
            SECONDARY_DISPLAY_FAILURE = 0x02,
            COMMS_FAILURE_CHANNEL_A = 0x04,
            COMMS_FAILURE_CHANNEL_B = 0x08,
            UNABLE_TO_MAINTAIN_BLEND = 0x10,
            FLOW_RATE_TOO_LOW_METER_1 = 0x20,
            FLOW_RATE_TOO_LOW_METER_2 = 0x40,
            FLOW_RATE_TOO_LOW_METER_3 = 0x80,
        }
        [Flags]
        public enum ALARM_BYTE_1 : byte                         /* Alarm bits 15 thru 8. */
        {
            FLOW_RATE_TOO_LOW_METER_4 = 0x00,
            FLOW_RATE_TOO_HIGH_METER_1 = 0x02,
            FLOW_RATE_TOO_HIGH_METER_2 = 0x04,
            FLOW_RATE_TOO_HIGH_METER_3 = 0x08,
            FLOW_RATE_TOO_HIGH_METER_4 = 0x10,
            VALVE_CLOSED_EARLY_METER_1 = 0x20,
            VALVE_CLOSED_EARLY_METER_2 = 0x40,
            VALVE_CLOSED_EARLY_METER_3 = 0x80,
        }
        [Flags]
        public enum ALARM_BYTE_2 : byte                        /* Alarm bits 23 thru 16. */
        {
            VALVE_CLOSED_EARLY_METER_4 = 0x00,
            TIME_OUT_NO_FLOW_DETECTED_METER_1 = 0x02,
            TIME_OUT_NO_FLOW_DETECTED_METER_2 = 0x04,
            TIME_OUT_NO_FLOW_DETECTED_METER_3 = 0x08,
            TIME_OUT_NO_FLOW_DETECTED_METER_4 = 0x10,
            UNAUTHORIZED_FLOW_EXCEEDS_LIMIT_METER_1 = 0x20,
            UNAUTHORIZED_FLOW_EXCEEDS_LIMIT_METER_2 = 0x40,
            UNAUTHORIZED_FLOW_EXCEEDS_LIMIT_METER_3 = 0x80,
        }
        [Flags]
        public enum ALARM_BYTE_3 : byte                         /* Alarm bits 31 thru 24. */
        {
            UNAUTHORIZED_FLOW_EXCEEDS_LIMIT_METER_4 = 0x00,
            PULSE_SECURITY_ERROR_METER_1 = 0x02,
            PULSE_SECURITY_ERROR_METER_2 = 0x04,
            PULSE_SECURITY_ERROR_METER_3 = 0x08,
            PULSE_SECURITY_ERROR_METER_4 = 0x10,
            TEMPERATURE_FAILURE_METER_1 = 0x20,
            TEMPERATURE_FAILURE_METER_2 = 0x40,
            TEMPERATURE_FAILURE_METER_3 = 0x80,
        }
        [Flags]
        public enum ALARM_BYTE_4 : byte                         /* Alarm bits 39 thru 32. */
        {
            TEMPERATURE_FAILURE_METER_4 = 0x00,
            PRESSURE_FAILURE_METER_1 = 0x02,
            PRESSURE_FAILURE_METER_2 = 0x04,
            PRESSURE_FAILURE_METER_3 = 0x08,
            PRESSURE_FAILURE_METER_4 = 0x10,
            UNABLE_TO_CLOSE_VALVE_METER_1 = 0x20,
            UNABLE_TO_CLOSE_VALVE_METER_2 = 0x40,
            UNABLE_TO_CLOSE_VALVE_METER_3 = 0x80,
        }
        [Flags]
        public enum ALARM_BYTE_5 : byte                         /* Alarm bits 47 thru 40. */
        {
            UNABLE_TO_CLOSE_VALVE_METER_4 = 0x00,
            DENSITY_FAILURE_COMPONENT_1 = 0x02,
            DENSITY_FAILURE_COMPONENT_2 = 0x04,
            DENSITY_FAILURE_COMPONENT_3 = 0x08,
            DENSITY_FAILURE_COMPONENT_4 = 0x10,
            COMPONENT_1_BLOCK_VALVE_NOT_CLOSED = 0x20,
            COMPONENT_2_BLOCK_VALVE_NOT_CLOSED = 0x40,
            COMPONENT_3_BLOCK_VALVE_NOT_CLOSED = 0x80,
        }
        [Flags]
        public enum ALARM_BYTE_6 : byte                         /* Alarm bits 55 thru 48. */
        {
            COMPONENT_4_BLOCK_VALVE_NOT_CLOSED = 0x00,
            ADDITIVE_1_FAILURE = 0x02,
            ADDITIVE_2_FAILURE = 0x04,
            ADDITIVE_3_FAILURE = 0x08,
            ADDITIVE_4_FAILURE = 0x10,
            ADDITIVE_5_FAILURE = 0x20,
            ADDITIVE_6_FAILURE = 0x40,
            SAFETY_CIRCUIT_1 = 0x80,
        }
        [Flags]
        public enum ALARM_BYTE_7 : byte                       /* Alarm bits 63 thru 56. */
        {
            SAFETY_CIRCUIT_2 = 0x00,
            SAFETY_CIRCUIT_3 = 0x02,
            SAFETY_CIRCUIT_4 = 0x04,
            SAFETY_CIRCUIT_5 = 0x08,
            SAFETY_CIRCUIT_6 = 0x10,
            SAFETY_CIRCUIT_7 = 0x20,
            SAFETY_CIRCUIT_8 = 0x40,
            DATA_LOGGING_MEMORY_FULL = 0x80,
        }
        [Flags]
        public enum ALARM_BYTE_8 : byte                       /* Alarm bits 71 thru 64. */
        {
            MEMORY_CHECK_FAILURE = 0x00,
            STORAGE_MEMORY_FULL = 0x02,
            POWER_FAILURE = 0x04,
            UNABLE_TO_RAMP_DOWN = 0x08,
            MPMC_1_FAILURE = 0x10,
            MPMC_2_FAILURE = 0x20,
            CALIBRATION_FAILURE_METER_1 = 0x40,
            CALIBRATION_FAILURE_METER_2 = 0x80,
        }
        [Flags]
        public enum ALARM_BYTE_9 : byte                       /* Alarm bits 79 thru 72. */
        {
            CALIBRATION_FAILURE_METER_3 = 0x00,
            CALIBRATION_FAILURE_METER_4 = 0x02,
            INTERMEDIATE_LEVEL_INPUT = 0x04,
        }

        struct rsp_rst_prm_alarms
        {
            public byte dfl; /* Data field length. */
            public byte cmdcode;
        }
        #endregion

        #region Command and Response TIME_OUT OP STATE
        public class RspTimeout
        {
            byte[] raw;
            public RspTimeout(byte[] response)
            {
                raw = new byte[response.Length];
                Array.Copy(response, raw, response.Length);
            }
        }

        struct cmd_timeout_op
        {
            public byte dfl; /* Data field length. */
            public byte cmdcode;
        }
        struct rsp_timeout_op
        {
            public byte dfl; /* Data field length. */
            public byte cmdcode;
        }

        #endregion

        #region Command and Response CLR_DISPLAY_STATE
        public class RspClrDisplayState
        {
            byte[] raw;
            public RspClrDisplayState(byte[] response)
            {
                raw = new byte[response.Length];
                Array.Copy(response, raw, response.Length);
            }
        }

        struct cmd_clr_display
        {
            public byte dfl; /* Data field length. */
            public byte cmdcode;
        }
        struct rsp_clr_display
        {
            public byte dfl; /* Data field length. */
            public byte cmdcode;
        }
        #endregion

        #region Command and Response DISPLAY_MESSAGE
        public class RspDisplayMessage
        {
            byte[] raw;
            public RspDisplayMessage(byte[] response)
            {
                raw = new byte[response.Length];
                Array.Copy(response, raw, response.Length);
            }
        }

        struct cmd_display_msg
        {
            public byte dfl; /* Data field length. */
            public byte cmdcode;
            public Int16 pmptfw; /* Prompt field width (0->8). pmptfw < 0 => 0. pmptfw > 8 => 8. */
            public byte inpctl; /* Input control. */
            public Int16 timout; /* Time-out # seconds. */
        }
        struct rsp_display_msg
        {
            public byte dfl; /* Data field length. */
            public byte cmdcode;
        }
        #endregion

        #region Command and Response Keypad

        struct cmd_req_keypad
        {
            public byte dfl; /* Data field length. */
            public byte cmdcode;
        }
        struct rsp_req_keypad
        {
            public byte dfl; /* Data field length. */
            public byte cmdcode;
            Int32 keypad_data;
        }

        public class RspKeypad
        {
            byte[] raw;

            public RspKeypad(byte[] response)
            {
                raw = new byte[response.Length];
                Array.Copy(response, raw, response.Length);
            }

            public int KeypadInput { get { return BitConverter.ToInt32(raw, 2 + 2); } }
        }

        #endregion

        #region Command and Response Request Status
        struct cmd_req_stat
        {
            public byte dfl; /* Data field length. */
            public byte cmdcode;
        }

        public class RspRequestStatus
        {
            byte[] raw;
            public RspRequestStatus(byte[] response)
            {
                raw = new byte[response.Length];
                Array.Copy(response, raw, response.Length);
            }
            public int Status { get { return BitConverter.ToInt32(raw, 2 + 2); } }
            public char Side { get { return BitConverter.ToChar(raw, 2 + 4); } }
            public int Grsvol { get { return BitConverter.ToInt32(raw, 2 + 5); } }
            public int Netvol { get { return BitConverter.ToInt32(raw, 2 + 7); } }
            public char Safety { get { return BitConverter.ToChar(raw, 2 + 13); } }
            public char Almcd { get { return BitConverter.ToChar(raw, 2 + 14); } }

            public char Alarm_Byte_9 { get { return BitConverter.ToChar(raw, 2 + 15); } }
            public char Alarm_Byte_8 { get { return BitConverter.ToChar(raw, 2 + 16); } }
            public char Alarm_Byte_7 { get { return BitConverter.ToChar(raw, 2 + 17); } }
            public char Alarm_Byte_6 { get { return BitConverter.ToChar(raw, 2 + 18); } }
            public char Alarm_Byte_5 { get { return BitConverter.ToChar(raw, 2 + 19); } }
            public char Alarm_Byte_4 { get { return BitConverter.ToChar(raw, 2 + 20); } }
            public char Alarm_Byte_3 { get { return BitConverter.ToChar(raw, 2 + 21); } }
            public char Alarm_Byte_2 { get { return BitConverter.ToChar(raw, 2 + 22); } }
            public char Alarm_Byte_1 { get { return BitConverter.ToChar(raw, 2 + 23); } }
            public char Alarm_Byte_0 { get { return BitConverter.ToChar(raw, 2 + 24); } }

            public String PrintAlarm0()
            {
                ALARM_BYTE_0 alarm = (ALARM_BYTE_0)Alarm_Byte_0;
                return alarm.ToString();
            }
            public String PrintAlarm1()
            {
                ALARM_BYTE_1 alarm = (ALARM_BYTE_1)Alarm_Byte_1;
                return alarm.ToString();
            }
            public String PrintAlarm2()
            {
                ALARM_BYTE_2 alarm = (ALARM_BYTE_2)Alarm_Byte_2;
                return alarm.ToString();
            }
            public String PrintAlarm3()
            {
                ALARM_BYTE_3 alarm = (ALARM_BYTE_3)Alarm_Byte_3;
                return alarm.ToString();
            }
            public String PrintAlarm4()
            {
                ALARM_BYTE_4 alarm = (ALARM_BYTE_4)Alarm_Byte_4;
                return alarm.ToString();
            }
            public String PrintAlarm5()
            {
                ALARM_BYTE_5 alarm = (ALARM_BYTE_5)Alarm_Byte_5;
                return alarm.ToString();
            }
            public String PrintAlarm6()
            {
                ALARM_BYTE_6 alarm = (ALARM_BYTE_6)Alarm_Byte_6;
                return alarm.ToString();
            }
            public String PrintAlarm7()
            {
                ALARM_BYTE_7 alarm = (ALARM_BYTE_7)Alarm_Byte_7;
                return alarm.ToString();
            }
            public String PrintAlarm8()
            {
                ALARM_BYTE_8 alarm = (ALARM_BYTE_8)Alarm_Byte_8;
                return alarm.ToString();
            }
            public String PrintAlarm9()
            {
                ALARM_BYTE_9 alarm = (ALARM_BYTE_9)Alarm_Byte_9;
                return alarm.ToString();
            }

            public bool PRIMARY_DISPLAY_FAILURE_ALARM()
            {
                ALARM_BYTE_0 alarm = (ALARM_BYTE_0)Alarm_Byte_0;
                if (alarm.HasFlag(ALARM_BYTE_0.PRIMARY_DISPLAY_FAILURE))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool SECONDARY_DISPLAY_FAILURE_ALARM()
            {
                ALARM_BYTE_0 alarm = (ALARM_BYTE_0)Alarm_Byte_0;
                if (alarm.HasFlag(ALARM_BYTE_0.SECONDARY_DISPLAY_FAILURE))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool COMMS_FAILURE_CHANNEL_A_ALARM()
            {
                ALARM_BYTE_0 alarm = (ALARM_BYTE_0)Alarm_Byte_0;
                if (alarm.HasFlag(ALARM_BYTE_0.COMMS_FAILURE_CHANNEL_A))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool COMMS_FAILURE_CHANNEL_B_ALARM()
            {
                ALARM_BYTE_0 alarm = (ALARM_BYTE_0)Alarm_Byte_0;
                if (alarm.HasFlag(ALARM_BYTE_0.COMMS_FAILURE_CHANNEL_B))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool UNABLE_TO_MAINTAIN_BLEND_ALARM()
            {
                ALARM_BYTE_0 alarm = (ALARM_BYTE_0)Alarm_Byte_0;
                if (alarm.HasFlag(ALARM_BYTE_0.UNABLE_TO_MAINTAIN_BLEND))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool FLOW_RATE_TOO_LOW_METER_1_ALARM()
            {
                ALARM_BYTE_0 alarm = (ALARM_BYTE_0)Alarm_Byte_0;
                if (alarm.HasFlag(ALARM_BYTE_0.FLOW_RATE_TOO_LOW_METER_1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool FLOW_RATE_TOO_LOW_METER_2_ALARM()
            {
                ALARM_BYTE_0 alarm = (ALARM_BYTE_0)Alarm_Byte_0;
                if (alarm.HasFlag(ALARM_BYTE_0.FLOW_RATE_TOO_LOW_METER_2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool FLOW_RATE_TOO_LOW_METER_3_ALARM()
            {
                ALARM_BYTE_0 alarm = (ALARM_BYTE_0)Alarm_Byte_0;
                if (alarm.HasFlag(ALARM_BYTE_0.FLOW_RATE_TOO_LOW_METER_3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


            public bool FLOW_RATE_TOO_LOW_METER_4_ALARM()
            {
                ALARM_BYTE_1 alarm = (ALARM_BYTE_1)Alarm_Byte_1;
                if (alarm.HasFlag(ALARM_BYTE_1.FLOW_RATE_TOO_LOW_METER_4))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool FLOW_RATE_TOO_HIGH_METER_1_ALARM()
            {
                ALARM_BYTE_1 alarm = (ALARM_BYTE_1)Alarm_Byte_1;
                if (alarm.HasFlag(ALARM_BYTE_1.FLOW_RATE_TOO_HIGH_METER_1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool FLOW_RATE_TOO_HIGH_METER_2_ALARM()
            {
                ALARM_BYTE_1 alarm = (ALARM_BYTE_1)Alarm_Byte_1;
                if (alarm.HasFlag(ALARM_BYTE_1.FLOW_RATE_TOO_HIGH_METER_2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool FLOW_RATE_TOO_HIGH_METER_3_ALARM()
            {
                ALARM_BYTE_1 alarm = (ALARM_BYTE_1)Alarm_Byte_1;
                if (alarm.HasFlag(ALARM_BYTE_1.FLOW_RATE_TOO_HIGH_METER_3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool FLOW_RATE_TOO_HIGH_METER_4_ALARM()
            {
                ALARM_BYTE_1 alarm = (ALARM_BYTE_1)Alarm_Byte_1;
                if (alarm.HasFlag(ALARM_BYTE_1.FLOW_RATE_TOO_HIGH_METER_4))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool VALVE_CLOSED_EARLY_METER_1_ALARM()
            {
                ALARM_BYTE_1 alarm = (ALARM_BYTE_1)Alarm_Byte_1;
                if (alarm.HasFlag(ALARM_BYTE_1.VALVE_CLOSED_EARLY_METER_1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool VALVE_CLOSED_EARLY_METER_2_ALARM()
            {
                ALARM_BYTE_1 alarm = (ALARM_BYTE_1)Alarm_Byte_1;
                if (alarm.HasFlag(ALARM_BYTE_1.VALVE_CLOSED_EARLY_METER_2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool VALVE_CLOSED_EARLY_METER_3_ALARM()
            {
                ALARM_BYTE_1 alarm = (ALARM_BYTE_1)Alarm_Byte_1;
                if (alarm.HasFlag(ALARM_BYTE_1.VALVE_CLOSED_EARLY_METER_3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


            public bool VALVE_CLOSED_EARLY_METER_4_ALARM()
            {
                ALARM_BYTE_2 alarm = (ALARM_BYTE_2)Alarm_Byte_2;
                if (alarm.HasFlag(ALARM_BYTE_2.VALVE_CLOSED_EARLY_METER_4))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool TIME_OUT_NO_FLOW_DETECTED_METER_1_ALARM()
            {
                ALARM_BYTE_2 alarm = (ALARM_BYTE_2)Alarm_Byte_2;
                if (alarm.HasFlag(ALARM_BYTE_2.TIME_OUT_NO_FLOW_DETECTED_METER_1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool TIME_OUT_NO_FLOW_DETECTED_METER_2_ALARM()
            {
                ALARM_BYTE_2 alarm = (ALARM_BYTE_2)Alarm_Byte_2;
                if (alarm.HasFlag(ALARM_BYTE_2.TIME_OUT_NO_FLOW_DETECTED_METER_2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool TIME_OUT_NO_FLOW_DETECTED_METER_3_ALARM()
            {
                ALARM_BYTE_2 alarm = (ALARM_BYTE_2)Alarm_Byte_2;
                if (alarm.HasFlag(ALARM_BYTE_2.TIME_OUT_NO_FLOW_DETECTED_METER_3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool TIME_OUT_NO_FLOW_DETECTED_METER_4_ALARM()
            {
                ALARM_BYTE_2 alarm = (ALARM_BYTE_2)Alarm_Byte_2;
                if (alarm.HasFlag(ALARM_BYTE_2.TIME_OUT_NO_FLOW_DETECTED_METER_4))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool UNAUTHORIZED_FLOW_EXCEEDS_LIMIT_METER_1_ALARM()
            {
                ALARM_BYTE_2 alarm = (ALARM_BYTE_2)Alarm_Byte_2;
                if (alarm.HasFlag(ALARM_BYTE_2.UNAUTHORIZED_FLOW_EXCEEDS_LIMIT_METER_1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool UNAUTHORIZED_FLOW_EXCEEDS_LIMIT_METER_2_ALARM()
            {
                ALARM_BYTE_2 alarm = (ALARM_BYTE_2)Alarm_Byte_2;
                if (alarm.HasFlag(ALARM_BYTE_2.UNAUTHORIZED_FLOW_EXCEEDS_LIMIT_METER_2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool UNAUTHORIZED_FLOW_EXCEEDS_LIMIT_METER_3_ALARM()
            {
                ALARM_BYTE_2 alarm = (ALARM_BYTE_2)Alarm_Byte_2;
                if (alarm.HasFlag(ALARM_BYTE_2.UNAUTHORIZED_FLOW_EXCEEDS_LIMIT_METER_3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


            public bool UNAUTHORIZED_FLOW_EXCEEDS_LIMIT_METER_4_ALARM()
            {
                ALARM_BYTE_3 alarm = (ALARM_BYTE_3)Alarm_Byte_3;
                if (alarm.HasFlag(ALARM_BYTE_3.UNAUTHORIZED_FLOW_EXCEEDS_LIMIT_METER_4))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool PULSE_SECURITY_ERROR_METER_1_ALARM()
            {
                ALARM_BYTE_3 alarm = (ALARM_BYTE_3)Alarm_Byte_3;
                if (alarm.HasFlag(ALARM_BYTE_3.PULSE_SECURITY_ERROR_METER_1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool PULSE_SECURITY_ERROR_METER_2_ALARM()
            {
                ALARM_BYTE_3 alarm = (ALARM_BYTE_3)Alarm_Byte_3;
                if (alarm.HasFlag(ALARM_BYTE_3.PULSE_SECURITY_ERROR_METER_2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool PULSE_SECURITY_ERROR_METER_3_ALARM()
            {
                ALARM_BYTE_3 alarm = (ALARM_BYTE_3)Alarm_Byte_3;
                if (alarm.HasFlag(ALARM_BYTE_3.PULSE_SECURITY_ERROR_METER_3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool PULSE_SECURITY_ERROR_METER_4_ALARM()
            {
                ALARM_BYTE_3 alarm = (ALARM_BYTE_3)Alarm_Byte_3;
                if (alarm.HasFlag(ALARM_BYTE_3.PULSE_SECURITY_ERROR_METER_4))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool TEMPERATURE_FAILURE_METER_1_ALARM()
            {
                ALARM_BYTE_3 alarm = (ALARM_BYTE_3)Alarm_Byte_3;
                if (alarm.HasFlag(ALARM_BYTE_3.TEMPERATURE_FAILURE_METER_1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool TEMPERATURE_FAILURE_METER_2_ALARM()
            {
                ALARM_BYTE_3 alarm = (ALARM_BYTE_3)Alarm_Byte_3;
                if (alarm.HasFlag(ALARM_BYTE_3.TEMPERATURE_FAILURE_METER_2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool TEMPERATURE_FAILURE_METER_3_ALARM()
            {
                ALARM_BYTE_3 alarm = (ALARM_BYTE_3)Alarm_Byte_3;
                if (alarm.HasFlag(ALARM_BYTE_3.TEMPERATURE_FAILURE_METER_3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool TEMPERATURE_FAILURE_METER_4_ALARM()
            {
                ALARM_BYTE_4 alarm = (ALARM_BYTE_4)Alarm_Byte_4;
                if (alarm.HasFlag(ALARM_BYTE_4.TEMPERATURE_FAILURE_METER_4))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool PRESSURE_FAILURE_METER_1_ALARM()
            {
                ALARM_BYTE_4 alarm = (ALARM_BYTE_4)Alarm_Byte_4;
                if (alarm.HasFlag(ALARM_BYTE_4.PRESSURE_FAILURE_METER_1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool PRESSURE_FAILURE_METER_2_ALARM()
            {
                ALARM_BYTE_4 alarm = (ALARM_BYTE_4)Alarm_Byte_4;
                if (alarm.HasFlag(ALARM_BYTE_4.PRESSURE_FAILURE_METER_2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool PRESSURE_FAILURE_METER_3_ALARM()
            {
                ALARM_BYTE_4 alarm = (ALARM_BYTE_4)Alarm_Byte_4;
                if (alarm.HasFlag(ALARM_BYTE_4.PRESSURE_FAILURE_METER_3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool PRESSURE_FAILURE_METER_4_ALARM()
            {
                ALARM_BYTE_4 alarm = (ALARM_BYTE_4)Alarm_Byte_4;
                if (alarm.HasFlag(ALARM_BYTE_4.PRESSURE_FAILURE_METER_4))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool UNABLE_TO_CLOSE_VALVE_METER_1_ALARM()
            {
                ALARM_BYTE_4 alarm = (ALARM_BYTE_4)Alarm_Byte_4;
                if (alarm.HasFlag(ALARM_BYTE_4.UNABLE_TO_CLOSE_VALVE_METER_1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool UNABLE_TO_CLOSE_VALVE_METER_2_ALARM()
            {
                ALARM_BYTE_4 alarm = (ALARM_BYTE_4)Alarm_Byte_4;
                if (alarm.HasFlag(ALARM_BYTE_4.UNABLE_TO_CLOSE_VALVE_METER_2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool UNABLE_TO_CLOSE_VALVE_METER_3_ALARM()
            {
                ALARM_BYTE_4 alarm = (ALARM_BYTE_4)Alarm_Byte_4;
                if (alarm.HasFlag(ALARM_BYTE_4.UNABLE_TO_CLOSE_VALVE_METER_3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool UNABLE_TO_CLOSE_VALVE_METER_4_ALARM()
            {
                ALARM_BYTE_5 alarm = (ALARM_BYTE_5)Alarm_Byte_5;
                if (alarm.HasFlag(ALARM_BYTE_5.UNABLE_TO_CLOSE_VALVE_METER_4))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool DENSITY_FAILURE_COMPONENT_1_ALARM()
            {
                ALARM_BYTE_5 alarm = (ALARM_BYTE_5)Alarm_Byte_5;
                if (alarm.HasFlag(ALARM_BYTE_5.DENSITY_FAILURE_COMPONENT_1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool DENSITY_FAILURE_COMPONENT_2_ALARM()
            {
                ALARM_BYTE_5 alarm = (ALARM_BYTE_5)Alarm_Byte_5;
                if (alarm.HasFlag(ALARM_BYTE_5.DENSITY_FAILURE_COMPONENT_2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool DENSITY_FAILURE_COMPONENT_3_ALARM()
            {
                ALARM_BYTE_5 alarm = (ALARM_BYTE_5)Alarm_Byte_5;
                if (alarm.HasFlag(ALARM_BYTE_5.DENSITY_FAILURE_COMPONENT_3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool DENSITY_FAILURE_COMPONENT_4_ALARM()
            {
                ALARM_BYTE_5 alarm = (ALARM_BYTE_5)Alarm_Byte_5;
                if (alarm.HasFlag(ALARM_BYTE_5.DENSITY_FAILURE_COMPONENT_4))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool COMPONENT_1_BLOCK_VALVE_NOT_CLOSED_ALARM()
            {
                ALARM_BYTE_5 alarm = (ALARM_BYTE_5)Alarm_Byte_5;
                if (alarm.HasFlag(ALARM_BYTE_5.COMPONENT_1_BLOCK_VALVE_NOT_CLOSED))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool COMPONENT_2_BLOCK_VALVE_NOT_CLOSED_ALARM()
            {
                ALARM_BYTE_5 alarm = (ALARM_BYTE_5)Alarm_Byte_5;
                if (alarm.HasFlag(ALARM_BYTE_5.COMPONENT_2_BLOCK_VALVE_NOT_CLOSED))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool COMPONENT_3_BLOCK_VALVE_NOT_CLOSED_ALARM()
            {
                ALARM_BYTE_5 alarm = (ALARM_BYTE_5)Alarm_Byte_5;
                if (alarm.HasFlag(ALARM_BYTE_5.COMPONENT_3_BLOCK_VALVE_NOT_CLOSED))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool COMPONENT_4_BLOCK_VALVE_NOT_CLOSED_ALARM()
            {
                ALARM_BYTE_6 alarm = (ALARM_BYTE_6)Alarm_Byte_6;
                if (alarm.HasFlag(ALARM_BYTE_6.COMPONENT_4_BLOCK_VALVE_NOT_CLOSED))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool ADDITIVE_1_FAILURE_ALARM()
            {
                ALARM_BYTE_6 alarm = (ALARM_BYTE_6)Alarm_Byte_6;
                if (alarm.HasFlag(ALARM_BYTE_6.ADDITIVE_1_FAILURE))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool ADDITIVE_2_FAILURE_ALARM()
            {
                ALARM_BYTE_6 alarm = (ALARM_BYTE_6)Alarm_Byte_6;
                if (alarm.HasFlag(ALARM_BYTE_6.ADDITIVE_2_FAILURE))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool ADDITIVE_3_FAILURE_ALARM()
            {
                ALARM_BYTE_6 alarm = (ALARM_BYTE_6)Alarm_Byte_6;
                if (alarm.HasFlag(ALARM_BYTE_6.ADDITIVE_3_FAILURE))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool ADDITIVE_4_FAILURE_ALARM()
            {
                ALARM_BYTE_6 alarm = (ALARM_BYTE_6)Alarm_Byte_6;
                if (alarm.HasFlag(ALARM_BYTE_6.ADDITIVE_4_FAILURE))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool ADDITIVE_5_FAILURE_ALARM()
            {
                ALARM_BYTE_6 alarm = (ALARM_BYTE_6)Alarm_Byte_6;
                if (alarm.HasFlag(ALARM_BYTE_6.ADDITIVE_5_FAILURE))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool ADDITIVE_6_FAILURE_ALARM()
            {
                ALARM_BYTE_6 alarm = (ALARM_BYTE_6)Alarm_Byte_6;
                if (alarm.HasFlag(ALARM_BYTE_6.ADDITIVE_6_FAILURE))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool SAFETY_CIRCUIT_1_ALARM()
            {
                ALARM_BYTE_6 alarm = (ALARM_BYTE_6)Alarm_Byte_6;
                if (alarm.HasFlag(ALARM_BYTE_6.SAFETY_CIRCUIT_1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


            public bool SAFETY_CIRCUIT_2_ALARM()
            {
                ALARM_BYTE_7 alarm = (ALARM_BYTE_7)Alarm_Byte_7;
                if (alarm.HasFlag(ALARM_BYTE_7.SAFETY_CIRCUIT_2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool SAFETY_CIRCUIT_3_ALARM()
            {
                ALARM_BYTE_7 alarm = (ALARM_BYTE_7)Alarm_Byte_7;
                if (alarm.HasFlag(ALARM_BYTE_7.SAFETY_CIRCUIT_3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool SAFETY_CIRCUIT_4_ALARM()
            {
                ALARM_BYTE_7 alarm = (ALARM_BYTE_7)Alarm_Byte_7;
                if (alarm.HasFlag(ALARM_BYTE_7.SAFETY_CIRCUIT_4))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool SAFETY_CIRCUIT_5_ALARM()
            {
                ALARM_BYTE_7 alarm = (ALARM_BYTE_7)Alarm_Byte_7;
                if (alarm.HasFlag(ALARM_BYTE_7.SAFETY_CIRCUIT_5))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool SAFETY_CIRCUIT_6_ALARM()
            {
                ALARM_BYTE_7 alarm = (ALARM_BYTE_7)Alarm_Byte_7;
                if (alarm.HasFlag(ALARM_BYTE_7.SAFETY_CIRCUIT_6))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool SAFETY_CIRCUIT_7_ALARM()
            {
                ALARM_BYTE_7 alarm = (ALARM_BYTE_7)Alarm_Byte_7;
                if (alarm.HasFlag(ALARM_BYTE_7.SAFETY_CIRCUIT_7))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool SAFETY_CIRCUIT_8_ALARM()
            {
                ALARM_BYTE_7 alarm = (ALARM_BYTE_7)Alarm_Byte_7;
                if (alarm.HasFlag(ALARM_BYTE_7.SAFETY_CIRCUIT_8))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool DATA_LOGGING_MEMORY_FULL_ALARM()
            {
                ALARM_BYTE_7 alarm = (ALARM_BYTE_7)Alarm_Byte_7;
                if (alarm.HasFlag(ALARM_BYTE_7.DATA_LOGGING_MEMORY_FULL))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


            public bool STORAGE_MEMORY_FULL_ALARM()
            {
                ALARM_BYTE_8 alarm = (ALARM_BYTE_8)Alarm_Byte_8;
                if (alarm.HasFlag(ALARM_BYTE_8.STORAGE_MEMORY_FULL))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool POWER_FAILURE_ALARM()
            {
                ALARM_BYTE_8 alarm = (ALARM_BYTE_8)Alarm_Byte_8;
                if (alarm.HasFlag(ALARM_BYTE_8.STORAGE_MEMORY_FULL))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool UNABLE_TO_RAMP_DOWN_ALARM()
            {
                ALARM_BYTE_8 alarm = (ALARM_BYTE_8)Alarm_Byte_8;
                if (alarm.HasFlag(ALARM_BYTE_8.UNABLE_TO_RAMP_DOWN))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool MPMC_1_FAILURE_ALARM()
            {
                ALARM_BYTE_8 alarm = (ALARM_BYTE_8)Alarm_Byte_8;
                if (alarm.HasFlag(ALARM_BYTE_8.MPMC_1_FAILURE))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool MPMC_2_FAILURE_ALARM()
            {
                ALARM_BYTE_8 alarm = (ALARM_BYTE_8)Alarm_Byte_8;
                if (alarm.HasFlag(ALARM_BYTE_8.MPMC_2_FAILURE))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool CALIBRATION_FAILURE_METER_1_ALARM()
            {
                ALARM_BYTE_8 alarm = (ALARM_BYTE_8)Alarm_Byte_8;
                if (alarm.HasFlag(ALARM_BYTE_8.CALIBRATION_FAILURE_METER_1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool CALIBRATION_FAILURE_METER_2_ALARM()
            {
                ALARM_BYTE_8 alarm = (ALARM_BYTE_8)Alarm_Byte_8;
                if (alarm.HasFlag(ALARM_BYTE_8.CALIBRATION_FAILURE_METER_2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


            public bool CALIBRATION_FAILURE_METER_3_ALARM()
            {
                ALARM_BYTE_9 alarm = (ALARM_BYTE_9)Alarm_Byte_9;
                if (alarm.HasFlag(ALARM_BYTE_9.CALIBRATION_FAILURE_METER_3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool CALIBRATION_FAILURE_METER_4_ALARM()
            {
                ALARM_BYTE_9 alarm = (ALARM_BYTE_9)Alarm_Byte_9;
                if (alarm.HasFlag(ALARM_BYTE_9.CALIBRATION_FAILURE_METER_4))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool INTERMEDIATE_LEVEL_INPUT_ALARM()
            {
                ALARM_BYTE_9 alarm = (ALARM_BYTE_9)Alarm_Byte_9;
                if (alarm.HasFlag(ALARM_BYTE_9.INTERMEDIATE_LEVEL_INPUT))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


            [Flags]
            public enum _STATUS_FLAG
            {
                OP_MODE_MANUAL = 0x00000000,
                PRIMARY_ALARM = 0x00000002,
                PASSCODE_ENTRY_IN_PROGRESS = 0x00000004,
                OP_TIMED_OUT = 0x00000008,
                RECIPE_SELECTED = 0x00000010,
                ADDITIVES_SELECTED = 0x00000020,
                PRESET_VOL_ENTERED = 0x00000040,
                KEYPAD_DATA_AVAIL = 0x00000080,
                PROG_CODE_VAL_CHANGED = 0x00000100,
                TRANSACTION_IN_PROGRESS = 0x00000200,
                BATCH_IN_PROGRESS = 0x00000400,
                KEY_PRESSED = 0x00000800,
                TRANSACTION_ENDED = 0x00001000,
                BATCH_ENDED = 0x00002000,
                BATCH_ABORTED = 0x00004000,
                INTERMEDIATE_LVL_INPUT_ALARM_STOPPED_BATCH = 0x00008000,
                RESERVED_1 = 0x00010000,
                BATCH_AUTHORIZED = 0x00020000,
                TRANSACTION_AUTHORIZED = 0x00040000,
                TRANSACTION_END_REQUESTED = 0x00080000,
                KEYPAD_DISP_LOCKED_OUT_TO_AUTO = 0x00100000,
                BATCH_STOPPED_RESUMABLE = 0x00200000,
                PROGRAM_MODE = 0x00400000,
                FLOWING = 0x00800000,
            }
            public String PrintStatus()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)Status;
                return stat.ToString();
            }
            public bool OperatingModeIsManual()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)Status;
                if (stat.HasFlag(_STATUS_FLAG.OP_MODE_MANUAL))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool PrimaryAlarm()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)Status;
                if (stat.HasFlag(_STATUS_FLAG.PRIMARY_ALARM))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool PasscodeEntryInProgress()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)Status;
                if (stat.HasFlag(_STATUS_FLAG.PASSCODE_ENTRY_IN_PROGRESS))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool OperationTimedOut()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)Status;
                if (stat.HasFlag(_STATUS_FLAG.OP_TIMED_OUT))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool RecipeSelected()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)Status;
                if (stat.HasFlag(_STATUS_FLAG.RECIPE_SELECTED))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool AdditivesSelected()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)Status;
                if (stat.HasFlag(_STATUS_FLAG.ADDITIVES_SELECTED))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool PresetVolumeEntered()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)Status;
                if (stat.HasFlag(_STATUS_FLAG.PRESET_VOL_ENTERED))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool KeypadDataAvailable()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)Status;
                if (stat.HasFlag(_STATUS_FLAG.KEYPAD_DATA_AVAIL))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool ProgramCodeValue()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)Status;
                if (stat.HasFlag(_STATUS_FLAG.PROG_CODE_VAL_CHANGED))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool TransactionInProgress()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)Status;
                if (stat.HasFlag(_STATUS_FLAG.TRANSACTION_IN_PROGRESS))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool BatchInProgress()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)Status;
                if (stat.HasFlag(_STATUS_FLAG.BATCH_IN_PROGRESS))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool KeyPressed()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)Status;
                if (stat.HasFlag(_STATUS_FLAG.KEY_PRESSED))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool TransactionEnded()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)Status;
                if (stat.HasFlag(_STATUS_FLAG.TRANSACTION_ENDED))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool BatchEnded()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)Status;
                if (stat.HasFlag(_STATUS_FLAG.BATCH_ENDED))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool BatchAborted()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)Status;
                if (stat.HasFlag(_STATUS_FLAG.BATCH_ABORTED))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool IntermediateLevelInputAlarmStoppedBatch()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)Status;
                if (stat.HasFlag(_STATUS_FLAG.INTERMEDIATE_LVL_INPUT_ALARM_STOPPED_BATCH))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool BatchAuthorized()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)Status;
                if (stat.HasFlag(_STATUS_FLAG.BATCH_AUTHORIZED))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool TransactionAuthorized()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)Status;
                if (stat.HasFlag(_STATUS_FLAG.TRANSACTION_AUTHORIZED))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool TransactionEndRequested()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)Status;
                if (stat.HasFlag(_STATUS_FLAG.TRANSACTION_END_REQUESTED))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool KeypadAndDisplayLockedOutToAutomationSystem()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)Status;
                if (stat.HasFlag(_STATUS_FLAG.KEYPAD_DISP_LOCKED_OUT_TO_AUTO))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool BatchStopped()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)Status;
                if (stat.HasFlag(_STATUS_FLAG.BATCH_STOPPED_RESUMABLE))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool ProgramMode()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)Status;
                if (stat.HasFlag(_STATUS_FLAG.PROGRAM_MODE))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool Flowing()
            {
                _STATUS_FLAG stat = (_STATUS_FLAG)Status;
                if (stat.HasFlag(_STATUS_FLAG.FLOWING))
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

        #region Command and Response Meter Value
        struct cmd_req_mtr_val
        {
            public byte dfl; /* Data field length. */
            public byte cmdcode;
            public Int16 mtrnum; /* Meter number (1->4). */
        }

        public class RspMeterValue
        {
            public byte[] raw;
            public RspMeterValue(byte[] response)
            {
                raw = new byte[response.Length];
                Array.Copy(response, raw, response.Length);
            }
            public int rawLength { get { return raw.Length; } }
            public int MeterNumber { get { return BitConverter.ToInt16(raw, 2 + 2); } }
            public int GrossTotal { get { return BitConverter.ToInt32(raw, 2 + 4); } }
            public int NetTotal { get { return BitConverter.ToInt32(raw, 2 + 8); } }
            public int Grs { get { return BitConverter.ToInt32(raw, 2 + 12); } }
            public int Net { get { return BitConverter.ToInt32(raw, 2 + 16); } }
            public int Rate3 { get { return BitConverter.ToInt32(raw, 2 + 20); } }
            public int Rate5 { get { return BitConverter.ToInt32(raw, 2 + 24); } }
            public int Rate4 { get { return BitConverter.ToInt32(raw, 2 + 28); } }
            public int Mtrfac { get { return BitConverter.ToInt32(raw, 2 + 32); } }
            public int Plscnt { get { return BitConverter.ToInt16(raw, 2 + 36); } }
            public int Numfacts { get { return BitConverter.ToInt16(raw, 2 + 38); } }
            //public struct pls
            //{
            public int pls2 { get { return BitConverter.ToInt32(raw, 2 + 40); } }
            //}

            public int ufg10 { get { return BitConverter.ToInt32(raw, 2 + 44); } }
            public int ufn10 { get { return BitConverter.ToInt16(raw, 2 + 48); } }
            public int temp { get { return BitConverter.ToInt16(raw, 2 + 52); } }
            public int dens { get { return BitConverter.ToInt32(raw, 2 + 54); } }
            public int pres { get { return BitConverter.ToInt32(raw, 2 + 58); } }
        }
        #endregion

        #region Command and Response Auth Batch

        #endregion

        #region Command and Response Dataframe and Constant Definitions
        // Frame format: <ADR> <FN> <Data Field 1> .. <Data Field n> <CRC1><CRC2> CRC-16 (MODBUS)
        // Data Field 1 = Length of message
        struct cmd_init_trans_stor
        {
            public byte dfl; /* Data field length. */
            public byte cmdcode;
        }
        struct rsp_init_trans_stor
        {
            public byte dfl; /* Data field length. */
            public byte cmdcode;
        }
        struct cmd_auth_transaction
        {
            public byte dfl; /* Data field length. */
            public byte cmdcode;
            public Int16 recipenumber; /* Recipe number 1->30. */
            public byte addselmthd; /* Additive selection method. */
            public byte addsel; /* Additive selection bit map. */
            public byte side; /* Swing-arm side. */
            public byte numdataprompts; /* 0->5 */
            public Int32[] dataitem; /* Data items. [numdataprompts] */
        }
        struct rsp_auth_transaction
        {
            public byte dfl; /* Data field length. */
            public byte cmdcode;
            public Int16 transeqnum; /* Prospective transaction sequence number. */
        }
        struct cmd_auth_batch_comp
        {
            public byte use_gord; /* Use or don't use this backup gravity or density. */
            public Int32 gord; /* Gravity or density. */
            public byte use_temp; /* Use or don't use this backup temperature. */
            public Int16 temp; /* Temperature. */
        }
        struct cmd_auth_batch
        {
            public byte dfl; /* Data field length. */
            public byte cmdcode;
            public Int16 numcomps; /* Configured number of components. */
            public Int16 timout; /* Time-out seconds. 0=No time-out. <0=Use configured time-out. */
            public cmd_auth_batch_comp[] comp; /* [numcomps] */
        }
        struct rsp_auth_batch
        {
            public byte dfl; /* Data field length. */
            public byte cmdcode;
            public Int16 batchseqnum; /* Prospective batch sequence number. */
        }



        #endregion


        public bool AppIsExiting = false;
        public bool ServerConnected = false;
        private int MyHostServerID = 0;
        private long ServerTime = DateTime.Now.Ticks;

        private static AutoResetEvent autoEventHostServer = null;//mutex
        private static AutoResetEvent autoEvent2;//mutex

        System.Timers.Timer GeneralTimer = null;

        private Thread FullPacketDataProcessThread = null;
        private Queue<TCPIPClient.FullPacket> FullHostServerPacketList = null;
        //public bool IsDisposed { get; }
        private Client client = null; //Client Socket class

        public Dictionary<int, UserClients> dUserClientsList = null;
        private Dictionary<int, StringBuilder> textInformation = new Dictionary<int, StringBuilder>();
        //public Dictionary<int, FileBody> dFileBodyList = null;

        //private Control invoker = null;

        public byte State = (byte)_MACHINE_STATE.DISCONNECTED;

        //System.Timers.Timer timer_rto = new System.Timers.Timer();
        System.Timers.Timer aTimer = new System.Timers.Timer();

        //private SerialPort sp = new SerialPort();
        public string DanloadStatus;
        private byte[] CommandDataframe = null;
        private byte[] ResponseDataframe = null;

        public byte fntype = 0x42;

        #region Constructor / Deconstructor
        public DanloadNetLib()
        {

        }
        ~DanloadNetLib()
        {
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
                DanloadStatus = "Connected!!";
                //labelStatusInfo.ForeColor = System.Drawing.Color.Green;
                BeginGeneralTimer();
            }
            else
            {
                ServerConnected = false;
                DanloadStatus = "Can't connect";
                //labelStatusInfo.Text = "Can't connect";
                //labelStatusInfo.ForeColor = System.Drawing.Color.Red;
                //pictureBox1.Image = imageListStatusLights.Images["RED"];
            }
        }

        public void Disconnected()
        {
            aTimer.Enabled = false;
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
            //keydata_keep = false;
            //batchData_ready = false;
            //ACK_Task = false;
            ////StartCom_State = false;
            //StartCom_fromStatus = false;
            //batchEnded = false;
            //transEnded = false;
            keydata_keep = false;
            batchData_ready = false;
            ACK_Task = false;
            Auth_clear = false;
            StartCom_State = false;
            StartCom_fromStatus = false;
            batchEnded = false;
            transEnded = false;
            transaction_number_2 = false;
        }

        public int count_press_start = 0;
        public void startDanload()
        {
            if (ServerConnected)
            {
                DanloadStatus = "ServerConnected";
                if (count_press_start == 0)
                {
                    count_press_start++;
                    resetAllState();
                    StartCom_State = true;
                    StartCom_fromStatus = false;
                    State = (byte)_MACHINE_STATE.START_COMM_STATE;
                    aTimer.Enabled = false;
                    aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                    aTimer.Interval = 500;
                    aTimer.Enabled = true;

                }
                else
                {
                    //resetAllState();
                    //count_press_start = 0;
                    StartCom_fromStatus = true;
                    keydata_keep = false;
                    DanloadStatus = "Continue";
                    aTimer.Enabled = true;
                    //State = (byte)_MACHINE_STATE.CLEAR_STATUS_STATE;
                    State = (byte)_MACHINE_STATE.START_COMM_STATE;
                }
                //Skema_Satu();




            }
            else
            {
                DanloadStatus = "Server NOT Connected";
            }
        }

        // Specify what you want to happen when the Elapsed event is raised.
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            //Console.WriteLine("Hello World!");
            Skema_Satu();
        }

        private byte[] cmd_msg;
        public int batch_request;

        public void Skema_Satu()
        {
            if (ServerConnected)
            {
                switch (State)
                {
                    case (byte)_MACHINE_STATE.DISCONNECTED:

                        break;

                    case (byte)_MACHINE_STATE.START_COMM_STATE:
                        fntype = 0x42;

                        cmd_msg = new byte[] { 0x02, (byte)_CMD_TYPE.START_COMM };
                        WriteCmdMessage(0x01, cmd_msg);
                        break;

                    case (byte)_MACHINE_STATE.CHG_OP_MODE_STATE:
                        cmd_msg = new byte[] { 0x03, (byte)_CMD_TYPE.CHG_OP_MODE, (byte)_CMD_CHG_OP_MODE.AUTO };
                        WriteCmdMessage(0x01, cmd_msg);
                        break;

                    case (byte)_MACHINE_STATE.RST_PRM_ALARMS_STATE:
                        cmd_msg = new byte[] { 0x0C, (byte)_CMD_TYPE.RST_PRM_ALARMS,
                                                 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff};
                        WriteCmdMessage(0x01, cmd_msg);
                        break;

                    case (byte)_MACHINE_STATE.TIMEOUT_OP_STATE:
                        cmd_msg = new byte[] { 0x02, (byte)_CMD_TYPE.TIMEOUT_OP };
                        WriteCmdMessage(0x01, cmd_msg);

                        break;

                    case (byte)_MACHINE_STATE.CLR_DISPLAY_STATE:
                        cmd_msg = new byte[] { 0x02, (byte)_CMD_TYPE.CLR_DISPLAY };
                        WriteCmdMessage(0x01, cmd_msg);
                        break;


                    case (byte)_MACHINE_STATE.DISPLAY_MSG_STATE:
                        cmd_msg = new byte[0x87];
                        Array.Clear(cmd_msg, 0, cmd_msg.Length);
                        cmd_msg[0] = 0x87;
                        cmd_msg[1] = (byte)_CMD_TYPE.DISPLAY_MSG;
                        Buffer.BlockCopy(Encoding.ASCII.GetBytes("Masukkan PIN:"), 0, cmd_msg, 2, 13);
                        cmd_msg[131] = 0x06;
                        WriteCmdMessage(0x01, cmd_msg);
                        break;

                    case (byte)_MACHINE_STATE.REQUEST_KEYPAD_DATA_STATE:
                        cmd_msg = new byte[] { 0x02, (byte)_CMD_TYPE.REQUEST_KEYPAD_DATA };
                        WriteCmdMessage(0x01, cmd_msg);
                        break;

                    case (byte)_MACHINE_STATE.AUTH_TRANSACTION_STATE:
                        cmd_msg = new byte[] { 0x1C, (byte)_CMD_TYPE.AUTH_TRANSACTION, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00,
                                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                        WriteCmdMessage(0x01, cmd_msg);
                        break;

                    case (byte)_MACHINE_STATE.AUTH_BATCH_STATE:
                        //cmd_msg = new byte[] { 0x12, (byte)_CMD_TYPE.AUTH_BATCH, 0x40, 0x1f, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                        //int batch_request = 8000;
                        cmd_msg = new byte[] { 0x12, (byte)_CMD_TYPE.AUTH_BATCH, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                        Buffer.BlockCopy(BitConverter.GetBytes(batch_request), 0, cmd_msg, 2, sizeof(Int32));
                        WriteCmdMessage(0x01, cmd_msg);
                        break;

                    case (byte)_MACHINE_STATE.REQ_MTR_VAL_STATE:
                        cmd_msg = new byte[] { 0x04, (byte)_CMD_TYPE.REQ_MTR_VAL, 0x01, 0x00 };
                        WriteCmdMessage(0x01, cmd_msg);
                        break;

                    case (byte)_MACHINE_STATE.REQ_STAT_STATE:
                        cmd_msg = new byte[] { 0x02, (byte)_CMD_TYPE.REQ_STAT };
                        WriteCmdMessage(0x01, cmd_msg);

                        break;


                    case (byte)_MACHINE_STATE.RST_PRM_ALARMS_STATE_ACK:
                        cmd_msg = new byte[] { 0x0C, (byte)_CMD_TYPE.RST_PRM_ALARMS,
                                                 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff};
                        WriteCmdMessage(0x01, cmd_msg);
                        break;


                    case (byte)_MACHINE_STATE.END_TRANSACTION_STATE:
                        cmd_msg = new byte[] { 0x03, (byte)_CMD_TYPE.END_TRANSACTION, 0x01 };
                        WriteCmdMessage(0x01, cmd_msg);
                        break;


                    case (byte)_MACHINE_STATE.END_BATCH_STATE:
                        cmd_msg = new byte[] { 0x02, (byte)_CMD_TYPE.END_BATCH };
                        WriteCmdMessage(0x01, cmd_msg);
                        break;

                    case (byte)_MACHINE_STATE.CLEAR_STATUS_STATE:
                        cmd_msg = new byte[] { 0x06, (byte)_CMD_TYPE.CLEAR_STATUS, 0xFF, 0xFF, 0xFF, 0xFF };
                        WriteCmdMessage(0x01, cmd_msg);
                        break;

                        //default:
                        //cmd_msg = new byte[] { 0x02, (byte)_CMD_TYPE.REQ_STAT };
                        //WriteCmdMessage(0x01, cmd_msg);
                        //break;
                }
            }
            else
            {
                DanloadStatus = "Server Not Connected";
            }
        }

        private string commandComputer;
        private void WriteCmdMessage(byte devID, byte[] datafields)
        {
            //Build outgoing danload message:
            BuildMessage(devID, datafields);

            SendMessageToServer(CommandDataframe);
            string str_command = BitConverter.ToString(CommandDataframe).Replace("-", " ");
            commandComputer = str_command;
            //SetMessageToTextBox_FromThread("CMD: " + str_command);
        }

        private void BeginGeneralTimer()
        {
            //create the general timer but skip over it if its already running
            if (GeneralTimer == null)
            {
                GeneralTimer = new System.Timers.Timer();
                GeneralTimer.Elapsed += new ElapsedEventHandler(GeneralTimer_Tick);
                GeneralTimer.Interval = 5000;
                GeneralTimer.Enabled = true;
            }
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

        public string responseDanload;
        private bool keydata_keep = false;
        public int pinKey;
        public bool batchData_ready = false;
        public bool ACK_Task = false;
        public bool Auth_clear = false;
        private bool StartCom_State = false;
        private bool StartCom_fromStatus = false;
        public bool batchEnded = false;
        public bool transEnded = false;
        public bool transaction_number_2 = false;
        public int KeyEnter = 0; //tambahan event enter BC
        public bool PinKeyAccept = false;
        public bool StartFlow = false; //tambahan untuk start flowing
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
                //SetMessageToTextBox_FromThread("RSP: " + str_response);
                responseDanload = "RSP: " + str_response;


                if (autoEventHostServer != null)
                {
                    autoEventHostServer.Set();//Fire in the hole
                }

                if (ServerConnected)
                {
                    if (ResponseDataframe.Length > 2)
                    {
                        if (CheckResponse(ResponseDataframe))
                        {
                            switch (State)
                            {
                                case (byte)_MACHINE_STATE.START_COMM_STATE:
                                    RspStartCommunication RspStartComm = new RspStartCommunication(ResponseDataframe);
                                    //SetMessageToTextBox_FromThread("Temperature Units: " + RspStartComm.TemperatureUnits);

                                    State = (byte)_MACHINE_STATE.CHG_OP_MODE_STATE;
                                    batchData_ready = false;
                                    break;

                                case (byte)_MACHINE_STATE.CHG_OP_MODE_STATE:

                                    //SetMessageToTextBox_FromThread("CHANGE_OP_MODE_STATE");
                                    DanloadStatus = "CHANGE_OP_MODE_STATE";
                                    State = (byte)_MACHINE_STATE.RST_PRM_ALARMS_STATE;

                                    break;

                                case (byte)_MACHINE_STATE.RST_PRM_ALARMS_STATE:

                                    //SetMessageToTextBox_FromThread("RST_PRM_ALARMS_STATE");
                                    DanloadStatus = "RST_PRM_ALARMS_STATE";
                                    State = (byte)_MACHINE_STATE.TIMEOUT_OP_STATE;


                                    break;

                                case (byte)_MACHINE_STATE.TIMEOUT_OP_STATE:

                                    //SetMessageToTextBox_FromThread("TIMEOUT_OP_STATE");
                                    DanloadStatus = "TIMEOUT_OP_STATE";
                                    State = (byte)_MACHINE_STATE.CLR_DISPLAY_STATE;


                                    break;

                                case (byte)_MACHINE_STATE.CLR_DISPLAY_STATE:

                                    //SetMessageToTextBox_FromThread("CLR_DISPLAY_STATE");
                                    DanloadStatus = "CLR_DISPLAY_STATE";
                                    State = (byte)_MACHINE_STATE.DISPLAY_MSG_STATE;


                                    break;

                                case (byte)_MACHINE_STATE.DISPLAY_MSG_STATE:

                                    //SetMessageToTextBox_FromThread("DISPLAY_MSG_STATE");
                                    DanloadStatus = "DISPLAY_MSG_STATE";
                                    keydata_keep = false;
                                    State = (byte)_MACHINE_STATE.REQ_MTR_VAL_STATE;
                                    if (batchEnded && transEnded)
                                    {
                                        //State = (byte)_MACHINE_STATE.CLEAR_STATUS_STATE;
                                        transaction_number_2 = true;

                                    }


                                    break;

                                case (byte)_MACHINE_STATE.REQUEST_KEYPAD_DATA_STATE:

                                    //SetMessageToTextBox_FromThread("REQUEST_KEYPAD_DATA_STATE");
                                    State = (byte)_MACHINE_STATE.REQUEST_KEYPAD_DATA_STATE;
                                    RspKeypad RspPad = new RspKeypad(ResponseDataframe);
                                    KeyEnter = RspPad.KeypadInput;
                                    // public int KeyPad = RspKeypad.Key;
                                    //SetMessageToTextBox_FromThread("Request Keypad: " + RspPad.KeypadInput);

                                    if (PinKeyAccept)
                                    {
                                        PinKeyAccept = false;
                                        //if (batch_request!=0 && KeyEnter != 0)
                                        //{
                                        State = (byte)_MACHINE_STATE.AUTH_TRANSACTION_STATE;
                                        keydata_keep = true;
                                        //}
                                        //else
                                        //{
                                        //    State = (byte)_MACHINE_STATE.DISPLAY_MSG_STATE;
                                        //}
                                        //SetMessageToTextBox_FromThread("AUTH READY");

                                        // pinKey = 0;
                                    }
                                    else
                                    {
                                        State = (byte)_MACHINE_STATE.DISPLAY_MSG_STATE;
                                    }


                                    break;


                                case (byte)_MACHINE_STATE.AUTH_TRANSACTION_STATE:

                                    //SetMessageToTextBox_FromThread("AUTH_TRANSACTION_STATE");
                                    State = (byte)_MACHINE_STATE.AUTH_BATCH_STATE;


                                    break;

                                case (byte)_MACHINE_STATE.AUTH_BATCH_STATE:

                                    //SetMessageToTextBox_FromThread("AUTH_BATCH_STATE");
                                    batchData_ready = true;
                                    State = (byte)_MACHINE_STATE.REQ_MTR_VAL_STATE;


                                    break;

                                case (byte)_MACHINE_STATE.REQ_STAT_STATE:
                                    RspRequestStatus RspStatus = new RspRequestStatus(ResponseDataframe);
                                    grsvol = RspStatus.Grsvol;
                                    netvol = RspStatus.Netvol;
                                    status = RspStatus.PrintStatus();
                                    PrintAlarm0 = RspStatus.PrintAlarm0();
                                    PrintAlarm1 = RspStatus.PrintAlarm1();
                                    PrintAlarm2 = RspStatus.PrintAlarm2();
                                    PrintAlarm3 = RspStatus.PrintAlarm3();
                                    PrintAlarm4 = RspStatus.PrintAlarm4();
                                    PrintAlarm5 = RspStatus.PrintAlarm5();
                                    PrintAlarm6 = RspStatus.PrintAlarm6();
                                    PrintAlarm7 = RspStatus.PrintAlarm7();
                                    PrintAlarm8 = RspStatus.PrintAlarm8();
                                    PrintAlarm9 = RspStatus.PrintAlarm9();
                                    State = (byte)_MACHINE_STATE.REQ_MTR_VAL_STATE;
                                    DanloadStatus = "REQ_STAT_STATE";

                                    if (RspStatus.KeypadDataAvailable() && keydata_keep == false)
                                    {
                                        //keydata_keep = true;
                                        State = (byte)_MACHINE_STATE.REQUEST_KEYPAD_DATA_STATE;
                                        DanloadStatus = "REQUEST_KEYPAD_DATA_STATE";
                                    }
                                    //else if (RspStatus.KeypadDataAvailable() && RspStatus.BatchEnded() && RspStatus.TransactionAuthorized())
                                    if (RspStatus.KeypadDataAvailable() && keydata_keep == true)
                                    {
                                        State = (byte)_MACHINE_STATE.AUTH_BATCH_STATE;
                                    }

                                    if (RspStatus.TransactionEnded() && RspStatus.BatchEnded() && !RspStatus.KeypadDataAvailable() && transaction_number_2 == false)
                                    {
                                        //State = (byte)_MACHINE_STATE.DISPLAY_MSG_STATE;
                                        transaction_number_2 = true;
                                        resetAllState();


                                    }


                                    if (RspStatus.BatchAborted())
                                    {
                                        State = (byte)_MACHINE_STATE.AUTH_BATCH_STATE;
                                    }

                                    if (RspStatus.TransactionInProgress() && RspStatus.BatchEnded() && RspStatus.TransactionAuthorized())
                                    {
                                        State = (byte)_MACHINE_STATE.END_TRANSACTION_STATE;

                                    }

                                    batchEnded = RspStatus.BatchEnded();
                                    transEnded = RspStatus.TransactionEnded();

                                    if (RspStatus.Flowing())
                                    {
                                        StartFlow = true;
                                        State = (byte)_MACHINE_STATE.REQ_MTR_VAL_STATE;
                                        transaction_number_2 = false;
                                    }

                                    if (StartCom_fromStatus)
                                    {
                                        //resetAllState();
                                        keydata_keep = false;
                                        StartCom_fromStatus = false;
                                        State = (byte)_MACHINE_STATE.CHG_OP_MODE_STATE;
                                    }


                                    break;

                                case (byte)_MACHINE_STATE.REQ_MTR_VAL_STATE:

                                    //SetMessageToTextBox_FromThread("REQ_MTR_VAL_STATE")
                                    RspMeterValue RspMeter = new RspMeterValue(ResponseDataframe);
                                    MeterNumber = RspMeter.MeterNumber;
                                    GrossTotal = RspMeter.GrossTotal;
                                    NetTotal = RspMeter.NetTotal;
                                    Grs = RspMeter.Grs;
                                    Net = RspMeter.Net;
                                    Rate3 = RspMeter.Rate3;
                                    Rate5 = RspMeter.Rate5;
                                    Rate4 = RspMeter.Rate4;
                                    Mtrfac = RspMeter.Mtrfac;
                                    Plscnt = RspMeter.Plscnt;
                                    Numfacts = RspMeter.Numfacts;
                                    pls2 = RspMeter.pls2;
                                    ufg10 = RspMeter.ufg10;
                                    ufn10 = RspMeter.ufn10;
                                    temp10 = RspMeter.temp;
                                    dens = RspMeter.dens;
                                    pres = RspMeter.pres;
                                    rawLength = RspMeter.rawLength;

                                    DanloadStatus = "REQ_MTR_VAL_STATE";
                                    if (ACK_Task)
                                    {
                                        ACK_Task = false;
                                        State = (byte)_MACHINE_STATE.RST_PRM_ALARMS_STATE_ACK;
                                    }
                                    else if (Auth_clear)
                                    {
                                        Auth_clear = false;
                                        State = (byte)_MACHINE_STATE.END_TRANSACTION_STATE;
                                    }
                                    else
                                    {
                                        State = (byte)_MACHINE_STATE.REQ_STAT_STATE;
                                    }

                                    break;

                                case (byte)_MACHINE_STATE.RST_PRM_ALARMS_STATE_ACK:

                                    //SetMessageToTextBox_FromThread("RST_PRM_ALARMS_STATE");
                                    //DanloadStatus = "RST_PRM_ALARMS_STATE";
                                    State = (byte)_MACHINE_STATE.REQ_MTR_VAL_STATE;
                                    DanloadStatus = "RST_PRM_ALARMS_STATE_ACK";

                                    break;

                                case (byte)_MACHINE_STATE.END_TRANSACTION_STATE:

                                    //State = (byte)_MACHINE_STATE.END_BATCH_STATE;
                                    State = (byte)_MACHINE_STATE.CLR_DISPLAY_STATE;
                                    DanloadStatus = "END_TRANSACTION_STATE";

                                    break;

                                case (byte)_MACHINE_STATE.END_BATCH_STATE:

                                    State = (byte)_MACHINE_STATE.CLR_DISPLAY_STATE;
                                    DanloadStatus = "END_BATCH_STATE";

                                    break;

                                case (byte)_MACHINE_STATE.CLEAR_STATUS_STATE:

                                    State = (byte)_MACHINE_STATE.REQ_MTR_VAL_STATE;
                                    DanloadStatus = "CLEAR_STATUS_STATE";

                                    break;


                                case (byte)_MACHINE_STATE.CLEAR_STATUS_STATE_ACK:

                                    State = (byte)_MACHINE_STATE.RST_PRM_ALARMS_STATE;
                                    DanloadStatus = "CLEAR_STATUS_STATE";

                                    break;

                            }
                        }
                    }
                }
            }
        }

        //Respon Status
        private int grsvol;
        public int netvol;
        private string status;
        private string PrintAlarm0;
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
        public int GrossTotal;
        private int NetTotal;
        private int Grs;
        private int Net;
        public int Rate3;
        private int Rate5;
        private int Rate4;
        private long Mtrfac;
        private int Plscnt;
        private long Numfacts;
        private long pls2;
        private long ufg10;
        private long ufn10;
        public int temp10;
        public long dens;
        public long pres;

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
                    DanloadStatus = "NOT Connected";
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
            if (GeneralTimer != null)
            {
                if (GeneralTimer.Enabled == true)
                    GeneralTimer.Enabled = false;

                try
                {
                    GeneralTimer.Elapsed -= GeneralTimer_Tick;
                }
                catch (Exception)
                {
                    //just incase there was no event to remove
                }
                GeneralTimer.Dispose();
                GeneralTimer = null;
            }
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

        }

        #endregion

        #region CRC Computation
        private void GetCRC(byte[] message, ref byte[] CRC)
        {
            //Function expects a modbus message of any length as well as a 2 byte CRC array in which to 
            //return the CRC values:

            ushort CRCFull = 0xFFFF;
            byte CRCHigh = 0xFF, CRCLow = 0xFF;
            char CRCLSB;

            for (int i = 0; i < (message.Length) - 2; i++)
            {
                CRCFull = (ushort)(CRCFull ^ message[i]);

                for (int j = 0; j < 8; j++)
                {
                    CRCLSB = (char)(CRCFull & 0x0001);
                    CRCFull = (ushort)((CRCFull >> 1) & 0x7FFF);

                    if (CRCLSB == 1)
                        CRCFull = (ushort)(CRCFull ^ 0xA001);
                }
            }
            CRC[1] = CRCHigh = (byte)((CRCFull >> 8) & 0xFF);
            CRC[0] = CRCLow = (byte)(CRCFull & 0xFF);
        }
        #endregion

        #region Build Message
        public void BuildMessage(byte address, byte[] datafields)
        {
            CommandDataframe = new byte[2 + datafields.Length + 2];

            //Array to receive CRC bytes:
            byte[] CRC = new byte[2];

            if (fntype == 0x42) fntype = 0x41;
            else fntype = 0x42;

            CommandDataframe[0] = address;
            CommandDataframe[1] = fntype;

            for (int i = 0; i < datafields.Length; i++)
            {
                CommandDataframe[i + 2] = datafields[i];
            }

            GetCRC(CommandDataframe, ref CRC);
            CommandDataframe[CommandDataframe.Length - 2] = CRC[0];
            CommandDataframe[CommandDataframe.Length - 1] = CRC[1];
        }
        #endregion

        #region Check Response
        private bool CheckResponse(byte[] response)
        {
            //Perform a basic CRC check:
            byte[] CRC = new byte[2];
            GetCRC(response, ref CRC);
            if (CRC[0] == response[response.Length - 2] && CRC[1] == response[response.Length - 1])
                return true;
            else
                return false;
        }

        #endregion

        #region Get Response
        //private void GetResponse(ref byte[] response)
        //{

        //}
        #endregion
        //private byte[] response;

        //public bool ReadMsg(ref string str_response)
        //{
        //    GetResponse(ref response);

        //    if (CheckResponse(response))
        //    {
        //        str_response = BitConverter.ToString(response).Replace("-", " ");
        //        DanloadStatus = "Read successful";
        //        return true;
        //    }
        //    else
        //    {
        //        DanloadStatus = "CRC error";
        //        return false;
        //    }
        //}

        #region Function Send Danload Message - Normal (41h or 42h) message commands
        //public bool SendMsg(byte address, byte[] datafields_cmd)
        //{
        //    return true;
        //}
        #endregion

    }

    #region Definition
    [Flags]
    public enum APPLICATION
    {
        None = 0,
        ClientTypeA = 1,
        ClientTypeB = 2
    }

    public enum APPLEVEL
    {
        None = 0,
        ClientLevel1 = 1,
        ClientLevel2 = 2
    }
    public enum PACKETTYPES
    {
        TYPE_Ping = 1,
        TYPE_PingResponse = 2,
        TYPE_RequestCredentials = 3,
        TYPE_MyCredentials = 4,
        TYPE_Registered = 5,
        TYPE_HostExiting = 6,
        TYPE_ClientData = 7,
        TYPE_ClientDisconnecting = 8,
        TYPE_CredentialsUpdate = 9,
        TYPE_Close = 10,
        TYPE_Message = 11,
        TYPE_MessageReceived = 12,
        TYPE_FileStart = 13,
        TYPE_FileChunk = 14,
        TYPE_FileEnd = 15,
        TYPE_DoneRecievingFile = 16
    }

    public enum PACKETTYPES_SUBMESSAGE
    {
        SUBMSG_MessageStart,
        SUBMSG_MessageGuts,
        SUBMSG_MessageEnd
    }

    public enum FILEACTION
    {
        IncomingFile = 1,
        OutgoingFile = 2
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class PACKET_DATA
    {
        /****************************************************************/
        //HEADER is 18 BYTES
        public UInt16 Packet_Type;  //TYPE_??
        public UInt16 Packet_Size;
        public UInt16 Data_Type;    // DATA_ type fields
        public UInt16 maskTo;       // SENDTO_MY_SHUBONLY and the like.
        public UInt32 idTo;         // Used if maskTo is SENDTO_INDIVIDUAL
        public UInt32 idFrom;       // Client ID value
        public UInt16 nAppLevel;
        /****************************************************************/

        public UInt32 Data1;        //miscellanious information
        public UInt32 Data2;        //miscellanious information
        public UInt32 Data3;        //miscellanious information
        public UInt32 Data4;        //miscellanious information
        public UInt32 Data5;        //miscellanious information

        public Int32 Data6;        //miscellanious information
        public Int32 Data7;        //miscellanious information
        public Int32 Data8;        //miscellanious information
        public Int32 Data9;        //miscellanious information
        public Int32 Data10;       //miscellanious information

        public UInt32 Data11;        //miscellanious information
        public UInt32 Data12;        //miscellanious information
        public UInt32 Data13;        //miscellanious information
        public UInt32 Data14;        //miscellanious information
        public UInt32 Data15;        //miscellanious information

        public Int32 Data16;        //miscellanious information
        public Int32 Data17;        //miscellanious information
        public Int32 Data18;        //miscellanious information
        public Int32 Data19;        //miscellanious information
        public Int32 Data20;       //miscellanious information

        public UInt32 Data21;        //miscellanious information
        public UInt32 Data22;        //miscellanious information
        public UInt32 Data23;        //miscellanious information
        public UInt32 Data24;        //miscellanious information
        public UInt32 Data25;        //miscellanious information

        public Int32 Data26;        //miscellanious information
        public Int32 Data27;        //miscellanious information
        public Int32 Data28;        //miscellanious information
        public Int32 Data29;        //miscellanious information
        public Int32 Data30;       //miscellanious information

        public Double DataDouble1;
        public Double DataDouble2;
        public Double DataDouble3;
        public Double DataDouble4;
        public Double DataDouble5;

        /// <summary>
        /// Long value1
        /// </summary>
        public Int64 DataLong1;
        /// <summary>
        /// Long value2
        /// </summary>
        public Int64 DataLong2;
        /// <summary>
        /// Long value3
        /// </summary>
        public Int64 DataLong3;
        /// <summary>
        /// Long value4
        /// </summary>
        public Int64 DataLong4;

        /// <summary>
        /// Unsigned Long value1
        /// </summary>
        public UInt64 DataULong1;
        /// <summary>
        /// Unsigned Long value2
        /// </summary>
        public UInt64 DataULong2;
        /// <summary>
        /// Unsigned Long value3
        /// </summary>
        public UInt64 DataULong3;
        /// <summary>
        /// Unsigned Long value4
        /// </summary>
        public UInt64 DataULong4;

        /// <summary>
        /// DateTime Tick value1
        /// </summary>
        public Int64 DataTimeTick1;

        /// <summary>
        /// DateTime Tick value2
        /// </summary>
        public Int64 DataTimeTick2;

        /// <summary>
        /// DateTime Tick value1
        /// </summary>
        public Int64 DataTimeTick3;

        /// <summary>
        /// DateTime Tick value2
        /// </summary>
        public Int64 DataTimeTick4;

        /// <summary>
        /// 300 Chars
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 300)]
        public Char[] szStringDataA = new Char[300];

        /// <summary>
        /// 300 Chars
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 300)]
        public Char[] szStringDataB = new Char[300];

        /// <summary>
        /// 150 Chars
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 150)]
        public Char[] szStringData150 = new Char[150];

        //18 + 120 + 40 + 96 + 600 + 150 = 1024
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class PACKET_CLIENTDATA
    {
        //HEADER is 16 BYTES
        public UInt16 Packet_Type;  //TYPE_??
        public UInt16 Packet_Size;
        public UInt16 Data_Type;    // DATA_ type fields
        public UInt16 maskTo;       // SENDTO_MY_SHUBONLY and the like.
        public UInt32 idTo;         // Used if maskTo is SENDTO_INDIVIDUAL
        public UInt32 idFrom;       // Client ID value

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
        public char[] szUserName = new char[50];

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
        public char[] szUsersAddress = new char[30];

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
        public char[] szUsersAlternateAddress = new char[30];

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
        public char[] szUsersClientVersion = new char[30];

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
        public char[] szStationName = new char[50];

        public UInt16 iClientID;
        public UInt32 ClientsColorRGB;
        public UInt16 ClientStatus;//CLIENTSTATUS
        public UInt16 ListeningPort;//Port the clients server is listening on
        public long StatusTimeTicks;//(8 bytes!)Convert Datime to ticks 

        //1024 - 16 - 50 - 30 - 30 - 30 - 50 - 18 = 800
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 800)]
        public byte[] SpaceTaker = new byte[800];
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class PACKET_BIGSTRING
    {
        public UInt16 Packet_Type;  //TYPE_??
        public UInt32 idTo;
        public UInt32 idFrom;
        public UInt32 StringLength;
        public UInt32 Extra;

        //1024 - 18  = 1006 bytes are left
        //4096 - 18  = 4078 bytes are left
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1006)]
        public Char[] sBigString = new Char[1006];

        /* NOTE: 
         * Remember to do a search for the value '1006' in 
         * the project if you change the packet size here 
         * and replace the value to the new size
        */
    }

    /******************** File transfer class **************/
    /// <summary>
    /// Fill FilePartBegin with the first 914 bytes of the file 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class PACKET_FILESTART
    {
        public UInt16 Packet_Type;  //TYPE_??
        public UInt16 idTo;
        public UInt16 idFrom;
        public UInt16 FileID;
        public UInt32 File_Size;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 98)]
        public char[] szFileName = new char[98];

        //1024 - 12 - 98 = 914 bytes are left
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 914)]
        public byte[] FilePart1 = new byte[914];

    }

    /// <summary>
    /// Fill FilePartChunk with the next 1010 bytes of the file 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class PACKET_FILECHUNK
    {
        public UInt16 Packet_Type;  //TYPE_??
        public UInt16 idTo;
        public UInt16 idFrom;
        public UInt16 FileID;
        public UInt16 Chunk_Size;
        public UInt32 ChunkCount;

        //1024 - 14 = 1010 bytes are left
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1010)]
        public byte[] FilePartChunk = new byte[1010];
    }
    /*******************************************************/

    public static class PACKET_FUNCTIONS
    {
        #region Byte Combobulator and Discombobulator
        public static Byte[] StructureToByteArray(Object obj)
        {
            Int32 rawsize = Marshal.SizeOf(obj);
            IntPtr buffer = Marshal.AllocHGlobal(rawsize);
            Marshal.StructureToPtr(obj, buffer, false);
            Byte[] rawdatas = new Byte[rawsize];
            Marshal.Copy(buffer, rawdatas, 0, rawsize);
            Marshal.FreeHGlobal(buffer);
            return rawdatas;
        }

        public static Object ByteArrayToStructure(Byte[] rawdatas, Type anytype)
        {
            Int32 rawsize = Marshal.SizeOf(anytype);
            if (rawsize > rawdatas.Length)
                return null;

            IntPtr buffer = Marshal.AllocHGlobal(rawsize);
            Marshal.Copy(rawdatas, 0, buffer, rawsize);
            Object retobj = Marshal.PtrToStructure(buffer, anytype);
            Marshal.FreeHGlobal(buffer);
            return retobj;
        }
        #endregion
    }
    #endregion

   public class UserClients
    {
        public UserClients(string szClientsIP, ushort iClientPort, string szUserName,
            int serverID, string szClientsAltIP, string pcName)
        {
            _ClientsIP = IPAddress.Parse(szClientsIP);
            _HostServerID = serverID;
            _szUserName = szUserName;
            _Port = iClientPort;//22043;

            _szAltIp = szClientsAltIP;
            szStationName = pcName;
            _FileTransferInTransit = 0;
        }

        public IPAddress ClientsIP { get { return _ClientsIP; } }
        public string szUserName { get { return _szUserName; } set { _szUserName = value; } }
        public string szStationName { get; set; }
        public int HostServerID { get { return _HostServerID; } }
        public int Port { get { return _Port; } }

        public Int16 FileTransferInTransit { get { return _FileTransferInTransit; } set { _FileTransferInTransit = value; } }

        public string szAltIp { get { return _szAltIp; } set { _szAltIp = value; } }

        public bool FailedOnSend
        {
            get;
            set;
        }
        public bool UseAltIP
        {
            get
            {
                if (szAltIp.Length > 0)
                    return _UseAltIP;
                else
                    return false;
            }
            set
            {
                if (szAltIp.Length > 0)
                    _UseAltIP = value;
                else
                    _UseAltIP = false;
            }
        }

        private int _HostServerID;
        private string _szUserName;
        private IPAddress _ClientsIP;
        private int _Port;


        private long _LastStatusTime;//time in NanoSeconds from Midnight 01-01-0001
        private string _szAltIp;
        private bool _UseAltIP;//Uses the alternate address specified by the client for a P2P connection
        private Int16 _FileTransferInTransit;//true while data is enroute to this user        

        public override string ToString()
        {
            return _szUserName;
        }
    }


    /*****************************************************************************************************/
    class FilesToSend
    {
        public FilesToSend(UInt16 fileID, string szPathAndFile, int sendTo)
        {
            _szPathAndFile = szPathAndFile;
            _SendTo = sendTo;
            _FileId = fileID;
        }

        public UInt16 FileId { get { return _FileId; } }
        public string szPathAndFile { get { return _szPathAndFile; } }
        public int sendTo { get { return _SendTo; } }

        private UInt16 _FileId;
        private string _szPathAndFile;
        private int _SendTo;
    }

    class RTFGuts
    {
        public RTFGuts(int sizeofguts, char[] theguts)
        {
            _guts = new char[sizeofguts];
            _guts = theguts;
            _iSizeOfGuts = sizeofguts;
        }

        public char[] guts { get { return _guts; } }
        public int iSizeOfGuts { get { return _iSizeOfGuts; } }

        private char[] _guts;
        private int _iSizeOfGuts;
    }

    class RTFBody
    {
        public RTFBody(int idFromClient, UInt32 sizeoffile, UInt16 RTFID)
        {
            _iSizOfRTF = sizeoffile;
            _iRTFID = RTFID;
            _iFromClientId = idFromClient;
            _RTFGutsList = new Queue<RTFGuts>();

        }
        ~RTFBody()
        {
            _RTFGutsList.Clear();
        }

        public int iFromClientId { get { return _iFromClientId; } }
        public int KeyID { get { return _iRTFID; } }

        public void AddToRTFGuts(RTFGuts fg)
        {
            lock (_RTFGutsList)
                _RTFGutsList.Enqueue(fg);
        }

        public RTFGuts PopAGut
        {
            get
            {
                RTFGuts rg;
                lock (_RTFGutsList)
                    rg = _RTFGutsList.Dequeue();
                return rg;
            }
        }

        public int GetGutCount()
        {
            return _RTFGutsList.Count;
        }

        private UInt32 _iSizOfRTF;
        private UInt16 _iRTFID;
        private int _iFromClientId;

        private Queue<RTFGuts> _RTFGutsList;
    }

    class FileGuts
    {
        public FileGuts(int sizeofguts, byte[] theguts)
        {
            _guts = new byte[sizeofguts];
            _guts = theguts;
            _iSizeOfGuts = sizeofguts;
        }

        public byte[] guts { get { return _guts; } }
        public int iSizeOfGuts { get { return _iSizeOfGuts; } }

        private byte[] _guts;
        private int _iSizeOfGuts;
    }

    class FileBody
    {
        public FileBody(int idFromClient, string szFileName, UInt32 sizeoffile, UInt16 fileID, string szAppFilePath)
        {
            _fileCreateInProgress = true;
            _szFileName = szFileName;
            _iSizOfFile = sizeoffile;
            _iFileID = fileID;
            _iFromClientId = idFromClient;
            _FileGutsList = new Queue<FileGuts>();
            _stillInThread = true;
            _fileGutCounter = 0;
            _appFilePath = szAppFilePath;

            autoEventFileGuts = new AutoResetEvent(false);//the guts mutex
            autoEventFinished = new AutoResetEvent(false);//the finished mutex
            ProcessTempFile = new Thread(new ThreadStart(DoTempFile));
            ProcessTempFile.Name = "file_" + szFileName;//name the thread
            ProcessTempFile.Start();

            //create a watchdog timer
            TimeOut = 0;
            _packetTimer = new System.Timers.Timer();
            _packetTimer.Interval = 10000;//10 sec 
            _packetTimer.Elapsed += new System.Timers.ElapsedEventHandler(_packetTimer_Elapsed);
            _packetTimer.Enabled = true;
        }

        public int iFromClientId { get { return _iFromClientId; } }
        public string szFileName { get { return _szFileName; } }
        public int KeyID { get { return _iFileID; } }

        public void ClearList()
        {
            lock (_FileGutsList)
                _FileGutsList.Clear();
        }

        public void AddToFileGuts(FileGuts fg)
        {
            lock (_FileGutsList)
                _FileGutsList.Enqueue(fg);


            if (_FileGutsList.Count > 100)
                if (autoEventFileGuts != null)
                    autoEventFileGuts.Set();

            TimeOut = 0;
        }

        private void DoTempFile()
        {
            Console.WriteLine("\n------------------ IN DoTempFile");
            try
            {
                //fin = new FileStream(System.Windows.Forms.Application.StartupPath + "\\" + _iFileID.ToString() + _szFileName + ".TMP", FileMode.Create, FileAccess.Write);
                _tmpFilename = Path.Combine(_appFilePath, string.Format("{0}{1}.TMP", _iFileID, _szFileName));
                fin = new FileStream(_tmpFilename, FileMode.Create, FileAccess.Write);
                if (fin != null)
                    fin.Seek(0, SeekOrigin.Begin);


                while (_fileCreateInProgress)
                {
                    //Console.WriteLine("------------------ BefORE WAIT");
                    autoEventFinished.Set();//signals the TransferCompleted function that we have made it here
                    autoEventFileGuts.WaitOne();//wait at mutex until signal
                    //Console.WriteLine("------------------ AFTER WAIT");

                    if (fin != null)
                    {
                        while (_FileGutsList.Count > 0)
                        {
                            FileGuts fg = null;
                            lock (_FileGutsList)
                                fg = _FileGutsList.Dequeue();

                            fin.Write(fg.guts, 0, fg.iSizeOfGuts);
                        }
                    }
                }

                if (fin != null)
                {
                    fin.Close();
                    fin.Dispose();
                    fin = null;
                }
                else
                {
                    //logMessage.ToFile("Error creating file: " + _szFileName, _appFilePath, "ErrorLog.txt");
                }
            }
            catch (Exception ex)
            {
                string msg = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
                System.Diagnostics.Debug.WriteLine("ERROR in DoTempFile()\n" + msg);
            }
            finally
            {
                _stillInThread = false;
            }
        }

        internal string TransferCompleted(string FinalPathAndFileName)
        {
            Console.WriteLine("1 ProcessTempFile.IsAlive = " + ProcessTempFile.IsAlive.ToString());

            //Wait here till we get the 'Set' from the thread. Files that are really small will blow past
            //this function before the threaded 'DoTempFile' funtion ever gets set if we dont wait.
            autoEventFinished.WaitOne();//genius on my part... did I spell genius right?

            _fileCreateInProgress = false;

            if (autoEventFileGuts != null)
                autoEventFileGuts.Set();

            while (_stillInThread)//wait till we know the temp file is closed
            {
                Thread.Sleep(5);
            }

            bool WeNeedAnewFileName = false;
            try
            {
                if (File.Exists(FinalPathAndFileName))//this will only happen for template type files and shedule type files, the
                    File.Delete(FinalPathAndFileName);//File.Move function below will throw an exception if that file already exixts.
            }
            catch (Exception ex)
            {
                //we couldnt remove an existing file....I'd assume it was open so lets chand the name of the file
                string msg = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
                System.Diagnostics.Debug.WriteLine(string.Format("\nERROR in TransferCompleted:\n{0}\n", msg));

                WeNeedAnewFileName = true;
            }

            if (WeNeedAnewFileName)
            {
                int c = 1;
                string dir = Path.GetDirectoryName(FinalPathAndFileName);
                string FileName = Path.GetFileNameWithoutExtension(FinalPathAndFileName);
                string ext = Path.GetExtension(FinalPathAndFileName);

                while (File.Exists(FinalPathAndFileName))
                {
                    if (c > 1)
                    {
                        try //try deleting the previous file that was here
                        {
                            if (File.Exists(FinalPathAndFileName))
                                File.Delete(FinalPathAndFileName);
                        }
                        catch { }
                    }

                    string file = string.Format("{0}({1})", FileName, c);
                    string newFileName = string.Format("{0}{1}", file, ext);
                    FinalPathAndFileName = Path.Combine(dir, newFileName);

                    c++;
                }
            }


            //string filename = Path.Combine(_appFilePath, string.Format("{0}{1}.TMP", _iFileID, _szFileName));
            if (File.Exists(_tmpFilename))
            {
                File.Move(_tmpFilename, FinalPathAndFileName);
            }
            else
                Console.WriteLine("FILE NOT FOUND: " + _tmpFilename);

            Console.WriteLine("2 ProcessTempFile.IsAlive = " + ProcessTempFile.IsAlive.ToString());

            CleanupClass();

            return FinalPathAndFileName;
        }

        //Every 10 seconds
        private void _packetTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (++TimeOut >= 6)
            {
                TimeOut = 0;

                //No packets within 60 seconds so something happened
                DoEmergencyAbort();
            }

            Console.WriteLine("_packetTimer_Elapsed = " + TimeOut.ToString());
        }

        public void DoEmergencyAbort()
        {
            _fileCreateInProgress = false;

            lock (_FileGutsList)
                _FileGutsList.Clear();

            if (autoEventFileGuts != null)
                autoEventFileGuts.Set();

            Thread.Sleep(100);



            _stillInThread = false;

            if (ProcessTempFile != null)
            {
                int c = 0;
                while (ProcessTempFile.IsAlive)
                {
                    Thread.Sleep(10);

                    if (c++ > 10)
                        break;
                }

                if (ProcessTempFile.IsAlive)
                    ProcessTempFile.Abort();

            }

            ProcessTempFile = null;

            CleanupClass();
        }

        private void CleanupClass()
        {
            try
            {
                if (_packetTimer != null)
                {
                    _packetTimer.Elapsed -= _packetTimer_Elapsed;
                    _packetTimer.Stop();
                    _packetTimer.Close();
                    _packetTimer.Dispose();
                    _packetTimer = null;
                }

                if (autoEventFileGuts != null)
                {
                    autoEventFileGuts.Close();
                    //autoEventFileGuts.Dispose();
                    autoEventFileGuts = null;
                }

                if (autoEventFinished != null)
                {
                    autoEventFinished.Close();
                    //autoEventFinished.Dispose();
                    autoEventFinished = null;
                }

            }
            catch { }
        }

        public FileGuts PopAGut
        {
            get
            {
                FileGuts fg;
                lock (_FileGutsList)
                    fg = _FileGutsList.Dequeue();
                return fg;
            }
        }

        public int GetGutCount
        {
            get { return _FileGutsList.Count; }
        }

        private string _appFilePath;
        private string _szFileName;
        private string _tmpFilename;
        private UInt32 _iSizOfFile;
        private UInt16 _iFileID;
        private int _iFromClientId;

        private Queue<FileGuts> _FileGutsList;
        private bool _fileCreateInProgress;
        private bool _stillInThread;

        private FileStream fin = null;
        private AutoResetEvent autoEventFileGuts = null;//mutex 
        private AutoResetEvent autoEventFinished = null;//mutex 
        private Thread ProcessTempFile = null;

        private System.Timers.Timer _packetTimer = null;
        private byte TimeOut;
        private int _fileGutCounter;

    }
}
