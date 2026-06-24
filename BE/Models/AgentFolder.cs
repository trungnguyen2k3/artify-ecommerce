using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class AgentFolder
{
    public int Id { get; set; }

    public string FolderName { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }
}
