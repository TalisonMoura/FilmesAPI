using Microsoft.AspNetCore.Mvc;
using FilmesAPI.Data;
using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        public MovieContext _context { get; set; }
        public IMapper _mapper { get; set; }

        public CinemaController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cinemaDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddCine([FromBody] CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCineById), new { Id = cinema.Id }, cinemaDto);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ReadCinemaDto> GetAllCines([FromQuery] int? addressId = null)
        {
            if (addressId == null)
            {
                var cineList = _context.Cinemas.ToList();
                return _mapper.Map<List<ReadCinemaDto>>(cineList);
            }
            return _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas.FromSqlRaw(
                $"SELECT Id, Nome, AddressId FROM cinemas where cinemas.AddressId = {addressId}").ToList());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetCineById(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(x => x.Id == id);
            if (cinema != null)
            {
                ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
                return Ok(cinemaDto);
            }
            return NotFound();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cineDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult UpdateCine(int id, [FromBody] UpdateCinemaDto cineDto)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(x => x.Id == id);
            if (cinema == null) return NotFound();
            _mapper.Map(cineDto, cinema);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCine(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(x => x.Id == id);
            if (cinema == null) return NotFound();
            _context.Remove(cinema);
            _context.SaveChanges();
            return NoContent();
        }



    }
}
