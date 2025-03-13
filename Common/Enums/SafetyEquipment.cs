using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    public enum SafetyEquipmentStatus
    {
        All = 1,
        WithSafetyEquipment = 2,
        WithoutSafetyEquipment = 3
    }

    public enum SafetyEquipmentType
    {
        ABS = 1,
        TractionControl = 2,
        RiderModes = 3,
        WheelieControl = 4,
        LaunchControl = 5,
        ActiveSuspension = 6
    }
}
