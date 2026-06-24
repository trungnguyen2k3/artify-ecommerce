using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class PageView
{
    public int Id { get; set; }

    public string? SessionId { get; set; }

    public string? IpAddress { get; set; }

    public string Url { get; set; } = null!;

    public string? Referrer { get; set; }

    public string? UserAgent { get; set; }

    public string? UtmSource { get; set; }

    public string? UtmMedium { get; set; }

    public string? UtmCampaign { get; set; }

    public string? Country { get; set; }

    public string? City { get; set; }

    public string? Device { get; set; }

    public DateTime CreatedAt { get; set; }
}
