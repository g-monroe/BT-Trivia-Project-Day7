using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using TriviaGame.Core.Models;

namespace TriviaGame.DataAccessHandlers.Infrastructure
{
    public class TriviaGameContext: DbContext
    {
        public TriviaGameContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<ToDoEntity> ToDos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoEntity>()
                .HasKey(t => t.Id);
        }
    }
}
