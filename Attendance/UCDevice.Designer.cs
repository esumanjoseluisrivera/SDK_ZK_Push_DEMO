namespace Attendance
{
    partial class UCDevice
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDevice = new System.Windows.Forms.DataGridView();
            this.lblModuleName = new System.Windows.Forms.Label();
            this.pnlData = new System.Windows.Forms.Panel();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.lblMsg = new System.Windows.Forms.Label();
            this.txtTransFlag = new System.Windows.Forms.TextBox();
            this.lblTransFlag = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cmbTimeZone = new System.Windows.Forms.ComboBox();
            this.lblTimeZone = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDevName = new System.Windows.Forms.TextBox();
            this.lblDevName = new System.Windows.Forms.Label();
            this.lblDevSN = new System.Windows.Forms.Label();
            this.txtDevSN = new System.Windows.Forms.TextBox();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.timerGetDevStatus = new System.Windows.Forms.Timer(this.components);
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewImageColumn();
            this.colDevSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDevName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMask = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTemp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDevIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFirmwareVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimeZone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevice)).BeginInit();
            this.pnlData.SuspendLayout();
            this.pnlControl.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDevice
            // 
            this.dgvDevice.AllowUserToAddRows = false;
            this.dgvDevice.AllowUserToDeleteRows = false;
            this.dgvDevice.AllowUserToResizeRows = false;
            this.dgvDevice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDevice.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDevice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDevice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStatus,
            this.colDevSN,
            this.colDevName,
            this.colMask,
            this.colTemp,
            this.colDevIP,
            this.colFirmwareVersion,
            this.colTransFlag,
            this.colTimeZone});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDevice.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDevice.Location = new System.Drawing.Point(0, 0);
            this.dgvDevice.MultiSelect = false;
            this.dgvDevice.Name = "dgvDevice";
            this.dgvDevice.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDevice.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDevice.RowHeadersVisible = false;
            this.dgvDevice.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDevice.RowTemplate.Height = 23;
            this.dgvDevice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDevice.Size = new System.Drawing.Size(525, 611);
            this.dgvDevice.TabIndex = 0;
            this.dgvDevice.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDevice_CellMouseClick);
            // 
            // lblModuleName
            // 
            this.lblModuleName.AutoSize = true;
            this.lblModuleName.Font = new System.Drawing.Font("Arial", 12F);
            this.lblModuleName.Location = new System.Drawing.Point(12, 8);
            this.lblModuleName.Name = "lblModuleName";
            this.lblModuleName.Size = new System.Drawing.Size(57, 18);
            this.lblModuleName.TabIndex = 1;
            this.lblModuleName.Text = "Device";
            this.lblModuleName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.dgvDevice);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(0, 30);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(525, 611);
            this.pnlData.TabIndex = 2;
            // 
            // pnlControl
            // 
            this.pnlControl.BackColor = System.Drawing.Color.White;
            this.pnlControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlControl.Controls.Add(this.lblMsg);
            this.pnlControl.Controls.Add(this.txtTransFlag);
            this.pnlControl.Controls.Add(this.lblTransFlag);
            this.pnlControl.Controls.Add(this.btnAdd);
            this.pnlControl.Controls.Add(this.btnDelete);
            this.pnlControl.Controls.Add(this.cmbTimeZone);
            this.pnlControl.Controls.Add(this.lblTimeZone);
            this.pnlControl.Controls.Add(this.btnSave);
            this.pnlControl.Controls.Add(this.txtDevName);
            this.pnlControl.Controls.Add(this.lblDevName);
            this.pnlControl.Controls.Add(this.lblDevSN);
            this.pnlControl.Controls.Add(this.txtDevSN);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlControl.Location = new System.Drawing.Point(525, 30);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(346, 611);
            this.pnlControl.TabIndex = 3;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(29, 17);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(23, 12);
            this.lblMsg.TabIndex = 32;
            this.lblMsg.Text = "msg";
            this.lblMsg.Visible = false;
            // 
            // txtTransFlag
            // 
            this.txtTransFlag.Font = new System.Drawing.Font("Arial", 9F);
            this.txtTransFlag.Location = new System.Drawing.Point(107, 162);
            this.txtTransFlag.Name = "txtTransFlag";
            this.txtTransFlag.Size = new System.Drawing.Size(216, 21);
            this.txtTransFlag.TabIndex = 31;
            // 
            // lblTransFlag
            // 
            this.lblTransFlag.AutoSize = true;
            this.lblTransFlag.Font = new System.Drawing.Font("Arial", 10F);
            this.lblTransFlag.Location = new System.Drawing.Point(28, 164);
            this.lblTransFlag.Name = "lblTransFlag";
            this.lblTransFlag.Size = new System.Drawing.Size(67, 16);
            this.lblTransFlag.TabIndex = 30;
            this.lblTransFlag.Text = "Transflag";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(190)))), ((int)(((byte)(167)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Arial", 12F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.ImageIndex = 2;
            this.btnAdd.Location = new System.Drawing.Point(31, 210);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(70, 30);
            this.btnAdd.TabIndex = 29;
            this.btnAdd.Text = "New";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(190)))), ((int)(((byte)(167)))));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Arial", 12F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.ImageIndex = 3;
            this.btnDelete.Location = new System.Drawing.Point(243, 210);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(79, 30);
            this.btnDelete.TabIndex = 25;
            this.btnDelete.Text = "Remove";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cmbTimeZone
            // 
            this.cmbTimeZone.Font = new System.Drawing.Font("Arial", 9F);
            this.cmbTimeZone.FormattingEnabled = true;
            this.cmbTimeZone.Items.AddRange(new object[] {
            "-12:30",
            "-12:00",
            "-11:30",
            "-11:00",
            "-10:30",
            "-10:00",
            "-09:30",
            "-09:00",
            "-08:30",
            "-08:00",
            "-07:30",
            "-07:00",
            "-06:30",
            "-06:00",
            "-05:30",
            "-05:00",
            "-04:30",
            "-04:00",
            "-03:30",
            "-03:00",
            "-02:30",
            "-02:00",
            "-01:30",
            "-01:00",
            "-00:30",
            "",
            "+00:30",
            "+01:00",
            "+01:30",
            "+02:00",
            "+02:30",
            "+03:00",
            "+03:30",
            "+04:00",
            "+04:30",
            "+05:00",
            "+05:30",
            "+06:00",
            "+06:30",
            "+07:00",
            "+07:30",
            "+08:00",
            "+08:30",
            "+09:00",
            "+09:30",
            "+10:00",
            "+10:30",
            "+11:00",
            "+11:30",
            "+12:00",
            "+12:30",
            "+13:00",
            "+13:30"});
            this.cmbTimeZone.Location = new System.Drawing.Point(107, 131);
            this.cmbTimeZone.Name = "cmbTimeZone";
            this.cmbTimeZone.Size = new System.Drawing.Size(216, 23);
            this.cmbTimeZone.TabIndex = 24;
            // 
            // lblTimeZone
            // 
            this.lblTimeZone.AutoSize = true;
            this.lblTimeZone.Font = new System.Drawing.Font("Arial", 10F);
            this.lblTimeZone.Location = new System.Drawing.Point(28, 134);
            this.lblTimeZone.Name = "lblTimeZone";
            this.lblTimeZone.Size = new System.Drawing.Size(70, 16);
            this.lblTimeZone.TabIndex = 23;
            this.lblTimeZone.Text = "TimeZone";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(190)))), ((int)(((byte)(167)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Arial", 12F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.ImageIndex = 4;
            this.btnSave.Location = new System.Drawing.Point(137, 210);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 30);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDevName
            // 
            this.txtDevName.Font = new System.Drawing.Font("Arial", 9F);
            this.txtDevName.Location = new System.Drawing.Point(107, 102);
            this.txtDevName.Name = "txtDevName";
            this.txtDevName.Size = new System.Drawing.Size(216, 21);
            this.txtDevName.TabIndex = 20;
            // 
            // lblDevName
            // 
            this.lblDevName.AutoSize = true;
            this.lblDevName.Font = new System.Drawing.Font("Arial", 10F);
            this.lblDevName.Location = new System.Drawing.Point(28, 104);
            this.lblDevName.Name = "lblDevName";
            this.lblDevName.Size = new System.Drawing.Size(44, 16);
            this.lblDevName.TabIndex = 19;
            this.lblDevName.Text = "Name";
            // 
            // lblDevSN
            // 
            this.lblDevSN.AutoSize = true;
            this.lblDevSN.Font = new System.Drawing.Font("Arial", 10F);
            this.lblDevSN.Location = new System.Drawing.Point(28, 74);
            this.lblDevSN.Name = "lblDevSN";
            this.lblDevSN.Size = new System.Drawing.Size(26, 16);
            this.lblDevSN.TabIndex = 18;
            this.lblDevSN.Text = "SN";
            // 
            // txtDevSN
            // 
            this.txtDevSN.Font = new System.Drawing.Font("Arial", 9F);
            this.txtDevSN.Location = new System.Drawing.Point(107, 72);
            this.txtDevSN.Name = "txtDevSN";
            this.txtDevSN.Size = new System.Drawing.Size(216, 21);
            this.txtDevSN.TabIndex = 17;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.lblModuleName);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(871, 30);
            this.pnlTop.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(190)))), ((int)(((byte)(167)))));
            this.label1.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.Location = new System.Drawing.Point(0, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(3, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = " ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timerGetDevStatus
            // 
            this.timerGetDevStatus.Interval = 1000;
            this.timerGetDevStatus.Tick += new System.EventHandler(this.timerGetDevStatus_Tick);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn1.Frozen = true;
            this.dataGridViewImageColumn1.HeaderText = "Status";
            this.dataGridViewImageColumn1.Image = global::Attendance.Properties.Resources.imgDevStatus1;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "DevSN";
            this.dataGridViewTextBoxColumn1.HeaderText = "DeviceSN";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 97;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DevName";
            this.dataGridViewTextBoxColumn2.HeaderText = "DeviceName";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 98;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "DevIP";
            this.dataGridViewTextBoxColumn3.HeaderText = "DeviceIP";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 97;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DevFirmwareVersion";
            this.dataGridViewTextBoxColumn4.HeaderText = "FirmwareVersion";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 195;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "DevIP";
            this.dataGridViewTextBoxColumn5.HeaderText = "DeviceIP";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 65;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "DevFirmwareVersion";
            this.dataGridViewTextBoxColumn6.HeaderText = "FirmwareVersion";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn6.Width = 65;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "TransFlag";
            this.dataGridViewTextBoxColumn7.HeaderText = "TransFlag";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "TimeZone";
            this.dataGridViewTextBoxColumn8.HeaderText = "TimeZone";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // colStatus
            // 
            this.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colStatus.Frozen = true;
            this.colStatus.HeaderText = "Status";
            this.colStatus.Image = global::Attendance.Properties.Resources.imgDevStatus1;
            this.colStatus.MinimumWidth = 70;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 70;
            // 
            // colDevSN
            // 
            this.colDevSN.DataPropertyName = "DevSN";
            this.colDevSN.HeaderText = "DeviceSN";
            this.colDevSN.Name = "colDevSN";
            this.colDevSN.ReadOnly = true;
            this.colDevSN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colDevName
            // 
            this.colDevName.DataPropertyName = "DevName";
            this.colDevName.HeaderText = "DeviceName";
            this.colDevName.Name = "colDevName";
            this.colDevName.ReadOnly = true;
            // 
            // colMask
            // 
            this.colMask.HeaderText = "Mask";
            this.colMask.Name = "colMask";
            this.colMask.ReadOnly = true;
            this.colMask.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colTemp
            // 
            this.colTemp.HeaderText = "Temperature";
            this.colTemp.Name = "colTemp";
            this.colTemp.ReadOnly = true;
            this.colTemp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colDevIP
            // 
            this.colDevIP.DataPropertyName = "DevIP";
            this.colDevIP.HeaderText = "DeviceIP";
            this.colDevIP.Name = "colDevIP";
            this.colDevIP.ReadOnly = true;
            this.colDevIP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colFirmwareVersion
            // 
            this.colFirmwareVersion.DataPropertyName = "DevFirmwareVersion";
            this.colFirmwareVersion.HeaderText = "FirmwareVersion";
            this.colFirmwareVersion.Name = "colFirmwareVersion";
            this.colFirmwareVersion.ReadOnly = true;
            this.colFirmwareVersion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colTransFlag
            // 
            this.colTransFlag.DataPropertyName = "TransFlag";
            this.colTransFlag.HeaderText = "TransFlag";
            this.colTransFlag.Name = "colTransFlag";
            this.colTransFlag.ReadOnly = true;
            this.colTransFlag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTransFlag.Visible = false;
            // 
            // colTimeZone
            // 
            this.colTimeZone.DataPropertyName = "TimeZone";
            this.colTimeZone.HeaderText = "TimeZone";
            this.colTimeZone.Name = "colTimeZone";
            this.colTimeZone.ReadOnly = true;
            this.colTimeZone.Visible = false;
            // 
            // UCDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.pnlTop);
            this.Name = "UCDevice";
            this.Size = new System.Drawing.Size(871, 641);
            this.Load += new System.EventHandler(this.UCDevice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevice)).EndInit();
            this.pnlData.ResumeLayout(false);
            this.pnlControl.ResumeLayout(false);
            this.pnlControl.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDevice;
        private System.Windows.Forms.Label lblModuleName;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.TextBox txtTransFlag;
        private System.Windows.Forms.Label lblTransFlag;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cmbTimeZone;
        private System.Windows.Forms.Label lblTimeZone;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDevName;
        private System.Windows.Forms.Label lblDevName;
        private System.Windows.Forms.Label lblDevSN;
        private System.Windows.Forms.TextBox txtDevSN;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Timer timerGetDevStatus;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewImageColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDevSN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDevName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMask;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTemp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDevIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFirmwareVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimeZone;
    }
}
