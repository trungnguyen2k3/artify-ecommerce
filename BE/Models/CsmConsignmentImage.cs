using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class CsmConsignmentImage
{
    public int Id { get; set; }

    public int ConsignmentId { get; set; }

    public string ImageType { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public string? Note { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }
}
