using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using Utils;

namespace Dal
{
    /// <summary>
    /// 指静脉
    /// </summary>
    public class TmpFveinDal
    {
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="pins"></param>
        /// <param name="ver"></param>
        /// <returns></returns>
        public List<TmpFveinModel> Get(List<string> pins, string ver)
        {
            string sql = string.Format(@"
select * from TmpFvein where pin in ({0}) and ver='{1}';", Tools.UnionString(pins), ver);

            DataTable dt = SqliteHelper.GetDataTable(sql);
            if (dt == null || dt.Rows.Count == 0)
                return null;

            List<TmpFveinModel> fps = new List<TmpFveinModel>();
            foreach (DataRow row in dt.Rows)
            {
                TmpFveinModel fp = new TmpFveinModel();
                fp.ID = Convert.ToInt32(row["ID"].ToString());
                fp.Pin = row["Pin"].ToString();
                fp.Fid = row["Fid"].ToString();
                fp.Index = row["Index"].ToString();
                fp.Size = Convert.ToInt32(row["Size"].ToString());
                fp.Valid = row["Valid"].ToString();
                fp.Tmp = row["Tmp"].ToString();
                fp.Ver = row["Ver"].ToString();
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
select count(*) from TmpFvein
 where pin='{0}' and ver='{1}'
", pin.ToLower(), ver.ToLower());

            return Tools.TryConvertToInt32(SqliteHelper.ExecuteScalar(sql));
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(TmpFveinModel model)
        {
            string sql = string.Format(@"
delete from TmpFvein where Pin =@Pin and Ver=@Ver and Fid=@Fid  and Index=@Index;

insert into TmpFvein(Pin,Fid,Index,Size,Valid,Tmp,Ver,Duress)
 values(@Pin,@Fid,@Index,@Size,@Valid,@Tmp,@Ver,@Duress);
");

            SQLiteParameter[] parameters = {
                        new SQLiteParameter("@Pin", model.Pin) ,
                        new SQLiteParameter("@Fid", model.Fid) ,
                        new SQLiteParameter("@Index", model.Index) ,
                        new SQLiteParameter("@Size",model.Size) ,
                        new SQLiteParameter("@Valid", model.Valid) ,
                        new SQLiteParameter("@Tmp", model.Tmp) ,
                        new SQLiteParameter("@Ver", model.Ver),
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
delete from TmpFvein  where Pin in ({0});", Tools.UnionString(pins));

            return SqliteHelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 清空
        /// </summary>
        /// <returns></returns>
        public int ClearAll()
        {
            string sql = "delete from TmpFvein ";
            return SqliteHelper.ExecuteNonQuery(sql);
        }
    }
}
