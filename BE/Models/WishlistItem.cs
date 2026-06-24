using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class WishlistItem
{
    public long Id { get; set; }

    public long WishlistId { get; set; }

    public int ProductId { get; set; }

    public DateTime CreatedAt { get; set; }
}
