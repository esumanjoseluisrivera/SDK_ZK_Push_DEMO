using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 一体化模板
    /// </summary>
    public class TmpBioDataModel
    {
        public TmpBioDataModel()
        {
            this.No = "0";
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
        /// "生物具体个体编号， 默认值为0
        ///【指纹】 编号是： 0-9， 对应的手指是： 左手： 小拇指/无名指/中指/食指/拇指, 右手： 拇指/食
        ///指/中指/无名指/小拇指；
        ///【指静脉】 和指纹相同
        ///【面部】 都为0
        ///【虹膜】 0为左眼 1为右眼
        ///【手掌】 0为左手 1为右手"
        /// </summary>		
        private string _no;
        public string No
        {
            get { return _no; }
            set { _no = value; }
        }
        /// <summary>
        /// 人员工号
        /// </summary>		
        private string _pin;
        public string Pin
        {
            get { return _pin; }
            set { _pin = value; }
        }
        /// <summary>
        /// 生物具体个体模板编号， 如1个手指存储多枚模板。 从0开始计算
        /// </summary>		
        private string _index;
        public string Index
        {
            get { return _index; }
            set { _index = value; }
        }
        /// <summary>
        /// 是否有效标示， 0： 无效， 1： 有效， 默认为1
        /// </summary>		
        private string _valid;
        public string Valid
        {
            get { return _valid; }
            set { _valid = value; }
        }
        /// <summary>
        /// 是否胁迫标示， 0： 非胁迫， 1： 胁迫， 默认为0
        /// </summary>		
        private string _duress;
        public string Duress
        {
            get { return _duress; }
            set { _duress = value; }
        }
        /// <summary>
        /// "生物识别类型
        ///值 意义
        ///0 通用的
        ///1 指纹
        ///2 面部
        ///3 声纹
        ///4 虹膜
        ///5 视网膜
        ///6 掌纹
        ///7 指静脉
        ///8 手掌
        ///9 可见光面部"
        /// </summary>		
        private string _type;
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        /// <summary>
        /// "主版本号， 如： 指纹算法版本10.3， 主版本是10， 副版本是3
        ///【指纹】 9.0、 10.3及12.054
        ///【 指静脉】 3.0
        ///【 面部】 5.0、 7.0和8.0
        ///【 手掌】 1.0"
        /// </summary>		
        private string _majorVer;
        public string MajorVer
        {
            get { return _majorVer; }
            set { _majorVer = value; }
        }
        /// <summary>
        /// "副版本号， 如： 指纹算法版本10.3， 主版本是10， 副版本是3
        ///【 指纹】 9.0、 10.3及12.0
        ///【 指静脉】 3.0
        ///【 面部】 5.0、 7.0和8.0
        ///【 手掌】 1.0"
        /// </summary>		
        private string _minorVer;
        public string MinorVer
        {
            get { return _minorVer; }
            set { _minorVer = value; }
        }
        /// <summary>
        /// "模板格式， 如指纹有ZK\ISO\ANSI等格式
        ///【 指纹】
        ///值 格式
        ///0 ZK
        ///1 ISO
        ///2 ANSI
        ///【 指静脉】
        ///值 格式
        ///0 ZK
        ///【 面部】
        ///值 格式
        ///0 ZK
        ///【 手掌】
        ///值 格式
        ///0 ZK"
        /// </summary>		
        private string _format;
        public string Format
        {
            get { return _format; }
            set { _format = value; }
        }
        /// <summary>
        /// 模板数据， 需要对原始二进制指纹模版进行base64编码
        /// </summary>		
        private string _tmp;
        public string Tmp
        {
            get { return _tmp; }
            set { _tmp = value; }
        }
    }
}
