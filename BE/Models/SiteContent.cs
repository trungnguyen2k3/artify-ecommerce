using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class SiteContent
{
    public int ContentId { get; set; }

    public string ContentKey { get; set; } = null!;

    public string? ContentValue { get; set; }

    public string ContentType { get; set; } = null!;

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
