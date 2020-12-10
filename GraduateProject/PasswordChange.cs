using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraduateProject
{
    public partial class PassworChange : Form
    {
        public PassworChange()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnChange_Click(object sender, EventArgs e)
        {

            if (TxtName.Text.Equals("") || OldPwd.Text.Equals("") || NewPwd.Text.Equals("") || Confirm.Text.Equals(""))
            {
                MessageBox.Show("请输入填写正确的信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return ;

            }
            string oldpwd = "select UserName,UserPwd from LoginDB where UserName='" + TxtName.Text.Trim() + "'and UserPwd = '" + OldPwd.Text.Trim() + " '";
            DataConn DC = new DataConn();
            IDataReader dr = DC.Read(oldpwd);
            if (dr.Read())
            {
                 if (NewPwd.Text.Length > 30||NewPwd.Text.Length<6)
                 {
                        MessageBox.Show("请重新输入正确密码，长度大于6且不小于30", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                 }
                 if(NewPwd.Text==OldPwd.Text)
                {
                    MessageBox.Show("新密码和旧密码一样，请重新输入", " 警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return ;
                }
 
                if (NewPwd.Text == Confirm.Text)
                {
                    string change = "update LoginDB set UserPwd ='" + NewPwd.Text + "'where UserName='" + TxtName.Text + "' ";
                    DataConn dataConn = new DataConn();
                    int i = dataConn.Excute(change);
                    if (i > 0)
                    {
                         MessageBox.Show("修改成功");
                        this.Close();
                    }

                 }
                else
                {
                     MessageBox.Show("两次密码不一致，请重新确认密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                  
            }
            else
            {
                 MessageBox.Show("账号密码不符，请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
