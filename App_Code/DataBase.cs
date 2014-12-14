using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
//�������
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Data.SqlClient;

public class DataBase:IDisposable
    {
        private MySqlConnection con_mysql;//�������Ӷ���
        private static string strConnectString = ConfigurationManager.ConnectionStrings["DefaultConnect"].ToString();

        #region   �����ݿ�����
        /// <summary>
        /// �����ݿ�����.
        /// </summary>
        private void Open()
        {

            if (con_mysql == null)//�ж����Ӷ����Ƿ�Ϊ��
            {
                con_mysql = new MySqlConnection(strConnectString);//�������ݿ����Ӷ���
            }
            if (con_mysql.State == ConnectionState.Closed )//�ж����ݿ������Ƿ�ر�
                con_mysql.Open();//�����ݿ�����
 
        }
        #endregion

        #region  �ر�����
        /// <summary>
        /// �ر����ݿ�����
        /// </summary>
        public void Close()
        {
            if (con_mysql != null)//�ж����Ӷ����Ƿ�Ϊ��
                con_mysql.Close();//�ر����ݿ�����
        }
        #endregion

        #region �ͷ����ݿ�������Դ
        /// <summary>
        /// �ͷ���Դ
        /// </summary>
        public void Dispose()
        {
            if (con_mysql != null)//�ж����Ӷ����Ƿ�Ϊ��
            {
                con_mysql.Dispose();//�ͷ����ݿ�������Դ
                con_mysql = null;//�������ݿ�����Ϊ��
            }
        }
        #endregion

        #region   ִ�в��������ı�(�����ݿ������ݷ���)
        /// <summary>
        /// ֱ��ִ��SQL���
        /// </summary>
        /// <param name="procName">�����ı�</param>
        /// <returns></returns>
        public int RunProc(string procName)
        {
            this.Open();//�����ݿ�����

            MySqlCommand cmd = new MySqlCommand(procName, con_mysql);//����MySqlCommand�������
            cmd.ExecuteNonQuery();//ִ��SQL����

            this.Close();//�ر����ݿ�����
            return 1;//����1����ʾִ�гɹ�
        }

        #endregion

        #region   ִ�в��������ı�(�з���ֵ)
        /// <summary>
        /// ִ�в�ѯ�����ı������ҷ���DataSet���ݼ�
        /// </summary>
        /// <param name="procName">�����ı�</param>
        /// <param name="prams">��������</param>
        /// <param name="tbName">���ݱ�����</param>
        /// <returns></returns>
        public DataSet RunProcReturnByArray(string procName, ArrayList prams, string tbName)
        {
            DataSet ds = new DataSet();//�������ݼ�����
 
            MySqlDataAdapter dap = CreateDataAdaperMysqlByArray(procName, prams);//�����Ž�������
            dap.Fill(ds, tbName);//������ݼ�

            this.Close();//�ر����ݿ�����
            return ds;//�������ݼ�
        }

        /// <summary>
        /// ִ�������ı������ҷ���DataSet���ݼ�
        /// </summary>
        /// <param name="procName">�����ı�</param>
        /// <param name="tbName">���ݱ�����</param>
        /// <returns>DataSet</returns>
        public DataSet RunProcReturn(string procName, string tbName)
        {
            DataSet ds = new DataSet();//�������ݼ�����

            MySqlDataAdapter dap = CreateDataAdaperMysql(procName, null);//�����Ž�������
            dap.Fill(ds, tbName);//������ݼ�

            this.Close();//�ر����ݿ�����
            return ds;//�������ݼ�
        }

        #endregion

        #region   �����������ת��ΪMySqlParameter����
        /// <summary>
        /// ת������
        /// </summary>
        /// <param name="ParamName">�洢�������ƻ������ı�</param>
        /// <param name="DbType">��������</param></param>
        /// <param name="Size">������С</param>
        /// <param name="Value">����ֵ</param>
        /// <returns>�µ� parameter ����</returns>
        public MySqlParameter MakeInParam(string ParamName, MySqlDbType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);//����SQL����
        }

        /// <summary>
        /// ��ʼ������ֵ
        /// </summary>
        /// <param name="ParamName">�洢�������ƻ������ı�</param>
        /// <param name="DbType">��������</param>
        /// <param name="Size">������С</param>
        /// <param name="Direction">��������</param>
        /// <param name="Value">����ֵ</param>
        /// <returns>�µ� parameter ����</returns>
        public MySqlParameter MakeParam(string ParamName, MySqlDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            MySqlParameter param;//����SQL��������
            if (Size > 0)//�жϲ����ֶ��Ƿ����0
                param = new MySqlParameter(ParamName, DbType, Size);//����ָ�������ͺʹ�С����SQL����
            else
                param = new MySqlParameter(ParamName, DbType);//����ָ�������ʹ���SQL����
            param.Direction = Direction;//����SQL����������
            if (!(Direction == ParameterDirection.Output && Value == null))//�ж��Ƿ�Ϊ�������
                param.Value = Value;//���ò�������ֵ
            return param;//����SQL����
        }
        #endregion

        #region   ִ�в��������ı�(�����ݿ������ݷ���)
        /// <summary>
        /// ִ������
        /// </summary>
        /// <param name="procName">�����ı�</param>
        /// <param name="prams">��������</param>
        /// <returns></returns>
        public int RunProc(string procName, MySqlParameter[] prams)
        {
            MySqlCommand cmd = CreateCommand(procName, prams);//����MySqlCommand�������
            cmd.ExecuteNonQuery();//ִ��SQL����
            this.Close();//�ر����ݿ�����
            if (cmd.Parameters["ReturnValue"].Value != null)
                return (int)cmd.Parameters["ReturnValue"].Value;//�õ�ִ�гɹ�����ֵ
            else
                return 0;
        }
        #endregion

        #region   ִ�в��������ı�(�з���ֵ)
        /// <summary>
        /// ִ�в�ѯ�����ı������ҷ���DataSet���ݼ�
        /// </summary>
        /// <param name="procName">�����ı�</param>
        /// <param name="prams">��������</param>
        /// <param name="tbName">���ݱ�����</param>
        /// <returns></returns>
        public DataSet RunProcReturn(string procName, MySqlParameter[] prams, string tbName)
        {
            MySqlDataAdapter dap = CreateDataAdaperMysql(procName, prams);//�����Ž�������
            DataSet ds = new DataSet();//�������ݼ�����
            dap.Fill(ds, tbName);//������ݼ�
            this.Close();//�ر����ݿ�����
            return ds;//�������ݼ�
        }

        #endregion 

        #region ִ�ж���SQL��䣬ʵ�����ݿ�����
        /// <summary>   
        /// ִ�ж���SQL��䣬ʵ�����ݿ�����   
        /// </summary>   
        /// <param name="SQLStringList">����SQL���</param>   
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

        #region �������ı���ӵ�MySqlDataAdapter
        /// <summary>
        /// ����һ��MySqlDataAdapter�����Դ���ִ�������ı�
        /// </summary>
        /// <param name="procName">�����ı�</param>
        /// <param name="prams">��������</param>
        /// <returns></returns>
        private MySqlDataAdapter CreateDataAdaperMysql(string procName, MySqlParameter[] prams)
        {
            this.Open();//�����ݿ�����
            MySqlDataAdapter dap = new MySqlDataAdapter(procName, con_mysql);//�����Ž�������
            dap.SelectCommand.CommandType = CommandType.Text;//ָ��Ҫִ�е�����Ϊ�����ı�
            if (prams != null)//�ж�SQL�����Ƿ�Ϊ��
            {
                foreach (MySqlParameter parameter in prams)//�������ݵ�ÿ��SQL����
                    dap.SelectCommand.Parameters.Add(parameter);//��SQL������ӵ�ִ�����������
            }
            //���뷵�ز���
            dap.SelectCommand.Parameters.Add(new MySqlParameter("ReturnValue", MySqlDbType.Int32, 4,
                ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return dap;//�����Ž�������
        }

        private MySqlDataAdapter CreateDataAdaperMysqlByArray(string procName, ArrayList prams)
        {
            this.Open();//�����ݿ�����
            MySqlDataAdapter dap = new MySqlDataAdapter(procName, con_mysql);//�����Ž�������
            dap.SelectCommand.CommandType = CommandType.Text;//ָ��Ҫִ�е�����Ϊ�����ı�
            if (prams != null)//�ж�SQL�����Ƿ�Ϊ��
            {
                foreach (MySqlParameter parameter in prams)//�������ݵ�ÿ��SQL����
                    dap.SelectCommand.Parameters.Add(parameter);//��SQL������ӵ�ִ�����������
            }
            //���뷵�ز���
            dap.SelectCommand.Parameters.Add(new MySqlParameter("ReturnValue", MySqlDbType.Int32, 4,
                ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return dap;//�����Ž�������
        }
        #endregion

        #region   �������ı���ӵ�MySqlCommand
        /// <summary>
        /// ����һ��MySqlCommand�����Դ���ִ�������ı�
        /// </summary>
        /// <param name="procName">�����ı�</param>
        /// <param name="prams"�����ı��������</param>
        /// <returns>����MySqlCommand����</returns>
        private MySqlCommand CreateCommand(string procName, MySqlParameter[] prams)
        {
            this.Open();//�����ݿ�����
            MySqlCommand cmd = new MySqlCommand(procName, con_mysql);//����SqlCommand�������
            cmd.CommandType = CommandType.Text;//ָ��Ҫִ�е�����Ϊ�����ı�
            // ���ΰѲ������������ı�
            if (prams != null)//�ж�SQL�����Ƿ�Ϊ��
            {
                foreach (MySqlParameter parameter in prams)//�������ݵ�ÿ��SQL����
                    cmd.Parameters.Add(parameter);//��SQL������ӵ�ִ�����������
            }
            //���뷵�ز���
            cmd.Parameters.Add(new MySqlParameter("ReturnValue", MySqlDbType.Int32, 4,
                ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return cmd;//����SqlCommand�������
        }
        #endregion

    }
