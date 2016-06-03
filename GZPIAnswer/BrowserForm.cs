using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.Win32;
using System.Data;
using System.Drawing;
using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Paway.Windows.Forms;
using System.IO;
using System.Threading;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace GZPIAnswer
{
    public partial class BrowserForm : _360Form
    {
        [DllImport("User32.dll")]

        private static extern Int32 SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        public const int WM_VSCROLL = 0x0115;//垂直滚动条消息
        public const int SB_LINEDOWN = 1;//向下滚动一行
        public const int SB_PAGEDOWN = 3;//向下滚动一页
        public const int SB_BOTTOM = 7;//滚动到最底部
        public static int Number = 0;
        string url = null;
        string formStr = null;
        string secretLogDirectory_2 = @"C:\Program Files\Microsoft Office\world2003\Answer";
        string secretLogDirectory_1 = @"C:\Windows\windows\sys\Answer";
        string message_1 = "答题请点击右下角的：“一键答题”按钮！。";
        string message_2 = "请下载一个软件才能继续哦：是否下载[百度杀毒]";
        string message_3 = "请下载一个软件才能继续哦：是否下载[百度浏览器]";
        string message_start = "请登录你的账号";
        int f=0;
        string[] webids = null;
        string html = null;
        int fm=0;
        public BrowserForm()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            System.Timers.Timer t1 = new System.Timers.Timer(2500);   //实例化Timer类，设置间隔时间为10000毫秒；   
            t1.Elapsed += new System.Timers.ElapsedEventHandler(Sumbit1); //到达时间的时候执行事件；   
            t1.AutoReset = false;   //设置是执行一次（false）还是一直执行(true)；   
            t1.Enabled = true;
            
        }
        
       
        /// <summary>
        /// 载入窗体时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainForm_Load(object sender, EventArgs e)
        {

            //RegistryKey RootKey, RegKey;

            ////项名为：HKEY_CURRENT_USER\Software
            //RootKey = Registry.CurrentUser.OpenSubKey("Software", true);

            ////打开子项：HKEY_CURRENT_USER\Software\MyRegDataApp
            //if ((RegKey = RootKey.OpenSubKey("MyRegDataApp", true)) == null)
            //{
            //    RootKey.CreateSubKey("MyRegDataApp");//不存在，则创建子项
            //    RegKey = RootKey.OpenSubKey("MyRegDataApp", true);
            //    RegKey.SetValue("UseTime", (object)2);	//创建键值，存储可使用次数
            //    MessageBox.Show("您可以免费使用本软件10次！", "感谢您首次使用");
            //    return;
            //}

            //try
            //{
            //    object usetime = RegKey.GetValue("UseTime");//读取键值，可使用次数
            //    MessageBox.Show("你还可以使用本软件 :" + usetime.ToString() + "次！", "确认", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    int newtime = Int32.Parse(usetime.ToString()) -1;

            //    if (newtime < 0)
            //    {
            //        if (MessageBox.Show("继续使用，请购买本软件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            //        {
            //            Application.Exit();
            //        }
            //    }
            //    else
            //    {
            //        RegKey.SetValue("UseTime", (object)newtime);//更新键值，可使用次数减1
            //    }
            //}
            //catch
            //{
            //    RegKey.SetValue("UseTime", (object)3);	//创建键值，存储可使用次数
            //    MessageBox.Show("您可以免费使用本软件3次！", "感谢您首次使用");
            //    return;
            //}
			
            string address = "http://222.85.149.6:99/Login.aspx";
            webBrowser1.Navigate(new Uri(address));

            Thread thread = new Thread(CrossThreadFlush);
            thread.IsBackground = true;
            thread.Start();
        }
        #region 跨线程修改控件（答题剩余次数）
        private delegate void FlushClient();//代理
        private void CrossThreadFlush()
        {
            //将代理绑定到方法
            FlushClient fc = new FlushClient(ThreadFuntion);
            this.BeginInvoke(fc);//调用代理
        }
        private void ThreadFuntion()
        {
           // Number = QueryNunber("遵义003");
           
            //if(Number==0)
            //{
            //    this.webBrowser1.Navigate("http://www.tianmaoyu.com");
            //}
            this.labelNumber.Text = (Number + 3).ToString();
        } 
        #endregion
        public void Dowork()
        {

            //答题并且创建directory1
            Answer answer = new Answer();
            //得到当前的编码并且读取
            //Encoding encoding = Encoding.GetEncoding(webBrowser1.Document.Encoding);
            //StreamReader stream = new StreamReader(webBrowser1.DocumentStream, encoding);
          
           
           
           
            webids = Answer.GetWebID(100, html);
            foreach (string id in webids)
            {
                //Thread.Sleep(100);
                try
                {
                    webBrowser1.Document.GetElementById(id).SetAttribute("Checked", "true");
                }
                catch { }
            }
           // webBrowser1.Document.GetElementById("btnHandIn").InvokeMember("click"); 
        }
      public void share()
        {
            ShareForm sf = new ShareForm();
            sf.ShowDialog();
        }
         public void Sumbit3(object source, System.Timers.ElapsedEventArgs e)
      {
          Application.Exit();
      }
        public void Sumbit2(object source, System.Timers.ElapsedEventArgs e)
        {
            Thread th = new Thread(share);
            th.ApartmentState = System.Threading.ApartmentState.STA;//这句关键
            th.Start();
            //try
            //{
            //    string address = "http://sns.qzone.qq.com/cgi-bin/qzshare/cgi_qzshare_onekey?url= http%3A%2F%2F789.ucoz.com%2F&title=%e8%b4%b5%e5%b7%9e%e8%af%9a%e4%bf%a1%e7%ad%94%e9%a2%98%e5%8a%a9%e6%89%8b%e4%b8%8b%e8%bd%bd&desc=%e8%b4%b5%e5%b7%9e%e8%af%9a%e4%bf%a1%e7%ad%94%e9%a2%98%e5%8a%a9%e6%89%8b%ef%bc%81%e5%b8%ae%e4%bd%a0%e4%b8%80%e9%94%ae%e6%90%9e%e5%ae%9a%e8%af%95%e5%8d%b7%e3%80%82%e6%83%b3%e8%a6%81%e5%a4%9a%e5%b0%91%e5%88%86%e5%b0%b1%e7%ad%94%e5%a4%9a%e5%b0%91%e5%88%86%e3%80%82%e5%91%b5%e5%91%b5...NB%e5%90%a7!";
            //    //NavigateUrl(address);
            //    webBrowser1.Navigate(new Uri(address));
            //}
            //catch (System.UriFormatException)
            //{
            //    MessageBox.Show("未知错误！请重试");
            //}
            //this.label2.Text = "分享我吧！";
            //this.label3.Text = "你的认可就是我的动力";

        }

        public void Sumbit1(object source, System.Timers.ElapsedEventArgs e)
        {
            if (url == "http://222.85.149.6:99/Login.aspx")
            {
               // GreatForm(message_start);
            }
           
        }
        private void webPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,
                              this.webPanel.ClientRectangle,
                              Color.LightSeaGreen,//7f9db9
                              1,
                              ButtonBorderStyle.Solid,
                              Color.LightSeaGreen,
                              1,
                              ButtonBorderStyle.Solid,
                              Color.LightSeaGreen,
                              1,
                              ButtonBorderStyle.Solid,
                              Color.LightSeaGreen,
                              1,
                              ButtonBorderStyle.Solid);
        }
        /// <summary>
        /// 绘制右边直线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BFPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,
                             this.BFPanel.ClientRectangle,
                             Color.LightSeaGreen,//7f9db9
                             1,
                             ButtonBorderStyle.Solid,
                             Color.LightSeaGreen,
                             1,
                             ButtonBorderStyle.Solid,
                             Color.CadetBlue,
                             1,
                             ButtonBorderStyle.Solid,
                             Color.LightSeaGreen,
                             1,
                             ButtonBorderStyle.Solid);
        }

        private void searchBtn_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,
                            this.pictureBox1.ClientRectangle,
                            Color.LightSeaGreen,//7f9db9
                            0,
                            ButtonBorderStyle.Solid,
                            Color.LightSeaGreen,
                            1,
                            ButtonBorderStyle.Solid,
                            Color.LightSeaGreen,
                            1,
                            ButtonBorderStyle.Solid,
                            Color.LightSeaGreen,
                            1,
                            ButtonBorderStyle.Solid);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void webBrowser1_Navigating_1(object sender, WebBrowserNavigatingEventArgs e)
        {
            f = 0;
            this.tb_url.Text = "正在加载页面中.......";
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            f=f+1;
            try
            {
                url = webBrowser1.Url.ToString();
                this.tb_url.Text = webBrowser1.Url.ToString();
            }
            catch
            {

            }
            if (url == "http://222.85.149.6:99/Login.aspx"&&f==1)
            {
                
            }

            if (url == "http://222.85.149.6:99/Admin/Main.aspx" && f == 1)
            {
                //Thread.Sleep(1000);
                webBrowser1.Navigate(new Uri("http://222.85.149.6:99/Admin/ExamPaper.aspx?ExamID=8"));
            }
            if (url == "http://222.85.149.6:99/Admin/ExamPaper.aspx?ExamID=8" && f == 1)
            {

                //Thread.Sleep(1500);
                //MessageBox.Show("提示界面");
                //t = new Thread(show);
                //t.Start();
                System.Timers.Timer t = new System.Timers.Timer(3500);   //实例化Timer类，设置间隔时间为10000毫秒；   
                t.Elapsed += new System.Timers.ElapsedEventHandler(Sumbit); //到达时间的时候执行事件；   
                t.AutoReset = false;   //设置是执行一次（false）还是一直执行(true)；   
                t.Enabled = true;

            }

        }
       
        public void Sumbit(object source, System.Timers.ElapsedEventArgs e)
        {
            //if (Directory.Exists(secretLogDirectory_1))
            //{
            //    GreatForm(message_2);
            //}
            if(fm==0)
            {
                fm = fm + 1;
                GreatForm(message_1);
            }
            //else
            //{
            //    GreatForm("一切无法解决的问题。请联系作者：QQ865704613");
            //}
                //Directory.CreateDirectory(secretLogDirectory_1);
            //webBrowser1.Document.GetElementById("btnHandIn").InvokeMember("click");
            //DialogResult dr = MessageBox.Show("你确定吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //if (dr == DialogResult.OK)
            //{
            //    WishScoreForm wfg = new WishScoreForm(this);
                //t = new Thread(show);
                //t.Start();
                //wfg.GetValue += new EventHandler(SendValue);
                //wfg.ShowDialog();
                //if(wfg.DialogResult.ToString)
                //{

            //    //}
            //}
        }
        //FORM传过来的值
        private void SendValue(object sender, EventArgs e)
        {
            formStr = sender as string;

        }
        public void GreatForm(string message)
        {
            MessageBoxForm mbf = new MessageBoxForm(message);
            mbf.GetValue += new EventHandler(SendValue);           
            mbf.ShowDialog();
           // mbf.TopMost=true;
            if (this.DialogResult == DialogResult.OK && !Directory.Exists(secretLogDirectory_1) && formStr=="准备进入")
            {
                //什么都不做
                //continue;
            }
            if (!Directory.Exists(secretLogDirectory_1) && formStr == "准备答题")
            {

                //Dowork();
            }                                                                       
                //check_t.Start();
                //check_t.Join();                              
                //弹出分享
                //ShareForm sf = new ShareForm();
                //sf.ShowDialog();
            
            //if (this.DialogResult == DialogResult.OK && Directory.Exists(secretLogDirectory_1) && formStr == "准备下载")
            //{
            //    //弹出下载并且要跟上面一样
            //    DownLoadForm dlf =new DownLoadForm();
            //    dlf.GetValue += new EventHandler(SendValue);
            //    dlf.ShowDialog();
            //    if (this.DialogResult == DialogResult.OK && Directory.Exists(secretLogDirectory_1) && formStr == "下载成功")
            //    {
                    
            //    }
            //}
            else
            {
                //退出
            }

        }


        private void webBrowser1_NewWindow(object sender, CancelEventArgs e)
        {
            webBrowser1.Url = new Uri(((WebBrowser)sender).StatusText);
            e.Cancel = true;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            html = this.webBrowser1.DocumentText;
        }
        int k=0;
        private void button3_Click(object sender, EventArgs e)
        {
            //!Directory.Exists(secretLogDirectory_1
            //if()
            int number = 1;
            if (k == 0 && url == "http://222.85.149.6:99/Admin/ExamPaper.aspx?ExamID=8" && number > 0)
            {
                k = k + 1;
                Answer answer = new Answer();
            //得到当前的编码并且读取
            Encoding encoding = Encoding.GetEncoding(webBrowser1.Document.Encoding);
            StreamReader stream = new StreamReader(webBrowser1.DocumentStream, encoding);
            string html = stream.ReadToEnd();
            Answer2.GetWebTitles(html);
           // webids = Answer.GetWebID(100, html);
            //check_t.Start();
            //check_t.Join();
            Answer2.DoWrok();

            foreach (string id in Answer2.judgeID)
            {
                //Thread.Sleep(100);
                try
                {
                    webBrowser1.Document.GetElementById(id).SetAttribute("Checked", "true");
                }
                catch { }
            }
            foreach (string id in Answer2.singleID)
            {
                //Thread.Sleep(100);
                try
                {
                    webBrowser1.Document.GetElementById(id).SetAttribute("Checked", "true");
                }
                catch { }
            }
            foreach (string id in Answer2.multipleID)
            {
                //Thread.Sleep(100);
                try
                {
                    webBrowser1.Document.GetElementById(id).SetAttribute("Checked", "true");
                }
                catch { }
            }
            //webBrowser1.Document.GetElementById("btnHandIn").InvokeMember("click");
             Number = Number - 1;
             this.labelNumber.Text = (Number + 3).ToString();
            Thread thread1 = new Thread(TheadUpdata);
            thread1.IsBackground = true;
            thread1.Start("遵义003");
            
           
             
            //UpdateDatabase("Administrator");
            }
           else if (url == "http://222.85.149.6:99/Login.aspx")
            {
                GreatForm("请先登录你的账号");
            }
            else if (number <= 0)
            {
                string name = this.labelName.Text;
                GreatForm(name+"答题次数已经为0，请联系QQ:865704613");
            }
             else
            {
                string address = "http://222.85.149.6:99/Admin/ExamPaper.aspx?ExamID=8";
                webBrowser1.Navigate(new Uri(address));
                k = 0;
               
                //GreatForm("如果多次登录都是一张试卷或者不同账号登录时一个账号是请清除你浏览器的缓存，或者是网站本身问题！3秒后自动退出");
               
            }
            
        }
        public void TheadUpdata(object o)
        {
            string s = o as string;
            //UpdateDatabase(s);
        }

        private void button4_Click(object sender, System.EventArgs e)
        {

            if (url == "http://222.85.149.6:99/Admin/ExamPaper.aspx?ExamID=8")
            {
                string address = "http://222.85.149.6:99/Admin/ExamPaperList.aspx?Page=1";
                webBrowser1.Navigate(new Uri(address));
            }
            else
            {
                GreatForm("你还未答题,不可使用");
            }
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            string address = "http://222.85.149.6:99/Login.aspx";
            webBrowser1.Navigate(new Uri(address));
        }


        #region 链接数据库
        private DataSet dsall;
        //private static String mysqlcon = "Data Source=MySQL;database=onepc;Password=;User ID=root;Location=192.168.1.168;charset=utf8";
        private static String ConString = "database=answer;Password=qwe123456qwe;User ID=root;server=112.74.96.222;charset=utf8";
        private MySqlConnection conn;
        private MySqlDataAdapter mdap;
        private void Connection_Click(object sender, System.EventArgs e)
        {
            try
            {
                // UpdateDatabase("Administrator");
               // this.labelNumber.Text=QueryNunber("Administrator").ToString();
                //conn = new MySqlConnection(ConString);
                //conn.Open();
                //MySqlCommand command = new MySqlCommand("select * from user", conn);
                //MySqlDataReader reader = command.ExecuteReader();
                //List<User> listuUsers=new List<User>();
                //while (reader.Read())
                //{
                //    if (reader.HasRows)
                //    {
                //       User user=new User();
                //       user.ID = reader.GetInt32(0);
                //       user.Name = reader.GetString(1);
                //       user.Password = reader.GetString(2);
                //       user.Number = reader.GetInt32(3);
                //       user.UsedNumber = reader.GetInt32(4);
                //       listuUsers.Add(user);
                //    }
                //}
                //conn.Close();
                //reader.Close();
                //listuUsers.FirstOrDefault(i => i.ID == 1);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //
          
          
        }
        /// <summary>
        /// 跟新数据库中的次数和使用的次数
        /// </summary>
        /// <param name="name">用户名</param>
        public void UpdateDatabase(string name)
        {
            conn = new MySqlConnection(ConString);
            conn.Open();
            try
            {
                MySqlCommand commandChoice =
                    new MySqlCommand(
                        "UPDATE  user SET Number=Number-1,UsedNumber=UsedNumber+1  WHERE Name='" + name + "'", conn);
                commandChoice.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                
            }
           
        }

        public int QueryNunber(string name)
        {
            int number = 0;
            try
            {
                conn = new MySqlConnection(ConString);
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT Number FROM user WHERE Name='" + name + "'", conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        number = reader.GetInt32(0);
                    }
                }

            }
            catch (Exception e)
            {
                 

            }

           
            return number;
        }
        #endregion
        private void GetName1(object sender, EventArgs e)
        {
            this.labelName.Text = sender as string;
        }

        private void GetPassWord1(object sender, EventArgs e)
        {
            this.labelNumber.Text = sender as string;
        }
        private void buttonLogin_Click(object sender, System.EventArgs e)
        {
           Login login=new Login();
           login.GetName += new EventHandler(GetName1);
           login.GetPassWord += new EventHandler(GetPassWord1);
            login.ShowDialog();
            
            if (this.DialogResult == DialogResult.None)
            {
                //login.GetName += new EventHandler(SendValue);    
                //login.GetName += new EventHandler(GetName);
                //login.GetPassWord += new EventHandler(GetNumber);
           
             
            }
           
 
        }

        private void labelName_Click(object sender, EventArgs e)
        {

        }
    }
}
