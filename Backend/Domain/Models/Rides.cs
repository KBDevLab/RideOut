using System;
using System.Collections.Generic;

namespace Rideout.Domain.Models;

public partial class Rides
{
    public int Rideid { get; set; }

    public int? Userid { get; set; }

    public int? Vehicleid { get; set; }

    public DateTime? Year { get; set; }

    public string? Color { get; set; }

    public bool? Isprimary { get; set; }

    public DateTime? Createdat { get; set; }

    public DateTime? Updatedat { get; set; }

    public virtual ICollection<Losses> Losses { get; set; } = new List<Losses>();

    public virtual ICollection<Stats> Stats { get; set; } = new List<Stats>();

    public virtual Users? User { get; set; }

    public virtual ICollection<Users> Users { get; set; } = new List<Users>();

    public virtual Vehicle? Vehicle { get; set; }

    public virtual ICollection<Wins> Wins { get; set; } = new List<Wins>();
}
