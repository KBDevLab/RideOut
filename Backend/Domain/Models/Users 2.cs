using System;
using System.Collections.Generic;

namespace RideOut.Domain.Models;

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

    public virtual ICollection<Messages> Messages { get; set; } = new List<Messages>();

    public virtual ICollection<Notifications> Notifications { get; set; } = new List<Notifications>();

    public virtual ICollection<Participants> Participants { get; set; } = new List<Participants>();

    public virtual ICollection<Reviews> Reviews { get; set; } = new List<Reviews>();

    public virtual ICollection<Rideouts> Rideouts { get; set; } = new List<Rideouts>();
}
