using PokemonAPI.Models.Pokemon;

namespace PokemonAPI.Services.PokemonServices
{
    public class PokemonServiceInMemory : IPokemonService
    {
        private readonly List<Pokemon> pokemon = new()
        {
            new Pokemon { Id = 1, Name = "Blastoise", Type = "Water", Level = 25, TrainerId = 1, TeamId = 1 },
            new Pokemon { Id = 2, Name = "Charizard", Type = "Fire", Level = 12, TrainerId = 1, TeamId = 1 },
            new Pokemon { Id = 3, Name = "Venusaur", Type = "Grass", Level = 7, TrainerId = 1, TeamId = 1 },
            new Pokemon { Id = 4, Name = "Raichu", Type = "Electric", Level = 1, TrainerId = 2, TeamId = 2 }
        };

        public Task<IEnumerable<Pokemon>> GetAllPokemonsAsync()
        {
            return Task.FromResult(pokemon.AsEnumerable());
        }

        public Task<Pokemon> GetPokemonByIdAsync(int id)
        {
            var result = pokemon.FirstOrDefault(p => p.Id == id);

            if (result == null)
            {
                throw new KeyNotFoundException($"Pokemon with ID {id} not found.");
            }

            return Task.FromResult(result);
        }

        public Task<Pokemon> CreatePokemonAsync(PokemonCreateDto pokemonDto)
        {
            if (string.IsNullOrWhiteSpace(pokemonDto.Name) || string.IsNullOrWhiteSpace(pokemonDto.Type))
            {
                throw new ArgumentException("Pokemon name and type are required.");
            }

            var newPokemon = new Pokemon
            {
                Id = pokemon.Max(p => p.Id) + 1,
                Name = pokemonDto.Name,
                Type = pokemonDto.Type,
                Level = pokemonDto.Level,
                TrainerId = pokemonDto.TrainerId,
                TeamId = pokemonDto.TeamId
            };

            pokemon.Add(newPokemon);

            return Task.FromResult(newPokemon);
        }

        public Task<bool> DeletePokemonAsync(int id)
        {
            var pokemonToDelete = pokemon.FirstOrDefault(p => p.Id == id);

            if (pokemonToDelete == null)
            {
                return Task.FromResult(false);
            }

            pokemon.Remove(pokemonToDelete);

            return Task.FromResult(true);
        }

        public Task<bool> UpdatePokemonAsync(int id, PokemonCreateDto pokemonDto)
        {
            var pokemonToUpdate = this.pokemon.FirstOrDefault(p => p.Id == id);

            if (pokemonToUpdate == null)
            {
                return Task.FromResult(false);
            }

            if (string.IsNullOrWhiteSpace(pokemonDto.Name))
            {
                throw new ArgumentException("Pokemon name is required.");
            }

            // Update properties using the DTO
            pokemonToUpdate.Name = pokemonDto.Name;
            pokemonToUpdate.Type = pokemonDto.Type;
            pokemonToUpdate.Level = pokemonDto.Level;
            pokemonToUpdate.TrainerId = pokemonDto.TrainerId;
            pokemonToUpdate.TeamId = pokemonDto.TeamId;

            return Task.FromResult(true);
        }

    }
}
