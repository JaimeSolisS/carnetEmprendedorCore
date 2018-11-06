using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarnetEmprendedor.Data;

namespace CarnetEmprendedor.Pages.Materias
{
    public class EditModel : PageModel
    {
        private readonly CarnetEmprendedor.Data.ApplicationDbContext _context;

        public EditModel(CarnetEmprendedor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Materia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MateriaExists(Materia.Id))
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

        private bool MateriaExists(int id)
        {
            return _context.Materia.Any(e => e.Id == id);
        }
    }
}
