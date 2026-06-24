using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class AgentFolderPermission
{
    public int Id { get; set; }

    public int AgentId { get; set; }

    public int FolderId { get; set; }

    public DateTime? CreatedAt { get; set; }
}
