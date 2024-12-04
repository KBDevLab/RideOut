using System;
using System.Collections.Generic;

namespace RideOut.Models;

public partial class Messages
{
    public int Messageid { get; set; }

    public int Rideoutid { get; set; }

    public int Senderuserid { get; set; }

    public string Messagetext { get; set; } = null!;

    public DateTime? Sentat { get; set; }

    public virtual Rideouts Rideout { get; set; } = null!;

    public virtual Users Senderuser { get; set; } = null!;
}
