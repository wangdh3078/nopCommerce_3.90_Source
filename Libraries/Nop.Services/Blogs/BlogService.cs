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
    /// ���ͷ���
    /// </summary>
    public partial class BlogService : IBlogService
    {
        #region �ֶ�

        private readonly IRepository<BlogPost> _blogPostRepository;
        private readonly IRepository<BlogComment> _blogCommentRepository;
        private readonly IRepository<StoreMapping> _storeMappingRepository;
        private readonly CatalogSettings _catalogSettings;
        private readonly IEventPublisher _eventPublisher;

        #endregion

        #region ���캯��

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

        #region ����

        #region ��������

        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="blogPost">����</param>
        public virtual void DeleteBlogPost(BlogPost blogPost)
        {
            if (blogPost == null)
                throw new ArgumentNullException("blogPost");

            _blogPostRepository.Delete(blogPost);

            //event notification
            _eventPublisher.EntityDeleted(blogPost);
        }
        /// <summary>
        /// ����ID��ȡ����
        /// </summary>
        /// <param name="blogPostId">����ID</param>
        /// <returns>����</returns>
        public virtual BlogPost GetBlogPostById(int blogPostId)
        {
            if (blogPostId == 0)
                return null;

            return _blogPostRepository.GetById(blogPostId);
        }

        /// <summary>
        /// ��ȡ���ͼ���
        /// </summary>
        /// <param name="blogPostIds">����ID����</param>
        /// <returns>���ͼ���</returns>
        public virtual IList<BlogPost> GetBlogPostsByIds(int[] blogPostIds)
        {
            var query = _blogPostRepository.Table;
            return query.Where(bp => blogPostIds.Contains(bp.Id)).ToList();
        }

        /// <summary>
        /// ��ȡ���в���
        /// </summary>
        /// <param name="storeId">�̵��ʶ��; ����0�Լ������м�¼</param>
        /// <param name="languageId">���Ա�ʶ��; 0������������м�¼</param>
        /// <param name="dateFrom">���������ڹ���; ���Ҫ��ȡ���м�¼����Ϊnull</param>
        /// <param name="dateTo">���������ڹ���; ���Ҫ��ȡ���м�¼����Ϊnull</param>
        /// <param name="pageIndex">ҳ������</param>
        /// <param name="pageSize">ҳ���С</param>
        /// <param name="showHidden">ָʾ�Ƿ���ʾ���ؼ�¼��ֵ</param>
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
        /// ��ȡ���в���
        /// </summary>
        /// <param name="storeId">�̵��ʶ��; ����0�Լ������м�¼</param>
        /// <param name="languageId">���Ա�ʶ���� 0������������в�������</param>
        /// <param name="tag">��ǩ</param>
        /// <param name="pageIndex">ҳ������</param>
        /// <param name="pageSize">ҳ���С</param>
        /// <param name="showHidden">ָʾ�Ƿ���ʾ���ؼ�¼��ֵ</param>
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
        /// ��ȡ���в������ӱ�ǩ
        /// </summary>
        /// <param name="storeId">�̵��ʶ��; ����0�Լ������м�¼</param>
        /// <param name="languageId">���Ա�ʶ���� 0������������в�������</param>
        /// <param name="showHidden">ָʾ�Ƿ���ʾ���ؼ�¼��ֵ</param>
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
        /// ��Ӳ���
        /// </summary>
        /// <param name="blogPost">����</param>
        public virtual void InsertBlogPost(BlogPost blogPost)
        {
            if (blogPost == null)
                throw new ArgumentNullException("blogPost");

            _blogPostRepository.Insert(blogPost);

            //event notification
            _eventPublisher.EntityInserted(blogPost);
        }

        /// <summary>
        /// ���²���
        /// </summary>
        /// <param name="blogPost">����</param>
        public virtual void UpdateBlogPost(BlogPost blogPost)
        {
            if (blogPost == null)
                throw new ArgumentNullException("blogPost");

            _blogPostRepository.Update(blogPost);

            //event notification
            _eventPublisher.EntityUpdated(blogPost);
        }

        #endregion

        #region ��������

        /// <summary>
        /// ��ȡ���в�������
        /// </summary>
        /// <param name="customerId">�ͻ���ʶ; 0�������м�¼</param>
        /// <param name="storeId">�̵��ʶ; ����0�Լ������м�¼</param>
        /// <param name="blogPostId">��������ID; 0��null�Լ������м�¼</param>
        /// <param name="approved">��ʾ�Ƿ���׼���ݵ�ֵ; null�Լ������м�¼</param> 
        /// <param name="fromUtc">��Ŀ��������; null�Լ������м�¼</param>
        /// <param name="toUtc">��Ŀ������; null�Լ������м�¼</param>
        /// <param name="commentText">������������; null�Լ������м�¼</param>
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
        /// ��ȡ��������
        /// </summary>
        /// <param name="blogCommentId">�������۱�ʶ��</param>
        /// <returns></returns>
        public virtual BlogComment GetBlogCommentById(int blogCommentId)
        {
            if (blogCommentId == 0)
                return null;

            return _blogCommentRepository.GetById(blogCommentId);
        }

        /// <summary>
        /// ����ʶ����ȡ��������
        /// </summary>
        /// <param name="commentIds">�������۱�ʶ��</param>
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
        /// ��ȡ�������۵�����
        /// </summary>
        /// <param name="blogPost">����</param>
        /// <param name="storeId">�̵��ʶ; ����0�Լ������м�¼</param>
        /// <param name="isApproved">��ʾ�Ƿ����������׼��δ��׼�����۵�ֵ; ����null�Ի�ȡ����ע�͵�����</param>
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
        /// ɾ����������
        /// </summary>
        /// <param name="blogComment">��������</param>
        public virtual void DeleteBlogComment(BlogComment blogComment)
        {
            if (blogComment == null)
                throw new ArgumentNullException("blogComment");

            _blogCommentRepository.Delete(blogComment);

            //event notification
            _eventPublisher.EntityDeleted(blogComment);
        }

        /// <summary>
        /// ɾ����������
        /// </summary>
        /// <param name="blogComments">�������ۼ���</param>
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
