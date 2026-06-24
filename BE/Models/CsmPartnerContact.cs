using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class CsmPartnerContact
{
    public int Id { get; set; }

    public int PartnerId { get; set; }

    public string ContactName { get; set; } = null!;

    public string? ContactRole { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Note { get; set; }

    public bool? IsPrimary { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }
}
