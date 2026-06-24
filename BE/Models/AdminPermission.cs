using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class AdminPermission
{
    public int Id { get; set; }

    public string Key { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    public string GroupName { get; set; } = null!;

    public int SortOrder { get; set; }
}
