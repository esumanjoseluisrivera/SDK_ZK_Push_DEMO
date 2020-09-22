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
    /// 工作代码
    /// </summary>
    public class WorkCodeBll
    {
        private WorkCodeDal _dal = new WorkCodeDal();
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="workCode"></param>
        /// <returns></returns>
        public int Add(WorkCodeModel workCode)
        {
            return _dal.Add(workCode);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="workCode"></param>
        /// <returns></returns>
        public int Delete(string workCode)
        {
            return _dal.Delete(workCode);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="workCode"></param>
        /// <returns></returns>
        public int Update(WorkCodeModel workCode)
        {
            return _dal.Update(workCode);
        }
        /// <summary>
        /// 获取记录
        /// </summary>
        /// <param name="workCode"></param>
        /// <returns></returns>
        public WorkCodeModel GetByWorkCode(string workCode)
        {
            return _dal.GetByWorkCode(workCode);
        }
        /// <summary>
        /// 获取记录
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            return _dal.GetAll();
        }
    }
}
