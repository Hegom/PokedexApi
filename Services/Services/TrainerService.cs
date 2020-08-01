using Pokedex.Data.Data;
using Pokedex.Data.Model;
using System.Threading.Tasks;

namespace Services.Services
{
    public class TrainerService : ITrainerService
    {
        public IPokedexRepository Repository { get; set; }

        public TrainerService(IPokedexRepository repository)
        {
            Repository = repository;
        }

        public async Task<bool> Create(Trainer trainer)
        {
            return await Repository.Create(trainer);
        }

        public async Task<Trainer> Find(string name)
        {
            return await Repository.Find(name);
        }

        public async Task<Trainer> Get(int id)
        {
            return await Repository.Get(id);
        }

        public async Task<bool> Update(int id, Trainer trainer)
        {
            return await Repository.Update(id, trainer);
        }
    }
}
