using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class TextEditorMediaItem
{
    public int Id { get; set; }

    public string ObjectName { get; set; } = null!;

    public int ObjectId { get; set; }

    public string Url { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public string? TempKey { get; set; }
}
