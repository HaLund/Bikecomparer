using System;
using System.Collections.Generic;

namespace Database.EntityModels;

public partial class SimilarBike
{
    public int McId { get; set; }

    public int SimilarBikesId { get; set; }

    public virtual BikeDataMain Mc { get; set; } = null!;
}
