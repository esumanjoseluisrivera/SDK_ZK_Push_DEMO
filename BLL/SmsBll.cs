using Dal;
using Model;
using System.Data;

namespace BLL
{
    /// <summary>
    /// 短消息
    /// </summary>
    public class SmsBll
    {
        private SmsDal _dal = new SmsDal();
        /// <summary>
        /// 获取记录
        /// </summary>
        /// <param name="sqlWhere"></param>
        /// <returns></returns>
        public DataTable GetAll(string sqlWhere)
        {
            return _dal.GetAll(sqlWhere);
        }
        /// <summary>
        /// 获取记录
        /// </summary>
        /// <param name="smsID"></param>
        /// <returns></returns>
        public SMSModel Get(string smsID)
        {
            return _dal.Get(smsID);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(SMSModel model)
        {
            return _dal.Add(model);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="smsID"></param>
        /// <returns></returns>
        public int Delete(string smsID)
        {
            return _dal.Delete(smsID);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(SMSModel model)
        {
            return _dal.Update(model);
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
