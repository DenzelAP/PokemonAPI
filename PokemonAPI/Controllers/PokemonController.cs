using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Data;
using PokemonAPI.Models.Pokemon;
using PokemonAPI.Services.PokemonServices;

namespace PokemonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(PokemonDbContext context, IPokemonService pokemonService)
        {
            this._pokemonService = pokemonService;
        }

        [HttpGet] // Get: api/Pokemon
        public async Task<ActionResult<IEnumerable<Pokemon>>> GetPokemons()
        {
            var pokemon = await _pokemonService.GetAllPokemonsAsync();

            return Ok(pokemon);
        }

        [HttpGet("{id}")] // Get: api/Pokemon/5
        public async Task<ActionResult<Pokemon>> GetPokemon(int id)
        {
            var pokemon = await _pokemonService.GetPokemonByIdAsync(id);

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

            var createdPokemon = await _pokemonService.CreatePokemonAsync(pokemonDto);

            return CreatedAtAction(nameof(GetPokemon), new { id = createdPokemon.Id }, createdPokemon);
        }

        [HttpPut("{id}")] // Put: api/Pokemon/5
        public async Task<IActionResult> UpdatePokemon(int id, Pokemon pokemon)
        {
           var updated = await _pokemonService.UpdatePokemonAsync(id, pokemon);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")] // Delete: api/Pokemon/5
        public async Task<IActionResult> DeletePokemon(int id)
        {
            var deletedPokemon = await _pokemonService.DeletePokemonAsync(id);

            if (!deletedPokemon)
            {
                return NotFound();
            }


            return NoContent();
        }

    }
}
