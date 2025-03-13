using System;
using System.Collections.Generic;

namespace Database.EntityModels;

public partial class BikeDataMain
{
    public int McId { get; set; }

    public int BikeBrandId { get; set; }

    public string ModelName { get; set; } = null!;

    public int? ModelFirstYear { get; set; }

    public int? FirstYear { get; set; }

    public int? FinalYear { get; set; }

    public string? Color { get; set; }

    public bool? SoldInSwedenThisYear { get; set; }

    public bool? SoldInSwedenEver { get; set; }

    public string? ImgUrl { get; set; }

    public double? Price { get; set; }

    public double? PriceWithAbs { get; set; }

    public string? PersonalComments { get; set; }

    public int? SimilarBikesId { get; set; }

    public int? BikeCategoryId { get; set; }

    public int? PerformanceId { get; set; }

    public int? ChassieId { get; set; }

    public int? EngineId { get; set; }

    public int? TransmissionId { get; set; }

    public string? Warranty { get; set; }

    public string? ServiceInterval { get; set; }

    public double? ValveCheckInterval { get; set; }

    public bool? QualityApproved { get; set; }

    public string? ModelNameCorrection { get; set; }

    public string? UpdatesForThisYear { get; set; }

    public bool? HasPicturesOnAllColors { get; set; }

    public bool? QualityApprovedGlobal { get; set; }

    public string? ModelNameUsa { get; set; }

    public string? ServiceIntervalEng { get; set; }

    public string? ServiceIntervalEngMiles { get; set; }

    public double? ValveCheckIntervalMiles { get; set; }

    public int? FirstYearGlobal { get; set; }

    public int? LastYearGlobal { get; set; }

    public double? PriceUsa { get; set; }

    public bool? ContainsNonResponsiveText { get; set; }

    public virtual ICollection<BikeReview> BikeReviews { get; set; } = new List<BikeReview>();

    public virtual Chassie? Chassie { get; set; }

    public virtual BikeCategory? BikeCategory { get; set; }

    public virtual BikeBrand? BikeBrand { get; set; }

    public virtual Engine? Engine { get; set; }

    public virtual ICollection<PriceList> PriceLists { get; set; } = new List<PriceList>();

    public virtual SimilarBike? SimilarBike { get; set; }

    public virtual Transmission? Transmission { get; set; }
}
