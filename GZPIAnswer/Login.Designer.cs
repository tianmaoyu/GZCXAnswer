namespace GZPIAnswer
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.buttonLONG = new System.Windows.Forms.Button();
            this.textBoxPassWord = new System.Windows.Forms.TextBox();
            this.textBoxname = new System.Windows.Forms.TextBox();
            this.label_Name = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelloging = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonLONG
            // 
            this.buttonLONG.Location = new System.Drawing.Point(122, 182);
            this.buttonLONG.Name = "buttonLONG";
            this.buttonLONG.Size = new System.Drawing.Size(110, 33);
            this.buttonLONG.TabIndex = 7;
            this.buttonLONG.Text = "登 录";
            this.buttonLONG.UseVisualStyleBackColor = true;
            this.buttonLONG.Click += new System.EventHandler(this.VIPLoginToData_Click);
            // 
            // textBoxPassWord
            // 
            this.textBoxPassWord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPassWord.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBoxPassWord.Location = new System.Drawing.Point(104, 116);
            this.textBoxPassWord.Name = "textBoxPassWord";
            this.textBoxPassWord.PasswordChar = '*';
            this.textBoxPassWord.Size = new System.Drawing.Size(161, 21);
            this.textBoxPassWord.TabIndex = 5;
            // 
            // textBoxname
            // 
            this.textBoxname.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxname.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBoxname.Location = new System.Drawing.Point(104, 60);
            this.textBoxname.Name = "textBoxname";
            this.textBoxname.Size = new System.Drawing.Size(161, 21);
            this.textBoxname.TabIndex = 6;
            this.textBoxname.TextChanged += new System.EventHandler(this.textBoxname_TextChanged);
            // 
            // label_Name
            // 
            this.label_Name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Name.AutoSize = true;
            this.label_Name.BackColor = System.Drawing.Color.Transparent;
            this.label_Name.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Name.ForeColor = System.Drawing.Color.Black;
            this.label_Name.Location = new System.Drawing.Point(31, 62);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(53, 16);
            this.label_Name.TabIndex = 18;
            this.label_Name.Text = "用户名";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(36, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "密  码";
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.progressBar1.Location = new System.Drawing.Point(39, 87);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(232, 23);
            this.progressBar1.TabIndex = 20;
            this.progressBar1.Value = 50;
            this.progressBar1.Visible = false;
            // 
            // labelloging
            // 
            this.labelloging.AutoSize = true;
            this.labelloging.Location = new System.Drawing.Point(129, 66);
            this.labelloging.Name = "labelloging";
            this.labelloging.Size = new System.Drawing.Size(89, 12);
            this.labelloging.TabIndex = 21;
            this.labelloging.Text = "登录中........";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 263);
            this.Controls.Add(this.labelloging);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_Name);
            this.Controls.Add(this.buttonLONG);
            this.Controls.Add(this.textBoxPassWord);
            this.Controls.Add(this.textBoxname);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "请登录";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLONG;
        private System.Windows.Forms.TextBox textBoxPassWord;
        private System.Windows.Forms.TextBox textBoxname;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelloging;

    }
}