using Nop.Core.Domain.Stores;

namespace Nop.Core
{
    /// <summary>
    /// 商店上下文
    /// </summary>
    public interface IStoreContext
    {
        /// <summary>
        /// 获取或设置当前商店
        /// </summary>
        Store CurrentStore { get; }
    }
}
