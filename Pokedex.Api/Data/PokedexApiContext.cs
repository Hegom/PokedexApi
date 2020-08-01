using Microsoft.EntityFrameworkCore;
using Pokedex.Api.Model;

namespace Pokedex.Api.Data
{
    public class PokedexApiContext : DbContext
    {
        public PokedexApiContext (DbContextOptions<PokedexApiContext> options)
            : base(options)
        {
        }        

        public DbSet<Trainer> Trainer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PokedexApiContext).Assembly);
            modelBuilder.Entity<Trainer>().HasKey(x => x.Id);
        }
    }
}
