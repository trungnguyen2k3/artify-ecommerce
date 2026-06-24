using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class CsmContractTemplateClause
{
    public int Id { get; set; }

    public int TemplateId { get; set; }

    public int ClauseOrder { get; set; }

    public string ClauseTitle { get; set; } = null!;

    public string? ClauseContent { get; set; }
}
