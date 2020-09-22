using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace Dal
{
    /// <summary>SqlHelper--Sqlite
    /// </summary>
    public sealed class SqliteHelper
    {
        public static string connString = "Data Source=" + Environment.CurrentDirectory + "\\pushdb.db";

        /// <summary>Database Connection String
        /// </summary> 
        public static string ConnString
        {
            get { return connString; }
        }

        /// <summary> Execute Sql
        /// </summary> 
        /// <param name="cmdText"></param> 
        /// <returns></returns> 
        public static int ExecuteNonQuery(string cmdText)
        {
            return ExecuteNonQuery(ConnString, cmdText);
        }

        /// <summary> Execute Sql By Transaction
        /// </summary> 
        /// <param name="trans"></param> 
        /// <param name="cmdText"></param> 
        /// <returns></returns> 
        public static int ExecuteNonQuery(SQLiteTransaction trans, string cmdText, params SQLiteParameter[] parameters)
        {
            int val = 0;
            using (SQLiteCommand cmd = new SQLiteCommand())
            {
                PrepareCommand(cmd, (SQLiteConnection)trans.Connection, trans, cmdText, parameters);
                val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            return val;
        }

        /// <summary> Execute Sql
        /// </summary>        
        /// <param name="cmdText"></param> 
        /// <param name="parameters"></param> 
        /// <returns></returns> 
        public static int ExecuteNonQuery( string cmdText, params SQLiteParameter[] parameters)
        {
            string connString = ConnString;
            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                return ExecuteNonQuery(conn, cmdText, parameters);
            }
        }

        /// <summary> Execute Sql
        /// </summary> 
        /// <param name="connString"></param> 
        /// <param name="cmdText"></param> 
        /// <param name="parameters"></param> 
        /// <returns></returns> 
        public static int ExecuteNonQuery(string connString, string cmdText, params SQLiteParameter[] parameters)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                return ExecuteNonQuery(conn, cmdText, parameters);
            }
        }

        /// <summary> Execute Sql
        /// </summary> 
        /// <param name="connection"></param> 
        /// <param name="cmdText"></param> 
        /// <param name="parameters"></param> 
        /// <returns></returns> 
        public static int ExecuteNonQuery(SQLiteConnection connection, string cmdText, params SQLiteParameter[] parameters)
        {
            int val = 0;
            using (SQLiteCommand cmd = new SQLiteCommand())
            {
                PrepareCommand(cmd, connection, null, cmdText, parameters);
                val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            return val;
        }

        /// <summary> Get first row first column data
        /// </summary> 
        /// <param name="cmdText"></param> 
        /// <returns></returns> 
        public static object ExecuteScalar(string cmdText)
        {
            return ExecuteScalar(ConnString, cmdText, null);
        }

        /// <summary> Get first row first column data
        /// </summary> 
        /// <param name="cmdText"></param> 
        /// <returns></returns> 
        public static object ExecuteScalar(string cmdText, SQLiteParameter[] parameters)
        {
            return ExecuteScalar(ConnString, cmdText, parameters);
        }

        /// <summary> Get first row first column data
        /// </summary> 
        /// <param name="connString"></param> 
        /// <param name="cmdText"> </param> 
        /// <returns></returns> 
        public static object ExecuteScalar(string connString, string cmdText, SQLiteParameter[] parameters)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                return ExecuteScalar(conn, cmdText, parameters);
            }
        }

        /// <summary> Get first row first column data
        /// </summary> 
        /// <param name="connection"></param> 
        /// <param name="cmdText"></param> 
        /// <returns></returns> 
        public static object ExecuteScalar(SQLiteConnection connection, string cmdText, SQLiteParameter[] parameters)
        {
            object val;
            using (SQLiteCommand cmd = new SQLiteCommand())
            {
                PrepareCommand(cmd, connection, null, cmdText, parameters);
                val = cmd.ExecuteScalar();
            }
            return val;
        }

        /// <summary>Get data by DataReader 
        /// </summary> 
        /// <param name="cmdText"></param> 
        /// <param name="parameters"></param> 
        /// <returns></returns> 
        public static SQLiteDataReader ExecuteReader(string cmdText)
        {
            return ExecuteReader(ConnString, cmdText, null);
        }
        /// <summary>Get data by DataReader 
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static SQLiteDataReader ExecuteReader(string cmdText, params SQLiteParameter[] parameters)
        {
            return ExecuteReader(ConnString, cmdText, parameters);
        }

        /// <summary>Get data by DataReader 
        /// </summary> 
        /// <param name="connString"></param> 
        /// <param name="cmdText"></param> 
        /// <param name="parameters"></param> 
        /// <returns></returns> 
        public static SQLiteDataReader ExecuteReader(string connString, string cmdText, params SQLiteParameter[] parameters)
        {
            SQLiteConnection conn = new SQLiteConnection(connString);
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                PrepareCommand(cmd, conn, null, cmdText, parameters);
                SQLiteDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        /// <summary> PrepareCommand
        /// </summary> 
        /// <param name="cmd">Command</param> 
        /// <param name="conn">Connection</param> 
        /// <param name="trans">Transcation</param> 
        /// <param name="cmdText">SQL Text</param> 
        /// <param name="parameters">Parameter</param> 
        private static void PrepareCommand(SQLiteCommand cmd, SQLiteConnection conn, SQLiteTransaction trans, string cmdText, params SQLiteParameter[] parameters)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.Parameters.Clear();
            if (null != parameters && parameters.Length > 0)
            {
                cmd.Parameters.AddRange(parameters);
            }
        }
        /// <summary>Transaction
        /// </summary>
        /// <param name="listSql"></param>
        public static void ExecuteManySql(List<string> listSql)
        {
            List<ManySql> manySqls = new List<ManySql>();
            foreach (string sql in listSql)
            {
                manySqls.Add(new ManySql(sql, null));
            }

            ExecuteManySql(manySqls);
        }
        /// <summary>Transaction
        /// </summary>
        /// <param name="SQLStringList"></param>
        public static void ExecuteManySql(List<ManySql> SQLStringList)
        {
            using (SQLiteConnection cnn = new SQLiteConnection(connString))
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cnn.Open();
                    using (SQLiteTransaction trans = cnn.BeginTransaction())
                    {
                        try
                        {
                            string sSql = string.Empty;
                            SQLiteParameter[] cmdParms = null;
                            foreach (ManySql ms in SQLStringList)
                            {
                                sSql = ms.Sql;
                                cmdParms = ms.Paras;
                                PrepareCommand(cmd, cnn, trans, sSql, (SQLiteParameter[])cmdParms);
                                int val = cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();
                            }
                            trans.Commit();
                        }
                        catch
                        {
                            trans.Rollback();
                            throw;
                        }
                    }
                }
            }
        }
        /// <summary>Get DataTable By SQL
        /// </summary>
        /// <param name="cmdText">SQL</param>
        /// <returns></returns>
        public static DataTable GetDataTable(string cmdText)
        {
            DataSet ds = GetDataSet(cmdText);
            if (ds == null || ds.Tables.Count == 0)
                return null;
            return ds.Tables[0];
        }
        /// <summary>Get DataTable By SQL
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string cmdText, params SQLiteParameter[] parameters)
        {
            DataSet ds = GetDataSet(cmdText, parameters);
            if (ds == null || ds.Tables.Count == 0)
                return null;
            return ds.Tables[0];
        }
        /// <summary>Get DataSet By SQL
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(string cmdText)
        {
            return GetDataSet(ConnString, cmdText, null);
        }
        /// <summary>Get DataSet By SQL
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(string cmdText, params SQLiteParameter[] parameters)
        {
            return GetDataSet(ConnString, cmdText, parameters);
        }
        /// <summary>Get DataSet By SQL
        /// </summary>
        /// <param name="connString"></param>
        /// <param name="cmdText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(string connString, string cmdText, params SQLiteParameter[] parameters)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    try
                    {
                        conn.Open();
                        try
                        {
                            PrepareCommand(cmd, conn, null, cmdText, parameters);
                            using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                            {
                                DataSet ds = new DataSet();
                                da.Fill(ds, "ds");
                                cmd.Parameters.Clear();
                                return ds;
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message);
                    }
                }
            }
        }

    }

    /// <summary>Transaction SQL
    /// </summary>
    public class ManySql
    {
        private string _sql = string.Empty;
        private SQLiteParameter[] _paras = null;

        public string Sql
        {
            get { return _sql; }
            set { _sql = value; }
        }

        public SQLiteParameter[] Paras
        {
            get { return _paras; }
            set { _paras = value; }
        }

        public ManySql(string sql, SQLiteParameter[] paras)
        {
            _sql = sql;
            _paras = paras;
        }
    }
}