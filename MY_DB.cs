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
            /*            SqlConnectionStringBuilder con = new SqlConnectionStringBuilder();
                        con.DataSource = "22110406.database.windows.net";
                        con.UserID = "sondang";
                        con.Password = "son22110406@";
                        con.InitialCatalog = "sonhuynh";
                        try
                        {
                            if(sqlCon == null)
                            {
                                sqlCon = new SqlConnection(con.ConnectionString);
                            }
                        }
                        catch(Exception ex)
                        {
                            throw;
                        }*/
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
