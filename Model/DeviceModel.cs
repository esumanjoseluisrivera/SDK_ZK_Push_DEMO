using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Model
{
    /// <summary>
    /// 设备
    /// </summary>
    public class DeviceModel
    {
        public DeviceModel()
        {
            this.DevName = "Iclock600";
            this.Delay = "10";
            this.DevFirmwareVersion = "";
            this.DevIP = "192.168.1.201";
            this.DevMac = "0C:00:00:00:B1:02";
            this.Encrypt = "0";           
            this.Realtime = "1";
            this.SyncTime = 0;
            this.ErrorDelay = "120";
            this.Timeout = 120;
            this.TransInterval = "30";
            this.TransTimes = "";
            this.UserCount = 10000;
            this.VendorName = "ZK";
            this.TransFlag = "TransData AttLog\tOpLog\tAttPhoto\tEnrollUser\tChgUser\tEnrollFP\tChgFP\tFPImag\tFACE\tUserPic\tWORKCODE\tBioPhoto";
            //AttLog 考勤记录,OpLog 操作日志,AttPhoto 考勤照片,EnrollUser 登记新用户,ChgUser 修改用户信息,EnrollFP 登记新指纹
            //ChgFP 修改指纹,FPImag 指纹图片,FACE 新登记人脸,UserPic 用户照片,WORKCODE 工作号码,BioPhoto 对比照片
            this.AttLogStamp = "0";
            this.AttPhotoStamp = "0";
            this.OperLogStamp = "0";
            this.TimeZone = "08:00";
            this.LastRequestTime = Convert.ToDateTime("1900-01-01 00:00:00");
            this.IRTempDetectionFunOn = "0";
            this.MaskDetectionFunOn = "0";
            this.MultiBioDataSupport = "1:1:1:1:1:1:1:1:1:1";
        }
        /// <summary>
        /// ID
        /// </summary>		
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// DevSN
        /// </summary>		
        private string _devsn;
        public string DevSN
        {
            get { return _devsn; }
            set { _devsn = value; }
        }
        /// <summary>
        /// DevName
        /// </summary>		
        private string _devname;
        public string DevName
        {
            get { return _devname; }
            set { _devname = value; }
        }
        /// <summary>
        /// AttLogStamp
        /// </summary>		
        private string _attlogstamp;
        public string AttLogStamp
        {
            get { return _attlogstamp; }
            set { _attlogstamp = value; }
        }
        /// <summary>
        /// OperLogsStamp
        /// </summary>		
        private string _operlogstamp;
        public string OperLogStamp
        {
            get { return _operlogstamp; }
            set { _operlogstamp = value; }
        }
        /// <summary>
        /// ATTPHOTOStamp
        /// </summary>		
        private string _attphotostamp;
        public string AttPhotoStamp
        {
            get { return _attphotostamp; }
            set { _attphotostamp = value; }
        }
        /// <summary>
        /// ErrorDelay
        /// </summary>		
        private string _errordelay;
        public string ErrorDelay
        {
            get { return _errordelay; }
            set { _errordelay = value; }
        }
        /// <summary>
        /// Delay
        /// </summary>		
        private string _delay;
        public string Delay
        {
            get { return _delay; }
            set { _delay = value; }
        }
        /// <summary>
        /// TransFlag
        /// </summary>		
        private string _transflag;
        public string TransFlag
        {
            get { return _transflag; }
            set { _transflag = value; }
        }
        /// <summary>
        /// Realtime
        /// </summary>		
        private string _realtime;
        public string Realtime
        {
            get { return _realtime; }
            set { _realtime = value; }
        }
        /// <summary>
        /// TransInterval
        /// </summary>		
        private string _transinterval;
        public string TransInterval
        {
            get { return _transinterval; }
            set { _transinterval = value; }
        }
        /// <summary>
        /// TransTimes
        /// </summary>		
        private string _transtimes;
        public string TransTimes
        {
            get { return _transtimes; }
            set { _transtimes = value; }
        }
        /// <summary>
        /// Encrypt
        /// </summary>		
        private string _encrypt;
        public string Encrypt
        {
            get { return _encrypt; }
            set { _encrypt = value; }
        }
        /// <summary>
        /// LastRequestTime
        /// </summary>		
        private DateTime _lastrequesttime;
        public DateTime LastRequestTime
        {
            get { return _lastrequesttime; }
            set { _lastrequesttime = value; }
        }
        /// <summary>
        /// DevIP
        /// </summary>		
        private string _devip;
        public string DevIP
        {
            get { return _devip; }
            set { _devip = value; }
        }
        /// <summary>
        /// DevMac
        /// </summary>		
        private string _devmac;
        public string DevMac
        {
            get { return _devmac; }
            set { _devmac = value; }
        }        
        /// <summary>
        /// DevFirmwareVersion
        /// </summary>		
        private string _devfirmwareversion;
        public string DevFirmwareVersion
        {
            get { return _devfirmwareversion; }
            set { _devfirmwareversion = value; }
        }
        /// <summary>
        /// UserCount
        /// </summary>		
        private int _usercount;
        public int UserCount
        {
            get { return _usercount; }
            set { _usercount = value; }
        }
        /// <summary>
        /// AttCount
        /// </summary>		
        private int _attcount;
        public int AttCount
        {
            get { return _attcount; }
            set { _attcount = value; }
        }
        /// <summary>
        /// TimeZone
        /// </summary>		
        private string _timezone;
        public string TimeZone
        {
            get { return _timezone; }
            set { _timezone = value; }
        }
        /// <summary>
        /// Timeout
        /// </summary>		
        private int _timeout;
        public int Timeout
        {
            get { return _timeout; }
            set { _timeout = value; }
        }
        /// <summary>
        /// SyncTime
        /// </summary>		
        private int _synctime;
        public int SyncTime
        {
            get { return _synctime; }
            set { _synctime = value; }
        }

        /// <summary>
        /// Vendor Name
        /// </summary>		
        private string _vendorName;
        public string VendorName
        {
            get { return _vendorName; }
            set { _vendorName = value; }
        }
        /// <summary>
        /// MaskDetectionFunOn
        /// </summary>
        private string _iRTempDetectionFunOn;
        public string IRTempDetectionFunOn
        {
            get { return _iRTempDetectionFunOn; }
            set { _iRTempDetectionFunOn = value; }
        }
        /// <summary>
        /// MaskDetectionFunOn
        /// </summary>
        private string _maskDetectionFunOn;
        public string MaskDetectionFunOn
        {
            get { return _maskDetectionFunOn; }
            set { _maskDetectionFunOn = value; }
        }

        /// <summary>
        /// 支持URL方式下发用户照片
        /// </summary>
        private string _userPicURLFunOn;
        public string UserPicURLFunOn
        {
            get { return _userPicURLFunOn; }
            set { _userPicURLFunOn = value; }
        }

        /// <summary>
        /// MultiBioDataSupport
        /// 支持多模态生物特征图片参数， type类型进行按位定义， 不同类型间用:冒号隔开，
        /// 0:不支持， 1表示支持： 支持版本号， 如： 0:1:1:0:0:0:0:0:0:0,表示支持指纹图片支持和近红外人
        ///脸图片支持
        /// 0 通用的 ,1 指纹,2 面部,3 声纹,4 虹膜,5 视网膜,6 掌纹,7 指静脉,8 手掌,9 可见光面部,
        /// </summary>
        private string _multiBioDataSupport;
        public string MultiBioDataSupport
        {
            get { return _multiBioDataSupport; }
            set { _multiBioDataSupport = value; }
        }
        /// <summary>
        /// 支持多模态生物特征图片参数， type类型进行按位定义， 不同类型间用:冒号隔开，
        /// 0:不支持， 1表示支持：如： 0:1:1:0:0:0:0:0:0:0,表示支持指纹图片支持和近红外人脸图片支持
        /// </summary>
        private string _multiBioPhotoSupport;
        public string MultiBioPhotoSupport
        {
            get { return _multiBioPhotoSupport; }
            set { _multiBioPhotoSupport = value; }
        }
        /// <summary>
        /// 多模态生物特征数据版本， 不同类型间用:冒号隔开， 0:不支持， 1表示支持： 
        /// 如： 0:10.0:7.0:0:0:0:0:0:0:0,表示支持指纹算法10.0和近红外人脸算法7.0
        /// </summary>
        private string _multiBioVersion;
        public string MultiBioVersion
        {
            get { return _multiBioVersion; }
            set { _multiBioVersion = value; }
        }
        /// <summary>
        /// 支持多模态生物特征数据版本参数， type类型进行按位定义， 不同类型间用:冒号隔开，
        /// 0:不支持， 1表示支持： 支持版本号， 如： 0:100:200:0:0:0:0:0:0:0,表示支持指纹数量100和近红外人脸数量200
        /// </summary>
        private string _multiBioCount;
        public string MultiBioCount
        {
            get { return _multiBioCount; }
            set { _multiBioCount = value; }
        }
        /// <summary>
        /// 支持多模态生物特征模板最大数量， type类型进行按位定义， 不同类型间用: 冒号隔开，
        /// 0:不支持， 1表示支持： 支持最大模板数量， 如： 0:10000:2000:0:0:0:0:0:0:0,表示支持指纹模板最大数量10000和近红外人脸模板最大数量2000
        /// </summary>
        private string _maxMultiBioDataCount;
        public string MaxMultiBioDataCount
        {
            get { return _maxMultiBioDataCount; }
            set { _maxMultiBioDataCount = value; }
        }
        /// <summary>
        /// 支持多模态生物特征照片最大数量， type类型进行按位定义， 不同类型间用:冒号隔开，
        /// 0:不支持， 1表示支持： 支持最大照片数量， 如： 0:10000:2000:0:0:0:0:0:0:0,表示支持指纹照片最大数量10000和近红外人脸照片最大数量2000
        /// </summary>
        private string _maxMultiBioPhotoCount;
        public string MaxMultiBioPhotoCount
        {
            get { return _maxMultiBioPhotoCount; }
            set { _maxMultiBioPhotoCount = value; }
        }

        public override string ToString()
        {
            return _devsn;
        }

        #region BioData Function
        /// <summary>
        /// 是否支持某多模态生物
        /// </summary>
        /// <param name="BioType">多模态生物类型</param>
        /// <returns></returns>
        public bool IsBioDataSupport(BioType BioType)
        {
            if (string.IsNullOrEmpty(MultiBioDataSupport))
                return false;

            string[] arr = MultiBioDataSupport.Split(':');
            if (arr.Length != 10 || (int)BioType >= arr.Length)
                return false;

            if (arr[(int)BioType] == "0"  || arr[(int)BioType] == "")
                return false;

            return true;
        }
        /// <summary>
        /// 是否支持某多模态生物图片
        /// </summary>
        /// <param name="BioType">多模态生物类型</param>
        /// <returns></returns>
        public bool IsBioPhotoSupport(BioType BioType)
        {
            if (string.IsNullOrEmpty(MultiBioPhotoSupport))
                return false;

            string[] arr = MultiBioDataSupport.Split(':');
            if (arr.Length != 10 || (int)BioType >= arr.Length)
                return false;

            if (arr[(int)BioType] == "0"  || arr[(int)BioType] == "")
                return false;

            return true;
        }
        /// <summary>
        /// 获取支持某多模态生物版本
        /// </summary>
        /// <param name="BioType">多模态生物类型</param>
        /// <returns></returns>
        public string GetBioVersion(BioType BioType)
        {
            string version = "";
            if (string.IsNullOrEmpty(MultiBioVersion))
                return version;

            string[] arr = MultiBioVersion.Split(':');
            if (arr.Length != 10 || (int)BioType >= arr.Length)
                return version;

            version = arr[(int)BioType];

            return version;
        }

        /// <summary>
        /// 获取某多模态生物数量
        /// </summary>
        /// <param name="BioType">多模态生物类型</param>
        /// <returns></returns>
        public int GetBioDataCount(BioType BioType)
        {
            int count = 0;
            if (string.IsNullOrEmpty(MultiBioCount))
                return count;

            string[] arr = MultiBioCount.Split(':');
            if (arr.Length != 10 || (int)BioType >= arr.Length)
                return count;

            count = Tools.TryConvertToInt32(arr[(int)BioType]);

            return count;
        }

        /// <summary>
        /// 获取某多模态生物图片数量
        /// </summary>
        /// <param name="BioType">多模态生物类型</param>
        /// <returns></returns>
        public int GetBioPhotoCount(BioType BioType)
        {
            int count = 0;
            if (string.IsNullOrEmpty(MaxMultiBioPhotoCount))
                return count;

            string[] arr = MaxMultiBioPhotoCount.Split(':');
            if (arr.Length != 10 || (int)BioType >= arr.Length)
                return count;

            count = Tools.TryConvertToInt32(arr[(int)BioType]);

            return count;
        }


        /// <summary>
        /// 获取某多模态生物最大数量
        /// </summary>
        /// <param name="BioType">多模态生物类型</param>
        /// <returns></returns>
        public int GetMaxBioDataCount(BioType BioType)
        {
            int count = 0;
            if (string.IsNullOrEmpty(MaxMultiBioDataCount))
                return count;

            string[] arr = MaxMultiBioDataCount.Split(':');
            if (arr.Length != 10 || (int)BioType >= arr.Length)
                return count;

            count = Tools.TryConvertToInt32(arr[(int)BioType]);

            return count;
        }
        /// <summary>
        /// 获取某多模态生物最大数量
        /// </summary>
        /// <param name="BioType">多模态生物类型</param>
        /// <returns></returns>
        public int GetMaxBioPhotoCount(BioType BioType)
        {
            int count = 0;
            if (string.IsNullOrEmpty(MaxMultiBioPhotoCount))
                return count;

            string[] arr = MaxMultiBioPhotoCount.Split(':');
            if (arr.Length != 10 || (int)BioType >= arr.Length)
                return count;

            count = Tools.TryConvertToInt32(arr[(int)BioType]);

            return count;
        }
        #endregion End-BioData Function

    }

    /// <summary>
    /// 多模态生物类型
    /// </summary>
    public enum BioType
    {
        /// <summary>
        /// 0 通用的
        /// </summary>
        Comm = 0,
        /// <summary>
        /// 1 指纹
        /// </summary>
        FingerPrint = 1,
        /// <summary>
        /// 2 面部
        /// </summary>
        Face = 2,
        /// <summary>
        /// 3 声纹
        /// </summary>
        VocalPrint = 3,
        /// <summary>
        /// 4 虹膜
        /// </summary>
        Iris = 4,
        /// <summary>
        /// 5 视网膜
        /// </summary>
        Retina = 5,
        /// <summary>
        /// 6 掌纹
        /// </summary>
        PalmPrint = 6,
        /// <summary>
        /// 7 指静脉
        /// </summary>
        FingerVein = 7,
        /// <summary>
        /// 8 手掌
        /// </summary>
        Palm = 8,
        /// <summary>
        /// 9 可见光面部 
        /// </summary>
        VisilightFace = 9
    }
}
