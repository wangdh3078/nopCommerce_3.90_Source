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
    /// �ṩ��ʽ�������������ԵĻ��ࡣ
    /// </summary>
    public abstract partial class CodeFormat : SourceFormat
	{
        /// <summary>
        /// ���뱻�������ṩÿ�������ж���Ĺؼ����б�
        /// </summary>
        /// <remarks>
        /// �ؼ��ֱ����ÿո�ָ���
        /// </remarks>
        protected abstract string Keywords 
		{
			get;
		}

        /// <summary>
        /// ������д�ṩÿ�������ж����Ԥ�������б�
        /// </summary>
        /// <remarks>
        ///Ԥ�����������ÿո�ָ���
        /// </remarks>
        protected virtual string Preprocessors
		{
			get { return ""; }
		}

        /// <summary>
        ///������д���ṩ������ʽ�ַ�����ƥ���ַ������֡�
        /// </summary>
        protected abstract string StringRegex
		{
			get;
		}

        /// <summary>
        ///������д���ṩ������ʽ�ַ�����ƥ��ע�͡�
        /// </summary>
        protected abstract string CommentRegex
		{
			get;
		}

        /// <summary>
        ///ȷ�������Ƿ����ִ�Сд��
        /// </summary>
        /// <value>����������ִ�Сд����Ϊ<b> true </b>������Ϊ<b> false </b>�� Ĭ��ֵΪtrue��</value>
        /// <remarks>
        ///�����ִ�Сд�����Ը�ʽ�����������д�������Է���false��
        /// </remarks>
        public virtual bool CaseSensitive
		{
			get { return true; }
		}

		/// <summary/>
		protected CodeFormat()
		{
            //�ӹؼ����б������ɹؼ��ֺ�Ԥ������������ʽ
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
        /// ��������������������ÿ��ƥ���Ƕ�Ӧ��HTMLƬ�Ρ�
        /// </summary>
        /// <param name="match">see cref ="Match"/>�ɵ���������ʽƥ�������</param>
        /// <returns>����HTML����Ƭ�ε��ַ�����</returns>
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

