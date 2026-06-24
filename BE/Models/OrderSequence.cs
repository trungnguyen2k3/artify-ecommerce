using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class OrderSequence
{
    public int Id { get; set; }

    public DateOnly SequenceDate { get; set; }

    public string Channel { get; set; } = null!;

    public int CurrentNumber { get; set; }
}
