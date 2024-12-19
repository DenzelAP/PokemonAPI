using System.ComponentModel.DataAnnotations;

namespace PokemonAPI.Models
{
    public class TrainerCreateDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Name { get; set; }

        [Range(1, 150, ErrorMessage = "Age must be between 1 and 150.")]
        public int Age { get; set; } // Age validation
    }
}
