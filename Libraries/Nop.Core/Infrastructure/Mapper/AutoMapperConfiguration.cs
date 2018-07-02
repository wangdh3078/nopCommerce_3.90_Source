using System;
using System.Collections.Generic;
using AutoMapper;

namespace Nop.Core.Infrastructure.Mapper
{
    /// <summary>
    /// AutoMapper配置
    /// </summary>
    public static class AutoMapperConfiguration
    {
        private static MapperConfiguration _mapperConfiguration;
        private static IMapper _mapper;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="configurationActions">配置操作</param>
        public static void Init(List<Action<IMapperConfigurationExpression>> configurationActions)
        {
            if (configurationActions == null)
                throw new ArgumentNullException("configurationActions");

            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                foreach (var ca in configurationActions)
                    ca(cfg);
            });

            _mapper = _mapperConfiguration.CreateMapper();
        }

        /// <summary>
        /// Mapper
        /// </summary>
        public static IMapper Mapper
        {
            get
            {
                return _mapper;
            }
        }
        /// <summary>
        /// Mapper配置
        /// </summary>
        public static MapperConfiguration MapperConfiguration
        {
            get
            {
                return _mapperConfiguration;
            }
        }
    }
}