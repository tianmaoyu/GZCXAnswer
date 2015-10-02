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

namespace GZPIAnswer
{
    
    public partial class ShareForm : Form
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
        public ShareForm()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.TopMost = true;
        }
        string html = null;
        //bool shareIsSuccessed = false;
        int i = 0;
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            html = null;
            html = this.webBrowser2.DocumentText;
            html = html.Trim().Replace("\r\n", "");//除去空格和换行符
            try
            {
                HtmlDocument htmlDoc = webBrowser2.Document;
                HtmlElement btnElement = htmlDoc.All["postButton"];
                if (btnElement != null)
                {
                    btnElement.Click += new HtmlElementEventHandler(HtmlBtnClose_Click);
                }
                // btnElement.AttachEventHandler("subbtn", new EventHandler(HtmlBtnClose_Click)); 
            }
            catch (SystemException)
            {

            }
            foreach (HtmlElement archor in this.webBrowser2.Document.Links)
            {
                archor.SetAttribute("target", "_self");
            }

            //将所有的FORM的提交目标，指向本窗体
            foreach (HtmlElement form in this.webBrowser2.Document.Forms)
            {
                form.SetAttribute("target", "_self");
            }
        }
        public delegate void DelUserHandler(string url);

        public void NavigateUrl(string url)
        {
            if (this.webBrowser2.InvokeRequired)
            {
                DelUserHandler handler = new DelUserHandler(NavigateUrl);
                this.Invoke(handler, url);
            }
            else
            {
                this.webBrowser2.Navigate(url);

            }
        }
        private void Share_Load(object sender, EventArgs e)
        {
            //QQ空间分享
            try
            {
                string address = "http://sns.qzone.qq.com/cgi-bin/qzshare/cgi_qzshare_onekey?url= http%3A%2F%2F789.ucoz.com%2F&title=%e8%b4%b5%e5%b7%9e%e8%af%9a%e4%bf%a1%e7%ad%94%e9%a2%98%e5%8a%a9%e6%89%8b%e4%b8%8b%e8%bd%bd&desc=%e8%b4%b5%e5%b7%9e%e8%af%9a%e4%bf%a1%e7%ad%94%e9%a2%98%e5%8a%a9%e6%89%8b%ef%bc%81%e5%b8%ae%e4%bd%a0%e4%b8%80%e9%94%ae%e6%90%9e%e5%ae%9a%e8%af%95%e5%8d%b7%e3%80%82%e6%83%b3%e8%a6%81%e5%a4%9a%e5%b0%91%e5%88%86%e5%b0%b1%e7%ad%94%e5%a4%9a%e5%b0%91%e5%88%86%e3%80%82%e5%91%b5%e5%91%b5...NB%e5%90%a7!";
                //NavigateUrl(address);
              webBrowser2.Navigate(new Uri(address));
            }
            catch (System.UriFormatException)
            {
                MessageBox.Show("未知错误！请重试");
            }

        }
        private void HtmlBtnClose_Click(object sender, EventArgs e)
        {

            if (html.Contains("<divclass=\"layout_m mod_links\"id=\"login_btn_panel\"><a>"))
            {
                MessageBox.Show("O(∩_∩)O谢谢成功分享！");
            }
            else
            {
                MessageBox.Show("请先登录！");
                i++;
            }

        }
        public bool shareIsSuccessed()
        {
            if (i >= 2)
            {
                return true;
            }
            else
            {
                return false;
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
