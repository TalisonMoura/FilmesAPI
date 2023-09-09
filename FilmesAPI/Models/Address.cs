using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Address
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Patio { get; set; }
        public int Number { get; set; }

    }
}
