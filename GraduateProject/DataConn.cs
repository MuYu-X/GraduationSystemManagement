using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GraduateProject
{
    class DataConn
    {
        private static readonly string CourseManage = ConfigurationManager.ConnectionStrings
            ["GraduateProject.Properties.Settings.CMConnectionString"].ConnectionString;
       
        public  SqlConnection connection()               //数据库连接
        {
          
            SqlConnection cm = new SqlConnection(CourseManage);
            cm.Open();
            return cm;
        }

        public SqlCommand command(string sql)           //数据库操作
        {
            SqlCommand cm = new SqlCommand(sql, connection());
            return cm;
        }

        public int Excute(string sql)               //增删改
        {
            int count;
            count = command(sql).ExecuteNonQuery();

            return count;
        }


        public SqlDataReader Read(string sql)       //执行查询，返回sqlDataReader
        {

               return command(sql).ExecuteReader();

        }


        public DataTable GetTable(string sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand= command(sql);
            adapter.Fill(dt);

            return dt;

        }
      
     
   
    }
}
