using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class PostCategory
{
    public int Id { get; set; }

    public int? ParentId { get; set; }

    public string Name { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string? MetaDescription { get; set; }

    public string? ThumbUrl { get; set; }

    public int? SortIndex { get; set; }

    public int? IsPublished { get; set; }
}
