using CarnetEmprendedor.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarnetEmprendedor.Services
{
    public class ServicioMateria
    {
        private readonly CarnetEmprendedor.Data.ApplicationDbContext _context;

        public ServicioMateria()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            _context = new ApplicationDbContext(options);
        }

        public ServicioMateria(CarnetEmprendedor.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> CrearNuevoAsync(Materia carrera)
        {
            _context.Materia.Add(carrera);
            int result = await _context.SaveChangesAsync();
            return result;
        }
    }
}
