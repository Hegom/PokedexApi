using Pokedex.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Api.Data
{
    public interface IPokedexRepository
    {
        Task<bool> Create(Trainer trainer);
        Task<Trainer> Find(string name);
        Task<bool> Update(int id, Trainer trainer);
        Task<Trainer> Get(int id);
    }
}
