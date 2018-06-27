
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Nop.Web.Framework.Kendoui
{
    /// <summary>
    /// 模型状态扩展
    /// </summary>
    public static class ModelStateExtensions
    {
        /// <summary>
        /// 获取错误信息
        /// </summary>
        /// <param name="error">模型错误</param>
        /// <param name="modelState">模型状态</param>
        /// <returns></returns>
        private static string GetErrorMessage(ModelError error, ModelState modelState)
        {
            if (!string.IsNullOrEmpty(error.ErrorMessage))
            {
                return error.ErrorMessage;
            }
            if (modelState.Value == null)
            {
                return error.ErrorMessage;
            }
            var args = new object[] { modelState.Value.AttemptedValue };
            return string.Format("ValueNotValidForProperty=The value '{0}' is invalid", args);
        }

        /// <summary>
        /// 序列化错误
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns></returns>
        public static object SerializeErrors(this ModelStateDictionary modelState)
        {
            return modelState.Where(entry => entry.Value.Errors.Any())
                .ToDictionary(entry => entry.Key, entry => SerializeModelState(entry.Value));
        }

        private static Dictionary<string, object> SerializeModelState(ModelState modelState)
        {
            var dictionary = new Dictionary<string, object>();
            dictionary["errors"] = modelState.Errors.Select(x => GetErrorMessage(x, modelState)).ToArray();
            return dictionary;
        }

        public static object ToDataSourceResult(this ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                return modelState.SerializeErrors();
            }
            return null;
        }
    }
}
