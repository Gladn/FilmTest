using AutoMapper;
using FilmsTest.DTOs;
using FilmsTest.Model;


namespace FilmsTest.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Film, FilmDTO>()
                .ForMember(dest => dest.FmID, opt => opt.MapFrom(src => src.FmID))
                .ForMember(dest => dest.FmTitle, opt => opt.MapFrom(src => src.FmTitle))
                .ForMember(dest => dest.FmYear, opt => opt.MapFrom(src => src.FmYear));


            CreateMap<Genre, GenreDTO>()
            .ForMember(dest => dest.GenID, opt => opt.MapFrom(src => src.GenID))
            .ForMember(dest => dest.GenName, opt => opt.MapFrom(src => src.GenName));


            CreateMap<FilmGenre, FilmGenreDTO>()
                .ForMember(dest => dest.GenID, opt => opt.MapFrom(src => src.GenID))
                .ForMember(dest => dest.FmID, opt => opt.MapFrom(src => src.FmID));


            CreateMap<Actor, ActorDTO>()
                .ForMember(dest => dest.ActID, opt => opt.MapFrom(src => src.ActID))
                .ForMember(dest => dest.ActName, opt => opt.MapFrom(src => src.ActName));


            CreateMap<FilmActor, FilmActorDTO>()
                .ForMember(dest => dest.ActID, opt => opt.MapFrom(src => src.ActID))
                .ForMember(dest => dest.FmID, opt => opt.MapFrom(src => src.FmID));
        }
    }
}
