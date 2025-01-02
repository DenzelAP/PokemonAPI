using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Data;
using PokemonAPI.Models.Team;

namespace PokemonAPI.Services.TeamServices
{
    public class TeamService : ITeamService
    {
        private readonly PokemonDbContext _context;

        public TeamService(PokemonDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Team>> GetAllTeamsAsync()
        {
            return await _context.Teams.ToListAsync();
        }

        public async Task<Team?> GetTeamByIdAsync(int id)
        {
            return await _context.Teams.FindAsync(id);
        }


        public async Task<Team> CreateTeamAsync(TeamCreateDto teamDto)
        {
            var newTeam = new Team
            {
                TeamName = teamDto.TeamName,
                TrainerId = teamDto.TrainerId
            };

            _context.Teams.Add(newTeam);
            await _context.SaveChangesAsync();

            return newTeam;
        }

        public async Task<bool> UpdateTeamAsync(int id, TeamCreateDto teamDto)
        {
            // Find the existing Team by ID
            var teamToUpdate = await _context.Teams.FirstOrDefaultAsync(t => t.Id == id);

            if (teamToUpdate == null) return false;

            // Update properties from the DTO
            teamToUpdate.TeamName = teamDto.TeamName;

            _context.Entry(teamToUpdate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Teams.AnyAsync(t => t.Id == id)) // AnyAsync returns a boolean if any element in the collection matches the condition
                    return false;

                throw;
            }
        }

        public async Task<bool> DeleteTeamAsync(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null) return false;

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
