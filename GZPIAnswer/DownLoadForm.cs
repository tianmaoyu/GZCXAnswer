using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Diagnostics;

namespace GZPIAnswer
{
    public partial class DownLoadForm : Form
    {
        const int WM_NCHITTEST = 0x0084;
        const int HT_LEFT = 10;
        const int HT_RIGHT = 11;
        const int HT_TOP = 12;
        const int HT_TOPLEFT = 13;
        const int HT_TOPRIGHT = 14;
        const int HT_BOTTOM = 15;
        const int HT_BOTTOMLEFT = 16;
        const int HT_BOTTOMRIGHT = 17;
        const int HT_CAPTION = 2;
        public event EventHandler GetValue;
        public string destFile;
        int i = 0;//传地址过来
        public List<string> sourceFiles = new List<string>();
        
        public DownLoadForm()
        {
            InitializeComponent();
            this.CenterToScreen();
            sourceFiles.Add("http://youqian.baidu.com/download/Baidusd.Setup.1.8.0.1255.youqian_1000043518.exe");
        }
        WebClient wc = new WebClient();
        public static int number = 0;
        public int getnumber()
        {
            return number;
        }
        private void startDown(int i)
        {

            string fileName = System.IO.Path.GetFileName(sourceFiles[i]);
            destFile = System.IO.Path.Combine(Environment.CurrentDirectory, fileName);
            label1.Text = String.Format("第[{0}]下载中.......", i + 1);
            fileDownloading(sourceFiles[i]);


        }
        private void fileDownloading(string sourceFile)
        {
            //string sourceFile = sourceFile;
            try
            {
                WebClient client = new WebClient();
                //进行异变下载
                //如果已经有这个文件了就把它给删掉
                client.DownloadFileAsync(new Uri(sourceFile), destFile);
                //绑定进度改变时的事件
                client.DownloadProgressChanged += client_DownloadProgressChanged;
                //绑定完成时事件
                client.DownloadFileCompleted += client_DownloadFileCompleted;
            }
            catch (WebException we)
            {
                MessageBox.Show(we.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 事件:WEBCIENT下载进度改变时触发的回调事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Action<DownloadProgressChangedEventArgs> onCompleted = progressChanging;
            onCompleted.Invoke(e);
        }

        /// <summary>
        /// 事件：WEBCLIENT下载完成时的回调事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Action<AsyncCompletedEventArgs> onCompleted = progressCompleted;
            onCompleted.Invoke(e);
        }

        /// <summary>
        /// 文件下载进度改变时触发
        /// </summary>
        /// <param name="de"></param>
        private void progressChanging(DownloadProgressChangedEventArgs de)
        {
            progressBar1.Value = de.ProgressPercentage;
            label2.Text = String.Format("{0}%", de.ProgressPercentage);
            this.label3.Text = String.Format("{0}M/{1}M", Math.Round((double)de.BytesReceived / 1024 / 1024, 2), Math.Round((double)de.TotalBytesToReceive / 1024 / 1024, 2));
        }


        /// <summary>
        /// 当文件下载完成时触发
        /// </summary>
        /// <param name="de"></param>
        private void progressCompleted(AsyncCompletedEventArgs de)
        {
            label1.Text = String.Format("第[{0}]下载完成", i + 1);
            //启动现在项
            //greatlog.WriteToSecretLog("分数:10");
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = Environment.CurrentDirectory + "\\" + System.IO.Path.GetFileName(sourceFiles[i]);
            myProcess.StartInfo.Verb = "Open";
            myProcess.StartInfo.CreateNoWindow = true;
            myProcess.Start();
            //下一个System.IO.Path.GetFileName(sourceFiles[i])
            if (i < sourceFiles.Count - 1)
            {
                i++;
                startDown(i);
            }
            else
            {
                number = sourceFiles.Count;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }

        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            this.Refresh();
            setWindowRegion();
        }
        private void setWindowRegion()
        {
            System.Drawing.Drawing2D.GraphicsPath FormPath;
            FormPath = new System.Drawing.Drawing2D.GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            FormPath = GetRoundedRectPath(rect, 10);
            this.Region = new Region(FormPath);
        }
        private System.Drawing.Drawing2D.GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

            // 左上角
            path.AddArc(arcRect, 180, 90);

            // 右上角
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);

            // 右下角
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);

            // 左下角
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();//闭合曲线
            return path;
        }
        protected override void WndProc(ref Message Msg)
        {
            if (Msg.Msg == WM_NCHITTEST)
            {
                //获取鼠标位置
                int nPosX = (Msg.LParam.ToInt32() & 65535);
                int nPosY = (Msg.LParam.ToInt32() >> 16);
                //右下角
                if (nPosX >= this.Right - 6 && nPosY >= this.Bottom - 6)
                {
                    Msg.Result = new IntPtr(HT_BOTTOMRIGHT);
                    return;
                }
                //左上角
                else if (nPosX <= this.Left + 6 && nPosY <= this.Top + 6)
                {
                    Msg.Result = new IntPtr(HT_TOPLEFT);
                    return;
                }
                //左下角
                else if (nPosX <= this.Left + 6 && nPosY >= this.Bottom - 6)
                {
                    Msg.Result = new IntPtr(HT_BOTTOMLEFT);
                    return;
                }
                //右上角
                else if (nPosX >= this.Right - 6 && nPosY <= this.Top + 6)
                {
                    Msg.Result = new IntPtr(HT_TOPRIGHT);
                    return;
                }
                else if (nPosX >= this.Right - 2)
                {
                    Msg.Result = new IntPtr(HT_RIGHT);
                    return;
                }
                else if (nPosY >= this.Bottom - 2)
                {
                    Msg.Result = new IntPtr(HT_BOTTOM);
                    return;
                }
                else if (nPosX <= this.Left + 2)
                {
                    Msg.Result = new IntPtr(HT_LEFT);
                    return;
                }
                else if (nPosY <= this.Top + 2)
                {
                    Msg.Result = new IntPtr(HT_TOP);
                    return;
                }
                else
                {
                    Msg.Result = new IntPtr(HT_CAPTION);
                    return;
                }
            }
            base.WndProc(ref Msg);
        }

        private void DownLoadForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (GetValue != null)
            {
                string s = "下载成功";//假如这个就是要传的值
                GetValue(s, e);
            }
        }
    }
}
