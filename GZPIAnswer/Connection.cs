using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
namespace GZPIAnswer
{
    class Connection
    {
        private DataSet dsall;
        //private static String mysqlcon = "Data Source=MySQL;database=onepc;Password=;User ID=root;Location=192.168.1.168;charset=utf8";
        private static String ConString = "database=answer;Password=qwe123456qwe;User ID=root;server=112.74.96.222;charset=utf8";
        private MySqlConnection conn = new MySqlConnection(ConString);
        private MySqlDataAdapter mdap;

        public void Connecte()
        {
            try
            {
               
                mdap = new MySqlDataAdapter("select * from user", conn);
                dsall = new DataSet();
                mdap.Fill(dsall, "hard");              
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
            finally
            {

            }
            
        }
    }
}
