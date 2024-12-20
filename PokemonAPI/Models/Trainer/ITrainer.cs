namespace PokemonAPI.Models.Trainer
{
    public interface ITrainer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
