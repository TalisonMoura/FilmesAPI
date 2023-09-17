using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController  : ControllerBase
    {
        MovieContext _context;
        IMapper _mapper;

        public SessionController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ReadSessionDTO> FindAllSessions()
        {
            return _mapper.Map<List<ReadSessionDTO>>(_context.Sessions.ToList());
        }

        [HttpGet("{movieId}/{cinemaId}")]
        public IActionResult FindSessionById(int movieId, int cinemaId)
        {
            Session sessionId = _context.Sessions.FirstOrDefault(
                session => session.MovieId == movieId &&
                session.CinemaId == cinemaId);
            if (sessionId == null)
            {
                return NotFound();
            }
            ReadSessionDTO readSessionDTO = _mapper.Map<ReadSessionDTO>(sessionId);
            return Ok(sessionId);
        }

        [HttpPost]
        public IActionResult CreateSession([FromBody] CreateSessionDTO sessionDTO)
        {
            Session session = _mapper.Map<Session>(sessionDTO);
            _context.Sessions.Add(session);
            _context.SaveChanges();
            return CreatedAtAction(nameof(FindSessionById), new Session 
            { MovieId = session.MovieId, CinemaId = session.CinemaId }, sessionDTO);
        }

        //[HttpDelete]
        //public IActionResult DeleteSession(int id)
        //{
        //    Session session = _context.Sessions.FirstOrDefault();
        //    if(session == null)
        //    {
        //        return NotFound();
        //    }
        //    _context.Sessions.Remove(session);
        //    _context.SaveChanges();
        //    return NoContent();
        //}
    }
}
