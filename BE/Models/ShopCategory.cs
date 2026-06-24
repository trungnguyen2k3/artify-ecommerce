using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class ShopCategory
{
    public int Id { get; set; }

    public string ShopCode { get; set; } = null!;

    public string CategoryName { get; set; } = null!;

    public int? ParentId { get; set; }

    public string Slug { get; set; } = null!;

    public string? Photo { get; set; }

    public int? SortOrder { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? MetaTitle { get; set; }

    public string? MetaDescription { get; set; }

    public string? MetaKeywords { get; set; }
}
