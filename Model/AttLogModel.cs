using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 考勤日志
    /// </summary>
    public class AttLogModel
    {

        /// <summary>
        /// ID
        /// </summary>	
        public AttLogModel()
        {
            this.PIN = "1";
            this.AttTime = Convert.ToDateTime("1900-01-01 00:00:00");
            this.DeviceID = "0";
            this.Status = "0";
            this.Verify = "0";
            this.Reserved1 = "0";
            this.Reserved2 = "0";
            this.WorkCode = "0";
        }
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// PIN
        /// </summary>		
        private string _pin;
        public string PIN
        {
            get { return _pin; }
            set { _pin = value; }
        }
        /// <summary>
        /// AttTime
        /// </summary>		
        private DateTime _atttime;
        public DateTime AttTime
        {
            get { return _atttime; }
            set { _atttime = value; }
        }
        /// <summary>
        /// Status
        /// </summary>		
        private string _status;
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }
        /// <summary>
        /// Verify
        /// </summary>		
        private string _verify;
        public string Verify
        {
            get { return _verify; }
            set { _verify = value; }
        }
        /// <summary>
        /// WorkCode
        /// </summary>		
        private string _workcode;
        public string WorkCode
        {
            get { return _workcode; }
            set { _workcode = value; }
        }
        /// <summary>
        /// Reserved1
        /// </summary>		
        private string _reserved1;
        public string Reserved1
        {
            get { return _reserved1; }
            set { _reserved1 = value; }
        }
        /// <summary>
        /// Reserved2
        /// </summary>		
        private string _reserved2;
        public string Reserved2
        {
            get { return _reserved2; }
            set { _reserved2 = value; }
        }
        /// <summary>
        /// 口罩
        /// </summary>
        private int _maskflag;
        public int MaskFlag
        {
            get { return _maskflag; }
            set { _maskflag = value; }
        }
        /// <summary>
        /// 体温
        /// </summary>
        private string _temperature;
        public string Temperature
        {
            get { return _temperature; }
            set { _temperature = value; }
        }
        /// <summary>
        /// Device SN
        /// </summary>
        private string _deviceid;
        public string DeviceID
        {
            get { return _deviceid; }
            set { _deviceid = value; }
        }
    }
}
