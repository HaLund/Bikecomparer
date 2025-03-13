using System;
using System.Collections.Generic;

namespace Database.EntityModels;

public partial class EquipmentReview
{
    public int EquipmenReviewId { get; set; }

    public int? EquipmentId { get; set; }

    public int? YearModel { get; set; }

    public double? Price { get; set; }

    public int LoginId { get; set; }

    public string Header { get; set; } = null!;

    public string Text { get; set; } = null!;

    public string Positive { get; set; } = null!;

    public string Negative { get; set; } = null!;

    public int Grade { get; set; }

    public string ImgUrl { get; set; } = null!;

    public virtual Equipment? Equipment { get; set; }
}
