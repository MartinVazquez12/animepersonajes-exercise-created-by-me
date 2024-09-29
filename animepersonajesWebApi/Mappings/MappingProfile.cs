using animepersonajesWebApi.Dtos;
using animepersonajesWebApi.Models;
using AutoMapper;

namespace animepersonajesWebApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Personaje, PersonajeDto>()
            .ForMember(dest => dest.id_pers, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.nombredto, opt => opt.MapFrom(src => src.Nombre))
            .ForMember(dest => dest.ocupdto, opt => opt.MapFrom(src => src.Ocupacion))
            .ForMember(dest => dest.locdto, opt => opt.MapFrom(src => src.Localizacion))
            .ForMember(dest => dest.edadto, opt => opt.MapFrom(src => src.Edad))
            .ForMember(dest => dest.generodto, opt => opt.MapFrom(src => src.Genero))
            .ForMember(dest => dest.vivodto, opt => opt.MapFrom(src => src.Vivo))
            .ForMember(dest => dest.animename, opt => opt.MapFrom(src => src.IdAnimeNavigation.Anime1))
            .ReverseMap();

            CreateMap<Personaje, PersonajePostDto>()
            .ForMember(dest => dest.id_post, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.nombrepost, opt => opt.MapFrom(src => src.Nombre))
            .ForMember(dest => dest.ocupost, opt => opt.MapFrom(src => src.Ocupacion))
            .ForMember(dest => dest.locpost, opt => opt.MapFrom(src => src.Localizacion))
            .ForMember(dest => dest.edadpost, opt => opt.MapFrom(src => src.Edad))
            .ForMember(dest => dest.generopost, opt => opt.MapFrom(src => src.Genero))
            .ForMember(dest => dest.vivopost, opt => opt.MapFrom(src => src.Vivo))
            .ForMember(dest => dest.id_animepost, opt => opt.MapFrom(src => src.IdAnime))
            .ReverseMap();

            CreateMap<Anime, AnimeDto>()
            .ForMember(dest => dest.id_anime, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.animedto, opt => opt.MapFrom(src => src.Anime1))
            .ReverseMap();

        }
    }
}
