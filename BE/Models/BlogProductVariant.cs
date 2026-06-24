using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class BlogProductVariant
{
    public int Id { get; set; }

    public int? BlogProductId { get; set; }

    public string? Material { get; set; }

    public string? FinishType { get; set; }

    public int? Width { get; set; }

    public int? Height { get; set; }

    public decimal? Price { get; set; }

    public bool? IsActive { get; set; }
}
