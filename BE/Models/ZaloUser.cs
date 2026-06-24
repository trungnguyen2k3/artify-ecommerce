using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class ZaloUser
{
    public int Id { get; set; }

    public string ZaloUserId { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Name { get; set; }

    public DateTime? FollowedAt { get; set; }

    public DateTime? LastInteractionAt { get; set; }
}
