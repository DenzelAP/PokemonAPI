namespace PokemonAPI.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }
        public ICollection<Pokemon> Pokemons { get; set; } = new List<Pokemon>();
    }
}
