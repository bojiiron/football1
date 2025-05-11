using System;
using System.Collections.Generic;

namespace Football.Data.Models;

public partial class Coach
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
