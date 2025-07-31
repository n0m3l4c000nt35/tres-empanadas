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
    public class DeleteModel : PageModel
    {
        private readonly TresEmpanadas.Data.ApplicationDbContext _context;

        public DeleteModel(TresEmpanadas.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var income = await _context.Income.FindAsync(id);
            if (income != null)
            {
                Income = income;
                _context.Income.Remove(Income);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
