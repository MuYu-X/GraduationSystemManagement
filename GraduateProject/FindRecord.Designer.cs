namespace GraduateProject
{
    partial class FindRecord
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbMatchWholeWord = new System.Windows.Forms.CheckBox();
            this.chbMatchCase = new System.Windows.Forms.CheckBox();
            this.btCancel = new System.Windows.Forms.Button();
            this.btFindNext = new System.Windows.Forms.Button();
            this.tbFindTxt = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbMatchWholeWord);
            this.groupBox1.Controls.Add(this.chbMatchCase);
            this.groupBox1.Controls.Add(this.btCancel);
            this.groupBox1.Controls.Add(this.btFindNext);
            this.groupBox1.Controls.Add(this.tbFindTxt);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 204);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // chbMatchWholeWord
            // 
            this.chbMatchWholeWord.AutoSize = true;
            this.chbMatchWholeWord.Location = new System.Drawing.Point(27, 107);
            this.chbMatchWholeWord.Name = "chbMatchWholeWord";
            this.chbMatchWholeWord.Size = new System.Drawing.Size(72, 16);
            this.chbMatchWholeWord.TabIndex = 3;
            this.chbMatchWholeWord.Text = "全字匹配";
            this.chbMatchWholeWord.UseVisualStyleBackColor = true;
            // 
            // chbMatchCase
            // 
            this.chbMatchCase.AutoSize = true;
            this.chbMatchCase.Location = new System.Drawing.Point(27, 71);
            this.chbMatchCase.Name = "chbMatchCase";
            this.chbMatchCase.Size = new System.Drawing.Size(84, 16);
            this.chbMatchCase.TabIndex = 2;
            this.chbMatchCase.Text = "大小写匹配";
            this.chbMatchCase.UseVisualStyleBackColor = true;
            this.chbMatchCase.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(230, 147);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 5;
            this.btCancel.Text = "取消(&L)";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btFindNext
            // 
            this.btFindNext.Location = new System.Drawing.Point(27, 147);
            this.btFindNext.Name = "btFindNext";
            this.btFindNext.Size = new System.Drawing.Size(75, 23);
            this.btFindNext.TabIndex = 4;
            this.btFindNext.Text = "查找(&L)";
            this.btFindNext.UseVisualStyleBackColor = true;
            this.btFindNext.Click += new System.EventHandler(this.btFindNext_Click);
            // 
            // tbFindTxt
            // 
            this.tbFindTxt.Location = new System.Drawing.Point(27, 20);
            this.tbFindTxt.Name = "tbFindTxt";
            this.tbFindTxt.Size = new System.Drawing.Size(278, 21);
            this.tbFindTxt.TabIndex = 0;
            // 
            // FindRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 228);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindRecord";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查找";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FindRecord_FormClosing);
            this.Load += new System.EventHandler(this.FindRecord_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbFindTxt;
        private System.Windows.Forms.CheckBox chbMatchWholeWord;
        private System.Windows.Forms.CheckBox chbMatchCase;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btFindNext;
    }
}