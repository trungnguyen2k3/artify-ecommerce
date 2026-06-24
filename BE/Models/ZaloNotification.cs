using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class ZaloNotification
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public string ZaloUserId { get; set; } = null!;

    public string TemplateId { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string? Response { get; set; }

    public DateTime? SentAt { get; set; }
}
