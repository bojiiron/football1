using System;
using System.Collections.Generic;

namespace Football.Data.Models;

public partial class League
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
