﻿using System;
using Nop.Core.Domain.Directory;

namespace Nop.Core.Domain.Common
{
    /// <summary>
    /// 地址
    /// </summary>
    public partial class Address : BaseEntity, ICloneable
    {
        /// <summary>
        /// 获取或设置名字
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// 获取或设置姓氏
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// 获取或设置电子邮件
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 获取或设置公司
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// 获取或设置国家标识符
        /// </summary>
        public int? CountryId { get; set; }

        /// <summary>
        /// 获取或设置州/省标识符
        /// </summary>
        public int? StateProvinceId { get; set; }

        /// <summary>
        /// 获取或设置城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 获取或设置地址1
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        /// 获取或设置地址2
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// 获取或设置邮政编码
        /// </summary>
        public string ZipPostalCode { get; set; }

        /// <summary>
        /// 获取或设置电话号码
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 获取或设置传真号码
        /// </summary>
        public string FaxNumber { get; set; }

        /// <summary>
        ///获取或设置自定义属性（有关更多信息，请参阅“AddressAttribute”实体）
        /// </summary>
        public string CustomAttributes { get; set; }

        /// <summary>
        /// 获取或设置实例创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        ///获取或设置国家
        /// </summary>
        public virtual Country Country { get; set; }

        /// <summary>
        /// 获取或设置州/省
        /// </summary>
        public virtual StateProvince StateProvince { get; set; }

        /// <summary>
        /// 复制地址
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            var addr = new Address
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email,
                Company = this.Company,
                Country = this.Country,
                CountryId = this.CountryId,
                StateProvince = this.StateProvince,
                StateProvinceId = this.StateProvinceId,
                City = this.City,
                Address1 = this.Address1,
                Address2 = this.Address2,
                ZipPostalCode = this.ZipPostalCode,
                PhoneNumber = this.PhoneNumber,
                FaxNumber = this.FaxNumber,
                CustomAttributes = this.CustomAttributes,
                CreatedOnUtc = this.CreatedOnUtc,
            };
            return addr;
        }
    }
}
