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

namespace Waikato_University.Pages.Lecturers
{
    public class EditModel : PageModel
    {
        private readonly Waikato_University.Data.Waikato_UniversityContext _context;

        public EditModel(Waikato_University.Data.Waikato_UniversityContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Lacturer Lacturer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Lacturer = await _context.Lacturer.FirstOrDefaultAsync(m => m.Id == id);

            if (Lacturer == null)
            {
                return NotFound();
            }
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

            _context.Attach(Lacturer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LacturerExists(Lacturer.Id))
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

        private bool LacturerExists(int id)
        {
            return _context.Lacturer.Any(e => e.Id == id);
        }
    }
}
