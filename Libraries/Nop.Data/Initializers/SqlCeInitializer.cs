using System;
using System.Data.Entity;
using System.Data.SqlServerCe;
using System.IO;

namespace Nop.Data.Initializers
{
    /// <summary>
    /// SqlCe初始化
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public abstract class SqlCeInitializer<T> : IDatabaseInitializer<T> where T : DbContext
    {
        /// <summary>
        /// 初始化数据库
        /// </summary>
        /// <param name="context"></param>
        public abstract void InitializeDatabase(T context);

        #region Helpers

        /// <summary>
        /// 使用相同的SqlCe连接字符串返回一个新的DbContext，但使用| DataDirectory |扩大
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected static DbContext ReplaceSqlCeConnection(DbContext context)
        {
            if (context.Database.Connection is SqlCeConnection)
            {
                var builder = new SqlCeConnectionStringBuilder(context.Database.Connection.ConnectionString);
                if (!String.IsNullOrWhiteSpace(builder.DataSource))
                {
                    builder.DataSource = ReplaceDataDirectory(builder.DataSource);
                    return new DbContext(builder.ConnectionString);
                }
            }
            return context;
        }

        private static string ReplaceDataDirectory(string inputString)
        {
            string str = null;
            if (inputString != null)
                str = inputString.Trim();
            if (string.IsNullOrEmpty(inputString) || !inputString.StartsWith("|DataDirectory|", StringComparison.InvariantCultureIgnoreCase))
            {
                return str;
            }
            var data = AppDomain.CurrentDomain.GetData("DataDirectory") as string;
            if (string.IsNullOrEmpty(data))
            {
                data = AppDomain.CurrentDomain.BaseDirectory ?? Environment.CurrentDirectory;
            }
            if (string.IsNullOrEmpty(data))
            {
                data = string.Empty;
            }
            int length = "|DataDirectory|".Length;
            if ((inputString.Length > "|DataDirectory|".Length) && ('\\' == inputString["|DataDirectory|".Length]))
            {
                length++;
            }
            return Path.Combine(data, inputString.Substring(length));
        }

        #endregion
    }

}
