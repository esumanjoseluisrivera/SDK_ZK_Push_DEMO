using Model;
using System.Data;
using System.Data.SQLite;

namespace Dal
{
    /// <summary>
    /// 设备异常日志
    /// </summary>
    public class ErrorLogDal
    {
        /// <summary>add a record
        /// </summary>
        public int Add(ErrorLogModel model)
        {
            string sql = string.Format(@"
insert into ErrorLog(
       ErrorCode,ErrMsg,DataOrigin,CmdId,Additional,DeviceID
    ) values (
       @ErrorCode,@ErrMsg,@DataOrigin,@CmdId,@Additional,@DeviceID
);");

            SQLiteParameter[] parameters = {
                        new SQLiteParameter("@ErrorCode",  model.ErrCode) ,
                        new SQLiteParameter("@ErrMsg", model.ErrMsg) ,
                        new SQLiteParameter("@DataOrigin", model.DataOrigin),
                        new SQLiteParameter("@CmdId",  model.CmdId) ,
                        new SQLiteParameter("@Additional", model.Additional) ,
                        new SQLiteParameter("@DeviceID",  model.DeviceID)
            };
            return SqliteHelper.ExecuteNonQuery(sql, parameters);
        }

        /// <summary>
        /// get record
        /// </summary>
        /// <param name="devSN"></param>
        /// <returns></returns>
        public DataTable GetAll(string devSN)
        {
            string whereDevSN = (string.IsNullOrEmpty(devSN)) ? "" : " where DeviceID=@DevSN";

            string sql = string.Format(@"
select * from Errorlog
      {0}
 order by id desc
", whereDevSN);

            SQLiteParameter[] sQLiteParameters = {
                new SQLiteParameter("@DevSN",devSN)
            };
            return SqliteHelper.GetDataTable(sql.ToString(), sQLiteParameters);
        }

        /// <summary>delete all record
        /// </summary>
        public int ClearAll()
        {
            string sql = "delete from ErrorLog";
            return SqliteHelper.ExecuteNonQuery(sql);
        }
    }
}
