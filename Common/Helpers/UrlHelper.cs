using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public class UrlHelper
    {
        public static string GetImgUrl(string? imgName, string? brand, string? model, int? year)
        {
            string imgPath = "";

            if (string.IsNullOrEmpty(imgName))
            {
                return $"../Images/Icons/missingImg.jpg";
            }

            imgPath = $"../Images/Bikes//{brand}/{model}/Small/{year}/{imgName}";
            return imgPath;
        }

        public static string GetLargeImgUrl(string? imgName, string? brand, string? model, int? year)
        {
            string imgPath = "";

            if (string.IsNullOrEmpty(imgName))
            {
                return $"/Images/Icons/missingImg.jpg";
            }

            imgPath = $"/Images/Bikes/{brand}/{model}/Big/{year}/{imgName}";// Fungerar!! --> "/Images/Bikes/" + brand + "/" + model + "/Big/" + year.ToString() + "/" + imgName;//
            return imgPath;//.ToLower();
        }
    }
}
