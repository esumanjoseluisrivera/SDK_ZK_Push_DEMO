using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using Utils;

namespace Dal
{
    /// <summary>
    /// 比对照片
    /// </summary>
    public class TmpBioPhotoDal
    {
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="pins"></param>
        /// <param name="ver"></param>
        /// <returns></returns>
        public List<TmpBioPhotoModel> Get(string pin, string type)
        {
            string sql = string.Format(@"
select * from TmpBioPhoto where pin ='{0}' and type in ({1});", pin, type);

            DataTable dt = SqliteHelper.GetDataTable(sql);
            if (dt == null || dt.Rows.Count == 0)
                return new List<TmpBioPhotoModel>();

            List<TmpBioPhotoModel> fps = new List<TmpBioPhotoModel>();
            foreach (DataRow row in dt.Rows)
            {
                TmpBioPhotoModel fp = new TmpBioPhotoModel();
                fp.ID = Convert.ToInt32(row["ID"].ToString());
                fp.Pin = row["PIN"].ToString();
                fp.FileName = row["FileName"].ToString();
                fp.Type = row["Type"].ToString();
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
select count(*) from TmpBioPhoto
 where pin='{0}' ", pin.ToLower());

            return Tools.TryConvertToInt32(SqliteHelper.ExecuteScalar(sql));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(TmpBioPhotoModel model)
        {
            string sql = string.Format(@"
delete from TmpBioPhoto where Pin =@Pin and Type=@Type;

insert into TmpBioPhoto(Pin,FileName,Type,Size,Content)
 values(@Pin,@FileName,@Type,@Size,@Content);
");

            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@Pin", model.Pin) ,
                    new SQLiteParameter("@FileName", model.FileName) ,
                    new SQLiteParameter("@Type",model.Type) ,
                    new SQLiteParameter("@Size",model.Size) ,
                    new SQLiteParameter("@Content", model.Content)
             };
            return SqliteHelper.ExecuteNonQuery(sql.ToString(), parameters);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="pins"></param>
        /// <returns></returns>
        public int Delete(List<string> pins)
        {
            string sql = string.Format(@"
delete from TmpBioPhoto  where Pin in ({0});", Tools.UnionString(pins));

            return SqliteHelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 清空
        /// </summary>
        /// <returns></returns>
        public int ClearAll()
        {
            string sql = "delete from TmpBioPhoto ";
            return SqliteHelper.ExecuteNonQuery(sql);
        }
    }
}
