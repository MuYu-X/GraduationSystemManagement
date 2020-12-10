namespace GraduateProject
{
    partial class PassworChange
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
            this.OldPwd = new System.Windows.Forms.TextBox();
            this.NewPwd = new System.Windows.Forms.TextBox();
            this.Confirm = new System.Windows.Forms.TextBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.labConfirm = new System.Windows.Forms.Label();
            this.labNewPwd = new System.Windows.Forms.Label();
            this.labOldPwd = new System.Windows.Forms.Label();
            this.labUsername = new System.Windows.Forms.Label();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // OldPwd
            // 
            this.OldPwd.Location = new System.Drawing.Point(138, 65);
            this.OldPwd.Name = "OldPwd";
            this.OldPwd.Size = new System.Drawing.Size(174, 21);
            this.OldPwd.TabIndex = 2;
            this.OldPwd.UseSystemPasswordChar = true;
            // 
            // NewPwd
            // 
            this.NewPwd.Location = new System.Drawing.Point(138, 108);
            this.NewPwd.Name = "NewPwd";
            this.NewPwd.Size = new System.Drawing.Size(174, 21);
            this.NewPwd.TabIndex = 3;
            this.NewPwd.UseSystemPasswordChar = true;
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(138, 151);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(174, 21);
            this.Confirm.TabIndex = 4;
            this.Confirm.UseSystemPasswordChar = true;
            this.Confirm.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(93, 201);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(75, 23);
            this.btnChange.TabIndex = 5;
            this.btnChange.Text = "修改密码";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(227, 201);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // labConfirm
            // 
            this.labConfirm.AutoSize = true;
            this.labConfirm.Location = new System.Drawing.Point(79, 154);
            this.labConfirm.Name = "labConfirm";
            this.labConfirm.Size = new System.Drawing.Size(53, 12);
            this.labConfirm.TabIndex = 5;
            this.labConfirm.Text = "确认密码";
            // 
            // labNewPwd
            // 
            this.labNewPwd.AutoSize = true;
            this.labNewPwd.Location = new System.Drawing.Point(91, 108);
            this.labNewPwd.Name = "labNewPwd";
            this.labNewPwd.Size = new System.Drawing.Size(41, 12);
            this.labNewPwd.TabIndex = 6;
            this.labNewPwd.Text = "新密码";
            // 
            // labOldPwd
            // 
            this.labOldPwd.AutoSize = true;
            this.labOldPwd.Location = new System.Drawing.Point(91, 68);
            this.labOldPwd.Name = "labOldPwd";
            this.labOldPwd.Size = new System.Drawing.Size(41, 12);
            this.labOldPwd.TabIndex = 7;
            this.labOldPwd.Text = "原密码";
            // 
            // labUsername
            // 
            this.labUsername.AutoSize = true;
            this.labUsername.Location = new System.Drawing.Point(91, 27);
            this.labUsername.Name = "labUsername";
            this.labUsername.Size = new System.Drawing.Size(41, 12);
            this.labUsername.TabIndex = 8;
            this.labUsername.Text = "用户名";
            this.labUsername.Click += new System.EventHandler(this.label4_Click);
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(138, 24);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(174, 21);
            this.TxtName.TabIndex = 1;
            // 
            // PassworChange
            // 
            this.AcceptButton = this.btnChange;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 285);
            this.Controls.Add(this.TxtName);
            this.Controls.Add(this.labUsername);
            this.Controls.Add(this.labOldPwd);
            this.Controls.Add(this.labNewPwd);
            this.Controls.Add(this.labConfirm);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.NewPwd);
            this.Controls.Add(this.OldPwd);
            this.Name = "PassworChange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "重置密码";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox OldPwd;
        private System.Windows.Forms.TextBox NewPwd;
        private System.Windows.Forms.TextBox Confirm;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label labConfirm;
        private System.Windows.Forms.Label labNewPwd;
        private System.Windows.Forms.Label labOldPwd;
        private System.Windows.Forms.Label labUsername;
        private System.Windows.Forms.TextBox TxtName;
    }
}