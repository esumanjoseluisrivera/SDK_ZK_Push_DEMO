using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Utils
{
    /// <summary>日志
    /// </summary>
    public class Log
    {
        /// <summary>日志文件--全路径
        /// </summary>
        private static string m_logFile = string.Empty;
        private static DateTime m_lastDate = Tools.GetDateTimeNow();
        private static StringBuilder sb = new StringBuilder();
        /// <summary>线程锁对象 
        /// </summary>
        private static object ThreadLock = new object();


        /// <summary>
        /// 获取当前输出日志的日志文件
        /// </summary>
        protected static string LogFile
        {
            get
            {
                if (Tools.GetDateTimeNow().Hour != m_lastDate.Hour || string.IsNullOrEmpty(m_logFile))
                {
                    m_lastDate = Tools.GetDateTimeNow();
                    System.IO.DirectoryInfo dir = new DirectoryInfo(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\ErrorLog");
                    if (!dir.Exists)
                    {
                        dir.Create();
                    }
                    dir = new DirectoryInfo(dir.FullName + "\\" + m_lastDate.ToString("yyyy-MM-dd"));
                    if (!dir.Exists)
                    {
                        dir.Create();
                    }
                    m_logFile = dir.FullName + "\\ErrorLog" + m_lastDate.Hour.ToString("00") + ".txt";
                    if (System.IO.File.Exists(m_logFile))
                    {
                        System.IO.File.Delete(m_logFile);
                    }
                }
                return m_logFile;
            }
        }

        /// <summary>
        /// 输出日志，默认不缓存
        /// </summary>
        /// <param name="msg"></param>
        public static void WriteLog(string msg)
        {
            WriteLog(msg, false);
        }
        /// <summary>
        /// 输出日志，默认缓存
        /// </summary>
        /// <param name="msg"></param>
        public static void WriteLogs(string msg)
        {
            WriteLog(msg, true);
        }

        /// <summary>
        /// 输出日志，可以指定是否缓存
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="issave"></param>
        public static void WriteLog(string msg, bool issave)
        {
            // 增加线程锁。在多线程环境下，StringBuilder.Append方法有时会抛出System.ArgumentOutOfRangeException异常，导致软件崩溃。
            if (Monitor.TryEnter(ThreadLock, 3000))
            {
                try
                {
                    sb.AppendLine(Tools.GetDateTimeNowString());
                    sb.AppendLine(msg).AppendLine();

                    if (sb.Length > 1000 || issave)
                    {
                        string fileName = LogFile;
                        FileInfo file = new FileInfo(fileName);
                        StreamWriter w = new StreamWriter(file.FullName, true, System.Text.Encoding.UTF8);
                        w.Write(sb.ToString());
                        w.Flush();
                        w.Close();
                        w = null;
                        sb = new StringBuilder();
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    //有时在写日志到文件中时会出现异常System.ArgumentOutOfRangeException，导致软件崩溃
                    //因此当出现异常时，把之前的日志抛弃掉，以防日志过长
                    sb = new StringBuilder();
                }
                catch (Exception)
                {
                }
                finally
                {
                    Monitor.Exit(ThreadLock);
                }
            }
        }
    }
}
