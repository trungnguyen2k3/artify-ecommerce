using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class CsmContractAnnexProduct
{
    public int Id { get; set; }

    public int AnnexId { get; set; }

    public string Sku { get; set; } = null!;

    public string? Note { get; set; }

    public int? ProductId { get; set; }

    public string? ProductType { get; set; }
}
