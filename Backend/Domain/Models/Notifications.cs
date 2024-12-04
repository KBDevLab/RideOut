using System;
using System.Collections.Generic;

namespace RideOut.Domain.Models;

public partial class Notifications
{
    public int Notificationid { get; set; }

    public int Userid { get; set; }

    public string Content { get; set; } = null!;

    public bool? Isread { get; set; }

    public DateTime? Sentat { get; set; }

    public virtual Users User { get; set; } = null!;
}
