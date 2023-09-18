using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
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

        /// <summary>
        /// Adiciona um filme ao banco de dados
        /// </summary>
        /// <param name="movieDto">Objeto com os campos necessários para criação de um filme</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddMovie([FromBody] CreateMovieDto movieDto)
        {
            Movie movie = _mapper.Map<Movie>(movieDto);
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

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _movieContext.Movies.FirstOrDefault(x => x.Id == id);
            if (movie == null) return NotFound();
            _movieContext.Remove(movie);
            _movieContext.SaveChanges();
            return NoContent();
        }

        [HttpGet]
        public IEnumerable<ReadMovieDto> GetMovies([FromQuery] int skip = 0, [FromQuery] int take = 50, [FromQuery] string? cineName = null)
        {
            if( cineName == null)
            {
                return _mapper.Map<List<ReadMovieDto>>(_movieContext.Movies.Skip(skip).Take(take).ToList());
            }
            return _mapper.Map<List<ReadMovieDto>>(_movieContext.Movies.Skip(skip).Take(take)
                   .Where(movie => movie.Sessions.Any(session => session.Cinema.Nome == cineName)).ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            var movie = _movieContext.Movies.FirstOrDefault(x => x.Id == id);
            if (movie == null) return NotFound();
            var movieDto = _mapper.Map<ReadMovieDto>(movie);
            return Ok(movieDto);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateMoviePartial(int id, JsonPatchDocument<UpdateMovieDto> patch)
        {
            var movie = _movieContext.Movies.FirstOrDefault(x => x.Id == id);
            if (movie == null) return NotFound();
            var movieToUpdate = _mapper.Map<UpdateMovieDto>(movie);
            patch.ApplyTo(movieToUpdate, ModelState);
            if (!TryValidateModel(movieToUpdate)) { return ValidationProblem(ModelState); }
            _mapper.Map(movieToUpdate, movie);
            _movieContext.SaveChanges();
            return NoContent();
        }


    }
}


