using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using BLL;
using Model;
using System.IO;
using System.Collections;

namespace Attendance
{
    /// <summary>
    /// 用户
    /// </summary>
    public partial class UCUser : UserControl
    {
        private UserInfoBll _bll = new UserInfoBll();
        private List<DataGridViewRow> _CurSelectRows = new List<DataGridViewRow>();
        private DeviceCmdBll _cmdBll = new DeviceCmdBll();
        private TmpFPBll _tmpFPBll = new TmpFPBll();
        private TmpFaceBll _faceBll = new TmpFaceBll();
        private TmpBioPhotoBll _tmpBioPhotoBll = new TmpBioPhotoBll();
        private TmpBioDataBll _tmpBioDataBll = new TmpBioDataBll();
        private string[] labMsg = new string[11];
        private DataTable _dt = new DataTable();
        private DatagridviewCheckboxHeaderCell _headerCheckBox;
        public UCUser()
        {
            InitializeComponent();
        }
        #region 初始化界面数据
        private void UCUser_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            this.dgvUser.AutoGenerateColumns = false;
            this.lblMsg.Visible = false;
            _headerCheckBox = new DatagridviewCheckboxHeaderCell();
            _headerCheckBox.OnCheckBoxClicked += new DatagridviewcheckboxHeaderEventHander(ch_OnCheckBoxClicked);//关联单击事件
            var checkboxCol = this.dgvUser.Columns[0] as DataGridViewCheckBoxColumn;
            checkboxCol.HeaderCell = _headerCheckBox;
            checkboxCol.HeaderCell.Value = string.Empty;//消除列头checkbox旁出现的文字
            InitMsg();
            LoadAllUsers(); //加载当前数据库里面的所有用户
            LoadCmbPrivilage();
            LoadDeviceSN(); //加载当前在线的所有机器的序列号sn

          

        }
       
