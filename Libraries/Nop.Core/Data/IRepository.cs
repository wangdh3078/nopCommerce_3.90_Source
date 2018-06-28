using System.Collections.Generic;
using System.Linq;

namespace Nop.Core.Data
{
    /// <summary>
    /// Repository
    /// </summary>
    public partial interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// 根据主键标识获取对象
        /// </summary>
        /// <param name="id">主键标识</param>
        /// <returns>实体</returns>
        T GetById(object id);

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        void Insert(T entity);

        /// <summary>
        /// 添加实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        void Insert(IEnumerable<T> entities);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">实体</param>
        void Update(T entity);

        /// <summary>
        /// 更新实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        void Update(IEnumerable<T> entities);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">实体</param>
        void Delete(T entity);

        /// <summary>
        /// 删除实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        void Delete(IEnumerable<T> entities);

        /// <summary>
        /// 获取一张表数据
        /// </summary>
        IQueryable<T> Table { get; }

        /// <summary>
        /// 获取一张不带上下文追踪的表，用于查询
        /// </summary>
        IQueryable<T> TableNoTracking { get; }
    }
}
