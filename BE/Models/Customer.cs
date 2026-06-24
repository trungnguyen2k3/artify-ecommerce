using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? Province { get; set; }

    public string? District { get; set; }

    public string? Ward { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsActive { get; set; }
}
