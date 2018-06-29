using System;
using System.Collections.Generic;
using System.Linq;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// 产品扩展
    /// </summary>
    public static class ProductExtensions
    {
        /// <summary>
        /// 解析“所需产品ID”属性
        /// </summary>
        /// <param name="product">产品</param>
        /// <returns>所需产品ID的列表</returns>
        public static int[] ParseRequiredProductIds(this Product product)
        {
            if (product == null)
                throw new ArgumentNullException("product");

            if (String.IsNullOrEmpty(product.RequiredProductIds))
                return new int[0];

            var ids = new List<int>();

            foreach (var idStr in product.RequiredProductIds
                .Split(new [] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim()))
            {
                int id;
                if (int.TryParse(idStr, out id))
                    ids.Add(id);
            }

            return ids.ToArray();
        }

        /// <summary>
        /// 获取指示产品是否现在可用的值（可用日期）
        /// </summary>
        /// <param name="product">产品</param>
        /// <returns></returns>
        public static bool IsAvailable(this Product product)
        {
            return IsAvailable(product, DateTime.UtcNow);
        }

        /// <summary>
        ///获取指示产品是否现在可用的值（可用日期）
        /// </summary>
        /// <param name="product">产品</param>
        /// <param name="dateTime">日期</param>
        /// <returns></returns>
        public static bool IsAvailable(this Product product, DateTime dateTime)
        {
            if (product == null)
                throw new ArgumentNullException("product");

            if (product.AvailableStartDateTimeUtc.HasValue && product.AvailableStartDateTimeUtc.Value > dateTime)
            {
                return false;
            }

            if (product.AvailableEndDateTimeUtc.HasValue && product.AvailableEndDateTimeUtc.Value < dateTime)
            {
                return false;
            }

            return true;
        }
    }
}
