using System;
using System.Collections.Generic;

namespace Database.EntityModels;

public partial class Equipment
{
    public int EquipmentId { get; set; }

    public int EquipmentTypeId { get; set; }

    public int EquipmentBrandId { get; set; }

    public int EquipmentModelId { get; set; }

    public int? Year { get; set; }

    public virtual EquipmentBrand EquipmentBrand { get; set; } = null!;

    public virtual EquipmentModel EquipmentModel { get; set; } = null!;

    public virtual ICollection<EquipmentReview> EquipmentReviews { get; set; } = new List<EquipmentReview>();

    public virtual EquipmentType EquipmentType { get; set; } = null!;
}
