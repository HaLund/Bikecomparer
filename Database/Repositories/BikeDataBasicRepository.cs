using DomainObjects;
using Database.EntityModels;
using Common.Enums;
using Database.Extensions;

namespace Database.Repositories
{
    public class BikeDataBasicRepository : RepositoryBase<BikeDataMain>, IBikeDataBasicRepository
    {
        public BikeDataBasicRepository(BikeComparerContext context) : base(context) { }

        public async Task<BikeDetails> GetBikeAsync(int id1)
        {
            var bikeDetails = await GetBikeAsync(id1, 0, 0, 0);
            return bikeDetails;
        }

        public async Task<BikeDetails> GetBikeAsync(int id1, int id2)
        {
            var bikeDetails = await GetBikeAsync(id1, id2, 0, 0);
            return bikeDetails;
        }

        public async Task<BikeDetails> GetBikeAsync(int id1, int id2, int id3)
        {
            var bikeDetails = await GetBikeAsync(id1, id2, id3, 0);
            return bikeDetails;
        }

        public async Task<BikeDetails> GetBikeAsync(int id1, int id2, int id3, int id4)
        {
            using (var context = new BikeComparerContext())
            {
                BikeDetails bikeDetails = new BikeDetails();

                var bikeData = from bike in context.BikeDataMains.FilterBikesById(id1, id2, id3, id4)
                                   join bikeBrand in context.BikeBrands
                                   on bike.BikeBrandId equals bikeBrand.BikeBrandId
                                   join BikeCategory in context.BikeCategories
                                   on bike.BikeCategoryId equals BikeCategory.BikeCategoryId into bikeCategoryGroup
                                   from BikeCategory in bikeCategoryGroup.DefaultIfEmpty()
                                   join engine in context.Engines
                                   on bike.EngineId equals engine.EngineId into engineGroup
                                   from engine in engineGroup.DefaultIfEmpty()
                                   join cooling in context.Coolings
                                   on engine.CoolingId equals cooling.CoolingId into coolingGroup
                                   from cooling in coolingGroup.DefaultIfEmpty()
                                   join CylinderConfiguration in context.CylinderConfigurations
                                   on engine.CylinderConfigurationId equals CylinderConfiguration.CylinderConfigurationId into cylinderConfigurationGroup
                                   from CylinderConfiguration in cylinderConfigurationGroup.DefaultIfEmpty()
                                   join engineType in context.EngineTypes
                                   on engine.EngineTypeId equals engineType.EngineTypeId into engineTypeGroup
                                   from engineType in engineTypeGroup.DefaultIfEmpty()
                                   join chassie in context.Chassies
                                   on bike.ChassieId equals chassie.ChassieId into chassieGroup
                                   from chassie in chassieGroup.DefaultIfEmpty()
                                   join transmission in context.Transmissions
                                   on bike.TransmissionId equals transmission.TransmissionId into transmissionGroup
                                   from transmission in transmissionGroup.DefaultIfEmpty()
                                   join Performance in context.Performances
                                   on bike.PerformanceId equals Performance.PerformanceId into performanceGroup
                                   from Performance in performanceGroup.DefaultIfEmpty()
                                   join similarBikes in context.SimilarBikes
                                   on bike.McId equals similarBikes.McId into bikeDataSimilarBikesGroup
                                   from similarBikes in bikeDataSimilarBikesGroup.DefaultIfEmpty()
                               select new { bike, bikeBrand, BikeCategory, engine, cooling, CylinderConfiguration, engineType, chassie, transmission, Performance };
                
                foreach (var selectedBike in bikeData)
                {
                    bikeDetails.BikeComparisonList.Add(new BikeDetails
                    {
                        McId = selectedBike.bike.McId,
                        ModelName = selectedBike.bike.ModelName,
                        BrandName = selectedBike.bikeBrand?.BikeBrandName,
                        FullName = $"{selectedBike.bikeBrand?.BikeBrandName} {selectedBike.bike.ModelName}",
                        BikeCategory = selectedBike.BikeCategory.BikeCategoryName,
                        FirstYear = selectedBike.bike.FirstYear.ToString(), 
                        Engine = selectedBike.engine?.ValvesPerCylinder.FormatEngineText(selectedBike.cooling?.CoolingName, selectedBike.engine?.Strokes, selectedBike.CylinderConfiguration?.CylinderConfigurationName, selectedBike.engineType?.EngineTypeName, selectedBike.engine?.Capacity),
                        Bore_X_stroke = selectedBike.engine?.BoreXStroke,
                        PeekpowerReev = selectedBike.engine?.PeekPowerReev.ToString(),
                        TorqueAtReev = selectedBike.engine?.PeekTorqueReev.ToString(),
                        Compression = selectedBike.engine?.CompressionRatio, 
                        StartSystem = selectedBike.engine?.StartSystem,
                        FuelingSystem = selectedBike.engine?.FuelSystem,
                        Frame = selectedBike.chassie?.Frame,
                        FrontSuspension = selectedBike.chassie?.FrontSuspension,
                        RearSuspension = selectedBike.chassie?.RearSuspension,
                        FrontBrakes = selectedBike.chassie?.FrontBrakes,
                        RearBrakes = selectedBike.chassie?.RearBrakes,
                        ABS_disconnectable = selectedBike.chassie?.DisconnectableAbs == true ? "Ja" : "Nej",
                        TC_adjustabletable = selectedBike.chassie?.AdjustableTc == true ? "Ja" : "Nej",
                        EngineMaps = selectedBike.engine?.EngineMapDetailsText,
                        TCisStandard = selectedBike.chassie?.TcIsOptional == true ? "Nej" : "Ja",
                        WheelieControl = selectedBike.chassie?.WheelieControl == true ? "Ja" : "Nej",
                        StandingFourHundredMetersSeconds = selectedBike.Performance?.Standing0400mTime != null ? selectedBike.Performance.Standing0400mTime + " sek" : string.Empty,
                        StandingThousandMeterSeconds = selectedBike.Performance?.Standing01000mTime != null ? selectedBike.Performance.Standing01000mTime + " sek" : string.Empty,
                        ZeroToHundredSeconds = selectedBike.Performance?.Acceleration0100kmH != null ? selectedBike.Performance.Acceleration0100kmH + " sek" : string.Empty,
                        ZeroToTwoHundredSeconds = selectedBike.Performance?.Acceleration0200kmH != null ? selectedBike.Performance.Acceleration0200kmH + " sek" : string.Empty,
                        BrakingDistanceHundredToZero = selectedBike.Performance?.Braking1000 != null ? selectedBike.Performance.Braking1000 + " sek" : string.Empty,
                        TopSpeed = selectedBike.Performance?.TopSpeed != null ? selectedBike.Performance.TopSpeed + " km/t" : string.Empty,
                        LaunchControl = selectedBike.chassie?.LaunchControl == true ? "Ja" : "Nej",
                        DynamicDamping = selectedBike.chassie?.DynamicDamping == true ? "Ja" : "Nej",
                        DryWeight = selectedBike.chassie?.DryWeightKg != null ? selectedBike.chassie.DryWeightKg + " kg" : string.Empty,
                        WetWeight = selectedBike.chassie?.WetWeight != null ? selectedBike.chassie.WetWeight + " kg" : string.Empty,
                        WheelBase = selectedBike.chassie?.Wheelbase != null ? selectedBike.chassie.Wheelbase + " mm" : string.Empty,
                        SeatHeight = selectedBike.chassie?.SeatHeight != null ? selectedBike.chassie.SeatHeight + " mm" : string.Empty,
                        Rake = selectedBike.chassie?.Rake != null ? selectedBike.chassie.Rake + " grader" : string.Empty,
                        Trail = selectedBike.chassie?.Trail != null ? selectedBike.chassie.Trail + " mm" : string.Empty,
                        FuelCapacityAndReserv = selectedBike.chassie?.FuelCapacity != null ? selectedBike.chassie.FuelCapacity + " liter" : string.Empty,
                        Warranty = selectedBike.bike.Warranty,
                        ServiceInterval = selectedBike.bike.ServiceInterval,
                        ValveCheckInterval = selectedBike.bike.ValveCheckInterval != null ? selectedBike.bike.ValveCheckInterval + " mil" : string.Empty,
                        GeneralAgent = selectedBike.bikeBrand?.GeneralAgent,
                        WebpageSweden = selectedBike.bikeBrand?.WebpageSweden,
                        WebpageGlobal = selectedBike.bikeBrand?.WebpageGlobal,
                        ImgMissingPath = selectedBike.bike.ModelName.ImgMissingPath(),
                        ImgPath = selectedBike.bike.ImgUrl.FullImgPathSmall(selectedBike.bikeBrand?.BikeBrandName, selectedBike.bike.ModelName, selectedBike.bike.FirstYear),
                        ImgPathLarge = selectedBike.bike.ImgUrl.FullImgPathLarge(selectedBike.bikeBrand?.BikeBrandName, selectedBike.bike.ModelName, selectedBike.bike.FirstYear),
                        ImgFolderPath = selectedBike.bikeBrand?.BikeBrandName.ImgFolderPathLarge(selectedBike.bike.ModelName, selectedBike.bike.FirstYear),
                        Price = selectedBike.bike.Price.FormatPriceText("SEK", selectedBike.bike.FinalYear),
                        Color = selectedBike.bike.Color,
                        UpdatesForThisYear = selectedBike.bike.UpdatesForThisYear != null ? "Nytt för denna generation:" + selectedBike.bike.UpdatesForThisYear : string.Empty,
                        Gearbox = selectedBike.transmission?.Gearbox,
                        FinalDrive = selectedBike.transmission?.FinalDrive,
                        Clutch = selectedBike.transmission?.Clutch,
                    });
                }
                return await Task.FromResult(bikeDetails);
            }
        }

