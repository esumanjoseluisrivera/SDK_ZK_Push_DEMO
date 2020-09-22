using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using Utils;

namespace Dal
{
    /// <summary>
    /// 人脸
    /// </summary>
    public class TmpFaceDal
    {
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="pins"></param>
        /// <param name="ver"></param>
        /// <returns></returns>
        public List<TmpFaceModel> Get(string pin)
        {
            string sql = string.Format(@"
select * from TmpFace where pin ='{0}';", pin);

            DataTable dt = SqliteHelper.GetDataTable(sql);
            if (dt == null || dt.Rows.Count == 0)
                return new List<TmpFaceModel>();

            List<TmpFaceModel> fps = new List<TmpFaceModel>();
            foreach (DataRow row in dt.Rows)
            {
                TmpFaceModel fp = new TmpFaceModel();
                fp.ID = Convert.ToInt32(row["ID"].ToString());
                fp.Pin = row["PIN"].ToString();
                fp.Fid = row["FID"].ToString();
                fp.Size = Convert.ToInt32(row["Size"].ToString());
                fp.Valid = row["Valid"].ToString();
                fp.Tmp = row["Tmp"].ToString();
                fp.Ver = row["Ver"].ToString();
                fps.Add(fp);
            }
            return fps;
        }

        /// <summary>
        /// 获取个数
        /// </summary>
        /// <param name="pin"></param>
        /// <param name="ver"></param>
        /// <returns></returns>
        public int GetCount(string pin, string ver)
        {
            string sql = string.Format(@"
select count(*) from TmpFace
 where pin='{0}' and ver='{1}'
", pin.ToLower(), ver.ToLower());

            return Tools.TryConvertToInt32(SqliteHelper.ExecuteScalar(sql));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(TmpFaceModel model)
        {
            string sql = string.Format(@"
delete from TmpFace where Pin =@Pin and Ver=@Ver and Fid=@Fid ;

insert into TmpFace(Pin,Fid,Size,Valid,Tmp,Ver)
 values(@Pin,@Fid,@Size,@Valid,@Tmp,@Ver);
");

            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@Pin", model.Pin) ,
                    new SQLiteParameter("@Fid", model.Fid) ,
                    new SQLiteParameter("@Size",model.Size) ,
                    new SQLiteParameter("@Valid", model.Valid) ,
                    new SQLiteParameter("@Tmp", model.Tmp) ,
                    new SQLiteParameter("@Ver", model.Ver)
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
delete from TmpFace  where Pin in ({0});", Tools.UnionString(pins));

            return SqliteHelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 清空
        /// </summary>
        /// <returns></returns>
        public int ClearAll()
        {
            string sql = "delete from TmpFace ";
            return SqliteHelper.ExecuteNonQuery(sql);
        }
    }
}
