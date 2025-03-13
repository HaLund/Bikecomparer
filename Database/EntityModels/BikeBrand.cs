using System;
using System.Collections.Generic;

namespace Database.EntityModels;

public partial class BikeBrand
{
    public int BikeBrandId { get; set; }

    public string BikeBrandName { get; set; } = null!;

    public string? GeneralAgent { get; set; }

    public string? WebpageSweden { get; set; }
    public int SortId { get; set; }

    public string? WebpageGlobal { get; set; }

    public bool? Active { get; set; }

    public virtual ICollection<BikeDataMain> BikeDataMains { get; set; } = new List<BikeDataMain>();
}
