using System;
using System.Collections.Generic;

namespace Database.EntityModels;

public partial class EquipmentType
{
    public int EquipmentTypeId { get; set; }

    public string EquipmentTypeName { get; set; } = null!;

    public virtual ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();
}
