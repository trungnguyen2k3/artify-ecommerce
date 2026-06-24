using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class AdminUser
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsSuperAdmin { get; set; }

    public int? RoleId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? LastLoginAt { get; set; }

    public virtual ICollection<SystemIpadmin> SystemIpadmins { get; set; } = new List<SystemIpadmin>();
}
