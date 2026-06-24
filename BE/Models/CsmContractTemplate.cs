using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class CsmContractTemplate
{
    public int Id { get; set; }

    public string TemplateName { get; set; } = null!;

    public string? ContractType { get; set; }

    public bool? IsDefault { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public string? IntroContent { get; set; }
}
