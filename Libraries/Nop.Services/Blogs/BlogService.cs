using System;
using System.Collections.Generic;
using System.Linq;
using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Domain.Blogs;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Stores;
using Nop.Services.Events;

namespace Nop.Services.Blogs
{
    /// <summary>
    /// 博客服务
    /// </summary>
    public partial class BlogService : IBlogService
    {
        #region 字段

        private readonly IRepository<BlogPost> _blogPostRepository;
        private readonly IRepository<BlogComment> _blogCommentRepository;
        private readonly IRepository<StoreMapping> _storeMappingRepository;
        private readonly CatalogSettings _catalogSettings;
        private readonly IEventPublisher _eventPublisher;

        #endregion

        #region 构造函数

        public BlogService(IRepository<BlogPost> blogPostRepository,
            IRepository<BlogComment> blogCommentRepository,
            IRepository<StoreMapping> storeMappingRepository,
            CatalogSettings catalogSettings,
            IEventPublisher eventPublisher)
        {
            this._blogPostRepository = blogPostRepository;
            this._blogCommentRepository = blogCommentRepository;
            this._storeMappingRepository = storeMappingRepository;
            this._catalogSettings = catalogSettings;
            this._eventPublisher = eventPublisher;
        }

        #endregion

        #region 方法

        #region 博客文章

        /// <summary>
        /// 删除博客
        /// </summary>
        /// <param name="blogPost">博客</param>
        public virtual void DeleteBlogPost(BlogPost blogPost)
        {
            if (blogPost == null)
                throw new ArgumentNullException("blogPost");

            _blogPostRepository.Delete(blogPost);

            //event notification
            _eventPublisher.EntityDeleted(blogPost);
        }
        /// <summary>
        /// 根据ID获取博客
        /// </summary>
        /// <param name="blogPostId">博客ID</param>
        /// <returns>博客</returns>
        public virtual BlogPost GetBlogPostById(int blogPostId)
        {
            if (blogPostId == 0)
                return null;

            return _blogPostRepository.GetById(blogPostId);
        }

