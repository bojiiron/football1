using System;
using System.Collections.Generic;

namespace Football.Data.Models;

public partial class Nationality
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? BestPlayer { get; set; }

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();
}
