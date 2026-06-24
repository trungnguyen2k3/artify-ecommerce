using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class CrawlLog
{
    public int LogId { get; set; }

    public int WebsiteId { get; set; }

    public int? SitemapYear { get; set; }

    public int? SitemapMonth { get; set; }

    public int? TotalArticles { get; set; }

    public int? CrawledCount { get; set; }

    public int? SuccessCount { get; set; }

    public int? FailedCount { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public string? Status { get; set; }

    public string? ErrorMessage { get; set; }

    public virtual CrawlWebsite Website { get; set; } = null!;
}
