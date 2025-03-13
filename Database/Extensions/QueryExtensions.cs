using Common.Enums;
using Database.EntityModels;
using DomainObjects;

namespace Database.Extensions
{
    public static class QueryExtensions
    {
        public static IQueryable<BikeDataMain> FilterYearRange(this IQueryable<BikeDataMain> bikeDataMainQuery, BikeDataBasic bikeDataBasic, YearRange yearRange = YearRange.AllBikesAvailableCurrentYear)
        {
            if (yearRange == YearRange.OnlyThisYearsNewBikes)
            {
                bikeDataMainQuery = bikeDataMainQuery.Where(b => b.FirstYear == DateTime.Now.Year || b.FirstYear == 2020);//change to DateTime.Year when this years' bikes are in the database
            }
            else if (yearRange == YearRange.AllBikesAvailableCurrentYear)
            {
                if (bikeDataBasic.FirstYear.HasValue)
                {
                    bikeDataMainQuery = bikeDataMainQuery.Where(b => b.FirstYear >= bikeDataBasic.FirstYear && (b.FinalYear == null));
                }
                else
                {
                    bikeDataMainQuery = bikeDataMainQuery.Where(b => b.FinalYear == null || b.FinalYear == DateTime.Now.Year || b.FinalYear == 2020);
                }
            }
            else if (yearRange == YearRange.OldAndNewBikes)
            {
                if (bikeDataBasic.FirstYear.HasValue)
                {
                    bikeDataMainQuery = bikeDataMainQuery.Where(b => b.FirstYear >= bikeDataBasic.FirstYear);
                }

                if (bikeDataBasic.FinalYear.HasValue)
                {
                    if (bikeDataBasic.FinalYear >= 0 && bikeDataBasic.FinalYear >= bikeDataBasic.FirstYear)
                    {
                        bikeDataMainQuery = bikeDataMainQuery.Where(b => b.FinalYear >= bikeDataBasic.FinalYear);
                    }
                }
            }
            return bikeDataMainQuery;
        }

        public static IQueryable<BikeDataMain> FilterBikesById(this IQueryable<BikeDataMain> bikeDataMainQuery, int id1, int id2, int id3, int id4)
        {
            if (id1 > 0 && id2 > 0 && id3 > 0 && id4 > 0)
            {
                bikeDataMainQuery = from bikes in bikeDataMainQuery
                                    where bikes.McId == id1 || bikes.McId == id2 || bikes.McId == id3 || bikes.McId == id4
                                    select bikes;
            }
            else if (id1 > 0 && id2 > 0 && id3 > 0)
            {
                bikeDataMainQuery = from bikes in bikeDataMainQuery
                                    where bikes.McId == id1 || bikes.McId == id2 || bikes.McId == id3
                                    select bikes;
            }
            else if (id1 > 0 && id2 > 0)
            {
                bikeDataMainQuery = from bikes in bikeDataMainQuery
                                    where bikes.McId == id1 || bikes.McId == id2
                                    select bikes;
            }
            else if (id1 > 0)
            {
                bikeDataMainQuery = bikeDataMainQuery.Where(b => b.McId == id1);
            }
            return bikeDataMainQuery;
        }
    }
}
