
using System.Data.Common;

namespace Nop.Core.Data
{
    /// <summary>
    /// 数据驱动接口
    /// </summary>
    public interface IDataProvider
    {
        /// <summary>
        /// 初始化连接工厂
        /// </summary>
        void InitConnectionFactory();

        /// <summary>
        /// 设置数据库初始化器
        /// </summary>
        void SetDatabaseInitializer();

        /// <summary>
        /// 初始化数据库
        /// </summary>
        void InitDatabase();

        /// <summary>
        /// 指示此数据提供程序是否支持存储过程的值。
        /// </summary>
        bool StoredProceduredSupported { get; }

        /// <summary>
        /// 指示此数据提供程序是否支持备份的值。
        /// </summary>
        bool BackupSupported { get; }

        /// <summary>
        /// 获取支持数据库参数对象（由存储过程使用）
        /// </summary>
        /// <returns>参数</returns>
        DbParameter GetParameter();

        /// <summary>
        /// 如果不支持哈希字节函数
        /// 哈希字节函数的最大长度返回0。
        /// </summary>
        /// <returns>哈希字节函数的数据长度</returns>
        int SupportedLengthOfBinaryHash();
    }
}
