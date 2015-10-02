using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GZPIAnswer
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.labelloging.Hide();
            this.progressBar1.Hide();
        }

        public static string name;
        public static string passWrod;
        public event EventHandler GetName;
        public event EventHandler GetPassWord;

        private void textBoxname_TextChanged(object sender, EventArgs e)
        {

        }

        private void VIPLoginToData_Click(object sender, EventArgs e)
        {
            this.label1.Hide();
            this.label_Name.Hide();
            this.textBoxPassWord.Hide();
            this.textBoxname.Hide();
            this.buttonLONG.Hide();
            this.labelloging.Show();
            this.progressBar1.Show();

            name = this.textBoxname.Text;
            passWrod = this.textBoxPassWord.Text;
            this.buttonLONG.DialogResult = System.Windows.Forms.DialogResult.OK;
           

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
           
                GetName(name,e);
                GetPassWord(passWrod, e);
        }
        
    }
}
