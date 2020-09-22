using Dal;
using Model;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfoBll
    {
        private UserInfoDal _dal = new UserInfoDal();
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Add(UserInfoModel user)
        {
            return _dal.Add(user);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Update(UserInfoModel user)
        {
            return _dal.Update(user);
        }
        /// <summary>
        /// 获取记录
        /// </summary>
        /// <param name="pin"></param>
        /// <returns></returns>
        public UserInfoModel Get(string pin)
        {
            return _dal.Get(pin);
        }
        /// <summary>
        /// 获取记录
        /// </summary>
        /// <param name="pins"></param>
        /// <returns></returns>
        public List<UserInfoModel> Get(List<string> pins)
        {
            return _dal.Get(pins);
        }
        /// <summary>
        /// 获取记录
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            return _dal.GetAll();
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
