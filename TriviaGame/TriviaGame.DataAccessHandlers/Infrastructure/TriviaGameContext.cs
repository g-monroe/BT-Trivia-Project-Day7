using Microsoft.EntityFrameworkCore;
using TriviaGame.Core.Models;

namespace TriviaGame.DataAccessHandlers.Infrastructure
{
    public class TriviaGameContext: DbContext
    {
        public virtual DbSet<ToDoEntity> ToDos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Blogging;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoEntity>()
                .HasKey(t => t.Id);
        }
    }
}
