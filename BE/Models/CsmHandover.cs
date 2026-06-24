using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class CsmHandover
{
    public int Id { get; set; }

    public string HandoverCode { get; set; } = null!;

    public int PartnerId { get; set; }

    public int? ContractId { get; set; }

    public DateOnly HandoverDate { get; set; }

    public string? SenderName { get; set; }

    public string? ReceiverName { get; set; }

    public string? Status { get; set; }

    public string? FileUrl { get; set; }

    public string? ActualImages { get; set; }

    public string? Note { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ConfirmedAt { get; set; }

    public string? ConfirmedBy { get; set; }

    public string? Condition { get; set; }

    public string? DeliveryLocation { get; set; }

    public string? ReconcileStatus { get; set; }

    public DateTime? ReconciledAt { get; set; }

    public string? ReconciledBy { get; set; }
}
