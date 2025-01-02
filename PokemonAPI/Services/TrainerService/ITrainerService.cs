using PokemonAPI.Models.Trainer;

namespace PokemonAPI.Services.TrainerService
{
    public interface ITrainerService
    {
        public Task<IEnumerable<Trainer>> GetAllTrainersAsync();
        public Task<Trainer> GetTrainerByIdAsync(int id);
        public Task<Trainer> CreateTrainerAsync(TrainerCreateDto trainerDto);
        public Task<bool> UpdateTrainerAsync(int id, TrainerCreateDto trainer);
        public Task<bool> DeleteTrainerAsync(int id);
    }
}
