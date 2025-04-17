using System;
using System.Collections.Generic;

namespace webAPI.com.Models;

public partial class Cow
{
    public int CowId { get; set; }

    public string? Name { get; set; }

    public string? Breed { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? HealthStatus { get; set; }

    public virtual ICollection<Feed> Feeds { get; set; } = new List<Feed>();

    public virtual ICollection<HealthRecord> HealthRecords { get; set; } = new List<HealthRecord>();

    public virtual ICollection<MilkProduction> MilkProductions { get; set; } = new List<MilkProduction>();
}
