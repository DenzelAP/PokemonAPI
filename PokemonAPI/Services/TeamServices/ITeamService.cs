using PokemonAPI.Models.Team;

namespace PokemonAPI.Services.TeamServices
{
    public interface ITeamService
    {
        public Task<IEnumerable<Team>> GetAllTeamsAsync();
        public Task<Team> GetTeamByIdAsync(int id);
        public Task<Team> CreateTeamAsync(TeamCreateDto teamDto);
        public Task<bool> UpdateTeamAsync(int id, Team team);
        public Task<bool> DeleteTeamAsync(int id);
    }
}
