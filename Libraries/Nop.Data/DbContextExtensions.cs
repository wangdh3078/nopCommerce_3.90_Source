using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Nop.Core;

namespace Nop.Data
{
    public static class DbContextExtensions
    {
        #region Utilities

        private static T InnerGetCopy<T>(IDbContext context, T currentCopy, Func<DbEntityEntry<T>, DbPropertyValues> func) where T : BaseEntity
        {
            //Get the database context
            DbContext dbContext = CastOrThrow(context);

            //Get the entity tracking object
            DbEntityEntry<T> entry = GetEntityOrReturnNull(currentCopy, dbContext);

            //The output 
            T output = null;

            //Try and get the values
            if (entry != null)
            {
                DbPropertyValues dbPropertyValues = func(entry);
                if (dbPropertyValues != null)
                {
                    output = dbPropertyValues.ToObject() as T;
                }
            }

            return output;
        }

        /// <summary>
        ///��ȡʵ��򷵻�null��
        /// </summary>
        /// <typeparam name="T">����</typeparam>
        /// <param name="currentCopy">Ŀǰ�ĸ�����</param>
        /// <param name="dbContext">���ݿ������ġ�</param>
        /// <returns></returns>
        private static DbEntityEntry<T> GetEntityOrReturnNull<T>(T currentCopy, DbContext dbContext) where T : BaseEntity
        {
            return dbContext.ChangeTracker.Entries<T>().FirstOrDefault(e => e.Entity == currentCopy);
        }

        private static DbContext CastOrThrow(IDbContext context)
        {
            var output = context as DbContext;

            if (output == null)
            {
                throw new InvalidOperationException("Context does not support operation.");
            }

            return output;
        }

        #endregion

        #region Methods

        /// <summary>
        /// ����ԭʼ������
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context">�����ġ�</param>
        /// <param name="currentCopy">Ŀǰ�ĸ�����</param>
        /// <returns></returns>
        public static T LoadOriginalCopy<T>(this IDbContext context, T currentCopy) where T : BaseEntity
        {
            return InnerGetCopy(context, currentCopy, e => e.OriginalValues);
        }

        /// <summary>
        /// �������ݿ⸱����
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context">������</param>
        /// <param name="currentCopy">Ŀǰ�ĸ���</param>
        /// <returns></returns>
        public static T LoadDatabaseCopy<T>(this IDbContext context, T currentCopy) where T : BaseEntity
        {
            return InnerGetCopy(context, currentCopy, e => e.GetDatabaseValues());
        }

        /// <summary>
        /// ɾ��һ�������
        /// </summary>
        /// <param name="context">������</param>
        /// <param name="tableName">����</param>
        public static void DropPluginTable(this DbContext context, string tableName)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            if (String.IsNullOrEmpty(tableName))
                throw new ArgumentNullException("tableName");

            //drop the table
            if (context.Database.SqlQuery<int>("SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = {0}", tableName).Any<int>())
            {
                var dbScript = "DROP TABLE [" + tableName + "]";
                context.Database.ExecuteSqlCommand(dbScript);
            }
            context.SaveChanges();
        }

        /// <summary>
        /// ��ȡʵ��ı���
        /// </summary>
        /// <typeparam name="T">ʵ������</typeparam>
        /// <param name="context">������</param>
        /// <returns>����</returns>
        public static string GetTableName<T>(this IDbContext context) where T : BaseEntity
        {
            //var tableName = typeof(T).Name;
            //return tableName;

            //this code works only with Entity Framework.
            //If you want to support other database, then use the code above (commented)

            var adapter = ((IObjectContextAdapter)context).ObjectContext;
            var storageModel = (StoreItemCollection)adapter.MetadataWorkspace.GetItemCollection(DataSpace.SSpace);
            var containers = storageModel.GetItems<EntityContainer>();
            var entitySetBase = containers.SelectMany(c => c.BaseEntitySets.Where(bes => bes.Name == typeof(T).Name)).First();

            // Here are variables that will hold table and schema name
            string tableName = entitySetBase.MetadataProperties.First(p => p.Name == "Table").Value.ToString();
            //string schemaName = productEntitySetBase.MetadataProperties.First(p => p.Name == "Schema").Value.ToString();
            return tableName;
        }

