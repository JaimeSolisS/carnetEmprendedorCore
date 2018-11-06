using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarnetEmprendedor.Data;

namespace CarnetEmprendedor.Pages.Materias
{
    public class DetailsModel : PageModel
    {
        private readonly CarnetEmprendedor.Data.ApplicationDbContext _context;

        public DetailsModel(CarnetEmprendedor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Materia Materia { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Materia = await _context.Materia.FirstOrDefaultAsync(m => m.Id == id);

            if (Materia == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
