using System;
using System.Collections.Generic;

namespace webAPI.com.Models;

public partial class Feed
{
    public int FeedId { get; set; }

    public int? CowId { get; set; }

    public string? FeedType { get; set; }

    public decimal? QuantityKg { get; set; }

    public DateOnly? FeedDate { get; set; }

    public virtual Cow? Cow { get; set; }
}
