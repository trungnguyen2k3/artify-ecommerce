using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class CsmConsignment
{
    public int Id { get; set; }

    public string ConsignmentCode { get; set; } = null!;

    public string? BatchCode { get; set; }

    public int PartnerId { get; set; }

    public int? ContractId { get; set; }

    public int? HandoverId { get; set; }

    public string Sku { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string? ProductType { get; set; }

    public int? ProductId { get; set; }

    public string? VariantInfo { get; set; }

    public string? Unit { get; set; }

    public int QuantitySent { get; set; }

    public int QuantitySold { get; set; }

    public int QuantityReturned { get; set; }

    public int QuantityDamaged { get; set; }

    public int QuantityLost { get; set; }

    public int QuantityRecalled { get; set; }

    public int? QuantityAvailable { get; set; }

    public decimal RetailPrice { get; set; }

    public decimal? MinimumPrice { get; set; }

    public decimal? CommissionRate { get; set; }

    public string Status { get; set; } = null!;

    public DateOnly SentDate { get; set; }

    public string? DisplayLocation { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public string? BatchStatus { get; set; }

    public int? NextReconMonths { get; set; }
}
