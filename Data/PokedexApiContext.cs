using Microsoft.EntityFrameworkCore;
using Pokedex.Data.Model;

namespace Pokedex.Data
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
