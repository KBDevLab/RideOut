using System;
using System.Collections.Generic;

namespace Rideout.Domain.Models;

public partial class Vehicle
{
    public int Vehicleid { get; set; }

    public string Vehicle1 { get; set; } = null!;

    public virtual ICollection<Rideouts> Rideouts { get; set; } = new List<Rideouts>();

    public virtual ICollection<Rides> Rides { get; set; } = new List<Rides>();
}
