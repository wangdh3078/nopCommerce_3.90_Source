using System;
using System.Data.Entity;
using System.Transactions;

namespace Nop.Data.Initializers
{
    /// <summary>
    /// IDatabaseInitializer的实现，只有在数据库不存在的情况下，才会重新创建数据库，并可选择重新生成数据库。
    /// 要为数据库创建种子，请创建派生类并重写Seed方法。
    /// </summary>
    /// <typeparam name="TContext">上下文的类型。</typeparam>
    public class CreateCeDatabaseIfNotExists<TContext> : SqlCeInitializer<TContext> where TContext : DbContext
    {
        #region Strategy implementation

        public override void InitializeDatabase(TContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            var replacedContext = ReplaceSqlCeConnection(context);

            bool databaseExists;
            using (new TransactionScope(TransactionScopeOption.Suppress))
            {
                databaseExists = replacedContext.Database.Exists();
            }

            if (databaseExists)
            {
                // If there is no metadata either in the model or in the databaase, then
                // we assume that the database matches the model because the common cases for
                // these scenarios are database/model first and/or an existing database.
                if (!context.Database.CompatibleWithModel(throwIfNoMetadata: false))
                {
                    throw new InvalidOperationException(string.Format("The model backing the '{0}' context has changed since the database was created. Either manually delete/update the database, or call Database.SetInitializer with an IDatabaseInitializer instance. For example, the DropCreateDatabaseIfModelChanges strategy will automatically delete and recreate the database, and optionally seed it with new data.", context.GetType().Name));
                }
            }
            else
            {
                context.Database.Create();
                Seed(context);
                context.SaveChanges();
            }
        }

        #endregion

        #region Seeding methods

        /// <summary>
        /// 一个应该被重写的实际上将数据添加到上下文以进行种子播种。
        /// 默认实现什么都不做。
        /// </summary>
        /// <param name="context">种子的上下文。</param>
        protected virtual void Seed(TContext context)
        {
        }

        #endregion
    }


}
