using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class ZaloToken
{
    public int Id { get; set; }

    public string AccessToken { get; set; } = null!;

    public string RefreshToken { get; set; } = null!;

    public DateTime ExpiredAt { get; set; }

    public DateTime? CreatedAt { get; set; }
}
