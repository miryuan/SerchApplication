using SqlSugar;
using System;

namespace SerchApplicationManager
{
    public class SqlSugarHelper
    {
        private static string _connectionStr { get; set; } = string.Empty;
        private static DbType _dbType { get; set; } = DbType.MySql;
        private static readonly object Locker = new object();
        private static SqlSugarClient _instance;
        private SqlSugarHelper() { }
        /// <summary>
        /// 初始化数据库链接库信息
        /// </summary>
        /// <param name="connectionStr"></param>
        /// <param name="dt"></param>
        public static void Init(string connectionStr, DbType dt = DbType.MySql)
        {
            _connectionStr = connectionStr;
            _dbType = dt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionName"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static SqlSugarClient GetInstance()
        {
            if (_connectionStr == null || _connectionStr.Length == 0) throw new Exception("数据库链接初始化失败,请检查链接字符串.");

            if (_instance == null)
            {
                lock (Locker)
                {
                    if (_instance == null)
                    {
                        _instance = new SqlSugarClient(new ConnectionConfig()
                        {
                            ConnectionString = _connectionStr,
                            DbType = _dbType,
                            IsAutoCloseConnection = true
                        });
                        _instance.Ado.IsEnableLogEvent = false;
                    }
                }
            }
            return _instance;
        }
    }
}
