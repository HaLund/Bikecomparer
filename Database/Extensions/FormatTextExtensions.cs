using System.Text;

namespace Database.Extensions
{
    public static class FormatTextExtensions
    {
        public static string FormatPriceText(this double? price, string currency, int? finalYear)
        {
            if (price == null)
            {
                return "Uppgift saknas";
            }
            if (finalYear != null)
            {
                return $"{price:#,0} {currency} ({finalYear})";
            }

            return $"{price:#,0} {currency}";
        }

        public static string FormatShortModelNameText(this string? modelName, string? brandName)
        {
            if (string.IsNullOrEmpty(modelName) || string.IsNullOrEmpty(brandName))
            {
                return string.Empty;
            }
            string fullName = $"{brandName} {modelName}";
            if (fullName.Length > 27)
            {
                return string.Concat(fullName.AsSpan(0, 27), "...");
            }
            else
            {
                return $"{brandName} {modelName}";
            }
        }

        public static string FormatEngineText(this int? valvesPerCylinder, string? cooling, int? stroke, string? cylinderConfiguration, string? engineType, double? capacity)
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
            if (capacity != null)
            {
                if (sbEngineText.Length > 0)
                {
                    sbEngineText.Append(", ");
                }
                sbEngineText.Append($"{capacity} cc");
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
    }
}
