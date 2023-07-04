using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[Controller]")]
public class MovieController : ControllerBase
{
    private static List<Movie> movies = new List<Movie>();
    private static int id = 0;

    [HttpPost]
    public IActionResult AddMovie([FromBody] Movie movie)
    {
        movie.Id = id++;
        movies.Add(movie);
        return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
    }

    [HttpGet]
    public IEnumerable<Movie> GetMovies([FromQuery] int skip, [FromQuery] int take)
    {
        return movies.Skip(skip).Take(take);
    }


    [HttpGet("{id}")]
    public IActionResult GetMovieById(int id)
    {
        var movie =  movies.FirstOrDefault(x => x.Id == id);
        if (movie == null) return NotFound();
        return Ok(movie);
    }


}
