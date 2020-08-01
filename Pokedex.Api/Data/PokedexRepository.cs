using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pokedex.Api.Model;
using System;
using System.Threading.Tasks;

namespace Pokedex.Api.Data
{
    public class PokedexRepository : IPokedexRepository
    {
        private readonly IServiceScope _scope;
        private readonly PokedexApiContext _databaseContext;

        public PokedexRepository(IServiceProvider serviceProvider)
        {
            _scope = serviceProvider.CreateScope();
            _databaseContext = _scope.ServiceProvider.GetRequiredService<PokedexApiContext>();
        }

        public async Task<bool> Create(Trainer trainer)
        {
            _databaseContext.Trainer.Add(trainer);
            var result = await _databaseContext.SaveChangesAsync();
            return result == 1;
        }

        public async Task<Trainer> Find(string name)
        {
            var result = await _databaseContext.Trainer.FirstOrDefaultAsync(x => x.FullName.Contains(name));
            return result;
        }

        public async Task<Trainer> Get(int id)
        {
            var result = await _databaseContext.Trainer.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<bool> Update(int id, Trainer trainer)
        {
            if (id != trainer.Id)
            {
                return false;
            }

            _databaseContext.Entry(trainer).State = EntityState.Modified;

            var result = await _databaseContext.SaveChangesAsync();

            return result == 1;
        }
    }
}
