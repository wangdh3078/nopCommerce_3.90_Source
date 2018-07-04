using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using Nop.Core;
using Nop.Data.Mapping;

namespace Nop.Data
{
    /// <summary>
    /// ����������
    /// </summary>
    public class NopObjectContext : DbContext, IDbContext
    {
        #region Ctor

        public NopObjectContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            //((IObjectContextAdapter) this).ObjectContext.ContextOptions.LazyLoadingEnabled = true;
        }
        
        #endregion

        #region Utilities

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //dynamically load all configuration
            //System.Type configType = typeof(LanguageMap);   //any of your configuration classes here
            //var typesToRegister = Assembly.GetAssembly(configType).GetTypes()

            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                type.BaseType.GetGenericTypeDefinition() == typeof(NopEntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            //...or do it manually below. For example,
            //modelBuilder.Configurations.Add(new LanguageMap());



            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// ��ʵ�帽�ӵ������Ļ򷵻��Ѹ��ӵ�ʵ�壨����Ѹ��ӣ�
        /// </summary>
        /// <typeparam name="TEntity">ʵ������</typeparam>
        /// <param name="entity">ʵ��</param>
        /// <returns>����ʵ��</returns>
        protected virtual TEntity AttachEntityToContext<TEntity>(TEntity entity) where TEntity : BaseEntity, new()
        {
            //little hack here until Entity Framework really supports stored procedures
            //otherwise, navigation properties of loaded entities are not loaded until an entity is attached to the context
            var alreadyAttached = Set<TEntity>().Local.FirstOrDefault(x => x.Id == entity.Id);
            if (alreadyAttached == null)
            {
                //attach new entity
                Set<TEntity>().Attach(entity);
                return entity;
            }

            //entity is already loaded
            return alreadyAttached;
        }

        #endregion

        #region Methods

        /// <summary>
        /// �������ݿ�ű�
        /// </summary>
        /// <returns>SQL�������ݿ�</returns>
        public string CreateDatabaseScript()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateDatabaseScript();
        }

        /// <summary>
        /// ��ȡDbSet
        /// </summary>
        /// <typeparam name="TEntity">ʵ������</typeparam>
        /// <returns>DbSet</returns>
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        /// <summary>
        /// ִ�д洢���̲���������ʵ���б�
        /// </summary>
        /// <typeparam name="TEntity">ʵ������</typeparam>
        /// <param name="commandText">�����ı�</param>
        /// <param name="parameters">����</param>
        /// <returns>ʵ�弯��</returns>
        public IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity : BaseEntity, new()
        {
            //add parameters to command
            if (parameters != null && parameters.Length > 0)
            {
                for (int i = 0; i <= parameters.Length - 1; i++)
                {
                    var p = parameters[i] as DbParameter;
                    if (p == null)
                        throw new Exception("Not support parameter type");

                    commandText += i == 0 ? " " : ", ";

                    commandText += "@" + p.ParameterName;
                    if (p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Output)
                    {
                        //output parameter
                        commandText += " output";
                    }
                }
            }

            var result = this.Database.SqlQuery<TEntity>(commandText, parameters).ToList();

            //performance hack applied as described here - http://www.nopcommerce.com/boards/t/25483/fix-very-important-speed-improvement.aspx
            bool acd = this.Configuration.AutoDetectChangesEnabled;
            try
            {
                this.Configuration.AutoDetectChangesEnabled = false;

                for (int i = 0; i < result.Count; i++)
                    result[i] = AttachEntityToContext(result[i]);
            }
            finally
            {
                this.Configuration.AutoDetectChangesEnabled = acd;
            }

            return result;
        }

        /// <summary>
        /// ���������ظ����������͵�Ԫ�ص�ԭʼSQL��ѯ�� 
        /// ���Ϳ����Ǿ������ѯ���ص��е�����ƥ������Ե��κ����ͣ�Ҳ�����Ǽ򵥵Ļ������͡�
        /// �����Ͳ�����ʵ�����͡�
        /// ��ʹ���صĶ���������ʵ�����ͣ�������Ҳ������ٴ˲�ѯ�Ľ����
        /// </summary>
        /// <typeparam name="TElement">��ѯ���صĶ������͡�</typeparam>
        /// <param name="sql">SQL��ѯ�ַ�����</param>
        /// <param name="parameters">SQL��ѯ�ַ����Ĳ���</param>
        /// <returns></returns>
        public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            return this.Database.SqlQuery<TElement>(sql, parameters);
        }

        /// <summary>
        /// �����ݿ�ִ�и�����DDL / DML���
        /// </summary>
        /// <param name="sql">�����ַ���</param>
        /// <param name="doNotEnsureTransaction">false - �޷�ȷ�����񴴽�; true - ȷ�����񴴽���</param>
        /// <param name="timeout">��ʱֵ������Ϊ��λ�� ��ֵ��ʾ��ʹ�û����ṩ�����Ĭ��ֵ</param>
        /// <param name="parameters">ҪӦ���������ַ����Ĳ�����</param>
        /// <returns>ִ����������ݿⷵ�صĽ����</returns>
        public int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters)
        {
            int? previousTimeout = null;
            if (timeout.HasValue)
            {
                //store previous timeout
                previousTimeout = ((IObjectContextAdapter) this).ObjectContext.CommandTimeout;
                ((IObjectContextAdapter) this).ObjectContext.CommandTimeout = timeout;
            }

            var transactionalBehavior = doNotEnsureTransaction
                ? TransactionalBehavior.DoNotEnsureTransaction
                : TransactionalBehavior.EnsureTransaction;
            var result = this.Database.ExecuteSqlCommand(transactionalBehavior, sql, parameters);

            if (timeout.HasValue)
            {
                //Set previous timeout back
                ((IObjectContextAdapter) this).ObjectContext.CommandTimeout = previousTimeout;
            }

            //return result
            return result;
        }

        /// <summary>
        ///����ʵ��
        /// </summary>
        /// <param name="entity">ʵ��</param>
        public void Detach(object entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            ((IObjectContextAdapter)this).ObjectContext.Detach(entity);
        }

        #endregion

        #region Properties

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾ�Ƿ������˴��������ã���EF��ʹ�ã�
        /// </summary>
        public virtual bool ProxyCreationEnabled
        {
            get
            {
                return this.Configuration.ProxyCreationEnabled;
            }
            set
            {
                this.Configuration.ProxyCreationEnabled = value;
            }
        }

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾ�Ƿ������Զ����������ã���EF��ʹ�ã�
        /// </summary>
        public virtual bool AutoDetectChangesEnabled
        {
            get
            {
                return this.Configuration.AutoDetectChangesEnabled;
            }
            set
            {
                this.Configuration.AutoDetectChangesEnabled = value;
            }
        }

        #endregion
    }
}