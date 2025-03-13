using System;
using System.Collections.Generic;

namespace Database.EntityModels;

public partial class EngineType
{
    public int EngineTypeId { get; set; }

    public string EngineTypeName { get; set; } = null!;

    public virtual ICollection<Engine> Engines { get; set; } = new List<Engine>();
}
