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
    public partial class MessageBoxForm : Form
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
        //
        public event EventHandler GetValue;
        //
        string message = "错误";
        string message_1 = "是否现在答题？请点击右下角的：一键答题";
        string message_2 = "请下载一个软件才能继续哦：是否下载[百度杀毒]";
        string message_3 = "请下载一个软件才能继续哦：是否下载[百度浏览器]";
        string message_start = "请登录你的账号";
        //this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
        //this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel; 
        public MessageBoxForm(string _message,bool showPictrue=false)
        {
           
            InitializeComponent();
            this.CenterToScreen();
            message = _message;
            this.TopMost = true;
           
            if (showPictrue)
            {
                this.pictureBox1.Visible = true;
                this.useGuide.Enabled = true;
                this.useGuide.Visible = true;
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
        //关闭窗口
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //确定
        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        //退出
        private void button2_Click(object sender, EventArgs e)
        {
            //this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        //关闭时传值
        private void MessageBoxForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (GetValue != null)
            {
                if(message==message_start)
                {
                      string s = "准备进入";//假如这个就是要传的值
                      GetValue(s, e);
                }
                if (message == message_1)
                {
                    string s = "准备答题";//假如这个就是要传的值
                    GetValue(s, e);
                }
                if (message == message_2)
                {
                    string s = "准备下载";//假如这个就是要传的值
                    GetValue(s, e);
                }
                else
                {
                    //string s = "错误";
                    //GetValue(s, e);
                }

              
               
            }
        }

        private void MessageBoxForm_Load(object sender, EventArgs e)
        {
            this.tb_message_string.Text = message;

         }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void useGuide_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://119.23.48.137/");
        }
    }
}
