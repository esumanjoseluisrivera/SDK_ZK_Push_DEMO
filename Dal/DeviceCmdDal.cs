using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;
using Utils;

namespace Dal
{
    //设备命令
    public class DeviceCmdDal
    {
        /// <summary>Max Length Buffer
        /// </summary>
        private const int MaxBufferCmd = 2* 1024* 1024;

        /// <summary>add a record
        /// </summary>
        public int Add(DeviceCmdModel dCmd)
        {
            string sql = string.Format(@"
insert into DeviceCmds(
       DevSN,Content,CommitTime,TransTime,ResponseTime,ReturnValue
   ) values (
       @DevSN,@Content,@CommitTime,@TransTime,@ResponseTime,@ReturnValue
);");

            SQLiteParameter[] parameters = {
                        new SQLiteParameter("@DevSN", dCmd.DevSN) ,
                        new SQLiteParameter("@Content",  dCmd.Content) ,
                        new SQLiteParameter("@CommitTime", dCmd.CommitTime) ,
                        new SQLiteParameter("@TransTime", null),
                        new SQLiteParameter("@ResponseTime",null),
                        new SQLiteParameter("@ReturnValue", dCmd.ReturnValue)

            };
            return SqliteHelper.ExecuteNonQuery(sql, parameters);
        }

        /// <summary>send to device
        /// </summary>
        /// <param name="DevSN"></param>
        /// <returns></returns>
        public string Send(string DevSN)
        {
            string sql = string.Format(@"
select  ID, DevSN, Content, CommitTime, TransTime, ResponseTime, ReturnValue 
  from DeviceCmds
 where DevSN=@DevSN and (ReturnValue is null or length(ReturnValue)=0) limit 200
");

            SQLiteParameter[] parameters = {
                  new SQLiteParameter("@DevSN", DevSN)
            };

            DataTable dtCmd = SqliteHelper.GetDataTable(sql, parameters);
            if (dtCmd == null || dtCmd.Rows.Count == 0)
                return "OK";

            StringBuilder sbCmd = new StringBuilder();
            StringBuilder sbCmdID = new StringBuilder();
            foreach (DataRow row in dtCmd.Rows)
            {
                string currCmd = string.Format("C:{0}:{1}\n", row["ID"], row["Content"]);
                int currCmdLen = Encoding.UTF8.GetByteCount(currCmd);
                int strOrdersLen = Encoding.UTF8.GetByteCount(sbCmd.ToString());
                if ((currCmdLen + strOrdersLen) > MaxBufferCmd)
                    break;

                sbCmd.Append(currCmd);
                sbCmdID.Append(row["ID"]).Append(",");
            }

            string ids = sbCmdID.ToString().Trim(',');
            if (ids.Length > 0)
            {
                sql = string.Format("update DeviceCmds set TransTime='{0}' where ID in ({1})", Tools.GetDateTimeNowString(), ids);
                SqliteHelper.ExecuteNonQuery(sql);
            }

            return (sbCmd.Length > 0) ? sbCmd.ToString() : "OK";
        }
        /// <summary>get record by options
        /// </summary>
        public DataTable GetByTime(DateTime startTime, DateTime endTime, string devSN)
        {
            string whereDevSN = (string.IsNullOrEmpty(devSN)) ? "" : " and DevSN=@DevSN";
            string sql = string.Format(@"
select * from DeviceCmds
 where CommitTime>@CommitTime1 and CommitTime<@CommitTime2
       {0}
 order by CommitTime desc
", whereDevSN);

            SQLiteParameter[] parameters = {
                 new SQLiteParameter("@CommitTime1", startTime),
                 new SQLiteParameter("@CommitTime2", endTime),
                 new SQLiteParameter("@DevSN", devSN)
            };

            return SqliteHelper.GetDataTable(sql, parameters);
        }
        /// <summary>get all record
        /// </summary>
        public DataTable GetAll()
        {
            string sql = string.Format(@"
select *   from DeviceCmds order by CommitTime desc
");
            return SqliteHelper.GetDataTable(sql);
        }
        /// <summary>
        /// 更新设备响应内容
        /// </summary>
        /// <param name="arrContent"></param>
        public void Update(string arrContent)
        {
            string sql = string.Format(@"
update DeviceCmds set 
    ResponseTime = @ResponseTime ,
    ReturnValue = @ReturnValue
 where ID=@ID
");

            List<ManySql> manySql = new List<ManySql>();
            string[] contentList = arrContent.Split('\n');

            for (int i = 0, j = contentList.Length; i < j && contentList[i].Length > 0; i++)
            {
                SQLiteParameter[] parameters = {
                        new SQLiteParameter("@ResponseTime", Tools.GetDateTimeNowString()),
                        new SQLiteParameter("@ReturnValue",contentList[i]),
                        new SQLiteParameter("@ID",contentList[i].Split('&')[0].Split('=')[1])
                    };
                manySql.Add(new ManySql(sql, parameters));
            }
            SqliteHelper.ExecuteManySql(manySql);
        }
        /// <summary>
        /// delete record by ids
        /// </summary>
        /// <param name="listId"></param>
        /// <returns></returns>
        public int Delete(List<string> listId)
        {
            string sql = string.Format(@"
delete from DeviceCmds  
 where id in ({0})
", Tools.UnionString(listId));

            return SqliteHelper.ExecuteNonQuery(sql);
        }
        /// <summary>delete all record
        /// </summary>
        public int ClearAll()
        {
            string sql = "delete from DeviceCmds";
            return SqliteHelper.ExecuteNonQuery(sql);
        }
    }
}
