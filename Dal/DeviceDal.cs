using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;
using Utils;

namespace Dal
{
    /// <summary>
    /// 设备
    /// </summary>
    public class DeviceDal
    {
        /// <summary>GetAll
        /// </summary>
        /// <param name="sqlWhere"></param>
        /// <returns></returns>
        public DataTable GetAll(string sqlWhere)
        {
            sqlWhere = string.IsNullOrEmpty(sqlWhere) ? "" : "where " + sqlWhere;
            string sql = string.Format(@"
select * from Device {0};", sqlWhere);

            return SqliteHelper.GetDataTable(sql);
        }
        /// <summary>Get one model
        /// </summary>
        /// <param name="devSN"></param>
        /// <returns></returns>
        public DeviceModel Get(string devSN)
        {
            DataTable dt = GetAll(string.Format("DevSN='{0}'", devSN));
            if (dt == null || dt.Rows.Count == 0)
                return null;

            DeviceModel device = new DeviceModel();
            device.ID = Tools.TryConvertToInt32(dt.Rows[0]["ID"]);
            device.DevSN = dt.Rows[0]["DevSN"].ToString();
            device.TransInterval = dt.Rows[0]["TransInterval"].ToString();
            device.TransTimes = dt.Rows[0]["TransTimes"].ToString();
            device.Encrypt = dt.Rows[0]["Encrypt"].ToString();
            device.LastRequestTime = Convert.ToDateTime(dt.Rows[0]["LastRequestTime"].ToString());
            device.DevIP = dt.Rows[0]["DevIP"].ToString();
            device.DevMac = dt.Rows[0]["DevMac"].ToString();
            device.DevFirmwareVersion = dt.Rows[0]["DevFirmwareVersion"].ToString();
            device.UserCount = Tools.TryConvertToInt32(dt.Rows[0]["UserCount"].ToString());
            device.AttCount = Tools.TryConvertToInt32(dt.Rows[0]["AttCount"].ToString());
            device.DevName = dt.Rows[0]["DevName"].ToString();
            device.TimeZone = dt.Rows[0]["TimeZone"].ToString();
            device.Timeout = Tools.TryConvertToInt32(dt.Rows[0]["Timeout"].ToString());
            device.SyncTime = Tools.TryConvertToInt32(dt.Rows[0]["SyncTime"].ToString());
            device.AttLogStamp = dt.Rows[0]["ATTLOGStamp"].ToString();
            device.OperLogStamp = dt.Rows[0]["OPERLOGStamp"].ToString();
            device.AttPhotoStamp = dt.Rows[0]["ATTPHOTOStamp"].ToString();
            device.ErrorDelay = dt.Rows[0]["ErrorDelay"].ToString();
            device.Delay = dt.Rows[0]["Delay"].ToString();
            device.TransFlag = dt.Rows[0]["TransFlag"].ToString();
            device.Realtime = dt.Rows[0]["Realtime"].ToString();
            device.VendorName = dt.Rows[0]["VendorName"].ToString();
            device.IRTempDetectionFunOn = dt.Rows[0]["IRTempDetectionFunOn"].ToString();
            device.MaskDetectionFunOn = dt.Rows[0]["MaskDetectionFunOn"].ToString();

            device.MultiBioDataSupport = dt.Rows[0]["MultiBioDataSupport"].ToString();
            device.MultiBioPhotoSupport = dt.Rows[0]["MultiBioPhotoSupport"].ToString();
            device.MultiBioVersion = dt.Rows[0]["MultiBioVersion"].ToString();
            device.MultiBioCount = dt.Rows[0]["MultiBioCount"].ToString();
            device.MaxMultiBioDataCount = dt.Rows[0]["MaxMultiBioDataCount"].ToString();
            device.MaxMultiBioPhotoCount = dt.Rows[0]["MaxMultiBioPhotoCount"].ToString();

            return device;
        }
        /// <summary>Add
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public int Add(DeviceModel device)
        {
            string sql = string.Format(@"
insert into Device(
        DevSN,TransInterval,TransTimes,Encrypt,LastRequestTime,DevIP,DevMac,DevFirmwareVersion
        ,UserCount,AttCount,DevName,TimeZone,Timeout,SyncTime,ATTLOGStamp,OPERLOGStamp,ATTPHOTOStamp
        ,ErrorDelay,Delay,TransFlag,Realtime,VendorName,IRTempDetectionFunOn,MaskDetectionFunOn
   ) values (
        @DevSN,@TransInterval,@TransTimes,@Encrypt,@LastRequestTime,@DevIP,@DevMac,@DevFirmwareVersion
        ,@UserCount,@AttCount,@DevName,@TimeZone,@Timeout,@SyncTime,@ATTLOGStamp,@OPERLOGStamp,@ATTPHOTOStamp
        ,@ErrorDelay,@Delay,@TransFlag,@Realtime,@VendorName,@IRTempDetectionFunOn,@MaskDetectionFunOn
);");

            SQLiteParameter[] parameters = {
                        new SQLiteParameter("@DevSN", device.DevSN) ,
                        new SQLiteParameter("@TransInterval", device.TransInterval) ,
                        new SQLiteParameter("@TransTimes", device.TransTimes) ,
                        new SQLiteParameter("@Encrypt", device.Encrypt) ,
                        new SQLiteParameter("@LastRequestTime", device.LastRequestTime) ,
                        new SQLiteParameter("@DevIP", device.DevIP) ,
                        new SQLiteParameter("@DevMac", device.DevMac) ,
                        new SQLiteParameter("@DevFirmwareVersion", device.DevFirmwareVersion) ,
                        new SQLiteParameter("@UserCount", device.UserCount) ,
                        new SQLiteParameter("@AttCount", device.AttCount) ,
                        new SQLiteParameter("@DevName", device.DevName) ,
                        new SQLiteParameter("@TimeZone", device.TimeZone) ,
                        new SQLiteParameter("@Timeout", device.Timeout) ,
                        new SQLiteParameter("@SyncTime", device.SyncTime) ,
                        new SQLiteParameter("@ATTLOGStamp",device.AttLogStamp) ,
                        new SQLiteParameter("@OPERLOGStamp", device.OperLogStamp) ,
                        new SQLiteParameter("@ATTPHOTOStamp", device.AttPhotoStamp) ,
                        new SQLiteParameter("@ErrorDelay", device.ErrorDelay) ,
                        new SQLiteParameter("@Delay",device.Delay) ,
                        new SQLiteParameter("@TransFlag", device.TransFlag) ,
                        new SQLiteParameter("@Realtime", device.Realtime) ,
                        new SQLiteParameter("@VendorName", device.VendorName),
                        new SQLiteParameter("@IRTempDetectionFunOn", device.IRTempDetectionFunOn),
                        new SQLiteParameter("@MaskDetectionFunOn", device.MaskDetectionFunOn)

            };
            return SqliteHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>Delete
        /// </summary>
        /// <param name="devSN"></param>
        /// <returns></returns>
        public int Delete(string devSN)
        {
            string sql = string.Format(@"
delete from Device where DevSN='{0}';", devSN);

            return SqliteHelper.ExecuteNonQuery(sql);
        }
        /// <summary>Update
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public int Update(DeviceModel device)
        {
            string sql = string.Format(@"
update Device set 
    TransInterval = @TransInterval , 
    TransTimes = @TransTimes , 
    Encrypt = @Encrypt , 
    LastRequestTime = @LastRequestTime , 
    DevIP = @DevIP , 
    DevMac = @DevMac , 
    DevFirmwareVersion = @DevFirmwareVersion , 
    UserCount = @UserCount , 
    AttCount = @AttCount , 
    DevName = @DevName , 
    TimeZone = @TimeZone , 
    Timeout = @Timeout , 
    SyncTime = @SyncTime , 
    ATTLOGStamp = @ATTLOGStamp , 
    OPERLOGStamp = @OPERLOGStamp , 
    ATTPHOTOStamp = @ATTPHOTOStamp , 
    ErrorDelay = @ErrorDelay , 
    Delay = @Delay , 
    TransFlag = @TransFlag , 
    Realtime = @Realtime,  
    VendorName = @VendorName,  
    IRTempDetectionFunOn = @IRTempDetectionFunOn,  
    MaskDetectionFunOn = @MaskDetectionFunOn,  
    MultiBioDataSupport = @MultiBioDataSupport,  
    MultiBioPhotoSupport = @MultiBioPhotoSupport,  
    MultiBioVersion = @MultiBioVersion,  
    MultiBioCount = @MultiBioCount,  
    MaxMultiBioDataCount = @MaxMultiBioDataCount,  
    MaxMultiBioPhotoCount = @MaxMultiBioPhotoCount  
where DevSN=@DevSN 
");

            SQLiteParameter[] parameters = {
                        new SQLiteParameter("@DevSN",  device.DevSN) ,
                        new SQLiteParameter("@TransInterval", device.TransInterval) ,
                        new SQLiteParameter("@TransTimes", device.TransTimes) ,
                        new SQLiteParameter("@Encrypt", device.Encrypt) ,
                        new SQLiteParameter("@LastRequestTime", device.LastRequestTime) ,
                        new SQLiteParameter("@DevIP", device.DevIP) ,
                        new SQLiteParameter("@DevMac",device.DevMac) ,
                        new SQLiteParameter("@DevFirmwareVersion", device.DevFirmwareVersion) ,
                        new SQLiteParameter("@UserCount",device.UserCount) ,
                        new SQLiteParameter("@AttCount", device.AttCount) ,
                        new SQLiteParameter("@DevName", device.DevName) ,
                        new SQLiteParameter("@TimeZone", device.TimeZone) ,
                        new SQLiteParameter("@Timeout", device.Timeout) ,
                        new SQLiteParameter("@SyncTime", device.SyncTime) ,
                        new SQLiteParameter("@ATTLOGStamp", device.AttLogStamp) ,
                        new SQLiteParameter("@OPERLOGStamp", device.OperLogStamp) ,
                        new SQLiteParameter("@ATTPHOTOStamp", device.AttPhotoStamp) ,
                        new SQLiteParameter("@ErrorDelay",device.ErrorDelay) ,
                        new SQLiteParameter("@Delay", device.Delay) ,
                        new SQLiteParameter("@TransFlag", device.TransFlag) ,
                        new SQLiteParameter("@Realtime", device.Realtime) ,
                        new SQLiteParameter("@VendorName", device.VendorName),
                        new SQLiteParameter("@IRTempDetectionFunOn", device.IRTempDetectionFunOn),
                        new SQLiteParameter("@MaskDetectionFunOn", device.MaskDetectionFunOn),
                        new SQLiteParameter("@MultiBioDataSupport", device.MultiBioDataSupport),
                        new SQLiteParameter("@MultiBioPhotoSupport", device.MultiBioPhotoSupport),
                        new SQLiteParameter("@MultiBioVersion", device.MultiBioVersion),
                        new SQLiteParameter("@MultiBioCount", device.MultiBioCount),
                        new SQLiteParameter("@MaxMultiBioDataCount", device.MaxMultiBioDataCount),
                        new SQLiteParameter("@MaxMultiBioPhotoCount", device.MaxMultiBioPhotoCount)
            };
            return SqliteHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 更新考勤日志时间戳
        /// </summary>
        /// <param name="stamp"></param>
        /// <param name="devSN"></param>
        public void UpdateAttLogStamp(string stamp, string devSN)
        {
            string sql = string.Format(@"
update Device set 
      ATTLOGStamp = @ATTLOGStamp 
 where DevSN=@DevSN;
");

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@ATTLOGStamp", stamp),
                new SQLiteParameter("@DevSN",  devSN)
            };
            SqliteHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 考勤日志时间戳清理
        /// </summary>
        /// <param name="listDevSn"></param>
        public void SetZeroAttLogStamp(List<string> listDevSn)
        {
            string sql = string.Format(@"
update Device set    
    ATTLOGStamp = '0', 
 where DevSN in ({0})
", Tools.UnionString(listDevSn));

            SqliteHelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 更新操作日志时间戳
        /// </summary>
        /// <param name="stamp"></param>
        /// <param name="devSN"></param>
        public void UpdateOperLogStamp(string stamp, string devSN)
        {
            string sql = string.Format(@"
update Device set 
      OPERLOGStamp = @OPERLOGStamp 
 where DevSN=@DevSN;
");

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@OPERLOGStamp",stamp ),
                new SQLiteParameter("@DevSN",  devSN)
            };
            SqliteHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 更新错误日志时间戳
        /// </summary>
        /// <param name="stamp"></param>
        /// <param name="devSN"></param>
        public void UpdateErrorLogStamp(string stamp, string devSN)
        {
            string sql = string.Format(@"
update Device set 
      ERRORLOGStamp = @ERRORLOGStamp 
 where DevSN=@DevSN;
");

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@ERRORLOGStamp",stamp ),
                new SQLiteParameter("@DevSN",  devSN)
            };
            SqliteHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 更新考勤图像时间戳
        /// </summary>
        /// <param name="stamp"></param>
        /// <param name="devSN"></param>
        public void UpdateAttPhotoStamp(string stamp, string devSN)
        {
            string sql = string.Format(@"
update Device set 
      ATTPHOTOStamp = @ATTPHOTOStamp 
 where DevSN=@DevSN;
");

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@ATTPHOTOStamp",stamp ),
                new SQLiteParameter("@DevSN",  devSN)
            };
            SqliteHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 清零时间戳
        /// </summary>
        /// <param name="listDevSn"></param>
        public void SetZeroStamp(List<string> listDevSn)
        {
            string sql = string.Format(@"
update Device set 
    OPERLOGStamp = '0', 
    ATTLOGStamp = '0', 
    ATTPHOTOStamp = '0' 
 where DevSN in ({0})
", Tools.UnionString(listDevSn));

            SqliteHelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 更新最后请求时间
        /// </summary>
        /// <param name="DevSN"></param>
        public void SetLastRequestTime(string DevSN)
        {
            string sql = string.Format(@"
update Device set 
      LastRequestTime = @LastRequestTime 
 where DevSN=@DevSN;
");

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@LastRequestTime",Tools.GetDateTimeNowString() ),
                new SQLiteParameter("@DevSN",  DevSN)
            };
            SqliteHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 更新供应商名称
        /// </summary>
        /// <param name="sn"></param>
        /// <param name="vendorName"></param>
        public void UpdateVendorName(string sn, string vendorName)
        {
            string sql = string.Format(@"
update Device set 
      VendorName = @VendorName 
 where DevSN=@DevSN;
");

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@VendorName",vendorName ),
                new SQLiteParameter("@DevSN",  sn)
            };
            SqliteHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 获取所有的DevSN
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllDevSN()
        {
            string sql = string.Format(@"select DevSN from Device;");

            List<string> listDevSN = new List<string>();
            DataTable dt = SqliteHelper.GetDataTable(sql);
            if (dt == null)
                return listDevSN;

            foreach (DataRow row in dt.Rows)
            {
                listDevSN.Add(row[0].ToString());
            }

            return listDevSN;
        }
    }
}
