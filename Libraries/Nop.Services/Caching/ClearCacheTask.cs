using Nop.Core.Caching;
using Nop.Core.Infrastructure;
using Nop.Services.Tasks;

namespace Nop.Services.Caching
{
    /// <summary>
    /// 清除缓存计划任务实施
    /// </summary>
    public partial class ClearCacheTask : ITask
    {
        /// <summary>
        /// 执行任务
        /// </summary>
        public void Execute()
        {
            var cacheManager = EngineContext.Current.ContainerManager.Resolve<ICacheManager>("nop_cache_static");
            cacheManager.Clear();
        }
    }
}
