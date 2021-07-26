using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Waikato_University.Data;
using Waikato_University.Models;

namespace Waikato_University.Pages.Lecturers
{
    public class DeleteModel : PageModel
    {
        private readonly Waikato_University.Data.Waikato_UniversityContext _context;

        public DeleteModel(Waikato_University.Data.Waikato_UniversityContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Lacturer = await _context.Lacturer.FindAsync(id);

            if (Lacturer != null)
            {
                _context.Lacturer.Remove(Lacturer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
