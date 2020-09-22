using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Dal
{
    /// <summary>
    /// 工作代码
    /// </summary>
    public class WorkCodeDal
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="workCode"></param>
        /// <returns></returns>
        public int Add(WorkCodeModel workCode)
        {
            string sql = "insert into WorkCode(workcode,workname) values(@workcode,@workname)";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@workcode", workCode.WorkCode) ,
                new SQLiteParameter("@workname", workCode.WorkName)
            };

            return SqliteHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="workCode"></param>
        /// <returns></returns>
        public int Delete(string workCode)
        {
            string sql = "delete from WorkCode where workcode=@workcode";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@workcode",workCode)
            };
            return SqliteHelper.ExecuteNonQuery(sql, parameters);
        }
        public int Update(WorkCodeModel workCode)
        {
            string sql = string.Format(@"
update WorkCode set
      workcode=@workcode
      ,workname=@workname 
 where id=@id
");

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@id",workCode.ID),
                new SQLiteParameter("@workcode",workCode.WorkCode),
                new SQLiteParameter("@workname",workCode.WorkName)
            };
            return SqliteHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 获取记录
        /// </summary>
        /// <param name="workCode"></param>
        /// <returns></returns>
        public WorkCodeModel GetByWorkCode(string workCode)
        {
            string sql = string.Format(@"
select * from WorkCode 
 where workcode=@workcode
");
            SQLiteParameter[] parameters = {
                new SQLiteParameter("@workcode",workCode)
            };
            DataTable dt = SqliteHelper.GetDataTable(sql, parameters);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }

            WorkCodeModel model = new WorkCodeModel();
            DataRow row = dt.Rows[0];
            model.ID = Tools.TryConvertToInt32(row["ID"].ToString());
            model.WorkCode = row["workcode"].ToString();
            model.WorkName = row["workname"].ToString();

            return model;
        }
        /// <summary>
        /// 获取记录
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            string sql = "select * from WorkCode";
            return SqliteHelper.GetDataTable(sql);
        }
    }
}
