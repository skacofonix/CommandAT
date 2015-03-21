using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;

namespace CommandAT.Tools.GSM
{
    internal class RIL
    {
        #region Variables

        private static AutoResetEvent whCellTowerInfo = new AutoResetEvent(false);
        private static AutoResetEvent whOperatorList = new AutoResetEvent(false);
        private static AutoResetEvent whCurrentOperator = new AutoResetEvent(false);
        private static AutoResetEvent whSignalQuality = new AutoResetEvent(false);
        private static AutoResetEvent whAllOperatorsList = new AutoResetEvent(false);
        private static AutoResetEvent whUnregisterFromNetwork = new AutoResetEvent(false);
        private static AutoResetEvent whSerialPortHandle = new AutoResetEvent(false);
        private static AutoResetEvent whPreferredOperatorList = new AutoResetEvent(false);
        private static AutoResetEvent waithandle = new AutoResetEvent(false);
        private static AutoResetEvent whDevSpecific = new AutoResetEvent(false);
        private static AutoResetEvent whSwitchOperator = new AutoResetEvent(false);

        private IntPtr hRil = IntPtr.Zero;

        private static RILCELLTOWERINFO _towerDetails;
        private static RILOPERATORNAMES _operatorNames;
        private static RILSIGNALQUALITY _signalQuality;
        private static string _resAT;

        private static int WAIT_TIMEOUT = 90000;

        private static uint RIL_NCLASS_DEVSPECIFIC = 0x80000000;
        private static uint RIL_NOTIFY_LOCATION = (0x00008000 | RIL_NCLASS_DEVSPECIFIC);
        private static int RIL_DEVSPECIFIC_SEND_ATC = 0x06;
        #endregion

        private static object bolt = new object();

        internal RIL()
        { }

        #region  RIL DLL functions

        [DllImport("ril.dll")]
        private static extern IntPtr RIL_Initialize(uint dwIndex, RILRESULTCALLBACK pfnResult, RILNOTIFYCALLBACK pfnNotify, uint dwNotificationClasses, uint dwParam, out IntPtr lphRil);
        [DllImport("ril.dll")]
        private static extern IntPtr RIL_Deinitialize(IntPtr hRil);
        [DllImport("ril.dll")]
        internal static extern IntPtr RIL_SendSimCmd(IntPtr lphRil, IntPtr lpbComamnd, IntPtr dwSize);
        [DllImport("ril.dll")]
        private static extern IntPtr RIL_GetCellTowerInfo(IntPtr hRil);
        [DllImport("ril.dll")]
        private static extern IntPtr RIL_Hangup(IntPtr hRil);
        [DllImport("ril.dll")]
        private static extern IntPtr RIL_RegisterOnNetwork(IntPtr hRil, uint dwMode, RILOPERATORNAMES rop);
        [DllImport("ril.dll")]
        private static extern IntPtr RIL_GetCurrentOperator(IntPtr hRil, uint dwFormat);
        [DllImport("ril.dll")]
        private static extern IntPtr RIL_GetSignalQuality(IntPtr hRil);
        [DllImport("ril.dll")]
        private static extern IntPtr RIL_GetOperatorList(IntPtr hRil);
        [DllImport("ril.dll")]
        private static extern IntPtr RIL_GetAllOperatorsList(IntPtr hRil);
        [DllImport("ril.dll")]
        private static extern IntPtr RIL_UnregisterFromNetwork(IntPtr hRil);
        [DllImport("ril.dll")]
        private static extern IntPtr RIL_GetSerialPortHandle(IntPtr hRil, out IntPtr hSerial);
        [DllImport("ril.dll")]
        private static extern IntPtr RIL_GetPreferredOperatorList(IntPtr lphRil, IntPtr dwFormat);
        [DllImport("ril.dll")]
        private static extern IntPtr RIL_DevSpecific(IntPtr hRil, IntPtr dwParam, IntPtr dwSize);

        #endregion

        #region Calbacks
        internal delegate void RILRESULTCALLBACK(uint dwCode,
                                               IntPtr hrCmdID,
                                               IntPtr lpData,
                                               uint cbData,
                                               uint dwParam);


        internal delegate void RILNOTIFYCALLBACK(uint dwCode,
                                               IntPtr lpData,
                                               uint cbData,
                                               uint dwParam);
        #endregion

        #region Nested Class

