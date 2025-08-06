using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TresEmpanadas.Data;
using TresEmpanadas.Models;

namespace TresEmpanadas.Pages.Incomes
{
    public class EditModel : PageModel
    {
        private readonly TresEmpanadas.Data.ApplicationDbContext _context;

        public EditModel(TresEmpanadas.Data.ApplicationDbContext context)
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

            var income =  await _context.Income.FirstOrDefaultAsync(m => m.Id == id);
            if (income == null)
            {
                return NotFound();
            }
            Income = income;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Income).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncomeExists(Income.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool IncomeExists(int id)
        {
            return _context.Income.Any(e => e.Id == id);
        }
    }
}
