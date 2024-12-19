using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Data;
using PokemonAPI.Models;

namespace PokemonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly PokemonDbContext _context;

        public TeamController(PokemonDbContext context)
        {
            this._context = context;
        }

        [HttpGet] // Get: api/Team
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
        {
            var team = await _context.Teams.ToListAsync();
            return Ok(team);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }

        [HttpPost]
        public async Task<ActionResult<Team>> CreateTeam([FromBody] TeamCreateDto teamDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newTeam = new Team
            {
                TeamName = teamDto.TeamName,
                TrainerId = teamDto.TrainerId
            };

            _context.Teams.Add(newTeam);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTeam), new { id = newTeam.Id }, newTeam);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeam(int id, Team team)
        {
            if (id != team.Id)
            {
                return BadRequest();
            }

            _context.Entry(team).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!_context.Teams.Any(t => t.Id == id))
            {

                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            _context.Remove(team);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
