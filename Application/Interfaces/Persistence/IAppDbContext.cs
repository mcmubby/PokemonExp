using Domain.Pokemons;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces.Persistence
{
    public interface IAppDbContext
    {
        public DbSet<Pokemon> Pokemons { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        int SaveChanges();
    }
}
