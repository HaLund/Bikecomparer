namespace BikeComparer.Models
{
    public class BikeComparisonViewModel
    {
        public int McId { get; set; }
        public string? BikeCategory { get; set; }
        public string? FullName { get; set; }
        public string? FirstYear { get; set; }
        public string? ImgPath { get; set; }
        public string? ImgPathLarge { get; set; }
        public string? imgName { get; set; }
        public string? Price { get; set; }
        public string? Engine { get; set; }
        public string? Bore_X_stroke { get; set; }
        public string? Capacity { get; set; }
        public string? PeekpowerReev { get; set; }
        public string? TorqueAtReev { get; set; }
        public string? Compression { get; set; }
        public string? StartSystem { get; set; }
        public string? FuelingSystem { get; set; }
        public string? Gearbox { get; set; }
        public string? FinalDrive { get; set; }
        public string? Clutch { get; set; }
        public string? DryWeight { get; set; }
        public string? WetWeight { get; set; }
        public string? WheelBase { get; set; }
        public string? SeatHeight { get; set; }
        public string? Rake { get; set; }
        public string? Trail { get; set; }
        public string? FuelCapacityAndReserv { get; set; }
        public string? Warranty { get; set; }
        public string? ServiceInterval { get; set; }
        public string? ValveCheckInterval { get; set; }
        public string? Frame { get; set; }
        public string? FrontSuspension { get; set; }
        public string? RearSuspension { get; set; }
        public string? FrontBrakes { get; set; }
        public string? RearBrakes { get; set; }
        public string? FrontTyre { get; set; }
        public string? RearTyre { get; set; }
        public string? ABS_disconnectable { get; set; }
        public string? TC_adjustabletable { get; set; }
        public string? EngineMaps { get; set; }
        public string? TCisStandard { get; set; }
        public string? WheelieControl { get; set; }
        public string? LaunchControl { get; set; }
        public string? DynamicDamping { get; set; }
        public string? TopSpeed { get; set; }
        public string? ZeroToHundredSeconds { get; set; }
        public string? ZeroToTwoHundredSeconds { get; set; }
        public string? StandingFourHundredMetersSeconds { get; set; }
        public string? StandingThousandMeterSeconds { get; set; }
        public string? BrakingDistanceHundredToZero { get; set; }
        public string? WebpageSweden { get; set; }
        public string? WebpageGlobal { get; set; }
        public string? GeneralAgent { get; set; }
        public string? Color { get; set; }
        public string? UpdatesForThisYear { get; set; }
        public List<BikeComparisonViewModel> BikeComparisonList { get; set; } = new List<BikeComparisonViewModel>();
    }
}
