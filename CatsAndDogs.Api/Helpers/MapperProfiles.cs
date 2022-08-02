using AutoMapper;
using CatsAndDogs.Business.Models;
using Integration.Cats.Api.Models;
using Integration.Dogs.Api.Models;

namespace CatsAndDogs.Api.Helpers
{
    /// <summary>
    /// Contains all of the Mapping Profiles
    /// </summary>
    public class MapperProfiles : Profile
    {
        /// <summary>
        /// Registers the mapping Profiles
        /// </summary>
        public MapperProfiles()
        {
            #region == Dog Mappingss ==
            CreateMap<DogImage, Image>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.Width,
                    opt => opt.MapFrom(src => src.Width)
                )
                .ForMember(
                    dest => dest.Height,
                    opt => opt.MapFrom(src => src.Height)
                )
                .ForMember(
                    dest => dest.Url,
                    opt => opt.MapFrom(src => src.Url)
                );

            CreateMap<Dog, Pet>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name)
                )
                .ForMember(
                    dest => dest.Temperament,
                    opt => opt.MapFrom(src => src.Temperament)
                )
                .ForMember(
                    dest => dest.Origin,
                    opt => opt.MapFrom(src => src.Origin)
                )
                .ForMember(
                    dest => dest.Image,
                    opt => opt.MapFrom(src => src.Image)
                )
                .ForMember(
                    dest => dest.BredFor,
                    opt => opt.MapFrom(src => src.BredFor)
                )
                .ForMember(
                    dest => dest.BreedGroup,
                    opt => opt.MapFrom(src => src.BreedGroup)
                );

            CreateMap<DogSearchResult, Pet>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name)
                )
                .ForMember(
                    dest => dest.Temperament,
                    opt => opt.MapFrom(src => src.Temperament)
                )
                .ForMember(
                    dest => dest.BredFor,
                    opt => opt.MapFrom(src => src.BredFor)
                )
                .ForMember(
                    dest => dest.BreedGroup,
                    opt => opt.MapFrom(src => src.BreedGroup)
                );

            #endregion

            #region == Cat Mapping ==
            CreateMap<CatImage, Image>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.Width,
                    opt => opt.MapFrom(src => src.Width)
                )
                .ForMember(
                    dest => dest.Height,
                    opt => opt.MapFrom(src => src.Height)
                )
                .ForMember(
                    dest => dest.Url,
                    opt => opt.MapFrom(src => src.Url)
                );

            CreateMap<Cat, Pet>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name)
                )
                .ForMember(
                    dest => dest.Temperament,
                    opt => opt.MapFrom(src => src.Temperament)
                )
                .ForMember(
                    dest => dest.Origin,
                    opt => opt.MapFrom(src => src.Origin)
                )
                .ForMember(
                    dest => dest.Image,
                    opt => opt.MapFrom(src => src.Image)
                )
                .ForMember(
                    dest => dest.CountryCode,
                    opt => opt.MapFrom(src => src.CountryCode)
                )
                .ForMember(
                    dest => dest.Description,
                    opt => opt.MapFrom(src => src.Description)
                );

            CreateMap<CatSearchResult, Pet>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name)
                )
                .ForMember(
                    dest => dest.Temperament,
                    opt => opt.MapFrom(src => src.Temperament)
                )
                .ForMember(
                    dest => dest.Origin,
                    opt => opt.MapFrom(src => src.Origin)
                )
                .ForMember(
                    dest => dest.CountryCode,
                    opt => opt.MapFrom(src => src.CountryCode)
                )
                .ForMember(
                    dest => dest.Description,
                    opt => opt.MapFrom(src => src.Description)
                );
            #endregion
        }
    }
}
