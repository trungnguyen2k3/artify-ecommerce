using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class CsmStaff
{
    public int Id { get; set; }

    public string StaffName { get; set; } = null!;

    public string DepartmentCode { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }
}
