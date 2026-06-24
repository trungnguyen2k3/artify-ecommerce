using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class SystemWidthBlogProduct
{
    public int Id { get; set; }

    public string Sku { get; set; } = null!;

    public int Width { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
