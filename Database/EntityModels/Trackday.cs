using System;
using System.Collections.Generic;

namespace Database.EntityModels;

public partial class Trackday
{
    public int TrackdayId { get; set; }

    public int TrackId { get; set; }

    public int OrganizerId { get; set; }

    public string? Groups { get; set; }

    public double? Price { get; set; }

    public bool? AmbulanceAttendence { get; set; }

    public virtual TrackdayOrganizer Organizer { get; set; } = null!;

    public virtual Circuit Track { get; set; } = null!;
}
