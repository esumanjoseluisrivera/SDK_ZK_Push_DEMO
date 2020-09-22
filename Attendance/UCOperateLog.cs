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
using System.Globalization;

namespace Attendance
{
    /// <summary>
    /// 设备操作日志管理
    /// </summary>
    public partial class UCOperateLog : UserControl
    {
        OpLogBll _bll = new OpLogBll();
        public UCOperateLog()
        {
            InitializeComponent();
        }
 

        #region 界面初始化

        private void UCOperateLog_Load(object sender, EventArgs e)
        {
            this.dgvOperate.AutoGenerateColumns = false;
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
              DateTime dtnNow = Tools.GetDateTimeNow();
            this.dtpStartTime.Value = new DateTime(dtnNow.Year, dtnNow.Month, dtnNow.Day, 0, 0, 0);//Today Start
            this.dtpEndTime.Value = new DateTime(dtnNow.Year, dtnNow.Month, dtnNow.Day, 23, 59, 59);//Today End
            //获取数据库中机器序列号
            GetAllDevSNToCmbo();
            //初始化界面默认数据
            LoadDefaultData();
        }
        /// <summary>
        /// 初始化界面默认数据
        /// </summary>
        private void LoadDefaultData()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => { LoadDefaultData(); }));
            }
            else
            {
                string devSN = cmb_DevSN.Text.Trim();

                //显示数据库中数据
                try
                {
                    DataTable dt = _bll.GetOplogByTime(this.dtpStartTime.Value, this.dtpEndTime.Value, devSN);

                    this.dgvOperate.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Load operatelog info error:" + ex.ToString());
                }
            }
            
            
            
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        public void RefreshData()
        {

            LoadDefaultData();
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
 
        /// <summary>
        /// 按时间段获取操作日志
        /// </summary>
        private void btnGetPeriodLog_Click(object sender, EventArgs e)
        {
            LoadDefaultData();
        }
        /// <summary>
        /// 删除所有操作日志按钮事件
        /// </summary>
        private void btnClearOpLog_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you want to delete all data?", "Tip", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                if (_bll.ClearAll()>0)
                {
                    this.dgvOperate.DataSource = null;
                }
                
            }
        }
        /// <summary>
        /// 绘制行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvOperate_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(this.dgvOperate.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, CultureInfo.CurrentUICulture),
                e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            }
        }

        #endregion

    }
}
