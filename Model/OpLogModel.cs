using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 设备操作日志
    /// </summary>
    public class OpLogModel
    {
        public OpLogModel()
        {
            this.Operator = "";
            this.OpType = "";
            this.Obj1 = "";
            this.Obj2 = "";
            this.Obj3 = "";
            this.Obj4 = "";
            this.User = "";
            this.OpTime = Convert.ToDateTime("1900-01-01 00:00:00");
            this.DeviceID = "";
        }
        // ID
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        //Device SN
        private string _deviceid;
        public string DeviceID
        {
            get { return _deviceid; }
            set { _deviceid = value; }
        }

        //Operator PIN
        private string _admin;
        public string Operator
        {
            get { return _admin; }
            set { _admin = value; }
        }

        //Optime
        private DateTime _optime;
        public DateTime OpTime
        {
            get { return _optime; }
            set { _optime = value; }
        }

        //User Pin be operated
        private string _user;
        public string User
        {
            get { return _user; }
            set { _user = value; }
        }

        //Operator type
        private string _optype;
        public string OpType
        {
            get { return _optype; }
            set { _optype = value; }
        }

        //Obj1
        private string _obj1;
        public string Obj1
        {
            get { return _obj1; }
            set { _obj1 = value; }
        }

        //Obj2
        private string _obj2;
        public string Obj2
        {
            get { return _obj2; }
            set { _obj2 = value; }
        }

        //Obj3
        private string _obj3;
        public string Obj3
        {
            get { return _obj3; }
            set { _obj3 = value; }
        }

        //Obj4
        private string _obj4;
        public string Obj4
        {
            get { return _obj4; }
            set { _obj4 = value; }
        }
    }
}
