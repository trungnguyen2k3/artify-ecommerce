using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class CsmContractAnnex
{
    public int Id { get; set; }

    public string AnnexCode { get; set; } = null!;

    public int ContractId { get; set; }

    public DateOnly? SignDate { get; set; }

    public DateOnly EffectiveDate { get; set; }

    public string ContentChange { get; set; } = null!;

    public string? FileUrl { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }
}
