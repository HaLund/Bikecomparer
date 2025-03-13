using System;
using System.Collections.Generic;

namespace Database.EntityModels;

public partial class EquipmentModel
{
    public int EquipmentModelId { get; set; }

    public int EquipmentBrandId { get; set; }

    public string EquipmentModelName { get; set; } = null!;

    public virtual ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();

    public virtual EquipmentBrand EquipmentBrand { get; set; } = null!;
}
