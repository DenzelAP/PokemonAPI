using PokemonAPI.Models.Pokemon;
using PokemonAPI.Models.Team;
using System.Collections.Generic;

namespace PokemonAPI.Models.Trainer
{
    public class Trainer : ITrainer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        // Navigation property
        public ICollection<Team.Team> Teams { get; set; } = new List<Team.Team>();
        public ICollection<Pokemon.Pokemon> Pokemons { get; set; } = new List<Pokemon.Pokemon>();
    }
}
