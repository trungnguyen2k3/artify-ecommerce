using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class Account
{
    public int Id { get; set; }

    public string GoogleId { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? LastLogin { get; set; }

    public string? CartShareCode { get; set; }

    public virtual ICollection<LoginHistory> LoginHistories { get; set; } = new List<LoginHistory>();
}
