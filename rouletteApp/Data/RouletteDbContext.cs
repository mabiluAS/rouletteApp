using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using rouletteApp.Models;
using System.Data;

namespace rouletteApp.Data
{
    public class RouletteDbContext : DbContext, IApplicationDbContext
    {
        public RouletteDbContext(DbContextOptions<RouletteDbContext> options) : base() { }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<Spin> Spins { get; set; }

        public IDbConnection Connection => Database.GetDbConnection();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "Roulette.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);
        }
    }
}
