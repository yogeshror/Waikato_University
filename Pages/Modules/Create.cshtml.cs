using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Waikato_University.Data;
using Waikato_University.Models;

namespace Waikato_University.Pages.Modules
{
    public class CreateModel : PageModel
    {
        private readonly Waikato_University.Data.Waikato_UniversityContext _context;

        public CreateModel(Waikato_University.Data.Waikato_UniversityContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Module Module { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Module.Add(Module);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
