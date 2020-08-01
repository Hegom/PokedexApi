using Microsoft.AspNetCore.Mvc;
using Pokedex.Api.Data;
using Pokedex.Api.Model;
using System.Threading.Tasks;

namespace Pokedex.Api.Controllers
{
    [Route("api/[controller]")]
    [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
    [ApiController]
    public class TrainersController : ControllerBase
    {
        private readonly IPokedexRepository _repository;

        public TrainersController(IPokedexRepository repository)
        {
            _repository = repository;
        }

        //// GET: api/Trainers/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Trainer>> GetTrainer(int id)
        //{
        //    var trainer = await _repository.Get(id);

        //    if (trainer == null)
        //    {
        //        return NotFound();
        //    }

        //    return trainer;
        //}

        // GET: api/Trainers/juan
        [HttpGet("{searchString}")]
        public async Task<ActionResult<Trainer>> Find([FromRoute] string searchString)
        {
            var trainer = await _repository.Find(searchString);

            if (trainer == null)
            {
                return NotFound();
            }

            return trainer;

        }

        // PUT: api/Trainers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainer(int id, Trainer trainer)
        {
            var result = await _repository.Update(id, trainer);
            if (result) return Ok();
            else return BadRequest();
        }

        // POST: api/Trainers
        [HttpPost]
        public async Task<ActionResult<Trainer>> PostTrainer(Trainer trainer)
        {
            var result = await _repository.Create(trainer);
            if (result) return Ok();
            else return BadRequest();
        }
    }
}
