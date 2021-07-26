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
    public class IndexModel : PageModel
    {
        private readonly Waikato_University.Data.Waikato_UniversityContext _context;

        public IndexModel(Waikato_University.Data.Waikato_UniversityContext context)
        {
            _context = context;
        }

        public IList<Lacturer> Lacturer { get;set; }

        public async Task OnGetAsync()
        {
            Lacturer = await _context.Lacturer.ToListAsync();
        }
    }
}
