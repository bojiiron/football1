using System;
using System.Collections.Generic;

namespace Football.Data.Models;

public partial class Player
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int TeamId { get; set; }

    public int NationalityId { get; set; }

    public virtual Nationality Nationality { get; set; } = null!;

    public virtual ICollection<PlayerTeam> PlayerTeams { get; set; } = new List<PlayerTeam>();

    public virtual Team Team { get; set; } = null!;
}
