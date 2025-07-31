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
    public class DetailsModel : PageModel
    {
        private readonly TresEmpanadas.Data.ApplicationDbContext _context;

        public DetailsModel(TresEmpanadas.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Income Income { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var income = await _context.Income.FirstOrDefaultAsync(m => m.Id == id);
            if (income == null)
            {
                return NotFound();
            }
            else
            {
                Income = income;
            }
            return Page();
        }
    }
}
