using Dal;
using Model;
using System.Collections.Generic;

namespace BLL
{
    /// <summary>
    /// 比对照片
    /// </summary>
    public class TmpBioPhotoBll
    {
        TmpBioPhotoDal _dal = new TmpBioPhotoDal();
        /// <summary>
        /// 获取记录
        /// </summary>
        /// <param name="pins"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<TmpBioPhotoModel> Get(string pin, string type)
        {
            return _dal.Get(pin, type);
        }
        /// <summary>
        /// 获取数量
        /// </summary>
        /// <param name="pin"></param>
        /// <returns></returns>
        public int GetCount(string pin)
        {
            return _dal.GetCount(pin);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(TmpBioPhotoModel model)
        {
            return _dal.Add(model);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="pins"></param>
        /// <returns></returns>
        public int Delete(List<string> pins)
        {
            return _dal.Delete(pins);
        }
        /// <summary>
        /// 清空
        /// </summary>
        /// <returns></returns>
        public int ClearAll()
        {
            return _dal.ClearAll();
        }
    }
}

