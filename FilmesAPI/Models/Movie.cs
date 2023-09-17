using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "The tittle is required")]
        public string Tittle { get; set; }


        [Required(ErrorMessage = "The gender is required")]
        [MaxLength(50, ErrorMessage = "The gender length cannot exceed 50 caracters")]
        public string Gender { get; set; }


        [Required]
        [Range(70, 600, ErrorMessage = "The duration must be between 70 and 600 minutes")]
        public int Duration { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}

