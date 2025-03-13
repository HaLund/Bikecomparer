using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public class TextHelpers
    {
        public static string FormatEngineText(int? valvesPerCylinder, string? cooling, int? stroke, string? boreXstroke, string? cylinderConfiguration, string? engineType)
        {
            StringBuilder sbEngineText = new StringBuilder();
            if (!string.IsNullOrEmpty(cylinderConfiguration))
            {
                sbEngineText.Append(cylinderConfiguration);
            }
            if (stroke != null)
            {
                if (sbEngineText.Length > 0)
                {
                    sbEngineText.Append(", ");
                }
                sbEngineText.Append($"{stroke}-takt");
            }
            if (!string.IsNullOrEmpty(cooling))
            {
                if (sbEngineText.Length > 0)
                {
                    sbEngineText.Append(", ");
                }
                sbEngineText.Append(cooling);
            }
            if (!string.IsNullOrEmpty(engineType))
            {
                if (sbEngineText.Length > 0)
                {
                    sbEngineText.Append(", ");
                }
                sbEngineText.Append(engineType);
            }
            if (valvesPerCylinder != null)
            {
                if (sbEngineText.Length > 0)
                {
                    sbEngineText.Append(", ");
                }
                sbEngineText.Append($"{valvesPerCylinder} ventiler per cylinder");
            }
            return sbEngineText.ToString();
        }

        public static string FormatPriceText(double? price, string currency, int? finalYear)
        {
            if(price == null)
            {
                return string.Empty;
            }
            if (finalYear  != null)
            {
                return $"{price:#,0} {currency} ({finalYear})";
            }

            return $"{price:#,0} {currency}";
        }   
    }
}
