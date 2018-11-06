using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarnetEmprendedor.Data;

namespace CarnetEmprendedor.Pages.Categorias
{
    public class IndexModel : PageModel
    {
        private readonly CarnetEmprendedor.Data.ApplicationDbContext _context;

        public IndexModel(CarnetEmprendedor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Categoria> Categoria { get;set; }

        public async Task OnGetAsync()
        {
            Categoria = await _context.Categoria.ToListAsync();
        }
    }
}
