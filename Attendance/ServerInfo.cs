using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Attendance
{
    /// <summary>
    /// 服务器信息
    /// </summary>
    public class ServerInfo
    {
        /// <summary>
        /// 服务器支持的协议版本号
        /// </summary>
        public const string VERSION = "2.2.14";
        /// <summary>
        /// 服务端依据哪个协议版本开发的
        /// </summary>
        public const string PushProtVer = "2.4.1";

        /// <summary>
        /// 软件是否支持设备推送配置参数请求， 0不支持， 1支持， 未设置时默认不支持。
        /// </summary>
        public const string PushOptionsFlag = "1";
    }
}
