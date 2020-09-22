using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Utils;

namespace Attendance
{
    /// <summary>Device Management
    /// </summary>
    public partial class UCDevice : UserControl
    {
        //Device number and device polling time dictionary
        private Dictionary<String, int> _dicDevInterval = new Dictionary<String, int>();

        private string[] devCmd = new string[100];
        DeviceBll _bll = new DeviceBll();
        DataTable _dtDevice = null;

        public UCDevice()
        {
            InitializeComponent();
        }

        /// <summary>Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCDevice_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            this.dgvDevice.AutoGenerateColumns = false;
            LoadDevice();
            if (_dtDevice == null || _dtDevice.Rows.Count != 0)
            {
                foreach (DataRow dr in _dtDevice.Rows)
                {
                    string sn = dr["DevSN"].ToString();
                    int delay = Tools.TryConvertToInt32(dr["Delay"]);
                    if (!_dicDevInterval.ContainsKey(sn))
                    {
                        _dicDevInterval.Add(sn, 0);
                    }
                }
            }
            
            this.timerGetDevStatus.Enabled = true;
            this.timerGetDevStatus.Interval = 1000;
        }

        /// <summary>Load Device Data
        /// </summary>
        private void LoadDevice()
        {
            _dtDevice = _bll.GetAll("");
            this.dgvDevice.DataSource = _dtDevice;
        }

        /// <summary>New Device
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.lblMsg.Visible = false;

            DeviceModel device = new DeviceModel();
            txtDevSN.Text = device.DevSN;
            txtDevName.Text = device.DevName;
            txtTransFlag.Text = device.TransFlag;
            cmbTimeZone.Text = device.TimeZone;
        }

        /// <summary>Save Device
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDevSN.Text))
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Please input Device SN";
                return;
            }

            lblMsg.Visible = false;

            //Device Exsit,Update
            DeviceModel device;
            if (null != (device = _bll.Get(txtDevSN.Text.Trim())))
            {
                device.TimeZone = cmbTimeZone.Text;
                device.DevName = txtDevName.Text;
                device.TransFlag = txtTransFlag.Text.Trim();
                try
                {
                    if (_bll.Update(device) > 0)
                    {
                        LoadDevice();
                        lblMsg.Visible = true;
                        lblMsg.Text = "Update device success";
                    }
                    else
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Update device fail";
                    }
                    return;
                }
                catch { }
            }

            //Device No Exsit,Add
            lblMsg.Visible = false;
            device = new DeviceModel();
            device.DevSN = txtDevSN.Text.Trim();
            device.TimeZone = cmbTimeZone.Text;
            device.DevName = txtDevName.Text;
            device.TransFlag = txtTransFlag.Text.Trim();
            try
            {
                if (_bll.Add(device) > 0)
                {
                    LoadDevice();
                    if (!_dicDevInterval.ContainsKey(device.DevSN))
                    {
                        _dicDevInterval.Add(device.DevSN, 0);
                    }

                    lblMsg.Visible = true;
                    lblMsg.Text = "Add device SN " + txtDevSN.Text.Trim() + " success";
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Add device SN " + txtDevSN.Text.Trim() + " fail";
                }
            }
            catch (Exception ex)
            {
                lblMsg.Visible = true;
                lblMsg.Text = ex.ToString();
            }
        }
        /// <summary>Delete Device
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDevSN.Text))
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Please Input Device SN first";
                return;
            }
            string devSN = txtDevSN.Text.Trim();
            DeviceModel device;
            if (null == (device = _bll.Get(devSN)))
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Device SN is not exist";
                return;
            }
            lblMsg.Visible = false;

            if (_bll.Delete(devSN) > 0)
            {
                LoadDevice();
                _dicDevInterval.Remove(devSN);

                lblMsg.Visible = true;
                lblMsg.Text = "Remove device success";
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Remove device fail";
            }
        }
        /// <summary>Send
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {

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
            this.txtDevSN.Text = row.Cells["colDevSN"].Value.ToString();
            this.txtDevName.Text = row.Cells["colDevName"].Value.ToString();
            this.txtTransFlag.Text = row.Cells["colTransFlag"].Value.ToString();
            this.cmbTimeZone.Text = row.Cells["colTimeZone"].Value.ToString();
        }

        /// <summary>Set devcie off-line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerGetDevStatus_Tick(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < this.dgvDevice.Rows.Count; i++)
                {
                    string devSN = this.dgvDevice.Rows[i].Cells["colDevSN"].Value.ToString();
                    if (!_dicDevInterval.ContainsKey(devSN))
                        continue;

                    int devDelay = Tools.TryConvertToInt32(_dtDevice.Rows[i]["Delay"]);
                    if (devDelay > _dicDevInterval[devSN])
                    {
                        _dicDevInterval[devSN] += 1;//add 1s
                        continue;
                    }

                    _dicDevInterval[devSN] = 0;//reset
                    this.dgvDevice.Rows[i].Cells["colStatus"].Value = Properties.Resources.imgDevStatus1;//Set device off-line .Receive msg from device,set it on-line.
                }
            }
            catch
            {
            }
        }

        /// <summary>Update Device Mask Status
        /// </summary>
        /// <param name="devSN"></param>
        /// <param name="maskStatus">0:no detected;1:detected successful;2:disable/notfound</param>
        public void UpdateDeviceMask(string devSN, int maskStatus)
        {
            for (int i = 0; i < this.dgvDevice.Rows.Count; i++)
            {
                string sn = this.dgvDevice.Rows[i].Cells["colDevSN"].Value.ToString();
                if (devSN != sn)
                    continue;

                string maskDesc = "";
                switch (maskStatus)
                {
                    case 0:
                        maskDesc = "No";
                        break;
                    case 1:
                        maskDesc = "Yes";
                        break;
                    case 2:
                        maskDesc = "";
                        break;
                    default:
                        break;
                }

                this.dgvDevice.Rows[i].Cells["colMask"].Value = maskDesc;
            }
        }
        /// <summary>Update Device Temperature
        /// </summary>
        /// <param name="devSN"></param>
        /// <param name="tempVal">Temperature</param>
        public void UpdateDeviceTemp(string devSN, string tempVal)
        {
            for (int i = 0; i < this.dgvDevice.Rows.Count; i++)
            {
                string sn = this.dgvDevice.Rows[i].Cells["colDevSN"].Value.ToString();
                if (devSN != sn)
                    continue;

                tempVal = (string.IsNullOrEmpty(tempVal)) ? "Disable/NotFound" : tempVal;

                this.dgvDevice.Rows[i].Cells["colTemp"].Value = tempVal;
            }
        }

        /// <summary>Update Device Info
        /// </summary>
        /// <param name="dev"></param>
        public void UpdateDevice(DeviceModel dev)
        {
            for (int i = 0; i < this.dgvDevice.Rows.Count; i++)
            {
                string devSN = this.dgvDevice.Rows[i].Cells["colDevSN"].Value.ToString();
                if (dev.DevSN != devSN)
                    continue;

                this.dgvDevice.Rows[i].Cells["colStatus"].Value = Properties.Resources.imgDevStatus2;//Set device on-line.
                if (_dicDevInterval.ContainsKey(devSN))
                {
                    _dicDevInterval[devSN] = 0;
                }

                this.dgvDevice.Rows[i].Cells["colDevIP"].Value = dev.DevIP;
                this.dgvDevice.Rows[i].Cells["colFirmwareVersion"].Value = dev.DevFirmwareVersion;
            }
                        
            //lstDevMsgDevice.Refresh();
        }

    }
}
