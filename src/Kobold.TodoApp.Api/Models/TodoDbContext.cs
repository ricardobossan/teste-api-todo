using Microsoft.EntityFrameworkCore;

namespace Kobold.TodoApp.Api.Models
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            TodoSeed.Seed(modelBuilder);
        }
    }
}

