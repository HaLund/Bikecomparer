using System;
using System.Collections.Generic;

namespace Database.EntityModels;

public partial class BikeCategory
{
    public int BikeCategoryId { get; set; }

    public string BikeCategoryName { get; set; } = null!;

    public virtual ICollection<BikeDataMain> BikeDataMains { get; set; } = new List<BikeDataMain>();
}
