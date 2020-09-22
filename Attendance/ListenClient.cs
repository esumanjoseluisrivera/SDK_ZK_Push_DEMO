using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Utils;

namespace Attendance
{
    /// <summary>Server Listen
    /// </summary>
    public class ListenClient
    {
        TcpListener tcp;
        const int MAXBUFFERSIZE = 1024 * 1024 * 2;
        /// <summary>
        /// listenling port
        /// </summary>
        private int port = 80;
        public int Port
        {
            get { return port; }
            set { port = value; }
        }

        /// <summary>
        /// server IP
        /// </summary>
        private string serverIP = string.Empty;
        public string ServerIP
        {
            get { return serverIP; }
            set { serverIP = value; }
        }

        /// <summary>
        /// is listenling
        /// </summary>
        private bool listening = false;
        public bool Listening
        {
            get { return listening; }
        }

        #region event

        /// <summary>
        /// error event
        /// </summary>
        /// <param name="imgReceive"></param>
        /// <param name="empPin"></param>
        public event Action<string> OnError;

        /// <summary>
        /// new punch event
        /// </summary>
        public event Action<AttLogModel> OnNewAttLog;

        /// <summary>
        /// new oplog event
        /// </summary>
        public event Action<OpLogModel> OnNewOpLog;

        /// <summary>
        /// new oplog event
        /// </summary>
        public event Action<ErrorLogModel> OnNewErrorLog;

        /// <summary>
        /// new user event
        /// </summary>
        /// <param name="user"></param>
        public event Action<UserInfoModel> OnNewUser;

        /// <summary>
        /// new bio fp template
        /// </summary>

        public event Action<TmpFPModel> OnNewFP;

        /// <summary>
        /// new face template
        /// </summary>

        public event Action<TmpFaceModel> OnNewFace;
        /// <summary>
        /// new Palm template
        /// </summary>

        public event Action<TmpBioDataModel> OnNewPalm;
        /// <summary>
        /// new biophoto
        /// </summary>

        public event Action<TmpBioPhotoModel> OnNewBioPhoto;

        /// <summary>
        /// new workcode
        /// </summary>

        public event Action<WorkCodeModel> OnNewWorkcode;

        /// <summary>
        /// new machine
        /// </summary>

        public event Action<string> OnNewMachine;

        /// <summary>
        /// Device Info Sync
        /// </summary>

        public event Action<DeviceModel> OnDeviceSync;


        /// <summary>
        /// Receive Data event
        /// </summary>
        public event Action<string> OnReceiveDataEvent;

        /// <summary>
        /// Send Data event
        /// </summary>
        public event Action<string> OnSendDataEvent;

        #endregion

        #region Main TCP listening process

        /// <summary>
        /// Start listening
        /// </summary>
        public void StartListening()
        {
            try
            {
                if (tcp == null)
                {
                    this.tcp = new TcpListener(IPAddress.Parse(serverIP), port);
                }
                this.tcp.Start();
                listening = true;
                Socket mySocket = null;
                
                while (listening)
                {

                    // Blocks until a client has connected to the server 
                    try
                    {

                        mySocket = this.tcp.AcceptSocket();
                        mySocket.ReceiveBufferSize = MAXBUFFERSIZE;
                        mySocket.SendBufferSize = MAXBUFFERSIZE;
                        Thread.Sleep(500);
                        if (mySocket.Available <= 0)
                            continue;
                        byte[] bReceive = new byte[MAXBUFFERSIZE];
                        mySocket.Receive(bReceive);

                        Analysis(bReceive, mySocket);
                    }
                    catch (Exception)
                    {
                    }
                }

                this.tcp.Stop();
            }
            catch
            {
                listening = false;
                string errMessage = string.Format("Please be sure that you are listening to the port number of your own PC." +
                "And {0} port is not occupied by other application or stopped by firewall.", port);

                if (OnError != null)
                {
                    OnError(errMessage);
                }
            }
        }

        /// <summary>
        /// stop listening
        /// </summary>
        public void StopListening()
        {
            if (listening)
            {
                listening = false;
                this.tcp.Stop();
            }
        }

        /// <summary>
        /// Analysis which kind of request from the iclock Devices
        /// </summary>
        /// <param name="bReceive"></param>
        /// <param name="endsocket"></param>
        private void Analysis(byte[] bReceive, Socket endsocket)
        {
            string strReceive = Encoding.ASCII.GetString(bReceive).TrimEnd().TrimEnd('\0');

            if (null != OnReceiveDataEvent)
            {
                OnReceiveDataEvent(strReceive);
            }

            if (strReceive.IndexOfEx("cdata?") > 0)
            {
                cdataProcess(bReceive, endsocket);
            }
            else if (strReceive.IndexOfEx("getrequest?") > 0)
            {
                GetRequestProcess(bReceive, endsocket);
            }
            else if (strReceive.IndexOfEx("devicecmd?") > 0)
            {
                DeviceCmdProcess(bReceive, endsocket);
            }
            else if (strReceive.IndexOfEx("ping?") > 0)
            {
                SendDataToDevice("200 OK", "OK\r\n", ref endsocket);
                endsocket.Close();
            }
            else
            {
                UnknownCmdProcess(endsocket);
                if (OnError != null)
                {
                    OnError("UnKnown message from device: " + strReceive);
                }
            }
        }


        /// <summary>
        /// Get Stamp
        /// </summary>
        /// <param name="sBuffer"></param>
        /// <param name="numberstr"></param>
        private void GetTimeNumber(string sBuffer, ref string numberstr)
        {
            numberstr = "";

            for (int i = 0; i < sBuffer.Length; i++)
            {
                if (sBuffer[i] > 47 && sBuffer[i] < 58)
                {
                    numberstr += sBuffer[i];
                }
                else
                {
                    break;
                }
            }
        }
        /// <summary>
        /// Get Value By name, Value=Name
        /// </summary>
        private string GetValueByNameInPushHeader(string buffer, string Name)
        {
            string[] splitStr = buffer.Split('&', '?', ' ');
            if (splitStr.Length <= 0)
            {
                return null;
            }

            foreach (string tmpStr in splitStr)
            {
                if (tmpStr.IndexOfEx(Name + "=") >= 0)
                {
                    return tmpStr.Substring(tmpStr.IndexOfEx(Name + "=") + Name.Length + 1);
                }
            }
            return null;
        }

        private int GetTimeFormTimeZone(string timezone)
        {
            string[] spistr = null;

            try
            {
                if ('-' == timezone[0])
                {
                    timezone = timezone.Substring(1);
                    spistr = timezone.Split(':');
                    if (spistr.Length == 2)
                    {
                        return -1 * (Convert.ToInt32(spistr[0]) * 60 + Convert.ToInt32(spistr[1]));
                    }
                    else if (spistr.Length == 1)
                    {
                        return -1 * (Convert.ToInt32(spistr[0]) * 60);
                    }
                }
                else
                {
                    spistr = timezone.Split(':');
                    if (spistr.Length == 2)
                    {
                        return Convert.ToInt32(spistr[0]) * 60 + Convert.ToInt32(spistr[1]);
                    }
                    else if (spistr.Length == 1)
                    {
                        return Convert.ToInt32(spistr[0]) * 60;
                    }
                }
            }
            catch { }
            return 0;
        }

