using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    /// <summary>
    /// 设备操作日志
    /// </summary>
    public class OpLogBll
    {
        private OpLogDal _dal = new OpLogDal();
        /// <summary>
        /// 获取记录
        /// </summary>
        /// <returns></returns>
        public List<OpLogModel> Get()
        {
            return _dal.Get();
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
        /// 获取记录
        /// </summary>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="devsn"></param>
        /// <returns></returns>
        public DataTable GetOplogByTime(DateTime starttime, DateTime endtime, string devsn)
        {
            return _dal.GetOplogByTime(starttime,endtime,devsn);
        }
        /// <summary>
        /// 清空记录
        /// </summary>
        /// <returns></returns>
        public int ClearAll()
        {
            return _dal.ClearAll();
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="oplog"></param>
        /// <returns></returns>
        public int Add(OpLogModel oplog)
        {
            return _dal.Add(oplog);
        }
    }
}
