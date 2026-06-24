using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class CsmHandoverDetail
{
    public int Id { get; set; }

    public int HandoverId { get; set; }

    public string Sku { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public int Quantity { get; set; }

    public string? VariantInfo { get; set; }

    public decimal RetailPrice { get; set; }

    public int? ProductId { get; set; }

    public string? ProductType { get; set; }

    public string? Unit { get; set; }

    public decimal? TotalAmount { get; set; }

    public decimal? DiscountRate { get; set; }

    public decimal? DiscountAmount { get; set; }

    public decimal? FinalAmount { get; set; }
}
