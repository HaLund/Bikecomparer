using System;
using System.Collections.Generic;

namespace Database.EntityModels;

public partial class BikeReview
{
    public int BikeReviewId { get; set; }

    public int? McId { get; set; }

    public int YearModel { get; set; }

    public double Price { get; set; }

    public int LoginId { get; set; }

    public string Header { get; set; } = null!;

    public string Text { get; set; } = null!;

    public string Positive { get; set; } = null!;

    public string Negative { get; set; } = null!;

    public int Grade { get; set; }

    public string Img { get; set; } = null!;

    public virtual BikeDataMain? Mc { get; set; }
}
