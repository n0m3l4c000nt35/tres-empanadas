using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TresEmpanadas.Data;
using TresEmpanadas.Models;

namespace TresEmpanadas.Pages.Incomes
{
    public class IndexModel : PageModel
    {
        private readonly TresEmpanadas.Data.ApplicationDbContext _context;

        public IndexModel(TresEmpanadas.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Income> Income { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Income = await _context.Income
                .Include(i => i.User).ToListAsync();
        }
    }
}
