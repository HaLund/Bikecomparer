using System;
using System.Collections.Generic;

namespace Database.EntityModels;

public partial class Transmission
{
    public int TransmissionId { get; set; }

    public string? Gearbox { get; set; }

    public string? FinalDrive { get; set; }

    public string? Clutch { get; set; }

    public string? GearboxEng { get; set; }

    public string? FinalDriveEng { get; set; }

    public string? ClutchEng { get; set; }

    public virtual ICollection<BikeDataMain> BikeDataMains { get; set; } = new List<BikeDataMain>();
}
