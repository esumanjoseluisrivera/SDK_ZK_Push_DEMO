namespace Attendance
{
    partial class UCDeviceCmd
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblModuleName = new System.Windows.Forms.Label();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.cmbDevSN = new System.Windows.Forms.ComboBox();
            this.lblDevSN = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.btnGet = new System.Windows.Forms.Button();
            this.btnGetAll = new System.Windows.Forms.Button();
            this.btnClearList = new System.Windows.Forms.Button();
            this.pnlData = new System.Windows.Forms.Panel();
            this.dgvDeviceCmd = new System.Windows.Forms.DataGridView();
            this.colIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDevSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCommitTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResponseTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReturnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlTop.SuspendLayout();
            this.pnlControl.SuspendLayout();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeviceCmd)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.lblModuleName);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(885, 30);
            this.pnlTop.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(190)))), ((int)(((byte)(167)))));
            this.label1.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.Location = new System.Drawing.Point(0, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(3, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = " ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblModuleName
            // 
            this.lblModuleName.AutoSize = true;
            this.lblModuleName.Font = new System.Drawing.Font("Arial", 12F);
            this.lblModuleName.Location = new System.Drawing.Point(12, 8);
            this.lblModuleName.Name = "lblModuleName";
            this.lblModuleName.Size = new System.Drawing.Size(91, 18);
            this.lblModuleName.TabIndex = 2;
            this.lblModuleName.Text = "DeviceCmd";
            this.lblModuleName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlControl
            // 
            this.pnlControl.BackColor = System.Drawing.Color.White;
            this.pnlControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlControl.Controls.Add(this.dtpEndTime);
            this.pnlControl.Controls.Add(this.dtpStartTime);
            this.pnlControl.Controls.Add(this.cmbDevSN);
            this.pnlControl.Controls.Add(this.lblDevSN);
            this.pnlControl.Controls.Add(this.lblMsg);
            this.pnlControl.Controls.Add(this.lblStartTime);
            this.pnlControl.Controls.Add(this.lblEndTime);
            this.pnlControl.Controls.Add(this.btnGet);
            this.pnlControl.Controls.Add(this.btnGetAll);
            this.pnlControl.Controls.Add(this.btnClearList);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlControl.Location = new System.Drawing.Point(630, 30);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(255, 533);
            this.pnlControl.TabIndex = 1;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CalendarFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEndTime.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(95, 128);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(136, 21);
            this.dtpEndTime.TabIndex = 65;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CalendarFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpStartTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpStartTime.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(95, 98);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(136, 21);
            this.dtpStartTime.TabIndex = 64;
            // 
            // cmbDevSN
            // 
            this.cmbDevSN.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbDevSN.FormattingEnabled = true;
            this.cmbDevSN.Location = new System.Drawing.Point(95, 68);
            this.cmbDevSN.Name = "cmbDevSN";
            this.cmbDevSN.Size = new System.Drawing.Size(136, 20);
            this.cmbDevSN.TabIndex = 63;
            // 
            // lblDevSN
            // 
            this.lblDevSN.AutoSize = true;
            this.lblDevSN.Font = new System.Drawing.Font("Arial", 10F);
            this.lblDevSN.Location = new System.Drawing.Point(19, 70);
            this.lblDevSN.Name = "lblDevSN";
            this.lblDevSN.Size = new System.Drawing.Size(26, 16);
            this.lblDevSN.TabIndex = 62;
            this.lblDevSN.Text = "SN";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(26, 40);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(23, 12);
            this.lblMsg.TabIndex = 59;
            this.lblMsg.Text = "msg";
            this.lblMsg.Visible = false;
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Font = new System.Drawing.Font("Arial", 10F);
            this.lblStartTime.Location = new System.Drawing.Point(19, 100);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(68, 16);
            this.lblStartTime.TabIndex = 55;
            this.lblStartTime.Text = "StartTime";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Font = new System.Drawing.Font("Arial", 10F);
            this.lblEndTime.Location = new System.Drawing.Point(19, 130);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(63, 16);
            this.lblEndTime.TabIndex = 56;
            this.lblEndTime.Text = "EndTime";
            // 
            // btnGet
            // 
            this.btnGet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(190)))), ((int)(((byte)(167)))));
            this.btnGet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGet.Font = new System.Drawing.Font("Arial", 12F);
            this.btnGet.ForeColor = System.Drawing.Color.White;
            this.btnGet.Location = new System.Drawing.Point(46, 187);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(157, 30);
            this.btnGet.TabIndex = 54;
            this.btnGet.Text = "Get Period Cmd";
            this.btnGet.UseVisualStyleBackColor = false;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // btnGetAll
            // 
            this.btnGetAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(190)))), ((int)(((byte)(167)))));
            this.btnGetAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetAll.Font = new System.Drawing.Font("Arial", 12F);
            this.btnGetAll.ForeColor = System.Drawing.Color.White;
            this.btnGetAll.Location = new System.Drawing.Point(46, 292);
            this.btnGetAll.Name = "btnGetAll";
            this.btnGetAll.Size = new System.Drawing.Size(157, 30);
            this.btnGetAll.TabIndex = 53;
            this.btnGetAll.Text = "Get All Cmd";
            this.btnGetAll.UseVisualStyleBackColor = false;
            this.btnGetAll.Click += new System.EventHandler(this.btnGetAll_Click);
            // 
            // btnClearList
            // 
            this.btnClearList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(190)))), ((int)(((byte)(167)))));
            this.btnClearList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearList.Font = new System.Drawing.Font("Arial", 12F);
            this.btnClearList.ForeColor = System.Drawing.Color.White;
            this.btnClearList.Location = new System.Drawing.Point(46, 327);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(157, 30);
            this.btnClearList.TabIndex = 52;
            this.btnClearList.Text = "Clear All Cmd";
            this.btnClearList.UseVisualStyleBackColor = false;
            this.btnClearList.Click += new System.EventHandler(this.btnClearList_Click);
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.dgvDeviceCmd);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(0, 30);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(630, 533);
            this.pnlData.TabIndex = 2;
            // 
            // dgvDeviceCmd
            // 
            this.dgvDeviceCmd.AllowUserToAddRows = false;
            this.dgvDeviceCmd.AllowUserToDeleteRows = false;
            this.dgvDeviceCmd.AllowUserToResizeRows = false;
            this.dgvDeviceCmd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDeviceCmd.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDeviceCmd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDeviceCmd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIndex,
            this.colDevSN,
            this.colCommitTime,
            this.colContent,
            this.colTransTime,
            this.colResponseTime,
            this.colReturnValue});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDeviceCmd.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDeviceCmd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDeviceCmd.Location = new System.Drawing.Point(0, 0);
            this.dgvDeviceCmd.MultiSelect = false;
            this.dgvDeviceCmd.Name = "dgvDeviceCmd";
            this.dgvDeviceCmd.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDeviceCmd.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDeviceCmd.RowHeadersVisible = false;
            this.dgvDeviceCmd.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDeviceCmd.RowTemplate.Height = 23;
            this.dgvDeviceCmd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeviceCmd.Size = new System.Drawing.Size(630, 533);
            this.dgvDeviceCmd.TabIndex = 1;
            this.dgvDeviceCmd.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvDeviceCmd_RowStateChanged);
            // 
            // colIndex
            // 
            this.colIndex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colIndex.DefaultCellStyle = dataGridViewCellStyle2;
            this.colIndex.FillWeight = 177.665F;
            this.colIndex.Frozen = true;
            this.colIndex.HeaderText = "Index";
            this.colIndex.MinimumWidth = 50;
            this.colIndex.Name = "colIndex";
            this.colIndex.ReadOnly = true;
            this.colIndex.Width = 50;
            // 
            // colDevSN
            // 
            this.colDevSN.DataPropertyName = "DevSN";
            this.colDevSN.FillWeight = 87.05584F;
            this.colDevSN.HeaderText = "DevSN";
            this.colDevSN.Name = "colDevSN";
            this.colDevSN.ReadOnly = true;
            // 
            // colCommitTime
            // 
            this.colCommitTime.DataPropertyName = "CommitTime";
            dataGridViewCellStyle3.Format = "yyyy-MM-dd HH:mm:ss";
            this.colCommitTime.DefaultCellStyle = dataGridViewCellStyle3;
            this.colCommitTime.FillWeight = 87.05584F;
            this.colCommitTime.HeaderText = "CommitTime";
            this.colCommitTime.Name = "colCommitTime";
            this.colCommitTime.ReadOnly = true;
            // 
            // colContent
            // 
            this.colContent.DataPropertyName = "Content";
            this.colContent.FillWeight = 87.05584F;
            this.colContent.HeaderText = "Content";
            this.colContent.Name = "colContent";
            this.colContent.ReadOnly = true;
            // 
            // colTransTime
            // 
            this.colTransTime.DataPropertyName = "TransTime";
            dataGridViewCellStyle4.Format = "yyyy-MM-dd HH:mm:ss";
            this.colTransTime.DefaultCellStyle = dataGridViewCellStyle4;
            this.colTransTime.FillWeight = 87.05584F;
            this.colTransTime.HeaderText = "TransTime";
            this.colTransTime.Name = "colTransTime";
            this.colTransTime.ReadOnly = true;
            // 
            // colResponseTime
            // 
            this.colResponseTime.DataPropertyName = "ResponseTime";
            dataGridViewCellStyle5.Format = "yyyy-MM-dd HH:mm:ss";
            this.colResponseTime.DefaultCellStyle = dataGridViewCellStyle5;
            this.colResponseTime.FillWeight = 87.05584F;
            this.colResponseTime.HeaderText = "ResponseTime";
            this.colResponseTime.Name = "colResponseTime";
            this.colResponseTime.ReadOnly = true;
            // 
            // colReturnValue
            // 
            this.colReturnValue.DataPropertyName = "ReturnValue";
            this.colReturnValue.FillWeight = 87.05584F;
            this.colReturnValue.HeaderText = "ReturnValue";
            this.colReturnValue.Name = "colReturnValue";
            this.colReturnValue.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Index";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DevSN";
            this.dataGridViewTextBoxColumn2.HeaderText = "DevSN";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 90;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CommitTime";
            dataGridViewCellStyle8.Format = "yyyy-MM-dd hh:mm:ss";
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn3.HeaderText = "CommitTime";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Content";
            this.dataGridViewTextBoxColumn4.HeaderText = "Content";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "TransTime";
            dataGridViewCellStyle9.Format = "yyyy-MM-dd hh:mm:ss";
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn5.HeaderText = "TransTime";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ResponseTime";
            dataGridViewCellStyle10.Format = "yyyy-MM-dd hh:mm:ss";
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn6.HeaderText = "ResponseTime";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 150;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "ReturnValue";
            this.dataGridViewTextBoxColumn7.HeaderText = "ReturnValue";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 80;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Status";
            this.dataGridViewImageColumn1.Image = global::Attendance.Properties.Resources.imgDevStatus1;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 50;
            // 
            // UCDeviceCmd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.pnlTop);
            this.Name = "UCDeviceCmd";
            this.Size = new System.Drawing.Size(885, 563);
            this.Load += new System.EventHandler(this.UCDeviceCmd_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlControl.ResumeLayout(false);
            this.pnlControl.PerformLayout();
            this.pnlData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeviceCmd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Label lblModuleName;
        private System.Windows.Forms.DataGridView dgvDeviceCmd;
        private System.Windows.Forms.ComboBox cmbDevSN;
        private System.Windows.Forms.Label lblDevSN;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Button btnGetAll;
        private System.Windows.Forms.Button btnClearList;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDevSN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCommitTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResponseTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReturnValue;
    }
}
