namespace GraduateProject
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
            this.LabName = new System.Windows.Forms.Label();
            this.LabPwd = new System.Windows.Forms.Label();
            this.UName = new System.Windows.Forms.TextBox();
            this.UPwd = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnEixt = new System.Windows.Forms.Button();
            this.btnPwdchange = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabName
            // 
            this.LabName.AutoSize = true;
            this.LabName.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabName.Location = new System.Drawing.Point(80, 60);
            this.LabName.Name = "LabName";
            this.LabName.Size = new System.Drawing.Size(104, 20);
            this.LabName.TabIndex = 0;
            this.LabName.Text = "用户名称:";
            this.LabName.Click += new System.EventHandler(this.label1_Click);
            // 
            // LabPwd
            // 
            this.LabPwd.AutoSize = true;
            this.LabPwd.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabPwd.Location = new System.Drawing.Point(80, 123);
            this.LabPwd.Name = "LabPwd";
            this.LabPwd.Size = new System.Drawing.Size(104, 20);
            this.LabPwd.TabIndex = 1;
            this.LabPwd.Text = "用户密码:";
            this.LabPwd.Click += new System.EventHandler(this.UserPassword_Click);
            // 
            // UName
            // 
            this.UName.Location = new System.Drawing.Point(184, 64);
            this.UName.Name = "UName";
            this.UName.Size = new System.Drawing.Size(228, 21);
            this.UName.TabIndex = 3;
            // 
            // UPwd
            // 
            this.UPwd.Location = new System.Drawing.Point(184, 122);
            this.UPwd.Name = "UPwd";
            this.UPwd.Size = new System.Drawing.Size(228, 21);
            this.UPwd.TabIndex = 4;
            this.UPwd.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.Control;
            this.btnLogin.Location = new System.Drawing.Point(84, 200);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(89, 38);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "登录 (&L)";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            this.btnLogin.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.btnLogin_ControlAdded);
            this.btnLogin.Enter += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnEixt
            // 
            this.btnEixt.BackColor = System.Drawing.SystemColors.Control;
            this.btnEixt.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnEixt.Location = new System.Drawing.Point(203, 200);
            this.btnEixt.Name = "btnEixt";
            this.btnEixt.Size = new System.Drawing.Size(89, 38);
            this.btnEixt.TabIndex = 6;
            this.btnEixt.Text = "退出(&L)";
            this.btnEixt.UseVisualStyleBackColor = false;
            this.btnEixt.Click += new System.EventHandler(this.btnEixt_Click);
            // 
            // btnPwdchange
            // 
            this.btnPwdchange.BackColor = System.Drawing.SystemColors.Control;
            this.btnPwdchange.Location = new System.Drawing.Point(322, 200);
            this.btnPwdchange.Name = "btnPwdchange";
            this.btnPwdchange.Size = new System.Drawing.Size(89, 38);
            this.btnPwdchange.TabIndex = 7;
            this.btnPwdchange.Text = "修改密码";
            this.btnPwdchange.UseVisualStyleBackColor = false;
            this.btnPwdchange.Click += new System.EventHandler(this.btnPwdChange_Click);
            // 
            // Login
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.btnEixt;
            this.ClientSize = new System.Drawing.Size(462, 287);
            this.Controls.Add(this.btnPwdchange);
            this.Controls.Add(this.btnEixt);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.UPwd);
            this.Controls.Add(this.UName);
            this.Controls.Add(this.LabPwd);
            this.Controls.Add(this.LabName);
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "本科生学习目标达成情况系统";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabName;
        private System.Windows.Forms.Label LabPwd;
        private System.Windows.Forms.TextBox UName;
        private System.Windows.Forms.TextBox UPwd;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnEixt;
        private System.Windows.Forms.Button btnPwdchange;
    }
}