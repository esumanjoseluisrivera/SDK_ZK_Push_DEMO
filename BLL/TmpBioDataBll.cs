using Dal;
using Model;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    /// <summary>
    /// 一体化模板
    /// </summary>
    public class TmpBioDataBll
    {
        private TmpBioDataDal _dal = new TmpBioDataDal();

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="sqlWhere"></param>
        /// <returns></returns>
        public List<TmpBioDataModel> Get(string pin,string type)
        {
            return _dal.Get(pin,type);
        }
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(TmpBioDataModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Pin))
                return -1;

            return _dal.Add(model);
        }
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(TmpBioDataModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Pin))
                return -1;

            return _dal.Update(model);
        }
        /// <summary>
        /// IsExist
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool IsExist(TmpBioDataModel model)
        {
            return _dal.IsExist(model);
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
            return _dal.IsExist(pin, no, index, type, majorVer, minorVer);
        }
        /// <summary>
        /// DeleteByPin
        /// </summary>
        /// <param name="pin"></param>
        /// <returns></returns>
        public int DeleteByPin(string pin)
        {
            return _dal.DeleteByPin(pin);
        }
        /// <summary>
        /// ClearAll
        /// </summary>
        /// <returns></returns>
        public int ClearAll()
        {
            return _dal.ClearAll();
        }
    }
}
