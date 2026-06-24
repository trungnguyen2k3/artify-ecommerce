using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class Post
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string Title { get; set; } = null!;

    public string? Content { get; set; }

    public string? Description { get; set; }

    public string Slug { get; set; } = null!;

    public int IsPublished { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? ThumbUrl { get; set; }

    public int? SortIndex { get; set; }

    public int ViewCount { get; set; }
}
