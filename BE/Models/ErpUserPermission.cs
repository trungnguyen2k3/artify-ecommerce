using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class ErpUserPermission
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string PermissionCode { get; set; } = null!;
}
