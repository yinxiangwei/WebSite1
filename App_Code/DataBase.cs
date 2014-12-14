using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
//引用类库
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Data.SqlClient;

public class DataBase:IDisposable
    {
        private MySqlConnection con_mysql;//创建连接对象
        private static string strConnectString = ConfigurationManager.ConnectionStrings["DefaultConnect"].ToString();

        #region   打开数据库连接
        /// <summary>
        /// 打开数据库连接.
        /// </summary>
        private void Open()
        {

            if (con_mysql == null)//判断连接对象是否为空
            {
                con_mysql = new MySqlConnection(strConnectString);//创建数据库连接对象
            }
            if (con_mysql.State == ConnectionState.Closed )//判断数据库连接是否关闭
                con_mysql.Open();//打开数据库连接
 
        }
        #endregion

        #region  关闭连接
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void Close()
        {
            if (con_mysql != null)//判断连接对象是否不为空
                con_mysql.Close();//关闭数据库连接
        }
        #endregion

        #region 释放数据库连接资源
        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            if (con_mysql != null)//判断连接对象是否不为空
            {
                con_mysql.Dispose();//释放数据库连接资源
                con_mysql = null;//设置数据库连接为空
            }
        }
        #endregion

        #region   执行参数命令文本(无数据库中数据返回)
        /// <summary>
        /// 直接执行SQL语句
        /// </summary>
        /// <param name="procName">命令文本</param>
        /// <returns></returns>
        public int RunProc(string procName)
        {
            this.Open();//打开数据库连接

            MySqlCommand cmd = new MySqlCommand(procName, con_mysql);//创建MySqlCommand命令对象
            cmd.ExecuteNonQuery();//执行SQL命令

            this.Close();//关闭数据库连接
            return 1;//返回1，表示执行成功
        }

        #endregion

        #region   执行参数命令文本(有返回值)
        /// <summary>
        /// 执行查询命令文本，并且返回DataSet数据集
        /// </summary>
        /// <param name="procName">命令文本</param>
        /// <param name="prams">参数对象</param>
        /// <param name="tbName">数据表名称</param>
        /// <returns></returns>
        public DataSet RunProcReturnByArray(string procName, ArrayList prams, string tbName)
        {
            DataSet ds = new DataSet();//创建数据集对象
 
            MySqlDataAdapter dap = CreateDataAdaperMysqlByArray(procName, prams);//创建桥接器对象
            dap.Fill(ds, tbName);//填充数据集

            this.Close();//关闭数据库连接
            return ds;//返回数据集
        }

        /// <summary>
        /// 执行命令文本，并且返回DataSet数据集
        /// </summary>
        /// <param name="procName">命令文本</param>
        /// <param name="tbName">数据表名称</param>
        /// <returns>DataSet</returns>
        public DataSet RunProcReturn(string procName, string tbName)
        {
            DataSet ds = new DataSet();//创建数据集对象

            MySqlDataAdapter dap = CreateDataAdaperMysql(procName, null);//创建桥接器对象
            dap.Fill(ds, tbName);//填充数据集

            this.Close();//关闭数据库连接
            return ds;//返回数据集
        }

        #endregion

        #region   传入参数并且转换为MySqlParameter类型
        /// <summary>
        /// 转换参数
        /// </summary>
        /// <param name="ParamName">存储过程名称或命令文本</param>
        /// <param name="DbType">参数类型</param></param>
        /// <param name="Size">参数大小</param>
        /// <param name="Value">参数值</param>
        /// <returns>新的 parameter 对象</returns>
        public MySqlParameter MakeInParam(string ParamName, MySqlDbType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);//创建SQL参数
        }

        /// <summary>
        /// 初始化参数值
        /// </summary>
        /// <param name="ParamName">存储过程名称或命令文本</param>
        /// <param name="DbType">参数类型</param>
        /// <param name="Size">参数大小</param>
        /// <param name="Direction">参数方向</param>
        /// <param name="Value">参数值</param>
        /// <returns>新的 parameter 对象</returns>
        public MySqlParameter MakeParam(string ParamName, MySqlDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            MySqlParameter param;//声明SQL参数对象
            if (Size > 0)//判断参数字段是否大于0
                param = new MySqlParameter(ParamName, DbType, Size);//根据指定的类型和大小创建SQL参数
            else
                param = new MySqlParameter(ParamName, DbType);//根据指定的类型创建SQL参数
            param.Direction = Direction;//设置SQL参数的类型
            if (!(Direction == ParameterDirection.Output && Value == null))//判断是否为输出参数
                param.Value = Value;//设置参数返回值
            return param;//返回SQL参数
        }
        #endregion

        #region   执行参数命令文本(无数据库中数据返回)
        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="procName">命令文本</param>
        /// <param name="prams">参数对象</param>
        /// <returns></returns>
        public int RunProc(string procName, MySqlParameter[] prams)
        {
            MySqlCommand cmd = CreateCommand(procName, prams);//创建MySqlCommand命令对象
            cmd.ExecuteNonQuery();//执行SQL命令
            this.Close();//关闭数据库连接
            if (cmd.Parameters["ReturnValue"].Value != null)
                return (int)cmd.Parameters["ReturnValue"].Value;//得到执行成功返回值
            else
                return 0;
        }
        #endregion

        #region   执行参数命令文本(有返回值)
        /// <summary>
        /// 执行查询命令文本，并且返回DataSet数据集
        /// </summary>
        /// <param name="procName">命令文本</param>
        /// <param name="prams">参数对象</param>
        /// <param name="tbName">数据表名称</param>
        /// <returns></returns>
        public DataSet RunProcReturn(string procName, MySqlParameter[] prams, string tbName)
        {
            MySqlDataAdapter dap = CreateDataAdaperMysql(procName, prams);//创建桥接器对象
            DataSet ds = new DataSet();//创建数据集对象
            dap.Fill(ds, tbName);//填充数据集
            this.Close();//关闭数据库连接
            return ds;//返回数据集
        }

        #endregion 

        #region 执行多条SQL语句，实现数据库事务
        /// <summary>   
        /// 执行多条SQL语句，实现数据库事务。   
        /// </summary>   
        /// <param name="SQLStringList">多条SQL语句</param>   
        public bool ExecuteNoQueryTran(List<String> SQLStringList)   
        {
            this.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con_mysql;
            MySqlTransaction tx = con_mysql.BeginTransaction();
            cmd.Transaction = tx;   
                 
            try
            {
                foreach (String strsql in SQLStringList)        
                {        
                    //string strsql = SQLStringList[n];        
                    if (strsql.Trim().Length > 1)
                    {
                        cmd.CommandText = strsql;
                        //PrepareCommand(cmd, con_mysql, tx, strsql, null);
                        cmd.ExecuteNonQuery();   
                    }
                }    
                tx.Commit();
                this.Close();
                return true;   
            }
            catch   
            {   
                tx.Rollback();
                this.Close();
                return false; 
            }
        }
        //private  void PrepareCommand(MySqlCommand cmd, MySqlConnection conn, MySqlTransaction trans, string cmdText, MySqlParameter[] cmdParms)
        //{
        //    if (conn.State != ConnectionState.Open)
        //        conn.Open();
        //    cmd.Connection = conn;
        //    cmd.CommandText = cmdText;
        //    if (trans != null)
        //        cmd.Transaction = trans;

        //    cmd.CommandType = CommandType.Text;//cmdType;
 
        //    if (cmdParms != null)
        //    {
        //        foreach (MySqlParameter parameter in cmdParms)
        //        {
        //            if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) && (parameter.Value == null))
        //            {
        //                parameter.Value = DBNull.Value;
        //            }
        //            cmd.Parameters.Add(parameter);
        //        }
        //    }
        //} 
        #endregion 

        #region 将命令文本添加到MySqlDataAdapter
        /// <summary>
        /// 创建一个MySqlDataAdapter对象以此来执行命令文本
        /// </summary>
        /// <param name="procName">命令文本</param>
        /// <param name="prams">参数对象</param>
        /// <returns></returns>
        private MySqlDataAdapter CreateDataAdaperMysql(string procName, MySqlParameter[] prams)
        {
            this.Open();//打开数据库连接
            MySqlDataAdapter dap = new MySqlDataAdapter(procName, con_mysql);//创建桥接器对象
            dap.SelectCommand.CommandType = CommandType.Text;//指定要执行的类型为命令文本
            if (prams != null)//判断SQL参数是否不为空
            {
                foreach (MySqlParameter parameter in prams)//遍历传递的每个SQL参数
                    dap.SelectCommand.Parameters.Add(parameter);//将SQL参数添加到执行命令对象中
            }
            //加入返回参数
            dap.SelectCommand.Parameters.Add(new MySqlParameter("ReturnValue", MySqlDbType.Int32, 4,
                ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return dap;//返回桥接器对象
        }

        private MySqlDataAdapter CreateDataAdaperMysqlByArray(string procName, ArrayList prams)
        {
            this.Open();//打开数据库连接
            MySqlDataAdapter dap = new MySqlDataAdapter(procName, con_mysql);//创建桥接器对象
            dap.SelectCommand.CommandType = CommandType.Text;//指定要执行的类型为命令文本
            if (prams != null)//判断SQL参数是否不为空
            {
                foreach (MySqlParameter parameter in prams)//遍历传递的每个SQL参数
                    dap.SelectCommand.Parameters.Add(parameter);//将SQL参数添加到执行命令对象中
            }
            //加入返回参数
            dap.SelectCommand.Parameters.Add(new MySqlParameter("ReturnValue", MySqlDbType.Int32, 4,
                ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return dap;//返回桥接器对象
        }
        #endregion

        #region   将命令文本添加到MySqlCommand
        /// <summary>
        /// 创建一个MySqlCommand对象以此来执行命令文本
        /// </summary>
        /// <param name="procName">命令文本</param>
        /// <param name="prams"命令文本所需参数</param>
        /// <returns>返回MySqlCommand对象</returns>
        private MySqlCommand CreateCommand(string procName, MySqlParameter[] prams)
        {
            this.Open();//打开数据库连接
            MySqlCommand cmd = new MySqlCommand(procName, con_mysql);//创建SqlCommand命令对象
            cmd.CommandType = CommandType.Text;//指定要执行的类型为命令文本
            // 依次把参数传入命令文本
            if (prams != null)//判断SQL参数是否不为空
            {
                foreach (MySqlParameter parameter in prams)//遍历传递的每个SQL参数
                    cmd.Parameters.Add(parameter);//将SQL参数添加到执行命令对象中
            }
            //加入返回参数
            cmd.Parameters.Add(new MySqlParameter("ReturnValue", MySqlDbType.Int32, 4,
                ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return cmd;//返回SqlCommand命令对象
        }
        #endregion

    }
