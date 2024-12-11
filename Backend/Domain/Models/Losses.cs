using System;
using System.Collections.Generic;

namespace Rideout.Domain.Models;

public partial class Losses
{
    public int Lossid { get; set; }

    public int Userid { get; set; }

    public int? Rideid { get; set; }

    public int Rideoutid { get; set; }

    public DateTime Date { get; set; }

    public string? Details { get; set; }

    public DateTime? Createdat { get; set; }

    public DateTime? Updatedat { get; set; }

    public virtual Rides? Ride { get; set; }

    public virtual Rideouts Rideout { get; set; } = null!;

    public virtual Users User { get; set; } = null!;
}
