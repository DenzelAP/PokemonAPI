
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Data;
using PokemonAPI.Services.PokemonServices;
using PokemonAPI.Services.TeamServices;
using PokemonAPI.Services.TrainerService;

namespace PokemonAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var useInMemory = builder.Configuration.GetValue<bool?>("InMemoryDatabase")
                   ?? throw new InvalidOperationException("InMemoryDatabase configuration is missing.");


            if (useInMemory)
            {
                // Register in-memory services
                builder.Services.AddSingleton<IPokemonService, PokemonServiceInMemory>();
                builder.Services.AddSingleton<ITeamService, TeamServiceInMemory>();
                builder.Services.AddSingleton<ITrainerService, TrainerServiceInMemory>();
            }
            else
            {
                // Register database services
                builder.Services.AddDbContext<PokemonDbContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
                builder.Services.AddScoped<IPokemonService, PokemonService>();
                builder.Services.AddScoped<ITrainerService, TrainerService>();
                builder.Services.AddScoped<ITeamService, TeamService>();
            }

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
