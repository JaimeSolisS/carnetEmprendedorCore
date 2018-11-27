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

        public IList<ListaInteresado> Interesados { get; set; }
        public int NumInteresados { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Evento = await _context.Evento
                .Include(e => e.Categoria).FirstOrDefaultAsync(m => m.Id == id);

            Interesados = _context.ListaInteresado.Include(t => t.Evento).Include(T => T.Usuario)
                .Where(x => x.EventoId == id).OrderBy(t => t.Usuario.Matricula)
                                                   
                .ToList();
            NumInteresados = Interesados.Count(); 
            if (Evento == null)
            {
                return NotFound();
            }
            return Page();
        }

       
    }
}
