using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TresEmpanadas.Models;

namespace TresEmpanadas.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<TresEmpanadas.Models.Category> Category { get; set; } = default!;
        public DbSet<TresEmpanadas.Models.Expense> Expense { get; set; } = default!;
        public DbSet<TresEmpanadas.Models.Income> Income { get; set; } = default!;
    }
}
