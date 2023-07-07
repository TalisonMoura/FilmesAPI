using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile() 
        {
            CreateMap<CreateMovieDto, Movie>();
<<<<<<< HEAD
            CreateMap<UpdateMovieDto, Movie>();
            CreateMap<DeleteMovieDto, Movie>();
=======
>>>>>>> 50c2781fead245e19046805c4ddf050ad65bf46e
        }
    }
}
