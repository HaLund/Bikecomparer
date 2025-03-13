using System;
using System.Collections.Generic;

namespace Database.EntityModels;

public partial class Chassie
{
    public int ChassieId { get; set; }

    public string? Frame { get; set; }

    public string? FrontSuspension { get; set; }

    public string? RearSuspension { get; set; }

    public string? FrontBrakes { get; set; }

    public string? RearBrakes { get; set; }

    public string? FrontTyre { get; set; }

    public string? RearTyre { get; set; }

    public string? SeatHeight { get; set; }

    public int? SeatHeightMin { get; set; }

    public double? FuelCapacity { get; set; }

    public double? FuelCapacityReserv { get; set; }

    public string? Wheelbase { get; set; }

    public double? DryWeightKg { get; set; }

    public double? DryWeightLb { get; set; }

    public double? WetWeight { get; set; }

    public bool? HasAbs { get; set; }

    public bool? DisconnectableAbs { get; set; }

    public double? AbsWeight { get; set; }

    public string? Rake { get; set; }

    public double? Trail { get; set; }

    public bool? TractionControl { get; set; }

    public bool? AdjustableTc { get; set; }

    public bool? WheelieControl { get; set; }

    public bool? LaunchControl { get; set; }

    public bool? TcIsOptional { get; set; }

    public string? AdjustableTcDetailsText { get; set; }

    public bool? DynamicDamping { get; set; }

    public string? DynamicDampingDetailsText { get; set; }

    public string? SeatHeightInches { get; set; }

    public string? WheelbaseInches { get; set; }

    public string? FrameEng { get; set; }

    public string? FrontSuspensionEng { get; set; }

    public string? RearSuspensionEng { get; set; }

    public string? FrontBrakesEng { get; set; }

    public string? RearBrakesEng { get; set; }

    public string? AdjustableTcDetailsTextEng { get; set; }

    public string? DynamicDampingDetailsTextEng { get; set; }

    public virtual ICollection<BikeDataMain> BikeDataMains { get; set; } = new List<BikeDataMain>();
}
