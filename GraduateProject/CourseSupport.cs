using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GraduateProject
{
    public partial class CourseSupport : Form
    {
        
       
        private FindRecord winFind = new FindRecord();
        public CourseSupport()
        {
            InitializeComponent();
            this.winFind.OnFindClick += new EventHandler<FindRecordWindowEventArgs>(this.winFind_OnFindClick);


        }


        private void CourseSupport_Load(object sender, EventArgs e)
        {

            PName.Text = TrainingPlan.ProfrssionName;
            FName.Text = TrainingPlan.FacultyName;

            combox.Text = "毕业要求1指标点";


        }


        //使用数组对数据进行传递
        private void table(string sql)
        {

            DataConn conn = new DataConn();
            IDataReader conndata = conn.Read(sql);
            while (conndata.Read())
            {
                string profression, grapoint, relatecou;
                string sc1, sc2, sc3, sc4, sc5, sc6, sc7, sc8;
                string sw1, sw2, sw3, sw4, sw5, sw6, sw7, sw8;

                profression = conndata["ProfessionName"].ToString();
                grapoint = conndata["Grapoint"].ToString();
                sc1 = conndata["SupportCourse1"].ToString();
                sw1 = conndata["SupportWeight1"].ToString();
                sc2 = conndata["SupportCourse2"].ToString();
                sw2 = conndata["SupportWeight2"].ToString();
                sc3 = conndata["SupportCourse3"].ToString();
                sw3 = conndata["SupportWeight3"].ToString();
                sc4 = conndata["SupportCourse4"].ToString();
                sw4 = conndata["SupportWeight4"].ToString();
                sc5 = conndata["SupportCourse5"].ToString();
                sw5 = conndata["SupportWeight5"].ToString();
                sc6 = conndata["SupportCourse6"].ToString();
                sw6 = conndata["SupportWeight6"].ToString();
                sc7 = conndata["SupportCourse7"].ToString();
                sw7 = conndata["SupportWeight7"].ToString();
                sc8 = conndata["SupportCourse8"].ToString();
                sw8 = conndata["SupportWeight8"].ToString();
                relatecou = conndata["RelateCourse"].ToString();

                string[] str = { profression, grapoint, sc1, sw1, sc2, sw2, sc3, sw3, sc4, sw4, sc5, sw5, sc6, sw6, sc7, sw7, sc8, sw8, relatecou };
                dataview.Rows.Add(str);


            }
            if (dataview.Rows.Count == 0)
            {
                btndelete.Enabled = false;
            }
            else
            {
                btndelete.Enabled = true;
            }
            conndata.Close();
        }


        //获取第一行第一列的值给GroupBox内的控件
        private void tableload()
        {
            if (dataview.Rows.Count != 0)          //加载数据时直接获取数值到各个textbox,不为空则获取值,为空则表格为null
            {
                textGraPoint.Text = dataview.Rows[0].Cells["Grapoint"].Value.ToString();
                textRelateCou.Text = dataview.Rows[0].Cells["relateCou"].Value.ToString();
                name1.Text = dataview.Rows[0].Cells["SupCou1"].Value.ToString();
                point1.Text = dataview.Rows[0].Cells["Coupoint1"].Value.ToString();
                name2.Text = dataview.Rows[0].Cells["SupCou2"].Value.ToString();
                point2.Text = dataview.Rows[0].Cells["Coupoint2"].Value.ToString();
                name3.Text = dataview.Rows[0].Cells["SupCou3"].Value.ToString();
                point3.Text = dataview.Rows[0].Cells["Coupoint3"].Value.ToString();
                name4.Text = dataview.Rows[0].Cells["SupCou4"].Value.ToString();
                point4.Text = dataview.Rows[0].Cells["Coupoint4"].Value.ToString();
                name5.Text = dataview.Rows[0].Cells["SupCou5"].Value.ToString();
                point5.Text = dataview.Rows[0].Cells["Coupoint5"].Value.ToString();
                name6.Text = dataview.Rows[0].Cells["SupCou6"].Value.ToString();
                point6.Text = dataview.Rows[0].Cells["Coupoint6"].Value.ToString();
                name7.Text = dataview.Rows[0].Cells["SupCou7"].Value.ToString();
                point7.Text = dataview.Rows[0].Cells["Coupoint7"].Value.ToString();
                name8.Text = dataview.Rows[0].Cells["SupCou8"].Value.ToString();
                point8.Text = dataview.Rows[0].Cells["Coupoint8"].Value.ToString();
            }
            else
            {
                textGraPoint.Text = null;
                textRelateCou.Text = null;
                name1.Text = null;
                name2.Text = null;
                name3.Text = null;
                name4.Text = null;
                name5.Text = null;
                name6.Text = null;
                name7.Text = null;
                name8.Text = null;
                point1.Text = null;
                point2.Text = null;
                point3.Text = null;
                point4.Text = null;
                point5.Text = null;
                point6.Text = null;
                point7.Text = null;
                point8.Text = null;
            }
        }

        //各个窗口获取对应数据
        private void textboxindex()
        {
            try
            {
                textGraPoint.Text = dataview.CurrentRow.Cells["Grapoint"].Value.ToString();
                textRelateCou.Text = dataview.CurrentRow.Cells["relateCou"].Value.ToString();
                name1.Text = dataview.CurrentRow.Cells["SupCou1"].Value.ToString();
                point1.Text = dataview.CurrentRow.Cells["Coupoint1"].Value.ToString();
                name2.Text = dataview.CurrentRow.Cells["SupCou2"].Value.ToString();
                point2.Text = dataview.CurrentRow.Cells["Coupoint2"].Value.ToString();
                name3.Text = dataview.CurrentRow.Cells["SupCou3"].Value.ToString();
                point3.Text = dataview.CurrentRow.Cells["Coupoint3"].Value.ToString();
                name4.Text = dataview.CurrentRow.Cells["SupCou4"].Value.ToString();
                point4.Text = dataview.CurrentRow.Cells["Coupoint4"].Value.ToString();
                name5.Text = dataview.CurrentRow.Cells["SupCou5"].Value.ToString();
                point5.Text = dataview.CurrentRow.Cells["Coupoint5"].Value.ToString();
                name6.Text = dataview.CurrentRow.Cells["SupCou6"].Value.ToString();
                point6.Text = dataview.CurrentRow.Cells["Coupoint6"].Value.ToString();
                name7.Text = dataview.CurrentRow.Cells["SupCou7"].Value.ToString();
                point7.Text = dataview.CurrentRow.Cells["Coupoint7"].Value.ToString();
                name8.Text = dataview.CurrentRow.Cells["SupCou8"].Value.ToString();
                point8.Text = dataview.CurrentRow.Cells["Coupoint8"].Value.ToString();
            }
            catch
            {
                MessageBox.Show("该毕业指标点下无可参考数据,请选择其他指标点", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        //使用combobox选择不同的专业指标点,显示不同的数据源
        private void combox_SelectedIndexChanged(object sender, EventArgs e)
        {

            string db = this.combox.SelectedItem.ToString();
            switch (db)
            {
                case "毕业要求1指标点":
                    dataview.Rows.Clear();
                    string selectdb1 = "select * from GraReq1DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                    table(selectdb1);
                    tableload();
                    break;

                case "毕业要求2指标点":
                    dataview.Rows.Clear();
                    string selectdb2 = "select * from GraReq2DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                    table(selectdb2);
                    tableload();
                    break;
                case "毕业要求3指标点":
                    dataview.Rows.Clear();
                    string selectdb3 = "select * from GraReq3DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                    table(selectdb3);
                    tableload();
                    break;
                case "毕业要求4指标点":
                    dataview.Rows.Clear();
                    string selectdb4 = "select * from GraReq4DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                    table(selectdb4);
                    tableload();
                    break;
                case "毕业要求5指标点":
                    dataview.Rows.Clear();
                    string selectdb5 = "select * from GraReq5DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                    table(selectdb5);
                    tableload();
                    break;
                case "毕业要求6指标点":
                    dataview.Rows.Clear();
                    string selectdb6 = "select * from GraReq6DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                    table(selectdb6);
                    tableload();
                    break;
                case "毕业要求7指标点":
                    dataview.Rows.Clear();
                    string selectdb7 = "select * from GraReq7DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                    table(selectdb7);
                    tableload();
                    break;
                case "毕业要求8指标点":
                    dataview.Rows.Clear();
                    string selectdb8 = "select * from GraReq8DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                    table(selectdb8);
                    tableload();
                    break;
                case "毕业要求9指标点":
                    dataview.Rows.Clear();
                    string selectdb9 = "select * from GraReq9DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                    table(selectdb9);
                    tableload();
                    break;
                case "毕业要求10指标点":
                    dataview.Rows.Clear();
                    string selectdb10 = "select * from GraReq10DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                    table(selectdb10);
                    tableload();
                    break;
                case "毕业要求11指标点":
                    dataview.Rows.Clear();
                    string selectdb11 = "select * from GraReq11DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                    table(selectdb11);
                    tableload();
                    break;
                case "毕业要求12指标点":
                    dataview.Rows.Clear();
                    string selectdb12 = "select * from GraReq12DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                    table(selectdb12);
                    tableload();
                    break;
            }



        }



        //点击某个单元格获取对应行的全部数据到textbox
        private void dataview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textboxindex();
        }


        //添加操作按钮,切换各个控件的属性
        private void btninsert_Click(object sender, EventArgs e)
        {
            foreach (Control control in groupBox1.Controls)
            {

                if (control is TextBox)
                {
                    TextBox t = (TextBox)control;
                    t.ReadOnly = false;
                    t.Text = null;

                }
            }
            _btnInsert.Visible = true;
            btnexit.Visible = true;
            btnfind.Visible = false;
            btninsert.Visible = false;
            btndelete.Visible = false;
            btnpdf.Visible = false;
            btnupdate.Visible = false;
            btnsave.Visible = false;
        }

        //删除操作
        private void btndelete_Click(object sender, EventArgs e)
        {
            string grapoint = textGraPoint.Text.ToString(); //毕业要求指标点内的字符转换成string类型,为空时也可以删除
            string db = this.combox.SelectedItem.ToString();
            switch (db)
            {
                case "毕业要求1指标点":
                    dataview.Rows.Clear();
                    string deletedb1 = "delete from GraReq1DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "' and Grapoint='" + grapoint + "' ";
                    delete(deletedb1);
                    string selectdb1 = "select * from GraReq1DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                    table(selectdb1);
                    tableload();
                    break;
                case "毕业要求2指标点":
                    dataview.Rows.Clear();
                    string deletedb2 = "delete from GraReq2DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "' and Grapoint='" + grapoint + "' ";
                    delete(deletedb2);
                    string selectdb2 = "select * from GraReq2DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                    table(selectdb2);
                    tableload();
                    break;
                case "毕业要求3指标点":
                    dataview.Rows.Clear();
                    string deletedb3 = "delete from GraReq3DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "' and Grapoint='" + grapoint + "' ";
                    delete(deletedb3);
                    string selectdb3 = "select * from GraReq3DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                    table(selectdb3);
                    tableload();
                    break;
                case "毕业要求4指标点":
                    dataview.Rows.Clear();
                    string deletedb4 = "delete from GraReq4DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "' and Grapoint='" + grapoint + "' ";
                    delete(deletedb4);
                    string selectdb4 = "select * from GraReq4DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                    table(selectdb4);
                    tableload();
                    break;
                case "毕业要求5指标点":
                    dataview.Rows.Clear();
                    string deletedb5 = "delete from GraReq5DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "' and Grapoint='" + grapoint + "' ";
                    delete(deletedb5);
                    string selectdb5 = "select * from GraReq5DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                    table(selectdb5);
                    tableload();
                    break;
                case "毕业要求6指标点":
                    dataview.Rows.Clear();
                    string deletedb6 = "delete from GraReq6DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "' and Grapoint='" + grapoint + "' ";
                    delete(deletedb6);
                    string selectdb6 = "select * from GraReq6DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                    table(selectdb6);
                    tableload();
                    break;
                case "毕业要求7指标点":
                    dataview.Rows.Clear();
                    string deletedb7 = "delete from GraReq7DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "' and Grapoint='" + grapoint + "' ";
                    delete(deletedb7);
                    string selectdb7 = "select * from GraReq7DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                    table(selectdb7);
                    tableload();
                    break;
                case "毕业要求8指标点":
                    dataview.Rows.Clear();
                    string deletedb8 = "delete from GraReq8DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "' and Grapoint='" + grapoint + "' ";
                    delete(deletedb8);
                    string selectdb8 = "select * from GraReq8DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                    table(selectdb8);
                    tableload();
                    break;
                case "毕业要求9指标点":
                    dataview.Rows.Clear();
                    string deletedb9 = "delete from GraReq9DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "' and Grapoint='" + grapoint + "' ";
                    delete(deletedb9);
                    string selectdb9 = "select * from GraReq9DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                    table(selectdb9);
                    tableload();
                    break;
                case "毕业要求10指标点":
                    dataview.Rows.Clear();
                    string deletedb10 = "delete from GraReq10DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "' and Grapoint='" + grapoint + "' ";
                    delete(deletedb10);
                    string selectdb10 = "select * from GraReq10DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                    table(selectdb10);
                    tableload();
                    break;
                case "毕业要求11指标点":
                    dataview.Rows.Clear();
                    string deletedb11 = "delete from GraReq11DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "' and Grapoint='" + grapoint + "' ";
                    delete(deletedb11);
                    string selectdb11 = "select * from GraReq11DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                    table(selectdb11);
                    tableload();
                    break;
                case "毕业要求12指标点":
                    dataview.Rows.Clear();
                    string deletedb12 = "delete from GraReq12DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "' and Grapoint='" + grapoint + "' ";
                    delete(deletedb12);
                    string selectdb12 = "select * from GraReq12DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                    table(selectdb12);
                    tableload();
                    break;

            }
        }



        //删除数据库方法
        private void delete(string sql)
        {
            DataConn dc = new DataConn();
            DialogResult result = MessageBox.Show("确认修改此项吗？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result.Equals(DialogResult.Yes))
            {
                int i = dc.Excute(sql);
                if (i > 0)
                {
                    MessageBox.Show("删除成功！");
                }
            }

        }


        //修改按钮
        private void btnupdate_Click(object sender, EventArgs e)
        {
            foreach (Control control in groupBox1.Controls)
            {

                if (control is TextBox)
                {
                    TextBox t = (TextBox)control;
                    t.ReadOnly = false;

                }
            }
            textGraPoint.ReadOnly = true;
            btndelete.Visible = false;
            btnpdf.Visible = false;
            btnfind.Visible = false;
            btninsert.Visible = false;
            btnupdate.Visible = false;
            btnsave.Visible = true;
            btnexit.Visible = true;

        }

        

        //判断是否有重复,如果没有,执行增加、修改操作,如果有,则报错
        private void insertDuplicate(string select, string sql)
        {
            DataConn dc = new DataConn();
            IDataReader dr = dc.Read(select);
            if (dr.Read() == true)
            {
                MessageBox.Show("该信息已存在于数据库,请选择其他操作!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult result = MessageBox.Show("请确认毕业要求指标点无误！","提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
                if(result.Equals(DialogResult.OK))
                {
                int i = dc.Excute(sql);
                    if (i > 0)
                    {
                        MessageBox.Show($" 添加成功!");
                    }
                }

            }


        }

        //添加操作的函数
        private void insert(string sql)
        {
            DataConn dc = new DataConn();
            string db = this.combox.SelectedItem.ToString();
            string grapoint = textGraPoint.Text.ToString();
            switch (db)
            {
                case "毕业要求1指标点":
                    string selectdb1 = "select * from GraReq1DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "' and Grapoint='" + grapoint + "'";
                    insertDuplicate(selectdb1, sql);
                    break;

                case "毕业要求2指标点":
                    string selectdb2 = "select * from GraReq2DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'and Grapoint='" + grapoint + "'";
                    insertDuplicate(selectdb2, sql);
                    break;

                case "毕业要求3指标点":
                    string selectdb3 = "select * from GraReq3DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'and Grapoint='" + grapoint + "'";
                    insertDuplicate(selectdb3, sql);
                    break;
                case "毕业要求4指标点":
                    string selectdb4 = "select * from GraReq4DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'and Grapoint='" + grapoint + "'";
                    insertDuplicate(selectdb4, sql);
                    break;
                case "毕业要求5指标点":
                    string selectdb5 = "select * from GraReq5DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'and Grapoint='" + grapoint + "'";
                    insertDuplicate(selectdb5, sql);
                    break;
                case "毕业要求6指标点":
                    string selectdb6 = "select * from GraReq6DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'and Grapoint='" + grapoint + "'";
                    insertDuplicate(selectdb6, sql);
                    break;
                case "毕业要求7指标点":
                    string selectdb7 = "select * from GraReq7DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'and Grapoint='" + grapoint + "'";
                    insertDuplicate(selectdb7, sql);
                    break;
                case "毕业要求8指标点":
                    string selectdb8 = "select * from GraReq8DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'and Grapoint='" + grapoint + "'";
                    insertDuplicate(selectdb8, sql);
                    break;
                case "毕业要求9指标点":
                    string selectdb9 = "select * from GraReq9DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'and Grapoint='" + grapoint + "'";
                    insertDuplicate(selectdb9, sql);
                    break;
                case "毕业要求10指标点":
                    string selectdb10 = "select * from GraReq10DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'and Grapoint='" + grapoint + "'";
                    insertDuplicate(selectdb10, sql);
                    break;
                case "毕业要求11指标点":
                    string selectdb11 = "select * from GraReq11DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'and Grapoint='" + grapoint + "'";
                    insertDuplicate(selectdb11, sql);
                    break;
                case "毕业要求12指标点":
                    string selectdb12 = "select * from GraReq12DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'and Grapoint='" + grapoint + "'";
                    insertDuplicate(selectdb12, sql);
                    break;
            }


        }



        //如果没有内容重复则修改
        private void update(string sql)
        {
            DataConn dc = new DataConn();
            int i = dc.Excute(sql);
            if (i > 0)
            {
                    MessageBox.Show($" 修改成功");
            }
            

        }


        //查找按钮
        private void btnfind_Click(object sender, EventArgs e)
        {
            winFind.Show();
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



        //退出按钮操作
        private void btnexit_Click(object sender, EventArgs e)
        {
            foreach (Control control in groupBox1.Controls)
            {

                if (control is TextBox)
                {
                    TextBox t = (TextBox)control;
                    t.ReadOnly = true;

                }
            }
            _btnInsert.Visible = false;
            btnexit.Visible = false;
            btnfind.Visible = true;
            btninsert.Visible = true;
            btndelete.Visible = true;
            btnpdf.Visible = true;
            btnupdate.Visible = true;
            btnsave.Visible = false;
            tableload();

        }


        //添加按钮
        private void _btnInsert_Click(object sender, EventArgs e)
        {
            string db = this.combox.SelectedItem.ToString();
            string gra = textGraPoint.Text.ToString();
  
                switch (db)
                {
                    case "毕业要求1指标点":
                        string selectdb1 = "select * from GraReq1DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                        string insert1 = "insert into GraReq1DB (FacultyName,ProfessionName,Grapoint,SupportCourse1,SupportWeight1,SupportCourse2,SupportWeight2,SupportCourse3,SupportWeight3,SupportCourse4,SupportWeight4,SupportCourse5,SupportWeight5,SupportCourse6,SupportWeight6,SupportCourse7,SupportWeight7,SupportCourse8,SupportWeight8,RelateCourse) values ('" + FName.Text + "','" + PName.Text + "','" + gra + "','" + name1.Text + "','" + point1.Text + "','" + name2.Text + "','" + point2.Text + "','" + name3.Text + "','" + point3.Text + "','" + name4.Text + "','" + point4.Text + "','" + name5.Text + "','" + point5.Text + "','" + name6.Text + "','" + point6.Text + "','" + name7.Text + "','" + point7.Text + "','" + name8.Text + "','" + point8.Text + "','" + textRelateCou.Text + "')";
                        insert(insert1);
                        dataview.Rows.Clear();
                        table(selectdb1);
                        break;

                    case "毕业要求2指标点":
                        dataview.Rows.Clear();
                        string selectdb2 = "select * from GraReq2DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                        string insert2 = "insert into GraReq2DB (FacultyName,ProfessionName,Grapoint,SupportCourse1,SupportWeight1,SupportCourse2,SupportWeight2,SupportCourse3,SupportWeight3,SupportCourse4,SupportWeight4,SupportCourse5,SupportWeight5,SupportCourse6,SupportWeight6,SupportCourse7,SupportWeight7,SupportCourse8,SupportWeight8,RelateCourse) values ('" + FName.Text + "','" + PName.Text + "','" + gra + "','" + name1.Text + "','" + point1.Text + "','" + name2.Text + "','" + point2.Text + "','" + name3.Text + "','" + point3.Text + "','" + name4.Text + "','" + point4.Text + "','" + name5.Text + "','" + point5.Text + "','" + name6.Text + "','" + point6.Text + "','" + name7.Text + "','" + point7.Text + "','" + name8.Text + "','" + point8.Text + "','" + textRelateCou.Text + "')";
                        insert(insert2);
                        table(selectdb2);
                        break;
                    case "毕业要求3指标点":
                        dataview.Rows.Clear();
                        string selectdb3 = "select * from GraReq3DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                        string insert3 = "insert into GraReq3DB (FacultyName,ProfessionName,Grapoint,SupportCourse1,SupportWeight1,SupportCourse2,SupportWeight2,SupportCourse3,SupportWeight3,SupportCourse4,SupportWeight4,SupportCourse5,SupportWeight5,SupportCourse6,SupportWeight6,SupportCourse7,SupportWeight7,SupportCourse8,SupportWeight8,RelateCourse) values ('" + FName.Text + "','" + PName.Text + "','" + gra + "','" + name1.Text + "','" + point1.Text + "','" + name2.Text + "','" + point2.Text + "','" + name3.Text + "','" + point3.Text + "','" + name4.Text + "','" + point4.Text + "','" + name5.Text + "','" + point5.Text + "','" + name6.Text + "','" + point6.Text + "','" + name7.Text + "','" + point7.Text + "','" + name8.Text + "','" + point8.Text + "','" + textRelateCou.Text + "')";
                        insert(insert3);
                        table(selectdb3);
                        break;
                    case "毕业要求4指标点":
                        dataview.Rows.Clear();
                        string selectdb4 = "select * from GraReq4DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                        string insert4 = "insert into GraReq4DB (FacultyName,ProfessionName,Grapoint,SupportCourse1,SupportWeight1,SupportCourse2,SupportWeight2,SupportCourse3,SupportWeight3,SupportCourse4,SupportWeight4,SupportCourse5,SupportWeight5,SupportCourse6,SupportWeight6,SupportCourse7,SupportWeight7,SupportCourse8,SupportWeight8,RelateCourse) values ('" + FName.Text + "','" + PName.Text + "','" + gra + "','" + name1.Text + "','" + point1.Text + "','" + name2.Text + "','" + point2.Text + "','" + name3.Text + "','" + point3.Text + "','" + name4.Text + "','" + point4.Text + "','" + name5.Text + "','" + point5.Text + "','" + name6.Text + "','" + point6.Text + "','" + name7.Text + "','" + point7.Text + "','" + name8.Text + "','" + point8.Text + "','" + textRelateCou.Text + "')";
                        insert(insert4);
                        table(selectdb4);
                        break;
                    case "毕业要求5指标点":
                        dataview.Rows.Clear();
                        string selectdb5 = "select * from GraReq5DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                        string insert5 = "insert into GraReq5DB (FacultyName,ProfessionName,Grapoint,SupportCourse1,SupportWeight1,SupportCourse2,SupportWeight2,SupportCourse3,SupportWeight3,SupportCourse4,SupportWeight4,SupportCourse5,SupportWeight5,SupportCourse6,SupportWeight6,SupportCourse7,SupportWeight7,SupportCourse8,SupportWeight8,RelateCourse) values ('" + FName.Text + "','" + PName.Text + "','" + gra + "','" + name1.Text + "','" + point1.Text + "','" + name2.Text + "','" + point2.Text + "','" + name3.Text + "','" + point3.Text + "','" + name4.Text + "','" + point4.Text + "','" + name5.Text + "','" + point5.Text + "','" + name6.Text + "','" + point6.Text + "','" + name7.Text + "','" + point7.Text + "','" + name8.Text + "','" + point8.Text + "','" + textRelateCou.Text + "')";
                        insert(insert5);
                        table(selectdb5);
                        break;
                    case "毕业要求6指标点":
                        dataview.Rows.Clear();
                        string selectdb6 = "select * from GraReq6DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                        string insert6 = "insert into GraReq6DB (FacultyName,ProfessionName,Grapoint,SupportCourse1,SupportWeight1,SupportCourse2,SupportWeight2,SupportCourse3,SupportWeight3,SupportCourse4,SupportWeight4,SupportCourse5,SupportWeight5,SupportCourse6,SupportWeight6,SupportCourse7,SupportWeight7,SupportCourse8,SupportWeight8,RelateCourse) values ('" + FName.Text + "','" + PName.Text + "','" + gra + "','" + name1.Text + "','" + point1.Text + "','" + name2.Text + "','" + point2.Text + "','" + name3.Text + "','" + point3.Text + "','" + name4.Text + "','" + point4.Text + "','" + name5.Text + "','" + point5.Text + "','" + name6.Text + "','" + point6.Text + "','" + name7.Text + "','" + point7.Text + "','" + name8.Text + "','" + point8.Text + "','" + textRelateCou.Text + "')";
                        insert(insert6);
                        table(selectdb6);
                        break;
                    case "毕业要求7指标点":
                        dataview.Rows.Clear();
                        string selectdb7 = "select * from GraReq7DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                        string insert7 = "insert into GraReq7DB (FacultyName,ProfessionName,Grapoint,SupportCourse1,SupportWeight1,SupportCourse2,SupportWeight2,SupportCourse3,SupportWeight3,SupportCourse4,SupportWeight4,SupportCourse5,SupportWeight5,SupportCourse6,SupportWeight6,SupportCourse7,SupportWeight7,SupportCourse8,SupportWeight8,RelateCourse) values ('" + FName.Text + "','" + PName.Text + "','" + gra + "','" + name1.Text + "','" + point1.Text + "','" + name2.Text + "','" + point2.Text + "','" + name3.Text + "','" + point3.Text + "','" + name4.Text + "','" + point4.Text + "','" + name5.Text + "','" + point5.Text + "','" + name6.Text + "','" + point6.Text + "','" + name7.Text + "','" + point7.Text + "','" + name8.Text + "','" + point8.Text + "','" + textRelateCou.Text + "')";
                        insert(insert7);
                        table(selectdb7);
                        break;
                    case "毕业要求8指标点":
                        dataview.Rows.Clear();
                        string selectdb8 = "select * from GraReq8DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                        string insert8 = "insert into GraReq8DB (FacultyName,ProfessionName,Grapoint,SupportCourse1,SupportWeight1,SupportCourse2,SupportWeight2,SupportCourse3,SupportWeight3,SupportCourse4,SupportWeight4,SupportCourse5,SupportWeight5,SupportCourse6,SupportWeight6,SupportCourse7,SupportWeight7,SupportCourse8,SupportWeight8,RelateCourse) values ('" + FName.Text + "','" + PName.Text + "','" + gra + "','" + name1.Text + "','" + point1.Text + "','" + name2.Text + "','" + point2.Text + "','" + name3.Text + "','" + point3.Text + "','" + name4.Text + "','" + point4.Text + "','" + name5.Text + "','" + point5.Text + "','" + name6.Text + "','" + point6.Text + "','" + name7.Text + "','" + point7.Text + "','" + name8.Text + "','" + point8.Text + "','" + textRelateCou.Text + "')";
                        insert(insert8);
                        table(selectdb8);
                        break;
                    case "毕业要求9指标点":
                        dataview.Rows.Clear();
                        string selectdb9 = "select * from GraReq9DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                        string insert9 = "insert into GraReq9DB (FacultyName,ProfessionName,Grapoint,SupportCourse1,SupportWeight1,SupportCourse2,SupportWeight2,SupportCourse3,SupportWeight3,SupportCourse4,SupportWeight4,SupportCourse5,SupportWeight5,SupportCourse6,SupportWeight6,SupportCourse7,SupportWeight7,SupportCourse8,SupportWeight8,RelateCourse) values ('" + FName.Text + "','" + PName.Text + "','" + gra + "','" + name1.Text + "','" + point1.Text + "','" + name2.Text + "','" + point2.Text + "','" + name3.Text + "','" + point3.Text + "','" + name4.Text + "','" + point4.Text + "','" + name5.Text + "','" + point5.Text + "','" + name6.Text + "','" + point6.Text + "','" + name7.Text + "','" + point7.Text + "','" + name8.Text + "','" + point8.Text + "','" + textRelateCou.Text + "')";
                        insert(insert9);
                        table(selectdb9);
                        break;
                    case "毕业要求10指标点":
                        dataview.Rows.Clear();
                        string selectdb10 = "select * from GraReq10DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                        string insert10 = "insert into GraReq10DB (FacultyName,ProfessionName,Grapoint,SupportCourse1,SupportWeight1,SupportCourse2,SupportWeight2,SupportCourse3,SupportWeight3,SupportCourse4,SupportWeight4,SupportCourse5,SupportWeight5,SupportCourse6,SupportWeight6,SupportCourse7,SupportWeight7,SupportCourse8,SupportWeight8,RelateCourse) values ('" + FName.Text + "','" + PName.Text + "','" + gra + "','" + name1.Text + "','" + point1.Text + "','" + name2.Text + "','" + point2.Text + "','" + name3.Text + "','" + point3.Text + "','" + name4.Text + "','" + point4.Text + "','" + name5.Text + "','" + point5.Text + "','" + name6.Text + "','" + point6.Text + "','" + name7.Text + "','" + point7.Text + "','" + name8.Text + "','" + point8.Text + "','" + textRelateCou.Text + "')";
                        insert(insert10);
                        table(selectdb10);
                        break;
                    case "毕业要求11指标点":
                        dataview.Rows.Clear();
                        string selectdb11 = "select * from GraReq11DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                        string insert11 = "insert into GraReq11DB (FacultyName,ProfessionName,Grapoint,SupportCourse1,SupportWeight1,SupportCourse2,SupportWeight2,SupportCourse3,SupportWeight3,SupportCourse4,SupportWeight4,SupportCourse5,SupportWeight5,SupportCourse6,SupportWeight6,SupportCourse7,SupportWeight7,SupportCourse8,SupportWeight8,RelateCourse) values ('" + FName.Text + "','" + PName.Text + "','" + gra + "','" + name1.Text + "','" + point1.Text + "','" + name2.Text + "','" + point2.Text + "','" + name3.Text + "','" + point3.Text + "','" + name4.Text + "','" + point4.Text + "','" + name5.Text + "','" + point5.Text + "','" + name6.Text + "','" + point6.Text + "','" + name7.Text + "','" + point7.Text + "','" + name8.Text + "','" + point8.Text + "','" + textRelateCou.Text + "')";
                        insert(insert11);
                        table(selectdb11);
                        break;
                    case "毕业要求12指标点":
                        dataview.Rows.Clear();
                        string selectdb12 = "select * from GraReq12DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                        string insert12 = "insert into GraReq12DB (FacultyName,ProfessionName,Grapoint,SupportCourse1,SupportWeight1,SupportCourse2,SupportWeight2,SupportCourse3,SupportWeight3,SupportCourse4,SupportWeight4,SupportCourse5,SupportWeight5,SupportCourse6,SupportWeight6,SupportCourse7,SupportWeight7,SupportCourse8,SupportWeight8,RelateCourse) values ('" + FName.Text + "','" + PName.Text + "','" + gra + "','" + name1.Text + "','" + point1.Text + "','" + name2.Text + "','" + point2.Text + "','" + name3.Text + "','" + point3.Text + "','" + name4.Text + "','" + point4.Text + "','" + name5.Text + "','" + point5.Text + "','" + name6.Text + "','" + point6.Text + "','" + name7.Text + "','" + point7.Text + "','" + name8.Text + "','" + point8.Text + "','" + textRelateCou.Text + "')";
                        insert(insert12);
                        table(selectdb12);
                        break;
                }
            

        }





        //修改选中的数据库
        private void btnsave_Click(object sender, EventArgs e)
        {
            string db = this.combox.SelectedItem.ToString();
            string gra = textGraPoint.Text.ToString();

                switch (db)
                {
                    case "毕业要求1指标点":
                        string selectdb1 = "select * from GraReq1DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                        string update1 = "update GraReq1DB set SupportCourse1='" + name1.Text + "',SupportCourse2='" + name2.Text + "',SupportCourse3='" + name3.Text + "',SupportCourse4='" + name4.Text + "',SupportCourse5='" + name5.Text + "',SupportCourse6='" + name6.Text + "',SupportCourse7='" + name7.Text + "',SupportCourse8='" + name8.Text + "',SupportWeight1='" + point1.Text + "',SupportWeight2='" + point2.Text + "',SupportWeight3='" + point3.Text + "',SupportWeight4='" + point4.Text + "',SupportWeight5='" + point5.Text + "',SupportWeight6='" + point6.Text + "',SupportWeight7='" + point7.Text + "',SupportWeight8='" + point8.Text + "',RelateCourse='" + textRelateCou.Text + "' where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "' and Grapoint='" + gra + "'";
                        update(update1);
                        dataview.Rows.Clear();
                        table(selectdb1);
                        break;

                    case "毕业要求2指标点":
                        dataview.Rows.Clear();
                        string selectdb2 = "select * from GraReq2DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                        string update2 = "update GraReq2DB set SupportCourse1='" + name1.Text + "',SupportCourse2='" + name2.Text + "',SupportCourse3='" + name3.Text + "',SupportCourse4='" + name4.Text + "',SupportCourse5='" + name5.Text + "',SupportCourse6='" + name6.Text + "',SupportCourse7='" + name7.Text + "',SupportCourse8='" + name8.Text + "',SupportWeight1='" + point1.Text + "',SupportWeight2='" + point2.Text + "',SupportWeight3='" + point3.Text + "',SupportWeight4='" + point4.Text + "',SupportWeight5='" + point5.Text + "',SupportWeight6='" + point6.Text + "',SupportWeight7='" + point7.Text + "',SupportWeight8='" + point8.Text + "',RelateCourse='" + textRelateCou.Text + "' where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "' and Grapoint='" + gra + "'";
                        update(update2);
                        table(selectdb2);
                        break;
                    case "毕业要求3指标点":
                        dataview.Rows.Clear();
                        string selectdb3 = "select * from GraReq3DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                        string update3 = "update GraReq3DB set SupportCourse1='" + name1.Text + "',SupportCourse2='" + name2.Text + "',SupportCourse3='" + name3.Text + "',SupportCourse4='" + name4.Text + "',SupportCourse5='" + name5.Text + "',SupportCourse6='" + name6.Text + "',SupportCourse7='" + name7.Text + "',SupportCourse8='" + name8.Text + "',SupportWeight1='" + point1.Text + "',SupportWeight2='" + point2.Text + "',SupportWeight3='" + point3.Text + "',SupportWeight4='" + point4.Text + "',SupportWeight5='" + point5.Text + "',SupportWeight6='" + point6.Text + "',SupportWeight7='" + point7.Text + "',SupportWeight8='" + point8.Text + "',RelateCourse='" + textRelateCou.Text + "' where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "' and Grapoint='" + gra + "'";
                        update(update3);
                        table(selectdb3);
                        break;
                    case "毕业要求4指标点":
                        dataview.Rows.Clear();
                        string selectdb4 = "select * from GraReq4DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                        string update4 = "update GraReq4DB set SupportCourse1='" + name1.Text + "',SupportCourse2='" + name2.Text + "',SupportCourse3='" + name3.Text + "',SupportCourse4='" + name4.Text + "',SupportCourse5='" + name5.Text + "',SupportCourse6='" + name6.Text + "',SupportCourse7='" + name7.Text + "',SupportCourse8='" + name8.Text + "',SupportWeight1='" + point1.Text + "',SupportWeight2='" + point2.Text + "',SupportWeight3='" + point3.Text + "',SupportWeight4='" + point4.Text + "',SupportWeight5='" + point5.Text + "',SupportWeight6='" + point6.Text + "',SupportWeight7='" + point7.Text + "',SupportWeight8='" + point8.Text + "',RelateCourse='" + textRelateCou.Text + "' where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "' and Grapoint='" + gra + "'";
                        update(update4);
                        table(selectdb4);
                        break;
                    case "毕业要求5指标点":
                        dataview.Rows.Clear();
                        string selectdb5 = "select * from GraReq5DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                        string update5 = "update GraReq5DB set SupportCourse1='" + name1.Text + "',SupportCourse2='" + name2.Text + "',SupportCourse3='" + name3.Text + "',SupportCourse4='" + name4.Text + "',SupportCourse5='" + name5.Text + "',SupportCourse6='" + name6.Text + "',SupportCourse7='" + name7.Text + "',SupportCourse8='" + name8.Text + "',SupportWeight1='" + point1.Text + "',SupportWeight2='" + point2.Text + "',SupportWeight3='" + point3.Text + "',SupportWeight4='" + point4.Text + "',SupportWeight5='" + point5.Text + "',SupportWeight6='" + point6.Text + "',SupportWeight7='" + point7.Text + "',SupportWeight8='" + point8.Text + "',RelateCourse='" + textRelateCou.Text + "' where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "' and Grapoint='" + gra + "'";
                        update(update5);
                        table(selectdb5);
                        break;
                    case "毕业要求6指标点":
                        dataview.Rows.Clear();
                        string selectdb6 = "select * from GraReq6DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                        string update6 = "update GraReq6DB set SupportCourse1='" + name1.Text + "',SupportCourse2='" + name2.Text + "',SupportCourse3='" + name3.Text + "',SupportCourse4='" + name4.Text + "',SupportCourse5='" + name5.Text + "',SupportCourse6='" + name6.Text + "',SupportCourse7='" + name7.Text + "',SupportCourse8='" + name8.Text + "',SupportWeight1='" + point1.Text + "',SupportWeight2='" + point2.Text + "',SupportWeight3='" + point3.Text + "',SupportWeight4='" + point4.Text + "',SupportWeight5='" + point5.Text + "',SupportWeight6='" + point6.Text + "',SupportWeight7='" + point7.Text + "',SupportWeight8='" + point8.Text + "',RelateCourse='" + textRelateCou.Text + "' where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "' and Grapoint='" + gra + "'";
                        update(update6);
                        table(selectdb6);
                        break;
                    case "毕业要求7指标点":
                        dataview.Rows.Clear();
                        string selectdb7 = "select * from GraReq7DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                        string update7 = "update GraReq7DB set SupportCourse1='" + name1.Text + "',SupportCourse2='" + name2.Text + "',SupportCourse3='" + name3.Text + "',SupportCourse4='" + name4.Text + "',SupportCourse5='" + name5.Text + "',SupportCourse6='" + name6.Text + "',SupportCourse7='" + name7.Text + "',SupportCourse8='" + name8.Text + "',SupportWeight1='" + point1.Text + "',SupportWeight2='" + point2.Text + "',SupportWeight3='" + point3.Text + "',SupportWeight4='" + point4.Text + "',SupportWeight5='" + point5.Text + "',SupportWeight6='" + point6.Text + "',SupportWeight7='" + point7.Text + "',SupportWeight8='" + point8.Text + "',RelateCourse='" + textRelateCou.Text + "' where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "' and Grapoint='" + gra + "'";
                        update(update7);
                        table(selectdb7);
                        break;
                    case "毕业要求8指标点":
                        dataview.Rows.Clear();
                        string selectdb8 = "select * from GraReq8DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                        string update8 = "update GraReq8DB set SupportCourse1='" + name1.Text + "',SupportCourse2='" + name2.Text + "',SupportCourse3='" + name3.Text + "',SupportCourse4='" + name4.Text + "',SupportCourse5='" + name5.Text + "',SupportCourse6='" + name6.Text + "',SupportCourse7='" + name7.Text + "',SupportCourse8='" + name8.Text + "',SupportWeight1='" + point1.Text + "',SupportWeight2='" + point2.Text + "',SupportWeight3='" + point3.Text + "',SupportWeight4='" + point4.Text + "',SupportWeight5='" + point5.Text + "',SupportWeight6='" + point6.Text + "',SupportWeight7='" + point7.Text + "',SupportWeight8='" + point8.Text + "',RelateCourse='" + textRelateCou.Text + "' where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "' and Grapoint='" + gra + "'";
                        update(update8);
                        table(selectdb8);
                        break;
                    case "毕业要求9指标点":
                        dataview.Rows.Clear();
                        string selectdb9 = "select * from GraReq9DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                        string update9 = "update GraReq9DB set SupportCourse1='" + name1.Text + "',SupportCourse2='" + name2.Text + "',SupportCourse3='" + name3.Text + "',SupportCourse4='" + name4.Text + "',SupportCourse5='" + name5.Text + "',SupportCourse6='" + name6.Text + "',SupportCourse7='" + name7.Text + "',SupportCourse8='" + name8.Text + "',SupportWeight1='" + point1.Text + "',SupportWeight2='" + point2.Text + "',SupportWeight3='" + point3.Text + "',SupportWeight4='" + point4.Text + "',SupportWeight5='" + point5.Text + "',SupportWeight6='" + point6.Text + "',SupportWeight7='" + point7.Text + "',SupportWeight8='" + point8.Text + "',RelateCourse='" + textRelateCou.Text + "' where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "' and Grapoint='" + gra + "'";
                        update(update9);
                        table(selectdb9);
                        break;
                    case "毕业要求10指标点":
                        dataview.Rows.Clear();
                        string selectdb10 = "select * from GraReq10DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                        string update10 = "update GraReq10DB set SupportCourse1='" + name1.Text + "',SupportCourse2='" + name2.Text + "',SupportCourse3='" + name3.Text + "',SupportCourse4='" + name4.Text + "',SupportCourse5='" + name5.Text + "',SupportCourse6='" + name6.Text + "',SupportCourse7='" + name7.Text + "',SupportCourse8='" + name8.Text + "',SupportWeight1='" + point1.Text + "',SupportWeight2='" + point2.Text + "',SupportWeight3='" + point3.Text + "',SupportWeight4='" + point4.Text + "',SupportWeight5='" + point5.Text + "',SupportWeight6='" + point6.Text + "',SupportWeight7='" + point7.Text + "',SupportWeight8='" + point8.Text + "',RelateCourse='" + textRelateCou.Text + "' where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "' and Grapoint='" + gra + "'";
                        update(update10);
                        table(selectdb10);
                        break;
                    case "毕业要求11指标点":
                        dataview.Rows.Clear();
                        string selectdb11 = "select * from GraReq11DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                        string update11 = "update GraReq11DB set SupportCourse1='" + name1.Text + "',SupportCourse2='" + name2.Text + "',SupportCourse3='" + name3.Text + "',SupportCourse4='" + name4.Text + "',SupportCourse5='" + name5.Text + "',SupportCourse6='" + name6.Text + "',SupportCourse7='" + name7.Text + "',SupportCourse8='" + name8.Text + "',SupportWeight1='" + point1.Text + "',SupportWeight2='" + point2.Text + "',SupportWeight3='" + point3.Text + "',SupportWeight4='" + point4.Text + "',SupportWeight5='" + point5.Text + "',SupportWeight6='" + point6.Text + "',SupportWeight7='" + point7.Text + "',SupportWeight8='" + point8.Text + "',RelateCourse='" + textRelateCou.Text + "' where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "' and Grapoint='" + gra + "'";
                        update(update11);
                        table(selectdb11);
                        break;
                    case "毕业要求12指标点":
                        dataview.Rows.Clear();
                        string selectdb12 = "select * from GraReq12DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                        string update12 = "update GraReq12DB set SupportCourse1='" + name1.Text + "',SupportCourse2='" + name2.Text + "',SupportCourse3='" + name3.Text + "',SupportCourse4='" + name4.Text + "',SupportCourse5='" + name5.Text + "',SupportCourse6='" + name6.Text + "',SupportCourse7='" + name7.Text + "',SupportCourse8='" + name8.Text + "',SupportWeight1='" + point1.Text + "',SupportWeight2='" + point2.Text + "',SupportWeight3='" + point3.Text + "',SupportWeight4='" + point4.Text + "',SupportWeight5='" + point5.Text + "',SupportWeight6='" + point6.Text + "',SupportWeight7='" + point7.Text + "',SupportWeight8='" + point8.Text + "',RelateCourse='" + textRelateCou.Text + "' where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "' and Grapoint='" + gra + "'";
                        update(update12);
                        table(selectdb12);
                        break;
                }
            
        }

        private void btnpdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "PDF(*.pdf)|*.pdf";
            string filename = DateTime.Now.ToString("yyyyMMddhhmmss");
            savefile.FileName = filename;
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    BaseFont bf = BaseFont.CreateFont("C:\\Windows\\Fonts\\simhei.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                    PdfPTable pdf = new PdfPTable(dataview.Columns.Count);
                    pdf.DefaultCell.Padding = 3;
                    pdf.WidthPercentage = 100;
                    pdf.HorizontalAlignment = Element.ALIGN_LEFT;
                    iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 9, iTextSharp.text.Font.NORMAL);

                    foreach (DataGridViewColumn column in dataview.Columns)
                    {
                        PdfPCell _pdfcell = new PdfPCell(new Phrase(column.HeaderText, text));
                        pdf.AddCell(_pdfcell);
                    }

                    
                    //string dr = combox.SelectedItem.ToString();
                    foreach(var dr in combox.Items)
                    {
                        switch (dr)
                        {
                            case "毕业要求1指标点":
                                dataview.Rows.Clear();
                                string selectdb1 = "select * from GraReq1DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                                table(selectdb1);
                                tableload();
                                foreach (DataGridViewRow rows in dataview.Rows)
                                    foreach (DataGridViewCell cells in rows.Cells)
                                    {
                                        pdf.AddCell(new Phrase(cells.Value.ToString(), text));
                                    }
                                break;

                            case "毕业要求2指标点":
                                dataview.Rows.Clear();
                                string selectdb2 = "select * from GraReq2DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                                table(selectdb2);
                                tableload();
                                foreach (DataGridViewRow rows in dataview.Rows)
                                    foreach (DataGridViewCell cells in rows.Cells)
                                    {
                                        pdf.AddCell(new Phrase(cells.Value.ToString(), text));
                                    }
                                break;

                            case "毕业要求3指标点":
                                dataview.Rows.Clear();
                                string selectdb3 = "select * from GraReq3DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                                table(selectdb3);
                                tableload();
                                foreach (DataGridViewRow rows in dataview.Rows)
                                    foreach (DataGridViewCell cells in rows.Cells)
                                    {
                                        pdf.AddCell(new Phrase(cells.Value.ToString(), text));
                                    }
                                break;

                            case "毕业要求4指标点":
                                dataview.Rows.Clear();
                                string selectdb4 = "select * from GraReq4DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                                table(selectdb4);
                                tableload();
                                foreach (DataGridViewRow rows in dataview.Rows)
                                    foreach (DataGridViewCell cells in rows.Cells)
                                    {
                                        pdf.AddCell(new Phrase(cells.Value.ToString(), text));
                                    }
                                break;

                            case "毕业要求5指标点":
                                dataview.Rows.Clear();
                                string selectdb5 = "select * from GraReq5DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                                table(selectdb5);
                                tableload();
                                foreach (DataGridViewRow rows in dataview.Rows)
                                    foreach (DataGridViewCell cells in rows.Cells)
                                    {
                                        pdf.AddCell(new Phrase(cells.Value.ToString(), text));
                                    }
                                break;

                            case "毕业要求6指标点":
                                dataview.Rows.Clear();
                                string selectdb6 = "select * from GraReq6DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                                table(selectdb6);
                                tableload();
                                foreach (DataGridViewRow rows in dataview.Rows)
                                    foreach (DataGridViewCell cells in rows.Cells)
                                    {
                                        pdf.AddCell(new Phrase(cells.Value.ToString(), text));
                                    }
                                break;

                            case "毕业要求7指标点":
                                dataview.Rows.Clear();
                                string selectdb7 = "select * from GraReq7DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                                table(selectdb7);
                                tableload();
                                foreach (DataGridViewRow rows in dataview.Rows)
                                    foreach (DataGridViewCell cells in rows.Cells)
                                    {
                                        pdf.AddCell(new Phrase(cells.Value.ToString(), text));
                                    }
                                break;

                            case "毕业要求8指标点":
                                dataview.Rows.Clear();
                                string selectdb8 = "select * from GraReq8DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                                table(selectdb8);
                                tableload();
                                foreach (DataGridViewRow rows in dataview.Rows)
                                    foreach (DataGridViewCell cells in rows.Cells)
                                    {
                                        pdf.AddCell(new Phrase(cells.Value.ToString(), text));
                                    }
                                break;

                            case "毕业要求9指标点":
                                dataview.Rows.Clear();
                                string selectdb9 = "select * from GraReq9DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                                table(selectdb9);
                                tableload();
                                foreach (DataGridViewRow rows in dataview.Rows)
                                    foreach (DataGridViewCell cells in rows.Cells)
                                    {
                                        pdf.AddCell(new Phrase(cells.Value.ToString(), text));
                                    }
                                break;

                            case "毕业要求10指标点":
                                dataview.Rows.Clear();
                                string selectdb10 = "select * from GraReq10DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                                table(selectdb10);
                                tableload();
                                foreach (DataGridViewRow rows in dataview.Rows)
                                    foreach (DataGridViewCell cells in rows.Cells)
                                    {
                                        pdf.AddCell(new Phrase(cells.Value.ToString(), text));
                                    }
                                break;

                            case "毕业要求11指标点":
                                dataview.Rows.Clear();
                                string selectdb11 = "select * from GraReq11DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                                table(selectdb11);
                                tableload();
                                foreach (DataGridViewRow rows in dataview.Rows)
                                    foreach (DataGridViewCell cells in rows.Cells)
                                    {
                                        pdf.AddCell(new Phrase(cells.Value.ToString(), text));
                                    }
                                break;
                            case "毕业要求12指标点":
                                dataview.Rows.Clear();
                                string selectdb12 = "select * from GraReq12DB where FacultyName='" + FName.Text + "' and ProfessionName='" + PName.Text + "'";
                                table(selectdb12);
                                tableload();
                                foreach (DataGridViewRow rows in dataview.Rows)
                                    foreach (DataGridViewCell cells in rows.Cells)
                                    {
                                        pdf.AddCell(new Phrase(cells.Value.ToString(), text));
                                    }
                                break;
                        }
                    }
 

                    using (FileStream _filestream = new FileStream(savefile.FileName, FileMode.Create))
                    {
                        Document newpdf = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);
                        PdfWriter.GetInstance(newpdf, _filestream);
                        newpdf.Open();
                        newpdf.Add(pdf);
                        newpdf.Close();
                        _filestream.Close();
                    }
                    MessageBox.Show("导出成功！", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error :" + ex.Message);
                }
            }
        

    }
    }
}
