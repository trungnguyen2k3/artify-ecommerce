using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class BlogProductEditRequest
{
    public int Id { get; set; }

    public int BlogProductId { get; set; }

    public int RequestedByAdminId { get; set; }

    public string OldDataJson { get; set; } = null!;

    public string NewDataJson { get; set; } = null!;

    public string Status { get; set; } = null!;

    public int? ResolvedByAdminId { get; set; }

    public DateTime? ResolvedAt { get; set; }

    public string? RejectReason { get; set; }

    public DateTime CreatedAt { get; set; }
}
