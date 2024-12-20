using PokemonAPI.Models.Pokemon;

namespace PokemonAPI.Services.PokemonServices
{
    public interface IPokemonService
    {
        public Task<IEnumerable<Pokemon>> GetAllPokemonsAsync();
        public Task<Pokemon> GetPokemonByIdAsync(int id);
        public Task<Pokemon> CreatePokemonAsync(PokemonCreateDto pokemonDto);
        public Task<bool> UpdatePokemonAsync(int id, Pokemon pokemon);
        public Task<bool> DeletePokemonAsync(int id);
    }
}
