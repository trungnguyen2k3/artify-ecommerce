using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class B2bCustomerContact
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public string FullName { get; set; } = null!;

    public string? Position { get; set; }

    public string? Department { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Role { get; set; }

    public bool? IsPrimary { get; set; }

    public bool? IsActive { get; set; }

    public string? Note { get; set; }

    public DateTime? CreatedAt { get; set; }
}
