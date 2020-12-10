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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnEixt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UserPassword_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           string name = UName.Text.Trim();
           string password = UPwd.Text.Trim();


            if (name == "" || password == "")
            {
                MessageBox.Show("用户名和密码不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                
                string check = "select UserName,UserPwd from LoginDB where UserName='" + name + "'and UserPwd = '" + password + "' COLLATE  Chinese_PRC_CS_AS ";
                DataConn conn = new DataConn();
                IDataReader conndata = conn.Read(check);
               
                if (conndata.Read())
                {

                    TrainingPlan trainingPlan = new TrainingPlan();
                    trainingPlan.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("请输入正确的账号和密码", "登陆提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
           
        }

       
       

        private void PicVerCode_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_ControlAdded(object sender, ControlEventArgs e)
        {
          
        }

        private void btnPwdChange_Click(object sender, EventArgs e)
        {
            PassworChange passwor = new PassworChange();
            passwor.Show();

        }
    }
}
