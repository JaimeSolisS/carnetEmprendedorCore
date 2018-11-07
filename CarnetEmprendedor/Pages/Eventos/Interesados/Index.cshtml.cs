using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarnetEmprendedor.Data;

namespace CarnetEmprendedor.Pages.Eventos.Interesados
{
    public class IndexModel : PageModel
    {
        private readonly CarnetEmprendedor.Data.ApplicationDbContext _context;

        public IndexModel(CarnetEmprendedor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ListaInteresado> ListaInteresado { get;set; }

        public async Task OnGetAsync()
        {
            ListaInteresado = await _context.ListaInteresado
                .Include(l => l.Evento).ToListAsync();
        }
    }
}
