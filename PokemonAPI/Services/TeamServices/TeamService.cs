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

        public async Task<bool> UpdateTeamAsync(int id, Team team)
        {
            if (id != team.Id) return false;

            _context.Entry(team).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Teams.AnyAsync(t => t.Id == id))
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
