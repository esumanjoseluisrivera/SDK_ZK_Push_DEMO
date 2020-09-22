using Model;
using System;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace Dal
{
    /// <summary>
    /// 短消息
    /// </summary>
    public class SmsDal
    {
        /// <summary>GetAll
        /// </summary>
        /// <param name="sqlWhere"></param>
        /// <returns></returns>
        public DataTable GetAll(string sqlWhere)
        {
            sqlWhere = string.IsNullOrEmpty(sqlWhere) ? "" : "where " + sqlWhere;
            string sql = string.Format(@"
select [ID] ,[SMSId] ,[Type] , [ValidTime] ,[BeginTime] ,[UserID] ,[Content]
       ,case [Type] 
          when 253 then 'Common'
          when 254 then 'User'
          when 255 then 'Reserved'
          else '' end as TypeName
 from SMS {0};", sqlWhere);

            return SqliteHelper.GetDataTable(sql);
        }
        /// <summary>Get
        /// </summary>
        /// <param name="smsID"></param>
        /// <returns></returns>
        public SMSModel Get(string smsID)
        {
            DataTable dt = GetAll(string.Format("smsID='{0}'", smsID));
            if (dt == null || dt.Rows.Count == 0)
                return null;

            SMSModel model = new SMSModel();
            model.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
            model.SMSId = Convert.ToInt32(dt.Rows[0]["SMSId"]);
            model.Type = Convert.ToInt32(dt.Rows[0]["Type"]);
            model.ValidTime = Convert.ToInt32(dt.Rows[0]["ValidTime"]);
            model.BeginTime = Convert.ToDateTime(dt.Rows[0]["BeginTime"].ToString());
            model.UserID = dt.Rows[0]["UserID"].ToString();
            model.Content = dt.Rows[0]["Content"].ToString();

            return model;
        }
        /// <summary>Add
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public int Add(SMSModel model)
        {
            string sql = string.Format(@"
insert into SMS(
      SMSId,[Type],ValidTime,BeginTime,UserID,Content
    ) values (
      @SMSId,@Type,@ValidTime,@BeginTime,@UserID,@Content
);");

            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@SMSId", model.SMSId) ,
                    new SQLiteParameter("@Type", model.Type) ,
                    new SQLiteParameter("@ValidTime", model.ValidTime) ,
                    new SQLiteParameter("@BeginTime", model.BeginTime) ,
                    new SQLiteParameter("@UserID", model.UserID) ,
                    new SQLiteParameter("@Content", model.Content)
            };
            return SqliteHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>Delete
        /// </summary>
        /// <param name="devSN"></param>
        /// <returns></returns>
        public int Delete(string smsID)
        {
            string sql = string.Format(@"
delete from SMS where smsID='{0}';", smsID);

            return SqliteHelper.ExecuteNonQuery(sql);
        }
        /// <summary>Update
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public int Update(SMSModel model)
        {
            string sql = string.Format(@"
 update SMS set 
    SMSId = @SMSId , 
    [Type] = @Type ,            
    ValidTime = @ValidTime,  
    BeginTime = @BeginTime,  
    UserID = @UserID,  
    Content = @Content  
 where ID=@ID 
");

            SQLiteParameter[] parameters = {
                        new SQLiteParameter("@SMSId",  model.SMSId) ,
                        new SQLiteParameter("@Type", model.Type) ,
                        new SQLiteParameter("@ValidTime", model.ValidTime) ,
                        new SQLiteParameter("@BeginTime", model.BeginTime) ,
                        new SQLiteParameter("@UserID", model.UserID) ,
                        new SQLiteParameter("@Content", model.Content) ,
                        new SQLiteParameter("@ID", model.ID)
            };
            return SqliteHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>ClearAll
        /// </summary>
        /// <returns></returns>
        public int ClearAll()
        {
            string sql = "delete from SMS ";
            return SqliteHelper.ExecuteNonQuery(sql);
        }
    }
}
