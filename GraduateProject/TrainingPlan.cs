using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Threading;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;





namespace GraduateProject
{
    public partial class TrainingPlan : Form
    {
        private FindRecord winFind = new FindRecord();


        public static string ProfrssionName, FacultyName;
        

        public TrainingPlan()
        {
            InitializeComponent();
            table();
            this.winFind.OnFindClick += new EventHandler<FindRecordWindowEventArgs>(this.winFind_OnFindClick);
            if(dataview.Rows.Count!=0)
            {
                btndelete.Enabled = true;

            }
            else
            {
                btndelete.Enabled = false;

            }
        }
     
        //查找，正則表達式
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
                            this.dataview.Rows[cel.RowIndex].Cells[cel.ColumnIndex].Style.BackColor = Color.Red;
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

        //窗口加载
        private void TrainingPlan_Load(object sender, EventArgs e)
        {
            DataConn dc = new DataConn();
            string fac = "select FacultyName from FacultyDB";

            DataTable faculty = dc.GetTable(fac);
            DataRow dr =faculty.NewRow();
           
            dr["FacultyName"] = "请选择";
            faculty.Rows.InsertAt(dr, 0);
            FNameList.DataSource = faculty;
            FNameList.DisplayMember = "FacultyName";
            FNameList.SelectedIndex = 0;

            FNameList.Text = dataview.Rows[0].Cells["Column1"].Value.ToString();           
            PName.Text = dataview.Rows[0].Cells["Column2"].Value.ToString();


        }


        //对数据表格点击后，下面文本框获取数据
        private void dataview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

                FNameList.Text = dataview.CurrentRow.Cells["Column1"].Value.ToString();
                PName.Text = dataview.CurrentRow.Cells["Column2"].Value.ToString();
                textTObject.Text = dataview.CurrentRow.Cells["Column3"].Value.ToString();
                textGR1.Text = dataview.CurrentRow.Cells["Column4"].Value.ToString();
                textGR2.Text = dataview.CurrentRow.Cells["Column5"].Value.ToString();
                textGR3.Text = dataview.CurrentRow.Cells["Column6"].Value.ToString();
                textGR4.Text = dataview.CurrentRow.Cells["Column7"].Value.ToString();
                textGR5.Text = dataview.CurrentRow.Cells["Column8"].Value.ToString();
                textGR6.Text = dataview.CurrentRow.Cells["Column9"].Value.ToString();
                textGR7.Text = dataview.CurrentRow.Cells["Column10"].Value.ToString();
                textGR8.Text = dataview.CurrentRow.Cells["Column11"].Value.ToString();
                textGR9.Text = dataview.CurrentRow.Cells["Column12"].Value.ToString();
                textGR10.Text = dataview.CurrentRow.Cells["Column13"].Value.ToString();
                textGR11.Text = dataview.CurrentRow.Cells["Column14"].Value.ToString();
                textGR12.Text = dataview.CurrentRow.Cells["Column15"].Value.ToString();

        
        }



        //数据窗口，使用数组循环传递
        private void table()
        {
            string sql = "select * from TrainPlanDB order by Faculty";
            DataConn conn = new DataConn();
            IDataReader conndata = conn.Read(sql);
            while (conndata.Read())
            {
                string fac, prof, tobject;
                string gr1, gr2, gr3, gr4, gr5, gr6, gr7, gr8, gr9, gr10, gr11, gr12;
                fac = conndata["Faculty"].ToString();
                prof = conndata["Profession"].ToString();
                tobject = conndata["TrainingObject"].ToString();
                gr1 = conndata["GraduationReq1"].ToString();
                gr2 = conndata["GraduationReq2"].ToString();
                gr3 = conndata["GraduationReq3"].ToString();
                gr4 = conndata["GraduationReq4"].ToString();
                gr5 = conndata["GraduationReq5"].ToString();
                gr6 = conndata["GraduationReq6"].ToString();
                gr7 = conndata["GraduationReq7"].ToString();
                gr8 = conndata["GraduationReq8"].ToString();
                gr9 = conndata["GraduationReq9"].ToString();
                gr10 = conndata["GraduationReq10"].ToString();
                gr11 = conndata["GraduationReq11"].ToString();
                gr12 = conndata["GraduationReq12"].ToString();
                string[] str = { fac, prof, tobject, gr1, gr2, gr3, gr4, gr5, gr6, gr7, gr8, gr9, gr10, gr11, gr12 };

                dataview.Rows.Add(str);


            }
            conndata.Close();
            if (dataview.Rows.Count != 0)
            {
                btndelete.Enabled = true;

            }
            else
            {
                btndelete.Enabled = false;

            }
        }


       

