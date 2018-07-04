using System;
using System.Collections.Generic;
using System.Linq;
using Nop.Core.Domain.Blogs;

namespace Nop.Services.Blogs
{
    /// <summary>
    /// ��չ
    /// </summary>
    public static class BlogExtensions
    {
        /// <summary>
        /// ������������֮�䷢�����������ӡ�
        /// </summary>
        /// <param name="source">����Դ</param>
        /// <param name="dateFrom">��ʼ����</param>
        /// <param name="dateTo">��������</param>
        /// <returns></returns>
        public static IList<BlogPost> GetPostsByDate(this IList<BlogPost> source,
            DateTime dateFrom, DateTime dateTo)
        {
            return source.Where(p => dateFrom.Date <= (p.StartDateUtc ?? p.CreatedOnUtc) && 
            (p.StartDateUtc ?? p.CreatedOnUtc).Date <= dateTo).ToList();
        }
    }
}
