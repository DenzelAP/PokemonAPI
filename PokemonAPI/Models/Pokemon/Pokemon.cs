using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PokemonAPI.Models.Pokemon;
using PokemonAPI.Models.Team;

namespace PokemonAPI.Models.Pokemon
{
    public class Pokemon : IPokemon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Level { get; set; }
        public int? TrainerId { get; set; } // Foreign key
        public int? TeamId { get; set; } // Foreign key

        // Navigation properties
        public Trainer.Trainer Trainer { get; set; }
        public Team.Team Team { get; set; }
    }
}
