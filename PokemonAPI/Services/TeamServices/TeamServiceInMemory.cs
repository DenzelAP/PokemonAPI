using PokemonAPI.Models.Team;

namespace PokemonAPI.Services.TeamServices
{
    public class TeamServiceInMemory : ITeamService
    {
        private readonly List<Team> teams = new()
        {
            new Team { Id = 1, TeamName = "Team Rocket"},
            new Team { Id = 2, TeamName = "Team Magma" },
            new Team { Id = 3, TeamName = "Team Aqua" }
        };

        public Task<IEnumerable<Team>> GetAllTeamsAsync()
        {
            return Task.FromResult(teams.AsEnumerable());
        }

        public Task<Team> GetTeamByIdAsync(int id)
        {
            var result = teams.FirstOrDefault(t => t.Id == id);

            if (result == null)
            {
                throw new KeyNotFoundException($"Team with ID {id} not found.");
            }

            return Task.FromResult(result);
        }

        public Task<Team> CreateTeamAsync(TeamCreateDto teamDto)
        {
            if (string.IsNullOrWhiteSpace(teamDto.TeamName))
            {
                throw new ArgumentException("Team name is required.");
            }

            var newTeam = new Team
            {
                Id = teams.Max(t => t.Id) + 1,
                TeamName = teamDto.TeamName
            };

            teams.Add(newTeam);

            return Task.FromResult(newTeam);
        }

        public Task<bool> DeleteTeamAsync(int id)
        {
            var teamToDelete = teams.FirstOrDefault(t => t.Id == id);

            if (teamToDelete == null)
            {
                return Task.FromResult(false);
            }

            teams.Remove(teamToDelete);

            return Task.FromResult(true);
        }

        public Task<bool> UpdateTeamAsync(int id, TeamCreateDto teamDto)
        {
            var teamToUpdate = teams.FirstOrDefault(t => t.Id == id);

            if (teamToUpdate == null)
            {
                return Task.FromResult(false);
            }

            if (string.IsNullOrWhiteSpace(teamDto.TeamName))
            {
                throw new ArgumentException("Team name is required.");
            }

            teamToUpdate.TeamName = teamDto.TeamName;

            return Task.FromResult(true);
        }
    }
}
