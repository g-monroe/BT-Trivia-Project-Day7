using Microsoft.EntityFrameworkCore;
using TriviaGame.Core.Models;

namespace TriviaGame.DataAccessHandlers.Infrastructure
{
    public class TriviaGameContext: DbContext
    {
        private string _connectionString;
        public TriviaGameContext(string connectionString): base()
        {
            _connectionString = connectionString;
        }

        public virtual DbSet<ToDoEntity> ToDos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoEntity>()
                .HasKey(t => t.Id);
        }
    }
}
