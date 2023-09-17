using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDto, Cinema>();
            CreateMap<Cinema, ReadCinemaDto>()
                .ForMember(cineDto => cineDto.Address,
                           opt => opt.MapFrom(cine => cine.Address))
                .ForMember(cineDto => cineDto.Sessions,
                           opt => opt.MapFrom(cine => cine.Sessions));
            CreateMap<UpdateCinemaDto, Cinema>();
        }
    }
}
