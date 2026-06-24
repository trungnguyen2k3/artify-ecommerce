using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class CsmContract
{
    public int Id { get; set; }

    public string ContractCode { get; set; } = null!;

    public int PartnerId { get; set; }

    public string ContractType { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public DateOnly? SignDate { get; set; }

    public string? FileUrl { get; set; }

    public string? Status { get; set; }

    public string? Note { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public string? IntroContent { get; set; }
}
