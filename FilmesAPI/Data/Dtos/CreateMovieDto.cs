using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class CreateMovieDto
    {
        [Required(ErrorMessage = "The tittle is required")]
        public string Tittle { get; set; }


        [Required(ErrorMessage = "The gender is required")]
        [StringLength(50, ErrorMessage = "The gender length cannot exceed 50 caracters")]
        public string Gender { get; set; }


        [Required]
        [Range(70, 600, ErrorMessage = "The duration must be between 70 and 600 minutes")]
        public int Duration { get; set; }
    }
}
