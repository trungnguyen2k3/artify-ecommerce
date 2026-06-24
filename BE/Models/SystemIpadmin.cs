using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class SystemIpadmin
{
    public int Id { get; set; }

    public int AdminUserId { get; set; }

    public string Username { get; set; } = null!;

    public string? DisplayName { get; set; }

    public string IpAddress { get; set; } = null!;

    public string? City { get; set; }

    public string? Region { get; set; }

    public string? Country { get; set; }

    public string? UserAgent { get; set; }

    public DateTime LastLoginAt { get; set; }

    public int LoginCount { get; set; }

    public bool IsExcluded { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual AdminUser AdminUser { get; set; } = null!;
}
