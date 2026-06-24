using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class FinishType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int MaterialId { get; set; }

    public int? Height1 { get; set; }

    public int? Height2 { get; set; }

    public int? Height3 { get; set; }

    public int? Height4 { get; set; }

    public int? Height5 { get; set; }

    public virtual Material Material { get; set; } = null!;
}
