using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class CrawlArticle
{
    public int ArticleId { get; set; }

    public int WebsiteId { get; set; }

    public string? Title { get; set; }

    public string Url { get; set; } = null!;

    public string? Slug { get; set; }

    public string? OgImage { get; set; }

    public DateTime? PublishedDate { get; set; }

    public int? SitemapYear { get; set; }

    public int? SitemapMonth { get; set; }

    public byte? CrawlStatus { get; set; }

    public DateTime? CrawledDate { get; set; }

    public string? CrawlError { get; set; }

    public string? ContentHtml { get; set; }

    public string? ContentText { get; set; }

    public string? MetaDescription { get; set; }

    public string? MetaKeywords { get; set; }

    public int? TextLength { get; set; }

    public int? ParagraphCount { get; set; }

    public int? ImageCount { get; set; }

    public int? AudioCount { get; set; }

    public int? PdfCount { get; set; }

    public string? ResourcesJson { get; set; }

    public byte? EditStatus { get; set; }

    public DateTime? EditedDate { get; set; }

    public string? EditedBy { get; set; }

    public string? EditedHtml { get; set; }

    public DateTime? PublishedToWebDate { get; set; }

    public string? Notes { get; set; }

    public string? Tags { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual CrawlWebsite Website { get; set; } = null!;
}
