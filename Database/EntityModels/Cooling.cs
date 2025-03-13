using System;
using System.Collections.Generic;

namespace Database.EntityModels;

public partial class Cooling
{
    public int CoolingId { get; set; }

    public string CoolingName { get; set; } = null!;

    public string? CoolingNameEng { get; set; }

    public virtual ICollection<Engine> Engines { get; set; } = new List<Engine>();
}
