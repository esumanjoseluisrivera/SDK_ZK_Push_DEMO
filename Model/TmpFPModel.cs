using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 指纹模板
    /// </summary>
    public class TmpFPModel
    {
        public TmpFPModel()
        {
            this.Fid = "0";
            this.Size = 0;
            this.Valid = "1";            
            this.Duress = "0";
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
        /// PIN
        /// </summary>		
        private string _pin;
        public string Pin
        {
            get { return _pin; }
            set { _pin = value; }
        }
        /// <summary>
        /// FID
        /// </summary>		
        private string _fid;
        public string Fid
        {
            get { return _fid; }
            set { _fid = value; }
        }
        /// <summary>
        /// Size
        /// </summary>		
        private int _size;
        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }
        /// <summary>
        /// Valid
        /// </summary>		
        private string _valid;
        public string Valid
        {
            get { return _valid; }
            set { _valid = value; }
        }
        /// <summary>
        /// TmpStr
        /// </summary>		
        private string _tmp;
        public string Tmp
        {
            get { return _tmp; }
            set { _tmp = value; }
        }

        /// <summary>
        /// Version
        /// </summary>		
        private string _majorVer;
        public string MajorVer
        {
            get { return _majorVer; }
            set { _majorVer = value; }
        }
        /// <summary>
        /// Version
        /// </summary>		
        private string _minorVer;
        public string MinorVer
        {
            get { return _minorVer; }
            set { _minorVer = value; }
        }
        /// <summary>
        /// Duress
        /// </summary>		
        private string _duress;
        public string Duress
        {
            get { return _duress; }
            set { _duress = value; }
        }
    }
}
