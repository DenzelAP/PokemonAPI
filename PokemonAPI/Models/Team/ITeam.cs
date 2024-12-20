namespace PokemonAPI.Models.Team
{
    public interface ITeam
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public int? TrainerId { get; set; }
    }
}
