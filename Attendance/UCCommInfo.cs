using System;
using System.Windows.Forms;
using Utils;

namespace Attendance
{
    /// <summary>
    /// 服务器客户端实时交互信息
    /// </summary>
    public partial class UCCommInfo : UserControl
    {
        private bool _IsPause = false;

        public UCCommInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 显示服务器版本号
        /// </summary>
        /// <param name="verString"></param>
        public void ShowVersion(string verString)
        {
            verString = string.IsNullOrEmpty(verString) ? "1.0.0.0" : verString;

            this.lblVersion.Text = string.Format("Version: {0}   ", verString);
        }

        /// <summary>
        /// 增加交互信息
        /// </summary>
        /// <param name="info"></param>
        /// <param name="Mode"></param>
        public void AddCommInfo(string info, int Mode)
        {
            if (_IsPause)
                return;

            string strNow = Tools.GetDateTimeNow().ToString("yyyy-MM-dd HH:mm:ss:fff");

            if (0 == Mode)
            {
                info = string.Format("Sever Receive Data:  {0}\r\n{1}\r\n", strNow, info.TrimEnd('\x00'));
            }
            else if (1 == Mode)
            {
                info = string.Format("Sever Send Data:  {0}\r\n{1}\r\n", strNow, info);
            }
            else if (3 == Mode)
            {
                info = string.Format("Sever Start:  {0}\r\n{1}\r\n", strNow, info);
            }
            else if (4 == Mode)
            {
                info = string.Format("Sever Stop:  {0}\r\n{1}\r\n", strNow, info);
            }
            this.rtxtCommInfo.AppendText(info);

            //写入本地txt 文件
            ServerLogToFile.WriteLogs(info);
        }

        /// <summary>
        /// 清空信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.rtxtCommInfo.Clear();
        }
        /// <summary>
        /// 暂停/继续
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPause_Click(object sender, EventArgs e)
        {
            _IsPause = !_IsPause;
            btnPause.Text = _IsPause ? "Resume" : "Pause";
        }
    }
}
