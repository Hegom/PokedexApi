using Pokedex.Data.Model;
using System.Threading.Tasks;

namespace Pokedex.Data.Data
{
    public interface IPokedexRepository
    {
        Task<bool> Create(Trainer trainer);
        Task<Trainer> Find(string name);
        Task<bool> Update(int id, Trainer trainer);
        Task<Trainer> Get(int id);
    }
}
