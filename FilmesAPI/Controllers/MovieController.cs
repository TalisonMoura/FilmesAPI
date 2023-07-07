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
<<<<<<< HEAD

=======
                
>>>>>>> 50c2781fead245e19046805c4ddf050ad65bf46e
        public MovieController(MovieContext movieContext, IMapper iMapper)
        {
            _movieContext = movieContext;
            _mapper = iMapper;
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] CreateMovieDto movieDto)
        {
<<<<<<< HEAD
            Movie movie = _mapper.Map<Movie>(movieDto);
=======

>>>>>>> 50c2781fead245e19046805c4ddf050ad65bf46e
            _movieContext.Movies.Add(movie);
            _movieContext.SaveChanges();
            return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDto movieDto)
        {
            var movie = _movieContext.Movies.FirstOrDefault(x => x.Id == id);
            if (movie == null) return NotFound();
            _mapper.Map(movieDto, movie);
            _movieContext.SaveChanges();
            return NoContent();
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


