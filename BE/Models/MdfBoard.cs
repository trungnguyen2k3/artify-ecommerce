using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class MdfBoard
{
    public int Id { get; set; }

    public decimal? Width { get; set; }

    public bool? Status { get; set; }

    public int Quantity { get; set; }

    public int? Type { get; set; }
}
