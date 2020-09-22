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
    /// 设备操作日志
    /// </summary>
    public class OpLogDal
    {
        /// <summary>
        /// 获取记录
        /// </summary>
        /// <returns></returns>
        public List<OpLogModel> Get()
        {            
            List<OpLogModel> Oplogs = new List<OpLogModel>();
            DataTable dt = GetAll();
            if (dt == null)
                return Oplogs;

            foreach (DataRow row in dt.Rows)
            {
                OpLogModel oplog = new OpLogModel();
                oplog.ID = Tools.TryConvertToInt32( row["ID"]);
                oplog.User = row["User"].ToString();
                oplog.Operator = row["Operator"].ToString();
                oplog.DeviceID = row["DeviceID"].ToString();
                oplog.OpTime = Convert.ToDateTime(row["OpTime"].ToString());
                oplog.OpType = row["OpType"].ToString();
                oplog.Obj1 = row["Obj1"].ToString();
                oplog.Obj2 = row["Obj2"].ToString();
                oplog.Obj3 = row["Obj3"].ToString();
                oplog.Obj4 = row["Obj4"].ToString();

                Oplogs.Add(oplog);
            }

            return Oplogs;
        }
        /// <summary>
        /// 获取记录
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            string sql = string.Format(@"select * from OpLog order by OpTime desc");

            return SqliteHelper.GetDataTable(sql);
        }
        /// <summary>
        /// 获取记录
        /// </summary>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="devsn"></param>
        /// <returns></returns>
        public DataTable GetOplogByTime(DateTime starttime, DateTime endtime, string devSN)
        {
            string whereDevSN = (string.IsNullOrEmpty(devSN)) ? "" : " and DeviceID=@DevSN";

            string sql = string.Format(@"
select * from OpLog
 where OpTime>@OpTime1 and OpTime<@OpTime2
      {0}
  order by OpTime desc
", whereDevSN);

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@OpTime1", starttime),
                new SQLiteParameter("@OpTime2", endtime),
                new SQLiteParameter("@DevSN", devSN)
            };
            return SqliteHelper.GetDataTable(sql, parameters);
        }
        /// <summary>
        /// 清空记录
        /// </summary>
        /// <returns></returns>
        public int ClearAll()
        {
            string sql = "delete from OpLog";
            return SqliteHelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="oplog"></param>
        /// <returns></returns>
        public int Add(OpLogModel oplog)
        {
            string sql = string.Format(@"
insert into OpLog(
         Operator,OpTime,OpType,User,Obj1,Obj2,Obj3,Obj4,DeviceID
) values (
         @Operator,@OpTime,@OpType,@User,@Obj1,@Obj2,@Obj3,@Obj4,@DeviceID
);");

            SQLiteParameter[] parameters = {
                        new SQLiteParameter("@Operator", oplog.Operator) ,
                        new SQLiteParameter("@OpTime", oplog.OpTime) ,
                        new SQLiteParameter("@OpType", oplog.OpType) ,
                        new SQLiteParameter("@User",oplog.User) ,
                        new SQLiteParameter("@Obj1", oplog.Obj1) ,
                        new SQLiteParameter("@Obj2", oplog.Obj2) ,
                        new SQLiteParameter("@Obj3", oplog.Obj3) ,
                        new SQLiteParameter("@Obj4", oplog.Obj4),
                        new SQLiteParameter("@DeviceID", oplog.DeviceID)
                    };

            return SqliteHelper.ExecuteNonQuery(sql, parameters);
        }
    }
}
