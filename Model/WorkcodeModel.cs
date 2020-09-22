/********************************************
 * Description: Define the Workcode entity
 * Author: 
 * Create Date: 
 ********************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 工作代码
    /// </summary>
    public class WorkCodeModel
    {
        public WorkCodeModel()
        {
            this.WorkCode = "1";
            this.WorkName = "1";
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
        /// work code
        /// </summary>		
        private string _workcode;
        public string WorkCode
        {
            get { return _workcode; }
            set { _workcode = value; }
        }
        /// <summary>
        /// WorkName
        /// </summary>		
        private string _workname;
        public string WorkName
        {
            get { return _workname; }
            set { _workname = value; }
        }
    }
}
