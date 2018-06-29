using Nop.Core.Configuration;

namespace Nop.Core.Domain.Messages
{
    /// <summary>
    /// 消息模板设置
    /// </summary>
    public class MessageTemplatesSettings : ISettings
    {
        /// <summary>
        /// 获取或设置一个值，该值指示是否根据大小写不变规则替换消息令牌
        /// </summary>
        public bool CaseInvariantReplacement { get; set; }

        /// <summary>
        /// 获取或设置工作流消息格式中使用的十六进制格式的color1（“#hhhhhh”）
        /// </summary>
        public string Color1 { get; set; }

        /// <summary>
        /// 获取或设置工作流消息格式中使用的十六进制格式的color2（“#hhhhhh”）
        /// </summary>
        public string Color2 { get; set; }

        /// <summary>
        ///获取或设置工作流消息格式中使用的十六进制颜色（“#hhhhhh”）
        /// </summary>
        public string Color3 { get; set; }

    }

}
