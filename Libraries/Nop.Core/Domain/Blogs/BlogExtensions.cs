using System;
using System.Collections.Generic;

namespace Nop.Core.Domain.Blogs
{
    /// <summary>
    /// 博客扩展
    /// </summary>
    public static class BlogExtensions
    {
        /// <summary>
        /// 解析博客标签
        /// </summary>
        /// <param name="blogPost">博客</param>
        /// <returns></returns>
        public static string[] ParseTags(this BlogPost blogPost)
        {
            if (blogPost == null)
                throw new ArgumentNullException("blogPost");

            var parsedTags = new List<string>();
            if (!String.IsNullOrEmpty(blogPost.Tags))
            {
                string[] tags2 = blogPost.Tags.Split(new [] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string tag2 in tags2)
                {
                    var tmp = tag2.Trim();
                    if (!String.IsNullOrEmpty(tmp))
                        parsedTags.Add(tmp);
                }
            }
            return parsedTags.ToArray();
        }
    }
}
