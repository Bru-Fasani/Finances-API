using Microsoft.EntityFrameworkCore;

namespace Finances_API.Controllers.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações adicionais do modelo
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Alimentação", Description = "Refeições e alimentos" },
                new Category { Id = 2, Name = "Transporte", Description = "Transporte público e combustível" },
                new Category { Id = 3, Name = "Moradia", Description = "Aluguel, contas e manutenção" },
                new Category { Id = 4, Name = "Lazer", Description = "Entretenimento e hobbies" },
                new Category { Id = 5, Name = "Saúde", Description = "Planos de saúde e medicamentos" }
            );
        }
    }
}
