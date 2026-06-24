using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class AdminRole
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }
}
