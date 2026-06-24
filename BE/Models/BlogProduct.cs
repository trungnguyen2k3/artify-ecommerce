using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class BlogProduct
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Photo { get; set; }

    public int CategoryId { get; set; }

    public bool IsActive { get; set; }

    public string Sku { get; set; } = null!;

    public string? MetadataJson { get; set; }

    public int? Width { get; set; }

    public string? TempId { get; set; }

    public string? MetaTitle { get; set; }

    public string? MetaDescription { get; set; }

    public string? MetaKeywords { get; set; }

    public string? Slug { get; set; }

    public string? AuthorName { get; set; }
}
