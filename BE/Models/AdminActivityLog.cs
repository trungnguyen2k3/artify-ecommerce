using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class AdminActivityLog
{
    public long Id { get; set; }

    public int AdminUserId { get; set; }

    public string AdminUsername { get; set; } = null!;

    public string AdminDisplayName { get; set; } = null!;

    public string ActionType { get; set; } = null!;

    public string? EntityId { get; set; }

    public string? IpAddress { get; set; }

    public string? RequestPath { get; set; }

    public DateTime CreatedAt { get; set; }

    public string TableName { get; set; } = null!;

    public string? OldValues { get; set; }

    public string? NewValues { get; set; }

    public string? ChangedColumns { get; set; }
}
