using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class BlogComment
{
    public int Id { get; set; }

    public int BlogProductId { get; set; }

    public int? ParentId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}
