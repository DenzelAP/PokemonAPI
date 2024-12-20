using System.ComponentModel.DataAnnotations;

namespace PokemonAPI.Models.Team
{
    public class TeamCreateDto
    {
        [Required(ErrorMessage = "TeamName is required.")]
        [MaxLength(50, ErrorMessage = "TeamName cannot exceed 50 characters.")]
        public string TeamName { get; set; }

        [Required(ErrorMessage = "TrainerId is required.")]
        public int TrainerId { get; set; } // Ensures every team belongs to a trainer
    }
}
