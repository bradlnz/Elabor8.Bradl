using Elabor8.Bradl.Entities;
using Microsoft.EntityFrameworkCore;

namespace Elabor8.Bradl.Repository
{
    public class DataContext : DbContext
    {
        public DbSet<Fact> Facts { get; set; }
        public DbSet<User> Users { get; set; }

        private readonly string _dbPath;

        public DataContext()
        {
            var path = Directory.GetCurrentDirectory();
            _dbPath = Path.Join(path, "facts.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={_dbPath}");
    }
}