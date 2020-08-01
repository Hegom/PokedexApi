using Microsoft.AspNetCore.Mvc;
using Pokedex.Data.Model;
using Services.Services;
using System.Threading.Tasks;

namespace Pokedex.Api.Controllers
{
    [Route("api/[controller]")]
    [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
    [ApiController]
    public class TrainersController : ControllerBase
    {
        private readonly ITrainerService _service;

        public TrainersController(ITrainerService service)
        {
            _service = service;
        }        

        // GET: api/Trainers/juan
        [HttpGet("{searchString}")]
        public async Task<ActionResult<Trainer>> Find([FromRoute] string searchString)
        {
            var trainer = await _service.Find(searchString);

            if (trainer == null)
            {
                return NotFound();
            }

            return Ok(trainer);
        }

        // PUT: api/Trainers/5        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainer(int id, Trainer trainer)
        {
            var result = await _service.Update(id, trainer);
            if (result) return Ok();
            else return BadRequest();
        }

        // POST: api/Trainers
        [HttpPost]
        public async Task<ActionResult<Trainer>> PostTrainer(Trainer trainer)
        {
            var result = await _service.Create(trainer);
            if (result) return Ok();
            else return BadRequest();
        }
    }
}
