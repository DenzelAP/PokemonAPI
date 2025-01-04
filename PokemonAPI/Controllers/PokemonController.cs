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
        private readonly IPokemonService pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            this.pokemonService = pokemonService;
        }

        [HttpGet] // Get: api/Pokemon
        public async Task<ActionResult<IEnumerable<Pokemon>>> GetPokemons()
        {
            var pokemon = await pokemonService.GetAllPokemonsAsync();

            return Ok(pokemon);
        }

        [HttpGet("{id}")] // Get: api/Pokemon/5
        public async Task<ActionResult<Pokemon>> GetPokemon(int id)
        {
            var pokemon = await pokemonService.GetPokemonByIdAsync(id);

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

            var createdPokemon = await pokemonService.CreatePokemonAsync(pokemonDto);

            return CreatedAtAction(nameof(GetPokemon), new { id = createdPokemon.Id }, createdPokemon);
        }

        [HttpPut("{id}")] // Put: api/Pokemon/5
        public async Task<IActionResult> UpdatePokemon(int id, PokemonCreateDto pokemonDto)
        {
            if (pokemonDto == null)
            {
                return BadRequest("Pokemon data is required.");
            }

            var updated = await pokemonService.UpdatePokemonAsync(id, pokemonDto);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")] // Delete: api/Pokemon/5
        public async Task<IActionResult> DeletePokemon(int id)
        {
            var deletedPokemon = await pokemonService.DeletePokemonAsync(id);

            if (!deletedPokemon)
            {
                return NotFound();
            }


            return NoContent();
        }

    }
}
