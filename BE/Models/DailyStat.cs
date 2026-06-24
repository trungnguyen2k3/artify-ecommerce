using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class DailyStat
{
    public int Id { get; set; }

    public DateOnly Date { get; set; }

    public int TotalViews { get; set; }

    public int UniqueVisitors { get; set; }

    public int TotalSessions { get; set; }

    public int AvgDurationSeconds { get; set; }

    public double AvgPagesPerSession { get; set; }

    public double BounceRate { get; set; }

    public string? TopPage { get; set; }

    public string? TopUtmSource { get; set; }

    public int MobileCount { get; set; }

    public int DesktopCount { get; set; }

    public DateTime CreatedAt { get; set; }
}
