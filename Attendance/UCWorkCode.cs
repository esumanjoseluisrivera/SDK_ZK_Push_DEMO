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
using Model;

namespace Attendance
{
    /// <summary>
    /// 工作代码管理
    /// </summary>
    public partial class UCWorkCode : UserControl
    {
        WorkCodeBll _bll = new WorkCodeBll();
        private DeviceCmdBll _cmdBll = new DeviceCmdBll();
        DataTable _dt = null;
        public UCWorkCode()
        {
            InitializeComponent();
        }


        private void UCWorkCode_Load(object sender, EventArgs e)
        {
            this.dgvWorkCode.AutoGenerateColumns = false;
            LoadAllWorkCode();
            LoadDeviceSN(); //加载当前在线的所有机器的序列号sn
        }
        /// <summary>
        /// 加载工作代码
        /// </summary>
        private void LoadAllWorkCode()
        {
            try
            {
                _dt = _bll.GetAll();
                this.dgvWorkCode.DataSource = _dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load workcode info error:" + ex.ToString());
            }
        }
        /// <summary>
        /// 加载所有设备序列号
        /// </summary>
        private void LoadDeviceSN()
        {
            cmbDevice.Items.Clear();
            DeviceBll deviceBll = new DeviceBll();
            try
            {
                List<string> listDevSN = deviceBll.GetAllDevSN();

                for (int i = 0; i < listDevSN.Count; i++)
                {
                    cmbDevice.Items.Add(listDevSN[i]); //添加在Device选择项中
                }
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Device Message error:" + ex.ToString());
            }
        }
        /// <summary>
        /// 新增-初始化数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            tb_WorkCode.Text = "";
            tb_WorkName.Text = "";
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_WorkCode.Text))
            {
                this.lblMsg.Visible = true;
                this.lblMsg.Text = "Please input workcode.";
                return;
            }
            lblMsg.Visible = false;
            WorkCodeModel model = _bll.GetByWorkCode(tb_WorkCode.Text.Trim());
            if (model == null)
            {
                model = new WorkCodeModel();
            }
            model.WorkCode = tb_WorkCode.Text.Trim();
            model.WorkName = tb_WorkName.Text.Trim();

            int ret = 0;
            try
            {
                if (model.ID == 0)
                {
                    ret = _bll.Add(model);
                    if (ret > 0)
                    {
                        LoadAllWorkCode();
                        this.lblMsg.Visible = true;
                        this.lblMsg.Text = "Add successful.";
                    }
                    else
                    {
                        this.lblMsg.Visible = true;
                        this.lblMsg.Text = "Add fail.";
                    }
                }
                else
                {
                    ret = _bll.Update(model);
                    if (ret > 0)
                    {
                        LoadAllWorkCode();
                        this.lblMsg.Visible = true;
                        this.lblMsg.Text = "Update successful.";
                    }
                    else
                    {
                        this.lblMsg.Visible = true;
                        this.lblMsg.Text = "Update fail.";
                    }
                }

            }
            catch (Exception ex)
            {
                this.lblMsg.Visible = true;
                this.lblMsg.Text = ex.ToString();
            }
        }
        /// <summary>
        /// 下发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (null == new DeviceBll().Get(cmbDevice.Text))
            {
                lblMsg.Text = "Please input Device SN.";
                return;
            }
            if (null == _bll.GetByWorkCode(tb_WorkCode.Text.Trim()))
            {
                lblMsg.Text = "Please save workcode first.";
                return;
            }

            if (string.IsNullOrWhiteSpace(tb_WorkCode.Text.Trim()))
            {
                lblMsg.Text = "Please select workcode item.";
                return;
            }
            DeviceCmdModel cmd = new DeviceCmdModel();
            cmd.DevSN = cmbDevice.Text;
            cmd.CommitTime = DateTime.Now;
            string workName = tb_WorkName.Text;
            byte[] bName = Encoding.UTF8.GetBytes(workName);

            workName = Encoding.Default.GetString(bName);

            cmd.Content = string.Format(Commands.Command_UpdateWorkCode, _dt.Select($"workcode='{tb_WorkCode.Text.Trim()}'")[0]["ID"].ToString(), tb_WorkCode.Text.Trim(), workName);

            if (string.IsNullOrEmpty(cmd.Content))
            {
                lblMsg.Text = "The command is error.";
                return;
            }
            lblMsg.Visible = true;
            try
            {
                if (_cmdBll.Add(cmd) >= 0)
                {
                    lblMsg.Text = "Operate successful.";
                }
                else
                {
                    lblMsg.Text = "Operate fail.";
                }
            }
            catch { }

        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(tb_WorkCode.Text))
            {
                this.lblMsg.Visible = true;
                this.lblMsg.Text = "Please select workcode item.";
                return;
            }
            lblMsg.Visible = false;
            WorkCodeModel model = _bll.GetByWorkCode(tb_WorkCode.Text.Trim());
            if (null == model)
            {
                this.lblMsg.Visible = true;
                this.lblMsg.Text = "The workcode is not exist.";
                return;
            }
            lblMsg.Visible = false;
            if (_bll.Delete(tb_WorkCode.Text.Trim()) > 0)
            {
                LoadAllWorkCode();
                this.lblMsg.Visible = true;
                this.lblMsg.Text = "Operate successful.";
            }
            else
            {
                this.lblMsg.Visible = true;
                this.lblMsg.Text = "Operate fail.";
            }
        }
        /// <summary>
        /// 点击行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvWorkCode_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            //Right-click to also select the row
            if (e.Button == MouseButtons.Right)
            {
                this.dgvWorkCode.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
            }
            if (this.dgvWorkCode.CurrentRow == null)
                return;

            DataGridViewRow row = dgvWorkCode.CurrentRow;
            this.tb_WorkCode.Text = row.Cells["colWorkCode"].Value.ToString();
            this.tb_WorkName.Text = row.Cells["colWorkName"].Value.ToString();

        }
        /// <summary>
        /// 第一列--序号赋值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvWorkCode_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Index >= 0)
            {
                this.dgvWorkCode.Rows[e.Row.Index].Cells["colIndex"].Value = e.Row.Index + 1;
            }
        }
    }
}