        /// <summary>
        /// Get Device Init Info
        /// </summary>
        private string GetDeviceInitInfo(DeviceModel device)
        {
            StringBuilder RetDeviceInfo = new StringBuilder();
            int time = GetTimeFormTimeZone(device.TimeZone);
            RetDeviceInfo.AppendFormat("GET OPTION FROM:{0}\n", device.DevSN);
            RetDeviceInfo.AppendFormat("Stamp={0}\n", device.AttLogStamp);
            RetDeviceInfo.AppendFormat("OpStamp={0}\n", device.OperLogStamp);
            RetDeviceInfo.AppendFormat("PhotoStamp={0}\n", device.AttPhotoStamp);
            RetDeviceInfo.AppendFormat("TransFlag={0}\n", device.TransFlag);
            RetDeviceInfo.AppendFormat("ErrorDelay={0}\n", device.ErrorDelay);
            RetDeviceInfo.AppendFormat("Delay={0}\n", device.Delay);
            RetDeviceInfo.AppendFormat("TimeZone={0}\n", time);
            RetDeviceInfo.AppendFormat("TransTimes={0}\n", device.TransTimes);
            RetDeviceInfo.AppendFormat("TransInterval={0}\n", device.TransInterval);
            RetDeviceInfo.AppendFormat("SyncTime={0}\n", device.SyncTime);
            RetDeviceInfo.AppendFormat("Realtime={0}\n", device.Realtime);
            RetDeviceInfo.AppendFormat("ServerVer={0} {1}\n", ServerInfo.VERSION, Tools.GetDateTimeNow().ToShortDateString());
            RetDeviceInfo.AppendFormat("PushProtVer={0}\n", ServerInfo.PushProtVer);
            RetDeviceInfo.AppendFormat("PushOptionsFlag={0}\n", ServerInfo.PushOptionsFlag);
            RetDeviceInfo.AppendFormat("ATTLOGStamp={0}\n", device.AttLogStamp);
            RetDeviceInfo.AppendFormat("OPERLOGStamp={0}\n", device.OperLogStamp);
            RetDeviceInfo.AppendFormat("ATTPHOTOStamp={0}\n", device.AttPhotoStamp);
            RetDeviceInfo.AppendFormat("ServerName=Logtime Server\n");
            //支持多模态生物特征模板参数， type类型进行按位定义
            RetDeviceInfo.AppendFormat("MultiBioDataSupport={0}\n", device.MultiBioDataSupport);
            return RetDeviceInfo.ToString();
        }

        DeviceBll _deviceBll = null;
        public DeviceBll DeviceBll
        {
            get
            {
                if (_deviceBll == null)
                    _deviceBll = new DeviceBll();
                return _deviceBll;
            }
        }

        DeviceCmdBll _deviceCmdBll = null;
        public DeviceCmdBll DeviceCmdBll
        {
            get
            {
                if (_deviceCmdBll == null)
                    _deviceCmdBll = new DeviceCmdBll();
                return _deviceCmdBll;
            }
        }

        /// <summary>
        /// Inilialize Device connection
        /// </summary>
        private string InitDeviceConnect(string DevSN, ref string RepString)
        {
            DeviceModel machine = DeviceBll.Get(DevSN);
            if (null == machine)
            {
                if (OnNewMachine != null)
                {
                    OnNewMachine(DevSN);
                    RepString = "OK\r\n";
                    return "200 OK";
                }
                else
                {
                    RepString = "Device Unauthorized";
                    return "401 Unauthorized";
                }
            }
            else
            {
                RepString = GetDeviceInitInfo(machine);
                return "200 OK";
            }
        }

        /// <summary>
        /// Response cdata request for iclock Devices
        /// </summary>
        /// <param name="bReceive"></param>
        /// <param name="remoteSocket"></param>
        private void cdataProcess(byte[] bReceive, Socket remoteSocket)
        {
            string sBuffer = Encoding.ASCII.GetString(bReceive).TrimEnd().TrimEnd('\0');
            string SN = GetValueByNameInPushHeader(sBuffer, "SN");
            string ReplyCode = "200 OK";
            string strReply = "OK";

            if (sBuffer.Substring(0, 3) == "GET") // iclock option
            {
                if (sBuffer.IndexOfEx("options=all", 0) > 0)
                {
                    ReplyCode = InitDeviceConnect(SN, ref strReply);
                    SendDataToDevice(ReplyCode, strReply, ref remoteSocket);
                    remoteSocket.Close();
                    return;
                }
                else
                {
                    ReplyCode = "400 Bad Request";
                    strReply = "Unknow Command";
                    SendDataToDevice(ReplyCode, strReply, ref remoteSocket);
                    remoteSocket.Close();
                    return;
                }
            }

            if (sBuffer.Substring(0, 4) == "POST")
            {
                // Only PUSH SDK Ver 2.0.1 (In Version 1.0 String for AttLog have diferent format, example: CHECK LOG: stamp=392232960 1       2018-03-14 17:39:00     0       0       0       1)
                //table=ATTLOG
                if (sBuffer.IndexOfEx("Stamp", 1) > 0
                    && sBuffer.IndexOfEx("OPERLOG", 1) < 0
                    && sBuffer.IndexOfEx("ATTLOG", 1) > 0
                    && sBuffer.IndexOfEx("OPLOG", 1) < 0) // Upload AttLog
                {
                    AttLog(sBuffer);
                }

                //table=OPERLOG
                if (sBuffer.IndexOfEx("Stamp", 1) > 0
                    && sBuffer.IndexOfEx("OPERLOG", 1) > 0
                    && sBuffer.IndexOfEx("ATTLOG", 1) < 0
                    && sBuffer.IndexOfEx("USERPIC", 1) < 0)
                {
                    if (sBuffer.IndexOfEx("Expect: 100-continue") > 0
                        && sBuffer.IndexOfEx("FP", 1) < 0
                        && sBuffer.IndexOfEx("FACE", 1) < 0)
                    {
                        ReplyCode = "100 Continue";
                        strReply = "Continue";
                        SendDataToDevice(ReplyCode, strReply, ref remoteSocket);
                        Thread.Sleep(5000);
                        remoteSocket.Close();
                        return;
                    }
               
                    OperLog(sBuffer);


                }
                //table=BIODATA
                if (sBuffer.IndexOfEx("Stamp", 1) > 0
                    && sBuffer.IndexOfEx("BIODATA", 1) > 0)
                {
                    BioData(sBuffer);
                }
                //table=ERRORLOG
                if (sBuffer.IndexOfEx("Stamp", 1) > 0
                    && sBuffer.IndexOfEx("ERRORLOG", 1) > 0
                    && sBuffer.IndexOfEx("ATTLOG", 1) < 0)
                {
                    Errorlog(sBuffer);
                }

                //table=ATTPHOTO
                if (sBuffer.IndexOfEx("Stamp", 1) > 0
                    && sBuffer.IndexOfEx("ATTPHOTO", 1) > 0)  /* upload attphoto */
                {
                    if (sBuffer.IndexOfEx("Expect: 100-continue") > 0
                        && sBuffer.IndexOfEx("PIN") < 0)
                    {
                        ReplyCode = "100 Continue";
                        strReply = "Continue";
                        SendDataToDevice(ReplyCode, strReply, ref remoteSocket);
                        Thread.Sleep(5000);
                        remoteSocket.Close();
                        return;
                    }
                    AttPhoto(bReceive);
                }

                //table=USERPIC
                if (sBuffer.IndexOfEx("Stamp", 1) > 0 && sBuffer.IndexOfEx("USERPIC", 1) > 0) // Upload user Info
                {
                    UserPicLog(sBuffer);
                }

                //options 推送配置信息
                if (sBuffer.IndexOfEx("table=options", 1) > 0) // Upload options Info
                {
                    Options(sBuffer);
                }

                /*
                //customer
                if (sBuffer.IndexOfEx("WORKCODE", 1) > 0) // Upload workcode Info
                {
                    WorkcodeLog(sBuffer);
                }*/

                SendDataToDevice(ReplyCode, strReply, ref remoteSocket);
                remoteSocket.Close();

            }
        }

