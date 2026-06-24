using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class ProductImage
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string ImageType { get; set; } = null!;

    public string? Color { get; set; }

    public string ImagePath { get; set; } = null!;
}
