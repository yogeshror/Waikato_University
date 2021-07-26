using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Waikato_University.Data;
using Waikato_University.Models;

namespace Waikato_University.Pages.Allocations
{
    public class DeleteModel : PageModel
    {
        private readonly Waikato_University.Data.Waikato_UniversityContext _context;

        public DeleteModel(Waikato_University.Data.Waikato_UniversityContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Allocation Allocation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Allocation = await _context.Allocation
                .Include(a => a.Department)
                .Include(a => a.Lecturer)
                .Include(a => a.Module).FirstOrDefaultAsync(m => m.Id == id);

            if (Allocation == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Allocation = await _context.Allocation.FindAsync(id);

            if (Allocation != null)
            {
                _context.Allocation.Remove(Allocation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