        /// <summary>
        /// Update device Information
        /// </summary>
        private void UpDateDeviceInfo(DeviceModel device, string strDevInfo)
        {
            string[] splitStr = strDevInfo.Split(',');

            try
            {
                device.DevFirmwareVersion = splitStr[0].Replace("%20", " ");
                device.UserCount = Convert.ToInt32(splitStr[1]);
                //device.FpCount = Convert.ToInt32(splitStr[2]);
                device.AttCount = Convert.ToInt32(splitStr[3]);
                device.DevIP = splitStr[4];
            }
            catch
            {
                if (OnError != null)
                {
                    OnError("Device Info Error:" + strDevInfo);
                }
            }

            if (DeviceBll.Update(device) > 0)
            {
                if (OnDeviceSync != null)
                {
                    OnDeviceSync(device);
                }
            }
        }

        /// <summary>
        /// Reponse get request for iclock Devices
        /// </summary>
        /// <param name="bReceive"></param>
        /// <param name="remoteSocket"></param>
        private void GetRequestProcess(byte[] bReceive, Socket remoteSocket)
        {
            string sBuffer = Encoding.GetEncoding("gb2312").GetString(bReceive);
            string cmdstring = "OK\r\n";
            string SN = GetValueByNameInPushHeader(sBuffer, "SN");
            string ReplyCode = "200 OK";
            DeviceModel device = DeviceBll.Get(SN);

            if (null == device)
            {
                ReplyCode = "401 Unauthorized";
                cmdstring = "Device Unauthorized";
            }
            else
            {
                if (null != OnDeviceSync)
                {
                    OnDeviceSync(device);
                }

                string strDevInfo = GetValueByNameInPushHeader(sBuffer, "INFO");
                if (string.IsNullOrEmpty(strDevInfo))
                {
                    cmdstring = DeviceCmdBll.Send(SN);
                    cmdstring = cmdstring + "\r\n";
                }
                else
                {
                    UpDateDeviceInfo(device, strDevInfo);
                    cmdstring = "OK\r\n";
                }
            }
            SendDataToDevice(ReplyCode, cmdstring, ref remoteSocket);
            remoteSocket.Close();
        }

        /// <summary>
        /// Response Device cmd request for iclock Devices
        /// </summary>
        /// <param name="bReceive"></param>
        private void DeviceCmdProcess(byte[] bReceive, Socket remoteSocket)
        {
            string sBuffer = Encoding.ASCII.GetString(bReceive).TrimEnd('\0');
            string strReceive = sBuffer;
            string errMessage = string.Empty;
            string machineSN = sBuffer.Substring(sBuffer.IndexOfEx("SN=") + 3);
            string SN = machineSN.Split('&')[0];

            int index = strReceive.IndexOfEx("ID=");
            SendDataToDevice("200 OK", "OK\r\n", ref remoteSocket);
            remoteSocket.Close();

            _deviceCmdBll.Update(strReceive.Substring(index));
        }

        private void UnknownCmdProcess(Socket remoteSocket)
        {
            SendDataToDevice("401 Unknown", "Unknown DATA", ref remoteSocket);
            remoteSocket.Close();
        }

        /// <summary>
        /// Server reponses to iclock Devices
        /// </summary>
        /// <param name="iTotBytes"></param>
        /// <param name="sStatusCode"></param>
        /// <param name="mySocket"></param>
        /// Date, Format: Thu, 19 Feb 2020 15:52:10 GMT+08:00
        private void SendDataToDevice(string sStatusCode, string sDataStr, ref Socket mySocket)
        {
            byte[] bData = Encoding.GetEncoding("gb2312").GetBytes(sDataStr);
            string sHeader = "HTTP/1.1 " + sStatusCode + "\r\n";
            sHeader = sHeader + "Content-Type: text/plain\r\n";
            sHeader = sHeader + "Accept-Ranges: bytes\r\n";
            sHeader = sHeader + "Date: " + Tools.GetDateTimeNow().ToUniversalTime().ToString("r") + "\r\n";
            sHeader = sHeader + "Content-Length: " + bData.Length + "\r\n\r\n";

            SendToBrowser(Encoding.GetEncoding("gb2312").GetBytes(sHeader), ref mySocket);
            SendToBrowser(bData, ref mySocket);
        }

        private void SendToBrowser(Byte[] bSendData, ref Socket mySocket)
        {
            int numBytes = 0;
            string errMessage = string.Empty;

            try
            {
                if (mySocket.Connected)
                {
                    if (null != OnSendDataEvent)
                    {
                        OnSendDataEvent(Encoding.ASCII.GetString(bSendData));
                    }

                    if ((numBytes = mySocket.Send(bSendData, bSendData.Length, 0)) == -1)
                    {
                        errMessage = "Socket Error: Cannot Send Packet";
                    }
                    else
                    {
                    }
                }
                else
                {
                    errMessage = "Link Failed...";
                }
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
            }

            if (!string.IsNullOrEmpty(errMessage))
            {
                if (OnError != null)
                {
                    OnError(errMessage);
                }
            }
        }
        #endregion

