using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using Utils;

namespace Dal
{
    /// <summary>
    /// 指纹模板
    /// </summary>
    public class TmpFPDal
    {
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="pins"></param>
        /// <returns></returns>
        public List<TmpFPModel> Get(string pin)
        {
            string sql = string.Format(@"
select * from TmpFP where pin = '{0}';", pin);

            DataTable dt = SqliteHelper.GetDataTable(sql);
            if (dt == null || dt.Rows.Count == 0)
                return new List<TmpFPModel>();

            List<TmpFPModel> fps = new List<TmpFPModel>();
            foreach (DataRow row in dt.Rows)
            {
                TmpFPModel fp = new TmpFPModel();
                fp.ID = Convert.ToInt32(row["ID"].ToString());
                fp.Pin = row["PIN"].ToString();
                fp.Fid = row["FID"].ToString();
                fp.Size = Convert.ToInt32(row["Size"].ToString());
                fp.Valid = row["Valid"].ToString();
                fp.Tmp = row["Tmp"].ToString();
                fp.MajorVer = row["MajorVer"].ToString();
                fp.MinorVer = row["MinorVer"].ToString();
                fp.Duress = row["Duress"].ToString();
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
select count(*) from TmpFP
 where pin='{0}' and ver='{1}'
", pin.ToLower(), ver.ToLower());

            return Tools.TryConvertToInt32(SqliteHelper.ExecuteScalar(sql));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(TmpFPModel model)
        {
            string sql = string.Format(@"
delete from TmpFP where Pin =@Pin and MajorVer=@MajorVer and Fid=@Fid ;

insert into TmpFP(Pin,Fid,Size,Valid,Tmp,MajorVer,MinorVer,Duress)
 values(@Pin,@Fid,@Size,@Valid,@Tmp,@MajorVer,@MinorVer,@Duress);
");

            SQLiteParameter[] parameters = {
                        new SQLiteParameter("@Pin", model.Pin) ,
                        new SQLiteParameter("@Fid", model.Fid) ,
                        new SQLiteParameter("@Size",model.Size) ,
                        new SQLiteParameter("@Valid", model.Valid) ,
                        new SQLiteParameter("@Tmp", model.Tmp) ,
                        new SQLiteParameter("@MajorVer", model.MajorVer),
                        new SQLiteParameter("@MinorVer", model.MinorVer),
                        new SQLiteParameter("@Duress", model.Duress)
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
delete from TmpFP  where Pin in ({0});", Tools.UnionString(pins));

            return SqliteHelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 清空
        /// </summary>
        /// <returns></returns>
        public int ClearAll()
        {
            string sql = "delete from TmpFP ";
            return SqliteHelper.ExecuteNonQuery(sql);
        }
    }
}
