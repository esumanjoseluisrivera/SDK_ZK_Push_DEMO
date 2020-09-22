using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// ÏÂ·¢ÃüÁî
    /// </summary>
    public class DeviceCmdModel
    {
        public DeviceCmdModel()
        {
            this.DevSN = "1";
            this.CommitTime = Convert.ToDateTime("1900-01-01 00:00:00");
            this.Content = "";
            this.ResponseTime = Convert.ToDateTime("1900-01-01 00:00:00");
            this.TransTime = Convert.ToDateTime("1900-01-01 00:00:00");
            this.ReturnValue = "";
        }

        /// <summary>
        /// ID
        /// </summary>		
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// DevSN
        /// </summary>		
        private string _devsn;
        public string DevSN
        {
            get { return _devsn; }
            set { _devsn = value; }
        }
        /// <summary>
        /// Content
        /// </summary>		
        private string _content;
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        /// <summary>
        /// CommitTime
        /// </summary>		
        private DateTime _committime;
        public DateTime CommitTime
        {
            get { return _committime; }
            set { _committime = value; }
        }
        /// <summary>
        /// TransTime
        /// </summary>		
        private DateTime _transtime;
        public DateTime TransTime
        {
            get { return _transtime; }
            set { _transtime = value; }
        }
        /// <summary>
        /// ResponseTime
        /// </summary>		
        private DateTime _responsetime;
        public DateTime ResponseTime
        {
            get { return _responsetime; }
            set { _responsetime = value; }
        }
        /// <summary>
        /// ReturnValue
        /// </summary>		
        private string _returnvalue;
        public string ReturnValue
        {
            get { return _returnvalue; }
            set { _returnvalue = value; }
        }

    }
}
