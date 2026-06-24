using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class InventoryHistory
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string ShopCode { get; set; } = null!;

    public string ChangeType { get; set; } = null!;

    public int Quantity { get; set; }

    public int? StockBefore { get; set; }

    public int? StockAfter { get; set; }

    public string? Notes { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }
}
