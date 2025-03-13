using Common.Enums;

namespace DomainObjects
{
    public record BikeDataBasic
    {
        public int Id { get; set; }
        public string? ModelName { get; set; }
        public string? ModelNameShort { get; set; }
        public string? BikeCategory { get; set; }
        public int? BikeBrandId { get; set; }
        public string? BikeBrandName { get; set; }
        public YearRange? YearRange { get; set; }
        public double? PriceFrom { get; set; }
        public double? PriceTo { get; set; }
        public string? Engine { get; set; }  
        public float? EngineCapacityFrom { get; set; }
        public float? EngineCapacityTo { get; set; }
        public float? PowerFrom { get; set; }
        public float? PowerTo { get; set; }
        public int? YearFrom { get; set; }
        public int? YearTo { get; set; }
        public SafetyEquipmentStatus? ABS { get; set; }
        public SafetyEquipmentStatus? TractionControl { get; set; }
        public SafetyEquipmentStatus? RiderModes { get; set; }
        public SafetyEquipmentStatus? WheelieControl { get; set; }
        public SafetyEquipmentStatus? LaunchControl { get; set; }
        public SafetyEquipmentStatus? ActiveSuspension { get; set; }
        public string? Color { get; set; }
        public int? FirstYear { get; set; }
        public int? FinalYear { get; set; }
        public string? ImgUrl { get; set; }
        public string? Description { get; set; }
        public string? Price { get; set; }
        public double? Power { get; set; }
        public int? PeekPowerReev { get; set; }
        public double? FuelCapacity { get; set; }
        public double? DryWeight { get; set; }
        public double? WetWeight { get; set; }
        public string? Wheelbase { get; set; }
        public int? TotalCount { get; set; }
        public List<BikeDataBasic> BikeDataBasicList { get; set; } = new List<BikeDataBasic>();
        public List<BikeCategoryDto> BikeCategoryList { get; set; } = new List<BikeCategoryDto>();
        public List<BikeBrandDto> bikeBrandList { get; set; } = new List<BikeBrandDto>();
    }
}
