using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    /// <summary>
    /// 下发命令
    /// </summary>
    public class DeviceCmdBll
    {
        private DeviceCmdDal _dal = new DeviceCmdDal();
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="dCmd"></param>
        /// <returns></returns>
        public int Add(DeviceCmdModel dCmd)
        {
            return _dal.Add(dCmd);
        }
        /// <summary>
        /// 下发命令
        /// </summary>
        /// <param name="devSN"></param>
        /// <returns></returns>
        public string Send(string devSN)
        {
            return _dal.Send(devSN);
        }
        /// <summary>
        /// 获取记录
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="devSN"></param>
        /// <returns></returns>
        public DataTable GetByTime(DateTime startTime, DateTime endTime, string devSN)
        {
            return _dal.GetByTime(startTime, endTime, devSN);
        }
        /// <summary>
        /// 获取所有记录
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            return _dal.GetAll();
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="arrContent"></param>
        public void Update(string arrContent)
        {
            _dal.Update(arrContent);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int Delete(List<string> ids)
        {
            return _dal.Delete(ids);
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
