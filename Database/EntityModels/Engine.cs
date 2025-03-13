using System;
using System.Collections.Generic;

namespace Database.EntityModels;

public partial class Engine
{
    public int EngineId { get; set; }

    public int? EngineTypeId { get; set; }

    public int? CylinderConfigurationId { get; set; }

    public int? CoolingId { get; set; }

    public double? Capacity { get; set; }

    public int? ValvesPerCylinder { get; set; }

    public int? Strokes { get; set; }

    public string? BoreXStroke { get; set; }

    public string? CompressionRatio { get; set; }

    public string? IgnitionStarting { get; set; }

    public double? MaxPower { get; set; }

    public int? PeekPowerReev { get; set; }

    public double? MaxTorqueNm { get; set; }

    public double? MaxTorqueKgm { get; set; }

    public double? MaxTorqueFtlb { get; set; }

    public double? MaxTorqueKpm { get; set; }

    public int? PeekTorqueReev { get; set; }

    public double? MaxPowerSweden { get; set; }

    public string? TransmissionDrive { get; set; }

    public string? StartSystem { get; set; }

    public string? FuelSystem { get; set; }

    public bool? AdjustableEngineMapManagement { get; set; }

    public string? EngineMapDetailsText { get; set; }

    public string? StartSystemEng { get; set; }

    public string? FuelSystemEng { get; set; }

    public string? EngineMapDetailsTextEng { get; set; }

    public virtual ICollection<BikeDataMain> BikeDataMains { get; set; } = new List<BikeDataMain>();

    public virtual Cooling? Cooling { get; set; }

    public virtual CylinderConfiguration? CylinderConfiguration { get; set; }

    public virtual EngineType? EngineType { get; set; }
}
