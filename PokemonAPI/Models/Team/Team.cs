using PokemonAPI.Models.Pokemon;
using PokemonAPI.Models.Trainer;
using System.Collections.Generic;

namespace PokemonAPI.Models.Team
{
    public class Team : ITeam
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public int? TrainerId { get; set; }

        // Navigation properties
        public Trainer.Trainer Trainer { get; set; }
        public ICollection<Pokemon.Pokemon> Pokemons { get; set; } = new List<Pokemon.Pokemon>();
    }
}
