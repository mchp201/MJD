using System;
using System.Collections;
using System.Configuration;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;

namespace MJD.COMMON
{
    public class MYSQLHELPER
    {
        public static string connstr = "Database=MJD;Data Source=localhost;User Id='root';Password='mchp2009';pooling=true;Minimum Pool Size=5;Maximum Pool Size=10;CharSet=utf8;port=3306;Connect Timeout=3600";
        
        public static MySqlRtMsg ExecuteNonQueryProcedure(string procName, params MySqlPara[] cmdParms)
        {
            List<MySqlParameter> pArr = new List<MySqlParameter>();
            
            if (cmdParms != null)
            {
                foreach (MySqlPara parm in cmdParms)
                {
                    pArr.Add(parm.GetMySqlParameter());
                }
            }
            
            return ExecuteNonQueryProcedure(procName, pArr.ToArray());
        }

        /// <summary>
        ///  给定连接的数据库用假设参数执行一个sql命令（不返回数据集）
        /// </summary>
        /// <param name="procName">一个有效的连接字符串</param>
        /// <param name="cmdParms">命令类型(存储过程, 文本, 等等)</param>
        /// <returns>执行命令所影响的行数</returns>
        private static MySqlRtMsg ExecuteNonQueryProcedure(string procName, params MySqlParameter[] cmdParms)
        {
            MySqlRtMsg rtMsg = new MySqlRtMsg();

            using (MySqlConnection conn = new MySqlConnection(connstr))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = procName;
                cmd.CommandType = CommandType.StoredProcedure;

                if (cmdParms != null)
                {
                    foreach (MySqlParameter parm in cmdParms)
                        cmd.Parameters.Add(parm);
                }

                MySqlParameter Total = new MySqlParameter();
                Total.ParameterName = "Total";
                Total.Direction = ParameterDirection.Output;
                Total.DbType = DbType.Int32;
                cmd.Parameters.Add(Total);

                MySqlParameter errCode = new MySqlParameter();
                errCode.ParameterName = "ErrCode";
                errCode.Direction = ParameterDirection.Output;
                errCode.DbType = DbType.Int32;
                cmd.Parameters.Add(errCode);

                MySqlParameter errMsg = new MySqlParameter();
                errMsg.ParameterName = "ErrMsg";
                errMsg.Direction = ParameterDirection.Output;
                errMsg.DbType = DbType.String;
                cmd.Parameters.Add(errMsg);

                if(conn.State != ConnectionState.Open)
                    conn.Open();
                int val = cmd.ExecuteNonQuery();

                rtMsg.errCode = int.Parse(cmd.Parameters["ErrCode"].Value.ToString());
                rtMsg.errMsg = cmd.Parameters["ErrMsg"].Value.ToString();

                conn.Close();
                cmd.Parameters.Clear();
                cmd.Clone();

                return rtMsg;
            }
        } 

        public static DataSet ExecuteQueryProcedure(string procName, ref MySqlRtMsg rtMsg, params MySqlPara[] cmdParms)
        {
            List<MySqlParameter> pArr = new List<MySqlParameter>();
            
            if (cmdParms != null)
            {
                foreach (MySqlPara parm in cmdParms)
                {
                    pArr.Add(parm.GetMySqlParameter());
                }
            }
            
            return ExecuteQueryProcedure(procName, ref rtMsg, pArr.ToArray());
        }

        /// <summary>
        ///  给定连接的数据库用假设参数执行一个sql命令（不返回数据集）
        /// </summary>
        /// <param name="procName">一个有效的连接字符串</param>
        /// <param name="cmdParms">命令类型(存储过程, 文本, 等等)</param>
        /// <returns>执行命令所影响的行数</returns>
        private static DataSet ExecuteQueryProcedure(string procName, ref MySqlRtMsg rtMsg, params MySqlParameter[] cmdParms)
        {
            DataSet rtDs = new DataSet();

            using (MySqlConnection conn = new MySqlConnection(connstr))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = procName;
                cmd.CommandType = CommandType.StoredProcedure;

                if (cmdParms != null)
                {
                    foreach (MySqlParameter parm in cmdParms)
                        cmd.Parameters.Add(parm);
                }

                MySqlParameter Total = new MySqlParameter();
                Total.ParameterName = "Total";
                Total.Direction = ParameterDirection.Output;
                Total.DbType = DbType.Int32;
                cmd.Parameters.Add(Total);

                MySqlParameter errCode = new MySqlParameter();
                errCode.ParameterName = "ErrCode";
                errCode.Direction = ParameterDirection.Output;
                errCode.DbType = DbType.Int32;
                cmd.Parameters.Add(errCode);

                MySqlParameter errMsg = new MySqlParameter();
                errMsg.ParameterName = "ErrMsg";
                errMsg.Direction = ParameterDirection.Output;
                errMsg.DbType = DbType.String;
                cmd.Parameters.Add(errMsg);

                if(conn.State != ConnectionState.Open)
                    conn.Open();

                using(MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(rtDs, "ds");
                } 


                rtMsg.pageSize = int.Parse(cmd.Parameters["pageSize"].Value.ToString());
                rtMsg.currentPage = int.Parse(cmd.Parameters["currentPage"].Value.ToString());
                rtMsg.total = int.Parse(cmd.Parameters["total"].Value.ToString());
                rtMsg.errCode = int.Parse(cmd.Parameters["ErrCode"].Value.ToString());
                rtMsg.errMsg = cmd.Parameters["ErrMsg"].Value.ToString();

                conn.Close();
                cmd.Parameters.Clear();
                cmd.Clone();
            }

            return rtDs;
        } 
    }

    public class MySqlRtMsg{
        
        public int pageSize{get;set;}
        public int currentPage{get;set;}       
        public int total{get;set;}
        public int errCode{get;set;}
        public string errMsg{get;set;}
    }

    public class MySqlPara{
        public string parameterName{get;set;}
        public ParameterDirection direction{get;set;}
        public DbType dbType{get;set;}
        public Object value{get;set;}
        public MySqlPara(string parameterName, ParameterDirection direction, DbType dbType){
            this.parameterName = parameterName;
            this.direction = direction;
            this.dbType = dbType;
            this.value = value;
        }
        public MySqlPara(string parameterName, ParameterDirection direction, DbType dbType, Object value){
            this.parameterName = parameterName;
            this.direction = direction;
            this.dbType = dbType;
            this.value = value;
        }

        public MySqlParameter GetMySqlParameter()
        {
            MySqlParameter p = new MySqlParameter();
            p.ParameterName = this.parameterName;
            p.Direction = this.direction;
            p.DbType = this.dbType;
            p.Value = this.value;

            return p;
        }
    }
}
