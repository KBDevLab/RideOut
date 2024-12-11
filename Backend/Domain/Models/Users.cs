using System;
using System.Collections.Generic;

namespace Rideout.Domain.Models;

public partial class Users
{
    public int Userid { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Passwordhash { get; set; } = null!;

    public string? Location { get; set; }

    public string? Profilepicture { get; set; }

    public string? Bio { get; set; }

    public DateTime? Createdat { get; set; }

    public DateTime? Updatedat { get; set; }

    public int? Statid { get; set; }

    public string? Status { get; set; }

    public int? Rideid { get; set; }

    public virtual ICollection<Losses> Losses { get; set; } = new List<Losses>();

    public virtual ICollection<Messages> Messages { get; set; } = new List<Messages>();

    public virtual ICollection<Notifications> Notifications { get; set; } = new List<Notifications>();

    public virtual ICollection<Participants> Participants { get; set; } = new List<Participants>();

    public virtual ICollection<Reviews> Reviews { get; set; } = new List<Reviews>();

    public virtual Rides? Ride { get; set; }

    public virtual ICollection<Rideouts> Rideouts { get; set; } = new List<Rideouts>();

    public virtual ICollection<Rides> Rides { get; set; } = new List<Rides>();

    public virtual Stats? Stat { get; set; }

    public virtual ICollection<Stats> Stats { get; set; } = new List<Stats>();

    public virtual ICollection<Wins> Wins { get; set; } = new List<Wins>();
}
