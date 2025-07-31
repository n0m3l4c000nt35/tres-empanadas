using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TresEmpanadas.Data;
using TresEmpanadas.Models;

namespace TresEmpanadas.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly TresEmpanadas.Data.ApplicationDbContext _context;

        public IndexModel(TresEmpanadas.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Category = await _context.Category
                .Include(c => c.User).ToListAsync();
        }
    }
}
