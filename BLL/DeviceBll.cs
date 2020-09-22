using Dal;
using Model;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    /// <summary>
    /// 设备
    /// </summary>
    public class DeviceBll
    {
        private DeviceDal _dal = new DeviceDal();
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public int Add(DeviceModel device)
        {
            return _dal.Add(device);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="devSN"></param>
        /// <returns></returns>
        public int Delete(string devSN)
        {
            return _dal.Delete(devSN);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public int Update(DeviceModel device)
        {
            return _dal.Update(device);
        }
        /// <summary>
        /// 获取记录
        /// </summary>
        /// <param name="devSN"></param>
        /// <returns></returns>
        public DeviceModel Get(string devSN)
        {
            return _dal.Get(devSN);
        }
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
        /// 更新考勤日志时间戳
        /// </summary>
        /// <param name="stamp"></param>
        /// <param name="devSN"></param>
        public void UpdateAttLogStamp(string stamp, string devSN)
        {
            _dal.UpdateAttLogStamp(stamp, devSN);
        }
        /// <summary>
        /// 更新操作日志时间戳
        /// </summary>
        /// <param name="stamp"></param>
        /// <param name="devSN"></param>
        public void UpdateOperLogStamp(string stamp, string devSN)
        {
            _dal.UpdateOperLogStamp(stamp, devSN);
        }
        /// <summary>
        /// 更新异常日志时间戳
        /// </summary>
        /// <param name="stamp"></param>
        /// <param name="devSN"></param>
        public void UpdateErrorLogStamp(string stamp, string devSN)
        {
            _dal.UpdateErrorLogStamp(stamp, devSN);
        }
        /// <summary>
        /// 更新考勤照片时间戳
        /// </summary>
        /// <param name="stamp"></param>
        /// <param name="devSN"></param>
        public void UpdateAttPhotoStamp(string stamp, string devSN)
        {
            _dal.UpdateAttPhotoStamp(stamp, devSN);
        }
        /// <summary>
        /// 清零所有时间戳
        /// </summary>
        /// <param name="snList"></param>
        public void SetZeroStamp(List<string> snList)
        {
            _dal.SetZeroStamp(snList);
        }
        /// <summary>
        /// 清零考勤日志时间戳
        /// </summary>
        /// <param name="snList"></param>
        public void SetZeroAttLogStamp(List<string> snList)
        {
            _dal.SetZeroAttLogStamp(snList);
        }
        /// <summary>
        /// 设置最后请求时间
        /// </summary>
        /// <param name="DevSN"></param>
        public void SetLastRequestTime(string DevSN)
        {
            _dal.SetLastRequestTime(DevSN);
        }
        /// <summary>
        /// 更新供应商名称
        /// </summary>
        /// <param name="sn"></param>
        /// <param name="vendorName"></param>
        public void UpdateVendorName(string sn, string vendorName)
        {
            _dal.UpdateVendorName(sn, vendorName);
        }
        /// <summary>
        /// 获取所有设备的 SN
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllDevSN()
        {
            return _dal.GetAllDevSN();
        }
    }
}
