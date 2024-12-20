﻿using System;
using System.Collections.Generic;

namespace Rideout.Domain.Models;

public partial class Rideouts
{
    public int Rideoutid { get; set; }

    public int Hostuserid { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string Location { get; set; } = null!;

    public DateTime Datetime { get; set; }

    public int? Maxparticipants { get; set; }

    public DateTime? Createdat { get; set; }

    public DateTime? Updatedat { get; set; }

    public string? Thumbnail { get; set; }

    public int? Vehicletype { get; set; }

    public virtual Users Hostuser { get; set; } = null!;

    public virtual ICollection<Losses> Losses { get; set; } = new List<Losses>();

    public virtual ICollection<Messages> Messages { get; set; } = new List<Messages>();

    public virtual ICollection<Participants> Participants { get; set; } = new List<Participants>();

    public virtual ICollection<Reviews> Reviews { get; set; } = new List<Reviews>();

    public virtual Vehicle? VehicletypeNavigation { get; set; }

    public virtual ICollection<Wins> Wins { get; set; } = new List<Wins>();
}
