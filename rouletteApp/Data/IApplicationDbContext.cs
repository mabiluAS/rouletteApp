using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Threading.Tasks;
using System.Threading;
using rouletteApp.Models;

namespace rouletteApp.Data
{
    public interface IApplicationDbContext
    {
        public IDbConnection Connection { get; }
        DatabaseFacade Database { get; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Spin> Spins { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
