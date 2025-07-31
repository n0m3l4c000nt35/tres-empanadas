using Microsoft.EntityFrameworkCore;
using TresEmpanadas.Models;

namespace TresEmpanadas.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<TresEmpanadas.Models.Category> Category { get; set; } = default!;
        public DbSet<TresEmpanadas.Models.Expense> Expense { get; set; } = default!;
        public DbSet<TresEmpanadas.Models.Income> Income { get; set; } = default!;
        public DbSet<TresEmpanadas.Models.User> User { get; set; } = default!;
    }
}
