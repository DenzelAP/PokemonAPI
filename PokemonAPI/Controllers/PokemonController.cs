using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Data;
using PokemonAPI.Models;

namespace PokemonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly PokemonDbContext _context;

        public PokemonController(PokemonDbContext context)
        {
            this._context = context;
        }

        [HttpGet] // Get: api/Pokemon
        public async Task<ActionResult<IEnumerable<Pokemon>>> GetPokemons()
        {
            var pokemon = await _context.Pokemons.ToListAsync();

            return Ok(pokemon);
        }

        [HttpGet("{id}")] // Get: api/Pokemon/5
        public async Task<ActionResult<Pokemon>> GetPokemon(int id)
        {
            var pokemon = await _context.Pokemons.FirstOrDefaultAsync(p => p.Id == id);

            if (pokemon == null)
            {
                return NotFound();
            }

            return Ok(pokemon);
        }

        [HttpPost] // Post: api/Pokemon
        public async Task<ActionResult<Pokemon>> CreatePokemon([FromBody] PokemonCreateDto pokemonDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pokemon = new Pokemon
            {
                Name = pokemonDto.Name,
                Type = pokemonDto.Type,
                Level = pokemonDto.Level,
                TrainerId = pokemonDto.TrainerId,
                TeamId = pokemonDto.TeamId
            };

            _context.Pokemons.Add(pokemon);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPokemon), new { id = pokemon.Id }, pokemon);
        }

        [HttpPut("{id}")] // Put: api/Pokemon/5
        public async Task<IActionResult> UpdatePokemon(int id, Pokemon pokemon)
        {
            if(id != pokemon.Id)
            {
                return BadRequest();
            }

            _context.Entry(pokemon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!_context.Pokemons.Any(p => p.Id == id))
            {

                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")] // Delete: api/Pokemon/5
        public async Task<IActionResult> DeletePokemon(int id)
        {
            var pokemon = await _context.Pokemons.FindAsync(id);
            if (pokemon == null)
            {
                return NotFound();
            }

            _context.Remove(pokemon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
