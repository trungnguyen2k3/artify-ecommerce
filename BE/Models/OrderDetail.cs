using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class OrderDetail
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public string? Material { get; set; }

    public string? FinishType { get; set; }

    public int? Width { get; set; }

    public int? Height { get; set; }

    public string? FrameColor { get; set; }

    public string? ProductType { get; set; }

    public string? ShopCode { get; set; }
}