        public async Task<BikeDataBasic> GetAllBikesAsync(BikeDataBasic bikeDataBasic, int pageSize, int itemsToSkip, bool queryChangedSinceLastRequest)
        {
            using (var context = new BikeComparerContext())
            {
                bikeDataBasic.BikeCategoryList = context.BikeCategories.Select(bc => new BikeCategoryDto() { Id = bc.BikeCategoryId, Name = bc.BikeCategoryName }).ToList();
                bikeDataBasic.bikeBrandList = context.BikeBrands.Select(bc => new BikeBrandDto() { Id = bc.BikeBrandId, Name = bc.BikeBrandName }).ToList();

                var filteredBikes = from allBikes in context.BikeDataMains.FilterYearRange(bikeDataBasic, bikeDataBasic.YearRange ?? YearRange.AllBikesAvailableCurrentYear)
                                    join bikeBrand in context.BikeBrands
                                    on allBikes.BikeBrandId equals bikeBrand.BikeBrandId into bikeBrandGroup
                                    from bikeBrand in bikeBrandGroup.DefaultIfEmpty()
                                    join BikeCategory in context.BikeCategories
                                    on allBikes.BikeCategoryId equals BikeCategory.BikeCategoryId into bikeCategoryGroup
                                    from BikeCategory in bikeCategoryGroup.DefaultIfEmpty()
                                    join engine in context.Engines
                                    on allBikes.EngineId equals engine.EngineId into engineGroup
                                    from engine in engineGroup.DefaultIfEmpty()
                                    join cooling in context.Coolings
                                    on engine.CoolingId equals cooling.CoolingId into coolingGroup
                                    from cooling in coolingGroup.DefaultIfEmpty()
                                    join CylinderConfiguration in context.CylinderConfigurations
                                    on engine.CylinderConfigurationId equals CylinderConfiguration.CylinderConfigurationId into cylinderConfigurationGroup
                                    from CylinderConfiguration in cylinderConfigurationGroup.DefaultIfEmpty()
                                    join engineType in context.EngineTypes
                                    on engine.EngineTypeId equals engineType.EngineTypeId into engineTypeGroup
                                    from engineType in engineTypeGroup.DefaultIfEmpty()
                                    join chassie in context.Chassies
                                    on allBikes.ChassieId equals chassie.ChassieId into chassieGroup
                                    from chassie in chassieGroup.DefaultIfEmpty()
                                    where allBikes.QualityApproved == true
                select new { allBikes, bikeBrand, BikeCategory, engine, cooling, CylinderConfiguration, engineType, chassie };

                double priceFrom = 0;
                float? engineCapacityFrom = 0;
                float? powerFrom = 0;

                if (bikeDataBasic.BikeBrandId.HasValue && bikeDataBasic.BikeBrandId > 0)
                {
                    filteredBikes = filteredBikes.Where(b => b.bikeBrand.BikeBrandId == bikeDataBasic.BikeBrandId);
                }

                if (bikeDataBasic.BikeCategory is not null)
                {
                    if (int.TryParse(bikeDataBasic.BikeCategory, out int categoryId))
                    {
                        if (categoryId > 0)
                        {
                            filteredBikes = filteredBikes.Where(b => b.BikeCategory.BikeCategoryId == categoryId);
                        }
                    }
                }

                if (bikeDataBasic.PriceFrom.HasValue && bikeDataBasic.PriceFrom > 0)
                {
                    filteredBikes = filteredBikes.Where(b => b.allBikes.Price >= bikeDataBasic.PriceFrom);
                }

                if (bikeDataBasic.PriceTo.HasValue && bikeDataBasic.PriceTo > priceFrom)
                {
                    filteredBikes = filteredBikes.Where(b => b.allBikes.Price <= bikeDataBasic.PriceTo);
                }
                
                if (bikeDataBasic.PowerFrom.HasValue && bikeDataBasic.PowerFrom > 0)
                {
                    powerFrom = bikeDataBasic.PowerFrom;
                    if (bikeDataBasic.PowerFrom.HasValue && bikeDataBasic.PowerFrom > 0)
                    {
                        powerFrom = bikeDataBasic.PowerFrom;
                        filteredBikes = filteredBikes.Where(b => b.allBikes.Engine != null && b.allBikes.Engine.MaxPower >= powerFrom);
                    }
                }

                if (bikeDataBasic.PowerTo.HasValue && powerFrom > 0 && bikeDataBasic.PowerTo >= powerFrom)
                {
                    filteredBikes = filteredBikes.Where(b => b.allBikes.Engine != null && b.allBikes.Engine.MaxPower <= bikeDataBasic.PowerTo);
                }

                if (bikeDataBasic.EngineCapacityFrom.HasValue && bikeDataBasic.EngineCapacityFrom > 0)
                {
                    engineCapacityFrom = bikeDataBasic.EngineCapacityFrom;
                    filteredBikes = filteredBikes.Where(b => b.allBikes.Engine != null && b.allBikes.Engine.Capacity >= engineCapacityFrom);
                }

                if (bikeDataBasic.EngineCapacityTo.HasValue && bikeDataBasic.EngineCapacityTo > 0 && bikeDataBasic.EngineCapacityTo >= engineCapacityFrom)
                {
                    filteredBikes = filteredBikes.Where(b => b.allBikes.Engine != null && b.allBikes.Engine.Capacity <= bikeDataBasic.EngineCapacityTo);
                }

                if (bikeDataBasic.ABS.HasValue && bikeDataBasic.ABS.Value != SafetyEquipmentStatus.All)
                {
                    filteredBikes = bikeDataBasic.ABS == SafetyEquipmentStatus.WithSafetyEquipment ? filteredBikes.Where(b => b.allBikes.Chassie != null && b.allBikes.Chassie.HasAbs == true) : filteredBikes.Where(b => b.allBikes.Chassie != null && b.allBikes.Chassie.HasAbs == false);
                }

                if (bikeDataBasic.WheelieControl.HasValue && bikeDataBasic.WheelieControl.Value != SafetyEquipmentStatus.All)
                {
                    filteredBikes = bikeDataBasic.WheelieControl == SafetyEquipmentStatus.WithSafetyEquipment ? filteredBikes.Where(b => b.allBikes.Chassie != null && b.allBikes.Chassie.WheelieControl == true) : filteredBikes.Where(b => b.allBikes.Chassie != null && b.allBikes.Chassie.WheelieControl == false);
                }

                if (bikeDataBasic.LaunchControl.HasValue && bikeDataBasic.LaunchControl.Value != SafetyEquipmentStatus.All)
                {
                    filteredBikes = bikeDataBasic.LaunchControl == SafetyEquipmentStatus.WithSafetyEquipment ? filteredBikes.Where(b => b.allBikes.Chassie != null && b.allBikes.Chassie.LaunchControl == true) : filteredBikes.Where(b => b.allBikes.Chassie != null && b.allBikes.Chassie.LaunchControl == false);
                }

                if (bikeDataBasic.TractionControl.HasValue && bikeDataBasic.TractionControl.Value != SafetyEquipmentStatus.All)
                {
                    filteredBikes = bikeDataBasic.TractionControl == SafetyEquipmentStatus.WithSafetyEquipment ? filteredBikes.Where(b => b.allBikes.Chassie != null && b.allBikes.Chassie.TractionControl == true) : filteredBikes.Where(b => b.allBikes.Chassie != null && b.allBikes.Chassie.TractionControl == false);
                }

                if (bikeDataBasic.ActiveSuspension.HasValue && bikeDataBasic.ActiveSuspension.Value != SafetyEquipmentStatus.All)
                {
                    filteredBikes = bikeDataBasic.ActiveSuspension == SafetyEquipmentStatus.WithSafetyEquipment ? filteredBikes.Where(b => b.allBikes.Chassie != null && b.allBikes.Chassie.DynamicDamping == true) : filteredBikes.Where(b => b.allBikes.Chassie != null && b.allBikes.Chassie.DynamicDamping == false);
                }

                if (bikeDataBasic.RiderModes.HasValue && bikeDataBasic.RiderModes.Value != SafetyEquipmentStatus.All)
                {
                    filteredBikes = bikeDataBasic.RiderModes == SafetyEquipmentStatus.WithSafetyEquipment ? filteredBikes.Where(b => b.allBikes.Engine != null && b.allBikes.Engine.AdjustableEngineMapManagement == true) : filteredBikes.Where(b => b.allBikes.Engine != null && b.allBikes.Engine.AdjustableEngineMapManagement == false);
                }

                //check total count-state to avoid unnecesary expensive db-call if possible
                if (queryChangedSinceLastRequest || bikeDataBasic.TotalCount == 0)
                {
                    bikeDataBasic.TotalCount = filteredBikes.Count();
                }

                var bikes = filteredBikes.OrderBy(b => b.bikeBrand.BikeBrandName).ThenBy(m => m.allBikes.ModelName).Skip(itemsToSkip).Take(pageSize).ToList();

                foreach (var bike in bikes)
                {
                    if (bikeDataBasic.BikeDataBasicList == null)
                    {
                        bikeDataBasic.BikeDataBasicList = new List<BikeDataBasic>();
                    }

                    bikeDataBasic.BikeDataBasicList.Add(new BikeDataBasic()
                    { 
                        Id = bike.allBikes != null ? bike.allBikes.McId : 0,
                        ModelNameShort = bike.allBikes?.ModelName.FormatShortModelNameText(bike.bikeBrand == null ? string.Empty : bike.bikeBrand?.BikeBrandName),
                        ImgUrl = bike.allBikes?.ImgUrl.FullImgPathSmall(bike.bikeBrand?.BikeBrandName, bike.allBikes.ModelName, bike.allBikes.FirstYear),
                        ModelName = $"{bike.bikeBrand?.BikeBrandName} {bike.allBikes?.ModelName}",
                        FirstYear = bike.allBikes?.FirstYear,
                        FinalYear = bike.allBikes?.FinalYear,
                        BikeCategory = bike.BikeCategory?.BikeCategoryName,
                        BikeBrandName = bike.bikeBrand?.BikeBrandName,
                        Engine = bike.engine?.ValvesPerCylinder.FormatEngineText(bike.cooling?.CoolingName, bike.engine?.Strokes, bike.CylinderConfiguration?.CylinderConfigurationName, bike.engineType?.EngineTypeName, bike.engine?.Capacity),
                        Color = bike.allBikes?.Color,
                        Description = bike.allBikes?.UpdatesForThisYear,
                        Price = bike.allBikes?.Price.FormatPriceText("SEK", bike.allBikes.FinalYear),
                        Power = bike.engine?.MaxPower,
                        PeekPowerReev = bike.engine?.PeekPowerReev,
                        FuelCapacity = bike.chassie?.FuelCapacity,
                        DryWeight = bike.chassie?.DryWeightKg,
                        WetWeight = bike.chassie?.WetWeight,
                        Wheelbase = bike.chassie?.Wheelbase
                    });
                };

                return await Task.FromResult(bikeDataBasic);
            }
        }

        public async Task<int> GetAmountOfBikesDefaultQueryAsync()
        {
            using (var context = new BikeComparerContext())
            {
                var filteredBikes = from theBikes in context.BikeDataMains
                                    where theBikes.QualityApproved == true
                                    where theBikes.FinalYear == null || theBikes.FinalYear == DateTime.Now.Year
                                    select theBikes;

                int totalCount = filteredBikes.Count();

                return await Task.FromResult(totalCount);
            }
        }
    }
}

