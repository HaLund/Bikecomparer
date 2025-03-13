using System;
using System.Collections.Generic;

namespace Database.EntityModels;

public partial class Performance
{
    public int PerformanceId { get; set; }

    public double? StandingQvarterMileTime { get; set; }

    public double? Standing01000mTime { get; set; }

    public double? Standing01000mTopSpeed { get; set; }

    public double? TopSpeed { get; set; }

    public double? Braking1000 { get; set; }

    public double? StandingQvarterMileTopSpeed { get; set; }

    public double? Acceleration0100kmH { get; set; }

    public double? Acceleration0200kmH { get; set; }

    public double? Acceleration060mph { get; set; }

    public double? Standing0400mTime { get; set; }

    public double? Braking60mph0 { get; set; }

    public double? StandingMileTime { get; set; }
}
