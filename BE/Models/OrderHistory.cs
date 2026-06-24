using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class OrderHistory
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public string ActionType { get; set; } = null!;

    public string? ActionBy { get; set; }

    public DateTime ActionDate { get; set; }

    public string? OldData { get; set; }

    public string? NewData { get; set; }

    public string? ChangeSummary { get; set; }

    public virtual Order Order { get; set; } = null!;
}
