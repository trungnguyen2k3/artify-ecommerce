using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class CsmMasterDatum
{
    public int Id { get; set; }

    public string Category { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string NameVi { get; set; } = null!;

    public int? SortOrder { get; set; }

    public bool? IsActive { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }
}
