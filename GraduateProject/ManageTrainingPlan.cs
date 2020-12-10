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
    public partial class ManageTrainingPlan : Form
    {
        public ManageTrainingPlan()
        {
            InitializeComponent();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        


        //窗口加载后的操作
        private void ManageTrainingPlan_Load(object sender, EventArgs e)
        {

            JXDW.Enabled = false;
            textJXDW.Visible = false;
            textZYMC.Visible = false;
            ZYMC.Enabled = false;
            PYMB.ReadOnly = true;
            TextBox[] box = new TextBox[] { GraR1,GraR2,GraR3,GraR4,GraR5,GraR6,GraR7,GraR8,GraR9,GraR10,GraR11,GraR12};
            for(int i=0;i<12;i++)
            {
                box[i].ReadOnly = true;

            }
            comSelect.Text = "教学单位"; 

        }


        //教学单位选择框添加数据
        private void JXDW_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (JXDW.Text == "请选择")
            {
                ZYMC.Text = "请选择";
            }
            else
            {
                string pro = "select ProfessionName from ProfessionDB where FacultyName='" + JXDW.Text + "'";
                DataConn dc = new DataConn();
                DataTable profession = dc.GetTable(pro);

                DataRow dr = profession.NewRow();

                dr["ProfessionName"] = "请选择";
                profession.Rows.InsertAt(dr, 0);
                ZYMC.DataSource = profession;
                ZYMC.DisplayMember = "ProfessionName";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataConn dc = new DataConn();

            //第一个选择框为专业名称执行的操作，先判断是否内容存在
            if (comSelect.Text.Equals("专业名称"))
            {
                string jxdw = JXDW.Text;
                string zymc = textZYMC.Text.Trim();
                string sel = "select ProfessionName,FacultyName from ProfessionDB where ProfessionName='"+zymc+"' and FacultyName='"+jxdw+"'";
                IDataReader dr = dc.Read(sel);
                if (dr.Read()!=true)
                {
                    string save = "insert into ProfessionDB (FacultyName,ProfessionName) values ('" + jxdw + "','" + zymc + "')";
                    int i = (int)dc.Excute(save);
                    if (i > 0)
                    {
                        MessageBox.Show($"{jxdw}{zymc}添加成功");
                    }
                }
                else
                {                    
                  MessageBox.Show($"{jxdw}{zymc}已经存在，请添加其他专业或选择其他操作", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            //第一个选择框为教学单位执行插入操作，判断是否内容存在
            else if (comSelect.Text.Equals("教学单位"))
            {
                string jxdw = textJXDW.Text.Trim();
                string sel = "select FacultyName from FacultyDB where FacultyName='"+jxdw+"'";
                IDataReader dr = dc.Read(sel);
                if(dr.Read()!=true)
                {
                    string save = "insert into facultyDB (FacultyName) values ('" + jxdw + "')";
                    int i = (int)dc.Excute(save);
                    if (i > 0)
                    {
                        MessageBox.Show($"{jxdw}添加成功");
                    }
                }
                else
                {
                     MessageBox.Show($"{jxdw}已经存在，请添加其他教学单位或选择其他操作", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

            //第一个选择框为培养目标执行插入操作，判断是否内容存在，然后执行添加
            else if (comSelect.Text.Equals("培养目标"))
            {

                string jxdw = JXDW.Text;
                string zymc = ZYMC.Text;
                string tobject = PYMB.Text.Trim();
                string gr1 = GraR1.Text.Trim();
                string gr2 = GraR2.Text.Trim();
                string gr3 = GraR3.Text.Trim();
                string gr4 = GraR4.Text.Trim();
                string gr5 = GraR5.Text.Trim();
                string gr6 = GraR6.Text.Trim();
                string gr7 = GraR7.Text.Trim();
                string gr8 = GraR8.Text.Trim();
                string gr9 = GraR9.Text.Trim();
                string gr10 = GraR10.Text.Trim();
                string gr11 = GraR11.Text.Trim();
                string gr12 = GraR12.Text.Trim();
                string sel = "select Faculty,Profession from TrainPlanDB where Faculty='" + jxdw + "' and Profession='" + zymc + "'";

                IDataReader dr = dc.Read(sel);
                if (dr.Read()==true)
                {
                    MessageBox.Show($"{jxdw}{zymc}已存在，请选择退出选择修改或添加其他信息", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    string save = "insert into TrainPlanDB (Faculty,Profession,TrainingObject,GraduationReq1,GraduationReq2,GraduationReq3,GraduationReq4,GraduationReq5,GraduationReq6,GraduationReq7,GraduationReq8,GraduationReq9,GraduationReq10,GraduationReq11,GraduationReq12) values ('" + jxdw + "','" + zymc + "','" + tobject + "','" + gr1 + "','" + gr2 + "','" + gr3 + "','" + gr4 + "','" + gr5 + "','" + gr6 + "','" + gr7 + "','" + gr8 + "','" + gr9 + "','" + gr10 + "','" + gr11 + "','" + gr12 + "')";
                    int i = (int)dc.Excute(save);
                    if (i > 0)
                    {
                        MessageBox.Show($"{jxdw}{zymc} 添加成功");
                    }

                }

            }


        }
       

        //第一个选择框
            private void comSelect_SelectedIndexChanged(object sender, EventArgs e)
            {
                TextBox[] box = new TextBox[] { GraR1, GraR2, GraR3, GraR4, GraR5, GraR6, GraR7, GraR8, GraR9, GraR10, GraR11, GraR12 };
                if (comSelect.Text.Equals("培养目标"))
                {
                    JXDW.Enabled = true;
                    textJXDW.Visible = false;
                    textZYMC.Visible = false;
                    ZYMC.Enabled = true;
                    PYMB.ReadOnly = false;
                   
                    for (int i = 0; i < 12; i++)
                    {
                        box[i].ReadOnly = false;

                    }
   
                    DataConn dc = new DataConn();
                    string fac = "select FacultyName from FacultyDB";
                    DataTable faculty = dc.GetTable(fac);
                    DataRow dr = faculty.NewRow();
                    JXDW.DataSource = faculty;
                    JXDW.DisplayMember = "FacultyName";
                    JXDW.SelectedIndex = 0;
                }
                else if (comSelect.Text.Equals("教学单位"))
                {
                    JXDW.Enabled = false;
                    textJXDW.Visible = true;
                    textZYMC.Visible = false;

                    ZYMC.Enabled = false;
                    PYMB.ReadOnly = true;
                for (int i = 0; i < 12; i++)
                {
                    box[i].ReadOnly = true;

                }
            }
                else if (comSelect.Text.Equals("专业名称"))
                {

                    JXDW.Enabled = true;
                    textJXDW.Visible = false;
                    textZYMC.Visible = true;

                    ZYMC.Enabled = false;
                    PYMB.ReadOnly = true;
                for (int i = 0; i < 12; i++)
                {
                    box[i].ReadOnly = true;

                }
                DataConn dc = new DataConn();
                string fac = "select FacultyName from FacultyDB";
                    DataTable faculty = dc.GetTable(fac);
                    DataRow dr = faculty.NewRow();
                    JXDW.DataSource = faculty;
                    JXDW.DisplayMember = "FacultyName";
                    JXDW.SelectedIndex = 0;
                }
            }
        }
    } 