        #region resolve data of table=OPERLOG

        //将设备传来的字符串分割为各个字段之后再封装为一个操作记录的对象
        private OpLogModel CreateOplog(string oplog, string machineSN)
        {
            string[] oplogstr = oplog.Split('\t');
            OpLogModel operlog = new OpLogModel();

            string Optype_tem = oplogstr[0];
            operlog.OpType = Optype_tem.Substring(6);
            operlog.Operator = oplogstr[1];
            operlog.OpTime = Convert.ToDateTime(oplogstr[2]);
            operlog.Obj1 = oplogstr[3];
            operlog.Obj2 = oplogstr[4];
            operlog.Obj3 = oplogstr[5];
            operlog.Obj4 = oplogstr[6];
            operlog.User = "0";
            operlog.DeviceID = machineSN;

            return operlog;
        }


        //封装通用指纹信息
        private TmpFPModel CreatFP(string template, string SN, bool isBioData)
        {
            TmpFPModel templateModel = new TmpFPModel();
            if (isBioData)
            {
                template = Tools.Replace(template, "BIODATA", "");
                Dictionary<string, string> dic = Tools.GetKeyValues(template);

                templateModel.Pin = Tools.GetValueFromDic(dic, "PIN");
                templateModel.Fid = Tools.GetValueFromDic(dic, "No");
                templateModel.Valid = Tools.GetValueFromDic(dic, "Valid");
                templateModel.Duress = Tools.GetValueFromDic(dic, "Duress");
                string MajorVer = Tools.GetValueFromDic(dic, "MajorVer");

                //从数据库中获取此设备支持的指纹版本号
                if (string.IsNullOrEmpty(MajorVer))
                {
                    DeviceModel model = _deviceBll.Get(SN);
                    if (null != model)
                    {
                        MajorVer = model.GetBioVersion(BioType.FingerPrint).Split('.')[0];
                    }
                }
                templateModel.MajorVer = MajorVer;
                templateModel.Tmp = Tools.GetValueFromDic(dic, "TMP");
            }
            else
            {
                template = Tools.Replace(template, "FP", "");
                Dictionary<string, string> dic = Tools.GetKeyValues(template);

                templateModel.Pin = Tools.GetValueFromDic(dic, "PIN");
                templateModel.Fid = Tools.GetValueFromDic(dic, "FID");
                templateModel.Size = Tools.TryConvertToInt32(Tools.GetValueFromDic(dic, "Size"));
                templateModel.Valid = Tools.GetValueFromDic(dic, "Valid");
                templateModel.Tmp = Tools.GetValueFromDic(dic, "TMP");
                if (templateModel.Tmp.StartsWith("oco"))
                    templateModel.MajorVer = "9";
                else
                    templateModel.MajorVer = "10";
            }

            return templateModel;
        }
        //封装Face模板信息
        private TmpFaceModel CreatFace(string template, bool isBioData)
        {
            TmpFaceModel tmpFace = new TmpFaceModel();
            if (isBioData)
            {
                template = Tools.Replace(template, "BIODATA", "");
                Dictionary<string, string> dic = Tools.GetKeyValues(template);

                tmpFace.Pin = Tools.GetValueFromDic(dic, "PIN");
                tmpFace.Fid = Tools.GetValueFromDic(dic, "No");
                tmpFace.Valid = Tools.GetValueFromDic(dic, "Valid");

                string MajorVer = Tools.GetValueFromDic(dic, "MajorVer");
                string MinorVer = Tools.GetValueFromDic(dic, "MinorVer");
                tmpFace.Ver = $"{MajorVer}.{MinorVer}";
                tmpFace.Tmp = Tools.GetValueFromDic(dic, "TMP");
            }
            else
            {
                template = Tools.Replace(template, "FACE", "");
                Dictionary<string, string> dic = Tools.GetKeyValues(template);

                tmpFace.Pin = Tools.GetValueFromDic(dic, "PIN");
                tmpFace.Fid = Tools.GetValueFromDic(dic, "FID");
                tmpFace.Size = Tools.TryConvertToInt32(Tools.GetValueFromDic(dic, "SIZE"));
                tmpFace.Valid = Tools.GetValueFromDic(dic, "VALID");
                tmpFace.Tmp = Tools.GetValueFromDic(dic, "TMP");
            }

            return tmpFace;
        }
        //封装掌静脉模板信息
        private TmpBioDataModel CreatPalm(string template)
        {
            template = Tools.Replace(template, "BIODATA", "");
            Dictionary<string, string> dic = Tools.GetKeyValues(template);

            TmpBioDataModel tmpPalm = new TmpBioDataModel();
            tmpPalm.Pin = Tools.GetValueFromDic(dic, "PIN");
            tmpPalm.No = Tools.GetValueFromDic(dic, "No");
            tmpPalm.Index = Tools.GetValueFromDic(dic, "Index");
            tmpPalm.Valid = Tools.GetValueFromDic(dic, "Valid");
            tmpPalm.Duress = Tools.GetValueFromDic(dic, "Duress");
            tmpPalm.Type = Tools.GetValueFromDic(dic, "Type");
            tmpPalm.MajorVer = Tools.GetValueFromDic(dic, "MajorVer");
            tmpPalm.MinorVer = Tools.GetValueFromDic(dic, "MinorVer");
            tmpPalm.Format = Tools.GetValueFromDic(dic, "Format");
            tmpPalm.Tmp = Tools.GetValueFromDic(dic, "TMP");

            return tmpPalm;
        }
        //封装比对照片
        private TmpBioPhotoModel CreatBioPhoto(string bioPhotoString)
        {
            bioPhotoString = Tools.Replace(bioPhotoString, "BIOPHOTO", "");
            Dictionary<string, string> dic = Tools.GetKeyValues(bioPhotoString);

            TmpBioPhotoModel biophoto = new TmpBioPhotoModel();
            biophoto.Pin = Tools.GetValueFromDic(dic, "PIN");
            biophoto.FileName = Tools.GetValueFromDic(dic, "FileName");
            biophoto.Type = Tools.GetValueFromDic(dic, "Type");
            biophoto.Size = Tools.TryConvertToInt32(Tools.GetValueFromDic(dic, "Size"));
            biophoto.Content = Tools.GetValueFromDic(dic, "Content");

            return biophoto;
        }
        //封装用户信息
        private UserInfoModel CreatUserInfo(string userstring)
        {
            userstring = Tools.Replace(userstring, "USER", "");
            Dictionary<string, string> dic = Tools.GetKeyValues(userstring);

            UserInfoModel user = new UserInfoModel();
            user.PIN = Tools.GetValueFromDic(dic, "PIN");
            user.UserName = Tools.GetValueFromDic(dic, "Name");
            user.Pri = Tools.GetValueFromDic(dic, "Pri");
            user.Passwd = Tools.GetValueFromDic(dic, "Passwd");
            user.IDCard = Tools.GetValueFromDic(dic, "Card");
            user.Grp = Tools.GetValueFromDic(dic, "Grp");
            user.TZ = Tools.GetValueFromDic(dic, "TZ");

            return user;
        }