        /// <summary>
        /// 加载所有用户
        /// </summary>
        public void LoadAllUsers()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => { LoadAllUsers(); }));
            }
            else
            {
                this.dgvUser.DataSource = null;
                _dt = _bll.GetAll();
                this.dgvUser.DataSource = _dt;
                _headerCheckBox._checked = false;
            }
           
        }

        /// <summary>
        /// 绑定权限下拉框数据
        /// </summary>
        private void LoadCmbPrivilage()
        {
            //绑定短消息类型下拉框
            ArrayList list = new ArrayList();
            list.Add(new DictionaryEntry("0", "User"));
            list.Add(new DictionaryEntry("14", "Administrator"));
            cmbPrivilege.DataSource = list;  
            cmbPrivilege.DisplayMember = "Value";
            cmbPrivilege.ValueMember = "Key";
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
        public void InitMsg()
        {
            try
            {
                labMsg[0] = "Please input user id.";
                labMsg[1] = "Please input device sn.";
                labMsg[2] = "Operate successful.";
                labMsg[3] = "Operate fail.";
                labMsg[4] = "Update successful.";
                labMsg[5] = "Update fail.";
                labMsg[6] = "Add successful.";
                labMsg[7] = "Add fail.";
                labMsg[8] = "The user is not exist.";
                labMsg[9] = "The command is error.";
                labMsg[10] = "Please save user picture first.";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        #endregion
        #region 用户数据管理
        /// <summary>
        /// 添加用户按钮事件
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            txtPin.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtCard.Text = string.Empty;
            cmbPrivilege.SelectedIndex = 0;
            txtPin.Enabled = true;
            picUserPhoto.Image = picUserPhoto.ErrorImage;
        }
        /// <summary>
        /// 保存用户按钮事件
        /// </summary>

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPin.Text))
            {
                this.lblMsg.Visible = true;
                this.lblMsg.Text = "Please input user id.";
                return;
            }
            lblMsg.Visible = false;
            UserInfoModel user = _bll.Get(txtPin.Text.Trim());  //数据库中获取对应pin的用户信息
            if (user == null)
            {
                user = new UserInfoModel();
            }
            user.PIN = txtPin.Text;
            user.UserName = txtUserName.Text;
            user.Passwd = txtPassword.Text;
            user.IDCard = txtCard.Text;
            user.Pri = cmbPrivilege.SelectedValue.ToString();

            int ret = 0;
            try
            {
                //数据库中没有对应的用户，则增加
                if (user.ID == 0)       
                {
                    ret = _bll.Add(user);
                    if (ret > 0)
                    {
                        LoadAllUsers();  //更新用户列表
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
                    ret = _bll.Update(user);
                    if (ret > 0)
                    {
                        LoadAllUsers();  //更新用户列表
                        this.lblMsg.Visible = true;
                        this.lblMsg.Text = "Update successful.";
                    }
                    else
                    {
                        this.lblMsg.Visible = true;
                        this.lblMsg.Text = "Update fail.";
                    }
                   
                }

                if (ret > 0)
                {
                    //保存用户photoiD
                    string strDesPath = "";
                    strDesPath = System.Environment.CurrentDirectory + "\\Photo\\" + txtPin.Text + ".jpg";

                    if (picUserPhoto.ImageLocation != null)
                        File.Copy(picUserPhoto.ImageLocation, strDesPath, true);//notice,picturebox的ImageLocation使用前，需要手动给他附上值

                    txtPin.Enabled = false;     //保存了之后pin不可再编辑
                }
            }
            catch (Exception ex)
            {
                this.lblMsg.Visible = true;
                this.lblMsg.Text = ex.ToString();
            }
        }
        /// <summary>
        /// 下发按钮事件
        /// </summary>
        private void btnUpload_Click(object sender, EventArgs e)
        {
            string privilege = string.Empty;
            string curPin = string.Empty;
            byte[] bName = new byte[24];
            
            string uName = "", sName = "";
            if (null == new DeviceBll().Get(cmbDevice.Text))
            {
                UserMessageShow(1, "");
                return;
            }
            if (null == _bll.Get(txtPin.Text.Trim()))
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Please save user.";
                return;
            }

            lblMsg.Visible = false;

            GetCurSelectRows();
            if (_CurSelectRows.Count == 0)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Please select user item.";
                return;
            }
            //send upload Userinfo commands
            foreach (DataGridViewRow item in _CurSelectRows)
            {
                privilege = item.Cells["colPrivilege"].Value.ToString();
                if (privilege == "14")
                {
                    privilege = "14";
                }
                else
                {
                    privilege = "0";
                }
                curPin = item.Cells["colUserPin"].Value.ToString();
                DeviceCmdModel cmd = new DeviceCmdModel();
                cmd.DevSN = cmbDevice.Text;
                cmd.CommitTime = DateTime.Now;
                sName = item.Cells["colUserName"].Value.ToString();
                bName = System.Text.Encoding.UTF8.GetBytes(sName);

                uName = System.Text.Encoding.Default.GetString(bName);
                sName = uName;

                //for (int i = 1; i < 1000; i++)
                {
                    cmd.Content = string.Format(Commands.Command_UpdateUserInfo, item.Cells["colUserPin"].Value.ToString(), sName,
                        privilege, item.Cells["colPassword"].Value.ToString(), item.Cells["colCardNumber"].Value.ToString(), item.Cells["colGroup"].Value.ToString(), item.Cells["colTimezone"].Value.ToString());


                    if (string.IsNullOrEmpty(cmd.Content))
                    {
                        UserMessageShow(9, "");
                        return;
                    }
                    lblMsg.Visible = false;
                    try
                    {
                        if (_cmdBll.Add(cmd) >= 0)
                        {
                            UserMessageShow(2, "");
                            
                            if (cb_FP.Checked == true)
                            {
                                uploadUserFingerTemplate(cmd.DevSN, curPin);
                            }
                            if (cb_Face.Checked == true)
                            {
                                uploadUserFaceTemplate(cmd.DevSN, curPin);
                            }
                            if (cb_Palm.Checked == true)
                            {
                                uploadPalmTemplate(cmd.DevSN, curPin);
                            }
                            if (cb_Photo.Checked == true)
                            {
                                uploadUserPhotoID(cmd.DevSN, curPin);
                            }
                            
                        }
                        else
                        {
                            UserMessageShow(3, "");
                        }
                    }
                    catch(Exception ex) 
                    {
                        MessageBox.Show("Upload Error/nException:" + ex.Message+" "+ex.StackTrace);
                    }
                }

            }
        }
        /// <summary>
        /// 获取当前选择行
        /// </summary>
        /// <returns></returns>
        private List<DataGridViewRow> GetCurSelectRows()
        {
            _CurSelectRows = new List<DataGridViewRow>();
            for (int i = 0; i < dgvUser.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgvUser.Rows[i].Cells[0].Value) == true)
                {
                    _CurSelectRows.Add(dgvUser.Rows[i]);
                }
            }
            return _CurSelectRows;
        }
        /// <summary>
        /// 下发用户指纹
        /// </summary>
        /// <param name="sn">设备序列号</param>
        /// <param name="pin">用户工号</param>
        private void uploadUserFingerTemplate(string sn,string pin)
        {
            DeviceModel deviceModel = new DeviceBll().Get(sn);
            if (!deviceModel.IsBioDataSupport(BioType.FingerPrint))
            {
                return;
            }

            List<TmpFPModel> templateList = _tmpFPBll.Get(pin);
            DeviceCmdModel cmd = new DeviceCmdModel
            {
                DevSN = sn
            };
            string verTmp = deviceModel.GetBioVersion(BioType.FingerPrint).Split('.')[0];
            //send upload FingerTmp commands
            foreach (TmpFPModel template in templateList)
            {
                cmd.CommitTime = DateTime.Now;
                if (template.MajorVer != verTmp)
                    continue;
                if (template.MajorVer != "12")
                {
                    cmd.Content = string.Format(Commands.Command_UpdateFingerTmp, template.Pin, template.Fid,
                    template.Size, template.Valid, template.Tmp);
                }
                else
                {

                    cmd.Content = string.Format(Commands.Command_UpdateBioData, template.Pin, template.Fid,
                    "", template.Valid, template.Duress, "1", template.MajorVer, template.MinorVer, "", template.Tmp);
                }
                if (string.IsNullOrEmpty(cmd.Content))
                {
                    UserMessageShow(9, "");
                    return;
                }
                lblMsg.Visible = false;
                try
                {
                    if (_cmdBll.Add(cmd) >= 0)
                    {
                        UserMessageShow(2, "");
                    }
                    else
                    {
                        UserMessageShow(3, "");
                    }
                }
                catch { }
            }

          
        }

        /// <summary>
        /// 下发用户面部数据
        /// </summary>
        /// <param name="sn">设备序列号</param>
        /// <param name="pin">用户工号</param>
        private void uploadUserFaceTemplate(string sn,string pin)
        {
            DeviceModel deviceModel = new DeviceBll().Get(sn);
            
            
            DeviceCmdModel cmd = new DeviceCmdModel();
            cmd.DevSN = sn;
            if (deviceModel.IsBioDataSupport(BioType.Face))
            {
                List<TmpFaceModel> faceList = _faceBll.Get(pin);
                //send upload face commands
                foreach (TmpFaceModel faceTmp in faceList)
                {
                    cmd.CommitTime = DateTime.Now;
                    cmd.Content = string.Format(Commands.Command_UpdateFaceTmp, faceTmp.Pin, faceTmp.Fid,
                        faceTmp.Valid, faceTmp.Size, faceTmp.Tmp);

                    if (string.IsNullOrEmpty(cmd.Content))
                    {
                        UserMessageShow(9, "");
                        return;
                    }
                    lblMsg.Visible = false;
                    try
                    {
                        if (_cmdBll.Add(cmd) >= 0)
                        {
                            UserMessageShow(2, "");
                        }
                        else
                        {
                            UserMessageShow(3, "");
                        }
                    }
                    catch { }
                }
            }
            if (deviceModel.IsBioDataSupport(BioType.VisilightFace))
            {
                List<TmpBioPhotoModel> biophotoList = _tmpBioPhotoBll.Get(pin, BioType.Comm.ToString("D")+","+BioType.VisilightFace.ToString("D"));
                //send upload biophoto commands
                foreach (TmpBioPhotoModel bioPhotoTmp in biophotoList)
                {
                    cmd.CommitTime = DateTime.Now;
                    cmd.Content = string.Format(Commands.Command_UpdateBioPhoto, bioPhotoTmp.Pin, bioPhotoTmp.Type,
                        bioPhotoTmp.Size, bioPhotoTmp.Content, "0", "","0");

                    if (string.IsNullOrEmpty(cmd.Content))
                    {
                        UserMessageShow(9, "");
                        return;
                    }
                    lblMsg.Visible = false;
                    try
                    {
                        if (_cmdBll.Add(cmd) >= 0)
                        {
                            UserMessageShow(2, "");
                        }
                        else
                        {
                            UserMessageShow(3, "");
                        }
                    }
                    catch { }
                }
            }

        }
        /// <summary>
        /// 下发用户掌静脉数据
        /// </summary>
        /// <param name="sn">设备序列号</param>
        /// <param name="pin">用户工号</param>
        private void uploadPalmTemplate(string sn,string pin)
        {
            DeviceModel deviceModel = new DeviceBll().Get(sn);

            DeviceCmdModel cmd = new DeviceCmdModel();
            cmd.DevSN = sn;
            if (deviceModel.IsBioDataSupport(BioType.Palm))
            {
                List<TmpBioDataModel> bioList = _tmpBioDataBll.Get(pin, BioType.Palm.ToString("D"));
                //send upload face commands
                foreach (TmpBioDataModel bioTmp in bioList)
                {
                    cmd.CommitTime = DateTime.Now;
                    cmd.Content = string.Format(Commands.Command_UpdateBioData, bioTmp.Pin, bioTmp.No,bioTmp.Index,bioTmp.Valid,
                        bioTmp.Duress, bioTmp.Type, bioTmp.MajorVer,bioTmp.MinorVer,bioTmp.Format,bioTmp.Tmp);

                    if (string.IsNullOrEmpty(cmd.Content))
                    {
                        UserMessageShow(9, "");
                        return;
                    }
                    lblMsg.Visible = false;
                    try
                    {
                        if (_cmdBll.Add(cmd) >= 0)
                        {
                            UserMessageShow(2, "");
                        }
                        else
                        {
                            UserMessageShow(3, "");
                        }
                    }
                    catch { }
                }
            }
            

        }
        /// <summary>
        /// 下发用户PhotoID到机器，图片转换成base64数据用于设置用户的photoID
        /// </summary>
        /// <param name="Imagefilename">图片文件名</param>
        /// <returns>图片64位字符串</returns>
        private string ImgToBase64String(string Imagefilename,out long imageSize)
        {
            string strbaser64 = "";
            try
            {
                Bitmap bmp = new Bitmap(Imagefilename);
                FileStream fs = new FileStream(Imagefilename + ".txt", FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);

                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                imageSize = ms.Length;
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                strbaser64 = Convert.ToBase64String(arr);
                sw.Write(strbaser64);

                sw.Close();
                fs.Close();
                return strbaser64;

            }
            catch (Exception ex)
            {
                MessageBox.Show("ImgToBase64String Error/nException:" + ex.Message);
                imageSize = 0;
                return strbaser64;
            }
        }

        /// <summary>
        /// 更新用户照片ID
        /// </summary>
        /// <param name="sn">设备序列号</param>
        /// <param name="pin">用户工号</param>
        private void uploadUserPhotoID(string sn,string pin)
        {
            string path = System.Environment.CurrentDirectory;
            string PathofImage = path;
            string strBase64 = "";

            path += "\\Photo\\" + pin + ".jpg";
            if (PathofImage != null && PathofImage != "")//本地目录有对应用户图像
            {
                if (!File.Exists(path))
                {
                    UserMessageShow(10,"");
                    return;
                }
                long imageSize = 0;
                strBase64 = ImgToBase64String(path,out imageSize);

                if (imageSize >= 50 * 1024)
                {
                    MessageBox.Show("please choice photo size less than 50Kb", "Error");
                }
                else
                {
                    DeviceCmdModel cmd = new DeviceCmdModel();
                    cmd.DevSN = sn;
                    cmd.CommitTime = DateTime.Now;
                    cmd.Content = string.Format(Commands.Command_UpdateUserPic, pin,
                        strBase64.Length.ToString(), strBase64);

                    if (string.IsNullOrEmpty(cmd.Content))
                    {
                        UserMessageShow(9, "");
                        return;
                    }
                    lblMsg.Visible = false;
                    try
                    {
                        if (_cmdBll.Add(cmd) >= 0)
                        {
                            UserMessageShow(2, "");
                        }
                        else
                        {
                            UserMessageShow(3, "");
                        }
                    }
                    catch { }
                }

            }
        }
        /// <summary>
        /// 删除按钮事件
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            GetCurSelectRows();
            if (_CurSelectRows.Count == 0)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Please select user item";
                return;
            }
            List<string> users = new List<string>();
            foreach (DataGridViewRow item in _CurSelectRows)
            {
                users.Add(item.Cells["colUserPin"].Value.ToString());
            }

            lblMsg.Visible = false;
           
            if (_bll.Delete(users) > 0)
            {
                LoadAllUsers();
                string basePath = System.Environment.CurrentDirectory;
                string path = string.Empty;
                foreach (var item in users)
                {
                    path = basePath + "\\Photo\\" + item + ".jpg";
                    if (File.Exists(path))
                        File.Delete(path);
                }
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
        /// 本地选择对应的照片作为当前用户的photoID
        /// </summary>
        private void btnOpenPic_Click(object sender, EventArgs e)
        {
            string strUserPicPath = "";

            if (txtPin.Text == "")
            {
                this.lblMsg.Visible = true;
                this.lblMsg.Text = "Please input user id.";
                return;
            }

            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Title = "选择要转换的图片";
            dlg.Filter = "JPEG Files (*.jpeg);*.jpeg;PNG Files (*.png);*.png;JPG Files (*.jpg)|*.jpg;|AllFiles (*.*)|*.*";
            if (DialogResult.OK == dlg.ShowDialog())
            {
                strUserPicPath = dlg.FileName;
                picUserPhoto.ImageLocation = strUserPicPath;
                using (FileStream image = new FileStream(strUserPicPath, FileMode.Open))
                {
                    picUserPhoto.Image = Image.FromStream(image);
                }
                picUserPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                this.picUserPhoto.Update();
            }
        }
        /// <summary>
        /// 更新界面提示信息
        /// </summary>
        /// <param name="msgindex">索引</param>
        /// <param name="userid">用户id</param>
        private void UserMessageShow(int msgindex, string userid)
        {
            lblMsg.Visible = true;
            lblMsg.Text = labMsg[msgindex] + userid;
        }
        #endregion
        #region 接收到设备上传数据，更新列表数据
        /// <summary>
        /// 更新9.0算法指纹模板数量
        /// </summary>
        /// <param name="fpver9">9.0算法指纹数据</param>
        public void UpdateUserFP9Info(TmpFPModel fpver9)
        {
            if (_dt.Select($"PIN='{fpver9.Pin}'").Length > 0)
            {
                DataRow dataRow = _dt.Select($"PIN='{fpver9.Pin}'")[0];
                dataRow["FP9Count"] = (Convert.ToInt32(dataRow["FP9Count"].ToString()) + 1).ToString();
                this.dgvUser.DataSource = _dt;
            }

        }
        /// <summary>
        /// 更新10.0算法指纹模板数量
        /// </summary>
        /// <param name="fpver10">10.0算法指纹数据</param>
        public void UpdateUserFP10Info(TmpFPModel fpver10)
        {
            if (_dt.Select($"PIN='{fpver10.Pin}'").Length > 0)
            {
                DataRow dataRow = _dt.Select($"PIN='{fpver10.Pin}'")[0];
                dataRow["FP10Count"] = (Convert.ToInt32(dataRow["FP10Count"].ToString()) + 1).ToString();
                this.dgvUser.DataSource = _dt;
            }
        }
        /// <summary>
        /// 更新人脸模板数量
        /// </summary>
        /// <param name="face">人脸模板数据</param>
        public void UpdateUserFaceInfo(dynamic face)
        {
            if (_dt.Select($"PIN='{face.Pin}'").Length > 0)
            {
                DataRow dataRow = _dt.Select($"PIN='{face.Pin}'")[0];
                dataRow["FaceCount"] = (Convert.ToInt32(dataRow["FaceCount"].ToString()) + 1).ToString();
                this.dgvUser.DataSource = _dt;
            }

        }
        /// <summary>
        /// 更新掌静脉模板数量
        /// </summary>
        /// <param name="face">人脸模板数据</param>
        public void UpdateUserPalmInfo(TmpBioDataModel palm)
        {
            if (_dt.Select($"PIN='{palm.Pin}'").Length > 0)
            {
                DataRow dataRow = _dt.Select($"PIN='{palm.Pin}'")[0];
                dataRow["PalmCount"] = (Convert.ToInt32(dataRow["PalmCount"].ToString()) + 1).ToString();
                this.dgvUser.DataSource = _dt;
            }

        }
        #endregion
        /// <summary>
        /// 选择GridView某一行，右侧展示当前选择行数据
        /// </summary>
        private void dgvUser_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            //Right-click to also select the row
            if (e.Button == MouseButtons.Right)
            {
                this.dgvUser.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
            }
            if (this.dgvUser.CurrentRow == null)
                return;
            SetCurUserInfo(dgvUser.CurrentRow);


        }
        /// <summary>
        /// 设置当前选择用户信息
        /// </summary>
        /// <param name="row"></param>
        private void SetCurUserInfo(DataGridViewRow row)
        {
            this.txtPin.Text = row.Cells["colUserPin"].Value.ToString();
            this.txtUserName.Text = row.Cells["colUserName"].Value.ToString();
            this.txtCard.Text = row.Cells["colCardNumber"].Value.ToString();
            this.txtPassword.Text = row.Cells["colPassword"].Value.ToString();
            this.cmbPrivilege.SelectedValue = row.Cells["colPrivilege"].Value.ToString();

            //显示对应用户的photoID
            {
                string path = System.Environment.CurrentDirectory;
                string PathofImage = path;

                path += "\\Photo\\" + row.Cells["colUserPin"].Value.ToString() + ".jpg";

                // Show Photo
                picUserPhoto.Image = picUserPhoto.ErrorImage;
                if (!string.IsNullOrEmpty(path))
                {
                    try
                    {
                        using (FileStream image = new FileStream(path, FileMode.Open))
                        {
                            picUserPhoto.Image = Image.FromStream(image);
                        }
                        picUserPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                        this.picUserPhoto.Update();
                    }
                    catch { }
                }
            }
        }
        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;

            if (dgvUser.Columns[e.ColumnIndex].Name != "cb_Select") return;

            DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)dgvUser.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell.Value != null && (bool)cell.Value)
            {
                cell.Value = false;
            }
            else
            {
                cell.Value = true;
            }
        }
        private void ch_OnCheckBoxClicked(object sender, DatagridviewCheckboxHeaderEventArgs e)
        {
            if (e.CheckedState&& dgvUser.Rows.Count>0)
            {
                SetCurUserInfo(dgvUser.Rows[0]);
            }
            foreach (DataGridViewRow dgvRow in this.dgvUser.Rows)
            {
                dgvRow.Cells[0].Value = e.CheckedState;
            }
        }
        private void dgvUser_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Index >= 0)
            {
                this.dgvUser.Rows[e.Row.Index].Cells["col_Index"].Value = e.Row.Index + 1;
            }
        }

    }

  

}