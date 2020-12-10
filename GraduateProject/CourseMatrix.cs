using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;

namespace GraduateProject
{
    public partial class CourseMatrix : Form
    {
        private FindRecord winFind = new FindRecord();
        public CourseMatrix()
        {

            InitializeComponent();
            table();
            this.winFind.OnFindClick += new EventHandler<FindRecordWindowEventArgs>(this.winFind_OnFindClick);


        }

        
        //加载窗口后执行的操作
        private void CourseMatrix_Load(object sender, EventArgs e)
        {
            PName.Text = TrainingPlan.ProfrssionName;
            FName.Text = TrainingPlan.FacultyName;
            if(dataview.Rows.Count!=0)
            {
                txtCourseName.Text = dataview.Rows[0].Cells["Column1"].Value.ToString();
                comboBox1.Text = dataview.Rows[0].Cells["Column2"].Value.ToString();
                comboBox2.Text = dataview.Rows[0].Cells["Column3"].Value.ToString();
                comboBox3.Text = dataview.Rows[0].Cells["Column4"].Value.ToString();
                comboBox4.Text = dataview.Rows[0].Cells["Column5"].Value.ToString();
                comboBox5.Text = dataview.Rows[0].Cells["Column6"].Value.ToString();
                comboBox6.Text = dataview.Rows[0].Cells["Column7"].Value.ToString();
                comboBox7.Text = dataview.Rows[0].Cells["Column8"].Value.ToString();
                comboBox8.Text = dataview.Rows[0].Cells["Column9"].Value.ToString();
                comboBox9.Text = dataview.Rows[0].Cells["Column10"].Value.ToString();
                comboBox10.Text = dataview.Rows[0].Cells["Column11"].Value.ToString();
                comboBox11.Text = dataview.Rows[0].Cells["Column12"].Value.ToString();
                comboBox12.Text = dataview.Rows[0].Cells["Column13"].Value.ToString();
            }

        }



        //删除按钮
        private void button2_Click(object sender, EventArgs e)
        {

            string del = "delete from CourseMatrixDB where FacultyName='" + FName.Text + "'and ProfessionName='"+PName.Text+ "'and CourseName='"+txtCourseName.Text+"'";
            DataConn dc = new DataConn();
            DialogResult result = MessageBox.Show("确认删除"+FName.Text+""+PName.Text+"下的"+txtCourseName.Text+"吗？","",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if(result==DialogResult.Yes)
            {
                int i = dc.Excute(del);
                if(i>0)
                {
                    MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataview.Rows.Clear();
                    table();

                }
            }
            txtCourseName.Text = null;

        }

        private void CourMatrix_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCourseName.Text = dataview.CurrentRow.Cells["Column1"].Value.ToString();
            comboBox1.Text = dataview.CurrentRow.Cells["Column2"].Value.ToString();
            comboBox2.Text = dataview.CurrentRow.Cells["Column3"].Value.ToString();
            comboBox3.Text = dataview.CurrentRow.Cells["Column4"].Value.ToString();
            comboBox4.Text = dataview.CurrentRow.Cells["Column5"].Value.ToString();
            comboBox5.Text = dataview.CurrentRow.Cells["Column6"].Value.ToString();
            comboBox6.Text = dataview.CurrentRow.Cells["Column7"].Value.ToString();
            comboBox7.Text = dataview.CurrentRow.Cells["Column8"].Value.ToString();
            comboBox8.Text = dataview.CurrentRow.Cells["Column9"].Value.ToString();
            comboBox9.Text = dataview.CurrentRow.Cells["Column10"].Value.ToString();
            comboBox10.Text = dataview.CurrentRow.Cells["Column11"].Value.ToString();
            comboBox11.Text = dataview.CurrentRow.Cells["Column12"].Value.ToString();
            comboBox12.Text = dataview.CurrentRow.Cells["Column13"].Value.ToString();



        }



        //获取数据库内容，并使用数组传递该值到datagripview各列，可以后续作为刷新的主要函数
        private void table()
        {
            string sql = "select * from CourseMatrixDB where ProfessionName='"+TrainingPlan.ProfrssionName+ "' and FacultyName='"+TrainingPlan.FacultyName+"'";
            DataConn conn = new DataConn();
            IDataReader conndata = conn.Read(sql);
            while (conndata.Read())
            {
                string coursename;
                string gr1, gr2, gr3, gr4, gr5, gr6, gr7, gr8, gr9, gr10, gr11, gr12;

                coursename = conndata["CourseName"].ToString();
                gr1 = conndata["GraReq1"].ToString();
                gr2 = conndata["GraReq2"].ToString();
                gr3 = conndata["GraReq3"].ToString();
                gr4 = conndata["GraReq4"].ToString();
                gr5 = conndata["GraReq5"].ToString();
                gr6 = conndata["GraReq6"].ToString();
                gr7 = conndata["GraReq7"].ToString();
                gr8 = conndata["GraReq8"].ToString();
                gr9 = conndata["GraReq9"].ToString();
                gr10 = conndata["GraReq10"].ToString();
                gr11 = conndata["GraReq11"].ToString();
                gr12 = conndata["GraReq12"].ToString();
                string[] str = {coursename,gr1, gr2, gr3, gr4, gr5, gr6, gr7, gr8, gr9, gr10, gr11, gr12 };
                dataview.Rows.Add(str);

            }
            conndata.Close();
            if (dataview.Rows.Count != 0)
            {
                button2.Enabled = true;

            }
            else
            {
                button2.Enabled = false;

            }
            
        }



