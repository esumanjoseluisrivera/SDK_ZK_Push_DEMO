namespace Attendance
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Device");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("DeviceOperationLog");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("CreateCmd");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("DeviceCmd");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("SMS");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("DeviceGroup", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("User");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("UserGroup", new System.Windows.Forms.TreeNode[] {
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Attendance");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("WorkCode");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("AttendanceGroup", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("DeviceExceptionLog");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("LogGroup", new System.Windows.Forms.TreeNode[] {
            treeNode12});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlWindowsButton = new System.Windows.Forms.Panel();
            this.picMax = new System.Windows.Forms.PictureBox();
            this.picMin = new System.Windows.Forms.PictureBox();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlSetting = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.cmbIP = new System.Windows.Forms.ComboBox();
            this.lblIP = new System.Windows.Forms.Label();
            this.tvMenu = new System.Windows.Forms.TreeView();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.ucCommInfo1 = new Attendance.UCCommInfo();
            this.ucAttendance1 = new Attendance.UCAttendance();
            this.pnlTop.SuspendLayout();
            this.pnlWindowsButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.pnlLeft.SuspendLayout();
            this.pnlSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.pnlWindowsButton);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1350, 58);
            this.pnlTop.TabIndex = 0;
            this.pnlTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);
            // 
            // pnlWindowsButton
            // 
            this.pnlWindowsButton.Controls.Add(this.picMax);
            this.pnlWindowsButton.Controls.Add(this.picMin);
            this.pnlWindowsButton.Controls.Add(this.picClose);
            this.pnlWindowsButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlWindowsButton.Location = new System.Drawing.Point(1150, 0);
            this.pnlWindowsButton.Name = "pnlWindowsButton";
            this.pnlWindowsButton.Size = new System.Drawing.Size(200, 58);
            this.pnlWindowsButton.TabIndex = 5;
            // 
            // picMax
            // 
            this.picMax.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMax.Image = global::Attendance.Properties.Resources.btn_maximize2;
            this.picMax.Location = new System.Drawing.Point(83, 12);
            this.picMax.Name = "picMax";
            this.picMax.Size = new System.Drawing.Size(44, 39);
            this.picMax.TabIndex = 7;
            this.picMax.TabStop = false;
            this.picMax.Click += new System.EventHandler(this.picMax_Click);
            // 
            // picMin
            // 
            this.picMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMin.Image = global::Attendance.Properties.Resources.btn_minimize2;
            this.picMin.Location = new System.Drawing.Point(12, 12);
            this.picMin.Name = "picMin";
            this.picMin.Size = new System.Drawing.Size(44, 39);
            this.picMin.TabIndex = 6;
            this.picMin.TabStop = false;
            this.picMin.Click += new System.EventHandler(this.picMin_Click);
            // 
            // picClose
            // 
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Image = global::Attendance.Properties.Resources.btn_close2;
            this.picClose.Location = new System.Drawing.Point(144, 12);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(44, 39);
            this.picClose.TabIndex = 5;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 16F);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(190)))), ((int)(((byte)(167)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(239, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Attendance Push Demo";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pnlLeft.Controls.Add(this.pnlSetting);
            this.pnlLeft.Controls.Add(this.tvMenu);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 58);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlLeft.Size = new System.Drawing.Size(244, 694);
            this.pnlLeft.TabIndex = 1;
            // 
            // pnlSetting
            // 
            this.pnlSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(190)))), ((int)(((byte)(167)))));
            this.pnlSetting.Controls.Add(this.btnStart);
            this.pnlSetting.Controls.Add(this.txtPort);
            this.pnlSetting.Controls.Add(this.lblPort);
            this.pnlSetting.Controls.Add(this.cmbIP);
            this.pnlSetting.Controls.Add(this.lblIP);
            this.pnlSetting.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSetting.Location = new System.Drawing.Point(0, 581);
            this.pnlSetting.Name = "pnlSetting";
            this.pnlSetting.Size = new System.Drawing.Size(244, 113);
            this.pnlSetting.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.White;
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Arial", 12F);
            this.btnStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(190)))), ((int)(((byte)(167)))));
            this.btnStart.Location = new System.Drawing.Point(70, 73);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(120, 28);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtPort
            // 
            this.txtPort.Font = new System.Drawing.Font("Arial", 9F);
            this.txtPort.Location = new System.Drawing.Point(70, 42);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(121, 21);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "8080";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Arial", 10F);
            this.lblPort.ForeColor = System.Drawing.Color.White;
            this.lblPort.Location = new System.Drawing.Point(34, 44);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(34, 16);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "Port";
            // 
            // cmbIP
            // 
            this.cmbIP.Font = new System.Drawing.Font("Arial", 9F);
            this.cmbIP.FormattingEnabled = true;
            this.cmbIP.Location = new System.Drawing.Point(70, 15);
            this.cmbIP.Name = "cmbIP";
            this.cmbIP.Size = new System.Drawing.Size(121, 23);
            this.cmbIP.TabIndex = 1;
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Font = new System.Drawing.Font("Arial", 10F);
            this.lblIP.ForeColor = System.Drawing.Color.White;
            this.lblIP.Location = new System.Drawing.Point(34, 18);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(20, 16);
            this.lblIP.TabIndex = 0;
            this.lblIP.Text = "IP";
            // 
            // tvMenu
            // 
            this.tvMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tvMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tvMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvMenu.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.tvMenu.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvMenu.ForeColor = System.Drawing.Color.White;
            this.tvMenu.HideSelection = false;
            this.tvMenu.ItemHeight = 35;
            this.tvMenu.Location = new System.Drawing.Point(0, 3);
            this.tvMenu.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tvMenu.Name = "tvMenu";
            treeNode1.Name = "nodeDevice";
            treeNode1.Text = "Device";
            treeNode2.Name = "nodeDeviceOperationLog";
            treeNode2.Text = "DeviceOperationLog";
            treeNode3.Name = "nodeCreateCmd";
            treeNode3.Text = "CreateCmd";
            treeNode4.Name = "nodeDeviceCmd";
            treeNode4.Text = "DeviceCmd";
            treeNode5.Name = "nodeSMS";
            treeNode5.Text = "SMS";
            treeNode6.Name = "nodeDeviceGroup";
            treeNode6.Text = "DeviceGroup";
            treeNode7.Name = "nodeUser";
            treeNode7.Text = "User";
            treeNode8.Name = "nodeUserGroup";
            treeNode8.Text = "UserGroup";
            treeNode9.Name = "nodeAttendance";
            treeNode9.Text = "Attendance";
            treeNode10.Name = "nodeWorkCode";
            treeNode10.Text = "WorkCode";
            treeNode11.Name = "nodeAttendanceGroup";
            treeNode11.Text = "AttendanceGroup";
            treeNode12.Name = "nodeDeviceExceptionLog";
            treeNode12.Text = "DeviceExceptionLog";
            treeNode13.Name = "nodeLogGroup";
            treeNode13.Text = "LogGroup";
            this.tvMenu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode8,
            treeNode11,
            treeNode13});
            this.tvMenu.Size = new System.Drawing.Size(244, 691);
            this.tvMenu.TabIndex = 0;
            this.tvMenu.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.tvMenu_DrawNode);
            this.tvMenu.NodeMouseHover += new System.Windows.Forms.TreeNodeMouseHoverEventHandler(this.tvMenu_NodeMouseHover);
            this.tvMenu.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvMenu_BeforeSelect);
            this.tvMenu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvMenu_AfterSelect);
            this.tvMenu.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvMenu_NodeMouseClick);
            // 
            // scMain
            // 
            this.scMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(244, 58);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.ucAttendance1);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.ucCommInfo1);
            this.scMain.Size = new System.Drawing.Size(1106, 694);
            this.scMain.SplitterDistance = 413;
            this.scMain.TabIndex = 2;
            // 
            // ucCommInfo1
            // 
            this.ucCommInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCommInfo1.Location = new System.Drawing.Point(0, 0);
            this.ucCommInfo1.Name = "ucCommInfo1";
            this.ucCommInfo1.Size = new System.Drawing.Size(1104, 275);
            this.ucCommInfo1.TabIndex = 0;
            // 
            // ucAttendance1
            // 
            this.ucAttendance1.Location = new System.Drawing.Point(-97, 3);
            this.ucAttendance1.Name = "ucAttendance1";
            this.ucAttendance1.Size = new System.Drawing.Size(885, 610);
            this.ucAttendance1.TabIndex = 3;
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1350, 752);
            this.ControlBox = false;
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1135, 730);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlWindowsButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.pnlSetting.ResumeLayout(false);
            this.pnlSetting.PerformLayout();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlWindowsButton;
        private System.Windows.Forms.PictureBox picMax;
        private System.Windows.Forms.PictureBox picMin;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.TreeView tvMenu;
        private System.Windows.Forms.Panel pnlSetting;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.ComboBox cmbIP;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.SplitContainer scMain;
        private UCCommInfo ucCommInfo1;
        private UCAttendance ucAttendance1;
    }
}