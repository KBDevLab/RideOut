using System;
using System.Collections.Generic;

namespace Rideout.Domain.Models;

public partial class Participants
{
    public int Participantid { get; set; }

    public int Rideoutid { get; set; }

    public int Userid { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? Joinedat { get; set; }

    public virtual Rideouts Rideout { get; set; } = null!;

    public virtual Users User { get; set; } = null!;
}