        /// <summary>
        /// 获取博客集合
        /// </summary>
        /// <param name="blogPostIds">博客ID集合</param>
        /// <returns>博客集合</returns>
        public virtual IList<BlogPost> GetBlogPostsByIds(int[] blogPostIds)
        {
            var query = _blogPostRepository.Table;
            return query.Where(bp => blogPostIds.Contains(bp.Id)).ToList();
        }

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
        public virtual IPagedList<BlogPost> GetAllBlogPosts(int storeId = 0, int languageId = 0,
            DateTime? dateFrom = null, DateTime? dateTo = null,
            int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            var query = _blogPostRepository.Table;
            if (dateFrom.HasValue)
                query = query.Where(b => dateFrom.Value <= (b.StartDateUtc ?? b.CreatedOnUtc));
            if (dateTo.HasValue)
                query = query.Where(b => dateTo.Value >= (b.StartDateUtc ?? b.CreatedOnUtc));
            if (languageId > 0)
                query = query.Where(b => languageId == b.LanguageId);
            if (!showHidden)
            {
                //The function 'CurrentUtcDateTime' is not supported by SQL Server Compact. 
                //That's why we pass the date value
                var utcNow = DateTime.UtcNow;
                query = query.Where(b => !b.StartDateUtc.HasValue || b.StartDateUtc <= utcNow);
                query = query.Where(b => !b.EndDateUtc.HasValue || b.EndDateUtc >= utcNow);
            }

            if (storeId > 0 && !_catalogSettings.IgnoreStoreLimitations)
            {
                //Store mapping
                query = from bp in query
                        join sm in _storeMappingRepository.Table
                        on new { c1 = bp.Id, c2 = "BlogPost" } equals new { c1 = sm.EntityId, c2 = sm.EntityName } into bp_sm
                        from sm in bp_sm.DefaultIfEmpty()
                        where !bp.LimitedToStores || storeId == sm.StoreId
                        select bp;

                //only distinct blog posts (group by ID)
                query = from bp in query
                        group bp by bp.Id
                        into bpGroup
                        orderby bpGroup.Key
                        select bpGroup.FirstOrDefault();
            }

            query = query.OrderByDescending(b => b.StartDateUtc ?? b.CreatedOnUtc);

            var blogPosts = new PagedList<BlogPost>(query, pageIndex, pageSize);
            return blogPosts;
        }

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
        public virtual IPagedList<BlogPost> GetAllBlogPostsByTag(int storeId = 0,
            int languageId = 0, string tag = "",
            int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            tag = tag.Trim();

            //we load all records and only then filter them by tag
            var blogPostsAll = GetAllBlogPosts(storeId: storeId, languageId: languageId, showHidden: showHidden);
            var taggedBlogPosts = new List<BlogPost>();
            foreach (var blogPost in blogPostsAll)
            {
                var tags = blogPost.ParseTags();
                if (!String.IsNullOrEmpty(tags.FirstOrDefault(t => t.Equals(tag, StringComparison.InvariantCultureIgnoreCase))))
                    taggedBlogPosts.Add(blogPost);
            }

            //server-side paging
            var result = new PagedList<BlogPost>(taggedBlogPosts, pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// 获取所有博客帖子标签
        /// </summary>
        /// <param name="storeId">商店标识符; 传递0以加载所有记录</param>
        /// <param name="languageId">语言标识符。 0如果你想获得所有博客帖子</param>
        /// <param name="showHidden">指示是否显示隐藏记录的值</param>
        /// <returns></returns>
        public virtual IList<BlogPostTag> GetAllBlogPostTags(int storeId, int languageId, bool showHidden = false)
        {
            var blogPostTags = new List<BlogPostTag>();

            var blogPosts = GetAllBlogPosts(storeId: storeId, languageId: languageId, showHidden: showHidden);
            foreach (var blogPost in blogPosts)
            {
                var tags = blogPost.ParseTags();
                foreach (string tag in tags)
                {
                    var foundBlogPostTag = blogPostTags.Find(bpt => bpt.Name.Equals(tag, StringComparison.InvariantCultureIgnoreCase));
                    if (foundBlogPostTag == null)
                    {
                        foundBlogPostTag = new BlogPostTag
                        {
                            Name = tag,
                            BlogPostCount = 1
                        };
                        blogPostTags.Add(foundBlogPostTag);
                    }
                    else
                        foundBlogPostTag.BlogPostCount++;
                }
            }

            return blogPostTags;
        }

        /// <summary>
        /// 添加博客
        /// </summary>
        /// <param name="blogPost">博客</param>
        public virtual void InsertBlogPost(BlogPost blogPost)
        {
            if (blogPost == null)
                throw new ArgumentNullException("blogPost");

            _blogPostRepository.Insert(blogPost);

            //event notification
            _eventPublisher.EntityInserted(blogPost);
        }

        /// <summary>
        /// 更新博客
        /// </summary>
        /// <param name="blogPost">博客</param>
        public virtual void UpdateBlogPost(BlogPost blogPost)
        {
            if (blogPost == null)
                throw new ArgumentNullException("blogPost");

            _blogPostRepository.Update(blogPost);

            //event notification
            _eventPublisher.EntityUpdated(blogPost);
        }

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
        public virtual IList<BlogComment> GetAllComments(int customerId = 0, int storeId = 0, int? blogPostId = null,
            bool? approved = null, DateTime? fromUtc = null, DateTime? toUtc = null, string commentText = null)
        {
            var query = _blogCommentRepository.Table;

            if (approved.HasValue)
                query = query.Where(comment => comment.IsApproved == approved);

            if (blogPostId > 0)
                query = query.Where(comment => comment.BlogPostId == blogPostId);

            if (customerId > 0)
                query = query.Where(comment => comment.CustomerId == customerId);

            if (storeId > 0)
                query = query.Where(comment => comment.StoreId == storeId);

            if (fromUtc.HasValue)
                query = query.Where(comment => fromUtc.Value <= comment.CreatedOnUtc);

            if (toUtc.HasValue)
                query = query.Where(comment => toUtc.Value >= comment.CreatedOnUtc);

            if (!string.IsNullOrEmpty(commentText))
                query = query.Where(c => c.CommentText.Contains(commentText));

            query = query.OrderBy(comment => comment.CreatedOnUtc);

            return query.ToList();
        }

        /// <summary>
        /// 获取博客评论
        /// </summary>
        /// <param name="blogCommentId">博客评论标识符</param>
        /// <returns></returns>
        public virtual BlogComment GetBlogCommentById(int blogCommentId)
        {
            if (blogCommentId == 0)
                return null;

            return _blogCommentRepository.GetById(blogCommentId);
        }

        /// <summary>
        /// 按标识符获取博客评论
        /// </summary>
        /// <param name="commentIds">博客评论标识符</param>
        /// <returns></returns>
        public virtual IList<BlogComment> GetBlogCommentsByIds(int[] commentIds)
        {
            if (commentIds == null || commentIds.Length == 0)
                return new List<BlogComment>();

            var query = from bc in _blogCommentRepository.Table
                        where commentIds.Contains(bc.Id)
                        select bc;
            var comments = query.ToList();
            //sort by passed identifiers
            var sortedComments = new List<BlogComment>();
            foreach (int id in commentIds)
            {
                var comment = comments.Find(x => x.Id == id);
                if (comment != null)
                    sortedComments.Add(comment);
            }
            return sortedComments;
        }

        /// <summary>
        /// 获取博客评论的数量
        /// </summary>
        /// <param name="blogPost">博客</param>
        /// <param name="storeId">商店标识; 传递0以加载所有记录</param>
        /// <param name="isApproved">表示是否仅计算已批准或未批准的评论的值; 传递null以获取所有注释的数量</param>
        /// <returns></returns>
        public virtual int GetBlogCommentsCount(BlogPost blogPost, int storeId = 0, bool? isApproved = null)
        {
            var query = _blogCommentRepository.Table.Where(comment => comment.BlogPostId == blogPost.Id);

            if (storeId > 0)
                query = query.Where(comment => comment.StoreId == storeId);

            if (isApproved.HasValue)
                query = query.Where(comment => comment.IsApproved == isApproved.Value);

            return query.Count();
        }

        /// <summary>
        /// 删除博客评论
        /// </summary>
        /// <param name="blogComment">博客评论</param>
        public virtual void DeleteBlogComment(BlogComment blogComment)
        {
            if (blogComment == null)
                throw new ArgumentNullException("blogComment");

            _blogCommentRepository.Delete(blogComment);

            //event notification
            _eventPublisher.EntityDeleted(blogComment);
        }

        /// <summary>
        /// 删除博客评论
        /// </summary>
        /// <param name="blogComments">博客评论集合</param>
        public virtual void DeleteBlogComments(IList<BlogComment> blogComments)
        {
            if (blogComments == null)
                throw new ArgumentNullException("blogComments");

            foreach (var blogComment in blogComments)
            {
                DeleteBlogComment(blogComment);
            }
        }

        #endregion

        #endregion
    }
}
