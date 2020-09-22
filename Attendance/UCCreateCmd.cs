using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Utils;

namespace Attendance
{
    /// <summary>Create Device Cmd
    /// </summary>
    public partial class UCCreateCmd : UserControl
    {
        private DeviceBll _bllDevice = new DeviceBll();
        private DeviceCmdBll _bll = new DeviceCmdBll();
        private string _devSN = null;

        /// <summary>Cmd Dictionary.CmdName/CmdContent
        /// </summary>
        private Dictionary<string, string> _dicCmd = new Dictionary<string, string>();

        public UCCreateCmd()
        {
            InitializeComponent();
        }

        /// <summary>Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCCreateCmd_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            this.dgvDevice.AutoGenerateColumns = false;
            LoadDevice();
            LoadCmd();
            this.rbtnControl.Checked = true;
        }

        /// <summary>Load Device Data
        /// </summary>
        private void LoadDevice()
        {
            DataTable dtDevice = _bllDevice.GetAll("");
            this.dgvDevice.DataSource = dtDevice;

            if (dtDevice != null && dtDevice.Rows.Count > 0)
            {
                _devSN = dtDevice.Rows[0]["DevSN"].ToString();
            }
        }

        /// <summary>The first column shows the sequence number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDevice_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Index >= 0)
            {
                this.dgvDevice.Rows[e.Row.Index].Cells["colIndex"].Value = e.Row.Index + 1;
            }
        }

        /// <summary>Selected a Row 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDevice_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            //Right-click to also select the row
            if (e.Button == MouseButtons.Right)
            {
                this.dgvDevice.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
            }
            if (this.dgvDevice.CurrentRow == null)
                return;

            DataGridViewRow row = dgvDevice.CurrentRow;
            _devSN = row.Cells["colDevSN"].Value.ToString();
            //this.txtDevName.Text = row.Cells["colDevName"].Value.ToString();
        }

        /// <summary>Load cmd content
        /// </summary>
        private void LoadCmd()
        {
            //cmbControl
            _dicCmd.Add("Reboot", Commands.Command_ControlReboot);
            _dicCmd.Add("UnLock", Commands.Command_ControlUnLock);
            _dicCmd.Add("UnAlarm", Commands.Command_ControlUnAlarm);
            _dicCmd.Add("Info", Commands.Command_ControlInfo);
            cmbControl.Items.AddRange(new string[] { "Reboot", "UnLock", "UnAlarm", "Info" });

            //cmbUpdate
            _dicCmd.Add("UpdateUserInfo", Commands.Command_UpdateUserInfo);
            //_dicCmd.Add("UpdateIDCard", Commands.Command_UpdateIDCard);
            _dicCmd.Add("UpdateFingerTmp", Commands.Command_UpdateFingerTmp);
            _dicCmd.Add("UpdateFaceTmp", Commands.Command_UpdateFaceTmp);
            _dicCmd.Add("UpdateFvein", Commands.Command_UpdateFvein);
            _dicCmd.Add("UpdateBioData", Commands.Command_UpdateBioData);
            _dicCmd.Add("UpdateUserPic", Commands.Command_UpdateUserPic);
            _dicCmd.Add("UpdateSMS", Commands.Command_UpdateSMS);
            _dicCmd.Add("UpdateUserSMS", Commands.Command_UpdateUserSMS);
            _dicCmd.Add("UpdateAdPic", Commands.Command_UpdateAdPic);
            _dicCmd.Add("UpdateWorkCode", Commands.Command_UpdateWorkCode);
            _dicCmd.Add("UpdateShortcutKey", Commands.Command_UpdateShortcutKey);
            _dicCmd.Add("UpdateAccGroup", Commands.Command_UpdateAccGroup);
            _dicCmd.Add("UpdateAccTimeZone", Commands.Command_UpdateAccTimeZone);
            _dicCmd.Add("UpdateAccHoliday", Commands.Command_UpdateAccHoliday);
            _dicCmd.Add("UpdateAccUnLockComb", Commands.Command_UpdateAccUnLockComb);
            _dicCmd.Add("UpdateBlackList", Commands.Command_UpdateBlackList);
            cmbUpdate.Items.AddRange(new string[] { "UpdateUserInfo", "UpdateFingerTmp", "UpdateFaceTmp", "UpdateFvein"
                , "UpdateBioData", "UpdateUserPic", "UpdateSMS", "UpdateUserSMS", "UpdateAdPic", "UpdateWorkCode"
                , "UpdateShortcutKey", "UpdateAccGroup", "UpdateAccTimeZone", "UpdateAccHoliday", "UpdateAccUnLockComb", "UpdateBlackList"
            });

            //cmbDelete
            _dicCmd.Add("DeleteUser", Commands.Command_DeleteUser);
            _dicCmd.Add("DeleteFingerTmp1", Commands.Command_DeleteFingerTmp1);
            _dicCmd.Add("DeleteFingerTmp2", Commands.Command_DeleteFingerTmp2);
            _dicCmd.Add("DeleteFace", Commands.Command_DeleteFace);
            _dicCmd.Add("DeleteFvein1", Commands.Command_DeleteFvein1);
            _dicCmd.Add("DeleteFvein2", Commands.Command_DeleteFvein2);
            _dicCmd.Add("DeleteBioData1", Commands.Command_DeleteBioData1);
            _dicCmd.Add("DeleteBioData2", Commands.Command_DeleteBioData2);
            _dicCmd.Add("DeleteBioData3", Commands.Command_DeleteBioData3);
            _dicCmd.Add("DeleteUserPic", Commands.Command_DeleteUserPic);
            _dicCmd.Add("DeleteBioPhoto", Commands.Command_DeleteBioPhoto);
            _dicCmd.Add("DeleteSMS", Commands.Command_DeleteSMS);
            _dicCmd.Add("DeleteWorkCode", Commands.Command_DeleteWorkCode);
            _dicCmd.Add("DeleteAdPic", Commands.Command_DeleteAdPic);
            cmbDelete.Items.AddRange(new string[] { "DeleteUser", "DeleteFingerTmp1", "DeleteFingerTmp2" , "DeleteFace"
                , "DeleteFvein1", "DeleteFvein2", "DeleteBioData1", "DeleteBioData2", "DeleteBioData3", "DeleteUserPic"
                , "DeleteBioPhoto", "DeleteSMS", "DeleteWorkCode", "DeleteAdPic"
            });

            //cmbQuery
            _dicCmd.Add("QueryAttLog", Commands.Command_QueryAttLog);
            _dicCmd.Add("QueryAttPhoto", Commands.Command_QueryAttPhoto);
            _dicCmd.Add("QueryUserInfo", Commands.Command_QueryUserInfo);
            _dicCmd.Add("QueryFingerTmp", Commands.Command_QueryFingerTmp);
            _dicCmd.Add("QueryBioData1", Commands.Command_QueryBioData1);
            _dicCmd.Add("QueryBioData2", Commands.Command_QueryBioData2);
            _dicCmd.Add("QueryBioData3", Commands.Command_QueryBioData3);
            cmbQuery.Items.AddRange(new string[] { "QueryAttLog", "QueryAttPhoto", "QueryUserInfo", "QueryFingerTmp"
                , "QueryBioData1", "QueryBioData2", "QueryBioData3"
            });

            //cmbClear
            _dicCmd.Add("ClearLog", Commands.Command_ClearLog);
            _dicCmd.Add("ClearPhoto", Commands.Command_ClearPhoto);
            _dicCmd.Add("ClearData", Commands.Command_ClearData);
            _dicCmd.Add("ClearBioData", Commands.Command_ClearBioData);
            cmbClear.Items.AddRange(new string[] { "ClearLog", "ClearPhoto", "ClearData", "ClearBioData" });
        }

        /// <summary>Save cmd to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_devSN))
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Please select a device";
                return;
            }

            if (string.IsNullOrEmpty(rtxtCmd.Text))
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Cmd content is empty";
                return;
            }

            if (!CheckCmd(rtxtCmd.Text))
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Cmd content is invalid";
                return;
            }

            DeviceCmdModel model = new DeviceCmdModel();
            model.DevSN = _devSN;
            model.Content = rtxtCmd.Text;
            model.CommitTime = Tools.GetDateTimeNow();

            if (_bll.Add(model) > 0)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Success";
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Fail";
            }
        }

        /// <summary>Check Cmd
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        private bool CheckCmd(string cmd)
        {
            //检查是否包含符号 “{”，“}”
            if (cmd.IndexOf('{') >= 0)
                return false;
            if (cmd.IndexOf('}') >= 0)
                return false;

            return true;
        }

        #region ComboBoxSelectedIndexChanged 
        /// <summary>GetCmdContent
        /// </summary>
        /// <param name="cmb"></param>
        private void GetCmdContent(ComboBox cmb)
        {
            if (cmb.SelectedIndex < 0)
                return;

            string cmdName = cmb.SelectedItem.ToString();
            if (_dicCmd.ContainsKey(cmdName))
                rtxtCmd.Text = _dicCmd[cmdName];
            else
                rtxtCmd.Text = "";
        }

        /// <summary>cmbControl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCmdContent((ComboBox)sender);
        }
        /// <summary>cmbUpdate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCmdContent((ComboBox)sender);
        }
        /// <summary>cmbDelete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCmdContent((ComboBox)sender);
        }
        /// <summary>cmbQuery
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbQuery_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCmdContent((ComboBox)sender);
        }
        /// <summary>cmbClear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbClear_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCmdContent((ComboBox)sender);
        }
        /// <summary>
        /// 选择类型-用户自定义
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnUserDefined_CheckedChanged(object sender, EventArgs e)
        {
            DisableCombobox();
            this.rtxtCmd.Text = "";
        }
        /// <summary>
        /// 选择类型-清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnClear_CheckedChanged(object sender, EventArgs e)
        {
            DisableCombobox();
            this.cmbClear.Enabled = true;
        }
        /// <summary>
        /// 选择类型-查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnQuery_CheckedChanged(object sender, EventArgs e)
        {
            DisableCombobox();
            this.cmbQuery.Enabled = true;
        }
        /// <summary>
        /// 选择类型-删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnDelete_CheckedChanged(object sender, EventArgs e)
        {
            DisableCombobox();
            this.cmbDelete.Enabled = true;
        }
        /// <summary>
        /// 选择类型-更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnUpdate_CheckedChanged(object sender, EventArgs e)
        {
            DisableCombobox();
            this.cmbUpdate.Enabled = true;
        }
        /// <summary>
        /// 选择类型-控制命令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnControl_CheckedChanged(object sender, EventArgs e)
        {
            DisableCombobox();
            this.cmbControl.Enabled = true;
        }

        /// <summary>Disable All Combobox
        /// </summary>
        private void DisableCombobox()
        {
            this.cmbControl.Enabled = false;
            this.cmbUpdate.Enabled = false;
            this.cmbDelete.Enabled = false;
            this.cmbQuery.Enabled = false;
            this.cmbClear.Enabled = false;
        }
        #endregion end-ComboBoxSelectedIndexChanged 
    }
}
