using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarnetEmprendedor.Data;

namespace CarnetEmprendedor.Pages.Eventos
{
    public class EditModel : PageModel
    {
        private readonly CarnetEmprendedor.Data.ApplicationDbContext _context;

        public EditModel(CarnetEmprendedor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Evento Evento { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Evento = await _context.Evento
                .Include(e => e.Categoria).FirstOrDefaultAsync(m => m.Id == id);

            if (Evento == null)
            {
                return NotFound();
            }
           ViewData["CategoriaEventoId"] = new SelectList(_context.Categoria, "Id", "CategoriaEvento");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Evento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoExists(Evento.Id))
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

        private bool EventoExists(int id)
        {
            return _context.Evento.Any(e => e.Id == id);
        }
    }
}
