using System;
using System.Collections.Generic;

namespace Football.Data.Models;

public partial class Team
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? LeagueId { get; set; }

    public int? CoachesId { get; set; }

    public int Trophies { get; set; }

    public virtual Coach? Coaches { get; set; }

    public virtual League? League { get; set; }

    public virtual ICollection<PlayerTeam> PlayerTeams { get; set; } = new List<PlayerTeam>();

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();
}
