using BLL;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Utils;

namespace Attendance
{
    /// <summary>
    /// 短消息
    /// </summary>
    public partial class UCSms : UserControl
    {
        private DeviceBll _bllDevice = new DeviceBll();
        private SmsBll _bll = new SmsBll();
        private DataTable _dt = new DataTable();

        public UCSms()
        {
            InitializeComponent();
        }

        /// <summary>Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCSms_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            this.dgvSms.AutoGenerateColumns = false;
            LoadDefaultData(sender, e);
        }

        /// <summary>
        /// 加载所有用户
        /// </summary>
        public void LoadAllSMS()
        {
            this.dgvSms.DataSource = null;
            _dt = _bll.GetAll("");
            this.dgvSms.DataSource = _dt;
        }

        //初始化界面默认数据
        private void LoadDefaultData(object sender, EventArgs e)
        {
            //绑定短消息类型下拉框
            ArrayList listType = new ArrayList();
            listType.Add(new DictionaryEntry("253", "Public"));
            listType.Add(new DictionaryEntry("254", "Personal"));
            listType.Add(new DictionaryEntry("255", "Drafts"));
            cmbType.DataSource = listType;
            cmbType.DisplayMember = "Value";
            cmbType.ValueMember = "Key";

            DateTime dtNow = Tools.GetDateTimeNow();
            this.dtpBeginTime.Value = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 0, 0, 0);//Today Start

