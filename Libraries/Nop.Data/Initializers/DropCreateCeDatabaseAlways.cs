using System;
using System.Data.Entity;

namespace Nop.Data.Initializers
{
    /// <summary>
    /// 始终重新创建数据库
    /// IDatabaseInitializer的实现将始终在应用程序域中首次使用上下文时重新创建数据库并重新种子数据库。
    /// 要为数据库创建种子，请创建派生类并重写Seed方法。
    /// </summary>
    /// <typeparam name="TContext">上下文的类型。</typeparam>
    public class DropCreateCeDatabaseAlways<TContext> : SqlCeInitializer<TContext> where TContext : DbContext
    {
        #region Strategy implementation

        /// <summary>
        /// 初始化数据库
        /// </summary>
        /// <param name="context">上下文</param>
        public override void InitializeDatabase(TContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            var replacedContext = ReplaceSqlCeConnection(context);

            if (replacedContext.Database.Exists())
            {
                replacedContext.Database.Delete();
            }
            context.Database.Create();
            Seed(context);
            context.SaveChanges();
        }

        #endregion

        #region Seeding methods

        /// <summary>
        /// 填充种子
        /// </summary>
        /// <param name="context">种子的上下文。</param>
        protected virtual void Seed(TContext context)
        {
        }

        #endregion
    }
}
