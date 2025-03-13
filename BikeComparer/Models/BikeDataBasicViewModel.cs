using Common.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BikeComparer.Models
{
    public class BikeDataBasicViewModel
    {
        public int Id { get; set; }
        public string? ModelNameShort { get; set; }
        public string? BikeCategory { get; set; }
        public int? BikeBrandId { get; set; }
        public YearRange? YearRange { get; set; }
        public double? PriceFrom { get; set; }
        public double? PriceTo { get; set; }
        public string? Engine { get; set; }
        public float? EngineCapacityFrom { get; set; }
        public float? EngineCapacityTo { get; set; }
        public float? PowerFrom { get; set; }
        public float? PowerTo { get; set; }    
        public string? YearFrom { get; set; }
        public string? YearTo { get; set; }
        public SafetyEquipmentStatus? ABS { get; set; }
        public SafetyEquipmentStatus? TractionControl { get; set; }
        public SafetyEquipmentStatus? RiderModes { get; set; }
        public SafetyEquipmentStatus? WheelieControl { get; set; }
        public SafetyEquipmentStatus? LaunchControl { get; set; }
        public SafetyEquipmentStatus? ActiveSuspension { get; set; }
        public int? FirstYear { get; set; }
        public int? FinalYear { get; set; }
        public string? ImgUrl { get; set; }
        public string? Price { get; set; }
        public double? FuelCapacity { get; set; }
        public double? DryWeight { get; set; }
        public double? WetWeight { get; set; }
        public string? Wheelbase { get; set; }
        public List<BikeDataBasicViewModel> BikeDataBasicList { get; set; } = new List<BikeDataBasicViewModel>();
        public List<BikeCategoryDto> bikeCategoryList { get; set; } = new List<BikeCategoryDto>();
        public List<BikeBrandDto> bikeBrandList { get; set; } = new List<BikeBrandDto>();
        public List<SelectListItem> YearRangeList { get; } = new List<SelectListItem>()
        {
            new SelectListItem{ Value = "1", Text="Samtliga motorcyklar 2020", Selected=true },
            new SelectListItem{ Value = "2", Text="Enbart årets nyheter" },
            new SelectListItem{ Value = "3", Text="Inkludera även utgångna modeller" }
        };

        public List<SelectListItem> SafetyEquipmentList { get; } = new List<SelectListItem>()
        {
            new SelectListItem{ Value = "1", Text="Alla", Selected=true },
            new SelectListItem{ Value = "2", Text="Med denna säkerhetsutrustning" },
            new SelectListItem{ Value = "3", Text="Utan denna säkerhetsutrustning" }
        };

        public List<SelectListItem> PowerFromList { get; } = new List<SelectListItem>()
        {
            new SelectListItem{ Value = "0", Text="Hästkrafter från", Selected=true },
            new SelectListItem{ Value = "0", Text="<=15 (A1)>" },
            new SelectListItem{ Value = "30", Text="30" },
            new SelectListItem{ Value = "48", Text="48 (A2)" },
            new SelectListItem{ Value = "60", Text="60" },
            new SelectListItem{ Value = "80", Text="80" },
            new SelectListItem{ Value = "100", Text="100" },
            new SelectListItem{ Value = "120", Text="120" },
            new SelectListItem{ Value = "150", Text="150" },
            new SelectListItem{ Value = "180", Text="180" },
            new SelectListItem{ Value = "200", Text="200" },
        };

        public List<SelectListItem> PowerToList { get; } = new List<SelectListItem>()
        {
            new SelectListItem{ Value = "0", Text="Hästkrafter till" , Selected = true},
            new SelectListItem{ Value = "15", Text="<=15 (A1)>" },
            new SelectListItem{ Value = "30", Text="30" },
            new SelectListItem{ Value = "48", Text="48 (A2)" },
            new SelectListItem{ Value = "60", Text="60" },
            new SelectListItem{ Value = "80", Text="80" },
            new SelectListItem{ Value = "100", Text="100" },
            new SelectListItem{ Value = "120", Text="120" },
            new SelectListItem{ Value = "150", Text="150" },
            new SelectListItem{ Value = "180", Text="180" },
            new SelectListItem{ Value = "200", Text=">180" },
        };

        public List<SelectListItem> EngnneCapacityFromList { get; } = new List<SelectListItem>()
        {
            new SelectListItem{ Value = "0", Text="Motorstorlek (cc) från", Selected = true },
            new SelectListItem{ Value = "0", Text="<=125 cc (A1)" },
            new SelectListItem{ Value = "250", Text="250 cc" },
            new SelectListItem{ Value = "400", Text="400 cc" },
            new SelectListItem{ Value = "500", Text="500 cc" },
            new SelectListItem{ Value = "600", Text="600 cc" },
            new SelectListItem{ Value = "750", Text="750 cc" },
            new SelectListItem{ Value = "1000", Text="1000 cc" },
            new SelectListItem{ Value = "1200", Text="1200 cc" }
        };

        public List<SelectListItem> EngineCapacityToList { get; } = new List<SelectListItem>()
        {
            new SelectListItem{ Value = "0", Text="Motorstorlek (cc) till", Selected=true },
            new SelectListItem{ Value = "125", Text="<=125 cc (A1)" },
            new SelectListItem{ Value = "250", Text="250 cc" },
            new SelectListItem{ Value = "400", Text="400 cc" },
            new SelectListItem{ Value = "500", Text="500 cc" },
            new SelectListItem{ Value = "600", Text="600 cc" },
            new SelectListItem{ Value = "750", Text="750 cc" },
            new SelectListItem{ Value = "1000", Text="1000 cc" },
            new SelectListItem{ Value = "1200", Text="1200 cc" }
        };

        public List<SelectListItem> PriceRangeFromList { get; } = new List<SelectListItem>()
        {
            new SelectListItem{ Value = "0", Text="Välj pris från", Selected=true },
            new SelectListItem{ Value = "50000", Text="50 000 kr" },
            new SelectListItem{ Value = "100000", Text="100 000 kr" },
            new SelectListItem{ Value = "150000", Text="150 000 kr" },
            new SelectListItem{ Value = "200000", Text="200 000 kr" },
            new SelectListItem{ Value = "250000", Text="250 000 kr" }
        };

        public List<SelectListItem> PriceRangeToList { get; } = new List<SelectListItem>()
        {
            new SelectListItem{ Value = "0", Text="Välj pris till", Selected=true },
            new SelectListItem{ Value = "50000", Text="50 000 kr" },
            new SelectListItem{ Value = "100000", Text="100 000 kr" },
            new SelectListItem{ Value = "150000", Text="150 000 kr" },
            new SelectListItem{ Value = "200000", Text="200 000 kr" },
            new SelectListItem{ Value = "250000", Text="250 000 kr" }
        };

        public List<SelectListItem> YearFromList { get; } = new List<SelectListItem>()
        {
            new SelectListItem{ Value = "0", Text="Välj år från", Selected=true },
            new SelectListItem{ Value = "2010", Text="2010" },
            new SelectListItem{ Value = "2011", Text="2011" },
            new SelectListItem{ Value = "2012", Text="2012" },
            new SelectListItem{ Value = "2013", Text="2013" },
            new SelectListItem{ Value = "2014", Text="2014" },
            new SelectListItem{ Value = "2015", Text="2015" },
            new SelectListItem{ Value = "2016", Text="2016" },
            new SelectListItem{ Value = "2017", Text="2017" },
            new SelectListItem{ Value = "2018", Text="2018" },
            new SelectListItem{ Value = "2019", Text="2019" },
            new SelectListItem{ Value = "2020", Text="2020" }
        };

        public List<SelectListItem> YearToList { get; } = new List<SelectListItem>()
        {
            new SelectListItem{ Value = "0", Text="Välj år till", Selected=true },
            new SelectListItem{ Value = "2010", Text="2010" },
            new SelectListItem{ Value = "2011", Text="2011" },
            new SelectListItem{ Value = "2012", Text="2012" },
            new SelectListItem{ Value = "2013", Text="2013" },
            new SelectListItem{ Value = "2014", Text="2014" },
            new SelectListItem{ Value = "2015", Text="2015" },
            new SelectListItem{ Value = "2016", Text="2016" },
            new SelectListItem{ Value = "2017", Text="2017" },
            new SelectListItem{ Value = "2018", Text="2018" },
            new SelectListItem{ Value = "2019", Text="2019" },
            new SelectListItem{ Value = "2020", Text="2020" }
        };
    }
}
