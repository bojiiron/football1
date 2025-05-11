using System;
using System.Collections.Generic;

namespace Football.Data.Models;

public partial class PlayerTeam
{
    public int Id { get; set; }

    public int PlayersId { get; set; }

    public int TeamId { get; set; }

    public int Salary { get; set; }

    public int MonthsActive { get; set; }

    public virtual Player Players { get; set; } = null!;

    public virtual Team Team { get; set; } = null!;
}
