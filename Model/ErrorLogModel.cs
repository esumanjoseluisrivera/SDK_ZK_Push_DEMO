using System;

namespace Model
{
    /// <summary>
    /// 设备异常日志
    /// </summary>

    public  class ErrorLogModel
    {
        /// <summary>
        /// Error Code
        /// </summary>
        public string ErrCode { get; set; }
        /// <summary>
        /// Error Message
        /// </summary>
        public string ErrMsg { get; set; }
        /// <summary>
        /// DataOrigin
        /// </summary>
        public string DataOrigin { get; set; }
        /// <summary>
        /// CmdId
        /// </summary>
        public string CmdId { get; set; }
        /// <summary>
        /// Additional
        /// </summary>
        public string Additional { get; set; }
        /// <summary>
        /// Stamp
        /// </summary>
        public string Stamp { get; set; }
        /// <summary>
        /// Device SN
        /// </summary>
        public string DeviceID { get; set; }
    }
}