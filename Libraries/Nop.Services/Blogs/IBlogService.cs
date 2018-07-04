using System;
using System.Collections.Generic;
using Nop.Core;
using Nop.Core.Domain.Blogs;

namespace Nop.Services.Blogs
{
    /// <summary>
    /// 博客服务接口
    /// </summary>
    public partial interface IBlogService
    {
        #region 博客文章

        /// <summary>
        /// 删除博客
        /// </summary>
        /// <param name="blogPost">博客</param>
        void DeleteBlogPost(BlogPost blogPost);

        /// <summary>
        /// 根据ID获取博客
        /// </summary>
        /// <param name="blogPostId">博客ID</param>
        /// <returns>博客</returns>
        BlogPost GetBlogPostById(int blogPostId);

        /// <summary>
        /// 获取博客集合
        /// </summary>
        /// <param name="blogPostIds">博客ID集合</param>
        /// <returns>博客集合</returns>
        IList<BlogPost> GetBlogPostsByIds(int[] blogPostIds);

        /// <summary>
        /// 获取所有博客
        /// </summary>
        /// <param name="storeId">商店标识符; 传递0以加载所有记录</param>
        /// <param name="languageId">语言标识符; 0如果你想获得所有记录</param>
        /// <param name="dateFrom">按创建日期过滤; 如果要获取所有记录，请为null</param>
        /// <param name="dateTo">按创建日期过滤; 如果要获取所有记录，请为null</param>
        /// <param name="pageIndex">页面索引</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="showHidden">指示是否显示隐藏记录的值</param>
        /// <returns></returns>
        IPagedList<BlogPost> GetAllBlogPosts(int storeId = 0, int languageId = 0,
            DateTime? dateFrom = null, DateTime? dateTo = null, 
            int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false);

        /// <summary>
        /// 获取所有博客
        /// </summary>
        /// <param name="storeId">商店标识符; 传递0以加载所有记录</param>
        /// <param name="languageId">语言标识符。 0如果你想获得所有博客帖子</param>
        /// <param name="tag">标签</param>
        /// <param name="pageIndex">页面索引</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="showHidden">指示是否显示隐藏记录的值</param>
        /// <returns></returns>
        IPagedList<BlogPost> GetAllBlogPostsByTag(int storeId = 0,
            int languageId = 0, string tag = "",
            int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false);

        /// <summary>
        /// 获取所有博客帖子标签
        /// </summary>
        /// <param name="storeId">商店标识符; 传递0以加载所有记录</param>
        /// <param name="languageId">语言标识符。 0如果你想获得所有博客帖子</param>
        /// <param name="showHidden">指示是否显示隐藏记录的值</param>
        /// <returns></returns>
        IList<BlogPostTag> GetAllBlogPostTags(int storeId, int languageId, bool showHidden = false);

        /// <summary>
        /// 添加博客
        /// </summary>
        /// <param name="blogPost">博客</param>
        void InsertBlogPost(BlogPost blogPost);

        /// <summary>
        /// 更新博客
        /// </summary>
        /// <param name="blogPost">博客</param>
        void UpdateBlogPost(BlogPost blogPost);

        #endregion

        #region 博客评论

        /// <summary>
        /// 获取所有博客评论
        /// </summary>
        /// <param name="customerId">客户标识; 0加载所有记录</param>
        /// <param name="storeId">商店标识; 传递0以加载所有记录</param>
        /// <param name="blogPostId">博客帖子ID; 0或null以加载所有记录</param>
        /// <param name="approved">表示是否批准内容的值; null以加载所有记录</param> 
        /// <param name="fromUtc">项目创建来自; null以加载所有记录</param>
        /// <param name="toUtc">项目创建到; null以加载所有记录</param>
        /// <param name="commentText">搜索评论文字; null以加载所有记录</param>
        /// <returns></returns>
        IList<BlogComment> GetAllComments(int customerId = 0, int storeId = 0, int? blogPostId = null,
            bool? approved = null, DateTime? fromUtc = null, DateTime? toUtc = null, string commentText = null);

        /// <summary>
        /// 获取博客评论
        /// </summary>
        /// <param name="blogCommentId">博客评论标识符</param>
        /// <returns></returns>
        BlogComment GetBlogCommentById(int blogCommentId);

        /// <summary>
        /// 按标识符获取博客评论
        /// </summary>
        /// <param name="commentIds">博客评论标识符</param>
        /// <returns></returns>
        IList<BlogComment> GetBlogCommentsByIds(int[] commentIds);

        /// <summary>
        /// 获取博客评论的数量
        /// </summary>
        /// <param name="blogPost">博客</param>
        /// <param name="storeId">商店标识; 传递0以加载所有记录</param>
        /// <param name="isApproved">表示是否仅计算已批准或未批准的评论的值; 传递null以获取所有注释的数量</param>
        /// <returns></returns>
        int GetBlogCommentsCount(BlogPost blogPost, int storeId = 0, bool? isApproved = null);

        /// <summary>
        /// 删除博客评论
        /// </summary>
        /// <param name="blogComment">博客评论</param>
        void DeleteBlogComment(BlogComment blogComment);

        /// <summary>
        /// 删除博客评论
        /// </summary>
        /// <param name="blogComments">博客评论集合</param>
        void DeleteBlogComments(IList<BlogComment> blogComments);

        #endregion
    }
}
