using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class BlogProductCoreStock
{
    public int Id { get; set; }

    public int BlogProductId { get; set; }

    public int MaterialId { get; set; }

    public int Quantity { get; set; }
}
