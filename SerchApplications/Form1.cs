using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SerchApplications
{
    public partial class Form1 : Form
    {
        List<string> apps = new List<string>();
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string baseID = FingerPrint.baseId();//主板编号
            string biosID = FingerPrint.biosId();//BIOS编号
            string cpuID = FingerPrint.cpuId();//CPU编号
            string diskID = FingerPrint.diskId();//磁盘编号
            string macID = FingerPrint.macId();//MAC地址
            string videoID = FingerPrint.videoId();//显卡编号

            StringBuilder info = new StringBuilder();
            info.AppendLine("主板编号:\r\n" + baseID);
            info.AppendLine("");
            info.AppendLine("BIOS编号:\r\n" + biosID);
            info.AppendLine("");
            info.AppendLine("CPU编号:\r\n" + cpuID);
            info.AppendLine("");
            info.AppendLine("磁盘编号:\r\n" + diskID);
            info.AppendLine("");
            info.AppendLine("MAC地址:\r\n" + macID);
            info.AppendLine("");
            info.AppendLine("显卡编号:\r\n" + videoID);

            tbHardInfo.Text = info.ToString();
        }

        void SerchApps()
        {
            apps.Clear();
            tbSoftList.Text = "";
            button1.Enabled = false;

            string temp = null, tempType = null;
            object displayName = null, uninstallString = null, releaseType = null;
            RegistryKey currentKey = null;
            RegistryKey pregkey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall");//获取指定路径下的键
            try
            {
                foreach (string item in pregkey.GetSubKeyNames())               //循环所有子键
                {
                    currentKey = pregkey.OpenSubKey(item);
                    displayName = currentKey.GetValue("DisplayName");           //获取显示名称
                    uninstallString = currentKey.GetValue("UninstallString");   //获取卸载字符串路径
                    releaseType = currentKey.GetValue("ReleaseType");           //发行类型,值是Security Update为安全更新,Update为更新
                    bool isSecurityUpdate = false;
                    if (releaseType != null)
                    {
                        tempType = releaseType.ToString();
                        if (tempType == "Security Update" || tempType == "Update")
                            isSecurityUpdate = true;
                    }
                    if (!isSecurityUpdate && displayName != null && uninstallString != null)
                    {
                        apps.Add(displayName.ToString());
                        temp += displayName.ToString() + Environment.NewLine;
                    }
                }
            }
            catch (Exception E)
            {
                tbSoftList.Text = E.Message.ToString();
            }
            tbSoftList.Text = "共有软件" + apps.Count + "个" + Environment.NewLine + temp;
            pregkey.Close();
        }

        /// <summary>
        /// 上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string bumen = cb_bumen.Text.Trim();//部门
            if (bumen.Length == 0)
            {
                MessageBox.Show("部门名称不能为空,请填写真实的部门名称.");
                cb_bumen.Focus();
            }

            string xingming = tb_xingming.Text.Trim();//姓名
            if (xingming.Length == 0)
            {
                MessageBox.Show("姓名不能为空,请填写真实的姓名.");
                tb_xingming.Focus();
            }

            string macID = FingerPrint.macId();

            //上传软件列表
            UploadSoftList(macID, bumen, xingming);

            MessageBox.Show(bumen + "-" + xingming + ",上传成功[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]");
        }

        private void UploadHardware(string bumen, string xingming)
        {
            string baseID = FingerPrint.baseId();//主板编号
            string biosID = FingerPrint.biosId();//BIOS编号
            string cpuID = FingerPrint.cpuId();//CPU编号
            string diskID = FingerPrint.diskId();//磁盘编号
            string macID = FingerPrint.macId();//MAC地址
            string videoID = FingerPrint.videoId();//显卡编号

            string sql = "insert into hardware (bumen,xingming,baseid,biosid,cpuid,diskid,macid,videoid) values ('" + bumen + "','" + xingming + "','" + baseID + "','" + biosID +
                "','" + cpuID + "','" + diskID + "','" + macID + "','" + videoID + "')";
            try
            {
                MySqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql);
            }
            catch (Exception ee)
            {

            }
        }

        /// <summary>
        /// 上传软件列表
        /// </summary>
        /// <param name="macID"></param>
        /// <param name="bumen"></param>
        /// <param name="xingming"></param>
        private void UploadSoftList(string macID, string bumen, string xingming)
        {
            bool isUpload = false;
            try
            {
                isUpload = IsUpload(macID);
            }
            catch (Exception ee)
            {
                MessageBox.Show("检查是否上传时遇到错误(请拍照给行政部李成东,或发QQ公司群内):" + ee.Message);
                return;
            }

            if (isUpload == true)
            {
                MessageBox.Show("本机器内的软件列表已上传,不用重复上传.");
                return;
            }

            try
            {
                //上传机器信息
                UploadHardware(bumen, xingming);
            }
            catch(Exception ex)
            {

            }

            foreach (var item in apps)
            {
                string sql = "insert into apps (cpuid,appname,bumen,xingming) values ('" + macID + "','" + item + "','" + bumen + "','" + xingming + "')";
                try
                {
                    MySqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql);
                }
                catch (Exception ee)
                {
                    MessageBox.Show("软件名称上传时遇到错误(请拍照给行政部李成东,或发QQ公司群内):" + ee.Message);
                }
            }
        }

        /// <summary>
        /// 是否已经上传
        /// </summary>
        /// <param name="cpuid"></param>
        private bool IsUpload(string cpuid)
        {
            DataSet ds = MySqlHelper.GetDataSet(MySqlHelper.Conn, System.Data.CommandType.Text, "select count(*) from apps where cpuid='" + cpuid + "'");
            if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows != null && ds.Tables[0].Rows.Count > 0)
            {
                var countStr = ds.Tables[0].Rows[0][0].ToString();
                uint count = uint.Parse(countStr);
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 识别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            SerchApps();
            if (apps.Count > 0)
            {
                button1.Enabled = true;
                button2.Enabled = false;
            }
        }
    }
}
