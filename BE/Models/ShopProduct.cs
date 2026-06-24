using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class ShopProduct
{
    public int Id { get; set; }

    public string ShopCode { get; set; } = null!;

    public int CategoryId { get; set; }

    public string Sku { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Photo { get; set; }

    public decimal Price { get; set; }

    public string? Dimension { get; set; }

    public decimal? Weight { get; set; }

    public int? StockQuantity { get; set; }

    public int? LowStockThreshold { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsFeatured { get; set; }

    public string? MetadataJson { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Slug { get; set; }

    public string? Color { get; set; }

    public string? MetaTitle { get; set; }

    public string? MetaDescription { get; set; }

    public string? MetaKeywords { get; set; }

    public string? LocationCode { get; set; }
}
