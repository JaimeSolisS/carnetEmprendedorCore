using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarnetEmprendedor.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarnetEmprendedor.Pages.MisEventos
{
    public class IndexModel : PageModel
    {
        private readonly CarnetEmprendedor.Data.ApplicationDbContext _context;

        public IndexModel(CarnetEmprendedor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public int Id { get; set; }
        public int UsuarioId { get; set; }

        public IList<Evento> MisEventos { get; set; }

        public IActionResult OnGet()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage("../Index");
            }
            // ViewData["EventoId"] = new SelectList(_context.Evento, "Id", "Nombre");
            //Id = id.Value;

            var Identity = User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;

            UsuarioId = _context.Usuario.Where(u => u.IdentityUserId == Identity).SingleOrDefault().Id;

            MisEventos = _context.ListaInteresado.Where(u => u.UsuarioId == UsuarioId).Select(a => a.Evento).ToList();
            return Page();
        }
    }
}