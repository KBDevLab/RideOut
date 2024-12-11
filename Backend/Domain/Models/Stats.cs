using System;
using System.Collections.Generic;

namespace Rideout.Domain.Models;

public partial class Stats
{
    public int Statid { get; set; }

    public int Userid { get; set; }

    public int Rideid { get; set; }

    public int? Wins { get; set; }

    public int? Losses { get; set; }

    public int? Totalrides { get; set; }

    public int? Totaldistance { get; set; }

    public decimal? Averagespeed { get; set; }

    public DateTime? Createdat { get; set; }

    public DateTime? Updatedat { get; set; }

    public virtual Rides Ride { get; set; } = null!;

    public virtual Users User { get; set; } = null!;

    public virtual ICollection<Users> Users { get; set; } = new List<Users>();
}
