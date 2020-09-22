using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 指静脉模板--Model
    /// </summary>
    public class TmpFveinModel
    {
        public TmpFveinModel()
        {
            this.Fid = "0";
            this.Index = "0";
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
        /// Index
        /// </summary>		
        private string _index;
        public string Index
        {
            get { return _index; }
            set { _index = value; }
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
        private string _ver;
        public string Ver
        {
            get { return _ver; }
            set { _ver = value; }
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
