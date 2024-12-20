using Microsoft.EntityFrameworkCore;
using PokemonAPI.Data;
using PokemonAPI.Models.Trainer;

namespace PokemonAPI.Services.TrainerService
{
    public class TrainerService : ITrainerService
    {
        private readonly PokemonDbContext _context;

        public TrainerService(PokemonDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Trainer>> GetAllTrainersAsync()
        {
            return await _context.Trainers.ToListAsync();
        }

        public async Task<Trainer?> GetTrainerByIdAsync(int id)
        {
            return await _context.Trainers.FindAsync(id);
        }

        public async Task<Trainer> CreateTrainerAsync(TrainerCreateDto trainerDto)
        {
            var trainer = new Trainer
            {
                Name = trainerDto.Name,
                Age = trainerDto.Age
            };

            _context.Trainers.Add(trainer);
            await _context.SaveChangesAsync();

            return trainer;
        }

        public async Task<bool> DeleteTrainerAsync(int id)
        {
            var trainer = await _context.Trainers.FindAsync(id);
            if (trainer != null)
            {
                return false;
            }

            _context.Trainers.Remove(trainer);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateTrainerAsync(int id, Trainer updatedTrainer)
        {
            var trainer = await _context.Trainers.FindAsync(id);
            if (trainer == null)
            {
                return false;
            }

            trainer.Name = updatedTrainer.Name;
            trainer.Age = updatedTrainer.Age;

            _context.Trainers.Update(trainer);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
