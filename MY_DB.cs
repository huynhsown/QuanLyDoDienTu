using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QuanLyDoDienTu
{
    public class MY_DB
    {
        private String sqlStr = @"Data Source=LAPTOP-DLNV3RL7\VANTHUONG;Initial Catalog=HQTCSDL;Integrated Security=True";
        private SqlConnection sqlCon = null;

        public MY_DB() 
        {
            try
            {
                if (sqlCon == null)
                {
                    sqlCon = new SqlConnection(sqlStr);

                }
            }
            catch
            {
                throw;
            }
        
        }

        public SqlConnection getConnection
        {
            get { return sqlCon; }
        }

        public void openConnection()
        {
            if (sqlCon.State == System.Data.ConnectionState.Closed)
            {
                sqlCon.Open();
            }
        }

        public void closeConnection()
        {

            if (sqlCon.State == System.Data.ConnectionState.Open)
            {
                sqlCon.Close();
            }
        }
    }
}
