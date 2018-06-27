using Autofac;
using Nop.Core.Configuration;

namespace Nop.Core.Infrastructure.DependencyManagement
{
    /// <summary>
    /// 依赖注入接口
    /// </summary>
    public interface IDependencyRegistrar
    {
        /// <summary>
        /// 注册接口和服务
        /// </summary>
        /// <param name="builder">容器构造器</param>
        /// <param name="typeFinder">类型查找</param>
        /// <param name="config">配置</param>
        void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config);

        /// <summary>
        /// 依赖注入顺序
        /// </summary>
        int Order { get; }
    }
}
