using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class LoginHistory
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public string IpAddress { get; set; } = null!;

    public string? City { get; set; }

    public string? Region { get; set; }

    public string? Country { get; set; }

    public string? UserAgent { get; set; }

    public DateTime Time { get; set; }

    public virtual Account Account { get; set; } = null!;
}