        //查找函数
        private void winFind_OnFindClick(object sender, FindRecordWindowEventArgs e)
        {
            string s = e.FindTxt;

            int index = e.Index;
            bool bFind = false;

            RegexOptions regOptions = RegexOptions.IgnoreCase;
            string pattern = Regex.Escape(s);

            AutoResetEvent resetEvent = new AutoResetEvent(false);



            if (e._FindOptions == FindRecord.FindOptions.MatchCase || e._FindOptions == FindRecord.FindOptions.MatchCaseAndWholeWord)
            {
                regOptions = RegexOptions.None;
            }

            if (e._FindOptions == FindRecord.FindOptions.MatchWholeWord || e._FindOptions == FindRecord.FindOptions.MatchCaseAndWholeWord)
            {
                pattern = "\\b" + pattern + "\\b";
            }

            foreach (DataGridViewRow row in dataview.Rows)
            {
                this.winFind.CurrentIndex = row.Index;
                foreach (DataGridViewCell cel in row.Cells)
                {
                    //if (cel.Value.ToString().Contains(s))`
                    if (Regex.IsMatch(cel.Value.ToString(), pattern, regOptions))
                    {
                        bFind = true;
                        if (cel.RowIndex > index)
                        {

                            this.dataview.ClearSelection();
                            this.dataview.Rows[cel.RowIndex].Selected = true;
                            return;

                        }

                    }

                }

            }

            if (!bFind)
            {
                this.winFind.CurrentIndex = -1;
                MessageBox.Show(string.Format("无法查找到相应内容:\r\n{0}", s), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void btnfind_Click(object sender, EventArgs e)
        {
            winFind.Show();
        }


        //执行添加按钮
        private void button1_Click(object sender, EventArgs e)
        {
            txtCourseName.ReadOnly = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = true;
            button6.Visible = true;
            btnfind.Visible = false;


        }

        //修改按钮
        private void button3_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = true;
            btnfind.Visible = false;
            btnupdate.Visible = true;
            
        }



        //只能有一个有元素，如果有，则报错
        public bool duplicatecount(int count)
        {
            count = 0;
            foreach (Control control in BoxCheck.Controls)
            {
              
                if(control is ComboBox)
                { 
                    if(control.Text!="")
                    {
                        count++;
                    }
                }
            }
            if(count<=1)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        
        //增加后保存按钮，首先判断combobox是否有多个重复，如果有则报错
        private void button5_Click(object sender, EventArgs e)
        {
            DataConn dc = new DataConn();
            int count = 0;
            if(txtCourseName.Text=="")
            {
                MessageBox.Show("课程名称不能为空");
                return;

            }
            if (duplicatecount(count) == false)
            {
                MessageBox.Show("每个课程只能有一个毕业要求，其余为空", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string duplicateCourse = "select * from CourseMatrixDB where FacultyName='" + FName.Text + "'and ProfessionName='" + PName.Text + "' and CourseName='"+txtCourseName.Text+"'";
                IDataReader dr = dc.Read(duplicateCourse);
                if(dr.Read()==true)
                {
                    MessageBox.Show($"{FName.Text}{PName.Text}{txtCourseName.Text}已存在，请选择退出选择修改或添加其他信息","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    string insert = "insert into CourseMatrixDB (ProfessionName,FacultyName,CourseName,GraReq1,GraReq2,GraReq3,GraReq4,GraReq5,GraReq6,GraReq7,GraReq8,GraReq9,GraReq10,GraReq11,GraReq12) " +
                        "values ('" + PName.Text + "','" + FName.Text + "','" + txtCourseName.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "'," +
                        "'" + comboBox3.Text + "','" + comboBox4.Text + "','" + comboBox5.Text + "','" + comboBox6.Text + "','" + comboBox7.Text + "'," +
                        "'" + comboBox8.Text + "','" + comboBox9.Text + "','" + comboBox10.Text + "','" + comboBox11.Text + "','" + comboBox12.Text + "')";
                    int i = dc.Excute(insert);
                    if (i > 0)
                    {
                        MessageBox.Show("添加成功");
                    }

                }


            }
            dataview.Rows.Clear();
            table();
            
        }

        //添加后退出按钮
        private void button6_Click(object sender, EventArgs e)
        {
            txtCourseName.ReadOnly = true;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = false;
            button6.Visible = false;
            btnfind.Visible = true;
            btnupdate.Visible = false;

        }


        //修改操作
        private void btnupdate_Click(object sender, EventArgs e)
        {
            DataConn dc = new DataConn();
            int count = 0;

            if (duplicatecount(count) == false)
            {
                MessageBox.Show("每个课程只能有一个毕业要求，其余为空", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string update = "update CourseMatrixDB  set GraReq1='" + comboBox1.Text + "',GraReq2='" + comboBox2.Text + "',GraReq3='" + comboBox3.Text + "',GraReq4='" + comboBox4.Text + "',GraReq5='" + comboBox5.Text + "',GraReq6='" + comboBox6.Text + "',GraReq7='" + comboBox7.Text + "',GraReq8='" + comboBox8.Text + "',GraReq9='" + comboBox9.Text + "',GraReq10='" + comboBox10.Text + "',GraReq11='" + comboBox11.Text + "',GraReq12='" + comboBox12.Text + "' where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "' and CourseName = '" + txtCourseName.Text + "'";
                DialogResult result = MessageBox.Show($"确认要修改{FName.Text}{PName.Text}{txtCourseName.Text}吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result==DialogResult.Yes)
                {
                    int i = dc.Excute(update);
                    if(i>0)
                    {
                        MessageBox.Show("修改成功!");
                        dataview.Rows.Clear();
                        table();
                    }


                }
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
                button6.Visible = false;
                btnfind.Visible = true;
                btnupdate.Visible = false;

            }
        }



        //导出pdf文件
        private void button4_Click(object sender, EventArgs e)
        {
            ExportPDF export = new ExportPDF();
            export.pdf(dataview);
        }
    }

}
