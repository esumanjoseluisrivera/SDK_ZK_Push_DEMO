using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;
using BLL;
using Model;

namespace Attendance
{
    /// <summary>
    /// 下发命令管理
    /// </summary>
    public partial class UCDeviceCmd : UserControl
    {
        private DeviceBll _bllDevice = new DeviceBll();
        private DeviceCmdBll _bll = new DeviceCmdBll();

        public UCDeviceCmd()
        {
            InitializeComponent();
        }

        /// <summary>Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCDeviceCmd_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            this.dgvDeviceCmd.AutoGenerateColumns = false;
            LoadDefaultData();
            LoadGridViewData();
        }
        /// <summary>GetAttLog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGet_Click(object sender, EventArgs e)
        {
            LoadGridViewData();
        }
        /// <summary>
        /// 加载GridView 数据
        /// </summary>
        private void LoadGridViewData()
        {
            string devSN = cmbDevSN.Text.Trim();

            //显示数据库中数据
            try
            {
                DataTable dt = _bll.GetByTime(this.dtpStartTime.Value, this.dtpEndTime.Value, devSN);
                this.dgvDeviceCmd.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load attlog info error:" + ex.ToString());
            }
        }

        /// <summary>GetAttlogAll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetAll_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = _bll.GetAll();
                this.dgvDeviceCmd.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load DeviceCmd info error:" + ex.ToString());
            }
        }
        /// <summary>ClearListAttLog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearList_Click(object sender, EventArgs e)
        {
            if (_bll.ClearAll() > 0)
            {
                this.dgvDeviceCmd.DataSource = null;
                this.lblMsg.Visible = true;
                this.lblMsg.Text = "Clear all cmd success";
            }
        }

        /// <summary>
        /// 初始化界面默认数据
        /// </summary>
        private void LoadDefaultData()
        {
            DateTime dtnNow = Tools.GetDateTimeNow();
            this.dtpStartTime.Value = new DateTime(dtnNow.Year, dtnNow.Month, dtnNow.Day, 0, 0, 0);//Today Start
            this.dtpEndTime.Value = new DateTime(dtnNow.Year, dtnNow.Month, dtnNow.Day, 23, 59, 59);//Today End

            //获取数据库中机器序列号
            GetAllDevSNToCmbo();
        }

        /// <summary>
        /// 获取所有机器的序列号
        /// </summary>
        private void GetAllDevSNToCmbo()
        {
            cmbDevSN.Items.Clear();
            cmbDevSN.Items.Add("");//第一行为空，表示全部
            try
            {
                List<string> listSN = _bllDevice.GetAllDevSN();
                int i = 0;

                for (i = 0; i < listSN.Count; i++)
                {
                    cmbDevSN.Items.Add(listSN[i]);
                }
                return;
            }
            catch (Exception)
            {

            }
        }

        /// <summary>The first column shows the sequence number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDeviceCmd_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Index >= 0)
            {
                this.dgvDeviceCmd.Rows[e.Row.Index].Cells["colIndex"].Value = e.Row.Index + 1;
            }
        }
    }
}
