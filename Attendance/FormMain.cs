using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Utils;

namespace Attendance
{
    /// <summary>
    /// MainPage
    /// </summary>
    public partial class FormMain : Form
    {
        /// <summary>Current PageId
        /// </summary>
        private int _currentPageId = (int)PageIdEnum.Device;

        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>Close Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>Max Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picMax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                this.WindowState = FormWindowState.Maximized;
            }
        }
        /// <summary>Min Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        /// <summary>
        /// Haga clic en el icono de la barra de tareas para mostrar / ocultar la ventana
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_MINIMIZEBOX = 0x00020000;  // Winuser.definido en h
                CreateParams cp = base.CreateParams;
                cp.Style = cp.Style | WS_MINIMIZEBOX;   // Permitir un funcionamiento mínimo
                return cp;
            }
        }


        //Move Window
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int IParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            // Forma de arrastre
            this.Cursor = System.Windows.Forms.Cursors.Hand; //Cambiar el estilo del mouse
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        /// <summary>Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            tvMenu.ExpandAll();
            GetServerIP();

            SwitchPage(PageIdEnum.Device);
        }

        /// <summary>
        /// PageId
        /// </summary>
        public enum PageIdEnum
        {
            /// <summary>
            /// Página del dispositivo
            /// </summary>
            Device = 1,
            /// <summary>
            /// Página de usuario 
            /// </summary>
            User = 2,
            /// <summary>
            /// Página de registro de asistencia
            /// </summary>
            Attendance = 3,
            /// <summary>
            /// Página de registro de funcionamiento del dispositivo
            /// </summary>
            DeviceOperationLog = 4,
            /// <summary>
            /// Página de comandos del dispositivo
            /// </summary>
            DeviceCmd = 5,
            /// <summary>
            /// Generar página de comando
            /// </summary>
            CreateCmd = 6,
            /// <summary>
            /// Página de registro de excepciones
            /// </summary>
            ErrorLog = 7,
            /// <summary>
            /// Página de SMS
            /// </summary>
            SMS = 8,
            /// <summary>
            /// Página de códigos de trabajo       
            /// </summary>
            WorkCode = 9
        }

        /// <summary>PageLoading
        /// </summary>
        private bool m_pageLoading = false;
        /// <summary>SwitchPage
        /// </summary>
        /// <param name="id"></param>
        public void SwitchPage(PageIdEnum id)
        {
            if (m_pageLoading)
                return;

            m_pageLoading = true;

            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    SwitchPage(id);
                });
                return;
            }

            SetUcCommandVisible(true);
            switch (id)
            {
                case PageIdEnum.Device:
                    LoadPage(new UCDevice());
                    break;
                case PageIdEnum.DeviceCmd:
                    LoadPage(new UCDeviceCmd());
                    break;
                case PageIdEnum.User:
                    LoadPage(new UCUser());
                    break;
                case PageIdEnum.Attendance:
                    LoadPage(new UCAttendance());
                    break;
                case PageIdEnum.DeviceOperationLog:
                    LoadPage(new UCOperateLog());
                    break;
                case PageIdEnum.CreateCmd:
                    LoadPage(new UCCreateCmd());
                    break;
                case PageIdEnum.ErrorLog:
                    LoadPage(new UCErrorLog());
                    break;
                case PageIdEnum.SMS:
                    LoadPage(new UCSms());
                    break;
                case PageIdEnum.WorkCode:
                    LoadPage(new UCWorkCode());
                    break;
            }

            //Ocultar la ventana de interacción en tiempo real del dispositivo de servicio
            if (id == PageIdEnum.User
                || id == PageIdEnum.Attendance
                || id == PageIdEnum.DeviceOperationLog
                || id == PageIdEnum.ErrorLog
                || id == PageIdEnum.SMS
                || id == PageIdEnum.WorkCode)
            {
                SetUcCommandVisible(false);
            }

            _currentPageId = (int)id;
            m_pageLoading = false;
        }
        /// <summary>Ocultar / mostrar información interactiva en tiempo real
        /// </summary>
        /// <param name="visible"></param>
        private void SetUcCommandVisible(bool visible)
        {
            this.ucCommInfo1.Visible = visible;
            this.scMain.Panel2Collapsed = !visible;
        }
        private DateTime m_lastCollect = Tools.GetDateTimeNow(); //Última hora de GC
        UserControl m_lastfrm = null; //Interfaz actual

        /// <summary>LoadPage
        /// </summary>
        /// <param name="frm"></param>
        private void LoadPage(UserControl frm)
        {
            UserControl tmpC = m_lastfrm;
            m_lastfrm = frm;

            this.scMain.Panel1.Controls.Clear();
            m_lastfrm.Parent = this.scMain.Panel1;
            m_lastfrm.Dock = DockStyle.Fill;
            m_lastfrm.Show();

            if (tmpC != null)
            {
                try
                {
                    try
                    {
                        #region Dispose by reflect
                        FieldInfo[] fieldInfoArray = tmpC.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

                        foreach (FieldInfo fi in fieldInfoArray)
                        {
                            if (fi.FieldType == typeof(Control))
                            {
                                Control ctrl = (Control)fi.GetValue(tmpC);
                                DisposeUC(ctrl);
                            }
                            else if (fi.FieldType == typeof(ToolStrip)) //RedGate it, find it to GC
                            {
                                ToolStrip toolStrip = (ToolStrip)fi.GetValue(tmpC);
                                toolStrip.Dispose();
                            }
                        }
                        #endregion
                    }
                    catch
                    { }
                    tmpC.Parent = null;
                    tmpC.Dispose();
                }
                catch
                { }
                tmpC = null;
            }

            if (DateTime.Now > m_lastCollect.AddMinutes(1))
            {
                m_lastCollect = DateTime.Now;
                try
                {
                    GC.Collect();
                }
                catch
                { }
            }
        }

        /// <summary>DisposeUC
        /// </summary>
        /// <param name="ctl"></param>
        private void DisposeUC(Control ctl)
        {
            if (ctl != null)
            {
                if (ctl.Controls.Count > 0)
                {
                    for (int i = 0; i < ctl.Controls.Count; i++)
                    {
                        DisposeUC(ctl.Controls[i]);
                    }
                }
                ctl.Controls.Clear();
                ctl.Dispose();
                ctl = null;
            }
        }

        private void tvMenu_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //if (!(sender is TreeNode))
            //    return;


        }

        private void tvMenu_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {

        }

        private void tvMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = this.tvMenu.SelectedNode;

            if (node.Level == 0)
            {
                if (!node.IsExpanded)
                    node.Expand();
            }
            else
            {
                switch (node.Name)
                {
                    case "nodeDevice":
                        SwitchPage(PageIdEnum.Device);
                        break;
                    case "nodeDeviceCmd":
                        SwitchPage(PageIdEnum.DeviceCmd);
                        break;
                    case "nodeUser":
                        SwitchPage(PageIdEnum.User);
                        break;
                    case "nodeAttendance":
                        SwitchPage(PageIdEnum.Attendance);
                        break;
                    case "nodeWorkCode":
                        SwitchPage(PageIdEnum.WorkCode);
                        break;
                    case "nodeDeviceOperationLog":
                        SwitchPage(PageIdEnum.DeviceOperationLog);
                        break;
                    case "nodeCreateCmd":
                        SwitchPage(PageIdEnum.CreateCmd);
                        break;
                    case "nodeDeviceExceptionLog":
                        SwitchPage(PageIdEnum.ErrorLog);
                        break;
                    case "nodeSMS":
                        SwitchPage(PageIdEnum.SMS);
                        break;
                    default:
                        break;
                }
            }
        }

        private void tvMenu_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (m_pageLoading)
                e.Cancel = true;
        }

        /// <summary>Server start flag
        /// </summary>
        private bool _isStart = false;
        //Start or Stop Server
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_isStart)
            {//Stop Server
                StopListenling();
                btnStart.Text = "Start";
                btnStart.ForeColor = Color.FromArgb(37, 190, 167);
                this.ucCommInfo1.AddCommInfo("", 4);
            }
            else
            {//Start Server
                StartListenling(cmbIP.Text, txtPort.Text);
                btnStart.Text = "Stop";
                btnStart.ForeColor = Color.Red;
                this.ucCommInfo1.AddCommInfo("", 3);
            }
            _isStart = !_isStart;
        }

        /// <summary>
        /// get locale IP
        /// </summary>
        /// <returns></returns>
        private void GetServerIP()
        {
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            cmbIP.Text = "";

            //Obtenga la dirección del servidor y solo conserve la dirección IPV4
            foreach (IPAddress ip in ipHost.AddressList)
            {
                if (!Regex.IsMatch(ip.ToString(), @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$"))
                {
                    continue;
                }

                cmbIP.Items.Add(ip.ToString());
            }
            cmbIP.SelectedIndex = 0;
        }

        private ListenClient listenClient = null;
        private Thread listenClientThread = null;
        /// <summary>
        /// start to listening
        /// </summary>
        /// <param name="serverIP"></param>
        /// <param name="Port"></param>
        private void StartListenling(string serverIP, string Port)
        {
            int port = string.IsNullOrEmpty(Port) ? 8080 : Int32.Parse(Port);
            listenClient = new ListenClient();
            listenClient.ServerIP = serverIP;
            listenClient.Port = port;
            listenClientThread = new Thread(new ThreadStart(listenClient.StartListening));
            listenClient.OnError += listenClient_OnError;
            listenClient.OnNewAttLog += listenClient_OnNewAttLog;
            listenClient.OnNewUser += listenClient_OnNewUser;
            listenClient.OnNewFP += listenClient_OnNewFP;
            listenClient.OnNewFace += listenClient_OnNewFace;
            listenClient.OnNewPalm += listenClient_OnNewPalm;
            listenClient.OnNewBioPhoto += listenClient_OnNewBioPhoto;
            listenClient.OnNewOpLog += listenClient_OnNewOpLog;
            listenClient.OnNewErrorLog += listenClient_OnNewErrorLog;
            listenClient.OnDeviceSync += listenClient_OnDeviceSync;
            listenClient.OnSendDataEvent += listenClient_OnSendDataEvent;
            listenClient.OnReceiveDataEvent += listenClient_OnReceiveDataEvent;
            listenClientThread.IsBackground = true;
            listenClientThread.Start();
        }

        /// <summary>
        /// stop listenling
        /// </summary>
        private void StopListenling()
        {
            if (listenClient != null && listenClient.Listening)
            {
                listenClient.StopListening();
            }
        }

        #region Gestión de seguimiento de eventos
        private DeviceBll _deviceBll = null;
        private DeviceBll DeviceBll
        {
            get
            {
                if (_deviceBll == null)
                    _deviceBll = new DeviceBll();
                return _deviceBll;
            }
        }
        private AttLogBll _attLogBll = null;
        private AttLogBll AttLogBll
        {
            get
            {
                if (_attLogBll == null)
                    _attLogBll = new AttLogBll();
                return _attLogBll;
            }
        }
        private OpLogBll _opLogBll = null;
        private OpLogBll OpLogBll
        {
            get
            {
                if (_opLogBll == null)
                    _opLogBll = new OpLogBll();
                return _opLogBll;
            }
        }
        private ErrorLogBll _erLogBll = null;
        private ErrorLogBll ErLogBll
        {
            get
            {
                if (_erLogBll == null)
                    _erLogBll = new ErrorLogBll();
                return _erLogBll;
            }
        }
        private UserInfoBll _userInfoBll = null;
        private UserInfoBll UserInfoBll
        {
            get
            {
                if (_userInfoBll == null)
                    _userInfoBll = new UserInfoBll();
                return _userInfoBll;
            }
        }
        private TmpFPBll _fPBll = null;
        private TmpFPBll FPBll
        {
            get
            {
                if (_fPBll == null)
                    _fPBll = new TmpFPBll();
                return _fPBll;
            }
        }
        private TmpFaceBll _faceBll = null;
        private TmpFaceBll FaceBll
        {
            get
            {
                if (_faceBll == null)
                    _faceBll = new TmpFaceBll();
                return _faceBll;
            }
        }
        private TmpBioDataBll _bioDataBll = null;
        private TmpBioDataBll BioDataBll
        {
            get
            {
                if (_bioDataBll == null)
                    _bioDataBll = new TmpBioDataBll();
                return _bioDataBll;
            }
        }
        private TmpBioPhotoBll _bioPhotoBll = null;
        private TmpBioPhotoBll BioPhotoBll
        {
            get
            {
                if (_bioPhotoBll == null)
                    _bioPhotoBll = new TmpBioPhotoBll();
                return _bioPhotoBll;
            }
        }
        //autoMatic to add Device and copy Device to Database 
        private void listenClient_OnNewMachine(string sn)
        {
            DeviceModel machine = new DeviceModel();
            machine.DevSN = sn;
            machine.TimeZone = "34";
            if (DeviceBll.Add(machine) > 0)
            {
                // add device 
            }
        }

        //AttLog copy to Database 
        private void listenClient_OnNewAttLog(AttLogModel attlog)
        {
            if (AttLogBll.Add(attlog) > 0)
            {
                if (_currentPageId == (int)PageIdEnum.Attendance && m_lastfrm != null)
                {
                    ((UCAttendance)m_lastfrm).AddNewRow(attlog);
                }
                else
                {
                    if (_currentPageId == (int)PageIdEnum.Device && m_lastfrm != null)
                    {
                        UCDevice uCDevice = (UCDevice)m_lastfrm;
                        uCDevice.UpdateDeviceMask(attlog.DeviceID, attlog.MaskFlag);
                        uCDevice.UpdateDeviceTemp(attlog.DeviceID, attlog.Temperature);
                    }
                }

            }
        }

        //OpLog copy to Database 
        private void listenClient_OnNewOpLog(OpLogModel oplog)
        {
            if (OpLogBll.Add(oplog) > 0)
            {
                //add oplog 
                if (_currentPageId == (int)PageIdEnum.DeviceOperationLog && m_lastfrm != null)
                {
                    UCOperateLog uCOperateLog = (UCOperateLog)m_lastfrm;
                    uCOperateLog.RefreshData();
                }
            }
        }
        //Error copy to Database 
        private void listenClient_OnNewErrorLog(ErrorLogModel erlog)
        {
            if (ErLogBll.Add(erlog) > 0)
            {
                //add erlog 
                if (_currentPageId == (int)PageIdEnum.ErrorLog && m_lastfrm != null)
                {
                    ((UCErrorLog)m_lastfrm).AddNewRow(erlog);
                }
            }
        }
        //UserInfo copy to Database
        private void listenClient_OnNewUser(UserInfoModel user)
        {
            var userModel = UserInfoBll.Get(user.PIN);
            int nRtn = 0;
            if (null == userModel)
            {
                nRtn = _userInfoBll.Add(user);
            }
            else
            {
                nRtn = _userInfoBll.Update(user);
            }
            if (nRtn >0&& _currentPageId == (int)PageIdEnum.User && m_lastfrm != null)
            {
                ((UCUser)m_lastfrm).LoadAllUsers();
            }
        }

        private void listenClient_OnNewFP(TmpFPModel fp)
        {
            if (FPBll.Add(fp) > 0)
            {
                if (_currentPageId == (int)PageIdEnum.User && m_lastfrm != null)
                {
                    if (fp.MajorVer == "9")
                        ((UCUser)m_lastfrm).UpdateUserFP9Info(fp);
                    else if (fp.MajorVer == "10")
                        ((UCUser)m_lastfrm).UpdateUserFP10Info(fp);
                }
            }
            // Cuando el usuario tiene una huella digital para cargar, actualice el número de huellas digitales del usuario correspondiente en la lista
        }
        //Face tmplate copy to Database
        private void listenClient_OnNewFace(TmpFaceModel face)
        {
            if (FaceBll.Add(face) > 0)
            {
                //Cuando el usuario tenga una cara para cargar, actualice la cantidad de caras del usuario correspondiente en la lista
                if (_currentPageId == (int)PageIdEnum.User && m_lastfrm != null)
                {
                    ((UCUser)m_lastfrm).UpdateUserFaceInfo(face);

                }
            }

        }

        //palm tmplate copy to Database
        private void listenClient_OnNewPalm(TmpBioDataModel palm)
        {
            if (BioDataBll.Add(palm) > 0)
            {
                if (_currentPageId == (int)PageIdEnum.User && m_lastfrm != null)
                {
                    ((UCUser)m_lastfrm).UpdateUserPalmInfo(palm);
                }
            }

        }
        private void listenClient_OnNewBioPhoto(TmpBioPhotoModel bioPhoto)
        {
            if (BioPhotoBll.Add(bioPhoto) > 0)
            {
                //Cuando el usuario tenga una cara para cargar, actualice la cantidad de caras del usuario correspondiente en la lista
                if (_currentPageId == (int)PageIdEnum.User && m_lastfrm != null)
                {
                    ((UCUser)m_lastfrm).UpdateUserFaceInfo(bioPhoto);
                }
            }

        }
        //get vendor name
        private void listenClient_OnGetVendorName(string sn, string vendorName)
        {
            // update vendorName to gridview 
            DeviceBll.UpdateVendorName(sn, vendorName);
        }

        //Error Infor shows 
        private void listenClient_OnError(string errMessage)
        {
            if (errMessage.IndexOfEx("UnKnown message from device: POST /iclock/registry?") >= 0)
            {
                string sn = GetDevSN(errMessage);
                MessageBox.Show("Tener acceso al equipo de seguridad(SN=" + sn + ")，Este servicio solo admite equipos de asistencia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Escribir en el archivo txt local
            Log.WriteLogs(errMessage);
        }
        /// <summary>
        /// Obtener dispositivo SN
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        private string GetDevSN(string buffer)
        {
            string[] splitStr = buffer.Split('&', '?', ' ');
            if (splitStr.Length <= 0)
            {
                return null;
            }

            foreach (string tmpStr in splitStr)
            {
                if (tmpStr.IndexOfEx("SN=") >= 0)
                {
                    return tmpStr.Substring(tmpStr.IndexOfEx("SN=") + 3);
                }
            }
            return null;
        }

        //add Send data
        private void listenClient_OnSendDataEvent(string Data)
        {
            this.ucCommInfo1.AddCommInfo(Data, 1);
        }

        //add receive data
        private void listenClient_OnReceiveDataEvent(string Data)
        {
            this.ucCommInfo1.AddCommInfo(Data, 0);
        }

        //sync time
        private void listenClient_OnDeviceSync(DeviceModel device)
        {
            //Update device
            if (_currentPageId == (int)PageIdEnum.Device && m_lastfrm != null)
            {
                UCDevice ucDevice = (UCDevice)m_lastfrm;
                ucDevice.UpdateDevice(device);
            }
        }
        #endregion


        private Brush _brush = new SolidBrush(Color.FromArgb(37, 190, 167));
        /// <summary>
        /// Cambiar el color de fondo del nodo seleccionado
        /// </summary>
        private void tvMenu_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if ((e.State & TreeNodeStates.Selected) != 0)
            {
                Rectangle rectangle = new Rectangle(e.Node.Bounds.X, e.Node.Bounds.Y, e.Node.Bounds.Width + 5, e.Node.Bounds.Height);
                e.Graphics.FillRectangle(_brush, rectangle);
                Font nodeFont = e.Node.NodeFont;
                if (nodeFont == null)
                    nodeFont = ((TreeView)sender).Font;
                e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.White, Rectangle.Inflate(rectangle, 2, -6));
            }
            else
            {
                e.DrawDefault = true;
            }
        }
    }
}
