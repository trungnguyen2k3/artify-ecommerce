using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class BlogCategory
{
    public int Id { get; set; }

    public string CategoryName { get; set; } = null!;

    public int SortOrder { get; set; }

    public bool IsActive { get; set; }

    public string? MetaTitle { get; set; }

    public string? MetaDescription { get; set; }

    public string? MetaKeywords { get; set; }

    public string? Slug { get; set; }
}
