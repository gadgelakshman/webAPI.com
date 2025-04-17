using System;
using System.Collections.Generic;

namespace webAPI.com.Models;

public partial class MilkProduction
{
    public int ProductionId { get; set; }

    public int? CowId { get; set; }

    public DateOnly? Date { get; set; }

    public decimal? QuantityLiters { get; set; }

    public virtual Cow? Cow { get; set; }
}
