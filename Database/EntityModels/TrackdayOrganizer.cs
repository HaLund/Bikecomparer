using System;
using System.Collections.Generic;

namespace Database.EntityModels;

public partial class TrackdayOrganizer
{
    public int OrganizerId { get; set; }

    public string OrganizerName { get; set; } = null!;

    public string? HomepageUrl { get; set; }

    public virtual ICollection<Trackday> Trackdays { get; set; } = new List<Trackday>();
}
