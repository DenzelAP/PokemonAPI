using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models.Trainer;
using PokemonAPI.Services.TrainerService;

namespace PokemonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {

        private readonly ITrainerService trainerService;

        public TrainerController(ITrainerService trainer)
        {
            this.trainerService = trainer;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trainer>>> GetTrainers()
        {
            var trainers = await trainerService.GetAllTrainersAsync();
            return Ok(trainers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Trainer>> GetTrainer(int id)
        {
            var trainer = await trainerService.GetTrainerByIdAsync(id);
            if (trainer == null)
            {
                return NotFound();
            }
            return Ok(trainer);
        }

        [HttpPost]
        public async Task<ActionResult<Trainer>> CreateTrainer([FromBody] TrainerCreateDto trainerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newTrainer = await trainerService.CreateTrainerAsync(trainerDto);

            return CreatedAtAction(nameof(GetTrainer), new { id = newTrainer.Id }, newTrainer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrainer(int id, [FromBody] TrainerCreateDto trainerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await trainerService.UpdateTrainerAsync(id, trainerDto);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainer(int id)
        {
            var result = await trainerService.DeleteTrainerAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
