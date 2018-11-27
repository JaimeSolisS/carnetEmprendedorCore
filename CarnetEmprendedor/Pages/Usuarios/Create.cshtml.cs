using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarnetEmprendedor.Data;

namespace CarnetEmprendedor.Pages.Usuarios
{
    public class CreateModel : PageModel
    {
        private readonly CarnetEmprendedor.Data.ApplicationDbContext _context;

        public CreateModel(CarnetEmprendedor.Data.ApplicationDbContext context)
        {
            _context = context;
        }
       // IdentityUserid = user.Id, IdentityUserName=user.UserName

       public  string IdentityUserid { get; set; }

       public string IdentityUserName { get; set; }

        public IActionResult OnGet(string identityUserid, string identityUserName)
        {
        ViewData["MateriaId"] = new SelectList(_context.Materia, "Id", "Nombre");
            Usuario = new Usuario(); 
            Usuario.IdentityUserId = identityUserid;
               Usuario.IdentityUserName = identityUserName;
            return Page();
        }

        [BindProperty]
        public Usuario Usuario { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Usuario.Add(Usuario);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}