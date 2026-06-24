using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class CsmPartnerLevelPolicy
{
    public int Id { get; set; }

    public string LevelCode { get; set; } = null!;

    public string LevelName { get; set; } = null!;

    public decimal? DefaultCommissionRate { get; set; }

    public decimal? DefaultDebtLimit { get; set; }

    public string? DefaultReconciliationCycle { get; set; }

    public string? DefaultPaymentTerm { get; set; }

    public int? DefaultConsignmentDuration { get; set; }

    public string? Description { get; set; }

    public int? SortOrder { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? DefaultDebtLimitDate { get; set; }
}
