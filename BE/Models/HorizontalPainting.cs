using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class HorizontalPainting
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Sku { get; set; } = null!;

    public string? Description { get; set; }

    public string? Photo { get; set; }

    public bool IsActive { get; set; }

    public string? MetadataJson { get; set; }

    public int? TempId { get; set; }

    public string? MetaTitle { get; set; }

    public string? MetaDescription { get; set; }

    public string? MetaKeywords { get; set; }

    public string? Slug { get; set; }

    public string? AuthorName { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
