using Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using Utils;

namespace Dal
{
    /// <summary>
    /// 一体化模板
    /// </summary>
    public class TmpBioDataDal
    {
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="pins"></param>
        /// <param name="ver"></param>
        /// <returns></returns>
        public List<TmpBioDataModel> Get(string pin, string type)
        {
            string sql = string.Format(@"
select * from TmpBioData where pin = '{0}' and type='{1}';", pin, type);

            DataTable dt = SqliteHelper.GetDataTable(sql);
            if (dt == null || dt.Rows.Count == 0)
                return new List<TmpBioDataModel>();

            List<TmpBioDataModel> bioList = new List<TmpBioDataModel>();
            foreach (DataRow row in dt.Rows)
            {
                TmpBioDataModel bio = new TmpBioDataModel();
                bio.ID = Tools.TryConvertToInt32(row["ID"].ToString());
                bio.Pin = row["PIN"].ToString();
                bio.No = row["No"].ToString();
                bio.Index = row["Index"].ToString();
                bio.Valid = row["Valid"].ToString();
                bio.Duress = row["Duress"].ToString();
                bio.Type = row["Type"].ToString();
                bio.MajorVer = row["MajorVer"].ToString();
                bio.MinorVer = row["MinorVer"].ToString();
                bio.Format = row["Format"].ToString();
                bio.Tmp = row["Tmp"].ToString();
             
                bioList.Add(bio);
            }
            return bioList;
        }
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="sqlWhere"></param>
        /// <returns></returns>
        public DataTable Get(string sqlWhere)
        {
            sqlWhere = string.IsNullOrEmpty(sqlWhere) ? "" : "where " + sqlWhere;
            string sql = string.Format(@"
select *
 from TmpBioData {0};", sqlWhere);

            return SqliteHelper.GetDataTable(sql);
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(TmpBioDataModel model)
        {
            //判断是否存在，存在则更新
            if (IsExist(model))
            {
                return Update(model);
            }

            string sql = string.Format(@"
insert into TmpBioData(
     [Pin], [No], [Index], [Valid], [Duress], [Type], [MajorVer], [MinorVer], [Format], [Tmp]
  ) values (
      @Pin, @No, @Index, @Valid, @Duress, @Type, @MajorVer, @MinorVer, @Format, @Tmp
);");

            SQLiteParameter[] parameters = {                  
                    new SQLiteParameter("@Pin", model.Pin.ToLower()) ,
                    new SQLiteParameter("@No", model.No) ,
                    new SQLiteParameter("@Index", model.Index) ,
                    new SQLiteParameter("@Valid", model.Valid) ,
                    new SQLiteParameter("@Duress", model.Duress) ,
                    new SQLiteParameter("@Type", model.Type.ToLower()) ,
                    new SQLiteParameter("@MajorVer", model.MajorVer.ToLower()) ,
                    new SQLiteParameter("@MinorVer", model.MinorVer.ToLower()) ,
                    new SQLiteParameter("@Format", model.Format.ToLower()) ,
                    new SQLiteParameter("@Tmp", model.Tmp)
            };
            return SqliteHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(TmpBioDataModel model)
        {
            string sql = string.Format(@"
update TmpBioData set
     [Valid]=@Valid
   , [Duress]=@Duress
   , [Format]=@Format
   , [Tmp]=@Tmp 
where [pin]=@Pin 
    and [no]=@No
    and [index]=@Index
    and [Type]=@Type;
    and [MajorVer]=@MajorVer
    and [MinorVer]=@MinorVer
 ");

            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@Pin", model.Pin) ,
                    new SQLiteParameter("@No", model.No) ,
                    new SQLiteParameter("@Index", model.Index) ,
                    new SQLiteParameter("@Valid", model.Valid) ,
                    new SQLiteParameter("@Duress", model.Duress) ,
                    new SQLiteParameter("@Type", model.Type.ToLower()) ,
                    new SQLiteParameter("@MajorVer", model.MajorVer.ToLower()) ,
                    new SQLiteParameter("@MinorVer", model.MinorVer.ToLower()) ,
                    new SQLiteParameter("@Format", model.Format) ,
                    new SQLiteParameter("@Tmp", model.Tmp)
            };
            return SqliteHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// IsExist
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool IsExist(TmpBioDataModel model)
        {
            return IsExist(model.Pin, model.No, model.Index, model.Type, model.MajorVer, model.MinorVer);
        }
        /// <summary>
        /// IsExist
        /// </summary>
        /// <param name="pin"></param>
        /// <param name="no"></param>
        /// <param name="index"></param>
        /// <param name="type"></param>
        /// <param name="majorVer"></param>
        /// <param name="minorVer"></param>
        /// <returns></returns>
        public bool IsExist(string pin, string no, string index, string type, string majorVer, string minorVer)
        {
            string sql = string.Format(@"
select 1 from TmpBioData
where [pin]=@Pin 
    and [no]=@No
    and [index]=@Index
    and [Type]=@Type
    and [MajorVer]=@MajorVer
    and [MinorVer]=@MinorVer
 ");

            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@Pin", pin) ,
                    new SQLiteParameter("@No", no) ,
                    new SQLiteParameter("@Index", index) ,
                    new SQLiteParameter("@Type", type.ToLower()) ,
                    new SQLiteParameter("@MajorVer", majorVer.ToLower()) ,
                    new SQLiteParameter("@MinorVer", minorVer.ToLower())
            };
            DataTable dt = SqliteHelper.GetDataTable(sql, parameters);
            if (dt != null && dt.Rows.Count > 0)
                return true;

            return false;
        }
        /// <summary>
        /// 删除--根据Pin
        /// </summary>
        /// <param name="pin"></param>
        /// <returns></returns>
        public int DeleteByPin(string pin)
        {
            string sql = string.Format(@"
delete from TmpBioData where pin='{0}';", pin);

            return SqliteHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 清空
        /// </summary>
        /// <returns></returns>
        public int ClearAll()
        {
            string sql = "delete from TmpBioData ";
            return SqliteHelper.ExecuteNonQuery(sql);
        }
    }
}
