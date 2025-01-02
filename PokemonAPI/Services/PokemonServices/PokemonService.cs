using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Data;
using PokemonAPI.Models.Pokemon;

namespace PokemonAPI.Services.PokemonServices
{
    public class PokemonService : IPokemonService
    {
        private readonly PokemonDbContext _context;

        public PokemonService(PokemonDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pokemon>> GetAllPokemonsAsync()
        {
            return await _context.Pokemons.ToListAsync();
        }

        public async Task<Pokemon?> GetPokemonByIdAsync(int id)
        {
            return await _context.Pokemons.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Pokemon> CreatePokemonAsync(PokemonCreateDto pokemonDto)
        {
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

            return pokemon;
        }

        public async Task<bool> UpdatePokemonAsync(int id, PokemonCreateDto pokemonDto)
        {
            // Find the Pokemon to update
            var pokemon = await _context.Pokemons.FirstOrDefaultAsync(p => p.Id == id);

            if (pokemon == null)
            {
                return false;
            }

            //Update the Pokemon from the DTO
            pokemon.Name = pokemonDto.Name;
            pokemon.Type = pokemonDto.Type;
            pokemon.Level = pokemonDto.Level;
            pokemon.TrainerId = pokemonDto.TrainerId;
            pokemon.TeamId = pokemonDto.TeamId;

            _context.Entry(pokemon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Pokemons.AnyAsync(p => p.Id == id))
                    return false;

                throw;
            }
        }

        public async Task<bool> DeletePokemonAsync(int id)
        {
            var pokemon = await _context.Pokemons.FindAsync(id);
            if (pokemon == null)
            {
                return false;
            }

            _context.Remove(pokemon);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

