using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class CrawlWebsite
{
    public int WebsiteId { get; set; }

    public string WebsiteName { get; set; } = null!;

    public string BaseUrl { get; set; } = null!;

    public string? SitemapUrl { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual ICollection<CrawlArticle> CrawlArticles { get; set; } = new List<CrawlArticle>();

    public virtual ICollection<CrawlLog> CrawlLogs { get; set; } = new List<CrawlLog>();
}
