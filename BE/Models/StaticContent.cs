using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class StaticContent
{
    public int Id { get; set; }

    public string Key { get; set; } = null!;

    public string Content { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Title { get; set; }

    public string? MetaTitle { get; set; }

    public string? MetaDescription { get; set; }

    public string? MetaKeywords { get; set; }
}
