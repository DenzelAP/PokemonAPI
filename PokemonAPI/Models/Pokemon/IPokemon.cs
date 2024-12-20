namespace PokemonAPI.Models.Pokemon
{
    public interface IPokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Level { get; set; }
        public int? TrainerId { get; set; }
        public int? TeamId { get; set; }
    }
}
