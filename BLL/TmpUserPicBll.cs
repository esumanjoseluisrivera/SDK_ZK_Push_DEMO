using Dal;
using Model;
using System.Collections.Generic;

namespace BLL
{
    /// <summary>
    /// 用户照片
    /// </summary>
    public class TmpUserPicBll
    {
        TmpUserPicDal _dal = new TmpUserPicDal();
        /// <summary>
        /// 获取记录
        /// </summary>
        /// <param name="pins"></param>
        /// <returns></returns>
        public List<TmpUserPicModel> Get(List<string> pins)
        {
            return _dal.Get(pins);
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
        public int Add(TmpUserPicModel model)
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
