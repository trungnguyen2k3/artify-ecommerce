using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class CsmConsignmentLog
{
    public int Id { get; set; }

    public int ConsignmentId { get; set; }

    public string Action { get; set; } = null!;

    public string? OldValue { get; set; }

    public string? NewValue { get; set; }

    public string? Note { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }
}
