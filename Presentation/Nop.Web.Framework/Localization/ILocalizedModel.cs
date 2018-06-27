using System.Collections.Generic;

namespace Nop.Web.Framework.Localization
{
    /// <summary>
    /// 本地化模型
    /// </summary>
    public interface ILocalizedModel
    {

    }
    /// <summary>
    /// 本地化模型
    /// </summary>
    /// <typeparam name="TLocalizedModel"></typeparam>
    public interface ILocalizedModel<TLocalizedModel> : ILocalizedModel
    {
        /// <summary>
        /// 语言环境
        /// </summary>
        IList<TLocalizedModel> Locales { get; set; }
    }
}
