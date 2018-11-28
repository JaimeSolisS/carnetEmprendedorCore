using CarnetEmprendedor.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarnetEmprendedor.Services
{
    public class ServicioCategoria
    {
        private readonly CarnetEmprendedor.Data.ApplicationDbContext _context;

        public ServicioCategoria()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            _context = new ApplicationDbContext(options);
        }

        public ServicioCategoria (CarnetEmprendedor.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task <int> CrearNuevoAsync(Categoria categoria)
        {
            _context.Categoria.Add(categoria);
           int result = await _context.SaveChangesAsync();
            return result; 
        }
    }
}
