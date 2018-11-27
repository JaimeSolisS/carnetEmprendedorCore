using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarnetEmprendedor.Data;

namespace CarnetEmprendedor.Pages.Eventos.Interesados
{
    public class CreateModel : PageModel
    {
        private readonly CarnetEmprendedor.Data.ApplicationDbContext _context;

        public CreateModel(CarnetEmprendedor.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int Boletos { get; set; }
        

        public IActionResult OnGet(int? id)
        {
        ViewData["EventoId"] = new SelectList(_context.Evento, "Id", "Nombre");
            Id = id.Value;
            // Boletos = _context.Evento.Find(Id).NumBoletos; 
            var Identity = User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
            UsuarioId= _context.Usuario.Where(u => u.IdentityUserId == Identity).SingleOrDefault().Id;
          
          //  UsuarioId = _context.Usuario.Where(u => u.IdentityUserId == Identity).SingleOrDefault().ListaInteresado;
           return Page();
        }

        [BindProperty]
        public ListaInteresado ListaInteresado { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
          //  Boletos = Boletos - 1;
            //_context.Evento.Find(Id).NumBoletos = Boletos; 
            _context.ListaInteresado.Add(ListaInteresado);

           var Evento =  _context.Evento.FirstOrDefault(m => m.Id == ListaInteresado.EventoId);
            Evento.NumBoletos -= 1;

            await _context.SaveChangesAsync();

            return RedirectToPage("../Index");
        }
    }
}