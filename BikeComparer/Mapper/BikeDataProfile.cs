using AutoMapper;
using BikeComparer.Models;
using DomainObjects;

namespace BikeComparer.Mapper
{
    public class BikeDataProfile : Profile
    {
        public BikeDataProfile()
        {
            CreateMap<BikeDataBasic, BikeDataBasicViewModel>()
                .ForMember(dest => dest.BikeDataBasicList, opt => opt.MapFrom(src => src.BikeDataBasicList));
            CreateMap<DomainObjects.BikeCategoryDto, Models.BikeCategoryDto>();
            CreateMap<DomainObjects.BikeBrandDto, Models.BikeBrandDto>();
            //CreateMap<DomainObjects.PagingDto, Models.PagingDto>();
            //CreateMap<BikeDataBasic, BikeDataBasicViewModel>()
            //    .ForMember(dest => dest.pagingList, opt => opt.MapFrom(src => src.pagingList));
            CreateMap<BikeDataBasic, BikeDataBasicViewModel>()
                .ForMember(dest => dest.bikeCategoryList, opt => opt.MapFrom(src => src.BikeCategoryList));
            CreateMap<BikeDetails, BikeDetailsViewModel>();

            CreateMap<BikeDetailsViewModel, BikeComparisonViewModel>();

            CreateMap<BikeDetails, BikeComparisonViewModel>();
            CreateMap<BikeDetails, BikeComparisonViewModel>()
                .ForMember(dest => dest.BikeComparisonList, opt => opt.MapFrom(src => src.BikeComparisonList));
        }
    }
}
