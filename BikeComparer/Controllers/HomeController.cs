using System.Diagnostics;
using BikeComparer.Models;
using Microsoft.AspNetCore.Mvc;
using Database.EntityModels;
using Database.Repositories;
using AutoMapper;
using DomainObjects;
using BikeComparer.Common.Helpers;
using Common.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using BikeComparer.Common.Enums;
using BikeComparer.Common.Extensions;

namespace BikeComparer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositoryBase<BikeDataMain> _repositoryBase;
        private readonly IBikeDataBasicRepository _bikeDataBasicRepository;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IRepositoryBase<BikeDataMain> repositoryBase, IBikeDataBasicRepository bikeDataBasicRepository, IMapper mapper)
        {
            _logger = logger;
            _bikeDataBasicRepository = bikeDataBasicRepository;
            _repositoryBase = repositoryBase;
            _mapper = mapper;
        }

        //
        /// <summary>
        /// Index GET Action for querying of all motorcycles on the Swedish market.
        /// The query in the Get action (rather than in the POST action) for two reasons:   
        /// 1: The user should be able to bookmark the search URL. By using HTTP GET, the form data is passed in the URL as query strings, which enables users to bookmark the URL.
        /// 2: The W3C recommendation is to use HTTP Get for queries which doesn't update the db.
        /// More details: https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/sort-filter-page?view=aspnetcore-9.0#add-a-search-box-to-the-student-index-view
        /// </summary>
        /// <param name="YearRange"></param>
        /// <param name="BikeBrandName"></param>
        /// <param name="BikeCategory"></param>
        /// <param name="PriceFrom"></param>
        /// <param name="PriceTo"></param>
        /// <param name="EngineCapacityFrom"></param>
        /// <param name="EngineCapacityTo"></param>
        /// <param name="PowerFrom"></param>
        /// <param name="PowerTo"></param>
        /// <param name="ABS"></param>
        /// <param name="TractionControl"></param>
        /// <param name="RiderModes"></param>
        /// <param name="ActiveSuspension"></param>
        /// <param name="WheelieControl"></param>
        /// <param name="LaunchControl"></param>
        /// <param name="YearFrom"></param>
        /// <param name="YearTo"></param>
        /// <param name="BikesToCompare"></param>
        /// <param name="Id"></param>
        /// <param name="Details"></param>
        /// <param name="btnGroupPaging"></param>
        /// <param name="TotalCount"></param>
        /// <param name="CurrentPage"></param>
        /// <returns></returns>
        public async Task<IActionResult> Index(YearRange? YearRange, int? BikeBrandId, string? BikeCategory, double? PriceFrom,
            double? PriceTo, float? EngineCapacityFrom, float? EngineCapacityTo, float? PowerFrom, float? PowerTo,
            SafetyEquipmentStatus? ABS, SafetyEquipmentStatus? TractionControl, SafetyEquipmentStatus? RiderModes,
            SafetyEquipmentStatus? ActiveSuspension, SafetyEquipmentStatus? WheelieControl,
            SafetyEquipmentStatus? LaunchControl, int? YearFrom, int? YearTo, string?[] BikesToCompare, int? Id,
            string btnGroupPaging, int? CurrentPage, string? btnSearch)
        {
            try
            {
                if (BikesToCompare.Count() > 0)
                {
                    return RedirectToAction("BikeComparison", new { id1 = BikesToCompare.ElementAtOrDefault(0), id2 = BikesToCompare.ElementAtOrDefault(1), id3 = BikesToCompare.ElementAtOrDefault(2), id4 = BikesToCompare.ElementAtOrDefault(3) });
                }
                else
                {
                    BikeDataBasic bikeDataRecordSet = new();
                    Pagination pagination;

                    int _currentPage = 1;
                    string strCurrentPage = Request.Query["listPages"].ToString();
                    var queryString = Request.QueryString;

                    if (int.TryParse(strCurrentPage.ToString(), out _currentPage))
                    {
                        _currentPage = int.Parse(strCurrentPage) == 0 ? 1 : int.Parse(strCurrentPage);//Default to page 1
                    }

                    //Landingpage. Sets CurrentPage to 1.
                    if (!queryString.HasValue && btnGroupPaging is null && string.IsNullOrEmpty(strCurrentPage))
                    {
                        int amountOfItems = await _bikeDataBasicRepository.GetAmountOfBikesDefaultQueryAsync();
                        pagination = new Pagination(1, amountOfItems, Paging.PageSize.Standard);
                        bikeDataRecordSet = await _bikeDataBasicRepository.GetAllBikesAsync(bikeDataRecordSet, Pagination.PageSize, Pagination.ItemsToSkip, true);
                    }
                    else
                    {
                        BikeDataBasic bikeDataDto = new()
                        {
                            BikeBrandId = BikeBrandId,
                            BikeCategory = BikeCategory,
                            YearRange = YearRange,
                            PriceFrom = PriceFrom,
                            PriceTo = PriceTo,
                            EngineCapacityFrom = EngineCapacityFrom,
                            EngineCapacityTo = EngineCapacityTo,
                            PowerFrom = PowerFrom,
                            PowerTo = PowerTo,
                            YearFrom = YearFrom,
                            YearTo = YearTo,
                            ABS = ABS,
                            ActiveSuspension = ActiveSuspension,
                            TractionControl = TractionControl,
                            RiderModes = RiderModes,
                            WheelieControl = WheelieControl,
                            LaunchControl = LaunchControl
                        };

                        if (btnGroupPaging is not null && string.IsNullOrEmpty(btnSearch))//One of the buttons in "btnGroupPaging" (First, Previous, Next, Last) is clicked - filter not changed, TotalCount can be reused
                        {
                            //Paging: update the Paging class with the new current page 
                            pagination = new Pagination(_currentPage, Pagination.TotalCount, Paging.PageSize.Standard, btnGroupPaging.GetBtnGroupPagingValue());
                            bikeDataRecordSet = await _bikeDataBasicRepository.GetAllBikesAsync(bikeDataDto, Pagination.PageSize, Pagination.ItemsToSkip, false);
                        }
                        else if (strCurrentPage != Pagination.CurrentPage.ToString() && string.IsNullOrEmpty(btnSearch)) //Page is changed by the list, query filter unchanged
                        {
                            pagination = new Pagination(_currentPage, Pagination.TotalCount, Paging.PageSize.Standard);
                            bikeDataRecordSet = await _bikeDataBasicRepository.GetAllBikesAsync(bikeDataDto, Pagination.PageSize, Pagination.ItemsToSkip, false);
                        }
                        else //btnSearch clicked, new query=new TotalCount
                        {
                            bikeDataRecordSet = await _bikeDataBasicRepository.GetAllBikesAsync(bikeDataDto, Pagination.PageSize, Pagination.ItemsToSkip, true);
                            int totalCount = bikeDataRecordSet.TotalCount ?? 1;
                            pagination = new Pagination(1, totalCount, Paging.PageSize.Standard);
                        }
                    }

                    bikeDataRecordSet.BikeCategoryList.Insert(0, new DomainObjects.BikeCategoryDto { Id = 0, Name = "Kategori" });
                    bikeDataRecordSet.bikeBrandList.Insert(0, new DomainObjects.BikeBrandDto { Id = 0, Name = "Tillverkare" });

                    List<SelectListItem> listPages = new List<SelectListItem>();
                    listPages = Pagination.PagesList.Select(m => new SelectListItem { Value = m.ToString(), Text = m.ToString() }).ToList();
                    if (listPages.Count > 0)
                    {
                        int selectedValue = Pagination.CurrentPage == 0 ? 1 : Pagination.CurrentPage;
                        listPages.FirstOrDefault(m => m.Value == selectedValue.ToString())!.Selected = true;
                    }

                    List<SelectListItem> listPages2 = new List<SelectListItem>();
                    listPages2 = Pagination.PagesList.Select(m => new SelectListItem { Value = m.ToString(), Text = m.ToString() }).ToList();
                    if (listPages2.Count > 0)
                    {
                        int selectedValue = Pagination.CurrentPage == 0 ? 1 : Pagination.CurrentPage;
                        listPages2.FirstOrDefault(m => m.Value == selectedValue.ToString())!.Selected = true;
                    }

                    ViewBag.listPages = listPages;
                    ViewBag.listPages2 = listPages2;

                    var mappedBikes = _mapper.Map<BikeDataBasic, BikeDataBasicViewModel>(bikeDataRecordSet);
                    return View(mappedBikes);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Index");
                return new NotFoundResult();
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null || id == 0)
                {
                    return new NotFoundResult();
                }
                var bikeDetails = await _bikeDataBasicRepository.GetBikeAsync(id.Value);

                if (bikeDetails is null)
                {
                    return new NotFoundResult();
                }

                List<Slider> files = new List<Slider>();
                string brandName = bikeDetails.BikeComparisonList[0].BrandName ?? string.Empty;
                string modelName = bikeDetails.BikeComparisonList[0].ModelName ?? string.Empty;
                string firstYear = bikeDetails.BikeComparisonList[0].FirstYear ?? string.Empty;
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "bikes", brandName, modelName, "big", firstYear) ?? string.Empty;

                //image slider
                if (Directory.Exists(path))
                {
                    string[] filepaths = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "bikes", brandName, modelName, "big", firstYear)) ?? Array.Empty<string>();

                    if (filepaths.Length == 0)
                    {
                        string filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "Icons", "missingImg.jpg");
                        files.Add(new Slider
                        {
                            title = "Missing image",
                            src = filepath
                        });
                    }
                    else
                    {
                        foreach (string filePath in filepaths)
                        {
                            string fileName = Path.GetFileName(filePath);
                            files.Add(new Slider
                            {
                                title = fileName.Split('.')[0].ToString(),
                                src = bikeDetails.BikeComparisonList[0].ImgFolderPath + fileName
                            });
                        }
                    }
                }
                else
                {
                    string filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "Icons", "missingImg.jpg");
                    files.Add(new Slider
                    {
                        title = "Missing image",
                        src = filepath
                    });
                }

                var mappedBikes = _mapper.Map<BikeDetails, BikeDetailsViewModel>(bikeDetails.BikeComparisonList[0]);
                mappedBikes.files = files;
                return View(mappedBikes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Details");
                return new NotFoundResult();
            }
        }

        public async Task<IActionResult> BikeComparison(int? id1, int? id2, int? id3, int? id4)
        {
            try
            {
                if (id1 is null && id2 is null && id3 is null && id4 is null)
                {
                    return new NotFoundResult();
                }

                List<BikeDetails> lstBikes = new();
                BikeComparisonViewModel bikeComparison = new();

                var bikes = await _bikeDataBasicRepository.GetBikeAsync(id1 ?? 0, id2 ?? 0, id3 ?? 0, id4 ?? 0);

                if (bikes is not null)
                {
                    var mappedBikes = _mapper.Map<IEnumerable<BikeDetails>, IEnumerable<BikeComparisonViewModel>>(bikes.BikeComparisonList);// lstBikes);
                    bikeComparison.BikeComparisonList = mappedBikes.ToList();
                }
                return View(bikeComparison);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in BikeComparison");
                return new NotFoundResult();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
