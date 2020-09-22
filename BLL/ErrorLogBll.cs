using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// 设备异常日志
    /// </summary>
    public class ErrorLogBll
    {
        private ErrorLogDal _dal = new ErrorLogDal();
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(ErrorLogModel model)
        {
            return _dal.Add(model);
        }
        /// <summary>
        /// 获取记录
        /// </summary>
        /// <param name="SN"></param>
        /// <returns></returns>
        public DataTable GetAll(string SN)
        {
            return _dal.GetAll(SN);
        }
        /// <summary>
        /// 清空记录
        /// </summary>
        /// <returns></returns>
        public int ClearAll()
        {
            return _dal.ClearAll();
        }
    }
}
