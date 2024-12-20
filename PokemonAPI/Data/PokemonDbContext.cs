using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models.Pokemon;
using PokemonAPI.Models.Team;
using PokemonAPI.Models.Trainer;

namespace PokemonAPI.Data
{
    public class PokemonDbContext : DbContext
    {
        public PokemonDbContext(DbContextOptions<PokemonDbContext> options) : base(options)
        {
        }

        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>().HasData(
                new Pokemon { Id = 1, Name = "Squirtle", Type = "Water", Level = 25, TrainerId = 1, TeamId = 1 },
                new Pokemon { Id = 2, Name = "Charmander", Type = "Fire", Level = 12, TrainerId = 1, TeamId = 1 },
                new Pokemon {Id = 3, Name = "Bulbasaur", Type = "Grass", Level = 7, TrainerId = 1, TeamId = 1 },
                new Pokemon {Id = 4, Name = "Pikachu", Type = "Electric", Level = 1, TrainerId = 2, TeamId = 2 }
            );

            modelBuilder.Entity<Trainer>().HasData(
                new Trainer { Id = 1, Name = "Denzel", Age = 29 },
                new Trainer { Id = 2, Name = "Thomas", Age = 8 }
            );

            modelBuilder.Entity<Team>().HasData(
                new Team { Id = 1, TeamName = "Team Alpha", TrainerId = 1 },
                new Team { Id = 2, TeamName = "Team Beta", TrainerId = 2 }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
