#region Copyright ?2001-2003 Jean-Claude Manoli [jc@manoli.net]
/*
 * This software is provided 'as-is', without any express or implied warranty.
 * In no event will the author(s) be held liable for any damages arising from
 * the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 *   1. The origin of this software must not be misrepresented; you must not
 *      claim that you wrote the original software. If you use this software
 *      in a product, an acknowledgment in the product documentation would be
 *      appreciated but is not required.
 * 
 *   2. Altered source versions must be plainly marked as such, and must not
 *      be misrepresented as being the original software.
 * 
 *   3. This notice may not be removed or altered from any source distribution.
 */ 
#endregion

using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Nop.Core.Html.CodeFormatter
{
    /// <summary>
    /// 提供格式化大多数编程语言的基类。
    /// </summary>
    public abstract partial class CodeFormat : SourceFormat
	{
        /// <summary>
        /// 必须被覆盖以提供每种语言中定义的关键字列表。
        /// </summary>
        /// <remarks>
        /// 关键字必须用空格分隔。
        /// </remarks>
        protected abstract string Keywords 
		{
			get;
		}

        /// <summary>
        /// 可以重写提供每种语言中定义的预处理器列表。
        /// </summary>
        /// <remarks>
        ///预处理器必须用空格分隔。
        /// </remarks>
        protected virtual string Preprocessors
		{
			get { return ""; }
		}

        /// <summary>
        ///必须重写以提供正则表达式字符串以匹配字符串文字。
        /// </summary>
        protected abstract string StringRegex
		{
			get;
		}

        /// <summary>
        ///必须重写以提供正则表达式字符串以匹配注释。
        /// </summary>
        protected abstract string CommentRegex
		{
			get;
		}

        /// <summary>
        ///确定语言是否区分大小写。
        /// </summary>
        /// <value>如果语言区分大小写，则为<b> true </b>，否则为<b> false </b>。 默认值为true。</value>
        /// <remarks>
        ///不区分大小写的语言格式化程序必须重写此属性以返回false。
        /// </remarks>
        public virtual bool CaseSensitive
		{
			get { return true; }
		}

		/// <summary/>
		protected CodeFormat()
		{
            //从关键字列表中生成关键字和预处理器正则表达式
            var r = new Regex(@"\w+|-\w+|#\w+|@@\w+|#(?:\\(?:s|w)(?:\*|\+)?\w+)+|@\\w\*+");
			string regKeyword = r.Replace(Keywords, @"(?<=^|\W)$0(?=\W)");
			string regPreproc = r.Replace(Preprocessors, @"(?<=^|\s)$0(?=\s|$)");
			r = new Regex(@" +");
			regKeyword = r.Replace(regKeyword, @"|");
			regPreproc = r.Replace(regPreproc, @"|");

			if (regPreproc.Length == 0)
			{
				regPreproc = "(?!.*)_{37}(?<!.*)"; //use something quite impossible...
			}

			//build a master regex with capturing groups
            var regAll = new StringBuilder();
			regAll.Append("(");
			regAll.Append(CommentRegex);
			regAll.Append(")|(");
			regAll.Append(StringRegex);
			//if (regPreproc.Length > 0)
			//{
				regAll.Append(")|(");
				regAll.Append(regPreproc);
			//}
			regAll.Append(")|(");
			regAll.Append(regKeyword);
			regAll.Append(")");

			RegexOptions caseInsensitive = CaseSensitive ? 0 : RegexOptions.IgnoreCase;
			CodeRegex = new Regex(regAll.ToString(), RegexOptions.Singleline | caseInsensitive);
		}

        /// <summary>
        /// 被调用以评估代码中与每个匹配标记对应的HTML片段。
        /// </summary>
        /// <param name="match">see cref ="Match"/>由单个正则表达式匹配产生。</param>
        /// <returns>包含HTML代码片段的字符串。</returns>
        protected override string MatchEval(Match match)
		{
			if(match.Groups[1].Success) //comment
			{
                var reader = new StringReader(match.ToString());
				string line;
                var sb = new StringBuilder();
				while ((line = reader.ReadLine()) != null)
				{
					if(sb.Length > 0)
					{
						sb.Append("\n");
					}
					sb.Append("<span class=\"rem\">");
					sb.Append(line);
					sb.Append("</span>");
				}
				return sb.ToString();
			}
			if(match.Groups[2].Success) //string literal
			{
				return "<span class=\"str\">" + match.ToString() + "</span>";
			}
			if(match.Groups[3].Success) //preprocessor keyword
			{
				return "<span class=\"preproc\">" + match.ToString() + "</span>";
			}
			if(match.Groups[4].Success) //keyword
			{
				return "<span class=\"kwrd\">" + match.ToString() + "</span>";
			}
			System.Diagnostics.Debug.Assert(false, "None of the above!");
			return ""; //none of the above
		}
	}
}

