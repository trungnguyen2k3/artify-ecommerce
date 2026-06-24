using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class Wishlist
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public string Name { get; set; } = null!;

    public string TokenShare { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int Visibility { get; set; }
}
