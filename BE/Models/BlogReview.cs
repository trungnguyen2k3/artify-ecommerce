using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class BlogReview
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int BlogProductId { get; set; }

    public int Rating { get; set; }

    public string? Review { get; set; }

    public DateTime Created { get; set; }
}
