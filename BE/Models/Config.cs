using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class Config
{
    public int Id { get; set; }

    public string? Config1 { get; set; }

    public string? Value { get; set; }

    public string? Note { get; set; }
}
