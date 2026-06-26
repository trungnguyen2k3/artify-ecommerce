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

    public string? Password { get; set; }

    public string? Username { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime? RefreshTokenExpiryTime { get; set; }

    public bool IsActive { get; set; }

    public int RoleId { get; set; }

    public virtual ICollection<LoginHistory> LoginHistories { get; set; } = new List<LoginHistory>();
}
