﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GZPIAnswer
{
    public class Connection
    {
        private DataSet dsall;
        private static String ConString = "database=answer;Password=;UserName=root;server=119.23.48.137;Port=3306;charset=utf8";
        private MySqlConnection conn;
        private MySqlDataAdapter mdap;
        
        /// <summary>
        /// 跟新数据库中的次数和使用的次数
        /// </summary>
        /// <param name="name">用户名</param>
        public void UpdateDatabase(string name)
        {
            conn = new MySqlConnection(ConString);
            conn.Open();
            try
            {
                MySqlCommand commandChoice =
                    new MySqlCommand(
                        "UPDATE  tb_user SET Number=Number-1,ExperCount=ExperCount+1  WHERE UserName='" + name + "'", conn);
                commandChoice.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {

            }

        }

        public int QueryNunber(string name)
        {
            int number = 0;
            try
            {
                conn = new MySqlConnection(ConString);
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT Number FROM tb_user WHERE UserName='" + name + "'", conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        number = reader.GetInt32(0);
                    }
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception e)
            {
              
            }
            return number;
        }

        public int Login(string userName,string password)
        {
            int number = 0;
            try
            {
                conn = new MySqlConnection(ConString);
                conn.Open();
                var queryString = "SELECT Number FROM tb_user WHERE UserName='" + userName + "' AND Password = '" + password +
                                  "'";
                MySqlCommand command = new MySqlCommand("SELECT Number FROM tb_user WHERE UserName='" + userName + "' AND Password = '"+ password + "'", conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        number = reader.GetInt32(0);
                    }
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception e)
            {

            }
            return number;
        }

        public int QueryMacCode(string macCode)
        {
            int number = -1;
            try
            {
                conn = new MySqlConnection(ConString);
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT id FROM tb_maccode WHERE MacCode='" + macCode + "'", conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        number = reader.GetInt32(0);
                    }
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception e)
            {
                number = 0;
                return number;
            }
            finally
            {

            }
            return number;
        }
        public int InsertMacCode(string macCode)
        {
            int number = 0;
            try
            {
                conn = new MySqlConnection(ConString);
                conn.Open();
                var creatTime = DateTime.Now;
                var sql = string.Format("insert into tb_maccode (MacCode,createTime) VALUES ('{0}','{1}')", macCode, creatTime);
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        number = reader.GetInt32(0);
                    }
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception e)
            {

            }
            return number;
        }

    }
}
