using Pokedex.Data.Data;
using Pokedex.Data.Model;
using System.Threading.Tasks;

namespace Services.Services
{
    public class TrainerService : ITrainerService
    {
        public IPokedexRepository _respository { get; set; }

        public TrainerService(IPokedexRepository respository)
        {
            _respository = respository;
        }

        public async Task<bool> Create(Trainer trainer)
        {

            return await _respository.Create(trainer);
        }

        public async Task<Trainer> Find(string name)
        {
            return await _respository.Find(name);
        }

        public async Task<Trainer> Get(int id)
        {
            return await _respository.Get(id);
        }

        public async Task<bool> Update(int id, Trainer trainer)
        {
            return await _respository.Update(id, trainer);
        }
    }
}
