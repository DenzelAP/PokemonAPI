using System.ComponentModel.DataAnnotations;

namespace PokemonAPI.Models.Pokemon
{
    public class PokemonCreateDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Type is required.")]
        [MaxLength(20, ErrorMessage = "Type cannot exceed 20 characters.")]
        public string Type { get; set; }
        [Range(1, 100, ErrorMessage = "Level must be between 1 and 100.")]
        public int Level { get; set; } = 1; // Default value
        public int? TrainerId { get; set; } // Optional
        public int? TeamId { get; set; } // Optional
    }
}
