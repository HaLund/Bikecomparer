using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Extensions
{
    public static class UrlExtensions
    {
        public static string FullImgPathSmall(this string? imgName, string? brandName, string? model, int? year)
        {
            string imgPath = "";

            if (string.IsNullOrEmpty(imgName))
            {
                return $"../Images/Icons/missingImg.jpg";
            }

            imgPath = $"../Images/Bikes//{brandName}/{model}/Small/{year}/{imgName}";
            return imgPath;
        }

        public static string FullImgPathLarge(this string? imgName, string? brandName, string? model, int? year)
        {
            string imgPath = "";

            if (string.IsNullOrEmpty(imgName))
            {
                return $"/Images/Icons/missingImg.jpg";
            }

            imgPath = $"/Images/Bikes/{brandName}/{model}/Big/{year}/{imgName}";
            return imgPath;
        }

        public static string ImgFolderPathLarge(this string? brandName, string? model, int? year)
        {
            string imgFolderPath = "";
            if (string.IsNullOrEmpty(brandName))
            {
                return $"/Images/Icons/missingImg.jpg";
            }
            imgFolderPath = $"/Images/Bikes/{brandName}/{model}/Big/{year}/";
            return imgFolderPath;
        }

        public static string ImgMissingPath(this string? modelName)
        {
            return $"/Images/Icons/missingImg.jpg";
        }
    }
}
