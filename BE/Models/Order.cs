using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public decimal Total { get; set; }

    public string Status { get; set; } = null!;

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? OrderNumber { get; set; }

    public string? FullName { get; set; }

    public decimal? DiscountPercent { get; set; }

    public int? AgentId { get; set; }

    public decimal? DiscountAmount { get; set; }

    public string? Address { get; set; }

    public string? Province { get; set; }

    public string? District { get; set; }

    public string? Ward { get; set; }

    public decimal? ShippingFee { get; set; }

    public double? Distance { get; set; }

    public string? Notes { get; set; }

    public string? OrderType { get; set; }

    public string? OriginalOrderNumber { get; set; }

    public DateTime? ConvertedDate { get; set; }

    public int? ChanelId { get; set; }

    public bool? IsManual { get; set; }

    public int? CreatedBy { get; set; }

    public int? CustomerId { get; set; }

    public string? UtmSource { get; set; }

    public string? TransactionCode { get; set; }

    public string? PaymentProvider { get; set; }

    public virtual ICollection<OrderHistory> OrderHistories { get; set; } = new List<OrderHistory>();
}
