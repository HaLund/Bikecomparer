using System;
using System.Collections.Generic;

namespace Database.EntityModels;

public partial class EquipmentBrand
{
    public int EquipmentBrandId { get; set; }

    public string EquipmentBrandName { get; set; } = null!;

    public virtual ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();

    public virtual ICollection<EquipmentModel> EquipmentModels { get; set; } = new List<EquipmentModel>();
}
