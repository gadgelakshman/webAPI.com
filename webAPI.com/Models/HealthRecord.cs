using System;
using System.Collections.Generic;

namespace webAPI.com.Models;

public partial class HealthRecord
{
    public int RecordId { get; set; }

    public int? CowId { get; set; }

    public DateOnly? CheckupDate { get; set; }

    public string? Notes { get; set; }

    public string? VetName { get; set; }

    public virtual Cow? Cow { get; set; }
}
