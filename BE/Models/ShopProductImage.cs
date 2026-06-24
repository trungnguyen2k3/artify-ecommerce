using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class ShopProductImage
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string ImagePath { get; set; } = null!;

    public string? ImageType { get; set; }

    public string? AltText { get; set; }

    public int? SortOrder { get; set; }
}
