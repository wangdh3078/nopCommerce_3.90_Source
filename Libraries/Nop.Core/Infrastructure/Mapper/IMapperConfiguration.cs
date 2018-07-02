using System;
using AutoMapper;

namespace Nop.Core.Infrastructure.Mapper
{
    /// <summary>
    /// Mapper配置注册器接口
    /// </summary>
    public interface IMapperConfiguration
    {
        /// <summary>
        /// 获取配置
        /// </summary>
        /// <returns>映射器配置操作</returns>
        Action<IMapperConfigurationExpression> GetConfiguration();

        /// <summary>
        /// 映射器实现的顺序
        /// </summary>
        int Order { get; }
    }
}
