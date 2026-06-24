using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class MasterExcelCellMapping
{
    public int Id { get; set; }

    public string VariantKey { get; set; } = null!;

    public string WidthCellAddress { get; set; } = null!;

    public string PriceCellAddress { get; set; } = null!;

    public string? Description { get; set; }
}