        /// <summary>
        /// ��ȡ�е���󳤶�
        /// </summary>
        /// <param name="context">������</param>
        /// <param name="entityTypeName">ʵ����������</param>
        /// <param name="columnName">����</param>
        /// <returns>��󳤶ȡ� ��������Ĺ��򲻴��ڣ���Ϊ��</returns>
        public static int? GetColumnMaxLength(this IDbContext context, string entityTypeName, string columnName)
        {
            var rez = GetColumnsMaxLength(context, entityTypeName, columnName);
            return rez.ContainsKey(columnName) ? rez[columnName] as int? : null;
        }

        /// <summary>
        /// ��ȡ�е���󳤶�
        /// </summary>
        /// <param name="context">������</param>
        /// <param name="entityTypeName">ʵ����������</param>
        /// <param name="columnNames">������</param>
        /// <returns></returns>
        public static IDictionary<string, int> GetColumnsMaxLength(this IDbContext context, string entityTypeName, params string[] columnNames)
        {
            int temp;

            var fildFacets = GetFildFacets(context, entityTypeName, "String", columnNames);

            var queryResult = fildFacets
                .Select(f => new { Name = f.Key, MaxLength = f.Value["MaxLength"].Value })
                .Where(p => int.TryParse(p.MaxLength.ToString(), out temp))
                .ToDictionary(p => p.Name, p => Convert.ToInt32(p.MaxLength));

            return queryResult;
        }


        /// <summary>
        /// ��ȡ���ʮ����ֵ
        /// </summary>
        /// <param name="context">������</param>
        /// <param name="entityTypeName">ʵ����������</param>
        /// <param name="columnNames">������</param>
        /// <returns></returns>
        public static IDictionary<string, decimal> GetDecimalMaxValue(this IDbContext context, string entityTypeName, params string[] columnNames)
        {
            var fildFacets = GetFildFacets(context, entityTypeName, "Decimal", columnNames);

            return fildFacets.ToDictionary(p => p.Key, p => int.Parse(p.Value["Precision"].Value.ToString()) - int.Parse(p.Value["Scale"].Value.ToString()))
                .ToDictionary(p => p.Key, p => new decimal(Math.Pow(10, p.Value)));
        }

        private static Dictionary<string, ReadOnlyMetadataCollection<Facet>> GetFildFacets(this IDbContext context,
            string entityTypeName, string edmTypeName, params string[] columnNames)
        {
            //original: http://stackoverflow.com/questions/5081109/entity-framework-4-0-automatically-truncate-trim-string-before-insert

            var entType = Type.GetType(entityTypeName);
            var adapter = ((IObjectContextAdapter)context).ObjectContext;
            var metadataWorkspace = adapter.MetadataWorkspace;
            var q = from meta in metadataWorkspace.GetItems(DataSpace.CSpace).Where(m => m.BuiltInTypeKind == BuiltInTypeKind.EntityType)
                    from p in (meta as EntityType).Properties.Where(p => columnNames.Contains(p.Name) && p.TypeUsage.EdmType.Name == edmTypeName)
                    select p;

            var queryResult = q.Where(p =>
            {
                var match = p.DeclaringType.Name == entityTypeName;
                if (!match && entType != null)
                {
                    //Is a fully qualified name....
                    match = entType.Name == p.DeclaringType.Name;
                }

                return match;

            }).ToDictionary(p => p.Name, p => p.TypeUsage.Facets);

            return queryResult;
        }
        /// <summary>
        /// ���ݿ�����
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string DbName(this IDbContext context)
        {
            var connection = ((IObjectContextAdapter)context).ObjectContext.Connection as EntityConnection;
            if (connection == null)
                return string.Empty;

            return connection.StoreConnection.Database;
        }

        #endregion
    }
}