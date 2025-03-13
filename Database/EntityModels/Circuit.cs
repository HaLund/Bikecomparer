using System;
using System.Collections.Generic;

namespace Database.EntityModels;

public partial class Circuit
{
    public int TrackId { get; set; }

    public string TrackName { get; set; } = null!;

    public virtual ICollection<Trackday> Trackdays { get; set; } = new List<Trackday>();
}
