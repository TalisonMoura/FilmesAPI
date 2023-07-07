using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class MovieController : ControllerBase
    {

        private MovieContext _movieContext;

        public MovieController(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            _movieContext.Movies.Add(movie);
            _movieContext.SaveChanges();
            return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
        }

        [HttpGet]
        public IEnumerable<Movie> GetMovies([FromQuery] int skip, [FromQuery] int take)
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


