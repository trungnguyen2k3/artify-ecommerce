using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class VisitorSession
{
    public int Id { get; set; }

    public string SessionId { get; set; } = null!;

    public string? IpAddress { get; set; }

    public string? FirstPage { get; set; }

    public string? LastPage { get; set; }

    public int PageCount { get; set; }

    public DateTime StartedAt { get; set; }

    public DateTime? EndedAt { get; set; }

    public int? DurationSeconds { get; set; }

    public string? UtmSource { get; set; }

    public string? UtmMedium { get; set; }

    public string? UtmCampaign { get; set; }

    public string? Country { get; set; }

    public string? City { get; set; }

    public string? Device { get; set; }
}
