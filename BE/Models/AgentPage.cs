using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class AgentPage
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string? Content { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int SortOrder { get; set; }

    public bool IsActive { get; set; }
}
