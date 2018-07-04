using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using Nop.Core.Data;
using Nop.Data.Initializers;

namespace Nop.Data
{
    public class SqlCeDataProvider : IDataProvider
    {
        /// <summary>
        /// 初始化连接工厂
        /// </summary>
        public virtual void InitConnectionFactory()
        {
            var connectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");
            //TODO fix compilation warning (below)
            #pragma warning disable 0618
            Database.DefaultConnectionFactory = connectionFactory;
        }

        /// <summary>
        /// 初始化数据库
        /// </summary>
        public virtual void InitDatabase()
        {
            InitConnectionFactory();
            SetDatabaseInitializer();
        }

        /// <summary>
        /// 设置数据库初始化器
        /// </summary>
        public virtual void SetDatabaseInitializer()
        {
            var initializer = new CreateCeDatabaseIfNotExists<NopObjectContext>();
            Database.SetInitializer(initializer);
        }

        /// <summary>
        /// 指示此数据提供程序是否支持存储过程的值。
        /// </summary>
        public virtual bool StoredProceduredSupported
        {
            get { return false; }
        }


        /// <summary>
        /// 指示此数据提供程序是否支持备份的值。
        /// </summary>
        public bool BackupSupported
        {
            get { return false; }
        }

        /// <summary>
        /// 获取支持数据库参数对象（由存储过程使用）
        /// </summary>
        /// <returns>参数</returns>
        public virtual DbParameter GetParameter()
        {
            return new SqlParameter();
        }

        /// <summary>
        /// 如果不支持哈希字节函数
        /// 哈希字节函数的最大长度返回0。
        /// </summary>
        /// <returns>哈希字节函数的数据长度</returns>
        public int SupportedLengthOfBinaryHash()
        {
            return 0; //HASHBYTES functions is missing in SQL CE
        }
    }
}
