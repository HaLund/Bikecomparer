using System;
using System.Collections.Generic;

namespace Database.EntityModels;

public partial class PriceList
{
    public int PriceListId { get; set; }

    public int McId { get; set; }

    public int YearModel { get; set; }

    public double CurrentValue { get; set; }

    public double PriceWhenNew { get; set; }

    public virtual BikeDataMain Mc { get; set; } = null!;
}