            //获取数据库中机器序列号
            GetAllDevSNToCmbo(sender, e);
            LoadAllSMS();
        }

        //获取所有机器的序列号
        private void GetAllDevSNToCmbo(object sender, EventArgs e)
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
        private void dgvSms_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Index >= 0)
            {
                this.dgvSms.Rows[e.Row.Index].Cells["colIndex"].Value = e.Row.Index + 1;
            }
        }
        /// <summary>
        /// add-Init data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            cmbType.SelectedIndex = 0;
            txtSmsID.Text = string.Empty;
            numValidTime.Value = 0;
            DateTime dtNow = Tools.GetDateTimeNow();
            dtpBeginTime.Value = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 0, 0, 0);//Today Start
            txtContent.Text = string.Empty;
            txtUserID.Text = "";
            txtUserID.Enabled = false;
        }

        /// <summary>
        /// 保存用户按钮事件
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            int smsID = Tools.TryConvertToInt32(this.txtSmsID.Text);

            if (smsID == 0)
            {
                this.lblMsg.Visible = true;
                this.lblMsg.Text = "SmdID is null or error.";
                return;
            }
            if (string.IsNullOrEmpty(txtContent.Text))
            {
                this.lblMsg.Visible = true;
                this.lblMsg.Text = "Content is Empty.";
                return;
            }
            if (cmbType.SelectedValue.ToString() == "254" && string.IsNullOrEmpty(txtUserID.Text))
            {
                this.lblMsg.Visible = true;
                this.lblMsg.Text = "UserID is Empty.";
                return;
            }
            lblMsg.Visible = false;
            SMSModel model = _bll.Get(txtSmsID.Text.Trim());  //数据库中获取对应pin的用户信息
            if (model == null)
            {
                model = new SMSModel();
            }
            model.Type = Tools.TryConvertToInt32(cmbType.SelectedValue);
            model.SMSId = smsID;
            model.ValidTime = Convert.ToInt32(numValidTime.Value);
            model.BeginTime = dtpBeginTime.Value;
            model.Content = txtContent.Text.Trim();
            model.UserID = txtUserID.Text.Trim();

            int ret = 0;
            try
            {
                //数据库中没有对应的用户，则增加
                if (model.ID == 0)
                {
                    ret = _bll.Add(model);
                    if (ret > 0)
                    {
                        LoadAllSMS();
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
                    //数据库找到对应的用户，则更新
                    ret = _bll.Update(model);
                    if (ret > 0)
                    {
                        LoadAllSMS();
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
        /// <summary>上传短消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbDevSN.Text))
            {
                this.lblMsg.Visible = true;
                this.lblMsg.Text = "DevSN is Empty.";
                return;
            }
            if (null == _bll.Get(txtSmsID.Text.Trim()))
            {
                this.lblMsg.Visible = true;
                lblMsg.Text = "Please save first.";
                return;
            }
            if (string.IsNullOrEmpty(txtSmsID.Text))
            {
                this.lblMsg.Visible = true;
                this.lblMsg.Text = "SmdID is Empty.";
                return;
            }
            if (string.IsNullOrEmpty(txtContent.Text))
            {
                this.lblMsg.Visible = true;
                this.lblMsg.Text = "Content is Empty.";
                return;
            }
            lblMsg.Visible = false;

            DeviceCmdModel cmd = new DeviceCmdModel();
            cmd.DevSN = cmbDevSN.Text;
            cmd.CommitTime = Tools.GetDateTimeNow();

            string content = txtContent.Text.Trim();
            string type = cmbType.SelectedValue.ToString();
            string smsID = txtSmsID.Text.Trim();
            int validTime = Tools.TryConvertToInt32(numValidTime.Value);
            string beginTime = dtpBeginTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            cmd.Content = string.Format(Commands.Command_UpdateSMS, content, type, smsID, validTime, beginTime);

            DeviceCmdBll cmdBll = new DeviceCmdBll();

            if (type == "254")
            {//用户短消息 
                if (cmdBll.Add(cmd) >= 0)
                {
                    string userID = txtUserID.Text.Trim();
                    cmd.Content = string.Format(Commands.Command_UpdateUserSMS, userID, smsID);
                }
                else
                {
                    this.lblMsg.Visible = true;
                    this.lblMsg.Text = "Operate fail.";
                    return;
                }
            }

            this.lblMsg.Visible = true;
            
            if (cmdBll.Add(cmd) >= 0)
            {
                this.lblMsg.Text = "Operate successful.";
            }
            else
            {
                this.lblMsg.Text = "Operate fail.";
            }
        }
        /// <summary>删除短消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSmsID.Text))
            {
                this.lblMsg.Visible = true;
                this.lblMsg.Text = "Please input SmdID.";
                return;
            }
            lblMsg.Visible = false;
            SMSModel model = _bll.Get(txtSmsID.Text);
            if (null == model)
            {
                this.lblMsg.Visible = true;
                this.lblMsg.Text = "The SMS is not exist.";
                return;
            }
            lblMsg.Visible = false;
            if (_bll.Delete(txtSmsID.Text) > 0)
            {
                LoadAllSMS();  //
                this.lblMsg.Visible = true;
                this.lblMsg.Text = "Operate successful.";
            }
            else
            {
                this.lblMsg.Visible = true;
                this.lblMsg.Text = "Operate fail.";
            }
        }
        /// <summary>短消息类型选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbType.SelectedValue != null && cmbType.SelectedValue.ToString() == "254")
            {//用户短消息
                txtUserID.Enabled = true;
            }
            else
            {
                txtUserID.Enabled = false;
                txtUserID.Text = "";
            }
        }

        /// <summary>Selected a Row 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSms_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            //Right-click to also select the row
            if (e.Button == MouseButtons.Right)
            {
                this.dgvSms.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
            }
            if (this.dgvSms.CurrentRow == null)
                return;

            DataGridViewRow row = dgvSms.CurrentRow;
            cmbType.SelectedValue = row.Cells["colType"].Value.ToString();
            txtSmsID.Text = row.Cells["colSmsID"].Value.ToString();
            numValidTime.Value = Tools.TryConvertToInt32(row.Cells["colValidTime"].Value);
            dtpBeginTime.Value = Convert.ToDateTime(row.Cells["colBeginTime"].Value.ToString());
            txtContent.Text = row.Cells["colContent"].Value.ToString();
            txtUserID.Text = row.Cells["colUserID"].Value.ToString();
        }
    }
}
