using System;
using System.Collections.Generic;

namespace Database.EntityModels;

public partial class CylinderConfiguration
{
    public int CylinderConfigurationId { get; set; }

    public string CylinderConfigurationName { get; set; } = null!;

    public string? CylinderConfigurationNameEng { get; set; }

    public virtual ICollection<Engine> Engines { get; set; } = new List<Engine>();
}
