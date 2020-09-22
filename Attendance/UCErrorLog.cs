using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Utils;
using Model;

namespace Attendance
{
    /// <summary>
    /// 设备异常日志管理
    /// </summary>
    public partial class UCErrorLog : UserControl
    {
        private ErrorLogBll _bll = new ErrorLogBll();
        private DataTable _dt = new DataTable();
        public UCErrorLog()
        {
            InitializeComponent();
        }
        #region 界面初始化
        private void UCErrorLog_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            this.dgvErrorLog.AutoGenerateColumns = false;

            GetAllDevSNToCmbo();
            LoadDefaultData("");
        }
        /// <summary>
        /// 初始化界面默认数据
        /// </summary>
        /// <param name="SN">设备序列号</param>
        private void LoadDefaultData(string SN)
        {
            try
            {
                _dt = _bll.GetAll(SN);
                this.dgvErrorLog.DataSource = _dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load attlog info error:" + ex.ToString());
            }
        }
        /// <summary>
        /// 获取所有机器的序列号
        /// </summary>
        private void GetAllDevSNToCmbo()
        {
            cmb_DevSN.Items.Clear();
            cmb_DevSN.Items.Add("");//第一行为空，表示全部
            try
            {
                List<string> listSN = new DeviceBll().GetAllDevSN();
                int i = 0;

                for (i = 0; i < listSN.Count; i++)
                {
                    cmb_DevSN.Items.Add(listSN[i]);
                }
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetAllDevSNToCmbo error:" + ex.ToString());
            }
        }

        #endregion

        #region 列表数据管理
        public void AddNewRow(ErrorLogModel errorLogModel)
        {
            if (_dt.Rows.Count == 0)
            {
                LoadDefaultData("");
                return;
            }
            DataRow dataRow = _dt.NewRow();
            dataRow["ErrorCode"] = errorLogModel.ErrCode;
            dataRow["ErrorCode"] = errorLogModel.ErrMsg;
            dataRow["ErrorCode"] = errorLogModel.DataOrigin;
            dataRow["ErrorCode"] = errorLogModel.CmdId;
            dataRow["ErrorCode"] = errorLogModel.Additional;
            dataRow["DeviceID"] = errorLogModel.DeviceID;
            _dt.Rows.InsertAt(dataRow,0);

            this.dgvErrorLog.DataSource = _dt;
        }
        /// <summary>
        /// 搜索按钮事件
        /// </summary>
        private void pb_Search_Click(object sender, EventArgs e)
        {
            LoadDefaultData(this.cmb_DevSN.Text.Trim());
        }
        /// <summary>
        /// 删除所有数据按钮事件
        /// </summary>

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete all data?", "Tip", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                if (_bll.ClearAll() > 0)
                {
                    this.dgvErrorLog.DataSource = null;
                }

            }
           
        }
        /// <summary>
        /// 第一列--序号赋值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvErrorLog_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Index >= 0)
            {
                this.dgvErrorLog.Rows[e.Row.Index].Cells["colIndex"].Value = e.Row.Index + 1;
            }
        }
        #endregion


    }
}
