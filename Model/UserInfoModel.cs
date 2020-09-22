using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfoModel
    {
        public UserInfoModel()
        {
            this.DevSN = "1";
            this.Grp = "0";
            this.IDCard = "0";
            this.Passwd = "0";
            this.Pri = "0";
            this.TZ = "0";
            this.UserName = "";
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

        private string _devsn;
        public string DevSN
        {
            get { return _devsn; }
            set { _devsn = value; }
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
        /// UserName
        /// </summary>		
        private string _username;
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }
        /// <summary>
        /// Passwd
        /// </summary>		
        private string _passwd;
        public string Passwd
        {
            get { return _passwd; }
            set { _passwd = value; }
        }
        /// <summary>
        /// IDCard
        /// </summary>		
        private string _idcard;
        public string IDCard
        {
            get { return _idcard; }
            set { _idcard = value; }
        }
        /// <summary>
        /// Grp
        /// </summary>		
        private string _grp;
        public string Grp
        {
            get { return _grp; }
            set { _grp = value; }
        }
        /// <summary>
        /// TZ
        /// </summary>		
        private string _tz;
        public string TZ
        {
            get { return _tz; }
            set { _tz = value; }
        }
        /// <summary>
        /// Pri
        /// </summary>		
        private string _pri;
        public string Pri
        {
            get { return _pri; }
            set { _pri = value; }
        }
    }
}