        /// <summary>
        /// save OpLog
        /// </summary>
        /// <param name="oplog"></param>
        private void SaveOperLog(string oplog, string machineSN)
        {
            if (OnNewOpLog != null)
            {
                OnNewOpLog(CreateOplog(oplog, machineSN));
            }
        }


        /// <summary>
        /// save  FP
        /// </summary>
        /// <param name="enfplog">指纹数据</param>
        /// <param name="SN">设备序列号</param>
        /// <param name="isBioData">是否一体化模板</param>
        private void SaveFP(string enfplog, string SN, bool isBioData)
        {
            if (enfplog.IndexOfEx("PIN", 0, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                if (OnNewFP != null)
                {
                    OnNewFP(CreatFP(enfplog, SN, isBioData));
                }
            }
        }
        /// <summary>
        /// save face
        /// </summary>
        /// <param name="enfacelog">面部数据</param>
        /// <param name="isBioData">是否一体化模板</param>
        private void SaveFace(string enfacelog, bool isBioData)
        {
            if (enfacelog.IndexOfEx("PIN", 0, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                if (OnNewFace != null)
                {
                    OnNewFace(CreatFace(enfacelog, isBioData));
                }
            }
        }
        /// <summary>
        /// save Palm
        /// </summary>
        /// <param name="enfacelog">面部数据</param>
        /// <param name="isBioData">是否一体化模板</param>
        private void SavePalm(string enPalmlog)
        {
            if (enPalmlog.IndexOfEx("PIN", 0, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                if (OnNewPalm != null)
                {
                    OnNewPalm(CreatPalm(enPalmlog));
                }
            }
        }
        /// <summary>
        /// save user
        /// </summary>
        /// <param name="usinlog"></param>
        /// <param name="stamp"></param>
        private void SaveUserinfo(string usinlog)
        {
            if (usinlog.IndexOfEx("PIN", 0, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                if (OnNewUser != null)
                {
                    OnNewUser(CreatUserInfo(usinlog));
                }
            }
        }
        private void SaveBioPhoto(string bioPhoto)
        {
            if (bioPhoto.IndexOfEx("PIN", 0, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                if (OnNewBioPhoto != null)
                {
                    OnNewBioPhoto(CreatBioPhoto(bioPhoto));
                }
            }
        }
        //将table=OPERLOG后面的数据进行分解，包括OPLOG，USER，FP
        private void SeparateOPERLOGData(string datastr, string SN)
        {
            try
            {
                string[] strlist = datastr.Split('\n');
                foreach (string i in strlist)
                {
                    string tmpstr = i.ToString();

                    if (tmpstr.IndexOfEx("OPLOG ") >= 0)//处理操作记录
                    {
                        SaveOperLog(tmpstr, SN);
                    }
                    else if (tmpstr.Split(' ')[0] == "USER")//处理用户信息
                    {
                        SaveUserinfo(tmpstr);
                    }
                    else if (tmpstr.Split(' ')[0] == "FP")//处理用户指纹
                    {
                        SaveFP(tmpstr, SN, false);
                    }
                    else if (tmpstr.Split(' ')[0] == "FACE")//处理用户面部模板
                    {
                        SaveFace(tmpstr, false);
                    }
                    else if (tmpstr.Split(' ')[0] == "BIOPHOTO") //处理用户photoID
                    {
                        SaveBioPhoto(tmpstr);
                    }
                }
            }
            catch (Exception ex)
            {
                if (OnError != null)
                {
                    OnError(ex.Message);
                }
            }
        }
        //将table=BIODATA后面的数据进行分解
        private void SeparateBioData(string datastr, string SN)
        {
            try
            {
                string[] strlist = datastr.Split('\n');
                foreach (string i in strlist)
                {
                    string tmpstr = i.ToString();
                    if (string.IsNullOrEmpty(tmpstr))
                        continue;
                    string bioTypeStr = tmpstr.Split('\t')[5].Split('=')[1];
                    BioType bioType = (BioType)Enum.Parse(typeof(BioType), bioTypeStr);
                    switch (bioType)
                    {
                        case BioType.Comm://通用
                            break;
                        case BioType.FingerPrint://指纹
                            SaveFP(tmpstr, SN, true);
                            break;
                        case BioType.Face://面部
                            SaveFace(tmpstr, true);
                            break;
                        case BioType.VocalPrint://声纹
                            break;
                        case BioType.Iris://虹膜
                            break;
                        case BioType.Retina://视网膜
                            break;
                        case BioType.PalmPrint://掌纹
                            break;
                        case BioType.FingerVein://指静脉
                            break;
                        case BioType.Palm://手掌
                            SavePalm(tmpstr);
                            break;
                        case BioType.VisilightFace://可见光面部
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                if (OnError != null)
                {
                    OnError(ex.Message);
                }
            }
        }
        //处理table=OPERLOG的数据
        private void OperLog(string sBuffer)
        {
            string machineSN = sBuffer.Substring(sBuffer.IndexOfEx("SN=") + 3);
            string SN = machineSN.Split('&')[0]; ;
            if (string.IsNullOrEmpty(SN))
                return;

            string machinestamp = sBuffer.Substring(sBuffer.IndexOfEx("Stamp=") + 6);
            string Stamp = "";
            this.GetTimeNumber(machinestamp, ref Stamp); // Get TimeStamp 

            //update machine oplogStamp
            DeviceBll.UpdateOperLogStamp(Stamp, SN);

            int operindex = sBuffer.IndexOfEx("\r\n\r\n", 1);
            string operstr = sBuffer.Substring(operindex + 4);

            SeparateOPERLOGData(operstr, SN);
        }
        //处理table=BIODATA的数据
        private void BioData(string sBuffer)
        {
            string machineSN = sBuffer.Substring(sBuffer.IndexOfEx("SN=") + 3);
            string SN = machineSN.Split('&')[0];

            string machinestamp = sBuffer.Substring(sBuffer.IndexOfEx("Stamp=") + 6);
            string Stamp = "";
            this.GetTimeNumber(machinestamp, ref Stamp); // Get TimeStamp 

            //update machine BioDataStamp (不使用)

            int bioindex = sBuffer.IndexOfEx("\r\n\r\n", 1);
            string biostr = sBuffer.Substring(bioindex + 4);

            SeparateBioData(biostr, SN);
        }
        #endregion
        #region resolve data of table=ERRORLOG
        //处理table=ERRORLOG的数据
        public void Errorlog(string sBuffer)
        {
            string machineSN = sBuffer.Substring(sBuffer.IndexOfEx("SN=") + 3);
            string SN = machineSN.Split('&')[0];

            string machinestamp = sBuffer.Substring(sBuffer.IndexOfEx("Stamp=") + 6);
            string Stamp = "";
            this.GetTimeNumber(machinestamp, ref Stamp); // Get TimeStamp 

            //update machine oplogStamp
            DeviceBll.UpdateErrorLogStamp(Stamp, SN);

            int errorindex = sBuffer.IndexOfEx("\r\n\r\n", 1);
            string errorstr = sBuffer.Substring(errorindex + 4);

            SeparateErrorData(errorstr, SN);
        }
        private void SeparateErrorData(string datastr, string SN)
        {
            try
            {
                string[] strlist = datastr.Split('\n');
                foreach (string i in strlist)
                {
                    string tmpstr = i.ToString();
                    //if (tmpstr.Split(' ')[0] == "OPLOG")//处理操作记录
                    if (tmpstr.IndexOfEx("ERRORLOG ") >= 0)
                    {
                        SaveErrorLog(tmpstr, SN);
                    }
                }
            }
            catch (Exception ex)
            {
                if (OnError != null)
                {
                    OnError(ex.Message);
                }
            }
        }
        /// <summary>
        /// save ErrorLog
        /// </summary>
        /// <param name="erlog"></param>
        private void SaveErrorLog(string erlog, string machineSN)
        {
            if (OnNewErrorLog != null)
            {
                OnNewErrorLog(CreateErrorlog(erlog, machineSN));
            }
        }
        //将设备传来的字符串分割为各个字段之后再封装为一个操作记录的对象
        private ErrorLogModel CreateErrorlog(string erlog, string machineSN)
        {
            string[] erlogstr = erlog.Split('\t');
            ErrorLogModel erlogModel = new ErrorLogModel();

            string temp = erlogstr[0];
            erlogModel.ErrCode = temp.Substring(8).Split('=')[1];
            erlogModel.ErrMsg = erlogstr[1].Split('=')[1];
            erlogModel.DataOrigin = erlogstr[2].Split('=')[1];
            erlogModel.CmdId = erlogstr[3].Split('=')[1];
            erlogModel.Additional = erlogstr[4].Split('=')[1];
            erlogModel.DeviceID = machineSN;

            return erlogModel;
        }
        #endregion
        #region resolve data of table=ATTLOG

        /// <summary>
        /// Parse AttLog for iclock Device
        /// </summary>
        /// <param name="sBuffer"></param>
        private void AttLog(string sBuffer)
        {
            string machineSN = sBuffer.Substring(sBuffer.IndexOfEx("SN=") + 3);
            string SN = machineSN.Split('&')[0];

            string machinestamp = sBuffer.Substring(sBuffer.IndexOfEx("Stamp=") + 6);
            string Stamp = "";
            this.GetTimeNumber(machinestamp, ref Stamp); // Get TimeStamp 

            //update machine attlogStamp
            DeviceBll.UpdateAttLogStamp(Stamp, SN);

            int attindex = sBuffer.IndexOfEx("\r\n\r\n", 1);
            string attstr = sBuffer.Substring(attindex + 4);
            AttLogProcess(attstr, SN);
        }


        private void AttLogProcess(string attstr, string machineSN)
        {
            try
            {
                string[] strlist = attstr.Split('\n');
                foreach (string i in strlist)
                {
                    if (string.IsNullOrEmpty(i))
                        continue;
                    SaveAttLog(i.ToString(), machineSN);
                }
            }
            catch (Exception ex)
            {
                if (OnError != null)
                {
                    OnError(ex.Message);
                }
            }
        }

        //封装考勤记录信息
        private AttLogModel CreateAttlog(string attlog, string machineSN)
        {
            string[] attlogstr = attlog.Split('\t');
            AttLogModel attLog = new AttLogModel();

            attLog.PIN = attlogstr[0];
            attLog.AttTime = Convert.ToDateTime(attlogstr[1]);
            attLog.Status = attlogstr[2];
            attLog.Verify = attlogstr[3];
            attLog.DeviceID = machineSN;

            try
            {
                attLog.WorkCode = attlogstr[4];
            }
            catch
            {
                attLog.WorkCode = "0";
            }
            if (attlogstr.Length > 8)
            {
                bool isConvert = int.TryParse(attlogstr[7], out int nResult);
                if (isConvert)
                    attLog.MaskFlag = nResult;
                attLog.Temperature = attlogstr[8];
            }
            return attLog;
        }

        /// <summary>
        /// save AttLog
        /// </summary>
        /// <param name="attlog"></param>
        private void SaveAttLog(string attlog, string machineSN)
        {
            if (OnNewAttLog != null)
            {
                OnNewAttLog(CreateAttlog(attlog, machineSN));
            }
        }
        #endregion

        #region resolve data of table=ATTPHOT
        /* save Attphoto */
        private void AttPhoto(byte[] bReceive)
        {
            string strReceive = Encoding.ASCII.GetString(bReceive);
            byte[] imgReceive = new byte[bReceive.Length];
            string[] tmpstr = strReceive.Split('\n');
            string strImageNumber = "";
            foreach (string str in tmpstr)
            {
                if (str.IndexOfEx("PIN=") >= 0)
                {
                    strImageNumber = str;
                    break;
                }
            }
            string machineSN = strReceive.Substring(strReceive.IndexOfEx("SN=") + 3);
            string SN = machineSN.Split('&')[0];

            string machinestamp = strReceive.Substring(strReceive.IndexOfEx("Stamp=") + 6);
            string Stamp = "";
            this.GetTimeNumber(machinestamp, ref Stamp); // Get TimeStamp 

            //update machine AttPhotoStamp
            DeviceBll.UpdateAttPhotoStamp(Stamp, SN);

            int imgrecindex = strReceive.IndexOfEx("uploadphoto") + 12;
            Array.Copy(bReceive, imgrecindex, imgReceive, 0, bReceive.Length - imgrecindex);

            string path = System.Environment.CurrentDirectory + "\\Capture";
            path += "\\" + strImageNumber.Replace("PIN=", "");
            System.IO.File.WriteAllBytes(path, imgReceive);

        }
        #endregion

        #region save workcode
        private void WorkcodeLog(string sBuffer)
        {
            string machineSN = sBuffer.Substring(sBuffer.IndexOfEx("SN=") + 3);
            string SN = machineSN.Split('&')[0];

            int usinindex = sBuffer.IndexOfEx("\r\n\r\n", 1);
            string usinstr = sBuffer.Substring(usinindex + 4);
            WorkcodeLogProcess(usinstr);
        }

        private void WorkcodeLogProcess(string sBuffer)
        {
            try
            {
                if (sBuffer.Length == 0) return;
                int usinindex = sBuffer.IndexOfEx("\n", 1);
                string usinstr = "";
                string endop = string.Empty;
                if (usinindex > 0)
                {
                    usinstr = sBuffer.Substring(0, usinindex);
                    if (usinstr.IndexOfEx("WORKCODE", 0) >= 0)
                    {
                        SaveWorkcode(usinstr);
                    }
                    endop = sBuffer.Substring(usinindex + 1);
                }

                if (!string.IsNullOrEmpty(endop))
                {
                    WorkcodeLogProcess(endop);
                }
            }
            catch (Exception ex)
            {
                if (OnError != null)
                {
                    OnError(ex.Message);
                }
            }
        }

        /// <summary>
        /// save workcode
        /// </summary>
        /// <param name="usinlog"></param>
        /// <param name="stamp"></param>
        private void SaveWorkcode(string usinlog)
        {
            if (usinlog.IndexOfEx("Code", 0) >= 0)
            {
                string code = usinlog.Substring(0, usinlog.IndexOfEx("\t", 0));
                string workname = usinlog.Substring(usinlog.IndexOfEx("\t", 0) + 1);

                WorkCodeModel workcode = new WorkCodeModel();
                workcode.WorkCode = code.Replace("WORKCODE Code=", "");
                workcode.WorkName = workname.Replace("Name=", "");
                if (OnNewWorkcode != null)
                {
                    OnNewWorkcode(workcode);
                }
            }
        }
        #endregion

        #region resolve data of table=USERPIC
        public void UserPicLog(string sBuffer)
        {
            string machineSN = sBuffer.Substring(sBuffer.IndexOfEx("SN=") + 3);
            string SN = machineSN.Split('&')[0];

            string machinestamp = sBuffer.Substring(sBuffer.IndexOfEx("Stamp=") + 6);
            string Stamp = "";
            this.GetTimeNumber(machinestamp, ref Stamp); // Get TimeStamp 

            //UserPicStamp = Stamp;

            int usinindex = sBuffer.IndexOfEx("\r\n\r\n", 1);
            string usinstr = sBuffer.Substring(usinindex + 4);
            userpiclogprocess(usinstr);
        }

        public void userpiclogprocess(string sBuffer)
        {
            try
            {
                int usinindex = sBuffer.IndexOfEx("\n", 1);
                string usinstr = "";

                if (usinindex > 0)
                {
                    usinstr = sBuffer.Substring(0, usinindex);
                }
                saveuserpic(usinstr);
                string endop = sBuffer.Substring(usinindex + 1);
                if (endop != "")
                {
                    userpiclogprocess(endop);
                }
            }
            catch
            {
            }

        }

        private void Base64StringToImage(string txtFileName)
        {
            try
            {
                FileStream ifs = new FileStream(txtFileName, FileMode.Open, FileAccess.Read);
                //System.IO.FileStream ifs = new System.IO.FileStream(txtFileName, System.IO.FileMode.Open, System.IO.FileAccess.Read, FileShare.ReadWrite);
                StreamReader sr = new StreamReader(ifs);

                String inputStr = sr.ReadToEnd();

                byte[] arr = Convert.FromBase64String(inputStr);
                MemoryStream ms = new MemoryStream(arr);
                Bitmap bmp = new Bitmap(ms);

                string temp = txtFileName.Substring(0, txtFileName.Length - 4);
                bmp.Save(temp + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                ms.Close();
                sr.Close();
                ifs.Close();
                //this.picUser.Image = bmp;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Base64StringToImage 转换失败/nException：" + ex.Message);
            }
        }
        public void saveuserpic(string usinlog)
        {
            if (usinlog.IndexOfEx("PIN", 0) > 0 && usinlog.IndexOfEx("FileName", 0) > 0)
            {
                string UsInid = usinlog.Substring(0, usinlog.IndexOfEx("\t", 0));
                string stillusin1 = usinlog.Substring(usinlog.IndexOfEx("\t", 0) + 1);
                string usinnum1 = stillusin1.Substring(0, stillusin1.IndexOfEx("\t", 0));
                string stillusin2 = stillusin1.Substring(stillusin1.IndexOfEx("\t", 0) + 1);
                string usinnum2 = stillusin2.Substring(0, stillusin2.IndexOfEx("\t", 0));
                string stillusin3 = stillusin2.Substring(stillusin2.IndexOfEx("\t", 0) + 1);
                string stillusin4 = stillusin3.Substring(8);
                string path = System.Environment.CurrentDirectory + "\\Photo"; ;
                string name = usinnum1.Replace("FileName=", "");
                string name1 = name.Substring(0, name.Length - 4);
                path += "\\" + name1 + ".txt";  //Photo\\
                StreamWriter sw = new StreamWriter(path);
                sw.WriteLine(stillusin4);
                sw.Close();
                Base64StringToImage("Photo\\" + name1 + ".txt");
                //this.WriteUserPic(UsInid.Replace("USER PIN=", ""), usinnum1.Replace("FileName=", ""), usinnum2.Replace("Size=", ""));

                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                /* if (tabOptions.SelectedIndex == 10) // User Info Logs Count
                 {
                     lblRecords.Text = "UserPic Count:";
                     lblCount.Text = lvUserPic.Items.Count.ToString();
                 }*/
                // MessageBox.Show("转换成功！");
            }
        }
        #endregion

        #region table=options
        /// <summary>
        /// Parse Options for Device
        /// </summary>
        /// <param name="sBuffer"></param>
        private void Options(string sBuffer)
        {
            string machineSN = sBuffer.Substring(sBuffer.IndexOfEx("SN=") + 3);
            string SN = machineSN.Split('&')[0];
            if (string.IsNullOrEmpty(SN))
                return;

            int attindex = sBuffer.IndexOfEx("\r\n\r\n", 1);
            string strOptions = sBuffer.Substring(attindex + 4);

            if (string.IsNullOrEmpty(strOptions))
                return;

            DeviceModel device = GetDeviceModelByOptions(SN, strOptions);

            //更新
            DeviceBll.Update(device);
        }

        /// <summary>
        /// 根据参数获取设备实例
        /// </summary>
        /// <param name="strOptions"></param>
        /// <returns></returns>
        private DeviceModel GetDeviceModelByOptions(string devSN, string strOptions)
        {
            DeviceModel device = DeviceBll.Get(devSN);
            //Tools.InitModel(device, strOptions);

            ////MultiBioDataSupport属性为空，则设备不支持混合识别协议
            //if (!string.IsNullOrEmpty(device.MultiBioDataSupport))
            //    return device;

            FormatBioData(ref strOptions);
            Tools.InitModel(device, strOptions);

            return device;
        }

        /// <summary>
        /// 参数字符串转化，转化为混合识别协议格式的
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        private void FormatBioData(ref string options)
        {
            if (string.IsNullOrEmpty(options))
                return;

            //0 通用的
            //1 指纹
            //2 面部
            //3 声纹
            //4 虹膜
            //5 视网膜
            //6 掌纹
            //7 指静脉
            //8 手掌
            //9 可见光面部 
            string valMultiBioDataSupport = "0:0:0:0:0:0:0:0:0:0";
            string valMultiBioPhotoSupport = "0:0:0:0:0:0:0:0:0:0";
            string valMultiBioVersion = "0:0:0:0:0:0:0:0:0:0";
            string valMultiBioCount = "0:0:0:0:0:0:0:0:0:0";
            string valMaxMultiBioDataCount = "0:0:0:0:0:0:0:0:0:0";
            string valMaxMultiBioPhotoCount = "0:0:0:0:0:0:0:0:0:0";

            options = options.Replace("~", "");
            string[] arrInfo = options.Split(",\t".ToCharArray());
            foreach (string info in arrInfo)
            {
                string[] arrKeyVal = info.Split('=');
                if (arrKeyVal.Length != 2)
                    continue;
                string key = arrKeyVal[0].Trim();
                string val = arrKeyVal[1].Trim();
                if (val == "" || val == "0")
                    continue;

                #region 指纹
                if (string.Equals(key, "FingerFunOn", StringComparison.OrdinalIgnoreCase))
                {//支持
                    UpdateOptionVal(BioType.FingerPrint, val, ref valMultiBioDataSupport);
                }
                else if (string.Equals(key, "FPVersion", StringComparison.OrdinalIgnoreCase))
                {//版本
                    UpdateOptionVal(BioType.FingerPrint, val, ref valMultiBioVersion);
                }
                else if (string.Equals(key, "FPCount", StringComparison.OrdinalIgnoreCase))
                {//数量
                    UpdateOptionVal(BioType.FingerPrint, val, ref valMultiBioCount);
                }
                else if (string.Equals(key, "MaxFingerCount", StringComparison.OrdinalIgnoreCase))
                {//最大数量
                    UpdateOptionVal(BioType.FingerPrint, val, ref valMaxMultiBioDataCount);
                }
                #endregion end-指纹
                #region 人脸
                else if (string.Equals(key, "FaceFunOn", StringComparison.OrdinalIgnoreCase))
                {//支持
                    UpdateOptionVal(BioType.Face, val, ref valMultiBioDataSupport);
                    UpdateOptionVal(BioType.VisilightFace, val, ref valMultiBioDataSupport);
                }
                else if (string.Equals(key, "FaceVersion", StringComparison.OrdinalIgnoreCase))
                {//版本
                    UpdateOptionVal(BioType.Face, val, ref valMultiBioVersion);
                }
                else if (string.Equals(key, "FaceCount", StringComparison.OrdinalIgnoreCase))
                {//数量
                    UpdateOptionVal(BioType.Face, val, ref valMultiBioCount);
                }
                else if (string.Equals(key, "MaxFaceCount", StringComparison.OrdinalIgnoreCase))
                {//最大数量
                    UpdateOptionVal(BioType.Face, val, ref valMaxMultiBioDataCount);
                }
                #endregion end-人脸
                #region 指静脉
                else if (string.Equals(key, "FvFunOn", StringComparison.OrdinalIgnoreCase))
                {//支持
                    UpdateOptionVal(BioType.FingerVein, val, ref valMultiBioDataSupport);
                }
                else if (string.Equals(key, "FvVersion", StringComparison.OrdinalIgnoreCase))
                {//版本
                    UpdateOptionVal(BioType.FingerVein, val, ref valMultiBioVersion);
                }
                else if (string.Equals(key, "FvCount", StringComparison.OrdinalIgnoreCase))
                {//数量
                    UpdateOptionVal(BioType.FingerVein, val, ref valMultiBioCount);
                }
                else if (string.Equals(key, "MaxFvCount", StringComparison.OrdinalIgnoreCase))
                {//最大数量
                    UpdateOptionVal(BioType.FingerVein, val, ref valMaxMultiBioDataCount);
                }
                #endregion end-指静脉
                #region 掌静脉-手掌
                else if (string.Equals(key, "PvFunOn", StringComparison.OrdinalIgnoreCase))
                {//支持
                    UpdateOptionVal(BioType.Palm, val, ref valMultiBioDataSupport);
                }
                else if (string.Equals(key, "PvVersion", StringComparison.OrdinalIgnoreCase))
                {//版本
                    UpdateOptionVal(BioType.Palm, val, ref valMultiBioVersion);
                }
                else if (string.Equals(key, "PvCount", StringComparison.OrdinalIgnoreCase))
                {//数量
                    UpdateOptionVal(BioType.Palm, val, ref valMultiBioCount);
                }
                else if (string.Equals(key, "MaxPvCount", StringComparison.OrdinalIgnoreCase))
                {//最大数量
                    UpdateOptionVal(BioType.Palm, val, ref valMaxMultiBioDataCount);
                }
                #endregion end-掌静脉-手掌
                #region 可见光
                else if (string.Equals(key, "VisilightFun", StringComparison.OrdinalIgnoreCase))
                {//支持
                    UpdateOptionVal(BioType.VisilightFace, val, ref valMultiBioDataSupport);
                }
                //else if (string.Equals(key, "PvVersion", StringComparison.OrdinalIgnoreCase))
                //{//版本
                //    UpdateOptionVal(BioType.FingerVein, val, ref valMultiBioVersion);
                //}
                //else if (string.Equals(key, "PvCount", StringComparison.OrdinalIgnoreCase))
                //{//数量
                //    UpdateOptionVal(BioType.FingerVein, val, ref valMultiBioCount);
                //}
                //else if (string.Equals(key, "MaxPvCount", StringComparison.OrdinalIgnoreCase))
                //{//最大数量
                //    UpdateOptionVal(BioType.FingerVein, val, ref valMaxMultiBioDataCount);
                //}
                #endregion end-可见光
            }

            options += ",MultiBioDataSupport=" + valMultiBioDataSupport
                    + ",MultiBioPhotoSupport=" + valMultiBioPhotoSupport
                    + ",MultiBioVersion=" + valMultiBioVersion
                    + ",MultiBioCount=" + valMultiBioCount
                    + ",MaxMultiBioDataCount=" + valMaxMultiBioDataCount
                    + ",MaxMultiBioPhotoCount=" + valMaxMultiBioPhotoCount;
        }
        /// <summary>
        /// 更新参数值
        /// </summary>
        /// <param name="BioType">类型</param>
        /// <param name="val">更新值</param>
        /// <param name="vals">值组</param>
        /// <returns></returns>
        private string UpdateOptionVal(BioType BioType, string val, ref string vals)
        {
            string[] arrVal = vals.Split(':');
            int t = (int)BioType;
            if (t >= arrVal.Length)
                return vals;

            arrVal[t] = val;

            vals = string.Join(":", arrVal);

            return vals;
        }
        #endregion end-table=options

    }
}
