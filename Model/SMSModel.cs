using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 短消息
    /// </summary>
    public class SMSModel
    {
        public SMSModel()
        {
            this.BeginTime = Convert.ToDateTime("1900-01-01 00:00:00");
            this.Content = "";
            this.ValidTime = 60;
            this.Type = 254;
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
        /// SMSId
        /// </summary>		
        private int _smsid;
        public int SMSId
        {
            get { return _smsid; }
            set { _smsid = value; }
        }
        /// <summary>
        /// Type
        /// </summary>		
        private int _type;
        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }
        /// <summary>
        /// BeginTime
        /// </summary>		
        private DateTime _begintime;
        public DateTime BeginTime
        {
            get { return _begintime; }
            set { _begintime = value; }
        }
        /// <summary>
        /// VaildTime
        /// </summary>		
        private int _validtime;
        public int ValidTime
        {
            get { return _validtime; }
            set { _validtime = value; }
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
        /// UserID
        /// </summary>		
        private string _userid;
        public string UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }
    }
}
