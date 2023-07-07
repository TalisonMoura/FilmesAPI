using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class ReadMovieDto
    {
        public string Tittle { get; set; }
        public string Gender { get; set; }
        public int Duration { get; set; }
        public DateTime QueryTime { get; set; } = DateTime.Now;
    }
}