        [StructLayout(LayoutKind.Explicit)]
        private class RILCELLTOWERINFO
        {
            [FieldOffset(0)]
            uint dwSize;
            [FieldOffset(4)]
            uint dwParams;
            [FieldOffset(8)]
            internal uint dwMobileCountryCode;
            [FieldOffset(12)]
            internal uint dwMobileNetworkCode;
            [FieldOffset(16)]
            internal uint dwLocationAreaCode;
            [FieldOffset(20)]
            internal uint dwCellID;
            [FieldOffset(24)]
            uint dwBaseStationID;
            [FieldOffset(28)]
            uint dwBroadcastControlChannel;
            [FieldOffset(32)]
            uint dwRxLevel;
            [FieldOffset(36)]
            uint dwRxLevelFull;
            [FieldOffset(40)]
            uint dwRxLevelSub;
            [FieldOffset(44)]
            uint dwRxQuality;
            [FieldOffset(48)]
            uint dwRxQualityFull;
            [FieldOffset(52)]
            uint dwRxQualitySub;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal class RILOPERATORNAMES
        {
            internal int cbSize;
            internal int dwParams;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x20)]
            internal byte[] szLongName;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x10)]
            internal byte[] szShortName;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x10)]
            internal byte[] szNumName;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            internal byte[] szCountryCode;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct RIL_DEVSPECIFIC_PARAMS
        {
            internal int dwFunctionID;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            internal byte[] lpInputParameters;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            internal byte[] lpOutputParameters;
        }

        [StructLayout(LayoutKind.Explicit)]
        private class RILSIGNALQUALITY
        {
            [FieldOffset(0)]
            uint dwSize;
            [FieldOffset(4)]
            uint dwParams;
            [FieldOffset(8)]
            internal int nSignalStrength;
            [FieldOffset(12)]
            int nMinSignalStrength;
            [FieldOffset(16)]
            int nMaxSignalStrength;
            [FieldOffset(20)]
            uint dwBitErrorRate;
            [FieldOffset(24)]
            int nLowSignalStrength;
            [FieldOffset(28)]
            int nHighSignalStrength;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal class RILOPERATORINFO
        {
            internal int cbSize;
            internal int dwParams;
            internal int dwIndex;
            internal int dwStatus;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x50)]
            internal RIL.RILOPERATORNAMES ronNames;
        }

        #endregion

        #region Implementations

        private static void CellDataCallback(uint dwCode, IntPtr hrCmdID, IntPtr lpData, uint cbData, uint dwParam)
        {
            _towerDetails = new RILCELLTOWERINFO();
            Marshal.PtrToStructure(lpData, _towerDetails);
            whCellTowerInfo.Set();
        }

        unsafe static byte[] byteArrayFromIntPtr(IntPtr ptr, ref int iRb)
        {
            if (ptr == IntPtr.Zero)
                return new byte[0];

            //Can't cast type 'System.IntPtr' to 'byte[]' :  byte[] tmp = (byte[])getString();
            //so we need to copy it manually:

            void* vPtr = ptr.ToPointer();
            byte* tmpP = (byte*)vPtr;
            int len = 0;
            for (len = 0; tmpP[len] != 0; len++) ;

            byte[] tmp = new byte[len];
            for (int i = 0; i < tmp.Length; i++)
                tmp[i] = tmpP[i];

            iRb = len;
            return tmp;
        }

        unsafe static byte[] byteArrayFromIntPtrEx(IntPtr ptr, int len, ref int iRb)
        {
            if (ptr == IntPtr.Zero)
                return new byte[0];

            //Can't cast type 'System.IntPtr' to 'byte[]' :  byte[] tmp = (byte[])getString();
            //so we need to copy it manually:

            void* vPtr = ptr.ToPointer();
            byte* tmpP = (byte*)vPtr;

            byte[] tmp = new byte[len];
            for (int i = 0; i < tmp.Length; i++)
                tmp[i] = tmpP[i];

            iRb = len;
            return tmp;
        }

        private static void SwitchOperatorCallback(uint dwCode, IntPtr hrCmdID, IntPtr lpData, uint cbData, uint dwParam)
        {
            whSwitchOperator.Set();
        }

        /// <summary>
        /// Fonction appelée en callback de la demande de liste de reseaux GSM environnant
        /// Lit les données recupérées par le modem et les met en forme dans la liste d'objets networks
        /// </summary>
        /// <param name="dwCode"></param>
        /// <param name="hrCmdID"></param>
        /// <param name="lpData"></param>
        /// <param name="cbData"></param>
        /// <param name="dwParam"></param>
        private static void OperatorDataCallback(uint dwCode, IntPtr hrCmdID, IntPtr lpData, uint cbData, uint dwParam)
        {
            _operatorNames = (RILOPERATORNAMES)Marshal.PtrToStructure(lpData, typeof(RILOPERATORNAMES));
            whCurrentOperator.Set();
        }

        private static void AllOperatorsListDataCallback(uint dwCode, IntPtr hrCmdID, IntPtr lpData, uint cbData, uint dwParam)
        {
            IntPtr ip = new IntPtr(lpData.ToInt32());
            int i = 0;
            for (i = 0; i < 1500; i++)
            {
                try
                {
                    RILOPERATORNAMES mlk = (RILOPERATORNAMES)(object)Marshal.PtrToStructure(lpData, typeof(RILOPERATORNAMES));
                    string szLongName = Encoding.ASCII.GetString(mlk.szLongName, 0, 32);
                    szLongName = szLongName.Replace("\0", "");

                    lpData = new IntPtr(lpData.ToInt32() + 64 * 5);
                }
                catch
                {

                }
            }

            lpData = new IntPtr(ip.ToInt32());
        }

        private static void SignalQualityCallback(uint dwCode, IntPtr hrCmdID, IntPtr lpData, uint cbData, uint dwParam)
        {
            _signalQuality = (RILSIGNALQUALITY)Marshal.PtrToStructure(lpData, typeof(RILSIGNALQUALITY));
            whSignalQuality.Set();
        }

        private string GetCurrentOperator()
        {
            uint dwFormats = 3;
            IntPtr radioInterfaceLayerHandle = IntPtr.Zero;
            IntPtr radioResponseHandle = RIL_Initialize(1, new RILRESULTCALLBACK(OperatorDataCallback), null, 0, 0, out radioInterfaceLayerHandle);
            radioResponseHandle = RIL_GetCurrentOperator(radioInterfaceLayerHandle, dwFormats);
            whCurrentOperator.WaitOne(WAIT_TIMEOUT, false);

            RIL_Deinitialize(radioInterfaceLayerHandle);

            string OperatorName = (Encoding.ASCII.GetString(_operatorNames.szLongName, 0, 32));
            return OperatorName;
        }

        private int GetSignalQuality()
        {
            IntPtr hRes = IntPtr.Zero;
            IntPtr hSignalQ = IntPtr.Zero;

            hRes = RIL_Initialize(1, new RILRESULTCALLBACK(SignalQualityCallback), null, 0, 0, out hSignalQ);
            hRes = RIL_GetSignalQuality(hSignalQ);

            whSignalQuality.WaitOne(WAIT_TIMEOUT, false);
            RIL_Deinitialize(hSignalQ);

            return _signalQuality.nSignalStrength;
        }
        
        #endregion

        #region Properties

        internal string CurrentOperator
        {
            get
            {
                return this.GetCurrentOperator().Replace("\0", string.Empty);
            }
        }

        internal int SignalStrength
        {
            get
            {
                return GetSignalQuality();
            }
        }

        private static void UnregisterFromNetworkCallback(uint dwCode, IntPtr hrCmdID, IntPtr lpData, uint cbData, uint dwParam)
        {
            whUnregisterFromNetwork.Set();
        }

        private int UnregisterDeviceFromNetwork()
        {
            IntPtr hRes = IntPtr.Zero;
            IntPtr hSignalQ = IntPtr.Zero;

            hRes = RIL_Initialize(1, new RILRESULTCALLBACK(UnregisterFromNetworkCallback), null, 0, 0, out hRil);
            hRes = RIL_UnregisterFromNetwork(hRil);

            whUnregisterFromNetwork.WaitOne(WAIT_TIMEOUT, false);
            RIL_Deinitialize(hRil);

            return 0;
        }

        internal int UnregisterFromNetwork()
        {
            return UnregisterDeviceFromNetwork();
        }

        private static void getSerialPortHandle(uint dwCode, IntPtr hrCmdID, IntPtr lpData, uint cbData, uint dwParam)
        {
            whSerialPortHandle.Set();
        }

        internal IntPtr GetSerialPortHandle()
        {
            //KO
            IntPtr hRil = IntPtr.Zero;
            IntPtr hRes = IntPtr.Zero;
            IntPtr lphSerial = IntPtr.Zero;

            hRes = RIL_Initialize(1, new RILRESULTCALLBACK(getSerialPortHandle), null, 0, 0, out hRil);
            if (hRes == IntPtr.Zero)
            {
                hRes = RIL_GetSerialPortHandle(hRil, out lphSerial);
                whSerialPortHandle.WaitOne(WAIT_TIMEOUT, false);
                RIL_Deinitialize(hRil);

                return lphSerial;
            }
            else
                return lphSerial = IntPtr.Zero;
        }

        private static void getPreferredOperatorList(uint dwCode, IntPtr hrCmdID, IntPtr lpData, uint cbData, uint dwParam)
        {
            string result = (string)Marshal.PtrToStringUni(lpData);

            whPreferredOperatorList.Set();
        }

        internal IntPtr GetPreferredOperatorList()
        {
            IntPtr hRil = IntPtr.Zero;
            IntPtr hRes = IntPtr.Zero;
            IntPtr lphSerial = IntPtr.Zero;

            hRes = RIL_Initialize(1, new RILRESULTCALLBACK(getPreferredOperatorList), null, 0, 0, out hRil);
            if (hRes == IntPtr.Zero)
            {
                hRes = RIL_GetPreferredOperatorList(hRil, IntPtr.Zero);
                whPreferredOperatorList.WaitOne(WAIT_TIMEOUT, false);
                RIL_Deinitialize(hRil);

                return lphSerial;
            }
            else
                return lphSerial = IntPtr.Zero;
        }

        unsafe private static void getDevSpecific(uint dwCode, IntPtr hrCmdID, IntPtr lpData, uint cbData, uint dwParam)
        {
            _resAT = "";
            if (cbData > 0)
            {
                byte* tmp = (byte*)lpData.ToPointer();


                for (int i = 0; i < cbData; i++)
                    _resAT += (char)tmp[i];
            }

            whDevSpecific.Set();
        }

        private static void getDevSpecificResult(uint dwCode, IntPtr lpData, uint cbData, uint dwParam)
        {

        }

        static RILRESULTCALLBACK GetDevSpecificCallback = new RILRESULTCALLBACK(getDevSpecific);
        static RILNOTIFYCALLBACK GetDevSpecificResult = new RILNOTIFYCALLBACK(getDevSpecificResult);

        static unsafe internal string SendAtCommand(string cmd)
        {
            IntPtr hRil = IntPtr.Zero;
            IntPtr hRes = IntPtr.Zero;
            IntPtr lphSerial = IntPtr.Zero;

            DateTime cmdDate = DateTime.Now;

            cmd += "\r";
            hRes = RIL_Initialize(1, GetDevSpecificCallback, GetDevSpecificResult, RIL_NCLASS_DEVSPECIFIC, 0, out hRil);
            if (hRes == IntPtr.Zero)
            {
                IntPtr dwSize = new IntPtr(260);
                byte[] buffer = new byte[260];

                for (int i = 0; i < 260; i++)
                    buffer[0] = 0;

                buffer[0] = Convert.ToByte(RIL_DEVSPECIFIC_SEND_ATC);
                for (int i = 0; i < cmd.Length; i++)
                    buffer[4 + i] = Convert.ToByte(cmd[i]);

                fixed (byte* p = buffer)
                {
                    IntPtr hDev = RIL_DevSpecific(hRil, (IntPtr)p, dwSize);
                    whDevSpecific.WaitOne(WAIT_TIMEOUT, false);
                }

                RIL_Deinitialize(hRil);
            }

            return _resAT;
        }

        
        #endregion

        private static List<GSMNetwork> networks = new List<GSMNetwork>();

        /// <summary>
        /// Récupère la liste des réseaux environnant
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="arrOperatorInfo"></param>
        /// <returns></returns>
        static unsafe internal List<GSMNetwork> GetNetworksList()
        {
            IntPtr radioInterfaceLayerHandle = IntPtr.Zero;
            IntPtr radioResponseHandle = RIL_Initialize(1, new RILRESULTCALLBACK(OperatorListCallback), null, 0, 0, out radioInterfaceLayerHandle);
            if (radioResponseHandle == IntPtr.Zero)
            {
                radioResponseHandle = RIL_GetOperatorList(radioInterfaceLayerHandle);

                if (radioResponseHandle.ToInt64() >= IntPtr.Zero.ToInt64())
                    whOperatorList.WaitOne(WAIT_TIMEOUT, false);
            }

            RIL_Deinitialize(radioInterfaceLayerHandle);

            return networks;
        }

        /// <summary>
        /// Fonction appelée en callback de la demande de liste de reseaux GSM environnant
        /// Lit les données recupérées par le modem et les met en forme dans la liste d'objets networks
        /// </summary>
        /// <param name="dwCode"></param>
        /// <param name="hrCmdID"></param>
        /// <param name="lpData"></param>
        /// <param name="cbData"></param>
        /// <param name="dwParam"></param>
        private static void OperatorListCallback(uint dwCode, IntPtr hrCmdID, IntPtr lpData, uint cbData, uint dwParam)
        {
            networks.Clear();

            IntPtr ip = new IntPtr(lpData.ToInt32());
            uint nCount = cbData / 0x60;

            for (int i = 0; i < nCount; i++)
            {
                try
                {
                    RILOPERATORINFO rInfo = new RILOPERATORINFO();
                    rInfo.cbSize = Marshal.ReadInt32(lpData);
                    lpData = new IntPtr(lpData.ToInt32() + 0x4);
                    rInfo.dwParams = Marshal.ReadInt32(lpData);
                    lpData = new IntPtr(lpData.ToInt32() + 0x4);
                    rInfo.dwIndex = Marshal.ReadInt32(lpData);
                    lpData = new IntPtr(lpData.ToInt32() + 0x4);
                    rInfo.dwStatus = Marshal.ReadInt32(lpData);
                    lpData = new IntPtr(lpData.ToInt32() + 0x4);

                    rInfo.ronNames = new RILOPERATORNAMES();
                    rInfo.ronNames.cbSize = Marshal.ReadInt32(lpData);
                    lpData = new IntPtr(lpData.ToInt32() + 0x4);
                    rInfo.ronNames.dwParams = Marshal.ReadInt32(lpData);
                    lpData = new IntPtr(lpData.ToInt32() + 0x4);

                    int iRb = 0;
                    rInfo.ronNames.szLongName = byteArrayFromIntPtrEx(lpData, 0x20, ref iRb);
                    lpData = new IntPtr(lpData.ToInt32() + 0x20);

                    rInfo.ronNames.szShortName = byteArrayFromIntPtrEx(lpData, 0x10, ref iRb);
                    lpData = new IntPtr(lpData.ToInt32() + 0x10);

                    rInfo.ronNames.szNumName = byteArrayFromIntPtrEx(lpData, 0x10, ref iRb);
                    lpData = new IntPtr(lpData.ToInt32() + 0x10);

                    rInfo.ronNames.szCountryCode = byteArrayFromIntPtrEx(lpData, 0x8, ref iRb);
                    lpData = new IntPtr(lpData.ToInt32() + 0x8);

                    iRb = 0x20;
                    string opp = Encoding.ASCII.GetString(rInfo.ronNames.szLongName, 0, iRb);
                    opp = opp.Replace("\0", "");

                    networks.Add(new GSMNetwork()
                    {
                        BroadcastName = opp,
                        Info = rInfo,
                        NetworkCode = Encoding.ASCII.GetString(rInfo.ronNames.szNumName, 0, 8).Replace("\0", ""),
                    });
                }
                catch (System.Exception)
                {
                    //TODO : Creer des exceptions specifiques
                    //Log.WriteLog("OperatorListCallback: " + e.Message);
                    return;
                }

            }

            lpData = new IntPtr(ip.ToInt32());
            whOperatorList.Set();
        }

        /// <summary>
        /// Passage sur un réseau donné
        /// </summary>
        /// <param name="network"></param>
        /// <returns></returns>
        static unsafe internal bool SwitchOperator(GSMNetwork network)
        {
            IntPtr radioInterfaceLayerHandle = IntPtr.Zero;
            IntPtr radioResponseHandle = RIL_Initialize(1, new RILRESULTCALLBACK(SwitchOperatorCallback), null, 0, 0, out radioInterfaceLayerHandle);
            RIL_RegisterOnNetwork(radioInterfaceLayerHandle, 0x00000002, network.Info.ronNames);
            whSwitchOperator.WaitOne(WAIT_TIMEOUT, false);
            RIL_Deinitialize(radioInterfaceLayerHandle);

            return true;
        }
    }
}