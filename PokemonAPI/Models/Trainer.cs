namespace PokemonAPI.Models
{
    public class Trainer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public ICollection<Pokemon> Pokemons { get; set; } = new List<Pokemon>();
        public ICollection<Team> Teams { get; set; } = new List<Team>();
    }
}
