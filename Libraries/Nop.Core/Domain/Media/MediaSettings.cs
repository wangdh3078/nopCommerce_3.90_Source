
using Nop.Core.Configuration;

namespace Nop.Core.Domain.Media
{
    /// <summary>
    /// 媒体设置
    /// </summary>
    public class MediaSettings : ISettings
    {
        /// <summary>
        /// 客户头像的图片大小（如果启用）
        /// </summary>
        public int AvatarPictureSize { get; set; }
        /// <summary>
        ///目录页面上显示的产品图片缩略图的图片大小（例如，类别详细信息页面）
        /// </summary>
        public int ProductThumbPictureSize { get; set; }
        /// <summary>
        ///产品详细信息页面上显示的主要产品图片的图片尺寸
        /// </summary>
        public int ProductDetailsPictureSize { get; set; }
        /// <summary>
        /// 产品详细信息页面上显示的产品图片缩略图的图片大小
        /// </summary>
        public int ProductThumbPictureSizeOnProductDetailsPage { get; set; }
        /// <summary>
        /// 相关产品图片大小
        /// </summary>
        public int AssociatedProductPictureSize { get; set; }
        /// <summary>
        /// 类别图片的图片大小
        /// </summary>
        public int CategoryThumbPictureSize { get; set; }
        /// <summary>
        /// 制造商图片的图片尺寸
        /// </summary>
        public int ManufacturerThumbPictureSize { get; set; }
        /// <summary>
        /// 供应商图片的图片尺寸
        /// </summary>
        public int VendorThumbPictureSize { get; set; }
        /// <summary>
        /// 购物车页面上产品图片的图片尺寸
        /// </summary>
        public int CartThumbPictureSize { get; set; }
        /// <summary>
        /// 迷你运输车箱的产品图片的图片尺寸
        /// </summary>
        public int MiniCartThumbPictureSize { get; set; }
        /// <summary>
        /// 自动填充搜索框的产品图片的图片大小
        /// </summary>
        public int AutoCompleteSearchThumbPictureSize { get; set; }
        /// <summary>
        ///产品详细信息页面上的图像正方形的图片大小（与“图片正方形”属性类型一起使用
        /// </summary>
        public int ImageSquarePictureSize { get; set; }
        /// <summary>
        /// 指示是否启用图片缩放的值
        /// </summary>
        public bool DefaultPictureZoomEnabled { get; set; }
        /// <summary>
        /// 允许的最大图片大小。 如果上传更大的图片，则会调整大小
        /// </summary>
        public int MaximumImageSize { get; set; }
        /// <summary>
        /// 获取或设置用于图像生成的默认质量
        /// </summary>
        public int DefaultImageQuality { get; set; }
        /// <summary>
        /// 获取或设置一个值，指示单张（/ content / images / thumbs /）或多个（/ content / images / thumbs / 001 /和/ content / images / thumbs / 002 /）目录是否将用于图片缩略图
        /// </summary>
        public bool MultipleThumbDirectories { get; set; }
        /// <summary>
        /// 获取或设置一个值，该值指示在导入产品时是否应使用快速HASHBYTES（哈希总和）数据库函数来比较图片
        /// </summary>
        public bool ImportProductImagesUsingHash { get; set; }

        /// <summary>
        ///获取或设置Azure CacheControl标题（例如“max-age = 3600，public”）
        /// </summary>
        /// <remarks>
        ///max-age=[seconds]     — specifies the maximum amount of time that a representation will be considered fresh. Similar to Expires, this directive is relative to the time of the request, rather than absolute. [seconds] is the number of seconds from the time of the request you wish the representation to be fresh for.
        ///s-maxage=[seconds]    — similar to max-age, except that it only applies to shared (e.g., proxy) caches.
        ///public                — marks authenticated responses as cacheable; normally, if HTTP authentication is required, responses are automatically private.
        ///private               — allows caches that are specific to one user (e.g., in a browser) to store the response; shared caches (e.g., in a proxy) may not.
        ///no-cache              — forces caches to submit the request to the origin server for validation before releasing a cached copy, every time. This is useful to assure that authentication is respected (in combination with public), or to maintain rigid freshness, without sacrificing all of the benefits of caching.
        ///no-store              — instructs caches not to keep a copy of the representation under any conditions.
        ///must-revalidate       — tells caches that they must obey any freshness information you give them about a representation. HTTP allows caches to serve stale representations under special conditions; by specifying this header, you’re telling the cache that you want it to strictly follow your rules.
        ///proxy-revalidate      — similar to must-revalidate, except that it only applies to proxy caches.
        /// </remarks>
        public string AzureCacheControlHeader { get; set; }
    }
}