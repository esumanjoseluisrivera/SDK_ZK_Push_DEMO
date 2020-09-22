using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using Utils;

namespace Dal
{
    /// <summary>
    /// 用户照片
    /// </summary>
    public class TmpUserPicDal
    {
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="pins"></param>
        /// <param name="ver"></param>
        /// <returns></returns>
        public List<TmpUserPicModel> Get(List<string> pins)
        {
            string sql = string.Format(@"
select * from TmpUserPic where pin in ({0});", Tools.UnionString(pins));

            DataTable dt = SqliteHelper.GetDataTable(sql);
            if (dt == null || dt.Rows.Count == 0)
                return null;

            List<TmpUserPicModel> fps = new List<TmpUserPicModel>();
            foreach (DataRow row in dt.Rows)
            {
                TmpUserPicModel fp = new TmpUserPicModel();
                fp.ID = Convert.ToInt32(row["ID"].ToString());
                fp.Pin = row["PIN"].ToString();
                fp.FileName = row["FileName"].ToString();
                fp.Size = Convert.ToInt32(row["Size"].ToString());
                fp.Content = row["Content"].ToString();

                fps.Add(fp);
            }
            return fps;
        }

        /// <summary>
        /// 获取个数
        /// </summary>
        /// <param name="pin"></param>      
        /// <returns></returns>
        public int GetCount(string pin)
        {
            string sql = string.Format(@"
select count(*) from TmpUserPic
 where pin='{0}' ", pin.ToLower());

            return Tools.TryConvertToInt32(SqliteHelper.ExecuteScalar(sql));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(TmpUserPicModel model)
        {
            string sql = string.Format(@"
delete from TmpUserPic where Pin =@Pin ;

insert into TmpUserPic(Pin,FileName,Size,Content)
 values(@Pin,@FileName,@Size,@Content);
");

            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@Pin", model.Pin) ,
                    new SQLiteParameter("@FileName", model.FileName) ,
                    new SQLiteParameter("@Size",model.Size) ,
                    new SQLiteParameter("@Content", model.Content)
             };
            return SqliteHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="pins"></param>
        /// <returns></returns>
        public int Delete(List<string> pins)
        {
            string sql = string.Format(@"
delete from TmpUserPic  where Pin in ({0});", Tools.UnionString(pins));

            return SqliteHelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 清空
        /// </summary>
        /// <returns></returns>
        public int ClearAll()
        {
            string sql = "delete from TmpUserPic ";
            return SqliteHelper.ExecuteNonQuery(sql);
        }
    }
}
