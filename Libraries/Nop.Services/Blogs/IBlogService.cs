using System;
using System.Collections.Generic;
using Nop.Core;
using Nop.Core.Domain.Blogs;

namespace Nop.Services.Blogs
{
    /// <summary>
    /// ���ͷ���ӿ�
    /// </summary>
    public partial interface IBlogService
    {
        #region ��������

        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="blogPost">����</param>
        void DeleteBlogPost(BlogPost blogPost);

        /// <summary>
        /// ����ID��ȡ����
        /// </summary>
        /// <param name="blogPostId">����ID</param>
        /// <returns>����</returns>
        BlogPost GetBlogPostById(int blogPostId);

        /// <summary>
        /// ��ȡ���ͼ���
        /// </summary>
        /// <param name="blogPostIds">����ID����</param>
        /// <returns>���ͼ���</returns>
        IList<BlogPost> GetBlogPostsByIds(int[] blogPostIds);

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
        IPagedList<BlogPost> GetAllBlogPosts(int storeId = 0, int languageId = 0,
            DateTime? dateFrom = null, DateTime? dateTo = null, 
            int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false);

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
        IPagedList<BlogPost> GetAllBlogPostsByTag(int storeId = 0,
            int languageId = 0, string tag = "",
            int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false);

        /// <summary>
        /// ��ȡ���в������ӱ�ǩ
        /// </summary>
        /// <param name="storeId">�̵��ʶ��; ����0�Լ������м�¼</param>
        /// <param name="languageId">���Ա�ʶ���� 0������������в�������</param>
        /// <param name="showHidden">ָʾ�Ƿ���ʾ���ؼ�¼��ֵ</param>
        /// <returns></returns>
        IList<BlogPostTag> GetAllBlogPostTags(int storeId, int languageId, bool showHidden = false);

        /// <summary>
        /// ��Ӳ���
        /// </summary>
        /// <param name="blogPost">����</param>
        void InsertBlogPost(BlogPost blogPost);

        /// <summary>
        /// ���²���
        /// </summary>
        /// <param name="blogPost">����</param>
        void UpdateBlogPost(BlogPost blogPost);

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
        IList<BlogComment> GetAllComments(int customerId = 0, int storeId = 0, int? blogPostId = null,
            bool? approved = null, DateTime? fromUtc = null, DateTime? toUtc = null, string commentText = null);

        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <param name="blogCommentId">�������۱�ʶ��</param>
        /// <returns></returns>
        BlogComment GetBlogCommentById(int blogCommentId);

        /// <summary>
        /// ����ʶ����ȡ��������
        /// </summary>
        /// <param name="commentIds">�������۱�ʶ��</param>
        /// <returns></returns>
        IList<BlogComment> GetBlogCommentsByIds(int[] commentIds);

        /// <summary>
        /// ��ȡ�������۵�����
        /// </summary>
        /// <param name="blogPost">����</param>
        /// <param name="storeId">�̵��ʶ; ����0�Լ������м�¼</param>
        /// <param name="isApproved">��ʾ�Ƿ����������׼��δ��׼�����۵�ֵ; ����null�Ի�ȡ����ע�͵�����</param>
        /// <returns></returns>
        int GetBlogCommentsCount(BlogPost blogPost, int storeId = 0, bool? isApproved = null);

        /// <summary>
        /// ɾ����������
        /// </summary>
        /// <param name="blogComment">��������</param>
        void DeleteBlogComment(BlogComment blogComment);

        /// <summary>
        /// ɾ����������
        /// </summary>
        /// <param name="blogComments">�������ۼ���</param>
        void DeleteBlogComments(IList<BlogComment> blogComments);

        #endregion
    }
}
