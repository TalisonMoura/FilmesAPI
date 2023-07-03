using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[Controller]")]
public class MovieController : ControllerBase
{
    private static List<Movie> movies = new List<Movie>();

    [HttpPost]
    public void AddMovie([FromBody] Movie movie)
    {
        movies.Add(movie);
        Console.WriteLine(movie.Tittle);
        Console.WriteLine(movie.Duration);
    }

}
