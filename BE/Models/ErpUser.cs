using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class ErpUser
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public bool IsSuperAdmin { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }
}
