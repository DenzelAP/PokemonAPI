using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Data;
using PokemonAPI.Models.Team;
using PokemonAPI.Services.TeamServices;

namespace PokemonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            this._teamService = teamService;
        }

        [HttpGet] // Get: api/Team
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
        {
            var teams = await _teamService.GetAllTeamsAsync();
            return Ok(teams);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id)
        {
            var team = await _teamService.GetTeamByIdAsync(id);
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

            var newTeam = await _teamService.CreateTeamAsync(teamDto);

            return CreatedAtAction(nameof(GetTeam), new { id = newTeam.Id }, newTeam);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeam(int id, Team team)
        {
            if (id != team.Id)
            {
                return BadRequest();
            }

            var result = await _teamService.UpdateTeamAsync(id, team);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var result = await _teamService.DeleteTeamAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
