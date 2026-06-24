using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class BlogProductTag
{
    public int Id { get; set; }

    public int BlogProductId { get; set; }

    public int TagId { get; set; }
}
