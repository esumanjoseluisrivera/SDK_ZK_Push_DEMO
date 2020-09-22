namespace Attendance
{
    partial class UCErrorLog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblModuleName = new System.Windows.Forms.Label();
            this.pnlData = new System.Windows.Forms.Panel();
            this.dgvErrorLog = new System.Windows.Forms.DataGridView();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.pb_Search = new System.Windows.Forms.PictureBox();
            this.cmb_DevSN = new System.Windows.Forms.ComboBox();
            this.lblDevSN = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.colIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DeviceSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colErrorCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colErrorMsg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataOrigin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCmdId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdditional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrorLog)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Search)).BeginInit();
            this.SuspendLayout();
            // 
            // lblModuleName
            // 
            this.lblModuleName.AutoSize = true;
            this.lblModuleName.Font = new System.Drawing.Font("Arial", 12F);
            this.lblModuleName.Location = new System.Drawing.Point(12, 8);
            this.lblModuleName.Name = "lblModuleName";
            this.lblModuleName.Size = new System.Drawing.Size(70, 18);
            this.lblModuleName.TabIndex = 2;
            this.lblModuleName.Text = "ErrorLog";
            this.lblModuleName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.dgvErrorLog);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(0, 65);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(816, 504);
            this.pnlData.TabIndex = 5;
            // 
            // dgvErrorLog
            // 
            this.dgvErrorLog.AllowUserToAddRows = false;
            this.dgvErrorLog.AllowUserToDeleteRows = false;
            this.dgvErrorLog.AllowUserToResizeRows = false;
            this.dgvErrorLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvErrorLog.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvErrorLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvErrorLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvErrorLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIndex,
            this.col_DeviceSN,
            this.colErrorCode,
            this.colTime,
            this.colErrorMsg,
            this.colDataOrigin,
            this.colCmdId,
            this.colAdditional});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvErrorLog.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvErrorLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvErrorLog.Location = new System.Drawing.Point(0, 0);
            this.dgvErrorLog.MultiSelect = false;
            this.dgvErrorLog.Name = "dgvErrorLog";
            this.dgvErrorLog.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvErrorLog.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvErrorLog.RowHeadersVisible = false;
            this.dgvErrorLog.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvErrorLog.RowTemplate.Height = 23;
            this.dgvErrorLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvErrorLog.Size = new System.Drawing.Size(816, 504);
            this.dgvErrorLog.TabIndex = 3;
            this.dgvErrorLog.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvErrorLog_RowStateChanged);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.btn_Clear);
            this.pnlTop.Controls.Add(this.pb_Search);
            this.pnlTop.Controls.Add(this.cmb_DevSN);
            this.pnlTop.Controls.Add(this.lblDevSN);
            this.pnlTop.Controls.Add(this.lblModuleName);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(816, 65);
            this.pnlTop.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(190)))), ((int)(((byte)(167)))));
            this.label1.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.Location = new System.Drawing.Point(0, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(3, 20);
            this.label1.TabIndex = 68;
            this.label1.Text = " ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Clear
            // 
            this.btn_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(190)))), ((int)(((byte)(167)))));
            this.btn_Clear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Clear.Font = new System.Drawing.Font("Arial", 12F);
            this.btn_Clear.ForeColor = System.Drawing.Color.White;
            this.btn_Clear.Location = new System.Drawing.Point(701, 29);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 30);
            this.btn_Clear.TabIndex = 67;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = false;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // pb_Search
            // 
            this.pb_Search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_Search.Image = global::Attendance.Properties.Resources.sousuo2;
            this.pb_Search.Location = new System.Drawing.Point(187, 31);
            this.pb_Search.Name = "pb_Search";
            this.pb_Search.Size = new System.Drawing.Size(27, 27);
            this.pb_Search.TabIndex = 66;
            this.pb_Search.TabStop = false;
            this.pb_Search.Click += new System.EventHandler(this.pb_Search_Click);
            // 
            // cmb_DevSN
            // 
            this.cmb_DevSN.Font = new System.Drawing.Font("Arial", 9F);
            this.cmb_DevSN.FormattingEnabled = true;
            this.cmb_DevSN.Location = new System.Drawing.Point(48, 33);
            this.cmb_DevSN.Name = "cmb_DevSN";
            this.cmb_DevSN.Size = new System.Drawing.Size(121, 23);
            this.cmb_DevSN.TabIndex = 65;
            // 
            // lblDevSN
            // 
            this.lblDevSN.AutoSize = true;
            this.lblDevSN.Font = new System.Drawing.Font("Arial", 12F);
            this.lblDevSN.Location = new System.Drawing.Point(14, 35);
            this.lblDevSN.Name = "lblDevSN";
            this.lblDevSN.Size = new System.Drawing.Size(30, 18);
            this.lblDevSN.TabIndex = 64;
            this.lblDevSN.Text = "SN";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn1.FillWeight = 106.599F;
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Index";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 30;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "LTime";
            dataGridViewCellStyle7.Format = "yyyy-MM-dd HH:mm:ss";
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn2.FillWeight = 98.90017F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Time";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "LTypeName";
            dataGridViewCellStyle8.Format = "yyyy-MM-dd HH:mm:ss";
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn3.FillWeight = 98.90017F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Type";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            this.dataGridViewTextBoxColumn3.Width = 120;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Content";
            this.dataGridViewTextBoxColumn4.FillWeight = 98.90017F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Content";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 300;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "DataOrigin";
            this.dataGridViewTextBoxColumn5.FillWeight = 98.90017F;
            this.dataGridViewTextBoxColumn5.HeaderText = "DataOrigin";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 115;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "CmdId";
            this.dataGridViewTextBoxColumn6.FillWeight = 98.90017F;
            this.dataGridViewTextBoxColumn6.HeaderText = "CmdId";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 115;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Additional";
            this.dataGridViewTextBoxColumn7.FillWeight = 98.90017F;
            this.dataGridViewTextBoxColumn7.HeaderText = "Additional";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 115;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Status";
            this.dataGridViewImageColumn1.Image = global::Attendance.Properties.Resources.imgDevStatus1;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 50;
            // 
            // colIndex
            // 
            this.colIndex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colIndex.DefaultCellStyle = dataGridViewCellStyle2;
            this.colIndex.Frozen = true;
            this.colIndex.HeaderText = "Index";
            this.colIndex.MinimumWidth = 50;
            this.colIndex.Name = "colIndex";
            this.colIndex.ReadOnly = true;
            this.colIndex.Width = 50;
            // 
            // col_DeviceSN
            // 
            this.col_DeviceSN.DataPropertyName = "DeviceID";
            this.col_DeviceSN.HeaderText = "DeviceSN";
            this.col_DeviceSN.Name = "col_DeviceSN";
            this.col_DeviceSN.ReadOnly = true;
            // 
            // colErrorCode
            // 
            this.colErrorCode.DataPropertyName = "ErrCode";
            this.colErrorCode.FillWeight = 87.05584F;
            this.colErrorCode.HeaderText = "ErrorCode";
            this.colErrorCode.Name = "colErrorCode";
            this.colErrorCode.ReadOnly = true;
            // 
            // colTime
            // 
            this.colTime.DataPropertyName = "Time";
            dataGridViewCellStyle3.Format = "yyyy-MM-dd HH:mm:ss";
            this.colTime.DefaultCellStyle = dataGridViewCellStyle3;
            this.colTime.FillWeight = 87.05584F;
            this.colTime.HeaderText = "Time";
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            this.colTime.Visible = false;
            // 
            // colErrorMsg
            // 
            this.colErrorMsg.DataPropertyName = "ErrMsg";
            this.colErrorMsg.FillWeight = 87.05584F;
            this.colErrorMsg.HeaderText = "ErrorMsg";
            this.colErrorMsg.Name = "colErrorMsg";
            this.colErrorMsg.ReadOnly = true;
            // 
            // colDataOrigin
            // 
            this.colDataOrigin.DataPropertyName = "DataOrigin";
            this.colDataOrigin.FillWeight = 87.05584F;
            this.colDataOrigin.HeaderText = "DataOrigin";
            this.colDataOrigin.Name = "colDataOrigin";
            this.colDataOrigin.ReadOnly = true;
            // 
            // colCmdId
            // 
            this.colCmdId.DataPropertyName = "CmdId";
            this.colCmdId.FillWeight = 87.05584F;
            this.colCmdId.HeaderText = "CmdId";
            this.colCmdId.Name = "colCmdId";
            this.colCmdId.ReadOnly = true;
            // 
            // colAdditional
            // 
            this.colAdditional.DataPropertyName = "Additional";
            this.colAdditional.FillWeight = 87.05584F;
            this.colAdditional.HeaderText = "Additional";
            this.colAdditional.Name = "colAdditional";
            this.colAdditional.ReadOnly = true;
            // 
            // UCErrorLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.pnlTop);
            this.Name = "UCErrorLog";
            this.Size = new System.Drawing.Size(816, 569);
            this.Load += new System.EventHandler(this.UCErrorLog_Load);
            this.pnlData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrorLog)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Search)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Label lblModuleName;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.DataGridView dgvErrorLog;
        private System.Windows.Forms.PictureBox pb_Search;
        private System.Windows.Forms.ComboBox cmb_DevSN;
        private System.Windows.Forms.Label lblDevSN;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DeviceSN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colErrorCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colErrorMsg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataOrigin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCmdId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdditional;
    }
}
