using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class CsmContractClause
{
    public int Id { get; set; }

    public int ContractId { get; set; }

    public int ClauseOrder { get; set; }

    public string ClauseTitle { get; set; } = null!;

    public string? ClauseContent { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
