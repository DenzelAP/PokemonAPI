using PokemonAPI.Models.Trainer;

namespace PokemonAPI.Services.TrainerService
{
    public class TrainerServiceInMemory : ITrainerService
    {
        private readonly List<Trainer> trainers = new()
        {
            new Trainer { Id = 1, Name = "Ash Ketchum", Age = 20 },
            new Trainer { Id = 2, Name = "Misty", Age = 21 },
            new Trainer { Id = 3, Name = "Brock", Age = 22  }
        };

        public Task<IEnumerable<Trainer>> GetAllTrainersAsync()
        {
            return Task.FromResult(trainers.AsEnumerable());
        }

        public Task<Trainer> GetTrainerByIdAsync(int id)
        {
            var trainer = trainers.FirstOrDefault(t => t.Id == id);

            if (trainer == null)
            {
                throw new KeyNotFoundException($"Trainer with ID {id} not found.");
            }

            return Task.FromResult(trainer);
        }

        public Task<Trainer> CreateTrainerAsync(TrainerCreateDto trainerDto)
        {
            if (string.IsNullOrWhiteSpace(trainerDto.Name))
            {
                throw new ArgumentException("Trainer name is required.");
            }

            var newTrainer = new Trainer
            {
                Id = trainers.Max(t => t.Id) + 1,
                Name = trainerDto.Name
            };

            trainers.Add(newTrainer);

            return Task.FromResult(newTrainer);
        }

        public Task<bool> DeleteTrainerAsync(int id)
        {
            var trainer = trainers.FirstOrDefault(t => t.Id == id);

            if (trainer == null)
            {
                return Task.FromResult(false);
            }

            trainers.Remove(trainer);

            return Task.FromResult(true);
        }

        public Task<bool> UpdateTrainerAsync(int id, TrainerCreateDto trainerDto)
        {
            var trainerToUpdate = trainers.FirstOrDefault(t => t.Id == id);

            if (trainerToUpdate == null)
            {
                return Task.FromResult(false);
            }

            trainerToUpdate.Name = trainerDto.Name;
            trainerToUpdate.Age = trainerDto.Age;

            return Task.FromResult(true);
        }
    }
}
