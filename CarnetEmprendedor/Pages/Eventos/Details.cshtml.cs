using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarnetEmprendedor.Data;

namespace CarnetEmprendedor.Pages.Eventos
{
    public class DetailsModel : PageModel
    {
        private readonly CarnetEmprendedor.Data.ApplicationDbContext _context;

        public DetailsModel(CarnetEmprendedor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
