using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Waikato_University.Data;
using Waikato_University.Models;

namespace Waikato_University.Pages.Allocations
{
    public class EditModel : PageModel
    {
        private readonly Waikato_University.Data.Waikato_UniversityContext _context;

        public EditModel(Waikato_University.Data.Waikato_UniversityContext context)
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
           ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "Name");
           ViewData["LecturerId"] = new SelectList(_context.Lacturer, "Id", "Name");
           ViewData["ModuleId"] = new SelectList(_context.Module, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Allocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllocationExists(Allocation.Id))
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

        private bool AllocationExists(int id)
        {
            return _context.Allocation.Any(e => e.Id == id);
        }
    }
}
