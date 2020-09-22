using Dal;
using Model;
using System.Collections.Generic;

namespace BLL
{
    /// <summary>
    /// 人脸模板
    /// </summary>
    public class TmpFaceBll
    {
        TmpFaceDal _dal = new TmpFaceDal();
        /// <summary>
        /// 获取记录
        /// </summary>
        /// <param name="pins"></param>
        /// <param name="ver"></param>
        /// <returns></returns>
        public List<TmpFaceModel> Get(string pin)
        {
            return _dal.Get(pin);
        }
        /// <summary>
        /// 获取数量
        /// </summary>
        /// <param name="pin"></param>
        /// <param name="ver"></param>
        /// <returns></returns>
        public int GetCount(string pin, string ver)
        {
            return _dal.GetCount(pin, ver);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(TmpFaceModel model)
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
