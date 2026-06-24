using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class AdminRolePermission
{
    public int Id { get; set; }

    public int RoleId { get; set; }

    public int PermissionId { get; set; }
}
