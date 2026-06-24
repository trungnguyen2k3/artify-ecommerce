using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class ErpPermission
{
    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Module { get; set; } = null!;
}
