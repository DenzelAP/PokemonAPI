using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Data;
using PokemonAPI.Models;

namespace PokemonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly PokemonDbContext _context;

        public TrainerController(PokemonDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trainer>>> GetTrainers()
        {
            var trainers = await _context.Trainers.ToListAsync();
            return Ok(trainers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Trainer>> GetTrainer(int id)
        {
            var trainer = await _context.Trainers.FindAsync(id);
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

            var NewTrainer = new Trainer
            {
                Name = trainerDto.Name,
                Age = trainerDto.Age
            };

            _context.Trainers.Add(NewTrainer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTrainer), new { id = NewTrainer.Id }, NewTrainer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrainer(int id, Trainer trainer)
        {
            if (id != trainer.Id)
            {
                return BadRequest();
            }

            _context.Entry(trainer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!_context.Trainers.Any(t => t.Id == id))
            {

                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainer(int id)
        {
            var trainer = await _context.Trainers.FindAsync(id);
            if (trainer == null)
            {
                return NotFound();
            }

            _context.Remove(trainer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
