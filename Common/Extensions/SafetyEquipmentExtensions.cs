using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class SafetyEquipmentExtensions
    {
        public static string ToFriendlyString(this SafetyEquipmentStatus safetyEquipment)
        {
            return safetyEquipment switch
            {
                SafetyEquipmentStatus.All => "Alla",
                SafetyEquipmentStatus.WithSafetyEquipment => "Med säkerhetsutrustning",
                SafetyEquipmentStatus.WithoutSafetyEquipment => "Utan säkerhetsutrustning",
                _ => throw new NotImplementedException()
            };
        }
    }
}
