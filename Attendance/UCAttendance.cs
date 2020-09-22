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
using System.IO;
using System.Globalization;

namespace Attendance
{
    /// <summary>
    /// 考勤管理
    /// </summary>
    public partial class UCAttendance : UserControl
    {
        private DeviceBll _bllDevice = new DeviceBll();
        private AttLogBll _bll = new AttLogBll();
        private WorkCodeBll _workCodeBll = new WorkCodeBll();
        DataTable _dt = null;
        public UCAttendance()
        {
            InitializeComponent();
        }
        #region 界面初始化
        private void UCAttendance_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            this.dgvAttendance.AutoGenerateColumns = false;
            LoadDefaultData();
        }

        //初始化界面默认数据
        private void LoadDefaultData()
        {
            DateTime dtnNow = Tools.GetDateTimeNow();
            this.dtpStartTime.Value = new DateTime(dtnNow.Year, dtnNow.Month, dtnNow.Day, 0, 0, 0);//Today Start
            this.dtpEndTime.Value = new DateTime(dtnNow.Year, dtnNow.Month, dtnNow.Day, 23, 59, 59);//Today End

            //获取数据库中机器序列号
            GetAllDevSNToCmbo();
            LoadAttlogData();
        }

        //获取所有机器的序列号
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
        #endregion
        #region  列表数据管理
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="attLogModel">考勤记录数据</param>
        public void AddNewRow(AttLogModel attLogModel)
        {
            if(attLogModel.AttTime>=this.dtpStartTime.Value&&attLogModel.AttTime<=this.dtpEndTime.Value)
            {
                DataRow dr = _dt.NewRow();
                dr["PIN"] = attLogModel.PIN;
                dr["AttTime"] = attLogModel.AttTime;
                dr["Status"] = attLogModel.Status;
                dr["Verify"] = attLogModel.Verify;
                dr["WorkCode"] = attLogModel.WorkCode;
                dr["DeviceID"] = attLogModel.DeviceID;
                dr["MaskFlag"] = attLogModel.MaskFlag;
                dr["Temperature"] = attLogModel.Temperature;
                dr["WorkName"] = string.IsNullOrEmpty(attLogModel.WorkCode)?"":_workCodeBll.GetByWorkCode(attLogModel.WorkCode).WorkName;
                _dt.Rows.InsertAt(dr,0);
            }
            

        }
        private void LoadAttlogData()
        {
            string userID = txtUserID.Text.Trim();
            string devSN = cmbDevSN.Text.Trim();

            //显示数据库中数据
            try
            {
                _dt = _bll.GetByTime(this.dtpStartTime.Value, this.dtpEndTime.Value, userID, devSN);
                this.dgvAttendance.DataSource = _dt;
                this.dgvAttendance.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load attlog info error:" + ex.ToString());
            }
        }
        /// <summary>
        /// 获取考勤记录事件
        /// </summary>
        private void btnGetAttLog_Click(object sender, EventArgs e)
        {
            LoadAttlogData();
        }
        /// <summary>
        /// 删除所有数据按钮事件
        /// </summary>
        private void btnClearListAttLog_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete all data?", "Tip", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                if (_bll.ClearAll() > 0)
                {
                    this.dgvAttendance.DataSource = null;
                    this.dgvAttendance.Update();
                }

            }
            
        }
        /// <summary>
        /// 绘制行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAttendance_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(this.dgvAttendance.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, CultureInfo.CurrentUICulture),
                e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvAttendance_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            //Right-click to also select the row
            if (e.Button == MouseButtons.Right)
            {
                this.dgvAttendance.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
            }
            if (this.dgvAttendance.CurrentRow == null)
                return;

            DataGridViewRow row = dgvAttendance.CurrentRow;
            string time = row.Cells["colAttTime"].Value.ToString();
            time = Convert.ToDateTime(time).ToString("yyyyMMddHHmmss", DateTimeFormatInfo.InvariantInfo);
            string PIN = row.Cells["colUserID"].Value.ToString();
            string FileName = Directory.GetCurrentDirectory() + "\\Capture\\" + time+"-"+PIN+".jpg";
            if (!File.Exists(FileName))
                picAttpho.Image = picAttpho.ErrorImage;
            else
                picAttpho.Image = Image.FromFile(FileName);
            picAttpho.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAttpho.Update();
        }
        #endregion
    }
}
