using Model;
using System;
using System.Data;
using System.Data.SQLite;
using Utils;

namespace Dal
{
    /// <summary>
    /// 考勤记录
    /// </summary>
    public class AttLogDal
    {
        /// <summary>
        /// 获取考勤记录
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="userID"></param>
        /// <param name="devSN"></param>
        /// <returns></returns>
        public DataTable GetByTime(DateTime startTime, DateTime endTime, string userID, string devSN)
        {
            string wherePin = (string.IsNullOrEmpty(userID)) ? "" : " and a.PIN=@PIN";
            string whereDevSN = (string.IsNullOrEmpty(devSN)) ? "" : " and DeviceID=@DevSN";

            string sql = string.Format(@"
select a.*,w.workname from AttLog a left join WorkCode w on a.workcode = w.workcode
 where a.PIN <> '' and a.AttTime>@AttTime1 and a.AttTime<@AttTime2
      {0}
      {1}
  order by a.AttTime desc
", wherePin, whereDevSN);

            SQLiteParameter[] parameters = {
                 new SQLiteParameter("@AttTime1", startTime),
                 new SQLiteParameter("@AttTime2", endTime),
                 new SQLiteParameter("@PIN", userID),
                 new SQLiteParameter("@DevSN", devSN)
            };
            return SqliteHelper.GetDataTable(sql, parameters);
        }

        /// <summary>
        /// 获取考勤记录
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            string sql = "select * from AttLog order by AttTime desc";
            return SqliteHelper.GetDataTable(sql);
        }
        /// <summary>
        /// 清空考勤记录
        /// </summary>
        /// <returns></returns>
        public int ClearAll()
        {
            string sql = "delete from AttLog";
            return SqliteHelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="attlog"></param>
        /// <returns></returns>
        public int Add(AttLogModel attlog)
        {
            string sql = string.Format(@"
insert into AttLog(
       PIN,AttTime,Status,Verify,WorkCode,Reserved1,Reserved2,MaskFlag,Temperature,DeviceID
   ) values (
       @PIN,@AttTime,@Status,@Verify,@WorkCode,@Reserved1,@Reserved2,@MaskFlag,@Temperature,@DeviceID
);");

            SQLiteParameter[] parameters = {
                        new SQLiteParameter("@PIN", attlog.PIN) ,
                        new SQLiteParameter("@AttTime", attlog.AttTime) ,
                        new SQLiteParameter("@Status", attlog.Status) ,
                        new SQLiteParameter("@Verify",attlog.Verify) ,
                        new SQLiteParameter("@WorkCode", attlog.WorkCode) ,
                        new SQLiteParameter("@Reserved1", attlog.Reserved1) ,
                        new SQLiteParameter("@Reserved2", attlog.Reserved2) ,
                        new SQLiteParameter("@MaskFlag", attlog.MaskFlag) ,
                        new SQLiteParameter("@Temperature", attlog.Temperature) ,
                        new SQLiteParameter("@DeviceID", attlog.DeviceID)
                    };

            return SqliteHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="pin"></param>
        /// <param name="attTime"></param>
        /// <returns></returns>
        public bool IsExist(string pin, DateTime attTime)
        {
            string sql = string.Format(@"
select count(*)
  from AttLog 
where pin=@PIN and attTime=@AttTime
");

            SQLiteParameter[] parameters = {
                        new SQLiteParameter("@PIN", pin) ,
                        new SQLiteParameter("@AttTime", attTime)
                    };
            int count = Tools.TryConvertToInt32(SqliteHelper.ExecuteScalar(sql, parameters));

            if (count <= 0)
                return false;

            return true;
        }
    }
}
