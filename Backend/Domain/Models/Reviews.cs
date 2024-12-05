using System;
using System.Collections.Generic;

namespace Rideout.Domain.Models;

public partial class Reviews
{
    public int Reviewid { get; set; }

    public int Rideoutid { get; set; }

    public int Userid { get; set; }

    public int? Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime? Reviewedat { get; set; }

    public virtual Rideouts Rideout { get; set; } = null!;

    public virtual Users User { get; set; } = null!;
}