        private void 课程体系对毕业要求支撑矩阵ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FacultyName = FNameList.Text;
            ProfrssionName = PName.Text;
            CourseMatrix courseMatrix = new CourseMatrix();
            if(FNameList.Text.Equals("请选择"))
            {
                MessageBox.Show("请先选择你要查看的院系和专业","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else if(PName.Text.Equals("请选择"))
            {
                MessageBox.Show("请继续选择专业", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                courseMatrix.Show();
            }
           
        }

        private void 退出ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //确认退出对话框，如果选择是则退出
        private void TrainingPlan_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("是否要退出系统", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.ExitThread(); // 退出当前线程下的消息循环
            }
            else
            {
                e.Cancel = true;
            }
        }


        //判断CTRL+F调出查找页面
        private void TrainingPlan_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Modifiers==Keys.Control&&e.KeyCode==Keys.F)
            {
                winFind.Show();
            }
        }

  

        private void FName_SelectedIndexChanged(object sender, EventArgs e)
        {

                string pro = "select ProfessionName from ProfessionDB where FacultyName='"+FNameList.Text+"' order by ProfessionName";
                DataConn dc = new DataConn();
                DataTable profession = dc.GetTable(pro);

                DataRow dr = profession.NewRow();

                dr["ProfessionName"] = "请选择";
                profession.Rows.InsertAt(dr, 0);
                PName.DataSource = profession;
                PName.DisplayMember = "ProfessionName";

        }

        private void 专业课程体系对毕业要求支撑矩阵ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FacultyName = FNameList.Text;
            ProfrssionName = PName.Text;
            CourseSupport courseSupport = new CourseSupport();
            if (FNameList.Text.Equals("请选择"))
            {
                MessageBox.Show("请先选择你要查看的院系和专业", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (PName.Text.Equals("请选择"))
            {
                MessageBox.Show("请继续选择专业", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                courseSupport.Show();
            }
           
        }


        //打开insert框，关闭后之后刷新操作
        private void btninsert_Click(object sender, EventArgs e)
        {
            ManageTrainingPlan manageTrainingPlan = new ManageTrainingPlan();
            if (manageTrainingPlan.ShowDialog() != DialogResult.OK)
            {
                dataview.Rows.Clear();
                table();
                //教学单位选择框刷新
                DataConn dc = new DataConn();
                string fac = "select FacultyName from FacultyDB order by FacultyName";
                DataTable faculty = dc.GetTable(fac);
                DataRow dr1 = faculty.NewRow();
                dr1["FacultyName"] = "请选择";
                faculty.Rows.InsertAt(dr1, 0);
                FNameList.DataSource = faculty;
                FNameList.DisplayMember = "FacultyName";
                FNameList.SelectedIndex = 0;
                //专业选择框刷新
                string pro = "select ProfessionName from ProfessionDB where FacultyName='" + FNameList.Text + "' order by ProfessionName";
                DataTable profession = dc.GetTable(pro);
                DataRow dr2 = profession.NewRow();
                dr2["ProfessionName"] = "请选择";
                profession.Rows.InsertAt(dr2, 0);
                PName.DataSource = profession;
                PName.DisplayMember = "ProfessionName";
            }
        }




        //删除数据库
        private void btndelete_Click(object sender, EventArgs e)
        {
            DataConn dc = new DataConn();
            TextBox[] _box = new TextBox[] { textTObject, textGR1, textGR2, textGR3, textGR4, textGR5, textGR6, textGR7, textGR8, textGR9, textGR10, textGR11, textGR12 };
            if(PName.Text=="请选择" && FNameList.Text!="请选择")
            {
                string deletefac= "delete from FacultyDB where FacultyName='" + FNameList.Text+"'";
                DialogResult result1 = MessageBox.Show("你确定要删除" + FNameList.Text + "下全部内容吗？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if(result1==DialogResult.Yes)
                {
                    int k = dc.Excute(deletefac);

                    if(k>0)
                    { 
                        MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataview.Rows.Clear();
                        table();
                    }
                    string fac = "select FacultyName from FacultyDB";
                    DataTable faculty = dc.GetTable(fac);
                    DataRow dr = faculty.NewRow();
                    dr["FacultyName"] = "请选择";
                    faculty.Rows.InsertAt(dr, 0);
                    FNameList.DataSource = faculty;
                    FNameList.DisplayMember = "FacultyName";
                    FNameList.SelectedIndex = 0;
                    for (int n= 0;n< _box.Length;n++)
                    {
                        _box[n].Text = null;

                    }


                }

            }
            else if(PName.Text!="请选择"&&FNameList.Text!="请选择")
            {
                string deletetrain = "delete from TrainPlanDB where Faculty='" + FNameList.Text + "' and  Profession = '" + PName.Text + "'";
                string deleteprofession = "delete  from ProfessionDB where FacultyName='" + FNameList.Text + "' and  ProfessionName = '" + PName.Text + "'";
                DialogResult result = MessageBox.Show("你确定要删除" + FNameList.Text + " " + PName.Text + " ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int i = dc.Excute(deletetrain);
                    int j = dc.Excute(deleteprofession);

                    if (i > 0&&j>0)
                    {
                        MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataview.Rows.Clear();
                        table();
                    }
                    string pro = "select ProfessionName from ProfessionDB where FacultyName='" + FNameList.Text + "'";
                    DataTable profession = dc.GetTable(pro);
                    DataRow dr = profession.NewRow();
                    dr["ProfessionName"] = "请选择";
                    profession.Rows.InsertAt(dr, 0);
                    PName.DataSource = profession;
                    PName.DisplayMember = "ProfessionName";
                    for (int n = 0; n < _box.Length; n++)
                    {
                        _box[n].Text = null;

                    }

                }

            }

           
        }


        //点击修改按钮后，执行的操作
        private void btnupdate_Click(object sender, EventArgs e)
        {
            btndelete.Visible = false;
            btnPdf.Visible = false;
            btninsert.Visible = false;
            btnupdate.Visible = false;
            btnsave.Visible = true;
            btnexit.Visible = true;
            textTObject.ReadOnly = false;
            
            textGR1.ReadOnly = false;
            textGR2.ReadOnly = false;
            textGR3.ReadOnly = false;
            textGR4.ReadOnly = false;
            textGR5.ReadOnly = false;
            textGR6.ReadOnly = false;
            textGR7.ReadOnly = false;
            textGR8.ReadOnly = false;
            textGR9.ReadOnly = false;
            textGR10.ReadOnly = false;
            textGR11.ReadOnly = false;
            textGR12.ReadOnly = false;

        }


        //修改添加
        private void btnsave_Click(object sender, EventArgs e)
        {
            DataConn dc = new DataConn();            
            string save = "update TrainPlanDB set TrainingObject ='"+textTObject.Text+ "', GraduationReq1 = '"+textGR1.Text+ "', GraduationReq2 = '" + textGR2.Text + "', " +
                "GraduationReq3 = '" + textGR3.Text + "', GraduationReq4 = '" + textGR4.Text+ "', GraduationReq5 = '" + textGR5.Text + "', " +
                "GraduationReq6 = '" + textGR6.Text + "', GraduationReq7 = '" + textGR7.Text + "', GraduationReq8 = '" + textGR8.Text + "', " +
                "GraduationReq9 = '" + textGR9.Text + "', GraduationReq10 = '" + textGR10.Text + "' ,GraduationReq11 = '" + textGR11.Text + "', " +
                "GraduationReq12 = '" + textGR12.Text + "' where  Faculty='" + FNameList.Text + "' and Profession='" + PName.Text + "' ";
            DialogResult result = MessageBox.Show("确认修改此项吗？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int i = dc.Excute(save);
                if(i>0)
                {
                    MessageBox.Show("修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataview.Rows.Clear();
                    table();
                }

            }
            

            
        }


        //修改后退出修改页面
        private void btnexit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("请问您确认要退出修改吗？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result.Equals(DialogResult.Yes))
            {
            btndelete.Visible = true;
            btnPdf.Visible = true;
            btninsert.Visible = true;
            btnupdate.Visible = true;
            btnsave.Visible = false;
            btnexit.Visible = false;
            textTObject.ReadOnly = true;
            textGR1.ReadOnly = true;
            textGR2.ReadOnly = true;
            textGR3.ReadOnly = true;
            textGR4.ReadOnly = true;
            textGR5.ReadOnly = true;
            textGR6.ReadOnly = true;
            textGR7.ReadOnly = true;
            textGR8.ReadOnly = true;
            textGR9.ReadOnly = true;
            textGR10.ReadOnly = true;
            textGR11.ReadOnly = true;
            textGR12.ReadOnly = true;
            }

        }

        //导出pdf文件供下载
        private void btnPdf_Click(object sender, EventArgs e)
        {
            ExportPDF export = new ExportPDF();
            export.pdf(dataview);

        }



        //院系和专业后显示培养目标和毕业要求
        private void PName_SelectedIndexChanged(object sender, EventArgs e)
        {

            string tobject = "select * from TrainPlanDB where Faculty='" + FNameList.Text + "' and Profession='" + PName.Text + "'";

            DataConn dc = new DataConn();
            IDataReader dr = dc.Read(tobject);
            if (dr.Read())
            {
                textTObject.Text = dr["TrainingObject"].ToString();
                textGR1.Text = dr["GraduationReq1"].ToString();
                textGR2.Text = dr["GraduationReq2"].ToString();
                textGR3.Text = dr["GraduationReq3"].ToString();
                textGR4.Text = dr["GraduationReq4"].ToString();
                textGR5.Text = dr["GraduationReq5"].ToString();
                textGR6.Text = dr["GraduationReq6"].ToString();
                textGR7.Text = dr["GraduationReq7"].ToString();
                textGR8.Text = dr["GraduationReq8"].ToString();
                textGR9.Text = dr["GraduationReq9"].ToString();
                textGR10.Text = dr["GraduationReq10"].ToString();
                textGR11.Text = dr["GraduationReq11"].ToString();
                textGR12.Text = dr["GraduationReq12"].ToString();
            }
            else
            {
                TextBox[] _box = new TextBox[] { textTObject, textGR1, textGR2, textGR3, textGR4, textGR5, textGR6, textGR7, textGR8, textGR9, textGR10, textGR11, textGR12 };
                for(int i=0;i<_box.Length;i++)
                {
                    _box[i].Text = null;
                }
            }

        }




    }
}
