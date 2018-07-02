using System.Configuration;
using System.Runtime.CompilerServices;
using Nop.Core.Configuration;

namespace Nop.Core.Infrastructure
{
    /// <summary>
    /// 提供对Nop引擎的单例实例的访问。
    /// </summary>
    public class EngineContext
    {
        #region 方法

        /// <summary>
        /// 初始化Nop工厂的静态实例。
        /// </summary>
        /// <param name="forceRecreate">即使工厂先前已初始化，也会创建新的工厂实例。</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IEngine Initialize(bool forceRecreate)
        {
            if (Singleton<IEngine>.Instance == null || forceRecreate)
            {
                Singleton<IEngine>.Instance = new NopEngine();

                var config = ConfigurationManager.GetSection("NopConfig") as NopConfig;
                Singleton<IEngine>.Instance.Initialize(config);
            }
            return Singleton<IEngine>.Instance;
        }

        /// <summary>
        /// 将静态引擎实例设置为提供的引擎。 使用此方法提供您自己的引擎实现。
        /// </summary>
        /// <param name="engine">要使用的引擎。</param>
        /// <remarks>如果您知道自己在做什么，请仅使用此方法。</remarks>
        public static void Replace(IEngine engine)
        {
            Singleton<IEngine>.Instance = engine;
        }

        #endregion

        #region 属性

        /// <summary>
        ///获取用于访问Nop服务的单例Nop引擎。
        /// </summary>
        public static IEngine Current
        {
            get
            {
                if (Singleton<IEngine>.Instance == null)
                {
                    Initialize(false);
                }
                return Singleton<IEngine>.Instance;
            }
        }

        #endregion
    }
}
