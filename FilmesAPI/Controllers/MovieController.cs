using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class MovieController : ControllerBase
    {

        private MovieContext _movieContext;
        private IMapper _mapper;
                
        public MovieController(MovieContext movieContext, IMapper iMapper)
        {
            _movieContext = movieContext;
            _mapper = iMapper;
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] CreateMovieDto movieDto)
        {

            _movieContext.Movies.Add(movie);
            _movieContext.SaveChanges();
            return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
        }

        [HttpGet]
        public IEnumerable<Movie> GetMovies([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _movieContext.Movies.Skip(skip).Take(take);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            var movie = _movieContext.Movies.FirstOrDefault(x => x.Id == id);
            if (movie == null) return NotFound();
            return Ok(movie);
        }


    }
}


